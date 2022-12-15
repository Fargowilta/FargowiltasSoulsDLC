using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Armor;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class NekomiEnchantment : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Nekomi Enchantment");
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);

            string tooltip = NekomiHood.getSetBonusString();
            string[] lines = tooltip.Split("\n");

            foreach (string line in lines)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "tooltip", line);
                tooltips.Add(tooltipLine);
            }
        }

        protected override Color nameColor => Color.Pink;
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.LightRed;
            Item.value = 50000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            NekomiHood.NekomiSetBonus(player, Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<NekomiHood>())
            .AddIngredient(ModContent.ItemType<NekomiHoodie>())
            .AddIngredient(ModContent.ItemType<NekomiLeggings>())

            .AddTile(TileID.CrystalBall)
            .Register();
        }
    }
}
