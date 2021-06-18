using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Sandstone;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.ThunderBird;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class SandstoneEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstone Enchantment");
            Tooltip.SetDefault(
@"'Enveloped by desert winds'
Desert winds will augment your boots, giving you a double jump");
            DisplayName.AddTranslation(GameCulture.Chinese, "砂石魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'沙暴环绕'
沙尘暴的力量被注入你的双脚，获得2段跳的能力");
            //Thrown attacks might refresh your jump
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

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            player.doubleJumpSandstorm = true;
            if (Main.rand.Next(25) == 0)
            {
                Projectile.NewProjectile(player.Center.X - 4f, player.Center.Y, 0f, 0f, thorium.ProjectileType("SandstoneEffect"), 0, 0f, Main.myPlayer, 0f, 0f);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<hSandStoneHelmet>());
            recipe.AddIngredient(ModContent.ItemType<iSandStoneMail>());
            recipe.AddIngredient(ModContent.ItemType<jSandStoneGreaves>());
            recipe.AddIngredient(ModContent.ItemType<Wreath>());
            recipe.AddIngredient(ModContent.ItemType<BaseballBat>());
            recipe.AddIngredient(ModContent.ItemType<StoneThrowingSpear>(), 300);
            recipe.AddIngredient(ModContent.ItemType<gSandStoneThrowingKnife>(), 300);
            recipe.AddIngredient(ModContent.ItemType<TalonBurst>());
            recipe.AddIngredient(ModContent.ItemType<ThunderOverDesertSkiesPaint>());
            recipe.AddIngredient(ItemID.BlackScorpion);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
