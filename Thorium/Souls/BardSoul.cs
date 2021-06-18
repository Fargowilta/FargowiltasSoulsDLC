using Terraria;
using Terraria.ModLoader;
using ThoriumMod;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Souls
{
    public class BardSoul : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bard's Soul");

            Tooltip.SetDefault(
@"'Every note you produce births a new world'
30% increased symphonic damage
20% increased symphonic playing speed
15% increased symphonic critical strike chance
Increases maximum inspiration by 20
Percussion critical strikes will deal 10% more damage
Percussion critical strikes will briefly stun enemies
Your wind instrument attacks now attempt to quickly home in on enemies
If the attack already homes onto enemies, it does so far more quickly
String weapon projectiles bounce five additional times
Critical strikes caused by brass instrument attacks release a spread of energy");
            DisplayName.AddTranslation(GameCulture.Chinese, "吟游诗人之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你的每一个音符都孕育着一个新世界'
增加30%音波伤害
增加20%音波演奏速度
增加15%音波暴击率
增加20点最大灵感值
打击乐器会造成额外10%伤害
打击乐器暴击时会晕眩敌人
你的管乐器的攻击现在能快速跟踪敌人
如果它本来就能追踪敌人，那么弹道速度大幅加快
弦乐器额外弹射5次
暴击会让铜管类乐器的攻击外放一团能量");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 1000000;
            item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(230, 248, 34));
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded) Thorium(player);
        }

        private void Thorium(Player player)
        {
            //general
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.symphonicDamage += 0.3f;
            thoriumPlayer.symphonicSpeed += .2f;
            thoriumPlayer.symphonicCrit += 15;
            thoriumPlayer.bardResourceMax2 += 20;
            //epic mouthpiece
            thoriumPlayer.accWindHoming = true;
            thoriumPlayer.bardHomingBonus = 5f;
            //straight mute
            thoriumPlayer.accBrassMute2 = true;
            //digital tuner
            thoriumPlayer.accPercussionTuner2 = true;
            //guitar pick claw
            thoriumPlayer.bardBounceBonus = 5;
        }
        
        private readonly string[] _items =
        {
            "DigitalVibrationTuner",
            "EpicMouthpiece",
            "GuitarPickClaw",
            "StraightMute",
            "BandKit",
            "SteamFlute",
            "PrimeRoar",
            "EskimoBanjo",
            "Fishbone",
            "Accordion",
            "Ocarina",
            "TheMaw",
            "SonicAmplifier" 
        };
        
        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "BardEssence");

            foreach (string i in _items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
