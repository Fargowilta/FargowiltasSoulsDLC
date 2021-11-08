using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.SummonItems;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class LifeBloomEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Bloom Enchantment");
            Tooltip.SetDefault(
@"'You are one with nature'
Attacks have a 33% chance to heal you lightly
Summons a living wood sapling and its attacks will home in on enemies
Your healing spells increase the life recovery and life recovery rate of the healed target
Effects of Petal Shield, Kick Petal, Fragrant Corsage, and Heart of the Jungle");
            DisplayName.AddTranslation(GameCulture.Chinese, "树人魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'大自然的一员'
攻击有33%的概率治疗你
召唤具有追踪攻击能力的小树苗
拥有无暇之蛹和植物纤维绳索宝典的效果");
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
            modPlayer.LifeBloomEnchant = true;

            mod.GetItem("LivingWoodEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("BulbEnchant").UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.JungleHeart))
            {
                thorium.GetItem("HeartOfTheJungle").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LifeBloomMask>());
            recipe.AddIngredient(ModContent.ItemType<LifeBloomMail>());
            recipe.AddIngredient(ModContent.ItemType<LifeBloomLeggings>());
            recipe.AddIngredient(ModContent.ItemType<LivingWoodEnchant>());
            recipe.AddIngredient(ModContent.ItemType<BulbEnchant>());
            recipe.AddIngredient(ModContent.ItemType<HeartOfTheJungle>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
