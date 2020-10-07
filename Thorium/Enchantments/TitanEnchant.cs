using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Titan;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Abyssion;
using ThoriumMod.Items.Lich;
using ThoriumMod.Items.RangedItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class TitanEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Titan Enchantment");
            Tooltip.SetDefault(
@"'Infused with primordial energy'
15% increased damage
Effects of Mask of the Crystal Eye, Abyssal Shell, and Rock Music Player");
            DisplayName.AddTranslation(GameCulture.Chinese, "泰坦魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'充溢着原始能量'
增加15%伤害
拥有水晶之眼, 深渊贝壳和青色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            player.GetModPlayer<FargoDLCPlayer>().AllDamageUp(.15f);
            //crystal eye mask
            thoriumPlayer.critDamage += 0.1f;
            //abyssal shell
            thoriumPlayer.AbyssalShell = true;
            //music player
            thoriumPlayer.accMusicPlayer = true;
            thoriumPlayer.accMP3String = true;

           // spiritband

        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyTitanHelmet");
            recipe.AddIngredient(ModContent.ItemType<TitanBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<TitanGreaves>());
            recipe.AddIngredient(ModContent.ItemType<CrystalEyeMask>());
            recipe.AddIngredient(ModContent.ItemType<AbyssalShell>());
            recipe.AddIngredient(ModContent.ItemType<SpiritBand>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerDamageReduction>());
            recipe.AddIngredient(ModContent.ItemType<TitanBoomerang>());
            recipe.AddIngredient(ModContent.ItemType<TranquilizerGun>());
            recipe.AddIngredient(ModContent.ItemType<TetherDart>(), 300);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
