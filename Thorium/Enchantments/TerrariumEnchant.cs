using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using ThoriumMod.Items.Terrarium;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.NPCItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class TerrariumEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Terrarium Enchantment");
            Tooltip.SetDefault(
@"'All will fall before your might...'
The energy of Terraria seeks to protect you
Shortlived Divermen will occasionally spawn when hitting enemies
Critical strikes ring a bell over your head, slowing all nearby enemies briefly
Effects of Crietz and Band of Replenishmen
Effects of Terrarium Surround Sound and Fan Letter");
            DisplayName.AddTranslation(GameCulture.Chinese, "元素之灵魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'万物都臣服于你的力量...'
泰拉瑞亚的能量试图保护你
攻击敌人时偶尔会召唤暂时存在的潜水员
暴击短暂缓慢所有附近敌人
拥有精准项链和大恢复戒指的效果
拥有粉丝的信函和界元音箱的效果");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB));
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10; //rainbow
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //terrarium set bonus
            timer++;
            if (timer > 60)
            {
                Projectile.NewProjectile(player.Center.X + 14f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 0f);
                Projectile.NewProjectile(player.Center.X + 9f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 1f);
                Projectile.NewProjectile(player.Center.X + 4f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 2f);
                Projectile.NewProjectile(player.Center.X, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 3f);
                Projectile.NewProjectile(player.Center.X - 4f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 4f);
                Projectile.NewProjectile(player.Center.X - 9f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 5f);
                Projectile.NewProjectile(player.Center.X - 14f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerrariumSetPro"), 50, 0f, Main.myPlayer, 0f, 6f);
                timer = 0;
            }
            //subwoofer
            thoriumPlayer.accSubwooferTerrarium = true;

            //diverman meme
            modPlayer.ThoriumEnchant = true;
            //crietz
            thorium.GetItem("Crietz").UpdateAccessory(player, hideVisual);
            //band of replenishment
            thoriumPlayer.accReplenishment = true;
            //jester bonus
            modPlayer.JesterEnchant = true;
            //fan letter
            thoriumPlayer.bardResourceMax2 += 2;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<TerrariumHelmet>());
            recipe.AddIngredient(ModContent.ItemType<TerrariumBreastPlate>());
            recipe.AddIngredient(ModContent.ItemType<TerrariumGreaves>());
            recipe.AddIngredient(ModContent.ItemType<ThoriumEnchant>());
            recipe.AddIngredient(ModContent.ItemType<TerrariumSubwoofer>());
            recipe.AddIngredient(ModContent.ItemType<ThoriumCube>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
