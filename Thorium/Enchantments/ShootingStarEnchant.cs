using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Tracker;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class ShootingStarEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shooting Star Enchantment");
            Tooltip.SetDefault(
@"'Echoes of the cosmic ballad dance in your head'
Each unique empowerment you have grants you:
5% increased symphonic damage,
2% increased movement speed,
2% increased inspiration regeneration,
1% increased playing speed");
            DisplayName.AddTranslation(GameCulture.Chinese, "民谣歌手魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'宇宙谣曲在你脑海中回响'
每拥有一种咒音, 获得以下增益:
增加8%音波伤害
增加3%移动速度
增加2%灵感回复
增加1%演奏速度");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //dmg, regen
            thoriumPlayer.setBalladeer = true;
            //move speed, play speed
            thoriumPlayer.accHeadset = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BalladeerHat>());
            recipe.AddIngredient(ModContent.ItemType<BalladeerShirt>());
            recipe.AddIngredient(ModContent.ItemType<BalladeerBoots>());
            recipe.AddIngredient(ModContent.ItemType<Headset>());
            recipe.AddIngredient(ModContent.ItemType<Acoustic>());
            recipe.AddIngredient(ModContent.ItemType<SunflareGuitar>());

            
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
