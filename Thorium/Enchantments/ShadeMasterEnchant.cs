using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.ThrownItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class ShadeMasterEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        private readonly Mod fargos = ModLoader.GetMod("FargowiltasSoulsDLC");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Shade Master Enchantment");
            Tooltip.SetDefault(
@"'Live in the shadows, and strike with precision'
50% of the damage you take is staggered over the next 10 seconds");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗影大师魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'匿于阴影, 致命一击'
所受伤害的50%将被分摊到接下来的10秒内
扔烟雾弹进行传送,获得先发制人Buff
召唤宠物黑猫");
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

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            thoriumPlayer.shadeSet = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<ShadeMasterMask>());
            recipe.AddIngredient(ModContent.ItemType<ShadeMasterGarb>());
            recipe.AddIngredient(ModContent.ItemType<ShadeMasterTreads>());
            recipe.AddIngredient(ModContent.ItemType<ClockWorkBomb>(), 300);
            //recipe.AddIngredient(ModContent.ItemType<KrakenThrown>());
            recipe.AddIngredient(ModContent.ItemType<BugenkaiShuriken>(), 300);
            recipe.AddIngredient(ModContent.ItemType<ShadeKunai>(), 300);
            recipe.AddIngredient(ModContent.ItemType<Soulslasher>(), 300);
            recipe.AddIngredient(ModContent.ItemType<LihzahrdKukri>(), 300);
            recipe.AddIngredient(ModContent.ItemType<TechniqueShadowDance>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
