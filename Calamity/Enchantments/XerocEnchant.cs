using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Typeless.FiniteUse;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class XerocEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Xeroc Enchantment");
            Tooltip.SetDefault(
@"'The power of an ancient god at your command…'
Rogue projectiles have special effects on enemy hits
Imbued with cosmic wrath and rage when you are damaged
Effects of The Community");
            DisplayName.AddTranslation(GameCulture.Chinese, "克希洛克魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'掌握着一位上古之神的力量...'
盗贼弹幕击中敌人产生特殊效果
受伤时受到来自宇宙的怒火加持
拥有归一心元石的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 9;
            item.value = 1000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(171, 19, 33);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.XerocEffects))
            {
                calamity.Call("SetSetBonus", player, "xeroc", true);
            }

            //the community
            calamity.GetItem("TheCommunity").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<XerocMask>());
            recipe.AddIngredient(ModContent.ItemType<XerocPlateMail>());
            recipe.AddIngredient(ModContent.ItemType<XerocCuisses>());
            recipe.AddIngredient(ModContent.ItemType<TheCommunity>());
            recipe.AddIngredient(ModContent.ItemType<ElephantKiller>());
            recipe.AddIngredient(ModContent.ItemType<ElementalBlaster>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
