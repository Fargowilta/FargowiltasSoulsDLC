using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class BiotechEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Biotech Enchantment");
            Tooltip.SetDefault(
@"'Anyways, that's how I lost my medical license'
A biotech probe will assist you in healing your allies
Heals ally life equal to your bonus healing");
            DisplayName.AddTranslation(GameCulture.Chinese, "生物工程魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'不管怎样, 这就是我怎么丢掉我的行医执照的'
召唤一个生物工程探测器协助你治疗队友
治疗量等于你的额外治疗量");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BiotechProbe))
            {
                ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
                thoriumPlayer.essenceSet = true;
                if (player.ownedProjectileCounts[thorium.ProjectileType("LifeEssence")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("LifeEssence"), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LifeWeaverHood>());
            recipe.AddIngredient(ModContent.ItemType<LifeWeaverGarment>());
            recipe.AddIngredient(ModContent.ItemType<LifeWeaverLeggings>());
            recipe.AddIngredient(ModContent.ItemType<LifeEssenceApparatus>());
            recipe.AddIngredient(ModContent.ItemType<NullZoneStaff>());
            recipe.AddIngredient(ModContent.ItemType<BarrierGenerator>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
