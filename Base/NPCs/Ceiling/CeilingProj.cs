using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC.Base.NPCs.Ceiling
{
    public class CeilingProj : ModProjectile
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Ceiling of Moon Lord");
        }

        public override void SetDefaults()
        {
            projectile.width = 420;
            projectile.height = 190;
            projectile.ignoreWater = true;
            projectile.tileCollide = false;
            projectile.hide = true;
            //projectile.GetGlobalProjectile<Projectiles.FargoGlobalProjectile>().TimeFreezeImmune = true;
        }

        public override void DrawBehind(int index, List<int> drawCacheProjsBehindNPCsAndTiles, List<int> drawCacheProjsBehindNPCs, List<int> drawCacheProjsBehindProjectiles, List<int> drawCacheProjsOverWiresUI)
        {
            if (projectile.hide)
                drawCacheProjsBehindNPCs.Add(index);
        }

        public override void AI()
        {
            int ai1 = (int)projectile.ai[1];
            if (projectile.ai[1] >= 0f && projectile.ai[1] < 200f &&
                Main.npc[ai1].active && Main.npc[ai1].type == ModContent.NPCType<CeilingOfMoonLord>())
            {
                projectile.Center = Main.npc[ai1].Center;
                projectile.timeLeft = 2;
            }
            else
            {
                projectile.Kill();
                return;
            }
        }

        public override bool CanDamage()
        {
            return false;
        }

        public override Color? GetAlpha(Color lightColor)
        {
            return Color.White;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.projectileTexture[projectile.type];
            int num156 = Main.projectileTexture[projectile.type].Height / Main.projFrames[projectile.type]; //ypos of lower right corner of sprite to draw
            int y3 = num156 * projectile.frame; //ypos of upper left corner of sprite to draw
            Rectangle rectangle = new Rectangle(0, y3, texture2D13.Width, num156);
            Vector2 origin2 = rectangle.Size() / 2f;

            for (int i = 0; i < Main.screenWidth; i += 210)
            {
                Vector2 drawPos = new Vector2(Main.screenPosition.X + i, projectile.Center.Y - 50);
                Main.spriteBatch.Draw(texture2D13, drawPos - Main.screenPosition + new Vector2(0f, projectile.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), projectile.GetAlpha(lightColor), projectile.rotation, origin2, projectile.scale, SpriteEffects.None, 0f);
            }
            return false;
        }
    }
}