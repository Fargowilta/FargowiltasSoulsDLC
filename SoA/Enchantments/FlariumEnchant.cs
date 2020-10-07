using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class FlariumEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flarium Enchantment");
            Tooltip.SetDefault(
@"'Raze your enemies with Araghur's flames'
Taking fatal damage will revive you with 1/3rd of your max health
You will have one minute of increased strength after rebirth
5 minute cooldown");
            DisplayName.AddTranslation(GameCulture.Chinese, "熔火魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'用阿拉古尔之焰焚尽你的敌人'
受到致命伤害时回复1/3血量
重生后1分钟内获得强化
5分钟冷却
召唤赤炎阿拉胡尔和熔火光环");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 350000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(204, 78, 40);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.DragonSetEffect = true;

            //pets soon tm
        }

        private readonly string[] items =
        {
            "FlariumChest",
            "FlariumLeggings",
            "FlariumStaff",
            "FlariumRocketLauncher",
            "FlariumJavelin",
            "SolusKatana",
            "SunSigil",
            "FlariumEarring",
            "SerpentSceptre",
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyFlariumHelmet");

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
