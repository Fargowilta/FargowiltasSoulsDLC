using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class PrairieEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Prairie Enchantment");
            Tooltip.SetDefault(
@"'Subdued Serenity'
5% increased ranged damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "草原魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'柔和宁静'
增加40%投掷物速度
增加5%投掷和远程伤害");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 50000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(129, 19, 29);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            player.rangedDamage += 0.05f;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(soa.ItemType("PrairieHelmet"));
            recipe.AddIngredient(soa.ItemType("PrairieChest"));
            recipe.AddIngredient(soa.ItemType("PrairieLegs"));
            recipe.AddIngredient(soa.ItemType("AncientCharm"));
            recipe.AddIngredient(soa.ItemType("WoodJavelin"), 300);
            recipe.AddIngredient(ItemID.RottenEgg, 300);
            recipe.AddIngredient(soa.ItemType("GoldJavelin"), 300);
            recipe.AddIngredient(ItemID.EnchantedBoomerang);
            recipe.AddIngredient(ItemID.PoisonedKnife, 300);
            recipe.AddIngredient(ItemID.BallOHurt);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
