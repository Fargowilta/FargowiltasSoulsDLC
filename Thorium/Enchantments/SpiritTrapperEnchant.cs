using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.SummonItems;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.DD;
using ThoriumMod.Items.Misc;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class SpiritTrapperEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spirit Trapper Enchantment");
            Tooltip.SetDefault(
@"'So many lost souls...'
Killing enemies or continually damaging bosses generates soul wisps
After generating 5 wisps, they are instantly consumed to heal you for 10 life
Effects of Inner Flame");
            DisplayName.AddTranslation(GameCulture.Chinese, "猎魂者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'这么多失落的灵魂...'
杀死敌人或持续攻击Boss会产生灵魂碎片
集齐5个后,它们会立即被消耗,治疗10点生命
拥有心灵之火效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            thoriumPlayer.setSpiritTrapper = true;
            modPlayer.SpiritTrapperEnchant = true;
            //inner flame
            thoriumPlayer.spiritFlame = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<SpiritTrapperHelmet>());
            recipe.AddIngredient(ModContent.ItemType<SpiritTrapperCuirass>());
            recipe.AddIngredient(ModContent.ItemType<SpiritTrapperGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SpiritFlame>());
            recipe.AddIngredient(ModContent.ItemType<TabooWand>());
            recipe.AddIngredient(ModContent.ItemType<SpiritBlastWand>());
            recipe.AddIngredient(ModContent.ItemType<CalmingSpirit>());
            recipe.AddIngredient(ModContent.ItemType<AntagonizingSpirit>());
            recipe.AddIngredient(ModContent.ItemType<HagTotemCaller>());
            recipe.AddIngredient(ModContent.ItemType<LoudFootstepsPaint>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
