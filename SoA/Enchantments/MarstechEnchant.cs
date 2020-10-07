using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class MarstechEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marstech Enchantment");
            Tooltip.SetDefault(
@"'Who needs magic when you have technology?'
Dealing damage charges up an energy forcefield around you that damages enemies and decays over time 
Can be instantly discharged by pressing [Ability], which will cause a shockwave to damage all nearby enemies 
Damage, range and debuff duration are increased by forcefield strength 
Has a cooldown of 1 minute");
            DisplayName.AddTranslation(GameCulture.Chinese, "火星科技魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'有了科技, 谁还需要魔法呢?'
造成伤害会充能一层随时间衰退的能量力场, 对敌人造成伤害
按下[特殊能力]键会立即进行能量放出, 造成冲击波对附近所有敌人造成伤害
力场会增加伤害, 射程和Debuff持续时间
1分钟冷却");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(61, 155, 189);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.marsArmor = true;
            //space junk
            modPlayer.spaceJunk = true;
        }

        private readonly string[] items =
        {
            "PhaseSlasher",
            "PlasmaDischarge",
            "ZappersInsanity",
            "Trispear"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(soa.ItemType("MarstechHelm"));
            recipe.AddIngredient(soa.ItemType("MarstechPlate"));
            recipe.AddIngredient(soa.ItemType("MarstechLegs"));
            recipe.AddIngredient(null, "SpaceJunkEnchant");

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddIngredient(ItemID.PaintingTheTruthIsUpThere);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
