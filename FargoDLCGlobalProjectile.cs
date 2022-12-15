using FargowiltasSouls.Toggler;
using FargowiltasSouls;
using Microsoft.Xna.Framework;
using System;
using System.Diagnostics.Metrics;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
//using ThoriumMod.Buffs.Summon;
//using ThoriumMod.Projectiles.Minions;

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

        private void KillPet(Projectile projectile, Player player, int buff, bool toggle)
        {
            FargoSoulsPlayer modPlayer = player.GetModPlayer<FargoSoulsPlayer>();

            if (player.FindBuffIndex(buff) == -1)
            {
                if (player.dead || !toggle || !modPlayer.VoidSoul || !modPlayer.PetsActive)
                {
                    projectile.Kill();
                }
            }
        }

        public override void AI(Projectile projectile)
        {
            Player player = Main.player[projectile.owner];
            FargoSoulsPlayer modPlayer = player.GetModPlayer<FargoSoulsPlayer>();

            switch (projectile.type)
            {
                #region pets

                case ProjectileID.BabyHornet:
                    KillPet(projectile, player, BuffID.BabyHornet, player.GetToggleValue("PetHornet"));
                    break;

                case ProjectileID.Sapling:
                    KillPet(projectile, player, BuffID.PetSapling, player.GetToggleValue("PetSeed"));
                    break;

                case ProjectileID.BabyFaceMonster:
                    KillPet(projectile, player, BuffID.BabyFaceMonster, player.GetToggleValue("PetFaceMonster"));
                    break;

                case ProjectileID.CrimsonHeart:
                    KillPet(projectile, player, BuffID.CrimsonHeart, player.GetToggleValue("PetHeart"));
                    break;

                case ProjectileID.MagicLantern:
                    KillPet(projectile, player, BuffID.MagicLantern, player.GetToggleValue("PetLantern"));
                    break;

                case ProjectileID.MiniMinotaur:
                    KillPet(projectile, player, BuffID.MiniMinotaur, player.GetToggleValue("PetMinitaur"));
                    break;

                case ProjectileID.BlackCat:
                    KillPet(projectile, player, BuffID.BlackCat, player.GetToggleValue("PetBlackCat"));
                    break;

                case ProjectileID.Wisp:
                    KillPet(projectile, player, BuffID.Wisp, player.GetToggleValue("PetWisp"));
                    break;

                case ProjectileID.CursedSapling:
                    KillPet(projectile, player, BuffID.CursedSapling, player.GetToggleValue("PetCursedSapling"));
                    break;

                case ProjectileID.EyeSpring:
                    KillPet(projectile, player, BuffID.EyeballSpring, player.GetToggleValue("PetEyeSpring"));
                    break;

                case ProjectileID.Turtle:
                    KillPet(projectile, player, BuffID.PetTurtle, player.GetToggleValue("PetTurtle"));
                    break;

                case ProjectileID.PetLizard:
                    KillPet(projectile, player, BuffID.PetLizard, player.GetToggleValue("PetLizard"));
                    break;

                case ProjectileID.Truffle:
                    KillPet(projectile, player, BuffID.BabyTruffle, player.GetToggleValue("PetShroom"));
                    break;

                case ProjectileID.Spider:
                    KillPet(projectile, player, BuffID.PetSpider, player.GetToggleValue("PetSpider"));
                    break;

                case ProjectileID.Squashling:
                    KillPet(projectile, player, BuffID.Squashling, player.GetToggleValue("PetSquash"));
                    break;

                case ProjectileID.BlueFairy:
                    KillPet(projectile, player, BuffID.FairyBlue, player.GetToggleValue("PetNavi"));
                    break;

                case ProjectileID.TikiSpirit:
                    KillPet(projectile, player, BuffID.TikiSpirit, player.GetToggleValue("PetTiki"));
                    break;

                case ProjectileID.Penguin:
                    KillPet(projectile, player, BuffID.BabyPenguin, player.GetToggleValue("PetPenguin"));
                    break;

                case ProjectileID.BabySnowman:
                    KillPet(projectile, player, BuffID.BabySnowman, player.GetToggleValue("PetSnowman"));
                    break;

                case ProjectileID.BabyGrinch:
                    KillPet(projectile, player, BuffID.BabyGrinch, player.GetToggleValue("PetGrinch"));
                    break;

                case ProjectileID.DD2PetGato:
                    KillPet(projectile, player, BuffID.PetDD2Gato, player.GetToggleValue("PetGato"));
                    break;

                case ProjectileID.Parrot:
                    KillPet(projectile, player, BuffID.PetParrot, player.GetToggleValue("PetParrot"));
                    break;

                case ProjectileID.Puppy:
                    KillPet(projectile, player, BuffID.Puppy, player.GetToggleValue("PetPup"));
                    break;

                case ProjectileID.CompanionCube:
                    KillPet(projectile, player, BuffID.CompanionCube, player.GetToggleValue("PetCompanionCube"));
                    break;

                case ProjectileID.DD2PetDragon:
                    KillPet(projectile, player, BuffID.PetDD2Dragon, player.GetToggleValue("PetDragon"));
                    break;

                case ProjectileID.BabySkeletronHead:
                    KillPet(projectile, player, BuffID.BabySkeletronHead, player.GetToggleValue("PetDG"));
                    break;

                case ProjectileID.BabyDino:
                    KillPet(projectile, player, BuffID.BabyDinosaur, player.GetToggleValue("PetDino"));
                    break;

                case ProjectileID.BabyEater:
                    KillPet(projectile, player, BuffID.BabyEater, player.GetToggleValue("PetEater"));
                    break;

                case ProjectileID.ShadowOrb:
                    KillPet(projectile, player, BuffID.ShadowOrb, player.GetToggleValue("PetOrb"));
                    break;

                case ProjectileID.SuspiciousTentacle:
                    KillPet(projectile, player, BuffID.SuspiciousTentacle, player.GetToggleValue("PetSuspEye"));
                    break;

                case ProjectileID.DD2PetGhost:
                    KillPet(projectile, player, BuffID.PetDD2Ghost, player.GetToggleValue("PetFlicker"));
                    break;

                case ProjectileID.ZephyrFish:
                    KillPet(projectile, player, BuffID.ZephyrFish, player.GetToggleValue("PetZephyr"));
                    break;

                case ProjectileID.SharkPup:
                    KillPet(projectile, player, BuffID.SharkPup, player.GetToggleValue("PetShark"));
                    break;

                case ProjectileID.DukeFishronPet:
                    KillPet(projectile, player, BuffID.DukeFishronPet, player.GetToggleValue("PetDuke"));
                    break;

                case ProjectileID.ChesterPet:
                    KillPet(projectile, player, BuffID.ChesterPet, player.GetToggleValue("PetChester"));
                    break;

                case ProjectileID.GolemPet:
                    KillPet(projectile, player, BuffID.GolemPet, player.GetToggleValue("PetGolem"));
                    break;

                case ProjectileID.LunaticCultistPet:
                    KillPet(projectile, player, BuffID.LunaticCultistPet, player.GetToggleValue("PetLC"));
                    break;

                case ProjectileID.DD2BetsyPet:
                    KillPet(projectile, player, BuffID.DD2BetsyPet, player.GetToggleValue("PetBetsy"));
                    break;

                case ProjectileID.DestroyerPet:
                    KillPet(projectile, player, BuffID.DestroyerPet, player.GetToggleValue("PetDestroyer"));
                    break;

                case ProjectileID.QueenBeePet:
                    KillPet(projectile, player, BuffID.QueenBeePet, player.GetToggleValue("PetQB"));
                    break;

                case ProjectileID.TwinsPet:
                    KillPet(projectile, player, BuffID.TwinsPet, player.GetToggleValue("PetTwins"));
                    break;

                case ProjectileID.PumpkingPet:
                    KillPet(projectile, player, BuffID.PumpkingPet, player.GetToggleValue("PetPumpking"));
                    break;

                case ProjectileID.FairyQueenPet:
                    KillPet(projectile, player, BuffID.FairyQueenPet, player.GetToggleValue("PetEoL"));
                    break;

                case ProjectileID.MoonLordPet:
                    KillPet(projectile, player, BuffID.MoonLordPet, player.GetToggleValue("PetML"));
                    break;

                case ProjectileID.SkeletronPet:
                    KillPet(projectile, player, BuffID.SkeletronPet, player.GetToggleValue("PetSkele"));
                    break;

                case ProjectileID.SkeletronPrimePet:
                    KillPet(projectile, player, BuffID.SkeletronPrimePet, player.GetToggleValue("PetSkelePrime"));
                    break;

                case ProjectileID.EyeOfCthulhuPet:
                    KillPet(projectile, player, BuffID.EyeOfCthulhuPet, player.GetToggleValue("PetEoC"));
                    break;

                case ProjectileID.EaterOfWorldsPet:
                    KillPet(projectile, player, BuffID.EaterOfWorldsPet, player.GetToggleValue("PetEoW"));
                    break;

                case ProjectileID.LilHarpy:
                    KillPet(projectile, player, BuffID.LilHarpy, player.GetToggleValue("PetHarpy"));
                    break;

                case ProjectileID.MartianPet:
                    KillPet(projectile, player, BuffID.MartianPet, player.GetToggleValue("PetMartian"));
                    break;

                case ProjectileID.DeerclopsPet:
                    KillPet(projectile, player, BuffID.DeerclopsPet, player.GetToggleValue("PetDeer"));
                    break;

                case ProjectileID.PlanteraPet:
                    KillPet(projectile, player, BuffID.PlanteraPet, player.GetToggleValue("PetPlantera"));
                    break;

                case ProjectileID.EverscreamPet:
                    KillPet(projectile, player, BuffID.EverscreamPet, player.GetToggleValue("PetEverscream"));
                    break;

                case ProjectileID.DD2OgrePet:
                    KillPet(projectile, player, BuffID.DD2OgrePet, player.GetToggleValue("PetOgre"));
                    break;

                case ProjectileID.GlitteryButterfly:
                    KillPet(projectile, player, BuffID.GlitteryButterfly, player.GetToggleValue("PetButterfly"));
                    break;

                case ProjectileID.QueenSlimePet:
                    KillPet(projectile, player, BuffID.QueenSlimePet, player.GetToggleValue("PetQS"));
                    break;

                case ProjectileID.IceQueenPet:
                    KillPet(projectile, player, BuffID.IceQueenPet, player.GetToggleValue("PetIceQueen"));
                    break;

                case ProjectileID.BrainOfCthulhuPet:
                    KillPet(projectile, player, BuffID.BrainOfCthulhuPet, player.GetToggleValue("PetBoC"));
                    break;

                case ProjectileID.SugarGlider:
                    KillPet(projectile, player, BuffID.SugarGlider, player.GetToggleValue("PetGlider"));
                    break;

                case ProjectileID.KingSlimePet:
                    KillPet(projectile, player, BuffID.KingSlimePet, player.GetToggleValue("PetKS"));
                    break;

                case ProjectileID.Plantero:
                    KillPet(projectile, player, BuffID.Plantero, player.GetToggleValue("PetPlantero"));
                    break;

                case ProjectileID.ShadowMimic:
                    KillPet(projectile, player, BuffID.ShadowMimic, player.GetToggleValue("PetMimic"));
                    break;

                case ProjectileID.VoltBunny:
                    KillPet(projectile, player, BuffID.VoltBunny, player.GetToggleValue("PetVolt"));
                    break;

                case ProjectileID.BabyRedPanda:
                    KillPet(projectile, player, BuffID.BabyRedPanda, player.GetToggleValue("PetPanda"));
                    break;

                case ProjectileID.FennecFox:
                    KillPet(projectile, player, BuffID.FennecFox, player.GetToggleValue("PetFox"));
                    break;

                case ProjectileID.DynamiteKitten:
                    KillPet(projectile, player, BuffID.DynamiteKitten, player.GetToggleValue("PetKitten"));
                    break;

                case ProjectileID.PigPet:
                    KillPet(projectile, player, BuffID.PigPet, player.GetToggleValue("PetPigman"));
                    break;

                case ProjectileID.BabyImp:
                    KillPet(projectile, player, BuffID.BabyImp, player.GetToggleValue("PetImp"));
                    break;

                case ProjectileID.BabyWerewolf:
                    KillPet(projectile, player, BuffID.BabyWerewolf, player.GetToggleValue("PetWerewolf"));
                    break;

                case ProjectileID.GlommerPet:
                    KillPet(projectile, player, BuffID.GlommerPet, player.GetToggleValue("PetGlommer"));
                    break;

                case ProjectileID.UpbeatStar:
                    KillPet(projectile, player, BuffID.UpbeatStar, player.GetToggleValue("PetEstee"));
                    break;

                #endregion

                default:
                    break;
            }

           
        }
    }
}
