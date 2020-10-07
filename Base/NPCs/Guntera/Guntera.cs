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

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    [AutoloadBossHead]
    public class Guntera : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guntera");
            Main.npcFrameCount[npc.type] = 8;
        }

        public override void SetDefaults()
        {
            npc.width = 86;
            npc.height = 86;
            npc.damage = 375;
            npc.defense = 100;
            npc.lifeMax = 1500000;
            npc.HitSound = SoundID.NPCHit1;
            npc.DeathSound = SoundID.NPCDeath1;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            for (int i = 0; i < npc.buffImmune.Length; i++)
                npc.buffImmune[i] = true;
            npc.buffImmune[ModContent.BuffType<Gun>()] = false;
            npc.aiStyle = -1;
            npc.value = Item.buyPrice(2);
            npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;

            npc.boss = true;
            music = MusicID.Plantera;
            musicPriority = MusicPriority.BossHigh;
            npc.netAlways = true;
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            npc.TargetClosest(false);

            if (npc.HasValidTarget && npc.Distance(Main.player[npc.target].Center) < 6000)
            {
                npc.timeLeft = 60;
            }
            else
            {
                npc.active = false;
                npc.life = 0;
                NetMessage.SendData(MessageID.SyncNPC, number: npc.whoAmI);
            }

            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;

            if (npc.localAI[1] == 0 && npc.life < npc.lifeMax * 0.4f)
            {
                npc.localAI[1] = 1;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    for (int i = 0; i < Main.maxNPCs; ++i)
                    {
                        if (Main.npc[i].active && Main.npc[i].type == ModContent.NPCType<GunteraHook>())
                        {
                            for (int j = 0; j < 3; ++j)
                            {
                                int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunteraTentacle>(), npc.whoAmI, ai2: i, ai3: npc.whoAmI);
                                if (n != Main.maxNPCs)
                                {
                                    if (Main.netMode == NetmodeID.Server)
                                        NetMessage.SendData(MessageID.SyncNPC, number: n);
                                }
                            }
                        }
                    }
                }
            }

            if (npc.localAI[2] == 0 && npc.life < npc.lifeMax / 2)
            {
                npc.localAI[2] = 1;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    for (int i = 0; i < 6; i++)
                    {
                        int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunteraHook>(), npc.whoAmI, ai3: npc.whoAmI);
                        if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.SyncNPC, number: n);
                    }
                }
            }
            
            if (npc.localAI[3] == 0)
            {
                npc.localAI[3] = 1;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunCelebration>(), npc.whoAmI, npc.whoAmI);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunMagnum>(), npc.whoAmI, npc.whoAmI, -1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunUzi>(), npc.whoAmI, npc.whoAmI, 1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunShotgun>(), npc.whoAmI, npc.whoAmI, -1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunQuad>(), npc.whoAmI, npc.whoAmI, 1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunSniper>(), npc.whoAmI, npc.whoAmI, -1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunSniper>(), npc.whoAmI, npc.whoAmI, 1);
                    if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                        NetMessage.SendData(MessageID.SyncNPC, number: n);

                    for (int i = 0; i < 5; i++)
                    {
                        n = NPC.NewNPC((int)npc.Center.X, (int)npc.Center.Y, ModContent.NPCType<GunteraHook>(), npc.whoAmI, ai3: npc.whoAmI);
                        if (n != Main.maxNPCs && Main.netMode == NetmodeID.Server)
                            NetMessage.SendData(MessageID.SyncNPC, number: n);
                    }
                }

                npc.netUpdate = true;
            }

            bool flag1 = false;
            bool flag2 = false;
            if (Main.player[npc.target].dead)
            {
                flag1 = true;
                flag2 = true;
            }
            int[] numArray = new int[11];
            float num1 = 0.0f;
            float num2 = 0.0f;
            int index1 = 0;
            for (int index2 = 0; index2 < Main.maxNPCs; ++index2)
            {
                if (Main.npc[index2].active && Main.npc[index2].type == ModContent.NPCType<GunteraHook>())
                {
                    num1 += (float)Main.npc[index2].Center.X;
                    num2 += (float)Main.npc[index2].Center.Y;
                    numArray[index1] = index2;
                    ++index1;
                    if (index1 >= 11)
                        break;
                }
            }
            float num3 = num1 / (float)index1;
            float num4 = num2 / (float)index1;
            float num5 = 2.5f;
            float num6 = 0.025f;
            if (npc.life < npc.lifeMax / 2)
            {
                num5 = 5f;
                num6 = 0.05f;
            }
            if (npc.life < npc.lifeMax / 4)
                num5 = 7f;
            if (!Main.player[npc.target].ZoneJungle || (double)Main.player[npc.target].position.Y < Main.worldSurface * 16.0 || Main.player[npc.target].position.Y > (double)((Main.maxTilesY - 200) * 16))
            {
                flag1 = true;
                num5 += 8f;
                num6 = 0.15f;

                npc.damage = npc.defDamage * 10;
                npc.defense = npc.defDefense * 10;
            }
            if (Main.expertMode)
            {
                num5 = (num5 + 1f) * 1.1f;
                num6 = (num6 + 0.01f) * 1.1f;
            }
            Vector2 vector2_1 = new Vector2(num3, num4);
            float num7 = (float)(Main.player[npc.target].Center.X - vector2_1.X);
            float num8 = (float)(Main.player[npc.target].Center.Y - vector2_1.Y);
            if (flag2)
            {
                num8 *= -1f;
                num7 *= -1f;
                num5 += 8f;
            }
            float num9 = (float)Math.Sqrt((double)num7 * (double)num7 + (double)num8 * (double)num8);
            int num10 = 500;
            if (flag1)
                num10 += 350;
            if (Main.expertMode)
                num10 += 150;
            if ((double)num9 >= (double)num10)
            {
                float num11 = (float)num10 / num9;
                num7 *= num11;
                num8 *= num11;
            }
            float num12 = num3 + num7;
            float num13 = num4 + num8;
            vector2_1 = npc.Center;
            float num14 = num12 - (float)vector2_1.X;
            float num15 = num13 - (float)vector2_1.Y;
            float num16 = (float)Math.Sqrt((double)num14 * (double)num14 + (double)num15 * (double)num15);
            float num17;
            float num18;
            if ((double)num16 < (double)num5)
            {
                num17 = (float)npc.velocity.X;
                num18 = (float)npc.velocity.Y;
            }
            else
            {
                float num11 = num5 / num16;
                num17 = num14 * num11;
                num18 = num15 * num11;
            }
            if (npc.velocity.X < (double)num17)
            {
                npc.velocity.X += num6;
                if (npc.velocity.X < 0.0 && (double)num17 > 0.0)
                {
                    npc.velocity.X += num6 * 2f;
                }
            }
            else if (npc.velocity.X > (double)num17)
            {
                npc.velocity.X -= num6;
                if (npc.velocity.X > 0.0 && (double)num17 < 0.0)
                {
                    npc.velocity.X -= num6 * 2f;
                }
            }
            if (npc.velocity.Y < (double)num18)
            {
                npc.velocity.Y += num6;
                if (npc.velocity.Y < 0.0 && (double)num18 > 0.0)
                {
                    npc.velocity.Y += num6 * 2f;
                }
            }
            else if (npc.velocity.Y > (double)num18)
            {
                npc.velocity.Y -= num6;
                if (npc.velocity.Y > 0.0 && (double)num18 < 0.0)
                {
                    npc.velocity.Y -= num6 * 2f;
                }
            }

            if (npc.life < npc.lifeMax / 2)
                npc.position += npc.velocity;

            npc.rotation = npc.DirectionTo(Main.player[npc.target].Center).ToRotation() + (float)Math.PI / 2;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Gun>(), 600);
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.life < npc.lifeMax / 2)
            {
                if (npc.frame.Y < 4 * frameHeight)
                    npc.frame.Y = 4 * frameHeight;

                if (++npc.frameCounter > 6)
                {
                    npc.frameCounter = 0;
                    npc.frame.Y += frameHeight;
                    if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                        npc.frame.Y = 4 * frameHeight;
                }
            }
            else
            {
                if (npc.frame.Y >= 4 * frameHeight)
                    npc.frame.Y = 0;

                if (++npc.frameCounter > 6)
                {
                    npc.frameCounter = 0;
                    npc.frame.Y += frameHeight;
                    if (npc.frame.Y >= 4 * frameHeight)
                        npc.frame.Y = 0;
                }
            }
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override void BossHeadRotation(ref float rotation)
        {
            rotation = npc.rotation;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(drawColor), npc.rotation, origin2, npc.scale, SpriteEffects.None, 0f);
            
            for (int i = 0; i < Main.maxNPCs; i++)
            {
                if (Main.npc[i].active && Main.npc[i].ai[0] == npc.whoAmI &&
                    (Main.npc[i].type == ModContent.NPCType<GunCelebration>()
                    || Main.npc[i].type == ModContent.NPCType<GunMagnum>()
                    || Main.npc[i].type == ModContent.NPCType<GunQuad>()
                    || Main.npc[i].type == ModContent.NPCType<GunShotgun>()
                    || Main.npc[i].type == ModContent.NPCType<GunSniper>()
                    || Main.npc[i].type == ModContent.NPCType<GunUzi>()))
                {
                    texture2D13 = Main.npcTexture[Main.npc[i].type];
                    rectangle = Main.npc[i].frame;
                    origin2 = rectangle.Size() / 2f;
                    Main.spriteBatch.Draw(texture2D13, Main.npc[i].Center - Main.screenPosition + new Vector2(0f, Main.npc[i].gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), Main.npc[i].GetAlpha(drawColor), Main.npc[i].rotation, origin2, Main.npc[i].scale,
                        npc.spriteDirection > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
                }
            }
            return false;
        }
    }
}