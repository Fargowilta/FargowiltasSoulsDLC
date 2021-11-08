using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Bronze;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Hero;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class BronzeEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Enchantment");
            Tooltip.SetDefault(
@"'You have the favor of Zeus'
Attacks have a 20% chance to unleash a piercing lightning strike
Effects of Olympic Torch, Champion's Rebuttal, and Spartan Sandals");
            DisplayName.AddTranslation(GameCulture.Chinese, "青铜魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'宙斯的青睐'
攻击有概率释放闪电链
拥有奥林匹克圣火, 反击之盾, 斯巴达凉鞋和斯巴达音箱的效果");
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
            //lightning
            modPlayer.BronzeEnchant = true;

            thorium.GetItem("ChampionsBarrier").UpdateAccessory(player, hideVisual);
            thorium.GetItem("SpartanSandles").UpdateAccessory(player, hideVisual);
            thorium.GetItem("OlympicTorch").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BronzeHelmet>());
            recipe.AddIngredient(ModContent.ItemType<BronzeBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<BronzeGreaves>());
            recipe.AddIngredient(ModContent.ItemType<OlympicTorch>());
            recipe.AddIngredient(ModContent.ItemType<ChampionsBarrier>());
            recipe.AddIngredient(ModContent.ItemType<SpartanSandles>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
