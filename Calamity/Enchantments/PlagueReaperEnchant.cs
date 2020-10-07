using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using System;
using CalamityMod.Projectiles.Rogue;
using CalamityMod;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class PlagueReaperEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Reaper Enchantment");
            Tooltip.SetDefault(
@"''
Enemies receive 10% more damage from ranged projectiles when afflicted by the Plague
Getting hit causes the plague cinders to rain from above
Effects of Plague Hive, Plagued Fuel Pack, The Bee, and The Camper");
            DisplayName.AddTranslation(GameCulture.Chinese, "瘟疫死神魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
受瘟疫减益作用的敌人会额外受到10%的远程伤害
受到伤害会使瘟疫残渣从天而降
拥有瘟疫蜂巢，瘟疫燃料背包，蜜蜂护符和露营者的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 300000;
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(70, 63, 69);
                }
            }
        }*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("SetSetBonus", player, "plaguereaper", true);
            //meme
            if (player.whoAmI == Main.myPlayer && player.immune && Utils.NextBool(Main.rand, 10))
            {
                for (int j = 0; j < 1; j++)
                {
                    float num2 = player.position.X + (float)Main.rand.Next(-400, 400);
                    float num3 = player.position.Y - (float)Main.rand.Next(500, 800);
                    Vector2 vector = new Vector2(num2, num3);
                    float num4 = player.position.X + (float)(player.width / 2) - vector.X;
                    float num5 = player.position.Y + (float)(player.height / 2) - vector.Y;
                    num4 += (float)Main.rand.Next(-100, 101);
                    float num6 = (float)22;
                    float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                    num7 = num6 / num7;
                    num4 *= num7;
                    num5 *= num7;
                    int num8 = Projectile.NewProjectile(num2, num3, num4, num5, ModContent.ProjectileType<TheSyringeCinder>(), 40, 4f, player.whoAmI, 0f, 0f);
                    Main.projectile[num8].Calamity().rogue = false;
                    Main.projectile[num8].ai[1] = player.position.Y;
                }
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PlagueHive))
            {
                calamity.GetItem("PlagueHive").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PlaguedFuelPack))
            {
                calamity.GetItem("PlaguedFuelPack").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.TheBee))
            {
                calamity.GetItem("TheBee").UpdateAccessory(player, hideVisual);
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.TheCamper))
            {
                calamity.GetItem("TheCamper").UpdateAccessory(player, hideVisual);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<PlagueReaperMask>());
            recipe.AddIngredient(ModContent.ItemType<PlagueReaperVest>());
            recipe.AddIngredient(ModContent.ItemType<PlagueReaperStriders>());
            recipe.AddIngredient(ModContent.ItemType<PlagueHive>());
            recipe.AddIngredient(ModContent.ItemType<PlaguedFuelPack>());
            recipe.AddIngredient(ModContent.ItemType<TheBee>());
            recipe.AddIngredient(calamity.ItemType("TheCamper"));
            recipe.AddIngredient(ModContent.ItemType<SamuraiBadge>());
            recipe.AddIngredient(ModContent.ItemType<Malachite>());
            recipe.AddIngredient(ModContent.ItemType<Plaguenade>(), 300);
            recipe.AddIngredient(ModContent.ItemType<PlagueKeeper>());
            recipe.AddIngredient(ModContent.ItemType<TheSwarmer>());
            recipe.AddIngredient(ModContent.ItemType<CelestialReaper>());
            recipe.AddIngredient(ModContent.ItemType<MadAlchemistsCocktailGlove>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
