using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.SummonItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class BulbEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blooming Enchantment");
            Tooltip.SetDefault(
@"'Has a surprisingly sweet aroma'
Your healing spells increase the life recovery and life recovery rate of the healed target
Effects of Petal Shield, Kick Petal, and Fragrant Corsage");
            DisplayName.AddTranslation(GameCulture.Chinese, "花瓣魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'香气逼人'
攻击有概率召唤使敌人中毒的毒孢子云
拥有影缀花和花之盾的效果");
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

            string oldSetBonus = player.setBonus;
            thorium.GetItem("BloomingCrown").UpdateArmorSet(player);
            player.setBonus = oldSetBonus;

            thorium.GetItem("PetalShield").UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.KickPetal))
            {
                thorium.GetItem("KickPetal").UpdateAccessory(player, hideVisual);
            }

            thorium.GetItem("FragrantCorsage").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BloomingCrown>());
            recipe.AddIngredient(ModContent.ItemType<BloomingTabard>());
            recipe.AddIngredient(ModContent.ItemType<BloomingLeggings>());
            recipe.AddIngredient(ModContent.ItemType<PetalShield>());
            recipe.AddIngredient(ModContent.ItemType<FragrantCorsage>());
            recipe.AddIngredient(ModContent.ItemType<KickPetal>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
