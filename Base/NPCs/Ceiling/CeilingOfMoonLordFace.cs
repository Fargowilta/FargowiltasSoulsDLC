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
    public class CeilingOfMoonLordFace : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceiling of Moon Lord");
        }

        public override void SetDefaults()
        {
            npc.width = 274;
            npc.height = 122;
            npc.damage = 125;
            npc.defense = 350;
            npc.lifeMax = 325000;
            npc.HitSound = SoundID.NPCHit57;
            npc.DeathSound = SoundID.NPCDeath11;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            for (int i = 0; i < npc.buffImmune.Length; i++)
                npc.buffImmune[i] = true;
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
            npc.position.Y += 100;

            if (Main.npc[npc.realLife].life < Main.npc[npc.realLife].lifeMax / 2)
                npc.localAI[0]++;
            if (++npc.localAI[0] > 660)
            {
                npc.localAI[0] = 0;
                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    int modifier = Main.player[npc.target].Center.X < npc.Center.X ? -1 : 1;
                    Projectile.NewProjectile(npc.Center, -Vector2.UnitY.RotatedBy(Math.PI / 2 * modifier), ModContent.ProjectileType<CeilingDeathray>(),
                        npc.damage / 4, 0f, Main.myPlayer, (float)Math.PI / 2 * modifier / 120 * 1.3f, npc.whoAmI);
                }
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            damage = 0;
            crit = false;
            return false;
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            projectile.timeLeft = 0;
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