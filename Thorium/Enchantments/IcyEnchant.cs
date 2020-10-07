using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Icy;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class IcyEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Icy Enchantment");
            Tooltip.SetDefault(
@"'Cold to the touch'
An icy aura surrounds you, which freezes nearby enemies after a short delay");

            DisplayName.AddTranslation(GameCulture.Chinese, "碎冰魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'触感冰凉'
环绕的冰锥将冰冻敌人
拥有霜火粉袋的效果");
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
            thoriumPlayer.icySet = true;
            if (player.ownedProjectileCounts[thorium.ProjectileType("IcyAura")] < 1)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("IcyAura"), 0, 0f, player.whoAmI, 0f, 0f);
            }
        }
        
        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<IcyBandana>());
            recipe.AddIngredient(ModContent.ItemType<IcyMail>());
            recipe.AddIngredient(ModContent.ItemType<IcyGreaves>());
            recipe.AddIngredient(ModContent.ItemType<FrostFireKatana>());
            recipe.AddIngredient(ModContent.ItemType<IceShard>());
            recipe.AddIngredient(ModContent.ItemType<FrostFury>());
            recipe.AddIngredient(ModContent.ItemType<Blizzard>());
            recipe.AddIngredient(ModContent.ItemType<IcyCaltrop>(), 300);
            recipe.AddIngredient(ModContent.ItemType<IceShaver>());
            recipe.AddIngredient(ItemID.IceBoomerang);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
