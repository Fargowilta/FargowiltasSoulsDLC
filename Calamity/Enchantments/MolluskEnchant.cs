using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Items.Fishing.SunkenSeaCatches;
using CalamityMod.Projectiles.Pets;
using CalamityMod.Buffs.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class MolluskEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Mollusk Enchantment");
            Tooltip.SetDefault(
@"'The world is your oyster'
Two shellfishes aid you in combat
When using any weapon you have a 10% chance to throw a returning seashell projectile
Summons a sea urchin to protect you
Effects of Giant Pearl and Aquatic Emblem 
Effects of Ocean's Crest and Luxor's Gift");
            DisplayName.AddTranslation(GameCulture.Chinese, "软壳魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'世界任你驰骋'
两只贝壳会为你而战
使用任何武器时都有10%的几率发射回旋贝壳弹幕
召唤一只海胆为你而战
拥有大珍珠和阿米迪亚斯之垂饰的效果
拥有海波纹章和附魔珍珠的效果
拥有海波项链，深潜者，变压护符和卢克索的礼物的效果
召唤小鬼铃水母宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(74, 97, 96);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.ShellfishMinion))
            {
                //set bonus clams
                calamity.Call("SetSetBonus", player, "mollusk", true);
                player.maxMinions += 4;
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(calamity.BuffType("Shellfish")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("Shellfish"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("Shellfish")] < 2)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("Shellfish"), (int)(1500.0 * (double)player.minionDamage), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GiantPearl))
            {
                calamity.GetItem("GiantPearl").UpdateAccessory(player, hideVisual);
            }

            //if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AmidiasPendant))
            //{
            //    calamity.GetItem("AmidiasPendant").UpdateAccessory(player, hideVisual);
            //}

            calamity.GetItem("AquaticEmblem").UpdateAccessory(player, hideVisual);
           // calamity.GetItem("EnchantedPearl").UpdateAccessory(player, hideVisual);
            mod.GetItem("VictideEnchant").UpdateAccessory(player, hideVisual);

        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<MolluskShellmet>());
            recipe.AddIngredient(ModContent.ItemType<MolluskShellplate>());
            recipe.AddIngredient(ModContent.ItemType<MolluskShelleggings>());
            recipe.AddIngredient(ModContent.ItemType<VictideEnchant>());
            recipe.AddIngredient(ModContent.ItemType<GiantPearl>());
            recipe.AddIngredient(ModContent.ItemType<AquaticEmblem>());
            //recipe.AddIngredient(ModContent.ItemType<EnchantedPearl>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
