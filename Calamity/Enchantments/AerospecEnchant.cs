using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class AerospecEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Aerospec Enchantment");
            Tooltip.SetDefault(
@"'The sky comes to your aid…'
You fall quicker and are immune to fall damage
Taking over 25 damage in one hit causes several homing feathers to fall
Summons a Valkyrie minion to protect you
Effects of Gladiator's Locket and Unstable Prism
Summons a Rotom pet");
            DisplayName.AddTranslation(GameCulture.Chinese, "天蓝魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"天空向你施以援手...
提升下落速度，免疫摔落伤害
一次受到超过25点伤害会召唤追踪羽毛从天而降
召唤天武神来保护你
拥有角斗士金锁和不稳定棱晶的效果
召唤一只电鬼洛托姆宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 200000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(159, 112, 112);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("SetSetBonus", player, "aerospec", true);
            player.noFallDmg = true;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ValkyrieMinion))
            {
                calamity.Call("SetSetBonus", player, "aerospec_summon", true);
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(calamity.BuffType("Valkyrie")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("Valkyrie"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("Valkyrie")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("Valkyrie"), 25, 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GladiatorLocket))
                calamity.GetItem("GladiatorsLocket").UpdateAccessory(player, hideVisual);
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.UnstablePrism))
                calamity.GetItem("UnstablePrism").UpdateAccessory(player, hideVisual);

            FargoDLCPlayer fargoPlayer = player.GetModPlayer<FargoDLCPlayer>();
            fargoPlayer.AerospecEnchant = true;
            fargoPlayer.AddPet(SoulConfig.Instance.calamityToggles.RotomPet, hideVisual, ModContent.BuffType<RotomBuff>(), ModContent.ProjectileType<RotomPet>());
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyAerospecHelmet");
            recipe.AddIngredient(ModContent.ItemType<AerospecBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<AerospecLeggings>());
            recipe.AddIngredient(ModContent.ItemType<GladiatorsLocket>());
            recipe.AddIngredient(ModContent.ItemType<UnstablePrism>());
            recipe.AddIngredient(ModContent.ItemType<StormSurge>());
            recipe.AddIngredient(ModContent.ItemType<FlurrystormCannon>());
            recipe.AddIngredient(ModContent.ItemType<PerfectDark>());
            recipe.AddIngredient(ModContent.ItemType<SausageMaker>());
            recipe.AddIngredient(ModContent.ItemType<RotomRemote>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
