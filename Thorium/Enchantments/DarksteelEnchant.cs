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
你无可阻挡
双击方向键冲刺
免疫蹒跚者的链球效果
拥有尖刺锁的效果");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //darksteel bonuses
            player.noKnockback = true;
            player.iceSkate = true;
            player.dash = 1;
            //steel effect
            if (player.statLife == player.statLifeMax2)
            {
                player.endurance += .1f;
            }
            //spiked bracers
            player.thorns += 0.35f;
            //ball n chain
            thoriumPlayer.ballnChain = true;
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
            recipe.AddIngredient(ModContent.ItemType<eeDarksteelMace>());
            recipe.AddIngredient(ModContent.ItemType<gDarkSteelCrossBow>());
            recipe.AddIngredient(ModContent.ItemType<ElephantGun>());
            recipe.AddIngredient(ModContent.ItemType<StrongestLink>());
            //recipe.AddIngredient(ModContent.ItemType<DarksteelHelmetStand>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
