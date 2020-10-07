using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class AsthraltiteEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Asthraltite Enchantment");
            Tooltip.SetDefault(
@"'Asph-... Asthath-... How are you meant to pronounce this?'
Press [Ability (Primary)] to deploy one of 4 spells
Press [Ability (Primary)] and Up/Down to cycle between the spells
Deploying a spell will initiate a cooldown of 1 minute
Effects of Ring of the Fallen, Memento Mori, and Arcanum of the Caster");
            DisplayName.AddTranslation(GameCulture.Chinese, "阿斯德罗特魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'Asph-... Asthath-... 这玩意怎么读?'
按下[特殊能力]键释放4种法术之一
按下按下[特殊能力]键和上/下切换法术类型
施放法术有1分钟的冷却
拥有堕落之戒, 死亡意志和魔法奥秘的效果
召唤安西的记忆和灭绝天使的徽记");
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
                    tooltipLine.overrideColor = new Color(94, 48, 117);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.AstralSet = true;

            //ring of the fallen
            ModLoader.GetMod("SacredTools").GetItem("AsthralRing").UpdateAccessory(player, hideVisual);

            //memento mori
            ModLoader.GetMod("SacredTools").GetItem("MementoMori").UpdateAccessory(player, hideVisual);

            //arcanum of the caster
            ModLoader.GetMod("SacredTools").GetItem("CasterArcanum").UpdateAccessory(player, hideVisual);

            //pets soon tm
        }

        private readonly string[] items =
        {
            "AsthralChest",
            "AsthralLegs",
            "AsthralRing",
            "MementoMori",
            "CasterArcanum"

        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyAstralHelmet");

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
