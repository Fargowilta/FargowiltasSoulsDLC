using FargowiltasSouls.Items.Accessories.Souls;
using FargowiltasSouls;
using Terraria;
using Terraria.ID;
using FargowiltasSouls.Toggler;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items
{
    public class VoidSoul : BaseSoul
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Soul of the Void");

            string tooltip =
@"Summons SOMETHING";
            Tooltip.SetDefault(tooltip);
        }

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            FargoSoulsPlayer modPlayer = player.GetModPlayer<FargoSoulsPlayer>();
            modPlayer.VoidSoul = true;

            modPlayer.AddPet(player.GetToggleValue("PetDino"), hideVisual, BuffID.BabyDinosaur, ProjectileID.BabyDino);
            modPlayer.AddPet(player.GetToggleValue("PetEater"), hideVisual, BuffID.BabyEater, ProjectileID.BabyEater);
            modPlayer.AddPet(player.GetToggleValue("PetFaceMonster"), hideVisual, BuffID.BabyFaceMonster, ProjectileID.BabyFaceMonster);
            modPlayer.AddPet(player.GetToggleValue("PetGrinch"), hideVisual, BuffID.BabyGrinch, ProjectileID.BabyGrinch);
            modPlayer.AddPet(player.GetToggleValue("PetHornet"), hideVisual, BuffID.BabyHornet, ProjectileID.BabyHornet);
            modPlayer.AddPet(player.GetToggleValue("PetImp"), hideVisual, BuffID.BabyImp, ProjectileID.BabyImp);
            modPlayer.AddPet(player.GetToggleValue("PetPenguin"), hideVisual, BuffID.BabyPenguin, ProjectileID.Penguin);
            modPlayer.AddPet(player.GetToggleValue("PetPanda"), hideVisual, BuffID.BabyRedPanda, ProjectileID.BabyRedPanda);
            modPlayer.AddPet(player.GetToggleValue("PetDG"), hideVisual, BuffID.BabySkeletronHead, ProjectileID.BabySkeletronHead);
            modPlayer.AddPet(player.GetToggleValue("PetSnowman"), hideVisual, BuffID.BabySnowman, ProjectileID.BabySnowman);
            modPlayer.AddPet(player.GetToggleValue("PetShroom"), hideVisual, BuffID.BabyTruffle, ProjectileID.Truffle);
            modPlayer.AddPet(player.GetToggleValue("PetWerewolf"), hideVisual, BuffID.BabyWerewolf, ProjectileID.BabyWerewolf);
            modPlayer.AddPet(player.GetToggleValue("PetBernie"), hideVisual, BuffID.BerniePet, ProjectileID.BerniePet);
            modPlayer.AddPet(player.GetToggleValue("PetBlackCat"), hideVisual, BuffID.BlackCat, ProjectileID.BlackCat);
            //blue chicken
            //caveling
            modPlayer.AddPet(player.GetToggleValue("PetChester"), hideVisual, BuffID.ChesterPet, ProjectileID.ChesterPet);
            modPlayer.AddPet(player.GetToggleValue("PetCompanionCube"), hideVisual, BuffID.CompanionCube, ProjectileID.CompanionCube);
            modPlayer.AddPet(player.GetToggleValue("PetCursedSapling"), hideVisual, BuffID.CursedSapling, ProjectileID.CursedSapling);
            //dirt
            modPlayer.AddPet(player.GetToggleValue("PetKitten"), hideVisual, BuffID.DynamiteKitten, ProjectileID.DynamiteKitten);
            modPlayer.AddPet(player.GetToggleValue("PetEstee"), hideVisual, BuffID.UpbeatStar, ProjectileID.UpbeatStar);
            modPlayer.AddPet(player.GetToggleValue("PetEyeSpring"), hideVisual, BuffID.EyeballSpring, ProjectileID.EyeSpring);
            modPlayer.AddPet(player.GetToggleValue("PetFox"), hideVisual, BuffID.FennecFox, ProjectileID.FennecFox);
            modPlayer.AddPet(player.GetToggleValue("PetButterfly"), hideVisual, BuffID.GlitteryButterfly, ProjectileID.GlitteryButterfly);
            modPlayer.AddPet(player.GetToggleValue("PetGlommer"), hideVisual, BuffID.GlommerPet, ProjectileID.GlommerPet);
            modPlayer.AddPet(player.GetToggleValue("PetDragon"), hideVisual, BuffID.PetDD2Dragon, ProjectileID.DD2PetDragon);
            //junimo
            modPlayer.AddPet(player.GetToggleValue("PetHarpy"), hideVisual, BuffID.LilHarpy, ProjectileID.LilHarpy);
            modPlayer.AddPet(player.GetToggleValue("PetLizard"), hideVisual, BuffID.PetLizard, ProjectileID.PetLizard);
            modPlayer.AddPet(player.GetToggleValue("PetMinitaur"), hideVisual, BuffID.MiniMinotaur, ProjectileID.MiniMinotaur);
            modPlayer.AddPet(player.GetToggleValue("PetParrot"), hideVisual, BuffID.PetParrot, ProjectileID.Parrot);
            modPlayer.AddPet(player.GetToggleValue("PetPigman"), hideVisual, BuffID.PigPet, ProjectileID.PigPet);
            modPlayer.AddPet(player.GetToggleValue("PetPlantero"), hideVisual, BuffID.Plantero, ProjectileID.Plantero);
            modPlayer.AddPet(player.GetToggleValue("PetGato"), hideVisual, BuffID.PetDD2Gato, ProjectileID.DD2PetGato);
            modPlayer.AddPet(player.GetToggleValue("PetPup"), hideVisual, BuffID.Puppy, ProjectileID.Puppy);
            modPlayer.AddPet(player.GetToggleValue("PetSeed"), hideVisual, BuffID.PetSapling, ProjectileID.Sapling);
            modPlayer.AddPet(player.GetToggleValue("PetSpider"), hideVisual, BuffID.PetSpider, ProjectileID.Spider);
            modPlayer.AddPet(player.GetToggleValue("PetMimic"), hideVisual, BuffID.ShadowMimic, ProjectileID.ShadowMimic);
            modPlayer.AddPet(player.GetToggleValue("PetShark"), hideVisual, BuffID.SharkPup, ProjectileID.SharkPup);
            //spiffo
            modPlayer.AddPet(player.GetToggleValue("PetSquash"), hideVisual, BuffID.Squashling, ProjectileID.Squashling);
            modPlayer.AddPet(player.GetToggleValue("PetGlider"), hideVisual, BuffID.SugarGlider, ProjectileID.SugarGlider);
            modPlayer.AddPet(player.GetToggleValue("PetTiki"), hideVisual, BuffID.TikiSpirit, ProjectileID.TikiSpirit);
            modPlayer.AddPet(player.GetToggleValue("PetTurtle"), hideVisual, BuffID.PetTurtle, ProjectileID.Turtle);
            modPlayer.AddPet(player.GetToggleValue("PetVolt"), hideVisual, BuffID.VoltBunny, ProjectileID.VoltBunny);
            modPlayer.AddPet(player.GetToggleValue("PetZephyr"), hideVisual, BuffID.ZephyrFish, ProjectileID.ZephyrFish);

            modPlayer.AddPet(player.GetToggleValue("PetOrb"), hideVisual, BuffID.ShadowOrb, ProjectileID.ShadowOrb);
            modPlayer.AddPet(player.GetToggleValue("PetHeart"), hideVisual, BuffID.CrimsonHeart, ProjectileID.CrimsonHeart);
            modPlayer.AddPet(player.GetToggleValue("PetLantern"), hideVisual, BuffID.MagicLantern, ProjectileID.MagicLantern);
            modPlayer.AddPet(player.GetToggleValue("PetNavi"), hideVisual, BuffID.FairyBlue, ProjectileID.BlueFairy);
            modPlayer.AddPet(player.GetToggleValue("PetFlicker"), hideVisual, BuffID.PetDD2Ghost, ProjectileID.DD2PetGhost);
            modPlayer.AddPet(player.GetToggleValue("PetWisp"), hideVisual, BuffID.Wisp, ProjectileID.Wisp);
            modPlayer.AddPet(player.GetToggleValue("PetSuspEye"), hideVisual, BuffID.SuspiciousTentacle, ProjectileID.SuspiciousTentacle);

            modPlayer.AddPet(player.GetToggleValue("PetKS"), hideVisual, BuffID.KingSlimePet, ProjectileID.KingSlimePet);
            modPlayer.AddPet(player.GetToggleValue("PetEoC"), hideVisual, BuffID.EyeOfCthulhuPet, ProjectileID.EyeOfCthulhuPet);
            modPlayer.AddPet(player.GetToggleValue("PetEoW"), hideVisual, BuffID.EaterOfWorldsPet, ProjectileID.EaterOfWorldsPet);
            modPlayer.AddPet(player.GetToggleValue("PetBoC"), hideVisual, BuffID.BrainOfCthulhuPet, ProjectileID.BrainOfCthulhuPet);
            modPlayer.AddPet(player.GetToggleValue("PetDeer"), hideVisual, BuffID.DeerclopsPet, ProjectileID.DeerclopsPet);
            modPlayer.AddPet(player.GetToggleValue("PetQB"), hideVisual, BuffID.QueenBeePet, ProjectileID.QueenBeePet);
            modPlayer.AddPet(player.GetToggleValue("PetSkele"), hideVisual, BuffID.SkeletronPet, ProjectileID.SkeletronPet);
            modPlayer.AddPet(player.GetToggleValue("PetQS"), hideVisual, BuffID.QueenSlimePet, ProjectileID.QueenSlimePet);
            modPlayer.AddPet(player.GetToggleValue("PetDestroyer"), hideVisual, BuffID.DestroyerPet, ProjectileID.DestroyerPet);
            modPlayer.AddPet(player.GetToggleValue("PetTwins"), hideVisual, BuffID.TwinsPet, ProjectileID.TwinsPet);
            modPlayer.AddPet(player.GetToggleValue("PetSkelePrime"), hideVisual, BuffID.SkeletronPrimePet, ProjectileID.SkeletronPrimePet);
            modPlayer.AddPet(player.GetToggleValue("PetOgre"), hideVisual, BuffID.DD2OgrePet, ProjectileID.DD2OgrePet);
            modPlayer.AddPet(player.GetToggleValue("PetPlantera"), hideVisual, BuffID.PlanteraPet, ProjectileID.PlanteraPet);
            modPlayer.AddPet(player.GetToggleValue("PetPumpking"), hideVisual, BuffID.PumpkingPet, ProjectileID.PumpkingPet);
            modPlayer.AddPet(player.GetToggleValue("PetEverscream"), hideVisual, BuffID.EverscreamPet, ProjectileID.EverscreamPet);
            modPlayer.AddPet(player.GetToggleValue("PetIceQueen"), hideVisual, BuffID.IceQueenPet, ProjectileID.IceQueenPet);
            modPlayer.AddPet(player.GetToggleValue("PetDuke"), hideVisual, BuffID.DukeFishronPet, ProjectileID.DukeFishronPet);
            modPlayer.AddPet(player.GetToggleValue("PetGolem"), hideVisual, BuffID.GolemPet, ProjectileID.GolemPet);
            modPlayer.AddPet(player.GetToggleValue("PetEoL"), hideVisual, BuffID.FairyQueenPet, ProjectileID.FairyQueenPet);
            modPlayer.AddPet(player.GetToggleValue("PetBetsy"), hideVisual, BuffID.DD2BetsyPet, ProjectileID.DD2BetsyPet);
            modPlayer.AddPet(player.GetToggleValue("PetMartian"), hideVisual, BuffID.MartianPet, ProjectileID.MartianPet);
            modPlayer.AddPet(player.GetToggleValue("PetLC"), hideVisual, BuffID.LunaticCultistPet, ProjectileID.LunaticCultistPet);
            modPlayer.AddPet(player.GetToggleValue("PetML"), hideVisual, BuffID.MoonLordPet, ProjectileID.MoonLordPet);
        }

        public override void AddRecipes()
        {
            CreateRecipe()
                .AddIngredient(ItemID.AmberMosquito)
                .AddIngredient(ItemID.EatersBone)
                .AddIngredient(ItemID.BoneRattle)
                .AddIngredient(ItemID.BabyGrinchMischiefWhistle)
                .AddIngredient(ItemID.Nectar)
                .AddIngredient(ItemID.HellCake)
                .AddIngredient(ItemID.Fish)
                .AddIngredient(ItemID.BambooLeaf)
                .AddIngredient(ItemID.BoneKey)
                .AddIngredient(ItemID.ToySled)
                .AddIngredient(ItemID.StrangeGlowingMushroom)
                .AddIngredient(ItemID.FullMoonSqueakyToy)
                .AddIngredient(ItemID.BerniePetItem)
                .AddIngredient(ItemID.UnluckyYarn)
                .AddIngredient(ItemID.ChesterPetItem)
                .AddIngredient(ItemID.CompanionCube)
                .AddIngredient(ItemID.CursedSapling)
                .AddIngredient(ItemID.BallOfFuseWire)
                .AddIngredient(ItemID.CelestialWand)
                .AddIngredient(ItemID.EyeSpring)
                .AddIngredient(ItemID.ExoticEasternChewToy)
                .AddIngredient(ItemID.BedazzledNectar)
                .AddIngredient(ItemID.GlommerPetItem)
                .AddIngredient(ItemID.DD2PetDragon)
                .AddIngredient(ItemID.BirdieRattle)
                .AddIngredient(ItemID.LizardEgg)
                .AddIngredient(ItemID.TartarSauce)
                .AddIngredient(ItemID.ParrotCracker)
                .AddIngredient(ItemID.PigPetItem)
                .AddIngredient(ItemID.MudBud)
                .AddIngredient(ItemID.DD2PetGato)
                .AddIngredient(ItemID.DogWhistle)
                .AddIngredient(ItemID.Seedling)
                .AddIngredient(ItemID.SpiderEgg)
                .AddIngredient(ItemID.OrnateShadowKey)
                .AddIngredient(ItemID.SharkBait)
                .AddIngredient(ItemID.MagicalPumpkinSeed)
                .AddIngredient(ItemID.EucaluptusSap)
                .AddIngredient(ItemID.TikiTotem)
                .AddIngredient(ItemID.Seaweed)
                .AddIngredient(ItemID.LightningCarrot)
                .AddIngredient(ItemID.ZephyrFish)
                .AddIngredient(ItemID.ShadowOrb)
                .AddIngredient(ItemID.CrimsonHeart)
                .AddIngredient(ItemID.MagicLantern)
                .AddIngredient(ItemID.FairyBell)
                .AddIngredient(ItemID.DD2PetGhost)
                .AddIngredient(ItemID.WispinaBottle)
                .AddIngredient(ItemID.SuspiciousLookingTentacle)
                .AddIngredient(ItemID.KingSlimePetItem)
                .AddIngredient(ItemID.EyeOfCthulhuPetItem)
                .AddIngredient(ItemID.EaterOfWorldsBossBag)
                .AddIngredient(ItemID.BrainOfCthulhuPetItem)
                .AddIngredient(ItemID.DeerclopsPetItem)
                .AddIngredient(ItemID.QueenBeePetItem)
                .AddIngredient(ItemID.SkeletronPetItem)
                .AddIngredient(ItemID.QueenSlimePetItem)
                .AddIngredient(ItemID.DestroyerPetItem)
                .AddIngredient(ItemID.TwinsPetItem)
                .AddIngredient(ItemID.SkeletronPrimePetItem)
                .AddIngredient(ItemID.DD2OgrePetItem)
                .AddIngredient(ItemID.PlanteraPetItem)
                .AddIngredient(ItemID.PumpkingPetItem)
                .AddIngredient(ItemID.EverscreamPetItem)
                .AddIngredient(ItemID.IceQueenPetItem)
                .AddIngredient(ItemID.DukeFishronPetItem)
                .AddIngredient(ItemID.GolemPetItem)
                .AddIngredient(ItemID.FairyQueenPetItem)
                .AddIngredient(ItemID.DD2BetsyPetItem)
                .AddIngredient(ItemID.MartianPetItem)
                .AddIngredient(ItemID.LunaticCultistPetItem)
                .AddIngredient(ItemID.MoonLordPetItem)
                .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
                .Register();
        }
    }
}
