using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Darksteel;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Placeable;
using ThoriumMod.Items.SummonItems;
using ThoriumMod.Items.RangedItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DarksteelEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Darksteel Enchantment");
            Tooltip.SetDefault(
@"'Light yet durable'
10% damage reduction at Full HP
Nothing will stop your movement 
Double tap to dash
Grants immunity to shambler chain-balls
Effects of Spiked Bracer");
            DisplayName.AddTranslation(GameCulture.Chinese, "暗金魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'轻巧而耐用'
满血时增加10%伤害减免
没有什么能阻止你的移动
获得冲刺能力
免疫蹒跚者的链球效果
拥有尖刺索的效果");
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

            //darksteel bonuses
            player.noKnockback = true;
            player.iceSkate = true;
            player.dash = 1;
            //steel effect
            if (player.statLife == player.statLifeMax2)
            {
                player.endurance += .1f;
            }

            thorium.GetItem("SpikedBracer").UpdateAccessory(player, hideVisual);
            thorium.GetItem("BallnChain").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<hDarksteelFaceGuard>());
            recipe.AddIngredient(ModContent.ItemType<iDarksteelBreastPlate>());
            recipe.AddIngredient(ModContent.ItemType<jDarksteelGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SteelEnchant>());
            recipe.AddIngredient(ModContent.ItemType<BallnChain>());
            recipe.AddIngredient(ModContent.ItemType<StrongestLink>());


            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
