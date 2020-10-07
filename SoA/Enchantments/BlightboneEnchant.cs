using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class BlightboneEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Blightbone Enchantment");
            Tooltip.SetDefault(
@"'Your spooks and scares will send shivers down your enemies' spines'
Empowers certain bone-related weapons
Effects Dreadflame Emblem");
            DisplayName.AddTranslation(GameCulture.Chinese, "荒骨魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你的幽影和恐惧会让你的敌人毛骨悚然'
增强特定骨头相关的武器
拥有恐惧火焰徽记的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 100000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(124, 10, 10);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.blightEmpowerment = true;

            //dreadflame emblem
            modPlayer.dreadEmblem = true;
        }

        private readonly string[] items =
        {
            "BlightMask",
            "BlightChest",
            "BlightLegs",
            "DreadflameEmblem",
            "FeatherHairpin",
            "MoodSummon",
            "HarpyBoomerang",
            "BoneThrone",
            "PumpGlove",
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddIngredient(soa.ItemType("Pumpnade"), 300);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
