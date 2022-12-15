using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Armor;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class GaiaEnchantment : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Gaia Enchantment");
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);

            string tooltip = GaiaHelmet.getSetBonusString();
            string[] lines = tooltip.Split("\n");

            foreach (string line in lines)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "tooltip", line);
                tooltips.Add(tooltipLine);
            }
        }

        protected override Color nameColor => Color.Green;
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Yellow;
            Item.value = 100000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            GaiaHelmet.GaiaSetBonus(player);
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<GaiaHelmet>())
            .AddIngredient(ModContent.ItemType<GaiaPlate>())
            .AddIngredient(ModContent.ItemType<GaiaGreaves>())

            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
            .Register();
        }
    }
}
