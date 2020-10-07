using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class VoidWardenEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Void Warden Enchantment");
            Tooltip.SetDefault(
@"'The ride never ends'
Taking damage has a chance to freeze all enemies nearby
Bosses and enemies with over 8000 HP are unaffected 
Attacking has a 5% chance to make nearby enemies take double damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "虚空守望魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'旅程永无止境'
受到伤害有概率冻结附近敌人
Boss和8000血以上的敌人不受该效果影响
攻击有5%概率使附近敌人收到双倍伤害
召唤一个友善的子弹伙伴");
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
                    tooltipLine.overrideColor = new Color(79, 21, 137);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.voidDefense = true;
            modPlayer.voidOffense = true;

            //pets soon tm
        }

        private readonly string[] items =
        {
            "VoidHelm",
            "VoidChest",
            "VoidChestOffense",
            "VoidLegs",
            "Skill_FuryForged",
            "DarkRemnant",
            "EdgeOfGehenna",
            "OblivionMagnum",
            "ArachnesGaze"
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
