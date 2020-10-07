using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;
using FargowiltasSouls.NPCs;

namespace FargowiltasSoulsDLC.Base.NPCs.Ceiling
{
    public class CeilingOfMoonLordEye : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceiling of Moon Lord");
        }

        public override void SetDefaults()
        {
            npc.width = 74;
            npc.height = 74;
            npc.damage = 125;
            npc.defense = 350;
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
            npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            int ai0 = (int)npc.ai[0];
            if (!(ai0 >= 0 && ai0 < Main.maxNPCs && Main.npc[ai0].active && Main.npc[ai0].type == ModContent.NPCType<CeilingOfMoonLord>()))
            {
                npc.active = false;
                return;
            }

            npc.realLife = ai0;
            npc.target = Main.npc[npc.realLife].target;
            npc.direction = npc.spriteDirection = (int)npc.ai[1];

            npc.Center = Main.npc[npc.realLife].Center;
            npc.position.X += 115 * npc.ai[1];

            int shootNum = 5;
            npc.localAI[1] += 1.5f;
            if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax * 0.75)
            {
                npc.localAI[1]++;
                shootNum++;
            }
            if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax * 0.5)
            {
                npc.localAI[1]++;
                shootNum++;
            }
            if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax * 0.25)
            {
                npc.localAI[1]++;
                shootNum += 2;
            }
            if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax * 0.1)
            {
                npc.localAI[1] += 4f;
                shootNum += 6;
            }

            if (npc.localAI[2] == 0)
            {
                if (npc.localAI[1] > 600)
                {
                    npc.localAI[1] = 0f;
                    npc.localAI[2] = 1f;
                }
            }
            else
            {
                if (npc.localAI[1] > 45)
                {
                    npc.localAI[1] = 0;
                    if (++npc.localAI[2] >= shootNum)
                        npc.localAI[2] = 0;

                    if (Main.netMode != NetmodeID.MultiplayerClient)
                    {
                        Vector2 vel = 9f * npc.DirectionTo(Main.player[npc.target].Center + Main.player[npc.target].velocity * 15f);
                        Projectile.NewProjectile(npc.Center, vel, ProjectileID.PhantasmalBolt, npc.damage / 6, 0f, Main.myPlayer);
                    }
                }
            }

            if (++npc.localAI[0] >= 300)
            {
                if (npc.localAI[0] % 20 == 0 && Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(npc.Center, Vector2.Zero, ModContent.ProjectileType<CeilingSphere>(), npc.damage / 6, 0f, Main.myPlayer, npc.target);
                }

                if (npc.localAI[0] > 420)
                {
                    npc.localAI[0] = 0;
                }
            }
            else if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax / 2)
            {
                npc.localAI[0]++;
            }
        }

        public override bool? DrawHealthBar(byte hbPosition, ref float scale, ref Vector2 position)
        {
            return false;
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
    }
}