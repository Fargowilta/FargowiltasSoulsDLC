using System;
using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.DBT.Souls
{
    public class KiSoul : ModItem
    {
        private readonly Mod dbzMod = ModLoader.GetMod("DBZMOD");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("DBZMOD") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Spiritualist's Soul");

            Tooltip.SetDefault(
@"'The world's spirit resonates within you.'
35% increased ki damage
40% reduced ki usage
20% increased ki critical strike chance
30% increased ki knockback
Massively increased speed while charging
Drastically increased flight speed
Drastically reduced flight ki usage
+5 Charge limit for all beams
Zenkai charm effects
Drasctically increases the range of ki orb pickups
Increased ki orb heal rate
Drastically increased ki regen
30% increased max Ki");
            DisplayName.AddTranslation(GameCulture.Chinese, "气功师之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'世界的元气与你共鸣.'
增加35%气功伤害
减少40%气功消耗
增加20%气功暴击率
增加30%气功击退
极大提升聚气速度
极大提高飞行速度
极大减少飞行的消耗
+5气功束最大蓄力
拥有全开符咒的效果
大幅增加气珠拾取范围
增加气珠回复速率
极大提高气回复
增加30%最大气值");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 216, 0));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 1000000;
            item.rare = 11;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.DBZMODLoaded) return;

            //general
            DBZMOD.MyPlayer dbtPlayer = player.GetModPlayer<DBZMOD.MyPlayer>();

            dbtPlayer.KiDamage += 0.35f;
            dbtPlayer.kiCrit += 20;
            dbtPlayer.chargeMoveSpeed = Math.Max(dbtPlayer.chargeMoveSpeed, 2f);
            dbtPlayer.kiKbAddition += 0.3f;
            dbtPlayer.kiDrainMulti -= 0.4f;
            dbtPlayer.kiMaxMult += 0.3f;
            dbtPlayer.kiRegen += 4;
            dbtPlayer.orbGrabRange += 6;
            dbtPlayer.orbHealAmount += 100;
            dbtPlayer.chargeLimitAdd += 5;
            dbtPlayer.flightSpeedAdd += 0.5f;
            dbtPlayer.flightUsageAdd += 2;
            dbtPlayer.zenkaiCharm = true;
        }

        private readonly string[] _items = 
        {
            "CrystalliteAlleviate",
            "BlackDiamondShell",
            "BlackBlitz",
            "BuldariumSigmite",
            "CandyLaser",
            "InfuserRainbow",
            "EarthenArcanium",
            "FinalShine",
            "KaioCrystal",
            "MajinNucleus",
            "SpiritCharm",
            "SuperSpiritBomb",
            "ScouterT6",
            "ZenkaiCharm"
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.DBZMODLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            foreach (string i in _items)
            {
                recipe.AddIngredient(dbzMod.ItemType(i));
            }

            //recipe.AddIngredient(_dbzModContent.\1Type<\2>\(\), 250);

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
