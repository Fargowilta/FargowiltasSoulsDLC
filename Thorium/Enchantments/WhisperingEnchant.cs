using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Abyssion;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class WhisperingEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Whispering Enchantment");
            Tooltip.SetDefault(
@"'Now R'lyeh on the old god's power'
You occasionally birth a tentacle of abyssal energy that attacks nearby enemies
You can have up to six tentacles and their damage saps 1 life & mana from the hit enemy");
            DisplayName.AddTranslation(GameCulture.Chinese, "黑暗低语者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
偶尔在地面产生深渊能量触手攻击附近的敌人
最多产生6根触手, 触手的攻击将会为你偷取1点生命值和法力");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WhisperingTentacles))
            {
                thoriumPlayer.whisperingSet = true;
                if (player.ownedProjectileCounts[thorium.ProjectileType("WhisperingTentacle")] + player.ownedProjectileCounts[thorium.ProjectileType("WhisperingTentacle2")] < 6 && player.ownedProjectileCounts[thorium.ProjectileType("WhisperingTentacleSpawn")] < 1)
                {
                    timer++;
                    if (timer > 30)
                    {
                        Projectile.NewProjectile(player.Center.X + (float)Main.rand.Next(-300, 300), player.Center.Y, 0f, 0f, thorium.ProjectileType("WhisperingTentacleSpawn"), 50, 0f, player.whoAmI, 0f, 0f);
                        timer = 0;
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<WhisperingHood>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingTabard>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingLeggings>());

            recipe.AddIngredient(ModContent.ItemType<WildUmbra>());
            recipe.AddIngredient(ModContent.ItemType<MindMelter>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingDagger>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
