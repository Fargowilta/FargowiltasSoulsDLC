using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Fishing.AstralCatches;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class AstralEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Astral Enchantment");
            Tooltip.SetDefault(
@"'The Astral Infection has consumed you...'
Whenever you crit an enemy fallen, hallowed, and astral stars will rain down
This effect has a 1 second cooldown before it can trigger again
Effects of the Astral Arcanum, Hide of Astrum Deus, and Gravistar Sabaton
Summons a pet Astrophage");
            DisplayName.AddTranslation(GameCulture.Chinese, "星幻魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'星辉瘟疫侵蚀了你...'
每当你对敌人造成暴击，天空会降落神圣和星辉陨星
此效果有1秒的冷却时间
拥有星辉秘术，星神隐壳和引力靴的效果
召唤噬星体宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 1000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(123, 99, 130);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AstralStars))
            {
                calamity.Call("SetSetBonus", player, "astral", true);
            }

            calamity.GetItem("AstralArcanum").UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.HideofAstrumDeus))
            {
                calamity.GetItem("HideofAstrumDeus").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GravistarSabaton))
            {
                calamity.GetItem("GravistarSabaton").UpdateAccessory(player, hideVisual);
            }

            FargoDLCPlayer fargoPlayer = player.GetModPlayer<FargoDLCPlayer>();
            fargoPlayer.AstralEnchant = true;
            fargoPlayer.AddPet(SoulConfig.Instance.calamityToggles.AstrophagePet, hideVisual, ModContent.BuffType<AstrophageBuff>(), ModContent.ProjectileType<Astrophage>());
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<AstralHelm>());
            recipe.AddIngredient(ModContent.ItemType<AstralBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<AstralLeggings>());
            recipe.AddIngredient(ModContent.ItemType<AstralArcanum>());
            recipe.AddIngredient(ModContent.ItemType<HideofAstrumDeus>());
            recipe.AddIngredient(ModContent.ItemType<GravistarSabaton>());
            recipe.AddIngredient(ModContent.ItemType<UrsaSergeant>());
            recipe.AddIngredient(ModContent.ItemType<EyeofMagnus>());
            recipe.AddIngredient(ModContent.ItemType<AbandonedSlimeStaff>());
            recipe.AddIngredient(ModContent.ItemType<Quasar>());
            recipe.AddIngredient(ModContent.ItemType<HivePod>());
            recipe.AddIngredient(ModContent.ItemType<HeavenfallenStardisk>());
            recipe.AddIngredient(ModContent.ItemType<AegisBlade>());
            recipe.AddIngredient(ModContent.ItemType<AstrophageItem>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
