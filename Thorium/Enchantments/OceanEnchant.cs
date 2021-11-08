using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Ocean;
using ThoriumMod.Items.QueenJelly;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class OceanEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Coral Enchantment");
            Tooltip.SetDefault(
@"'For swimming with the fishes'
Radiant damage builds up to 20 life shield and life shielding no longer decays on you. Healing an ally transfers the life shield to them
Effects of Sea Breeze Pendant and Bubble Magnet");
            DisplayName.AddTranslation(GameCulture.Chinese, "海洋魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'与鱼同游'
获得水下呼吸能力
获得游泳能力
拥有海洋通行证和泡泡磁铁的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            string oldSetBonus = player.setBonus;
            thorium.GetItem("OceanHelmet").UpdateArmorSet(player);
            player.setBonus = oldSetBonus;

            thorium.GetItem("SeaBreezePendant").UpdateAccessory(player, hideVisual);
            thorium.GetItem("BubbleMagnet").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<OceanHelmet>());
            recipe.AddIngredient(ModContent.ItemType<OceanChestGuard>());
            recipe.AddIngredient(ModContent.ItemType<OceanGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SeaBreezePendant>());
            recipe.AddIngredient(ModContent.ItemType<BubbleMagnet>());
            recipe.AddIngredient(ItemID.Swordfish);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
