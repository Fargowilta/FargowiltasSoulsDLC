using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.EarlyMagic;
using ThoriumMod.Items.BasicAccessories;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class SilkEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silk Enchantment");
            Tooltip.SetDefault(
@"'You feel silky-smooth'
+12% magic damage while above 90% maximum mana
Effects of Artificer's Focus, Artificer's Shield, and Artificer's Rocketeers");
            DisplayName.AddTranslation(GameCulture.Chinese, "丝绸魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'丝般光滑'
增加6%魔法伤害");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 0;
            item.value = 20000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            string oldSetBonus = player.setBonus;
            thorium.GetItem("SilkHat").UpdateArmorSet(player);
            player.setBonus = oldSetBonus;

            thorium.GetItem("ArtificersFocus").UpdateAccessory(player, hideVisual);
            thorium.GetItem("EnchantedShield").UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.ManaBoots))
            {
                thorium.GetItem("ManaChargedRocketeers").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<SilkHat>());
            recipe.AddIngredient(ModContent.ItemType<SilkTabard>());
            recipe.AddIngredient(ModContent.ItemType<SilkLeggings>());
            recipe.AddIngredient(ModContent.ItemType<ArtificersFocus>());
            recipe.AddIngredient(ModContent.ItemType<EnchantedShield>());
            recipe.AddIngredient(ModContent.ItemType<ManaChargedRocketeers>());
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
