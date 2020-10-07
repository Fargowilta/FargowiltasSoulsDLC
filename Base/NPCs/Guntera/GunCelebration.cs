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
    public class GunCelebration : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celebration Mk2");
        }

        public override void SetDefaults()
        {
            npc.width = 78;
            npc.height = 28;
            npc.damage = 500;
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
            npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;
        }

        public virtual void Offset(NPC guntera)
        {
            npc.Center = guntera.Center + new Vector2(0, -64).RotatedBy(guntera.rotation);
        }

        public override void AI()
        {
            npc.timeLeft = 60;

            if (npc.localAI[3] == 0)
            {
                npc.localAI[3] = Main.rand.NextFloat(4);
            }

            int ai0 = (int)npc.ai[0];
            if (!(ai0 >= 0 && ai0 < Main.maxNPCs && Main.npc[ai0].active && Main.npc[ai0].type == ModContent.NPCType<Guntera>()))
            {
                npc.active = false;
                return;
            }

            npc.TargetClosest(false);
            npc.direction = npc.spriteDirection = npc.ai[0] < 0 ? -1 : 1;

            Offset(Main.npc[ai0]);

            float targetRotation = npc.DirectionTo(Main.player[npc.target].Center).ToRotation();
            float bottom = (float)Math.PI * npc.localAI[3];
            float top = (float)Math.PI * (npc.localAI[3] + 2);
            if (targetRotation > top)
                targetRotation -= (float)Math.PI * 2;
            if (targetRotation < bottom)
                targetRotation += (float)Math.PI * 2;

            npc.rotation += Math.Sign(targetRotation - npc.rotation) * MathHelper.ToRadians(1);
            if (npc.rotation > top)
                npc.rotation -= (float)Math.PI * 2;
            if (npc.rotation < bottom)
                npc.rotation += (float)Math.PI * 2;

            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;

            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.9 || Main.npc[ai0].life < Main.npc[ai0].lifeMax * 0.9)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.8 || Main.npc[ai0].life < Main.npc[ai0].lifeMax * 0.8)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.7 || Main.npc[ai0].life < Main.npc[ai0].lifeMax * 0.7)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.6 || Main.npc[ai0].life < Main.npc[ai0].lifeMax * 0.6)
                npc.localAI[1]++;
            npc.localAI[1]++;
            if (npc.life < npc.lifeMax * 0.5 || Main.npc[ai0].life < Main.npc[ai0].lifeMax * 0.5)
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

                float speedModifier = 1f - (float)npc.life / npc.lifeMax;
                if (speedModifier < 1f - (float)Main.npc[ai0].life / Main.npc[ai0].lifeMax)
                    speedModifier = 1f - (float)Main.npc[ai0].life / Main.npc[ai0].lifeMax;
                speedModifier *= 12f;
                speedModifier += 3;

                if (Main.netMode != NetmodeID.MultiplayerClient)
                {
                    Projectile.NewProjectile(npc.Center, npc.rotation.ToRotationVector2() * speedModifier,
                        ModContent.ProjectileType<GunteraBullet>(), npc.damage / 4, 0f, Main.myPlayer, 
                        npc.Distance(Main.player[npc.target].Center) / speedModifier);
                }
            }
        }

        public override void OnHitByProjectile(Projectile projectile, int damage, float knockback, bool crit)
        {
            projectile.timeLeft = 0;
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
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;//new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;
            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(drawColor), npc.rotation, origin2, npc.scale,
                npc.spriteDirection > 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None, 0f);
            return false;
        }
    }
}