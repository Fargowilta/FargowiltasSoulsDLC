using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using System.IO;
using FargowiltasSouls.NPCs;

namespace FargowiltasSoulsDLC.Base.NPCs.Ceiling
{
    [AutoloadBossHead]
    public class CeilingOfMoonLord : ModNPC
    {
        private int ceilingProj = -1;

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceiling of Moon Lord");
        }

        public override void SetDefaults()
        {
            npc.width = 46;
            npc.height = 60;
            npc.damage = 125;
            npc.defense = 50;
            npc.lifeMax = 325000;
            npc.HitSound = SoundID.NPCHit57;
            npc.DeathSound = SoundID.NPCDeath11;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.buffImmune[BuffID.Suffocation] = true;
            npc.buffImmune[BuffID.Confused] = true;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(1, 50);
            //npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;

            npc.boss = true;
            music = MusicID.LunarBoss;
            musicPriority = MusicPriority.BossHigh;
            npc.netAlways = true;
        }

        public override void SendExtraAI(BinaryWriter writer)
        {
            writer.Write(ceilingProj);
        }

        public override void ReceiveExtraAI(BinaryReader reader)
        {
            ceilingProj = reader.ReadInt32();
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            if (!npc.HasValidTarget)
                npc.TargetClosest(false);

            if (!(ceilingProj >= 0 && ceilingProj < Main.maxProjectiles 
                && Main.projectile[ceilingProj].active && Main.projectile[ceilingProj].type == ModContent.ProjectileType<CeilingProj>()))
            {
                if (Main.netMode != NetmodeID.MultiplayerClient)
                    ceilingProj = Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<CeilingProj>(), 0, 0f, Main.myPlayer, 0f, npc.whoAmI);

                npc.netUpdate = true;
            }

            if (npc.localAI[3] == 0)
            {
                npc.localAI[3] = 1;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CeilingOfMoonLordEye>(), npc.whoAmI, npc.whoAmI, 1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    npc.ai[0] = n;

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CeilingOfMoonLordEye>(), npc.whoAmI, npc.whoAmI, -1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    npc.ai[1] = n;

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<CeilingOfMoonLordFace>(), npc.whoAmI, npc.whoAmI);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    npc.ai[2] = n;
                }

                npc.netUpdate = true;
            }

            if (Main.LocalPlayer.active && !Main.LocalPlayer.dead && !Main.LocalPlayer.ghost)
            {
                Main.LocalPlayer.AddBuff(ModContent.BuffType<Moonified>(), 2);

                if (Main.LocalPlayer.Center.Y < npc.Center.Y - 32 //teleport and hurt if player is EVER above boss or too far to sides
                    || Main.LocalPlayer.Center.Y > npc.Center.Y + 1500
                    || Math.Abs(Main.LocalPlayer.Center.X - npc.Center.X) > 1500)
                {
                    Vector2 teleportPos = npc.Center;
                    teleportPos.Y += 250;

                    bool hurt = Main.LocalPlayer.Center.Y < npc.Center.Y;

                    for (int i = 0; i < 50; i++)
                    {
                        int d = Dust.NewDust(Main.player[Main.myPlayer].position, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 229, 0f, 0f, 0, default(Color), 2.5f);
                        Main.dust[d].noGravity = true;
                        Main.dust[d].noLight = true;
                        Main.dust[d].velocity *= 9f;
                    }

                    Main.LocalPlayer.Teleport(teleportPos);
                    NetMessage.SendData(MessageID.Teleport, -1, -1, null, 0, Main.LocalPlayer.whoAmI, teleportPos.X, teleportPos.Y, 1);
                    Main.LocalPlayer.velocity = Vector2.Zero;
                    if (hurt)
                    {
                        Main.LocalPlayer.Hurt(PlayerDeathReason.ByNPC(npc.whoAmI), npc.damage, 1);
                        Main.LocalPlayer.immune = false;
                        Main.LocalPlayer.immuneTime = 0;
                        Main.LocalPlayer.hurtCooldowns[0] = 0;
                        Main.LocalPlayer.hurtCooldowns[1] = 0;
                    }

                    for (int i = 0; i < 50; i++)
                    {
                        int d = Dust.NewDust(Main.player[Main.myPlayer].position, Main.player[Main.myPlayer].width, Main.player[Main.myPlayer].height, 229, 0f, 0f, 0, default(Color), 2.5f);
                        Main.dust[d].noGravity = true;
                        Main.dust[d].noLight = true;
                        Main.dust[d].velocity *= 9f;
                    }
                }

                if (Main.LocalPlayer.ZoneUnderworldHeight) //kill when reached underworld
                {
                    Main.LocalPlayer.KillMe(PlayerDeathReason.ByOther(12), 9999, 0, false);
                }
            }

            if (npc.position.Y > Main.maxTilesY * 16) //despawn upon exiting the bottom of world
            {
                npc.active = false;
            }

            npc.velocity.Y = 1.5f;
            if (npc.life < npc.lifeMax * 0.75)
                npc.velocity.Y += 0.25f;
            if (npc.life < npc.lifeMax * 0.5)
                npc.velocity.Y += 0.4f;
            if (npc.life < npc.lifeMax * 0.25)
                npc.velocity.Y += 0.5f;
            if (npc.life < npc.lifeMax * 0.1)
                npc.velocity.Y += 0.6f;
            if (npc.life < npc.lifeMax * 0.66 && Main.expertMode)
                npc.velocity.Y += 0.3f;
            if (npc.life < npc.lifeMax * 0.33 && Main.expertMode)
                npc.velocity.Y += 0.3f;
            if (npc.life < npc.lifeMax * 0.05 && Main.expertMode)
                npc.velocity.Y += 0.6f;
            if (npc.life < npc.lifeMax * 0.035 && Main.expertMode)
                npc.velocity.Y += 0.6f;
            if (npc.life < npc.lifeMax * 0.025 && Main.expertMode)
                npc.velocity.Y += 0.6f;
            if (Main.expertMode)
                npc.velocity.Y = npc.velocity.Y * 1.35f + 0.35f;

            if (Math.Abs(Main.player[npc.target].Center.X - npc.Center.X) > 150)
                npc.velocity.X = 2 * npc.velocity.Y * Math.Sign(Main.player[npc.target].Center.X - npc.Center.X);

            if (npc.life < npc.lifeMax / 2)
                npc.localAI[0]++;

            if (++npc.localAI[0] > 300)
            {
                npc.localAI[0] = 0;
                if (Main.netMode != NetmodeID.MultiplayerClient) //spray homing eyes
                {
                    for (int i = 0; i < 6; i++)
                    {
                        Projectile.NewProjectile(npc.Center + Main.rand.NextVector2Square(0f, npc.width), Vector2.UnitX.RotatedByRandom(Math.PI) * 6f,
                            ProjectileID.PhantasmalEye, npc.damage / 7, 0f, Main.myPlayer);
                    }
                }
            }
        }

        public override void HitEffect(int hitDirection, double damage)
        {
            for (int i = 0; i < 3; i++)
            {
                int d = Dust.NewDust(npc.position, npc.width, npc.height, 229, 0f, 0f, 0, default(Color), 1f);
                Main.dust[d].noGravity = true;
                Main.dust[d].noLight = true;
                Main.dust[d].velocity *= 3f;
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override Color? GetAlpha(Color drawColor)
        {
            return Color.White;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(drawColor), npc.rotation, origin2, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}