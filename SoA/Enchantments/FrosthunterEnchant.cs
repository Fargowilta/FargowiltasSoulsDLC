using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class FrosthunterEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Frosthunter Enchantment");
            Tooltip.SetDefault(
@"'The hunter now hunted, the prey now predator'
15% increased ranged damage while in the snow biome
Ranged projectiles frostburn enemies
Effects of Frigid Pendant");
            DisplayName.AddTranslation(GameCulture.Chinese, "霜冻猎人魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'现在, 猎人成了猎物, 猎物成了掠食者'
在冰雪地形时, 增加15%远程伤害
远程抛射物将使敌人霜燃
拥有极寒吊坠的效果
召唤一只哀嚎的死亡小狗和虎斑史莱姆跟随你");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 50000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(73, 94, 174);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.frostburnRanged = true;
            if (player.ZoneSnow)
            {
                player.rangedDamage += 0.15f;
            }

            //frigid pendant
            modPlayer.decreePendant = true;
            if (hideVisual)
            {
                modPlayer.decreePendantHide = true;
            }

            //pets soon tm
        }

        private readonly string[] items =
        {
            "FrosthunterHeaddress",
            "FrosthunterWrappings",
            "FrosthunterBoots",
            "DecreeCharm",
            "OmegaStrongbow",
            "IceclawShuriken",
            "FrostGlobeStaff",
            "FrostBeam",
            "DecreeChop",
            "CharmOfH"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in items) recipe.AddIngredient(soa.ItemType(i));

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
