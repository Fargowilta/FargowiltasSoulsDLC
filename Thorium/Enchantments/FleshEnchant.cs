using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Flesh;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class FleshEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flesh Enchantment");
            Tooltip.SetDefault(
@"'Symbiotically attached to your body'
Consecutive attacks against enemies might drop flesh, which grants bonus life and damage
Effects of Vampire Gland");
            DisplayName.AddTranslation(GameCulture.Chinese, "血肉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'与你共生'
连续攻击敌人时概率掉落肉, 拾取肉会获得额外生命并增加伤害
拥有吸血鬼试剂的效果
召唤宠物泡泡虫");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.FleshDrops))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("FleshMask").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.VampireGland))
            {
                thorium.GetItem("VampireGland").UpdateAccessory(player, true);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FleshMask>());
            recipe.AddIngredient(ModContent.ItemType<FleshBody>());
            recipe.AddIngredient(ModContent.ItemType<FleshLegs>());
            recipe.AddIngredient(ModContent.ItemType<VampireGland>());
            recipe.AddIngredient(ModContent.ItemType<FleshMace>());
            recipe.AddIngredient(ModContent.ItemType<BloodRage>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
