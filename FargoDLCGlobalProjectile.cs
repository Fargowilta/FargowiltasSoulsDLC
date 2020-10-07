using CalamityMod.Buffs.Pets;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod.Buffs.Healer;
using ThoriumMod.Buffs.Pet;
using ThoriumMod.Buffs.Summon;

namespace FargowiltasSoulsDLC
{
    class FargoDLCGlobalProjectile : GlobalProjectile
    {
        public override bool InstancePerEntity
        {
            get
            {
                return true;
            }
        }

        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public int ModProjID;

        public override void SetDefaults(Projectile projectile)
        {
            FargowiltasSoulsDLC.ModProjDict.TryGetValue(projectile.type, out ModProjID);
        }

        public override void AI(Projectile projectile)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
            {
                ThoriumPets(projectile);
            }

            if (FargowiltasSoulsDLC.Instance.CalamityLoaded)
            {
                CalamityPets(projectile);
            }

        }

        private void ThoriumPets(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            switch (ModProjID)
            {

                #region thorium pets

                case 2:
                    //KillPet(projectile, player, ModContent.BuffType<BioFeederBuff>(), modPlayer.MeteorEnchant, SoulConfig.Instance.thoriumToggles.BioFeederPet);
                    break;

                case 3:
                    KillPet(projectile, player, ModContent.BuffType<BlisterBuff>(), modPlayer.FleshEnchant, SoulConfig.Instance.thoriumToggles.BlisterPet);
                    break;

                case 4:
                    KillPet(projectile, player, ModContent.BuffType<WyvernPetBuff>(), modPlayer.DragonEnchant, SoulConfig.Instance.thoriumToggles.WyvernPet);
                    break;

                /*case 6:
                    KillPet(projectile, player, ModContent.BuffType<LockBoxBuff>(), modPlayer.MinerEnchant, SoulConfig.Instance.thoriumToggles.BoxPet);
                    break;*/

                case 9:
                    KillPet(projectile, player, ModContent.BuffType<LifeSpiritBuff>(), modPlayer.SacredEnchant, SoulConfig.Instance.thoriumToggles.SpiritPet);
                    break;

                case 11:
                    KillPet(projectile, player, ModContent.BuffType<SaplingBuff>(), modPlayer.LivingWoodEnchant, SoulConfig.Instance.thoriumToggles.SaplingMinion, true);
                    break;

                case 12:
                    KillPet(projectile, player, ModContent.BuffType<SnowyOwlBuff>(), modPlayer.CryoEnchant, SoulConfig.Instance.thoriumToggles.OwlPet);
                    break;

                case 13:
                    KillPet(projectile, player, ModContent.BuffType<JellyPet>(), modPlayer.DepthEnchant, SoulConfig.Instance.thoriumToggles.JellyfishPet);
                    break;

                /*case 17:
                    KillPet(projectile, player, ModContent.BuffType<ShineDust>(), modPlayer.PlatinumEnchant, SoulConfig.Instance.thoriumToggles.GlitterPet);
                    break;

                case 18:
                    KillPet(projectile, player, ModContent.BuffType<DrachmaBuff>(), modPlayer.GoldEnchant, SoulConfig.Instance.thoriumToggles.CoinPet);
                    break;*/

                    #endregion
            }
        }

        private void CalamityPets(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            switch (ModProjID)
            {
                case 101:
                    KillPet(projectile, player, ModContent.BuffType<Kendra>(), modPlayer.DaedalusEnchant, SoulConfig.Instance.calamityToggles.KendraPet);
                    break;


                case 103:
                    KillPet(projectile, player, ModContent.BuffType<ThirdSageBuff>(), modPlayer.DaedalusEnchant, SoulConfig.Instance.calamityToggles.ThirdSagePet);
                    break;

                case 104:
                    KillPet(projectile, player, ModContent.BuffType<BearBuff>(), modPlayer.DaedalusEnchant, SoulConfig.Instance.calamityToggles.BearPet);
                    break;

                case 105:
                    KillPet(projectile, player, ModContent.BuffType<BrimlingBuff>(), modPlayer.BrimflameEnchant, SoulConfig.Instance.calamityToggles.BrimlingPet);
                    break;

                case 106:
                    KillPet(projectile, player, ModContent.BuffType<DannyDevito>(), modPlayer.SulphurEnchant, SoulConfig.Instance.calamityToggles.DannyPet);
                    break;

                case 107:
                    KillPet(projectile, player, ModContent.BuffType<SirenLightPetBuff>(), modPlayer.FathomEnchant, SoulConfig.Instance.calamityToggles.SirenPet);
                    break;

                case 108:
                case 109:
                    KillPet(projectile, player, ModContent.BuffType<ChibiiBuff>(), modPlayer.GodSlayerEnchant, SoulConfig.Instance.calamityToggles.ChibiiPet);
                    break;

                case 110:
                    KillPet(projectile, player, ModContent.BuffType<AkatoYharonBuff>(), modPlayer.SilvaEnchant, SoulConfig.Instance.calamityToggles.AkatoPet);
                    break;

                case 111:
                    KillPet(projectile, player, ModContent.BuffType<Fox>(), modPlayer.SilvaEnchant, SoulConfig.Instance.calamityToggles.FoxPet);
                    break;

                case 112:
                    KillPet(projectile, player, ModContent.BuffType<LeviBuff>(), modPlayer.DemonShadeEnchant, SoulConfig.Instance.calamityToggles.LeviPet);
                    break;

                case 113:
                    KillPet(projectile, player, ModContent.BuffType<RotomBuff>(), modPlayer.AerospecEnchant, SoulConfig.Instance.calamityToggles.RotomPet);
                    break;

                case 114:
                    KillPet(projectile, player, ModContent.BuffType<AstrophageBuff>(), modPlayer.AstralEnchant, SoulConfig.Instance.calamityToggles.AstrophagePet);
                    break;

                case 115:
                    KillPet(projectile, player, ModContent.BuffType<SparksBuff>(), modPlayer.ReaverEnchant, SoulConfig.Instance.calamityToggles.SparksPet);
                    break;

                case 116:
                    KillPet(projectile, player, ModContent.BuffType<RadiatorBuff>(), modPlayer.SulphurEnchant, SoulConfig.Instance.calamityToggles.RadiatorPet);
                    break;

                case 117:
                    KillPet(projectile, player, ModContent.BuffType<BabyGhostBellBuff>(), modPlayer.MolluskEnchant, SoulConfig.Instance.calamityToggles.GhostBellPet);
                    break;

                case 118:
                    KillPet(projectile, player, ModContent.BuffType<FlakPetBuff>(), modPlayer.FathomEnchant, SoulConfig.Instance.calamityToggles.FlakPet);
                    break;

                case 119:
                    KillPet(projectile, player, ModContent.BuffType<SCalPetBuff>(), modPlayer.DemonShadeEnchant, SoulConfig.Instance.calamityToggles.ScalPet);
                    break;

            }
        }



        private void KillPet(Projectile projectile, Player player, int buff, bool enchant, bool toggle, bool minion = false)
        {
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            if (player.FindBuffIndex(buff) == -1)
            {
                if (player.dead || !enchant || !SoulConfig.Instance.GetValue(toggle) || (!modPlayer.PetsActive && !minion))
                    projectile.Kill();
            }
        }

        public override void OnHitNPC(Projectile projectile, NPC target, int damage, float knockback, bool crit)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded) ThoriumOnHit(projectile, crit);
        }

        private void ThoriumOnHit(Projectile projectile, bool crit)
        {
            Player player = Main.player[Main.myPlayer];
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.JesterBell))
            {
                //jester effect
                if (modPlayer.JesterEnchant && crit)
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        Projectile projectile2 = Main.projectile[m];
                        if (projectile2.active && projectile2.type == thorium.ProjectileType("JestersBell"))
                        {
                            return;
                        }
                    }
                    Main.PlaySound(SoundID.Item, (int)projectile.position.X, (int)projectile.position.Y, 35, 1f, 0f);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y - 50f, 0f, 0f, thorium.ProjectileType("JestersBell"), 0, 0f, projectile.owner, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("JestersBell2"), 0, 0f, projectile.owner, 0f, 0f);
                }
            }
        }

        public static Projectile[] XWay(int num, Vector2 pos, int type, float speed, int damage, float knockback)
        {
            Projectile[] projs = new Projectile[num];
            double spread = 2 * Math.PI / num;
            for (int i = 0; i < num; i++)
                projs[i] = NewProjectileDirectSafe(pos, new Vector2(speed, speed).RotatedBy(spread * i), type, damage, knockback, Main.myPlayer);
            return projs;
        }

        public static Projectile NewProjectileDirectSafe(Vector2 pos, Vector2 vel, int type, int damage, float knockback, int owner = 255, float ai0 = 0f, float ai1 = 0f)
        {
            int p = Projectile.NewProjectile(pos, vel, type, damage, knockback, owner, ai0, ai1);
            return (p < 1000) ? Main.projectile[p] : null;
        }
    }
}
