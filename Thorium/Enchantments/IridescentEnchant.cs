using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class IridescentEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Iridescent Enchantment");
            Tooltip.SetDefault(
@"'All the colors of the rainbow'
Your radiant damage has a 15% chance to release a blinding flash of light
The flash heals nearby allies equal to your bonus healing and confuses enemies
Effects of Equalizer");
            DisplayName.AddTranslation(GameCulture.Chinese, "光辉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'五颜六色'
你的光辉伤害有15%几率释放光之火
治疗周围友军量等于你的额外治疗量并令敌人混乱
拥有平等护符的效果");
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

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            thoriumPlayer.iridescentSet = true;
            //equalizer 
            thoriumPlayer.equilibrium = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<IridescentHelmet>());
            recipe.AddIngredient(ModContent.ItemType<IridescentMail>());
            recipe.AddIngredient(ModContent.ItemType<IridescentGreaves>());
            recipe.AddIngredient(ModContent.ItemType<Equalizer>());
            recipe.AddIngredient(ModContent.ItemType<HereticBreaker>());
            recipe.AddIngredient(ModContent.ItemType<SpiritPouch>());
            recipe.AddIngredient(ModContent.ItemType<TranquilLyre>());
            recipe.AddIngredient(ModContent.ItemType<IridescentStaff>());
            recipe.AddIngredient(ModContent.ItemType<SerpentsBubbleWand>());
            recipe.AddIngredient(ModContent.ItemType<Recuperate>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
