using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.QueenJelly;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class JesterEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Jester Enchantment");
            Tooltip.SetDefault(
@"'Clowning around'
Critical strikes ring a bell over your head, slowing all nearby enemies briefly
Effects of Fan Letter");
            DisplayName.AddTranslation(GameCulture.Chinese, "小丑魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'开个玩笑'
暴击时会奏响头顶的铃铛,微幅减速周围所有敌人
拥有粉丝的信函的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 60000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            modPlayer.JesterEnchant = true;
            //fan letter
            thoriumPlayer.bardResourceMax2 += 2;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyJesterMask");
            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyJesterShirt");
            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyJesterLeggings");
            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyLetter");
            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyTambourine");
            recipe.AddIngredient(ModContent.ItemType<Oboe>());
            recipe.AddIngredient(ModContent.ItemType<SkywareLute>());
            recipe.AddIngredient(ModContent.ItemType<Panflute>());
            recipe.AddIngredient(ModContent.ItemType<ConchShell>());
            recipe.AddIngredient(ModContent.ItemType<Alphorn>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
