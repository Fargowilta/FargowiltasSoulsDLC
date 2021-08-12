using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Geode;
using ThoriumMod.Items.Lodestone;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.Misc;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class WhiteDwarfEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Dwarf Enchantment");
            Tooltip.SetDefault(
@"'Throw with the force of nuclear fusion'
Critical strikes will unleash ivory flares from the cosmos
Ivory flares deal 0.1% of the hit target's maximum life as damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "白矮星魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'以核聚变的伟力抛出'
暴击将释放宇宙星光
宇宙星光造成敌人生命上限0.5%的伤害");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 300000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            player.GetModPlayer<FargoDLCPlayer>().WhiteDwarfEnchant = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfMask>());
            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfGuard>());
            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfGreaves>());
            recipe.AddIngredient(ModContent.ItemType<BlackHammer>());
            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfPickaxe>());
            recipe.AddIngredient(ModContent.ItemType<AngelsEnd>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
