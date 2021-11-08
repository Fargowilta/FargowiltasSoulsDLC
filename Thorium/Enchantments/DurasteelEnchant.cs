using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Steel;
using ThoriumMod.Items.DD;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DurasteelEnchant : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Durasteel Enchantment");
            Tooltip.SetDefault(
@"'Masterfully forged by the Blacksmith'
12% damage reduction at Full HP
Grants immunity to shambler chain-balls
Effects of Incandescent Spark and Spiked Bracers");
            DisplayName.AddTranslation(GameCulture.Chinese, "耐刚魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'精工打造'
满血时增加90%伤害减免
免疫蹒跚者的链球效果
拥有炽热火花, 尖刺索和贪婪磁铁的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            //durasteel effect
            if (player.statLife == player.statLifeMax2)
            {
                player.endurance += .12f;
            }

            //darksteel bonuses
            player.noKnockback = true;
            player.iceSkate = true;
            player.dash = 1;

            ModContent.GetModItem(ModContent.ItemType<BallnChain>()).UpdateAccessory(player, hideVisual);
            ModContent.GetModItem(ModContent.ItemType<SpikedBracer>()).UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.IncandescentSpark))
            {
                ModContent.GetModItem(ModContent.ItemType<IncandescentSpark>()).UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DurasteelHelmet>());
            recipe.AddIngredient(ModContent.ItemType<DurasteelChestplate>());
            recipe.AddIngredient(ModContent.ItemType<DurasteelGreaves>());
            recipe.AddIngredient(ModContent.ItemType<DarksteelEnchant>());
            recipe.AddIngredient(ModContent.ItemType<IncandescentSpark>());
            recipe.AddIngredient(ModContent.ItemType<DurasteelBlade>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
