using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Sandstone;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.ThunderBird;
using ThoriumMod.Items.NPCItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class SandstoneEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sandstone Enchantment");
            Tooltip.SetDefault(
@"'Enveloped by desert winds'
Desert winds have granted you a sandy double jump");
            DisplayName.AddTranslation(GameCulture.Chinese, "砂石魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'沙暴环绕'
沙暴增强了你的靴子, 能够额外跳跃一次");
            //Thrown attacks might refresh your jump
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SandstoneJump))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("hSandStoneHelmet").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<hSandStoneHelmet>());
            recipe.AddIngredient(ModContent.ItemType<iSandStoneMail>());
            recipe.AddIngredient(ModContent.ItemType<jSandStoneGreaves>());
            recipe.AddIngredient(ModContent.ItemType<StoneThrowingSpear>(), 300);
            recipe.AddIngredient(ModContent.ItemType<Scorpain>());
            recipe.AddIngredient(ModContent.ItemType<TalonBurst>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
