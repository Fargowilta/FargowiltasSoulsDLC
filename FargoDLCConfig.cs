using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using Terraria;
using Terraria.ModLoader.Config;
using System.ComponentModel;

namespace FargowiltasSoulsDLC
{
    class SoulConfig : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;
        public static SoulConfig Instance;

        private void SetAll(bool val)
        {
            IEnumerable<FieldInfo> configs = typeof(SoulConfig).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo config in configs)
            {
                config.SetValue(this, val);
            }

            IEnumerable<FieldInfo> thoriumConfigs = typeof(ThoriumToggles).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo thoriumConfig in thoriumConfigs)
            {
                thoriumConfig.SetValue(thoriumToggles, val);
            }

            IEnumerable<FieldInfo> calamityConfigs = typeof(CalamityToggles).GetFields(BindingFlags.Public | BindingFlags.Instance).Where(i => i.FieldType == true.GetType());
            foreach (FieldInfo calamityConfig in calamityConfigs)
            {
                calamityConfig.SetValue(calamityToggles, val);
            }
        }

        [Label("Toggle All On")]
        public bool PresetA
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(true);
                }
            }
        }

        [Label("Toggle All Off")]
        public bool PresetB
        {
            get => false;
            set
            {
                if (value)
                {
                    SetAll(false);
                }
            }
        }

       
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumHeader")]
        public ThoriumToggles thoriumToggles = new ThoriumToggles();

        [Label("$Mods.FargowiltasSoulsDLC.CalamityHeader")]
        public CalamityToggles calamityToggles = new CalamityToggles();

        //soa soon tm

        public override void OnLoaded()
        {
            Instance = this;
        }

        public bool GetValue(bool toggle, bool checkForMutantPresence = true)
        {
            return checkForMutantPresence && Main.player[Main.myPlayer].GetModPlayer<FargowiltasSouls.FargoPlayer>().MutantPresence ? false : toggle;
        }
    }

    public class ThoriumToggles
    {
        //[Label("$Mods.FargowiltasSoulsDLC.ThoriumCrystalScorpionConfig")]
        //[DefaultValue(true)]
        //public bool CrystalScorpion;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumHeadMirrorConfig")]
        [DefaultValue(true)]
        public bool HeadMirror;

        //[Label("$Mods.FargowiltasSoulsDLC.ThoriumAirWalkersConfig")]
        //[DefaultValue(true)]
        //public bool AirWalkers;



        [Header("$Mods.FargowiltasSoulsDLC.MuspelheimForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumBeeBootiesConfig")]
        [DefaultValue(true)]
        public bool BeeBooties;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumSaplingMinionConfig")]
        [DefaultValue(true)]
        public bool SaplingMinion;

        [Header("$Mods.FargowiltasSoulsDLC.JotunheimForce")]

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumTideFoamConfig")]
        [DefaultValue(true)]
        public bool TideFoam;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumYewCritsConfig")]
        [DefaultValue(true)]
        public bool YewCrits;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumCryoDamageConfig")]
        [DefaultValue(true)]
        public bool CryoDamage;



        [Label("$Mods.FargowiltasSoulsDLC.ThoriumIcyBarrierConfig")]
        [DefaultValue(true)]
        public bool IcyBarrier;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumWhisperingTentaclesConfig")]
        [DefaultValue(true)]
        public bool WhisperingTentacles;


        [Label("$Mods.FargowiltasSoulsDLC.ThoriumWarlockWispsConfig")]
        [DefaultValue(true)]
        public bool WarlockWisps;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumBiotechProbeConfig")]
        [DefaultValue(true)]
        public bool BiotechProbe;

        [Header("$Mods.FargowiltasSoulsDLC.NiflheimForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumMixTapeConfig")]
        [DefaultValue(true)]
        public bool MixTape;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumCyberStatesConfig")]
        [DefaultValue(true)]
        public bool CyberStates;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumMetronomeConfig")]
        [DefaultValue(true)]
        public bool Metronome;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumMarchingBandConfig")]
        [DefaultValue(true)]
        public bool MarchingBand;

        [Header("$Mods.FargowiltasSoulsDLC.SvartalfheimForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumEyeoftheStormConfig")]
        [DefaultValue(true)]
        public bool EyeoftheStorm;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumBronzeLightningConfig")]
        [DefaultValue(true)]
        public bool BronzeLightning;



        [Label("$Mods.FargowiltasSoulsDLC.ThoriumConduitShieldConfig")]
        [DefaultValue(true)]
        public bool ConduitShield;


        [Header("$Mods.FargowiltasSoulsDLC.MidgardForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumLodestoneConfig")]
        [DefaultValue(true)]
        public bool LodestoneResist;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumBeholderEyeConfig")]
        [DefaultValue(true)]
        public bool BeholderEye;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumIllumiteMissileConfig")]
        [DefaultValue(true)]
        public bool IllumiteMissile;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumTerrariumSpiritsConfig")]
        [DefaultValue(true)]
        public bool TerrariumSpirits;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumDiverConfig")]
        [DefaultValue(true)]
        public bool ThoriumDivers;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumCrietzConfig")]
        [DefaultValue(true)]
        public bool Crietz;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumJesterBellConfig")]
        [DefaultValue(true)]
        public bool JesterBell;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumManaBootsConfig")]
        [DefaultValue(true)]
        public bool ManaBoots;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumWhiteDwarfConfig")]
        [DefaultValue(true)]
        public bool WhiteDwarf;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumCelestialAuraConfig")]
        [DefaultValue(true)]
        public bool CelestialAura;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumAscensionStatueConfig")]
        [DefaultValue(true)]
        public bool AscensionStatue;

        [Header("$Mods.FargowiltasSoulsDLC.HelheimForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumSpiritWispsConfig")]
        [DefaultValue(true)]
        public bool SpiritTrapperWisps;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumDreadConfig")]
        [DefaultValue(true)]
        public bool DreadSpeed;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumDragonFlamesConfig")]
        [DefaultValue(true)]
        public bool DragonFlames;


        [Label("$Mods.FargowiltasSoulsDLC.ThoriumDemonBloodConfig")]
        [DefaultValue(true)]
        public bool DemonBloodEffect;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumFleshDropsConfig")]
        [DefaultValue(true)]
        public bool FleshDrops;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumVampireGlandConfig")]
        [DefaultValue(true)]
        public bool VampireGland;


        [Label("$Mods.FargowiltasSoulsDLC.ThoriumBerserkerConfig")]
        [DefaultValue(true)]
        public bool BerserkerEffect;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumSlagStompersConfig")]
        [DefaultValue(true)]
        public bool SlagStompers;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumSpringStepsConfig")]
        [DefaultValue(true)]
        public bool SpringSteps;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumHarbingerOverchargeConfig")]
        [DefaultValue(true)]
        public bool HarbingerOvercharge;

        [Header("$Mods.FargowiltasSoulsDLC.AsgardForce")]
        [Label("$Mods.FargowiltasSoulsDLC.ThoriumTideGlobulesConfig")]
        [DefaultValue(true)]
        public bool TideGlobules;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumTideDaggersConfig")]
        [DefaultValue(true)]
        public bool TideDaggers;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumAssassinDamageConfig")]
        [DefaultValue(true)]
        public bool AssassinDamage;

        [Label("$Mods.FargowiltasSoulsDLC.ThoriumpyromancerBurstsConfig")]
        [DefaultValue(true)]
        public bool PyromancerBursts;

    }

    public class CalamityToggles
    {
        //[Label("$Mods.FargowiltasSoulsDLC.CalamityElementalQuiverConfig")]
        //[DefaultValue(true)]
        //public bool ElementalQuiver;

        //aerospec
        [Header("$Mods.FargowiltasSoulsDLC.AnnihilationForce")]
        [Label("$Mods.FargowiltasSoulsDLC.CalamityValkyrieMinionConfig")]
        [DefaultValue(true)]
        public bool ValkyrieMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityGladiatorLocketConfig")]
        [DefaultValue(true)]
        public bool GladiatorLocket;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityUnstablePrismConfig")]
        [DefaultValue(true)]
        public bool UnstablePrism;

        //statigel
        [Label("$Mods.FargowiltasSoulsDLC.CalamityFungalSymbiote")]
        [DefaultValue(true)]
        public bool FungalSymbiote;

        //hydrothermic
        [Label("$Mods.FargowiltasSoulsDLC.CalamityAtaxiaEffectsConfig")]
        [DefaultValue(true)]
        public bool AtaxiaEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityChaosMinionConfig")]
        [DefaultValue(true)]
        public bool ChaosMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityHallowedRuneConfig")]
        [DefaultValue(true)]
        public bool HallowedRune;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityEtherealExtorterConfig")]
        [DefaultValue(true)]
        public bool EtherealExtorter;

        //xeroc
        [Label("$Mods.FargowiltasSoulsDLC.CalamityXerocEffectsConfig")]
        [DefaultValue(true)]
        public bool XerocEffects;

        //fearmonger

        [Label("$Mods.FargowiltasSoulsDLC.CalamityStatisBeltOfCursesConfig")]
        [DefaultValue(true)]
        public bool StatisBeltOfCurses;

        //reaver
        [Header("$Mods.FargowiltasSoulsDLC.DevastationForce")]
        [Label("$Mods.FargowiltasSoulsDLC.CalamityReaverEffectsConfig")]
        [DefaultValue(true)]
        public bool ReaverEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityReaverMinionConfig")]
        [DefaultValue(true)]
        public bool ReaverMinion;

        //plague reaper
        [Label("$Mods.FargowiltasSoulsDLC.CalamityPlagueHiveConfig")]
        [DefaultValue(true)]
        public bool PlagueHive;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityPlaguedFuelPackConfig")]
        [DefaultValue(true)]
        public bool PlaguedFuelPack;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityTheCamperConfig")]
        [DefaultValue(false)]
        public bool TheCamper;

        //demonshade
        [Label("$Mods.FargowiltasSoulsDLC.CalamityDevilMinionConfig")]
        [DefaultValue(true)]
        public bool RedDevilMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityProfanedSoulConfig")]
        [DefaultValue(true)]
        public bool ProfanedSoulCrystal;

        //daedalus
        [Header("$Mods.FargowiltasSoulsDLC.DesolationForce")]
        [Label("$Mods.FargowiltasSoulsDLC.CalamityDaedalusEffectsConfig")]
        [DefaultValue(true)]
        public bool DaedalusEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityDaedalusMinionConfig")]
        [DefaultValue(true)]
        public bool DaedalusMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityPermafrostPotionConfig")]
        [DefaultValue(true)]
        public bool PermafrostPotion;


        //astral
        [Label("$Mods.FargowiltasSoulsDLC.CalamityAstralStarsConfig")]
        [DefaultValue(true)]
        public bool AstralStars;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityGravistarSabatonConfig")]
        [DefaultValue(true)]
        public bool GravistarSabaton;

        //omega blue
        [Label("$Mods.FargowiltasSoulsDLC.CalamityOmegaTentaclesConfig")]
        [DefaultValue(true)]
        public bool OmegaTentacles;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityDivingSuitConfig")]
        [DefaultValue(false)]
        public bool DivingSuit;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityReaperToothNecklaceConfig")]
        [DefaultValue(false)]
        public bool ReaperToothNecklace;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityMutatedTruffleConfig")]
        [DefaultValue(true)]
        public bool MutatedTruffle;

        //victide
        [Label("$Mods.FargowiltasSoulsDLC.CalamityUrchinConfig")]
        [DefaultValue(true)]
        public bool UrchinMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityLuxorGiftConfig")]
        [DefaultValue(true)]
        public bool LuxorGift;





        //organize more later ech


        [Label("$Mods.FargowiltasSoulsDLC.CalamityBloodflareEffectsConfig")]
        [DefaultValue(true)]
        public bool BloodflareEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityPolterMinesConfig")]
        [DefaultValue(true)]
        public bool PolterMines;

        [Label("$Mods.FargowiltasSoulsDLC.CalamitySilvaEffectsConfig")]
        [DefaultValue(true)]
        public bool SilvaEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamitySilvaMinionConfig")]
        [DefaultValue(true)]
        public bool SilvaMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityGodlyArtifactConfig")]
        [DefaultValue(true)]
        public bool GodlySoulArtifact;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityYharimGiftConfig")]
        [DefaultValue(true)]
        public bool YharimGift;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityFungalMinionConfig")]
        [DefaultValue(true)]
        public bool FungalMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityPoisonSeawaterConfig")]
        [DefaultValue(true)]
        public bool PoisonSeawater;


        [Label("$Mods.FargowiltasSoulsDLC.CalamityGodSlayerEffectsConfig")]
        [DefaultValue(true)]
        public bool GodSlayerEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityMechwormMinionConfig")]
        [DefaultValue(true)]
        public bool MechwormMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityNebulousCoreConfig")]
        [DefaultValue(true)]
        public bool NebulousCore;


        [Label("$Mods.FargowiltasSoulsDLC.CalamityAuricEffectsConfig")]
        [DefaultValue(true)]
        public bool AuricEffects;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityWaifuMinionsConfig")]
        [DefaultValue(true)]
        public bool WaifuMinions;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityShellfishMinionConfig")]
        [DefaultValue(true)]
        public bool ShellfishMinion;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityAmidiasPendantConfig")]
        [DefaultValue(true)]
        public bool AmidiasPendant;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityGiantPearlConfig")]
        [DefaultValue(true)]
        public bool GiantPearl;

        [Label("$Mods.FargowiltasSoulsDLC.CalamityTarragonEffectsConfig")]
        [DefaultValue(true)]
        public bool TarragonEffects;
    }
}
