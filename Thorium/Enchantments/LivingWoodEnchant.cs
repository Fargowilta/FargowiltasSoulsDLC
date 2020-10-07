using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.SummonItems;
using ThoriumMod.Items.Consumable;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class LivingWoodEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Living Wood Enchantment");
            Tooltip.SetDefault(
@"'Become one with nature'
Summons a living wood sapling and its attacks will home in on enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "生命木魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'与自然融为一体'
召唤具有追踪攻击能力的小树苗
拥有植物纤维绳索宝典的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            thoriumPlayer.livingWood = true;
            //free boi
            modPlayer.LivingWoodEnchant = true;
            modPlayer.AddMinion(SoulConfig.Instance.thoriumToggles.SaplingMinion, thorium.ProjectileType("MinionSapling"), 10, 2f);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LivingWoodMask>());
            recipe.AddIngredient(ModContent.ItemType<LivingWoodChestguard>());
            recipe.AddIngredient(ModContent.ItemType<LivingWoodBoots>());
            recipe.AddIngredient(ModContent.ItemType<LivingWoodSprout>());
            recipe.AddIngredient(ItemID.SlimeStaff);
            recipe.AddIngredient(ModContent.ItemType<AntlionStaff>());
            recipe.AddIngredient(ItemID.LeafWand);
            recipe.AddIngredient(ModContent.ItemType<ChiTea>(), 5);
            recipe.AddIngredient(ItemID.JuliaButterfly);
            recipe.AddIngredient(ItemID.Grasshopper);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
