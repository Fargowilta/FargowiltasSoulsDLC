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
暴击时在头顶鸣铃, 减缓周围敌人的速度
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
            modPlayer.JesterEnchant = true;

            thorium.GetItem("FanLetter").UpdateAccessory(player, hideVisual);
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
            recipe.AddIngredient(ModContent.ItemType<SkywareLute>());
 
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
