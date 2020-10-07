using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class VulcanReaperEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vulcan Reaper Enchantment");
            Tooltip.SetDefault(
@"'Reap the rewards of your near-endless grind'
Provides immunity to Flarium Inferno and Obsidian Curse");
            DisplayName.AddTranslation(GameCulture.Chinese, "火神收割者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'收获你那近乎无休止的苦差事的回报'
免疫地狱之火和黑曜石诅咒
召唤龙魂");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 350000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(138, 36, 58);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            player.buffImmune[soa.BuffType("SerpentWrath")] = true;
            player.buffImmune[soa.BuffType("ObsidianCurse")] = true;

            //pet soon tm
        }

        private readonly string[] items =
        {
            "VulcanHelm",
            "VulcanChest",
            "VulcanLegs",
            "SmolderingSpicyCurry",
            "SerpentChain",
            "Warmth"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
