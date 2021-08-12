using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class BlazingBruteEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blazing Brute Enchantment");
            Tooltip.SetDefault(
@"'Your spirit ignites like the brightest flame. Soon, your enemies will too'
Standing still for 5 seconds charges a shield that increases damage reduction by 25% per level (max of 4) 
Getting hit or moving resets the counter");
            DisplayName.AddTranslation(GameCulture.Chinese, "赤炎魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你的灵魂燃烧如炽火. 很快, 你的敌人也将如此'
站立不动5秒将会蓄能一层护盾, 每一层增加25%伤害减免(上限4层)
被攻击或移动后重置");
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
                    tooltipLine.overrideColor = new Color(249, 75, 7);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.SolariusArmor = true;
        }

        private readonly string[] items =
        {
            "BlazingBruteHelm",
            "BlazingBrutePlate",
            "BlazingBruteLegs",
            "Nyanmere",
            "StarShower",
            "AsteroidShower",
            //"OblivionSpear",
            //"FlareFlail",
            //"AsthralBlade",
            //"Phaselash"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
