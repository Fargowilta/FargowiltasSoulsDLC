using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class SpaceJunkEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Space Junk Enchantment");
            Tooltip.SetDefault(
@"''I'm da spaceman!'
33% chance to not consume thrown items
Damaging enemies will occasionally call upon a meteor to fall from the sky");
            DisplayName.AddTranslation(GameCulture.Chinese, "太空垃圾魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'我是太空人!'
33%概率不消耗投掷物
攻击敌人概率召唤陨石从天而降");
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

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(120, 135, 154);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.spaceJunk = true;
        }

        private readonly string[] items =
        {
            "SpaceJunkHelm",
            "SpaceJunkBody",
            "SpaceJunkLegs",
            "SatelliteStaff",
            "OrbFlayer",
            "HornetNeedle",
            "VenomiteDagger",
            "RazorfangDagger",
            "GoldDoorHandle",
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddIngredient(soa.ItemType("OrbTitanium"), 300);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
