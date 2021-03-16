using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.DataStructures;
using Terraria.GameInput;
using Terraria.Graphics.Effects;
using Terraria.ID;
using Terraria.ModLoader;

using ThoriumMod;
using ThoriumMod.Projectiles;
using ThoriumMod.Buffs;


namespace FargowiltasSoulsDLC
{
    public partial class FargoDLCPlayer
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public bool FungusEnchant;
        public bool WarlockEnchant;
        public bool SacredEnchant;
        public bool LivingWoodEnchant;
        public bool DepthEnchant;
        public bool KnightEnchant;
        public bool IllumiteEnchant;
        public bool JesterEnchant;
        public bool MalignantEnchant;
        public bool WhiteDwarfEnchant;
        public bool YewEnchant;
        public bool CryoEnchant;
        public bool TideHunterEnchant;
        public bool BronzeEnchant;
        public bool TideTurnerEnchant;
        public bool AssassinEnchant;
        public bool PyroEnchant;
        public bool ThoriumEnchant;
        public bool SpiritTrapperEnchant;
        public bool LifeBloomEnchant;
        public bool LichEnchant;
        public bool DemonBloodEnchant;
        public bool BulbEnchant;
        public bool MixTape;
        public bool ConduitEnchant;
        public bool DragonEnchant;
        public bool FleshEnchant;

        public bool ThoriumSoul;

        public void ThoriumResetEffects()
        {
            FungusEnchant = false;
            WarlockEnchant = false;
            SacredEnchant = false;
            LivingWoodEnchant = false;
            DepthEnchant = false;
            KnightEnchant = false;
            IllumiteEnchant = false;
            JesterEnchant = false;
            MalignantEnchant = false;
            WhiteDwarfEnchant = false;
            YewEnchant = false;
            CryoEnchant = false;
            TideHunterEnchant = false;
            BronzeEnchant = false;
            TideTurnerEnchant = false;
            AssassinEnchant = false;
            PyroEnchant = false;
            ThoriumEnchant = false;
            SpiritTrapperEnchant = false;
            LifeBloomEnchant = false;
            LichEnchant = false;
            DemonBloodEnchant = false;
            BulbEnchant = false;
            MixTape = false;
            ConduitEnchant = false;
            DragonEnchant = false;
            FleshEnchant = false;

            ThoriumSoul = false;
        }

        private void ThoriumPostUpdate()
        {
            if (SpiritTrapperEnchant && player.ownedProjectileCounts[thorium.ProjectileType("SpiritTrapperSpirit")] >= 5)
            {
                player.statLife += 10;
                player.HealEffect(10, true);
                for (int num23 = 0; num23 < 5; num23++)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("SpiritTrapperVisual"), 0, 0f, player.whoAmI, (float)num23, 0f);
                }
                for (int num24 = 0; num24 < 1000; num24++)
                {
                    Projectile projectile3 = Main.projectile[num24];
                    if (projectile3.active && projectile3.type == thorium.ProjectileType("SpiritTrapperSpirit"))
                    {
                        projectile3.Kill();
                    }
                }
            }
        }

        private void ThoriumModifyProj(Projectile proj, NPC target, int damage, bool crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (FungusEnchant && !ThoriumSoul && Main.rand.Next(5) == 0)
                target.AddBuff(thorium.BuffType("Mycelium"), 120);

            if (proj.type == thorium.ProjectileType("MeteorPlasmaDamage") || proj.type == thorium.ProjectileType("PyroBurst") || proj.type == thorium.ProjectileType("LightStrike") || proj.type == thorium.ProjectileType("WhiteFlare") || proj.type == thorium.ProjectileType("CryoDamage") || proj.type == thorium.ProjectileType("MixtapeNote") || proj.type == thorium.ProjectileType("DragonPulse"))
            {
                return;
            }

            if (TideTurnerEnchant)
            {
                //tide turner daggers
                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TideDaggers) && player.ownedProjectileCounts[thorium.ProjectileType("TideDagger")] < 24 && proj.type != thorium.ProjectileType("ThrowingGuideFollowup") && proj.type != thorium.ProjectileType("TideDagger") && target.type != NPCID.TargetDummy && Main.rand.Next(5) == 0)
                {
                    FargoDLCGlobalProjectile.XWay(4, player.position, thorium.ProjectileType("TideDagger"), 3, (int)(proj.damage * 0.75), 3);
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 43, 1f, 0f);
                }
                //mini crits
                if (thoriumPlayer.tideOrb > 0 && !crit)
                {
                    float num = 30f;
                    int num2 = 0;
                    while ((float)num2 < num)
                    {
                        Vector2 vector = Vector2.UnitX * 0f;
                        vector += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num2 * (6.28318548f / num)), default(Vector2)) * new Vector2(12f, 12f);
                        vector = Utils.RotatedBy(vector, (double)Utils.ToRotation(target.velocity), default(Vector2));
                        int num3 = Dust.NewDust(target.Center, 0, 0, 176, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num3].scale = 1.5f;
                        Main.dust[num3].noGravity = true;
                        Main.dust[num3].position = target.Center + vector;
                        Main.dust[num3].velocity = target.velocity * 0f + Utils.SafeNormalize(vector, Vector2.UnitY) * 1f;
                        int num4 = num2;
                        num2 = num4 + 1;
                    }
                    crit = true;
                    damage = (int)((double)damage * 0.75);
                    thoriumPlayer.tideOrb--;
                }
            }

            if (AssassinEnchant)
            {
                //assassin duplicate damage
                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.AssassinDamage) && Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 92, 1f, 0f);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)((float)proj.damage * 1.15f), 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                //insta kill
                if (target.type != NPCID.TargetDummy && target.lifeMax < 100000 && Utils.NextFloat(Main.rand) < 0.05f)
                {
                    if ((target.boss || NPCID.Sets.BossHeadTextures[target.type] > -1) && target.life < target.lifeMax * 0.05)
                    {
                        CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, target.width, target.height), new Color(135, 255, 45), "ERADICATED", false, false);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)(target.lifeMax * 1.25f), 0f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                    else if (NPCID.Sets.BossHeadTextures[target.type] < 0)
                    {
                        CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, target.width, target.height), new Color(135, 255, 45), "ERADICATED", false, false);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)(target.lifeMax * 1.25f), 0f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if (PyroEnchant)
            {
                //pyro
                target.AddBuff(24, 300, true);
                target.AddBuff(thorium.BuffType("Singed"), 300, true);

                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.PyromancerBursts) && proj.type != thorium.ProjectileType("PyroBurst"))
                {
                    Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("PyroBurst"), 100, 1f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("PyroExplosion2"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
            }

            if (BronzeEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BronzeLightning) && Main.rand.Next(5) == 0 && proj.type != thorium.ProjectileType("LightStrike") && proj.type != thorium.ProjectileType("ThrowingGuideFollowup"))
            {
                target.immune[proj.owner] = 5;
                Projectile.NewProjectile(target.Center.X, target.Center.Y - 600f, 0f, 15f, thorium.ProjectileType("LightStrike"), (int)(proj.damage / 4), 1f, proj.owner, 0f, 0f);
            }

            //malignant
            if (MalignantEnchant && crit)
            {
                target.AddBuff(24, 900, true);
                target.AddBuff(thorium.BuffType("lightCurse"), 900, true);
                for (int i = 0; i < 8; i++)
                {
                    int num5 = Dust.NewDust(target.position, target.width, target.height, 127, (float)Main.rand.Next(-6, 6), (float)Main.rand.Next(-10, 10), 0, default(Color), 1.2f);
                    Main.dust[num5].noGravity = true;
                }
                for (int j = 0; j < 8; j++)
                {
                    int num6 = Dust.NewDust(target.position, target.width, target.height, 65, (float)Main.rand.Next(-6, 6), (float)Main.rand.Next(-10, 10), 0, default(Color), 1.2f);
                    Main.dust[num6].noGravity = true;
                }
            }

            //white dwarf
            if (WhiteDwarfEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WhiteDwarf) && crit)
            {
                Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 92, 1f, 0f);
                Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("WhiteFlare"), (int)((float)target.lifeMax * 0.001f), 0f, Main.myPlayer, 0f, 0f);
            }

            //yew wood
            if (YewEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.YewCrits) && !crit)
            {
                thoriumPlayer.yewChargeTimer = 120;
                if (player.ownedProjectileCounts[thorium.ProjectileType("YewVisual")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("YewVisual"), 0, 0f, player.whoAmI, 0f, 0f);
                }
                if (thoriumPlayer.yewCharge < 4)
                {
                    thoriumPlayer.yewCharge++;
                }
                else
                {
                    crit = true;
                    damage = (int)((double)damage * 0.75);
                    thoriumPlayer.yewCharge = 0;
                }
            }

            //cryo
            if (CryoEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.CryoDamage))
            {
                target.AddBuff(ModContent.BuffType<EnemyFrozen>(), 120, false);
                Projectile.NewProjectile(target.Center, Vector2.Zero, ModContent.ProjectileType<ReactionNitrogen>(), 0, 0f, Main.myPlayer, 0f, 0f);
            }

            if (WarlockEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WarlockWisps) && !(proj.modProjectile is ThoriumProjectile && ((ThoriumProjectile)proj.modProjectile).radiant))
            {
                //warlock
                if (crit && player.ownedProjectileCounts[thorium.ProjectileType("ShadowWisp")] < 15)
                {
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, -2f, thorium.ProjectileType("ShadowWisp"), (int)((float)proj.damage * 0.75f), 0f, Main.myPlayer, 0f, 0f);
                }
            }
        }

        private void ThoriumModifyNPC(NPC target, Item item, int damage, bool crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (FungusEnchant && !ThoriumSoul && Main.rand.Next(5) == 0)
                target.AddBuff(thorium.BuffType("Mycelium"), 120);

            if (TideTurnerEnchant)
            {
                //tide turner daggers
                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TideDaggers) && player.ownedProjectileCounts[thorium.ProjectileType("TideDagger")] < 24 && target.type != NPCID.TargetDummy && Main.rand.Next(5) == 0)
                {
                    FargoDLCGlobalProjectile.XWay(4, player.position, thorium.ProjectileType("TideDagger"), 3, (int)(item.damage * 0.75), 3);
                    Main.PlaySound(SoundID.Item, (int)player.position.X, (int)player.position.Y, 43, 1f, 0f);
                }
                //mini crits
                if (thoriumPlayer.tideOrb > 0 && !crit)
                {
                    float num = 30f;
                    int num2 = 0;
                    while ((float)num2 < num)
                    {
                        Vector2 vector = Vector2.UnitX * 0f;
                        vector += -Utils.RotatedBy(Vector2.UnitY, (double)((float)num2 * (6.28318548f / num)), default(Vector2)) * new Vector2(12f, 12f);
                        vector = Utils.RotatedBy(vector, (double)Utils.ToRotation(target.velocity), default(Vector2));
                        int num3 = Dust.NewDust(target.Center, 0, 0, 176, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num3].scale = 1.5f;
                        Main.dust[num3].noGravity = true;
                        Main.dust[num3].position = target.Center + vector;
                        Main.dust[num3].velocity = target.velocity * 0f + Utils.SafeNormalize(vector, Vector2.UnitY) * 1f;
                        int num4 = num2;
                        num2 = num4 + 1;
                    }
                    crit = true;
                    damage = (int)((double)damage * 0.75);
                    thoriumPlayer.tideOrb--;
                }
            }

            if (AssassinEnchant)
            {
                //assassin duplicate damage
                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.AssassinDamage) && Utils.NextFloat(Main.rand) < 0.1f)
                {
                    Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 92, 1f, 0f);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)((float)item.damage * 1.15f), 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                //insta kill
                if (target.type != NPCID.TargetDummy && target.lifeMax < 100000 && Utils.NextFloat(Main.rand) < 0.05f)
                {
                    if ((target.boss || NPCID.Sets.BossHeadTextures[target.type] > -1) && target.life < target.lifeMax * 0.05)
                    {
                        CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, target.width, target.height), new Color(135, 255, 45), "ERADICATED", false, false);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)(target.lifeMax * 1.25f), 0f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                    else if (NPCID.Sets.BossHeadTextures[target.type] < 0)
                    {
                        CombatText.NewText(new Rectangle((int)target.position.X, (int)target.position.Y, target.width, target.height), new Color(135, 255, 45), "ERADICATED", false, false);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasmaDamage"), (int)(target.lifeMax * 1.25f), 0f, Main.myPlayer, 0f, 0f);
                        Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("MeteorPlasma"), 0, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if (PyroEnchant)
            {
                //pyro
                target.AddBuff(24, 300, true);
                target.AddBuff(thorium.BuffType("Singed"), 300, true);

                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.PyromancerBursts))
                {
                    Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("PyroBurst"), 100, 1f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(((int)target.Center.X), ((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("PyroExplosion2"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
            }

            if (BronzeEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BronzeLightning) && Main.rand.Next(5) == 0)
            {
                target.immune[player.whoAmI] = 5;
                Projectile.NewProjectile(target.Center.X, target.Center.Y - 600f, 0f, 15f, thorium.ProjectileType("LightStrike"), (int)(item.damage / 4), 1f, player.whoAmI, 0f, 0f);
            }

            //malignant
            if (MalignantEnchant && crit)
            {
                target.AddBuff(24, 900, true);
                target.AddBuff(thorium.BuffType("lightCurse"), 900, true);
                for (int i = 0; i < 8; i++)
                {
                    int num5 = Dust.NewDust(target.position, target.width, target.height, 127, (float)Main.rand.Next(-6, 6), (float)Main.rand.Next(-10, 10), 0, default(Color), 1.2f);
                    Main.dust[num5].noGravity = true;
                }
                for (int j = 0; j < 8; j++)
                {
                    int num6 = Dust.NewDust(target.position, target.width, target.height, 65, (float)Main.rand.Next(-6, 6), (float)Main.rand.Next(-10, 10), 0, default(Color), 1.2f);
                    Main.dust[num6].noGravity = true;
                }
            }

            //white dwarf
            if (WhiteDwarfEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WhiteDwarf) && crit)
            {
                Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 92, 1f, 0f);
                Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("WhiteFlare"), (int)((float)target.lifeMax * 0.001f), 0f, Main.myPlayer, 0f, 0f);
            }

            //yew wood
            if (YewEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.YewCrits) && !crit)
            {
                thoriumPlayer.yewChargeTimer = 120;
                if (player.ownedProjectileCounts[thorium.ProjectileType("YewVisual")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("YewVisual"), 0, 0f, player.whoAmI, 0f, 0f);
                }
                if (thoriumPlayer.yewCharge < 4)
                {
                    thoriumPlayer.yewCharge++;
                }
                else
                {
                    crit = true;
                    damage = (int)((double)damage * 0.75);
                    thoriumPlayer.yewCharge = 0;
                }
            }

            if (CryoEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.CryoDamage))
            {
                target.AddBuff(ModContent.BuffType<EnemyFrozen>(), 120, false);
                Projectile.NewProjectile(target.Center, Vector2.Zero, ModContent.ProjectileType<ReactionNitrogen>(), 0, 0f, Main.myPlayer, 0f, 0f);
            }

            if (WarlockEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WarlockWisps))
            {
                //warlock
                if (crit && player.ownedProjectileCounts[thorium.ProjectileType("ShadowWisp")] < 15)
                {
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, -2f, thorium.ProjectileType("ShadowWisp"), (int)((float)item.damage * 0.75f), 0f, Main.myPlayer, 0f, 0f);
                }
            }
        }

        private void ThoriumHitProj(Projectile proj, NPC target, int damage, bool crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (BulbEnchant && !ThoriumSoul && Main.rand.Next(4) == 0)
            {
                Main.PlaySound(SoundID.Item, (int)proj.position.X, (int)proj.position.Y, 34, 1f, 0f);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("BloomCloud"), 0, 0f, proj.owner, 0f, 0f);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("BloomCloudDamage"), (int)(10f * player.magicDamage), 0f, proj.owner, 0f, 0f);
            }

            if (SpiritTrapperEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SpiritTrapperWisps) && !proj.minion)
            {
                if (target.life < 0 && target.value > 0f)
                {
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, -2f, thorium.ProjectileType("SpiritTrapperSpirit"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                if (target.boss || NPCID.Sets.BossHeadTextures[target.type] > -1)
                {
                    thoriumPlayer.setSpiritTrapperHit++;
                }
            }

            //tide hunter
            if (TideHunterEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TideFoam) && crit)
            {
                for (int n = 0; n < 10; n++)
                {
                    int num10 = Dust.NewDust(target.position, target.width, target.height, 217, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 100, default(Color), 1f);
                    Main.dust[num10].noGravity = true;
                    Main.dust[num10].noLight = true;
                }
                for (int num11 = 0; num11 < 200; num11++)
                {
                    NPC npc = Main.npc[num11];
                    if (npc.active && npc.FindBuffIndex(thorium.BuffType("Oozed")) < 0 && !npc.friendly && Vector2.Distance(npc.Center, target.Center) < 80f)
                    {
                        npc.AddBuff(thorium.BuffType("Oozed"), 90, false);
                    }
                }
            }

            if (LichEnchant && target.life <= 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("SoulFragment"), 0, 0f, proj.owner, 0f, 0f);
                for (int num26 = 0; num26 < 5; num26++)
                {
                    int num27 = Dust.NewDust(proj.position, proj.width, proj.height, 55, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 150, default(Color), 0.75f);
                    Main.dust[num27].noGravity = true;
                }
                for (int num28 = 0; num28 < 5; num28++)
                {
                    int num29 = Dust.NewDust(proj.position, proj.width, proj.height, thorium.DustType("HarbingerDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 100, default(Color), 1f);
                    Main.dust[num29].noGravity = true;
                }
            }

            //life bloom
            if (LifeBloomEnchant && target.type != NPCID.TargetDummy && Main.rand.Next(4) == 0 && thoriumPlayer.setLifeBloomMax < 50)
            {
                for (int l = 0; l < 10; l++)
                {
                    int num7 = Dust.NewDust(target.position, target.width, target.height, 44, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0, default(Color), 1f);
                    Main.dust[num7].noGravity = true;
                }
                int num8 = Main.rand.Next(1, 4);
                player.statLife += num8;
                player.HealEffect(num8, true);
                thoriumPlayer.setLifeBloomMax += num8;
            }

            //demon blood
            if (DemonBloodEnchant && target.type != NPCID.TargetDummy && !thoriumPlayer.bloodChargeExhaust)
            {
                thoriumPlayer.bloodCharge++;
                thoriumPlayer.bloodChargeTimer = 120;
                if (player.ownedProjectileCounts[thorium.ProjectileType("DemonBloodVisual")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("DemonBloodVisual"), 0, 0f, player.whoAmI, 0f, 0f);
                }
                if (thoriumPlayer.bloodCharge >= 5)
                {
                    player.statLife += damage / 5;
                    player.HealEffect(damage / 5, true);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("BloodBoom"), 0, 0f, Main.myPlayer, 0f, 0f);
                    damage = (int)((float)damage * 2f);
                    player.AddBuff(thorium.BuffType("DemonBloodExhaust"), 600, true);
                    thoriumPlayer.bloodCharge = 0;
                }
            }

            if (proj.type == thorium.ProjectileType("MeteorPlasmaDamage") || proj.type == thorium.ProjectileType("PyroBurst") || proj.type == thorium.ProjectileType("LightStrike") || proj.type == thorium.ProjectileType("WhiteFlare") || proj.type == thorium.ProjectileType("CryoDamage") || proj.type == thorium.ProjectileType("MixtapeNote") || proj.type == thorium.ProjectileType("DragonPulse"))
            {
                return;
            }

            //mixtape
            if (MixTape && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.MixTape) && crit && proj.type != thorium.ProjectileType("MixtapeNote"))
            {
                int num23 = Main.rand.Next(3);
                Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 73, 1f, 0f);
                for (int n = 0; n < 5; n++)
                {
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, Utils.NextFloat(Main.rand, -5f, 5f), Utils.NextFloat(Main.rand, -5f, 5f), thorium.ProjectileType("MixtapeNote"), (int)((float)proj.damage * 0.25f), 2f, proj.owner, (float)num23, 0f);
                }
            }

            if (ThoriumEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.ThoriumDivers) && NPC.CountNPCS(thorium.NPCType("Diverman")) < 5 && Main.rand.Next(20) == 0)
            {
                int diver = NPC.NewNPC((int)target.Center.X, (int)target.Center.Y, thorium.NPCType("Diverman"));
                Main.npc[diver].AddBuff(BuffID.ShadowFlame, 9999999);
                Main.npc[diver].AddBuff(BuffID.CursedInferno, 9999999);
            }
        }

        private void ThoriumHitNPC(NPC target, Item item, bool crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (BulbEnchant && !ThoriumSoul && Main.rand.Next(4) == 0)
            {
                Main.PlaySound(SoundID.Item, (int)player.Center.X, (int)player.Center.Y, 34, 1f, 0f);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("BloomCloud"), 0, 0f, player.whoAmI, 0f, 0f);
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("BloomCloudDamage"), (int)(10f * player.magicDamage), 0f, player.whoAmI, 0f, 0f);
            }

            if (SpiritTrapperEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SpiritTrapperWisps) && !item.summon)
            {
                if (target.life < 0 && target.value > 0f)
                {
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, -2f, thorium.ProjectileType("SpiritTrapperSpirit"), 0, 0f, Main.myPlayer, 0f, 0f);
                }
                if (target.boss || NPCID.Sets.BossHeadTextures[target.type] > -1)
                {
                    thoriumPlayer.setSpiritTrapperHit++;
                }
            }

            //tide hunter
            if (TideHunterEnchant && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TideFoam) && crit)
            {
                for (int n = 0; n < 10; n++)
                {
                    int num10 = Dust.NewDust(target.position, target.width, target.height, 217, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 100, default(Color), 1f);
                    Main.dust[num10].noGravity = true;
                    Main.dust[num10].noLight = true;
                }
                for (int num11 = 0; num11 < 200; num11++)
                {
                    NPC npc = Main.npc[num11];
                    if (npc.active && npc.FindBuffIndex(thorium.BuffType("Oozed")) < 0 && !npc.friendly && Vector2.Distance(npc.Center, target.Center) < 80f)
                    {
                        npc.AddBuff(thorium.BuffType("Oozed"), 90, false);
                    }
                }
            }

            if (LichEnchant && target.life <= 0)
            {
                Projectile.NewProjectile(target.Center.X, target.Center.Y, 0f, 0f, thorium.ProjectileType("SoulFragment"), 0, 0f, player.whoAmI, 0f, 0f);
                for (int num26 = 0; num26 < 5; num26++)
                {
                    int num27 = Dust.NewDust(target.position, target.width, target.height, 55, (float)Main.rand.Next(-4, 4), (float)Main.rand.Next(-4, 4), 150, default(Color), 0.75f);
                    Main.dust[num27].noGravity = true;
                }
                for (int num28 = 0; num28 < 5; num28++)
                {
                    int num29 = Dust.NewDust(target.position, target.width, target.height, thorium.DustType("HarbingerDust"), (float)Main.rand.Next(-3, 3), (float)Main.rand.Next(-3, 3), 100, default(Color), 1f);
                    Main.dust[num29].noGravity = true;
                }
            }

            //life bloom
            if (LifeBloomEnchant && target.type != NPCID.TargetDummy && Main.rand.Next(4) == 0 && thoriumPlayer.setLifeBloomMax < 50)
            {
                for (int l = 0; l < 10; l++)
                {
                    int num7 = Dust.NewDust(target.position, target.width, target.height, 44, (float)Main.rand.Next(-5, 5), (float)Main.rand.Next(-5, 5), 0, default(Color), 1f);
                    Main.dust[num7].noGravity = true;
                }
                int num8 = Main.rand.Next(1, 4);
                player.statLife += num8;
                player.HealEffect(num8, true);
                thoriumPlayer.setLifeBloomMax += num8;
            }

            //demon blood
            if (DemonBloodEnchant && target.type != NPCID.TargetDummy && !thoriumPlayer.bloodChargeExhaust)
            {
                thoriumPlayer.bloodCharge++;
                thoriumPlayer.bloodChargeTimer = 120;
                if (player.ownedProjectileCounts[thorium.ProjectileType("DemonBloodVisual")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("DemonBloodVisual"), 0, 0f, player.whoAmI, 0f, 0f);
                }
                if (thoriumPlayer.bloodCharge >= 5)
                {
                    player.statLife += item.damage / 5;
                    player.HealEffect(item.damage / 5, true);
                    Projectile.NewProjectile((float)((int)target.Center.X), (float)((int)target.Center.Y), 0f, 0f, thorium.ProjectileType("BloodBoom"), 0, 0f, Main.myPlayer, 0f, 0f);
                    item.damage = (int)((float)item.damage * 2f);
                    player.AddBuff(thorium.BuffType("DemonBloodExhaust"), 600, true);
                    thoriumPlayer.bloodCharge = 0;
                }
            }

            //mixtape
            if (MixTape && SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.MixTape) && crit)
            {
                int num23 = Main.rand.Next(3);
                Main.PlaySound(SoundID.Item, (int)target.position.X, (int)target.position.Y, 73, 1f, 0f);
                for (int n = 0; n < 5; n++)
                {
                    Projectile.NewProjectile(target.Center.X, target.Center.Y, Utils.NextFloat(Main.rand, -5f, 5f), Utils.NextFloat(Main.rand, -5f, 5f), thorium.ProjectileType("MixtapeNote"), (int)((float)item.damage * 0.25f), 2f, player.whoAmI, (float)num23, 0f);
                }
            }
        }

        private void ThoriumDamage(float dmg)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.radiantBoost += dmg;
            thoriumPlayer.symphonicDamage += dmg;
        }

        private void ThoriumCrit(int crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.radiantCrit += crit;
            thoriumPlayer.symphonicCrit += crit;
        }

        private void ThoriumCritEquals(int crit)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.radiantCrit = crit;
            thoriumPlayer.symphonicCrit = crit;
        }
    }
}
