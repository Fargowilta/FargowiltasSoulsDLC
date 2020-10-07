using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.CalPlayer;
using System;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Magic;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class AuricEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Auric Tesla Enchantment");
            Tooltip.SetDefault(
@"'Your strength rivals that of the Jungle Tyrant...'
All effects from Tarragon, Bloodflare, Godslayer and Silva armor
All attacks spawn healing auric orbs
Effects of Heart of the Elements and The Sponge");
            DisplayName.AddTranslation(GameCulture.Chinese, "古圣金源魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你的力量能与丛林暴君的力量相媲美...'
拥有龙蒿, 血炎, 弑神者和始源林海的套装效果
所有攻击生成圣金源光球治疗玩家
拥有元素之心和化绵留香石的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 10000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(217, 142, 67);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.AuricEffects))
            {
                calamity.Call("SetSetBonus", player, "auric", true);

                //tarragaon
                calamity.Call("SetSetBonus", player, "tarragon", true);
                calamity.Call("SetSetBonus", player, "tarragon_melee", true);
                calamity.Call("SetSetBonus", player, "tarragon_ranged", true);
                calamity.Call("SetSetBonus", player, "tarragon_magic", true);
                calamity.Call("SetSetBonus", player, "tarragon_summon", true);
                calamity.Call("SetSetBonus", player, "tarragon_rogue", true);
                //bloodflare
                calamity.Call("SetSetBonus", player, "bloodflare", true);
                calamity.Call("SetSetBonus", player, "bloodflare_melee", true);
                calamity.Call("SetSetBonus", player, "bloodflare_ranged", true);
                calamity.Call("SetSetBonus", player, "bloodflare_magic", true);
                calamity.Call("SetSetBonus", player, "bloodflare_rogue", true);
                //godslayer
                calamity.Call("SetSetBonus", player, "godslayer", true);
                calamity.Call("SetSetBonus", player, "godslayer_melee", true);
                calamity.Call("SetSetBonus", player, "godslayer_ranged", true);
                calamity.Call("SetSetBonus", player, "godslayer_magic", true);
                calamity.Call("SetSetBonus", player, "godslayer_rogue", true);
                //silva
                calamity.Call("SetSetBonus", player, "silva", true);
                calamity.Call("SetSetBonus", player, "silva_melee", true);
                calamity.Call("SetSetBonus", player, "silva_ranged", true);
                calamity.Call("SetSetBonus", player, "silva_magic", true);
                calamity.Call("SetSetBonus", player, "silva_rogue", true);
            }

            //summon head
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PolterMines))
            {
                calamity.Call("SetSetBonus", player, "bloodflare_summon", true);
            }

            if (player.whoAmI == Main.myPlayer)
            {
                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SilvaMinion))
                {
                    calamity.Call("SetSetBonus", player, "silva_summon", true);
                    if (player.FindBuffIndex(calamity.BuffType("SilvaCrystal")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("SilvaCrystal"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("SilvaCrystal")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("SilvaCrystal"), (int)(3000.0 * (double)player.minionDamage), 0f, Main.myPlayer, 0f, 0f);
                    }
                }

                if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.MechwormMinion))
                {
                    calamity.Call("SetSetBonus", player, "godslayer_summon", true);
                    if (player.FindBuffIndex(calamity.BuffType("Mechworm")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("Mechworm"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("MechwormHead")] < 1)
                    {
                        int whoAmI = player.whoAmI;
                        int num = calamity.ProjectileType("MechwormHead");
                        int num2 = calamity.ProjectileType("MechwormBody");
                        int num3 = calamity.ProjectileType("MechwormBody2");
                        int num4 = calamity.ProjectileType("MechwormTail");
                        for (int i = 0; i < 1000; i++)
                        {
                            if (Main.projectile[i].active && Main.projectile[i].owner == whoAmI && (Main.projectile[i].type == num || Main.projectile[i].type == num4 || Main.projectile[i].type == num2 || Main.projectile[i].type == num3))
                            {
                                Main.projectile[i].Kill();
                            }
                        }
                        int num5 = player.maxMinions;
                        if (num5 > 10)
                        {
                            num5 = 10;
                        }
                        int num6 = (int)(35f * (player.minionDamage * 5f / 3f + player.minionDamage * 0.46f * (num5 - 1)));
                        Vector2 value = player.RotatedRelativePoint(player.MountedCenter, true);
                        Vector2 value2 = Utils.RotatedBy(Vector2.UnitX, player.fullRotation, default(Vector2));
                        Vector2 value3 = Main.MouseWorld - value;
                        float num7 = Main.mouseX + Main.screenPosition.X - value.X;
                        float num8 = Main.mouseY + Main.screenPosition.Y - value.Y;
                        if (player.gravDir == -1f)
                        {
                            num8 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - value.Y;
                        }
                        float num9 = (float)Math.Sqrt((num7 * num7 + num8 * num8));
                        if ((float.IsNaN(num7) && float.IsNaN(num8)) || (num7 == 0f && num8 == 0f))
                        {
                            num7 = player.direction;
                            num8 = 0f;
                            num9 = 10f;
                        }
                        else
                        {
                            num9 = 10f / num9;
                        }
                        num7 *= num9;
                        num8 *= num9;
                        int num10 = -1;
                        int num11 = -1;
                        for (int j = 0; j < 1000; j++)
                        {
                            if (Main.projectile[j].active && Main.projectile[j].owner == whoAmI)
                            {
                                if (num10 == -1 && Main.projectile[j].type == num)
                                {
                                    num10 = j;
                                }
                                else if (num11 == -1 && Main.projectile[j].type == num4)
                                {
                                    num11 = j;
                                }
                                if (num10 != -1 && num11 != -1)
                                {
                                    break;
                                }
                            }
                        }
                        if (num10 == -1 && num11 == -1)
                        {
                            float num12 = Vector2.Dot(value2, value3);
                            if (num12 > 0f)
                            {
                                player.ChangeDir(1);
                            }
                            else
                            {
                                player.ChangeDir(-1);
                            }
                            num7 = 0f;
                            num8 = 0f;
                            value.X = Main.mouseX + Main.screenPosition.X;
                            value.Y = Main.mouseY + Main.screenPosition.Y;
                            int num13 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormHead"), num6, 1f, whoAmI, 0f, 0f);
                            int num14 = num13;
                            num13 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormBody"), num6, 1f, whoAmI, num14, 0f);
                            num14 = num13;
                            num13 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormBody2"), num6, 1f, whoAmI, num14, 0f);
                            Main.projectile[num14].localAI[1] = num13;
                            Main.projectile[num14].netUpdate = true;
                            num14 = num13;
                            num13 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormTail"), num6, 1f, whoAmI, num14, 0f);
                            Main.projectile[num14].localAI[1] = num13;
                            Main.projectile[num14].netUpdate = true;
                            return;
                        }
                        if (num10 != -1 && num11 != -1)
                        {
                            int num15 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormBody"), num6, 1f, whoAmI, Main.projectile[num11].ai[0], 0f);
                            int num16 = Projectile.NewProjectile(value.X, value.Y, num7, num8, calamity.ProjectileType("MechwormBody2"), num6, 1f, whoAmI, (float)num15, 0f);
                            Main.projectile[num15].localAI[1] = num16;
                            Main.projectile[num15].ai[1] = 1f;
                            Main.projectile[num15].minionSlots = 0f;
                            Main.projectile[num15].netUpdate = true;
                            Main.projectile[num16].localAI[1] = num11;
                            Main.projectile[num16].netUpdate = true;
                            Main.projectile[num16].minionSlots = 0f;
                            Main.projectile[num16].ai[1] = 1f;
                            Main.projectile[num11].ai[0] = num16;
                            Main.projectile[num11].netUpdate = true;
                            Main.projectile[num11].ai[1] = 1f;
                        }
                    }
                }      
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.WaifuMinions))
            {
                calamity.GetItem("HeartoftheElements").UpdateAccessory(player, hideVisual);
            }

            //the sponge
            calamity.GetItem("Sponge").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyAuricHelmet");
            recipe.AddIngredient(ModContent.ItemType<AuricTeslaBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<AuricTeslaCuisses>());
            recipe.AddIngredient(ModContent.ItemType<HeartoftheElements>());
            recipe.AddIngredient(ModContent.ItemType<Sponge>());
            recipe.AddIngredient(ModContent.ItemType<DraedonsExoblade>());
            recipe.AddIngredient(ModContent.ItemType<ArkoftheCosmos>());
            recipe.AddIngredient(ModContent.ItemType<DragonPow>());
            recipe.AddIngredient(ModContent.ItemType<Oracle>());
            recipe.AddIngredient(ModContent.ItemType<Drataliornus>());
            recipe.AddIngredient(ModContent.ItemType<Photoviscerator>());
            recipe.AddIngredient(ModContent.ItemType<VividClarity>());
            recipe.AddIngredient(ModContent.ItemType<CosmicImmaterializer>());
            recipe.AddIngredient(ModContent.ItemType<Supernova>());

            recipe.AddTile(calamity, "DraedonsForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
