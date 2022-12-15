using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Armor;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class TrueMutantEnchantment : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("True Mutant Enchantment");
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);

            string tooltip = MutantMask.getSetBonusString();
            string[] lines = tooltip.Split("\n");

            foreach (string line in lines)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "tooltip", line);
                tooltips.Add(tooltipLine);
            }
        }

        protected override Color nameColor => new Color(Main.DiscoR, 51, 255 - (int)(Main.DiscoR * 0.4));
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Purple;
            Item.value = 500000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            MutantMask.MutantSetBonus(player, Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<MutantMask>())
            .AddIngredient(ModContent.ItemType<MutantBody>())
            .AddIngredient(ModContent.ItemType<MutantPants>())

            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
            .Register();
        }
    }
}
