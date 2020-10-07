using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Magma;
using ThoriumMod.Items.Misc;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Consumable;
using ThoriumMod.Items.ThrownItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class MagmaEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public bool allowJump = true;
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Magma Enchantment");
            Tooltip.SetDefault(
@"'Bursting with heat'
Fire surrounds your armour and melee weapons
Enemies that you set on fire or singe will take additional damage over time
Effects of Spring Steps, Slag Stompers, and Molten Spear Tip");
            DisplayName.AddTranslation(GameCulture.Chinese, "熔岩魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'充斥热能'
火焰环绕着你的盔甲和近战武器
随着时间的推移,被你点燃或烧伤的敌人会受到额外的伤害
拥有弹簧鞋, 熔渣重踏和炽热枪尖的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 60000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            player.magmaStone = true;
            thoriumPlayer.magmaSet = true;
            //spring steps
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SpringSteps))
            {
                thorium.GetItem("SpringSteps").UpdateAccessory(player, hideVisual);
            }
                
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SlagStompers))
            {
                //slag stompers
                timer++;
                if (timer > 20)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0.1f * Main.rand.Next(-25, 25), 2f, thorium.ProjectileType("SlagPro"), 20, 1f, Main.myPlayer, 0f, 0f);
                    timer = 0;
                }
            }
            //molten spear tip
            thoriumPlayer.spearFlame = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<MagmaHelmet>());
            recipe.AddIngredient(ModContent.ItemType<MagmaChestGuard>());
            recipe.AddIngredient(ModContent.ItemType<MagmaGreaves>());
            recipe.AddIngredient(ModContent.ItemType<SpringSteps>());
            recipe.AddIngredient(ModContent.ItemType<SlagStompers>());
            recipe.AddIngredient(ModContent.ItemType<MoltenSpearTip>());
            recipe.AddIngredient(ModContent.ItemType<MagmaPolearm>());
            recipe.AddIngredient(ModContent.ItemType<MagmaticRicochet>());
            recipe.AddIngredient(ModContent.ItemType<MagmaShiv>(), 300);
            recipe.AddIngredient(ModContent.ItemType<HotChocolate>(), 5);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
