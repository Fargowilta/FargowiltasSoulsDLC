using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Valadium;
using ThoriumMod.Items.FallenBeholder;
using ThoriumMod.Items.Blizzard;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.ThrownItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class ValadiumEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Valadium Enchantment");
            Tooltip.SetDefault(
@"'Which way is up?'
Reverse gravity by pressing UP
While reversed, damage is increased by 12%
Effects of Mirror of the Beholder");
            DisplayName.AddTranslation(GameCulture.Chinese, "虚金魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'哪儿是上?'
按上（W）键来反转重力
反转状态时，你增加12%远程伤害
拥有注视者之眼的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            //if (SoulConfig.Instance.GetValue(SoulConfig.Instance.GravityControl))
            //{
                player.gravControl = true;
                if (player.gravDir == -1f)
                {
                    modPlayer.AllDamageUp(.12f);
                }
            //}
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BeholderEye))
            {
                //eye of beholder
                thorium.GetItem("EyeofBeholder").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<ValadiumHelmet>());
            recipe.AddIngredient(ModContent.ItemType<ValadiumBreastPlate>());
            recipe.AddIngredient(ModContent.ItemType<ValadiumGreaves>());
            recipe.AddIngredient(ModContent.ItemType<EyeofBeholder>());
            recipe.AddIngredient(ModContent.ItemType<GlacialSting>());
            recipe.AddIngredient(ModContent.ItemType<Obliterator>());
            recipe.AddIngredient(ModContent.ItemType<ValadiumBow>());
            recipe.AddIngredient(ModContent.ItemType<ValadiumStaff>());
            recipe.AddIngredient(ModContent.ItemType<TommyGun>());
            recipe.AddIngredient(ModContent.ItemType<CrystalBalloon>(), 300);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
