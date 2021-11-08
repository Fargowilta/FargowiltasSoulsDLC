using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Granite;
using ThoriumMod.Items.EnergyStorm;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Painting;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class GraniteEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Granite Enchantment");
            Tooltip.SetDefault(
@"'Defensively energized'
Immune to intense heat and enemy knockback, but your movement speed is slowed down greatly
Effects of Heart of Stone");
            DisplayName.AddTranslation(GameCulture.Chinese, "花岗岩魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'防御激增'
免疫火块灼烧和击退，但大幅度降低移动速度
拥有风暴之眼和充能音箱的效果");
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

            //set bonus
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[24] = true;
            player.noKnockback = true;

            if (!player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul)
            {
                player.moveSpeed -= 0.5f;
                player.maxRunSpeed = 4f;
            }
           
            //if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.EyeoftheStorm))
            //{
                thorium.GetItem("HeartOfStone").UpdateAccessory(player, hideVisual);
            //}
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<GraniteHelmet>());
            recipe.AddIngredient(ModContent.ItemType<GraniteChestGuard>());
            recipe.AddIngredient(ModContent.ItemType<GraniteGreaves>());
            recipe.AddIngredient(ModContent.ItemType<HeartOfStone>());
            recipe.AddIngredient(ModContent.ItemType<ShockAbsorber>());
            recipe.AddIngredient(ModContent.ItemType<ObsidianStriker>(), 300);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
