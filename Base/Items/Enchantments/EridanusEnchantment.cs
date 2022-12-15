using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls.Items.Armor;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class EridanusEnchantment : BaseEnchant
    {
        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Eridanus Enchantment");
        }

        public override void SafeModifyTooltips(List<TooltipLine> tooltips)
        {
            base.SafeModifyTooltips(tooltips);

            Player player = Main.LocalPlayer;
            string tooltip = EridanusHat.getSetBonusString(player);
            string[] lines = tooltip.Split("\n");

            foreach (string line in lines)
            {
                TooltipLine tooltipLine = new TooltipLine(Mod, "tooltip", line);
                tooltips.Add(tooltipLine);
            }
        }

        protected override Color nameColor => Color.Purple;
        public override string wizardEffect => "";

        public override void SetDefaults()
        {
            base.SetDefaults();

            Item.rare = ItemRarityID.Purple;
            Item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            EridanusHat.EridanusSetBonus(player, Item);
        }

        public override void AddRecipes()
        {
            CreateRecipe()

            .AddIngredient(ModContent.ItemType<EridanusHat>())
            .AddIngredient(ModContent.ItemType<EridanusBattleplate>())
            .AddIngredient(ModContent.ItemType<EridanusLegwear>())

            .AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"))
            .Register();
        }
    }
}
