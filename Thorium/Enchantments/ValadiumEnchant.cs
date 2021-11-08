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
using ThoriumMod.Items.Lich;

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
Effects of Mirror of the Beholder and Beholder's Gaze");
            DisplayName.AddTranslation(GameCulture.Chinese, "虚金魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'哪儿是上?'
按'上'键逆转重力
重力颠倒时增加12%伤害
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
            recipe.AddIngredient(ModContent.ItemType<LichGaze>());
            recipe.AddIngredient(ModContent.ItemType<TommyGun>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
