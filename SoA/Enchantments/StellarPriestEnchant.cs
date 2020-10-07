using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace FargowiltasSoulsDLC.SoA.Enchantments
{
    public class StellarPriestEnchant : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Stellar Priest Enchantment");
            Tooltip.SetDefault(
@"'Stand proud'
Summons a Stellar Guardian behind you that attacks enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "恒星牧师魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'STAND PROUD'
在身后召唤一个替身攻击敌人
召唤一颗黑星照亮你");
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
                    tooltipLine.overrideColor = new Color(108, 116, 204);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //set bonus
            modPlayer.DustiteArmor = true;
            if (player.ownedProjectileCounts[soa.ProjectileType("StellarGuardian")] == 0 && !player.dead)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, soa.ProjectileType("StellarGuardian"), (int)(1000f * player.minionDamage), 0f, player.whoAmI, 0f, 0f);
            }

            //pet soon tm
        }

        private readonly string[] items =
        {
            "StellarPriestHead",
            "StellarPriestChest",
            "StellarPriestLegs",
            "StarScourge",
            "GalaxyScepter",
            "LunarCrystalStaff",
            "OblivionRod",
            "FlariumSceptre",
            "AsthralDroneStaff",
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
