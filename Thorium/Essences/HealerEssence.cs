using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace FargowiltasSoulsDLC.Thorium.Essences
{
    public class HealerEssence : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Crusader's Essence");
            Tooltip.SetDefault(
@"18% increased radiant damage
5% increased healing and radiant casting speed
5% increased radiant critical strike chance
'This is only the beginning..'");
            DisplayName.AddTranslation(GameCulture.Chinese, "十字军精华");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''这才刚刚开始..''
增加18%光辉伤害
增加5%治疗和光辉施法速度
增加5%光辉暴击率");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 30, 247));
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
            
            HealEffect(player);
        }
        
        private void HealEffect(Player player)
        {
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.radiantBoost += 0.18f;
            thoriumPlayer.radiantSpeed -= 0.05f;
            thoriumPlayer.healingSpeed += 0.05f;
            thoriumPlayer.radiantCrit += 5;
        }
        
        private readonly string[] items =
        {
            "ClericEmblem",
            "GoodBook",
            "HeartWand",
            "FeatherBarrierRod",
            "TulipStaff",
            "LargePopcorn",
            "DarkMageStaff",
            "BatScythe",
            "DivineLotus",
            "SentinelWand",
            "LifeDisperser",
            "RedeemerStaff",
            "DeepStaff",
            "StarRod"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);
            
            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
