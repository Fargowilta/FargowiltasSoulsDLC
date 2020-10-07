using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Items.Weapons.Magic;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class SilvaEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        public int dragonTimer = 60;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Silva Enchantment");
            Tooltip.SetDefault(
@"'Boundless life energy cascades from you...'
You are immune to almost all debuffs
Reduces all damage taken by 5%, this is calculated separately from damage reduction
All projectiles spawn healing leaf orbs on enemy hits
Max run speed and acceleration boosted by 5%
If you are reduced to 0 HP you will not die from any further damage for 10 seconds
If you get reduced to 0 HP again while this effect is active you will lose 100 max life
This effect only triggers once per life
Your max life will return to normal if you die
True melee strikes have a 25% chance to do five times damage
Melee projectiles have a 25% chance to stun enemies for a very brief moment
Increases your rate of fire with all ranged weapons
Magic projectiles have a 10% chance to cause a massive explosion on enemy hits
Summons an ancient leaf prism to blast your enemies with life energy
Rogue weapons have a faster throwing rate while you are above 90% life
Effects of the The Amalgam, Dynamo Stem Cells, Godly Soul Artifact, and Yharim's Gift
Summons an Akato and Fox pet");
            DisplayName.AddTranslation(GameCulture.Chinese, "始源林海魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你身上流淌出无尽的生命能量'
免疫几乎所有减益
所有弹幕击中敌人时生成林海光球治疗你
最大跑动速度和加速度提高5%
如果你的生命值将要降至1以下，则你在10秒钟内不会因为受伤而死亡
在此期间每当你的生命值将要因为受伤而归零时，你将具有1点生命值但生命值上限减少100
如果你的最大生命值被降至了400，此效果立即结束。此效果每条生命仅会生效一次
死去时最大生命值恢复正常
真正的近战攻击有25%概率造成五倍伤害
近战弹幕有25%几率眩晕敌人一小会
提升远程武器的射速
魔法弹幕击中敌人后有10%几率产生巨大爆炸
魔法弹幕击中敌人后有10%几率产生巨大爆炸
生命值高于50%时, 提高盗贼武器攻速
拥有聚合之脑, 痴愚金龙干细胞，圣魂神物和魔君的礼物的效果
召唤阿卡托和狐狸宠物");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(176, 112, 70);
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 20000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SilvaEffects))
            {
                calamity.Call("SetSetBonus", player, "silva", true);
                calamity.Call("SetSetBonus", player, "silva_melee", true);
                calamity.Call("SetSetBonus", player, "silva_ranged", true);
                calamity.Call("SetSetBonus", player, "silva_magic", true);
                calamity.Call("SetSetBonus", player, "silva_rogue", true);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.SilvaMinion))
            {
                //summon
                calamity.Call("SetSetBonus", player, "silva_summon", true);
                if (player.whoAmI == Main.myPlayer)
                {
                    if (player.FindBuffIndex(calamity.BuffType("SilvaCrystal")) == -1)
                    {
                        player.AddBuff(calamity.BuffType("SilvaCrystal"), 3600, true);
                    }
                    if (player.ownedProjectileCounts[calamity.ProjectileType("SilvaCrystal")] < 1)
                    {
                        Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("SilvaCrystal"), (int)(1500.0 * (double)player.minionDamage), 0f, Main.myPlayer, 0f, 0f);
                    }
                }
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.FungalMinion))
            {
                calamity.GetItem("TheAmalgam").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.GodlySoulArtifact))
            {
                calamity.GetItem("GodlySoulArtifact").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.YharimGift))
            {
                calamity.GetItem("YharimsGift").UpdateAccessory(player, hideVisual);
            }

            calamity.GetItem("DynamoStemCells").UpdateAccessory(player, hideVisual);

            FargoDLCPlayer fargoPlayer = player.GetModPlayer<FargoDLCPlayer>();
            fargoPlayer.SilvaEnchant = true;
            fargoPlayer.AddPet(SoulConfig.Instance.calamityToggles.AkatoPet, hideVisual, calamity.BuffType("AkatoYharonBuff"), calamity.ProjectileType("Akato"));
            fargoPlayer.AddPet(SoulConfig.Instance.calamityToggles.FoxPet, hideVisual, calamity.BuffType("Fox"), calamity.ProjectileType("Fox"));
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnySilvaHelmet");
            recipe.AddIngredient(ModContent.ItemType<SilvaArmor>());
            recipe.AddIngredient(ModContent.ItemType<SilvaLeggings>());
            recipe.AddIngredient(ModContent.ItemType<TheAmalgam>());
            recipe.AddIngredient(ModContent.ItemType<GodlySoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<YharimsGift>());
            recipe.AddIngredient(ModContent.ItemType<DynamoStemCells>());
            recipe.AddIngredient(ModContent.ItemType<AlphaRay>());
            recipe.AddIngredient(ModContent.ItemType<ScourgeoftheCosmos>());
            recipe.AddIngredient(ModContent.ItemType<Swordsplosion>());
            recipe.AddIngredient(ModContent.ItemType<VoidVortex>());
            recipe.AddIngredient(ModContent.ItemType<YharimsCrystal>());
            recipe.AddIngredient(ModContent.ItemType<ForgottenDragonEgg>());
            recipe.AddIngredient(ModContent.ItemType<FoxDrive>());

            recipe.AddTile(calamity, "DraedonsForge");
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
