using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.ThrownItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class YewWoodEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Yew Wood Enchantment");
            Tooltip.SetDefault(
@"'This strange wood comes from a far away land'
After four consecutive non-critical strikes, your next attack will mini-crit for 150% damage
Effects of Goblin War Shield");
            DisplayName.AddTranslation(GameCulture.Chinese, "紫杉木魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'这种奇怪的木头来自遥远的大陆'
连续4次攻击不暴击时, 下一次攻击造成150%伤害
拥有哥布林战盾的效果");
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
            //yew set bonus
            modPlayer.YewEnchant = true;
            //goblin war shield
            thorium.GetItem("GoblinWarshield").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<YewWoodaHelmet>());
            recipe.AddIngredient(ModContent.ItemType<YewWoodBreastgaurd>());
            recipe.AddIngredient(ModContent.ItemType<YewWoodLeggings>());
            recipe.AddIngredient(ModContent.ItemType<GoblinWarshield>());
            recipe.AddIngredient(ModContent.ItemType<FeatherFoe>());
            recipe.AddIngredient(ModContent.ItemType<YewWoodBow>());
            recipe.AddIngredient(ModContent.ItemType<YewWoodBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<YewGun>());
            recipe.AddIngredient(ModContent.ItemType<ShadowflameWand>());
            recipe.AddIngredient(ModContent.ItemType<SpikeBomb>(), 300);
            
            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
