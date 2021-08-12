using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Bronze;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Hero;
using ThoriumMod.Items.NPCItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class BronzeEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bronze Enchantment");
            Tooltip.SetDefault(
@"'You have the favor of Zeus'
Attacks have a chance to cause a lightning bolt to strike
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
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //lightning
            modPlayer.BronzeEnchant = true;
            //rebuttal
            thoriumPlayer.championShield = true;
            //sandles
            thorium.GetItem("SpartanSandles").UpdateAccessory(player, hideVisual);
            player.moveSpeed -= 0.15f;
            player.maxRunSpeed -= 1f;
            //olympic torch
            thoriumPlayer.olympicTorch = true;
           
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
