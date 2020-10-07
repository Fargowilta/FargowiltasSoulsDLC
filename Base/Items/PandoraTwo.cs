using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Base.Items
{
    public class PandoraTwo : ModItem
    {
        private int[] projectiles = {15, 27, 45, 76, 77, 78, 88, 89, 95, 114, 116, 119, 120, 121, 122, 123, 124, 125, 126, 132, 156, 157, 172, 173, 189, 207, 
            225, 242, 253, 254, 261, 263, 270, 274, 278, 279, 280, 282, 283, 284, 285, 294, 295, 304, 306, 311, 321, 335, 336, 337, 338, 343, 356, 357, 399, 408, 409, 410, 
            424, 442, 444, 451, 461, 477, 478, 479, 483, 495, 496, 497, 502, 503, 510, 521, 523, 615, 617, 630, 636, 639, 659, 660, 661, 684, 700, 706, 710, 711, 712};
    
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pandora's Tome");
            Tooltip.SetDefault("A true mess of projectiles");
            DisplayName.AddTranslation(GameCulture.Chinese, "潘多拉之书");
            Tooltip.AddTranslation(GameCulture.Chinese, "一大堆抛射物");
        }

        public override void SetDefaults()
        {
            item.damage = 121;
            item.magic = true;
            item.width = 24;
            item.height = 28;
            item.useTime = 5;
            item.useAnimation = 10;
            item.useStyle = 5;
            item.noMelee = true;
            item.knockBack = 2;
            item.value = 1000;
            item.rare = 10;
            item.mana = 12;
            item.UseSound = SoundID.Item21;
            item.autoReuse = true;
            item.shoot = 1;
            item.shootSpeed = 18f;
        }

        public override bool Shoot(Player player, ref Vector2 position, ref float speedX, ref float speedY,
            ref int type, ref int damage, ref float knockBack)
        {
            float num72 = item.shootSpeed;
            int num73 = item.damage;
            float num74 = item.knockBack;
            num74 = player.GetWeaponKnockback(item, num74);
            player.itemTime = item.useTime;
            Vector2 vector2 = player.RotatedRelativePoint(player.MountedCenter);
            Vector2.UnitX.RotatedBy(player.fullRotation);
            float num78 = Main.mouseX + Main.screenPosition.X - vector2.X;
            float num79 = Main.mouseY + Main.screenPosition.Y - vector2.Y;
            if (player.gravDir == -1f) num79 = Main.screenPosition.Y + Main.screenHeight - Main.mouseY - vector2.Y;

            float num80 = (float) Math.Sqrt(num78 * num78 + num79 * num79);
            if (float.IsNaN(num78) && float.IsNaN(num79) || num78 == 0f && num79 == 0f)
            {
                num78 = player.direction;
                num79 = 0f;
                num80 = num72;
            }
            else
            {
                num80 = num72 / num80;
            }

            num78 *= num80;
            num79 *= num80;
            int num146 = 4;
            if (Main.rand.Next(2) == 0) num146++;

            if (Main.rand.Next(4) == 0) num146++;

            if (Main.rand.Next(8) == 0) num146++;

            if (Main.rand.Next(16) == 0) num146++;

            for (int num147 = 0; num147 < num146; num147++)
            {
                int r = projectiles[Main.rand.Next(projectiles.Length)];

                float num148 = num78;
                float num149 = num79;
                float num150 = 0.05f * num147;
                num148 += Main.rand.Next(-35, 36) * num150;
                num149 += Main.rand.Next(-35, 36) * num150;
                num80 = (float) Math.Sqrt(num148 * num148 + num149 * num149);
                num80 = num72 / num80;
                num148 *= num80;
                num149 *= num80;
                float x4 = vector2.X;
                float y4 = vector2.Y;

                Projectile.NewProjectile(x4, y4, num148, num149, r, num73, num74, Main.myPlayer);
            }

            return false;
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(null, "PandorasBox");
            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
