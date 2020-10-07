using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Accessories;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class AtaxiaEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Hydrothermic Enchantment");
            Tooltip.SetDefault(
@"''
You have a 20% chance to emit a blazing explosion on hit
Melee attacks and projectiles cause chaos flames to erupt on enemy hits
You have a 50% chance to fire a homing chaos flare when using ranged weapons
Magic attacks summon damaging and healing flare orbs on hit
Summons a hydrothermic vent to protect you
Rogue weapons have a 10% chance to unleash a volley of chaos flames around the player
Effects of Hallowed Rune and Ethereal Extorter");
            DisplayName.AddTranslation(GameCulture.Chinese, "渊泉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
你受伤时有20%的几率在原地产生一场烈焰爆炸
近战攻击和弹幕在击中敌人时喷发出混沌火焰
使用远程武器时有50%的几率发射追踪的混沌火焰
魔法攻击产生伤害火球和治疗火球
召唤沸腾渊泉保护你
盗贼武器有10%的几率释放混沌火焰
拥有神圣符文和虚空掠夺者的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 1000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(194, 89, 89);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AtaxiaEffects))
            {
                calamity.Call("SetSetBonus", player, "ataxia", true);
                calamity.Call("SetSetBonus", player, "ataxia_melee", true);
                calamity.Call("SetSetBonus", player, "ataxia_ranged", true);
                calamity.Call("SetSetBonus", player, "ataxia_magic", true);
                calamity.Call("SetSetBonus", player, "ataxia_rogue", true);
            }

            if (SoulConfig.Instance.calamityToggles.HallowedRune)
            {
                calamity.GetItem("HallowedRune").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.HallowedRune)
            {
                calamity.GetItem("EtherealExtorter").UpdateAccessory(player, hideVisual);
            } 

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ChaosMinion))
            {
                //summon
                calamity.Call("SetSetBonus", player, "ataxia_summon", true);
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(calamity.BuffType("ChaosSpirit")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("ChaosSpirit"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("ChaosSpirit")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("ChaosSpirit"), (int)(190f * player.minionDamage), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyAtaxiaHelmet");
            recipe.AddIngredient(ModContent.ItemType<AtaxiaArmor>());
            recipe.AddIngredient(ModContent.ItemType<AtaxiaSubligar>());
            recipe.AddIngredient(ModContent.ItemType<HallowedRune>());
            recipe.AddIngredient(ModContent.ItemType<EtherealExtorter>());
            recipe.AddIngredient(ModContent.ItemType<SpearofDestiny>());
            recipe.AddIngredient(ModContent.ItemType<Hellborn>());
            recipe.AddIngredient(ModContent.ItemType<Terracotta>());
            recipe.AddIngredient(ModContent.ItemType<BarracudaGun>());
            recipe.AddIngredient(ModContent.ItemType<Vesuvius>());
            recipe.AddIngredient(ModContent.ItemType<LeadWizard>());
            recipe.AddIngredient(ModContent.ItemType<BrimlashBuster>());
            recipe.AddIngredient(ModContent.ItemType<Impaler>());
            recipe.AddIngredient(ModContent.ItemType<HolidayHalberd>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
