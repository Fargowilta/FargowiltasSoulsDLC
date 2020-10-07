using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class UmbraphileEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Umbraphile Enchantment");
            Tooltip.SetDefault(
@"''
Rogue weapons have a chance to create explosions on hit
Stealth strikes always create an explosion
Penumbra potions always build stealth at max effectiveness
Effects of Thief's Dime, Vampiric Talisman, and Momentum Capacitor");
            DisplayName.AddTranslation(GameCulture.Chinese, "日影魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
盗贼武器击中敌人时概率产生爆炸
暴击总是会产生爆炸
半影药剂总是发挥最大功效
拥有盗贼铸币，吸血鬼符咒和动量电容器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 300000;
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(70, 63, 69);
                }
            }
        }*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("SetSetBonus", player, "umbraphile", true);
            calamity.GetItem("ThiefsDime").UpdateAccessory(player, hideVisual);
            calamity.GetItem("VampiricTalisman").UpdateAccessory(player, hideVisual);
            calamity.GetItem("MomentumCapacitor").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<UmbraphileHood>());
            recipe.AddIngredient(ModContent.ItemType<UmbraphileRegalia>());
            recipe.AddIngredient(ModContent.ItemType<UmbraphileBoots>());
            recipe.AddIngredient(ModContent.ItemType<ThiefsDime>());
            recipe.AddIngredient(ModContent.ItemType<VampiricTalisman>());
            recipe.AddIngredient(ModContent.ItemType<MomentumCapacitor>());
            recipe.AddIngredient(ModContent.ItemType<AcidicRainBarrel>());
            recipe.AddIngredient(ModContent.ItemType<Brimblade>());
            recipe.AddIngredient(ModContent.ItemType<DeepWounder>());
            recipe.AddIngredient(ModContent.ItemType<MonkeyDarts>(), 300);
            recipe.AddIngredient(ModContent.ItemType<DefectiveSphere>(), 5);
            recipe.AddIngredient(ModContent.ItemType<StellarKnife>());
            recipe.AddIngredient(ModContent.ItemType<CorpusAvertor>());
            recipe.AddIngredient(calamity.ItemType("OnyxExcavatorKey")); //e
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
