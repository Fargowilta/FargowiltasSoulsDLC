using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.MiniBoss;
using ThoriumMod.Items.MagicItems;
using ThoriumMod.Items.Painting;
using ThoriumMod.Items.Abyssion;
using FargowiltasSouls;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class NagaSkinEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Naga-Skin Enchantment");
            Tooltip.SetDefault(
@"'Extreme danger noodle'
20% increased attack speed while in water
Allows quicker movement in water");
            DisplayName.AddTranslation(GameCulture.Chinese, "娜迦魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'极端危险'
在水中时, 增加20%攻击速度
允许在水中快速移动");
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

            FargoPlayer fargoPlayer = player.GetModPlayer<FargoPlayer>();
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //naga effect
            if (player.wet)
            {
                fargoPlayer.AttackSpeed += .2f;
            }

            //quicker in water
            player.ignoreWater = true;
            if (player.wet)
            {
                player.moveSpeed += 0.15f;
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<NagaSkinMask>());
            recipe.AddIngredient(ModContent.ItemType<NagaSkinSuit>());
            recipe.AddIngredient(ModContent.ItemType<NagaSkinTail>());
            recipe.AddIngredient(ModContent.ItemType<Eelrod>());
            recipe.AddIngredient(ModContent.ItemType<HydromancerCatalyst>());
            recipe.AddIngredient(ModContent.ItemType<OldGodGrasp>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
