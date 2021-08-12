using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class NebulousApprenticeEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Nebulous Apprentice Enchantment");
            Tooltip.SetDefault(
@"'Nuba would be proud'
Attacking enemies may sometimes release buff wisps which can be picked up for different stacking buffs
Effects of Nuba's Blessing");
            DisplayName.AddTranslation(GameCulture.Chinese, "星云学徒魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'努巴会为你感到骄傲'
攻击敌人概率释放强化焰, 拾取后获得可堆叠Buff
拥有努巴的祝福的效果");
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
                    tooltipLine.overrideColor = new Color(206, 7, 221);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.NubaArmor = true;

            //nubas blessing
            modPlayer.NubaBlessing = true;
        }

        private readonly string[] items =
        {
            "NubaHood",
            "NubaChest",
            "NubaRobe",
            "NubasBlessing",
            "LunaticBurstStaff",
            //"CosmicCloudBracelet",
            //"Armageddon",
            //"FlariumTome",
            "AsthralStaff",
            //"AsthralTome"
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
