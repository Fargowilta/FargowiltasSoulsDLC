using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class ExitumLuxEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Exitum Lux Enchantment");
            Tooltip.SetDefault(
@"''
Does something soon TM
Effects of Stone of Resonance");
            DisplayName.AddTranslation(GameCulture.Chinese, "卢克斯魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''

拥有夜明共振石的效果");
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
                    tooltipLine.overrideColor = new Color(137, 154, 178);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.exodusHelmet = true;
            modPlayer.exodusChest = true;
            modPlayer.exodusLegs = true;

            //stone of resonance
            ModLoader.GetMod("SacredTools").GetItem("StoneOfResonance").UpdateAccessory(player, hideVisual);
        }

        private readonly string[] items =
        {
            "ExodusHelmet",
            "ExodusChest",
            "ExodusLegs",
            "StoneOfResonance",
            "Claymarine",
            "LuxShardMelee",
            "LuxShardRanged",
            "LuxShardMagic",
            "LuxShardSummon",
            "LuxDustThrown"
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
