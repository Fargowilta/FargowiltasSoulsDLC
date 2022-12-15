using FargowiltasSouls.Items.Accessories.Enchantments;
using FargowiltasSouls;
using FargowiltasSouls.Items.Accessories.Forces;
using FargowiltasSouls.Items.Materials;
using Terraria.ModLoader;
using Terraria;

namespace FargowiltasSoulsDLC.Base.Items.Enchantments
{
    public class EternityForce : BaseForce
    {
        public static int[] Enchants => new int[]
        {
            ModContent.ItemType<NekomiEnchantment>(),
            ModContent.ItemType<GaiaEnchantment>(),
            ModContent.ItemType<EridanusEnchantment>(),
            ModContent.ItemType<StyxEnchantment>(),
            ModContent.ItemType<TrueMutantEnchantment>()
        };

        public override void SetStaticDefaults()
        {
            base.SetStaticDefaults();

            DisplayName.SetDefault("Force of Eternity");

            string tooltip =
$"[i:{ModContent.ItemType<NekomiEnchantment>()}] [i:{ModContent.ItemType<GaiaEnchantment>()}] [i:{ModContent.ItemType<EridanusEnchantment>()}] [i:{ModContent.ItemType<StyxEnchantment>()}] [i:{ModContent.ItemType<TrueMutantEnchantment>()}] \n" +
$"Grants all effects of material Enchantments\n" +
"'0.00001% of the Lumberjack's power'";
            Tooltip.SetDefault(tooltip);

        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            ModContent.GetModItem(ModContent.ItemType<NekomiEnchantment>()).UpdateAccessory(player, hideVisual);
            ModContent.GetModItem(ModContent.ItemType<GaiaEnchantment>()).UpdateAccessory(player, hideVisual);
            ModContent.GetModItem(ModContent.ItemType<EridanusEnchantment>()).UpdateAccessory(player, hideVisual);
            ModContent.GetModItem(ModContent.ItemType<StyxEnchantment>()).UpdateAccessory(player, hideVisual);
            ModContent.GetModItem(ModContent.ItemType<TrueMutantEnchantment>()).UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            Recipe recipe = CreateRecipe();
            foreach (int ench in Enchants)
                recipe.AddIngredient(ench);

            recipe.AddTile(ModContent.Find<ModTile>("Fargowiltas", "CrucibleCosmosSheet"));
            recipe.Register();
        }
    }
}
