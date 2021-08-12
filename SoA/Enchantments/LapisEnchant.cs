using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class LapisEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lapis Enchantment");
            Tooltip.SetDefault(
@"'Gotta go fast'
20% increased movement speed
Effects of Lapis Pendant");

            DisplayName.AddTranslation(GameCulture.Chinese, "青金魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'Gotta go fast'
增加20%移动速度
拥有青金石挂饰的效果
召唤宠物Nicky和嗡嗡甲虫");
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
                    tooltipLine.overrideColor = new Color(46, 66, 163);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            player.moveSpeed += 0.2f;

            //lapis pendant
            modPlayer.LapisPendant = true;

        }

        private readonly string[] items =
        {
            "LapisHelmet",
            "LapisChest",
            "LapisLegs",
            "LapisPendant",

            "LapisStaff",
            //"LapisBow",
            //"LapisJavelin",
            "Haven",
            //"LapisPick"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
