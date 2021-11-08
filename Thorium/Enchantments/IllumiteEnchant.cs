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
using ThoriumMod.Items.Donate;

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
Effects of The Nuclear Option and Jazz Music Player");
            DisplayName.AddTranslation(GameCulture.Chinese, "荧光魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'好像还不够粉'
每3次攻击会发射荧光导弹
拥有粉色播放器的效果
召唤宠物粉红史莱姆");
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
            modPlayer.IllumiteEnchant = true;

            thorium.GetItem("TheNuclearOption").UpdateAccessory(player, true);
            thorium.GetItem("TunePlayerLifeRegen").UpdateAccessory(player, true);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<IllumiteMask>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteChestplate>());
            recipe.AddIngredient(ModContent.ItemType<IllumiteGreaves>());
            recipe.AddIngredient(ModContent.ItemType<TheNuclearOption>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerLifeRegen>());
            recipe.AddIngredient(ModContent.ItemType<HandCannon>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
