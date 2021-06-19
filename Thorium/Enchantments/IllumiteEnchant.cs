using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Illumite;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.MiniBoss;
using ThoriumMod.Items.Misc;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.MeleeItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class IllumiteEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Illumite Enchantment");
            Tooltip.SetDefault(
@"'As if you weren't pink enough'
Every third attack will unleash an illumite missile
Effects of Jazz Music Player");
            DisplayName.AddTranslation(GameCulture.Chinese, "荧光魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'好像还不够粉'
每三次攻击都会发射荧光火箭
拥有粉色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            modPlayer.IllumiteEnchant = true;
            //music player
            thoriumPlayer.accMusicPlayer = true;
            thoriumPlayer.accMP3Wind = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<IllumiteMask>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteChestplate>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteGreaves>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerLifeRegen>());
            recipe.AddIngredient(ModContent.ItemType<PinkPhasesaber>());
            recipe.AddIngredient(ModContent.ItemType<HandCannon>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteBlaster>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteBarrage>());
            recipe.AddIngredient(ModContent.ItemType<BlobhornCoralStaff>());
            recipe.AddIngredient(ModContent.ItemType<LargeOpal>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
