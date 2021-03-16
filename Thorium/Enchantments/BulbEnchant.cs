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
Your damage has a chance to poison hit enemies with a spore cloud
Effects of Bee Booties and Petal Shield, and Kick Petal");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //bulb set bonus
            modPlayer.BulbEnchant = true;
            //petal shield
            thorium.GetItem("PetalShield").UpdateAccessory(player, hideVisual);
            player.statDefense -= 2;
            //bee booties
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BeeBooties))
            {
                thorium.GetItem("BeeBoots").UpdateAccessory(player, hideVisual);
                player.moveSpeed -= 0.15f;
                player.maxRunSpeed -= 1f;
            }

            //kickpetal
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            //recipe.AddIngredient(ModContent.ItemType<BloomingCrown>());
            //recipe.AddIngredient(ModContent.ItemType<BloomingTabard>());
            //recipe.AddIngredient(ModContent.ItemType<BloomingLeggings>());
            recipe.AddIngredient(ModContent.ItemType<PetalShield>());
            recipe.AddIngredient(ModContent.ItemType<KickPetal>());
            recipe.AddIngredient(ModContent.ItemType<BeeBoots>());
            recipe.AddIngredient(ModContent.ItemType<BloomingBlade>());
            recipe.AddIngredient(ModContent.ItemType<BloomerBell>());
            recipe.AddIngredient(ModContent.ItemType<CreepingVineStaff>());
            recipe.AddIngredient(ModContent.ItemType<CactusFruit>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
