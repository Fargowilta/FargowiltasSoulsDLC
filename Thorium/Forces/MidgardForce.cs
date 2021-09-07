using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class MidgardForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int lightGen;
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Midgard");
            Tooltip.SetDefault(
@"'Behold the power of Mankind...'
All armor bonuses from Lodestone, Valadium, Illumite, and Shade Master
All armor bonuses from Jester, Thorium, and Terrarium
Effects of Astro-Beetle Husk, Obsidian Scale, Mirror of the Beholder, and Jazz Music Player
Effects of Crietz, Band of Replenishment, Fan Letter, and Terrarium Surround Sound");
            DisplayName.AddTranslation(GameCulture.Chinese, "米德加德之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'人类的力量'
生命值每下降25%, 增加10%伤害减免
生命值低于50%时达到上限: 30%
按'上'键逆转重力
重力颠倒时增加12%远程伤害
每3次攻击会发射荧光导弹
泰拉瑞亚的能量试图保护你
攻击敌人时偶尔会召唤暂时存在的潜水员
暴击短暂缓慢所有附近敌人
拥有太空甲虫壳和注者之眼的效果
拥有精准项链和界元音箱的效果
召唤宠物粉红史莱姆");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            //lodestone
            mod.GetItem("LodestoneEnchant").UpdateAccessory(player, hideVisual);

            //obsidianscale
            thorium.GetItem("ObsidianScale").UpdateAccessory(player, true);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BeholderEye))
            {
                //mirror of beholder
                thorium.GetItem("EyeofBeholder").UpdateAccessory(player, hideVisual);
            }

            //shade
            thoriumPlayer.setShade = true;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TerrariumSpirits))
            {
                //terrarium set bonus
                timer++;
                if (timer > 60)
                {
                    Projectile.NewProjectile(player.Center.X + 14f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraRed"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X + 9f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraOrange"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X + 4f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraYellow"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraGreen"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X - 4f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraBlue"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X - 9f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraIndigo"), 50, 0f, Main.myPlayer, 0f, 0f);
                    Projectile.NewProjectile(player.Center.X - 14f, player.Center.Y - 20f, 0f, 2f, thorium.ProjectileType("TerraPurple"), 50, 0f, Main.myPlayer, 0f, 0f);
                    timer = 0;
                }
            }
            //diverman meme
            modPlayer.ThoriumEnchant = true;
            //jester
            modPlayer.JesterEnchant = true;
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.Crietz))
            {
                //crietz
                thorium.GetItem("Crietz").UpdateAccessory(player, hideVisual);
            }
            //band of replenishment
            thoriumPlayer.accReplenishment = true;
            //fan letter
            thoriumPlayer.bardResourceMax2 += 2;

            if (modPlayer.ThoriumSoul) return;

            //valadium
            //if (SoulConfig.Instance.GetValue(SoulConfig.Instance.GravityControl))
            //{
                player.gravControl = true;
                if (player.gravDir == -1f)
                {
                    modPlayer.AllDamageUp(.12f);
                }
            //}
            //music player
            thorium.GetItem("TunePlayerLifeRegen").UpdateAccessory(player, true);
            //terrarium woofer
            thoriumPlayer.accSubwooferTerrarium = true;

        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "LodestoneEnchant");
            recipe.AddIngredient(null, "ValadiumEnchant");
            recipe.AddIngredient(null, "IllumiteEnchant");
            recipe.AddIngredient(null, "ShadeMasterEnchant");
            recipe.AddIngredient(null, "TerrariumEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
