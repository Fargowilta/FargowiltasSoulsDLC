using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class CosmicCommanderEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cosmic Commander Enchantment");
            Tooltip.SetDefault(
@"'Make Soran great again'
Pressing [Ability] puts you in 'Sniper State' 
Your damage is upped in this state however you are frozen in place and have reduced defense 
State is toggled upon button press and has a cooldown of 5 seconds after switching");
            DisplayName.AddTranslation(GameCulture.Chinese, "宇宙指挥官魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'让索兰再次伟大'
按[特殊能力]键进入'狙击状态'
该状态下, 提升攻击力, 但不能移动且降低防御力
该状态可开关, 拥有5秒的切换冷却
召唤小沃萨跟随你");
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
                    tooltipLine.overrideColor = new Color(21, 142, 100);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.VoxaArmor = true;

            //pet soon tm
        }

        private readonly string[] items =
        {
            "VortexCommanderHat",
            "VortexCommanderSuit",
            "VortexCommanderGreaves",
            "DolphinGun",
            "LightningRifle",
            "PGMUltimaRatioHecateII",
            "FlariumRifle",
            "AsthralBow",
            "AsthralGun"
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
