using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using ThoriumMod.Items.EndofDays.Omni;
using ThoriumMod.Items.RangedItems;
using ThoriumMod.Items.Tracker;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class AssassinEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Assassin Enchantment");
            Tooltip.SetDefault(
@"'Blacken the skies and cull the weak'
Attacks have a 10% chance to duplicate and become increased by 15%
Attacks have a 5% chance to instantly kill the enemy
Effects of Dart Pouch");
            DisplayName.AddTranslation(GameCulture.Chinese, "刺客魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'遮蔽天空，抹除弱者'
攻击有10%概率复制并增加15%伤害
攻击有5%概率即死敌人
拥有飞镖袋的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 400000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 128, 0));
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            modPlayer.AssassinEnchant = true;

            //dart pouch effect
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<OmniMarkHead>());
            recipe.AddIngredient(ModContent.ItemType<OmniArablastHood>());
            recipe.AddIngredient(ModContent.ItemType<OmniBody>());
            recipe.AddIngredient(ModContent.ItemType<OmniGreaves>());
            recipe.AddIngredient(ModContent.ItemType<DartPouch>());
            recipe.AddIngredient(ModContent.ItemType<RejectsBlowpipe>());
            recipe.AddIngredient(ModContent.ItemType<BlackBow>());
            recipe.AddIngredient(ModContent.ItemType<OmniBow>());
            recipe.AddIngredient(ModContent.ItemType<WyrmDecimator>());
            recipe.AddIngredient(ModContent.ItemType<TheJavelin>());
            
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
