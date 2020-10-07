using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using FargowiltasSouls.NPCs;

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    public class GunteraTentacle : ModNPC
    {
        public override string Texture => "Terraria/NPC_264";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guntera's Tentacle");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.PlanterasTentacle];
        }

        public override void SetDefaults()
        {
            npc.width = 24;
            npc.height = 24;
            npc.damage = 400;
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
            npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = 0;
            return true;
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            int ai2 = (int)npc.ai[2];
            if (!(ai2 >= 0 && ai2 < Main.maxNPCs && Main.npc[ai2].active && Main.npc[ai2].type == ModContent.NPCType<GunteraHook>()))
            {
                npc.active = false;
                return;
            }

            npc.position += Main.npc[ai2].velocity;

            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;

            int ai3 = (int)npc.ai[3];
            if (Main.netMode != 1)
            {
                npc.localAI[0] -= 1f;
                if ((double)npc.localAI[0] <= 0.0)
                {
                    npc.localAI[0] = (float)Main.rand.Next(120, 480);
                    npc.ai[0] = (float)Main.rand.Next(-100, 101);
                    npc.ai[1] = (float)Main.rand.Next(-100, 101);
                    npc.netUpdate = true;
                }
            }
            npc.TargetClosest(true);
            float num1 = 0.2f;
            float num2 = 200f;
            if ((double)Main.npc[ai3].life < (double)Main.npc[ai3].lifeMax * 0.25)
                num2 += 100f;
            if ((double)Main.npc[ai3].life < (double)Main.npc[ai3].lifeMax * 0.1)
                num2 += 100f;
            if (Main.expertMode)
            {
                float num31 = (float)(1.0 - (double)npc.life / (double)npc.lifeMax);
                num2 += num31 * 300f;
                num1 += 0.3f;
            }

            float num3 = (float)Main.npc[ai2].position.X + (float)(Main.npc[ai2].width / 2);
            float num4 = (float)Main.npc[ai2].position.Y + (float)(Main.npc[ai2].height / 2);
            Vector2 vector2 = new Vector2(num3, num4);
            float num5 = num3 + npc.ai[0];
            float num6 = num4 + npc.ai[1];
            float num7 = num5 - (float)vector2.X;
            float num8 = num6 - (float)vector2.Y;
            float num9 = (float)Math.Sqrt((double)num7 * (double)num7 + (double)num8 * (double)num8);
            float num10 = num2 / num9;
            float num11 = num7 * num10;
            float num12 = num8 * num10;
            if (npc.position.X < (double)num3 + (double)num11)
            {
                npc.velocity.X += num1;
                if (npc.velocity.X < 0.0 && (double)num11 > 0.0)
                {
                    npc.velocity.X *= 0.9f;
                }
            }
            else if (npc.position.X > (double)num3 + (double)num11)
            {
                npc.velocity.X -= num1;
                if (npc.velocity.X > 0.0 && (double)num11 < 0.0)
                {
                    npc.velocity.X *= 0.9f;
                }
            }
            if (npc.position.Y < (double)num4 + (double)num12)
            {
                npc.velocity.Y += num1;
                if (npc.velocity.Y < 0.0 && (double)num12 > 0.0)
                {
                    npc.velocity.Y *= 0.9f;
                }
            }
            else if (npc.position.Y > (double)num4 + (double)num12)
            {
                npc.velocity.Y -= num1;
                if (npc.velocity.Y > 0.0 && (double)num12 < 0.0)
                {
                    npc.velocity.Y *= 0.9f;
                }
            }
            if (npc.velocity.X > 8)
                npc.velocity.X = 8;
            if (npc.velocity.X < -8)
                npc.velocity.X = -8;
            if (npc.velocity.Y > 8)
                npc.velocity.Y = 8;
            if (npc.velocity.Y < -8)
                npc.velocity.Y = -8;
            if ((double)num11 > 0.0)
            {
                npc.spriteDirection = 1;
                npc.rotation = (float)Math.Atan2((double)num12, (double)num11);
            }
            if ((double)num11 >= 0.0)
                return;
            npc.spriteDirection = -1;
            npc.rotation = (float)Math.Atan2((double)num12, (double)num11) + 3.14f;

            if (!Main.player[npc.target].ZoneJungle || (double)Main.player[npc.target].position.Y < Main.worldSurface * 16.0 || Main.player[npc.target].position.Y > (double)((Main.maxTilesY - 200) * 16))
            {
                npc.damage = npc.defDamage * 10;
                npc.defense = npc.defDefense * 10;
            }

            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.9 || Main.npc[ai2].life < Main.npc[ai2].lifeMax * 0.9)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.8 || Main.npc[ai2].life < Main.npc[ai2].lifeMax * 0.8)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.7 || Main.npc[ai2].life < Main.npc[ai2].lifeMax * 0.7)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.6 || Main.npc[ai2].life < Main.npc[ai2].lifeMax * 0.6)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.5 || Main.npc[ai2].life < Main.npc[ai2].lifeMax * 0.5)
                npc.localAI[1]++;
            if (!Main.player[npc.target].ZoneJungle || (double)Main.player[npc.target].position.Y < Main.worldSurface * 16.0 || Main.player[npc.target].position.Y > (double)((Main.maxTilesY - 200) * 16))
            {
                npc.localAI[1] += 3;
                npc.damage = npc.defDamage * 10;
                npc.defense = npc.defDefense * 10;
            }

            if (npc.localAI[1] > 80)
            {
                npc.localAI[1] = Main.rand.Next(-20, 20);
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    float speedModifier = Main.rand.NextFloat(2, 20f);
                    Projectile.NewProjectile(npc.Center, npc.DirectionTo(Main.player[npc.target].Center) * speedModifier,
                        ModContent.ProjectileType<GunteraBullet>(), npc.damage / 4, 0f, Main.myPlayer,
                        npc.Distance(Main.player[npc.target].Center) / speedModifier);
                }
            }
        }

        public override void FindFrame(int frameHeight)
        {
            npc.frameCounter = npc.frameCounter + 1.0;
            if (npc.frameCounter >= 6.0)
            {
                npc.frame.Y += frameHeight;
                npc.frameCounter = 0.0;
            }
            if (npc.frame.Y >= frameHeight * Main.npcFrameCount[npc.type])
                npc.frame.Y = 0;
        }

        public override void OnHitPlayer(Player target, int damage, bool crit)
        {
            target.AddBuff(ModContent.BuffType<Gun>(), 600);
        }

        public override bool CheckActive()
        {
            return false;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color drawColor)
        {
            if (npc.ai[2] > -1 && npc.ai[2] < Main.maxNPCs && Main.npc[(int)npc.ai[2]].active
                && Main.npc[(int)npc.ai[2]].type == ModContent.NPCType<GunteraHook>())
            {
                Texture2D texture = Main.chain27Texture;
                Vector2 position = npc.Center;
                Vector2 mountedCenter = Main.npc[(int)npc.ai[2]].Center;
                Rectangle? sourceRectangle = new Rectangle?();
                Vector2 origin = new Vector2(texture.Width * 0.5f, texture.Height * 0.5f);
                float num1 = texture.Height;
                Vector2 vector24 = mountedCenter - position;
                float rotation = (float)Math.Atan2(vector24.Y, vector24.X) - 1.57f;
                bool flag = true;
                if (float.IsNaN(position.X) && float.IsNaN(position.Y))
                    flag = false;
                if (float.IsNaN(vector24.X) && float.IsNaN(vector24.Y))
                    flag = false;
                while (flag)
                    if (vector24.Length() < num1 + 1.0)
                    {
                        flag = false;
                    }
                    else
                    {
                        Vector2 vector21 = vector24;
                        vector21.Normalize();
                        position += vector21 * num1;
                        vector24 = mountedCenter - position;
                        Color color2 = Lighting.GetColor((int)position.X / 16, (int)(position.Y / 16.0));
                        color2 = npc.GetAlpha(color2);
                        Main.spriteBatch.Draw(texture, position - Main.screenPosition, sourceRectangle, color2, rotation, origin, 1f, SpriteEffects.None, 0.0f);
                    }
            }

            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(drawColor), npc.rotation, origin2, npc.scale, SpriteEffects.None, 0f);
            return false;
        }
    }
}