﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using CalamityMod.CalPlayer;
using Terraria.Localization;
using System.Collections.Generic;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod;
using CalamityMod.Cooldowns;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class OmegaBlueEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Omega Blue Enchantment");
            Tooltip.SetDefault(
@"'The darkness of the Abyss has overwhelmed you...'
Increases armor penetration by 100
Short-ranged tentacles heal you by sucking enemy life
Press Y to activate abyssal madness for 5 seconds
Abyssal madness increases damage, critical strike chance, and tentacle aggression/range
This effect has a 30 second cooldown
Effects of the Abyssal Diving Suit and Mutated Truffle");
            DisplayName.AddTranslation(GameCulture.Chinese, "欧米伽蓝魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'深渊的黑暗压垮了你...'
提高50点护甲穿透
触手会攻击附近的敌人，偷取生命值治疗你
按Y键进入深渊狂乱状态5秒
深渊狂乱提升你的暴击率，同时触手的攻击欲望和攻击范围都会增加
此效果有25秒冷却时间
两只贝壳会为你而战
使用任何武器时都有10%的几率发射回旋贝壳弹幕
召唤一只海胆为你而战
浸没在液体中时增加10%召唤伤害
在深渊提供适量光照，并适度减少深渊中的氧气损耗
攻击敌人或被敌人攻击赋予他们中毒减益
获得一段硫磺泡泡跳跃，击中敌人赋予毒液减益
拥有深渊潜游服，突变松露和硫海遗爵之鳞的效果
拥有大珍珠和阿米迪亚斯之垂饰的效果
拥有海波纹章和附魔珍珠的效果
拥有海波项链，深潜者，变压护符和卢克索的礼物的效果
拥有腐蚀脊椎和流明护身符的效果
拥有沙尘披风和诱惑鱼饵的效果
召唤几只宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 13;
            item.value = 1000000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(35, 95, 161);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.OmegaTentacles))
            {
                calamity.Call("SetSetBonus", player, "omegablue", true);
                CalamityPlayer modPlayer = player.GetModPlayer<CalamityPlayer>();

                CooldownInstance value;

                if (player.HasCooldown(CalamityMod.Cooldowns.OmegaBlue.ID))
                {
                    player.AddCooldown(OmegaBlue.ID, 1800);
                    if (modPlayer.cooldowns.TryGetValue(OmegaBlue.ID, out value) && value.timeLeft == 1)
                    {
                        for (int num23 = 0; num23 < 66; num23++)
                        {

                            int num24 = Dust.NewDust(player.position, player.width, player.height, 20, 0f, 0f, 100, Color.Transparent, 2.6f);
                            Main.dust[num24].noGravity = true;
                            Main.dust[num24].noLight = true;
                            Main.dust[num24].fadeIn = 1f;
                            Main.dust[num24].velocity *= 6.6f;
                        }
                    }
                }

                if (modPlayer.cooldowns.TryGetValue(OmegaBlue.ID, out value) && value.timeLeft > 1500)
                {
                    modPlayer.omegaBlueHentai = true;
                    int num2 = Dust.NewDust(player.position, player.width, player.height, 20, 0f, 0f, 100, Color.Transparent, 1.6f);
                    Main.dust[num2].noGravity = true;
                    Main.dust[num2].noLight = true;
                    Main.dust[num2].fadeIn = 1f;
                    Main.dust[num2].velocity *= 3f;
                }
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DivingSuit))
            {
                calamity.GetItem("AbyssalDivingSuit").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.ReaperToothNecklace)
            {
                calamity.GetItem("ReaperToothNecklace").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.calamityToggles.MutatedTruffle)
            {
                calamity.GetItem("MutatedTruffle").UpdateAccessory(player, hideVisual);
            }

            //calamity.GetItem("DukeScales").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<OmegaBlueHelmet>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueChestplate>());
            recipe.AddIngredient(ModContent.ItemType<OmegaBlueLeggings>());

            recipe.AddIngredient(ModContent.ItemType<AbyssalDivingSuit>());
            recipe.AddIngredient(ModContent.ItemType<ReaperToothNecklace>());
            recipe.AddIngredient(ModContent.ItemType<MutatedTruffle>());
            
            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
