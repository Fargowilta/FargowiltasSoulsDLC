using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.Thorium.Essences
{
    public class BardEssence : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Musician's Essence");
            Tooltip.SetDefault(
@"18% increased symphonic damage
5% increased symphonic playing speed
5% increased symphonic critical strike chance
'This is only the beginning..'");
            DisplayName.AddTranslation(GameCulture.Chinese, "音乐家精华");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''这才刚刚开始..''
增加18%音波伤害
增加5%音波演奏速度
增加5%音波暴击率");
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

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 4;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            BardEffect(player);
        }
        
        private void BardEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.symphonicDamage += 0.18f;
            thoriumPlayer.symphonicSpeed += .05f;
            thoriumPlayer.symphonicCrit += 5;
        }
        
        private readonly string[] items =
        {
            "BardEmblem",
            "AntlionMaraca",
            "SeashellCastanettes",
            "Didgeridoo",
            "Bagpipe",
            "Lute",
            "ForestOcarina",
            "AquamarineWineGlass",
            "SonarCannon",
            "Calaveras",
            "GraniteBoomBox",
            "TuningFork",
            "HotHorn",
            "SongFireAndIce"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
