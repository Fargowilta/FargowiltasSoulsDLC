using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class CelestialEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Celestial Enchantment");
            Tooltip.SetDefault(
@"'Harmonious energy embraces you'
Pressing the 'Special Ability' key will summon an incredibly powerful aura around your cursor
Creating this aura costs 150 mana
Effects of Ascension Statuette");
            DisplayName.AddTranslation(GameCulture.Chinese, "大天使魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'谐能环绕着你'
按下'套装技能'键'会在鼠标位置召唤一个极为强大的光环
消耗150魔力值
拥有飞升雕像的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.celestialSet = true;
            //ascension statue
            thoriumPlayer.ascension = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<CelestialCrown>());
            recipe.AddIngredient(ModContent.ItemType<CelestialVestment>());
            recipe.AddIngredient(ModContent.ItemType<CelestialLeggings>());
            recipe.AddIngredient(ModContent.ItemType<CelestialTrinity>());
            recipe.AddIngredient(ModContent.ItemType<AscensionStatuette>());
            recipe.AddIngredient(ModContent.ItemType<HealingRain>());
            recipe.AddIngredient(ModContent.ItemType<AncientTome>());
            recipe.AddIngredient(ModContent.ItemType<Buisine>());
            recipe.AddIngredient(ModContent.ItemType<BlackScythe>());
            recipe.AddIngredient(ModContent.ItemType<DivineStaff>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
