using CalamityMod.Items.Armor;
using CalamityMod.Items.Placeables.Furniture;
using SacredTools.Items.Armor.Asthraltite;
using SacredTools.Items.Armor.Dragon;
using System;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod.Items.Titan;
using ThoriumMod.Projectiles.Healer;
using ThoriumMod.Projectiles.Minions;
using ThoriumMod.Projectiles.Pets;

namespace FargowiltasSoulsDLC
{
    public class FargowiltasSoulsDLC : Mod
    {
        internal static FargowiltasSoulsDLC Instance;

        internal bool ThoriumLoaded;
        internal bool CalamityLoaded;
        internal bool SoALoaded;
        internal bool DBZMODLoaded;

        public override void Load()
        {
            Instance = this;

            if (ModLoader.GetMod("ThoriumMod") != null)
            {
                AddToggle("ThoriumHeader", "Thorium Toggles", "ThoriumSoul", "ffffff");

                //AddToggle("ThoriumCrystalScorpionConfig", "Crystal Scorpion", "ConjuristsSoul", "ffffff");
                AddToggle("ThoriumYumasPendantConfig", "Yuma's Pendant", "ConjuristsSoul", "ffffff");
                AddToggle("ThoriumHeadMirrorConfig", "Head Mirror", "GuardianAngelsSoul", "ffffff");
                //AddToggle("ThoriumAirWalkersConfig", "Air Walkers", "SupersonicSoul", "ffffff");

                AddToggle("MuspelheimForce", "Force of Muspelheim", "MuspelheimForce", "ffffff");
                AddToggle("ThoriumBeeBootiesConfig", "Bee Booties", "BulbEnchant", "ffffff");
                AddToggle("ThoriumSaplingMinionConfig", "Sapling Minion", "LivingWoodEnchant", "ffffff");

                AddToggle("JotunheimForce", "Force of Jotunheim", "JotunheimForce", "ffffff");
                AddToggle("ThoriumTideFoamConfig", "Tide Hunter Foam", "TideHunterEnchant", "ffffff");
                AddToggle("ThoriumYewCritsConfig", "Yew Wood Crits", "YewWoodEnchant", "ffffff");
                AddToggle("ThoriumCryoDamageConfig", "Cryo-Magus Damage", "CryomancerEnchant", "ffffff");
                AddToggle("ThoriumIcyBarrierConfig", "Icy Barrier", "IcyEnchant", "ffffff");
                AddToggle("ThoriumWhisperingTentaclesConfig", "Whispering Tentacles", "WhisperingEnchant", "ffffff");

                AddToggle("AlfheimForce", "Force of Alfheim", "AlfheimForce", "ffffff");
                AddToggle("ThoriumCherubMinionConfig", "Li'l Cherub Minion", "SacredEnchant", "ffffff");

                AddToggle("ThoriumWarlockWispsConfig", "Warlock Wisps", "WarlockEnchant", "ffffff");
                AddToggle("ThoriumDevilMinionConfig", "Li'l Devil Minion", "WarlockEnchant", "ffffff");
                AddToggle("ThoriumBiotechProbeConfig", "Biotech Probe", "BiotechEnchant", "ffffff");

                AddToggle("NiflheimForce", "Force of Niflheim", "NiflheimForce", "ffffff");
                AddToggle("ThoriumMixTapeConfig", "Mix Tape", "NobleEnchant", "ffffff");
                AddToggle("ThoriumCyberStatesConfig", "Cyber Punk States", "CyberPunkEnchant", "ffffff");
                AddToggle("ThoriumMetronomeConfig", "Metronome", "MaestroEnchant", "ffffff");
                AddToggle("ThoriumMarchingBandConfig", "Marching Band Effect", "MarchingBandEnchant", "ffffff");

                AddToggle("SvartalfheimForce", "Force of Svartalfheim", "SvartalfheimForce", "ffffff");
                AddToggle("ThoriumEyeoftheStormConfig", "Eye of the Storm", "GraniteEnchant", "ffffff");
                AddToggle("ThoriumBronzeLightningConfig", "Bronze Lightning", "BronzeEnchant", "ffffff");
                AddToggle("ThoriumIncandescentSparkConfig", "Incandescent Spark", "DurasteelEnchant", "ffffff");
                AddToggle("ThoriumGreedyMagnetConfig", "Greedy Magnet", "DurasteelEnchant", "ffffff");
                AddToggle("ThoriumConduitShieldConfig", "Conduit Shield", "ConduitEnchant", "ffffff");

                AddToggle("MidgardForce", "Force of Midgard", "MidgardForce", "ffffff");
                AddToggle("ThoriumLodestoneConfig", "Lodestone Resistance", "LodestoneEnchant", "ffffff");
                AddToggle("ThoriumBeholderEyeConfig", "Eye of the Beholder", "ValadiumEnchant", "ffffff");
                AddToggle("ThoriumIllumiteMissileConfig", "Illumite Missile", "IllumiteEnchant", "ffffff");
                AddToggle("ThoriumTerrariumSpiritsConfig", "Terrarium Spirits", "TerrariumEnchant", "ffffff");
                AddToggle("ThoriumDiverConfig", "Spawn Divers", "ThoriumEnchant", "ffffff");
                AddToggle("ThoriumCrietzConfig", "Crietz", "ThoriumEnchant", "ffffff");
                AddToggle("ThoriumJesterBellConfig", "Jester Bell", "JesterEnchant", "ffffff");

                AddToggle("VanaheimForce", "Force of Vanaheim", "VanaheimForce", "ffffff");
                AddToggle("ThoriumFolvAuraConfig", "Folv's Aura", "FolvEnchant", "ffffff");
                AddToggle("ThoriumFolvBoltsConfig", "Folv's Bolts", "FolvEnchant", "ffffff");
                AddToggle("ThoriumManaBootsConfig", "Mana-Charged Rocketeers", "MalignantEnchant", "ffffff");
                AddToggle("ThoriumWhiteDwarfConfig", "White Dwarf Flares", "WhiteDwarfEnchant", "ffffff");
                AddToggle("ThoriumCelestialAuraConfig", "Celestial Aura", "CelestialEnchant", "ffffff");
                AddToggle("ThoriumAscensionStatueConfig", "Ascension Statuette", "CelestialEnchant", "ffffff");

                AddToggle("HelheimForce", "Force of Helheim", "HelheimForce", "ffffff");
                AddToggle("ThoriumSpiritWispsConfig", "Spirit Trapper Wisps", "SpiritTrapperEnchant", "ffffff");
                AddToggle("ThoriumDreadConfig", "Dread Speed", "DreadEnchant", "ffffff");
                AddToggle("ThoriumDragonFlamesConfig", "Dragon Flames", "DragonEnchant", "ffffff");
                AddToggle("ThoriumDemonBloodConfig", "Demon Blood Effect", "DemonBloodEnchant", "ffffff");
                AddToggle("ThoriumFleshDropsConfig", "Flesh Drops", "FleshEnchant", "ffffff");
                AddToggle("ThoriumVampireGlandConfig", "Vampire Gland", "FleshEnchant", "ffffff");
                AddToggle("ThoriumBerserkerConfig", "Berserker Effect", "BerserkerEnchant", "ffffff");
                AddToggle("ThoriumSlagStompersConfig", "Slag Stompers", "MagmaEnchant", "ffffff");
                AddToggle("ThoriumSpringStepsConfig", "Spring Steps", "MagmaEnchant", "ffffff");
                AddToggle("ThoriumHarbingerOverchargeConfig", "Harbinger Overcharge", "HarbingerEnchant", "ffffff");
                AddToggle("ThoriumPlagueFlaskConfig", "Plague Lord's Flask", "PlagueDoctorEnchant", "ffffff");

                AddToggle("AsgardForce", "Force of Asgard", "AsgardForce", "ffffff");
                AddToggle("ThoriumTideGlobulesConfig", "Tide Turner Globules", "TideTurnerEnchant", "ffffff");
                AddToggle("ThoriumTideDaggersConfig", "Tide Turner Daggers", "TideTurnerEnchant", "ffffff");
                AddToggle("ThoriumAssassinDamageConfig", "Assassin Damage", "AssassinEnchant", "ffffff");
                AddToggle("ThoriumpyromancerBurstsConfig", "Pyromancer Bursts", "PyromancerEnchant", "ffffff");


                AddToggle("ThoriumKickPetalConfig", "Kick Petal", "BulbEnchant", "ffffff");
                AddToggle("ThoriumMagmaConfig", "Magma Effects", "MagmaEnchant", "ffffff");
                AddToggle("ThoriumDepthDiverEffectConfig", "Depth Diver Effect", "DepthDiverEnchant", "ffffff");
                AddToggle("ThoriumDrownedDoubloonConfig", "Drowned Doubloon", "DepthDiverEnchant", "ffffff");
                AddToggle("ThoriumIncandescentSparkConfig", "Incandescent Spark", "DurasteelEnchant", "ffffff");

                AddToggle("ThoriumNoviceClericConfig", "Novice Cleric Effect", "NoviceClericEnchant", "ffffff");
                AddToggle("ThoriumJungleHeartConfig", "Heart of the Jungle", "LifeBloomEnchant", "ffffff");
                AddToggle("ThoriumSandstoneJumpConfig", "Sandstone Jump", "SandstoneEnchant", "ffffff");
                AddToggle("ThoriumKarmicHolderConfig", "Karmic Holder", "SacredEnchant", "ffffff");

                AddToggle("ThoriumSandweaversTiaraConfig", "Sandweaver's Tiara", "LodestoneEnchant", "ffffff");
                AddToggle("ThoriumPlasmaGeneratorConfig", "Plasma Generator", "PyromancerEnchant", "ffffff");



            }
            else
            {
                AddToggle("ThoriumHeader", "Enable Thorium for these Toggles", "", "ffffff");
            }

            if (ModLoader.GetMod("CalamityMod") != null)
            {
                AddToggle("CalamityHeader", "Calamity Toggles", "CalamitySoul", "ffffff");
                //AddToggle("CalamityElementalQuiverConfig", "Elemental Quiver", "SnipersSoul", "ffffff");

                AddToggle("AnnihilationForce", "Force of Annihilation", "AnnihilationForce", "ffffff");
                AddToggle("CalamityValkyrieMinionConfig", "Valkyrie Minion", "AerospecEnchant", "ffffff");
                AddToggle("CalamityGladiatorLocketConfig", "Gladiator's Locket", "AerospecEnchant", "ffffff");
                AddToggle("CalamityUnstablePrismConfig", "Unstable Prism", "AerospecEnchant", "ffffff");
                AddToggle("CalamityFungalSymbiote", "Fungal Symbiote", "StatigelEnchant", "ffffff");
                AddToggle("CalamityAtaxiaEffectsConfig", "Ataxia Effects", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityChaosMinionConfig", "Chaos Spirit Minion", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityHallowedRuneConfig", "Hallowed Rune", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityEtherealExtorterConfig", "Ethereal Extorter", "AtaxiaEnchant", "ffffff");
                AddToggle("CalamityXerocEffectsConfig", "Xeroc Effects", "XerocEnchant", "ffffff");
                
                AddToggle("CalamityStatisBeltOfCursesConfig", "Statis' Void Sash", "FearmongerEnchant", "ffffff");

                AddToggle("DevastationForce", "Force of Devastation", "DevastationForce", "ffffff");
                AddToggle("CalamityReaverEffectsConfig", "Reaver Effects", "ReaverEnchant", "ffffff");
                AddToggle("CalamityReaverMinionConfig", "Reaver Orb Minion", "ReaverEnchant", "ffffff");
                AddToggle("CalamityPlagueHiveConfig", "Plague Hive", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityPlaguedFuelPackConfig", "Plague Fuel Pack", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityTheCamperConfig", "The Camper", "PlagueReaperEnchant", "ffffff");
                AddToggle("CalamityDevilMinionConfig", "Red Devil Minion", "DemonShadeEnchant", "ffffff");
                AddToggle("CalamityProfanedSoulConfig", "Profaned Soul Crystal", "DemonShadeEnchant", "ffffff");


                AddToggle("DesolationForce", "Force of Desolation", "DesolationForce", "ffffff");
                AddToggle("CalamitySnowRuffianWingsConfig", "Snow Ruffian Wings", "SnowRuffianEnchant", "ffffff");
                AddToggle("CalamityDaedalusEffectsConfig", "Daedalus Effects", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityDaedalusMinionConfig", "Daedalus Crystal Minion", "DaedalusEnchant", "ffffff");
                AddToggle("CalamityPermafrostPotionConfig", "Permafrost's Concoction", "DaedalusEnchant", "ffffff");

                AddToggle("CalamityAstralStarsConfig", "Astral Stars", "AstralEnchant", "ffffff");
                AddToggle("CalamityGravistarSabatonConfig", "GravistarSabaton", "AstralEnchant", "ffffff");

                AddToggle("CalamityOmegaTentaclesConfig", "Omega Blue Tentacles", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityDivingSuitConfig", "Abyssal Diving Suit", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityReaperToothNecklaceConfig", "Reaper Tooth Necklace", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityMutatedTruffleConfig", "Mutated Truffle", "OmegaBlueEnchant", "ffffff");
                AddToggle("CalamityUrchinConfig", "Victide Sea Urchin", "VictideEnchant", "ffffff");
                AddToggle("CalamityLuxorGiftConfig", "Luxor's Gift", "VictideEnchant", "ffffff");

                AddToggle("CalamityBloodflareEffectsConfig", "Bloodflare Effects", "BloodflareEnchant", "ffffff");
                AddToggle("CalamityPolterMinesConfig", "Polterghast Mines", "BloodflareEnchant", "ffffff");

                AddToggle("CalamitySilvaEffectsConfig", "Silva Effects", "SilvaEnchant", "ffffff");
                AddToggle("CalamitySilvaMinionConfig", "Silva Crystal Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityGodlyArtifactConfig", "Godly Soul Artifact", "SilvaEnchant", "ffffff");
                AddToggle("CalamityYharimGiftConfig", "Yharim's Gift", "SilvaEnchant", "ffffff");
                AddToggle("CalamityFungalMinionConfig", "Fungal Clump Minion", "SilvaEnchant", "ffffff");
                AddToggle("CalamityPoisonSeawaterConfig", "Poisonous Sea Water", "SilvaEnchant", "ffffff");

                AddToggle("CalamityGodSlayerEffectsConfig", "God Slayer Effects", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityMechwormMinionConfig", "Mechworm Minion", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityNebulousCoreConfig", "Nebulous Core", "GodSlayerEnchant", "ffffff");
                AddToggle("CalamityAuricEffectsConfig", "Auric Tesla Effects", "AuricEnchant", "ffffff");
                AddToggle("CalamityWaifuMinionsConfig", "Elemental Waifus", "AuricEnchant", "ffffff");

                AddToggle("CalamityShellfishMinionConfig", "Shellfish Minions", "MolluskEnchant", "ffffff");
                AddToggle("CalamityGiantPearlConfig", "Giant Pearl", "MolluskEnchant", "ffffff");

                AddToggle("CalamityTarragonEffectsConfig", "Tarragon Effects", "TarragonEnchant", "ffffff");

            }
            else
            {
                AddToggle("CalamityHeader", "Enable Calamity for these Toggles", "", "ffffff");
            }

        }

        public void AddToggle(String toggle, String name, String item, String color)
        {
            ModTranslation text = CreateTranslation(toggle);
            text.SetDefault("[i:" + Instance.ItemType(item) + "][c/" + color + ": " + name + "]");
            AddTranslation(text);
        }

        public override void PostSetupContent()
        {
            try
            {
                ThoriumLoaded = ModLoader.GetMod("ThoriumMod") != null;
                CalamityLoaded = ModLoader.GetMod("CalamityMod") != null;
                SoALoaded = ModLoader.GetMod("SacredTools") != null;
                DBZMODLoaded = ModLoader.GetMod("DBZMOD") != null; 
            }
            catch (Exception e)
            {
                Logger.Error("FargowiltasSoulsDLC PostSetupContent Error: " + e.StackTrace + e.Message);
            }
        }

        public override void AddRecipes()
        {
            if (ThoriumLoaded)
            {
                ThoriumRecipes();
            }

            if (CalamityLoaded)
            {
                CalamityRecipes();
            }

            if (SoALoaded)
            {
                SoARecipes();
            }


        }

        private void ThoriumRecipes()
        {
            Mod thorium = ModLoader.GetMod("ThoriumMod");

            //jester mask
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Jester Mask", thorium.ItemType("JestersMask"), thorium.ItemType("JestersMask2"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyJesterMask", group);
            //jester shirt
            group = new RecipeGroup(() => Lang.misc[37] + " Jester Shirt", thorium.ItemType("JestersShirt"), thorium.ItemType("JestersShirt2"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyJesterShirt", group);
            //jester legging
            group = new RecipeGroup(() => Lang.misc[37] + " Jester Leggings", thorium.ItemType("JestersLeggings"), thorium.ItemType("JestersLeggings2"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyJesterLeggings", group);
            //evil wood tambourine
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Wood Tambourine", thorium.ItemType("EbonWoodTambourine"), thorium.ItemType("ShadeWoodTambourine"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyTambourine", group);
            //fan letter
            group = new RecipeGroup(() => Lang.misc[37] + " Fan Letter", thorium.ItemType("FanLetter"), thorium.ItemType("FanLetter2"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyLetter", group);
            //bugle horn
            group = new RecipeGroup(() => Lang.misc[37] + " Bugle Horn", thorium.ItemType("GoldenBugleHorn"), thorium.ItemType("PlatinumBugle"));
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyBugleHorn", group);

            //titan 
            group = new RecipeGroup(() => Lang.misc[37] + " Titan Headgear", ModContent.ItemType<TitanHelmet>(), ModContent.ItemType<TitanMask>(), ModContent.ItemType<TitanHeadgear>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyTitanHelmet", group);

        }

        private void CalamityRecipes()
        {
            //Aerospec
            RecipeGroup group = new RecipeGroup(() => Lang.misc[37] + " Aerospec Helmet", ModContent.ItemType<AerospecHat>(), ModContent.ItemType<AerospecHeadgear>(), ModContent.ItemType<AerospecHelm>(), ModContent.ItemType<AerospecHood>(), ModContent.ItemType<AerospecHelmet>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAerospecHelmet", group);

            //Ataxia
            group = new RecipeGroup(() => Lang.misc[37] + " Ataxia Helmet", ModContent.ItemType<AtaxiaHeadgear>(), ModContent.ItemType<AtaxiaHelm>(), ModContent.ItemType<AtaxiaHood>(), ModContent.ItemType<AtaxiaHelmet>(), ModContent.ItemType<AtaxiaMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAtaxiaHelmet", group);

            //Auric
            group = new RecipeGroup(() => Lang.misc[37] + " Auric Helmet", ModContent.ItemType<AuricTeslaHelm>(), ModContent.ItemType<AuricTeslaPlumedHelm>(), ModContent.ItemType<AuricTeslaHoodedFacemask>(), ModContent.ItemType<AuricTeslaSpaceHelmet>(), ModContent.ItemType<AuricTeslaWireHemmedVisage>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAuricHelmet", group);

            //Bloodflare
            group = new RecipeGroup(() => Lang.misc[37] + " Bloodflare Helmet", ModContent.ItemType<BloodflareHelm>(), ModContent.ItemType<BloodflareHelmet>(), ModContent.ItemType<BloodflareHornedHelm>(), ModContent.ItemType<BloodflareHornedMask>(), ModContent.ItemType<BloodflareMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyBloodflareHelmet", group);

            //Daedalus
            group = new RecipeGroup(() => Lang.misc[37] + " Daedalus Helmet", ModContent.ItemType<DaedalusHelm>(), ModContent.ItemType<DaedalusHelmet>(), ModContent.ItemType<DaedalusHat>(), ModContent.ItemType<DaedalusHeadgear>(), ModContent.ItemType<DaedalusVisor>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyDaedalusHelmet", group);

            // Godslayer
            group = new RecipeGroup(() => Lang.misc[37] + " Godslayer Helmet", ModContent.ItemType<GodSlayerHelm>(), ModContent.ItemType<GodSlayerHelmet>(), ModContent.ItemType<GodSlayerVisage>(), ModContent.ItemType<GodSlayerHornedHelm>(), ModContent.ItemType<GodSlayerMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyGodslayerHelmet", group);

            // Reaver
            group = new RecipeGroup(() => Lang.misc[37] + " Reaver Helmet", ModContent.ItemType<ReaverHelm>(), ModContent.ItemType<ReaverVisage>(), ModContent.ItemType<ReaverMask>(), ModContent.ItemType<ReaverHelmet>(), ModContent.ItemType<ReaverCap>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyReaverHelmet", group);

            //Silva
            group = new RecipeGroup(() => Lang.misc[37] + " Silva Helmet", ModContent.ItemType<SilvaHelm>(), ModContent.ItemType<SilvaHornedHelm>(), ModContent.ItemType<SilvaMaskedCap>(), ModContent.ItemType<SilvaHelmet>(), ModContent.ItemType<SilvaMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnySilvaHelmet", group);

            //Statigel
            group = new RecipeGroup(() => Lang.misc[37] + " Statigel Helmet", ModContent.ItemType<StatigelHelm>(), ModContent.ItemType<StatigelHeadgear>(), ModContent.ItemType<StatigelCap>(), ModContent.ItemType<StatigelHood>(), ModContent.ItemType<StatigelMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyStatigelHelmet", group);
            //evil effigy
            group = new RecipeGroup(() => Lang.misc[37] + " Evil Effigy", ModContent.ItemType<CorruptionEffigy>(), ModContent.ItemType<CrimsonEffigy>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyEvilEffigy", group);

            //Tarragon
            group = new RecipeGroup(() => Lang.misc[37] + " Tarragon Helmet", ModContent.ItemType<TarragonHelm>(), ModContent.ItemType<TarragonVisage>(), ModContent.ItemType<TarragonMask>(), ModContent.ItemType<TarragonHornedHelm>(), ModContent.ItemType<TarragonHelmet>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyTarragonHelmet", group);

            //Victide
            group = new RecipeGroup(() => Lang.misc[37] + " Victide Helmet", ModContent.ItemType<VictideHelm>(), ModContent.ItemType<VictideVisage>(), ModContent.ItemType<VictideMask>(), ModContent.ItemType<VictideHelmet>(), ModContent.ItemType<VictideHeadgear>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyVictideHelmet", group);

            //Wulfrum
            group = new RecipeGroup(() => Lang.misc[37] + " Wulfrum Helmet", ModContent.ItemType<WulfrumHelm>(), ModContent.ItemType<WulfrumHeadgear>(), ModContent.ItemType<WulfrumHood>(), ModContent.ItemType<WulfrumHelmet>(), ModContent.ItemType<WulfrumMask>());
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyWulfrumHelmet", group);
        }

        private void SoARecipes()
        {
            // Flarium
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyFlariumHelmet",
                new RecipeGroup(() => Lang.misc[37] + " Flarium Helmet",
                    ModContent.ItemType<FlariumCowl>(), ModContent.ItemType<FlariumHelmet>(), ModContent.ItemType<FlariumHood>(), ModContent.ItemType<FlariumCrown>(), ModContent.ItemType<FlariumMask>()));

            // Asthraltite
            RecipeGroup.RegisterGroup("FargowiltasSoulsDLC:AnyAstralHelmet",
                new RecipeGroup(() => Lang.misc[37] + " Asthraltite Helmet",
                    ModContent.ItemType<AsthralMelee>(), ModContent.ItemType<AsthralRanged>(), ModContent.ItemType<AsthralMage>(), ModContent.ItemType<AsthralSummon>(), ModContent.ItemType<AsthralThrown>()));
        }
    }
}