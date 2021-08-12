using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class BismuthEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bismuth Enchantment");
            Tooltip.SetDefault(
@"'It takes every color to make a rainbow'
Hitting enemies has a chance to summon a bismuth hammer for extra damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "铋魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'五颜六色汇成彩虹'
攻击敌人概率召唤一柄铋锤造成额外伤害");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 100000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(184, 66, 66);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.bismuthArmor = true;
        }

        private readonly string[] items =
        {
            "BismuthHelm",
            "BismuthChest",
            "BismuthLegs",
            //"BismuthChakram",
           // "RainbowHandgun",
           // "TheCluster",
            "DeathsGarden",
            "VenomiteStaff",
            "GospelOfDismay"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            //recipe.AddIngredient(ItemID.RainbowRod);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
