using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Armor;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class StyxEnchantment : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Styx Enchantment");
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);

            string tooltip = StyxCrown.getSetBonusString();
            string[] lines = tooltip.Split("\n");

            foreach (string line in lines)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "tooltip", line);
                tooltips.Add(tooltipLine);
            }
        }

        protected override Color nameColor => Color.Orange;
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Purple;
            Item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            StyxCrown.StyxSetBonus(player, Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<StyxCrown>())
            .AddIngredient(ModContent.ItemType<StyxChestplate>())
            .AddIngredient(ModContent.ItemType<StyxLeggings>())

            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
            .Register();
        }
    }
}
