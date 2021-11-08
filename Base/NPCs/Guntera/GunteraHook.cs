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
    public class GunteraHook : ModNPC
    {
        public override string Texture => "Terraria/NPC_263";

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guntera's Hook");
            Main.npcFrameCount[npc.type] = Main.npcFrameCount[NPCID.PlanterasHook];
        }

        public override void SetDefaults()
        {
            npc.width = 40;
            npc.height = 40;
            npc.damage = 400;
            npc.defense = 100;
            npc.lifeMax = 1500000;
            npc.HitSound = SoundID.NPCHit4;
            npc.DeathSound = SoundID.NPCDeath14;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            for (int i = 0; i < npc.buffImmune.Length; i++)
                npc.buffImmune[i] = true;
            npc.buffImmune[ModContent.BuffType<Gun>()] = false;
            npc.aiStyle = -1;
            //npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;

            npc.dontTakeDamage = true;
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            int ai3 = (int)npc.ai[3];
            if (!(ai3 >= 0 && ai3 < Main.maxNPCs && Main.npc[ai3].active && Main.npc[ai3].type == ModContent.NPCType<Guntera>()))
            {
                npc.active = false;
                return;
            }

            npc.target = Main.npc[ai3].target;

            if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 2 && Main.npc[ai3].HasValidTarget)
            {
                if (npc.Distance(Main.player[Main.npc[ai3].target].Center + Main.player[npc.target].velocity * 30) > 700)
                {
                    Vector2 targetPos = Main.player[Main.npc[ai3].target].Center / 16; //pick a new target pos near player
                    targetPos.X += Main.rand.Next(-40, 41);
                    targetPos.Y += Main.rand.Next(-40, 41);

                    Tile tile = Framing.GetTileSafely((int)targetPos.X, (int)targetPos.Y);
                    npc.localAI[0] = 600; //reset vanilla timer for picking new block
                    if (Main.netMode != NetmodeID.MultiplayerClient)
                        npc.netUpdate = true;

                    npc.ai[0] = targetPos.X;
                    npc.ai[1] = targetPos.Y;
                }
            }

            npc.position += npc.velocity;

            bool flag1 = false;
            bool flag2 = false;

            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;

            if (Main.player[Main.npc[ai3].target].dead)
                flag2 = true;
            if (((ai3 != -1 && !Main.player[Main.npc[ai3].target].ZoneJungle || (double)Main.player[Main.npc[ai3].target].position.Y < Main.worldSurface * 16.0 ? 1 : (Main.player[Main.npc[ai3].target].position.Y > (double)((Main.maxTilesY - 200) * 16) ? 1 : 0)) | (flag2 ? 1 : 0)) != 0)
            {
                npc.localAI[0] -= 4f;
                flag1 = true;
                npc.damage = npc.defDamage * 10;
                npc.defense = npc.defDefense * 10;
            }
            if (Main.netMode == 1)
            {
                if ((double)npc.ai[0] == 0.0)
                    npc.ai[0] = (float)(int)(npc.Center.X / 16.0);
                if ((double)npc.ai[1] == 0.0)
                    npc.ai[1] = (float)(int)(npc.Center.X / 16.0);
            }
            if (Main.netMode != 1)
            {
                if ((double)npc.ai[0] == 0.0 || (double)npc.ai[1] == 0.0)
                    npc.localAI[0] = 0.0f;
                npc.localAI[0]--;
                if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 2)
                {
                    npc.localAI[0] -= 2f;
                }
                if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 4)
                {
                    npc.localAI[0] -= 2f;
                }
                if (flag1)
                {
                    npc.localAI[0] -= 6f;
                }
                if (!flag2 && (double)npc.localAI[0] <= 0.0 && (double)npc.ai[0] != 0.0)
                {
                    for (int index = 0; index < 200; ++index)
                    {
                        if (index != npc.whoAmI && Main.npc[index].active && Main.npc[index].type == npc.type && (Main.npc[index].velocity.X != 0.0 || Main.npc[index].velocity.Y != 0.0))
                            npc.localAI[0] = (float)Main.rand.Next(60, 300);
                    }
                }
                if ((double)npc.localAI[0] <= 0.0)
                {
                    npc.localAI[0] = (float)Main.rand.Next(300, 600);
                    bool flag3 = false;
                    int num1 = 0;
                    while (!flag3 && num1 <= 1000)
                    {
                        ++num1;
                        int num2 = (int)(Main.player[Main.npc[ai3].target].Center.X / 16.0);
                        int num3 = (int)(Main.player[Main.npc[ai3].target].Center.Y / 16.0);
                        if ((double)npc.ai[0] == 0.0)
                        {
                            num2 = (int)((Main.player[Main.npc[ai3].target].Center.X + Main.npc[ai3].Center.X) / 32.0);
                            num3 = (int)((Main.player[Main.npc[ai3].target].Center.Y + Main.npc[ai3].Center.Y) / 32.0);
                        }
                        if (flag2)
                        {
                            num2 = (int)Main.npc[ai3].position.X / 16;
                            num3 = (int)(Main.npc[ai3].position.Y + 400.0) / 16;
                        }
                        int num4 = 20 + (int)(100.0 * ((double)num1 / 1000.0));
                        int i = num2 + Main.rand.Next(-num4, num4 + 1);
                        int j = num3 + Main.rand.Next(-num4, num4 + 1);
                        if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 2 && Main.rand.Next(6) == 0)
                        {
                            npc.TargetClosest(true);
                            int index1 = (int)(Main.player[npc.target].Center.X / 16.0);
                            int index2 = (int)(Main.player[npc.target].Center.Y / 16.0);
                            if ((int)Main.tile[index1, index2].wall > 0)
                            {
                                i = index1;
                                j = index2;
                            }
                        }
                        try
                        {
                            if (!WorldGen.SolidTile(i, j))
                            {
                                if ((int)Main.tile[i, j].wall > 0)
                                {
                                    if (num1 <= 500)
                                    {
                                        if (Main.npc[ai3].life >= Main.npc[ai3].lifeMax / 2)
                                            continue;
                                    }
                                }
                                else
                                    continue;
                            }
                            flag3 = true;
                            npc.ai[0] = (float)i;
                            npc.ai[1] = (float)j;
                            npc.netUpdate = true;
                        }
                        catch
                        {
                        }
                    }
                }
            }
            if ((double)npc.ai[0] <= 0.0 || (double)npc.ai[1] <= 0.0)
                return;
            float num5 = 6f;
            if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 2)
                num5 = 8f;
            if (Main.npc[ai3].life < Main.npc[ai3].lifeMax / 4)
                num5 = 10f;
            if (Main.expertMode)
                ++num5;
            if (Main.expertMode && Main.npc[ai3].life < Main.npc[ai3].lifeMax / 2)
                ++num5;
            if (flag1)
                num5 *= 2f;
            if (flag2)
                num5 *= 2f;
            Vector2 vector2_1 = npc.Center;
            float num6 = (float)((double)npc.ai[0] * 16.0 - 8.0 - vector2_1.X);
            float num7 = (float)((double)npc.ai[1] * 16.0 - 8.0 - vector2_1.Y);
            float num8 = (float)Math.Sqrt((double)num6 * (double)num6 + (double)num7 * (double)num7);
            if ((double)num8 < 12.0 + (double)num5)
            {
                npc.velocity.X = num6;
                npc.velocity.Y = num7;
            }
            else
            {
                float num1 = num5 / num8;
                npc.velocity.X = num6 * num1;
                npc.velocity.Y = num7 * num1;
            }
            Vector2 vector2_2 = npc.Center;
            float num9 = (float)(Main.npc[ai3].Center.X - vector2_2.X);
            npc.rotation = (float)Math.Atan2((double)(float)(Main.npc[ai3].Center.Y - vector2_2.Y), (double)num9) - 1.57f;
        }

        public override void FindFrame(int frameHeight)
        {
            if (npc.velocity.X == 0.0 && npc.velocity.Y == 0.0)
            {
                npc.frame.Y = 0;
            }
            else
            {
                npc.frame.Y = frameHeight;
            }
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
            if (npc.ai[3] > -1 && npc.ai[3] < Main.maxNPCs && Main.npc[(int)npc.ai[3]].active
                && Main.npc[(int)npc.ai[3]].type == ModContent.NPCType<Guntera>())
            {
                Texture2D texture = Main.chain26Texture;
                Vector2 position = npc.Center;
                Vector2 mountedCenter = Main.npc[(int)npc.ai[3]].Center;
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