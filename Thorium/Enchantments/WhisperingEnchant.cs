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
            DisplayName.AddTranslation(GameCulture.Chinese, "低语者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
你有时会释放由深渊能量凝聚的触手攻击周围敌人
最多6条触手,触手的每一次抽击都会回复你1点生命值和1点魔力值");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

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

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<WhisperingHood>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingTabard>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingLeggings>());
            recipe.AddIngredient(ModContent.ItemType<RottenCod>());
            recipe.AddIngredient(ModContent.ItemType<TheStalker>());
            recipe.AddIngredient(ModContent.ItemType<SamsaraLotus>());
            recipe.AddIngredient(ModContent.ItemType<WildUmbra>());
            recipe.AddIngredient(ModContent.ItemType<MindMelter>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingDagger>());
            recipe.AddIngredient(ModContent.ItemType<CuriousSeaLifePaint>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
