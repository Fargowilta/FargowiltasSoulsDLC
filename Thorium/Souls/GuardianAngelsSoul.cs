using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using ThoriumMod;
using System.Collections.Generic;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Souls
{
    //[AutoloadEquip(EquipType.Face)]
    public class GuardianAngelsSoul : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Guardian Angel's Soul");

            Tooltip.SetDefault(
@"'Divine Intervention'
30% increased radiant damage
20% increased healing and radiant casting speed
15% increased radiant critical strike chance
Healing spells will heal an additional 5 life
Points you towards the ally with the least health
Healing an ally will increase your movement speed and increase their life regen and defense
Upon drinking a healing potion, all allies will recover 25 life and 50 mana
Nearby allies take 10% reduced damage
Nearby allies that die drop a wisp of spirit energy");
            DisplayName.AddTranslation(GameCulture.Chinese, "守护天使之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'神圣干涉'
增加30%光辉伤害
增加20%治疗和光辉施法速度
增加15%光辉暴击率
治疗法术将额外治疗5点生命
自动指向生命值最低的队友
治疗一个队友将增加你的移动速度,并增加他们的生命回复和防御
喝下治疗药水后,所有队友将恢复25点生命和50点法力值
附近的队友所受伤害减少10%
附近死亡的队友会掉落一团灵魂能量");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.value = 750000;
            item.rare = 11;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 30, 247));
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded) Thorium(player);
        }

        private void Thorium(Player player)
        {
            //general
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.radiantBoost += 0.3f;
            thoriumPlayer.radiantSpeed -= 0.2f;
            thoriumPlayer.healingSpeed += 0.2f;
            thoriumPlayer.radiantCrit += 15;
            //support stash
            thorium.GetItem("SupportSash").UpdateAccessory(player, true);
            //saving grace
            thoriumPlayer.crossHeal = true;
            thoriumPlayer.healBloom = true;
            //soul guard
            thoriumPlayer.graveGoods = true;
            for (int i = 0; i < 255; i++)
            {
                Player player2 = Main.player[i];
                if (player2.active && player2 != player && Vector2.Distance(player2.Center, player.Center) < 400f)
                {
                    player2.AddBuff(thorium.BuffType("AegisAura"), 30, false);
                }
            }
            //archdemon's curse
            thoriumPlayer.darkAura = true;
            //archangels heart
            thoriumPlayer.healBonus += 5;
            //medical bag
            thoriumPlayer.medicalAcc = true;
            //head mirror arrow 
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.HeadMirror))
            {
                float num = 0f;
                int num2 = player.whoAmI;
                for (int i = 0; i < 255; i++)
                {
                    if (Main.player[i].active && Main.player[i] != player && !Main.player[i].dead && (Main.player[i].statLifeMax2 - Main.player[i].statLife) > num)
                    {
                        num = (Main.player[i].statLifeMax2 - Main.player[i].statLife);
                        num2 = i;
                    }
                }
                if (player.ownedProjectileCounts[thorium.ProjectileType("HealerSymbol")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("HealerSymbol"), 0, 0f, player.whoAmI, 0f, 0f);
                }
                for (int j = 0; j < 1000; j++)
                {
                    Projectile projectile = Main.projectile[j];
                    if (projectile.active && projectile.owner == player.whoAmI && projectile.type == thorium.ProjectileType("HealerSymbol"))
                    {
                        projectile.timeLeft = 2;
                        projectile.ai[1] = num2;
                    }
                }
            }
            
        }
        
        private readonly string[] items =
        {
            "SupportSash",
            "SavingGrace",
            "SoulGuard",
            "ArchDemonCurse",
            "ArchangelHeart",
            "MedicalBag",
            "TeslaDefibrillator",
            "MoonlightStaff",
            "TerrariumHolyScythe",
            "TerraScythe",
            "PheonixStaff", 
            "ShieldDroneBeacon", 
            "LifeAndDeath" 
        };

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "HealerEssence");

            foreach (string i in items) recipe.AddIngredient(thorium.ItemType(i));

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
