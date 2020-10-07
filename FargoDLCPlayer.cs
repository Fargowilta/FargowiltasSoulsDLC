using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC
{
    public partial class FargoDLCPlayer : ModPlayer
    {
        public bool PetsActive = true;

        public override void ResetEffects()
        {
            if(FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumResetEffects();

            if (FargowiltasSoulsDLC.Instance.CalamityLoaded)
                CalamityResetEffects();

            PetsActive = true;
        }

        public override void PostUpdate()
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumPostUpdate();
        }

        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref int damage, ref float knockback, ref bool crit, ref int hitDirection)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumModifyProj(proj, target, damage, crit);
        }

        public override void ModifyHitNPC(Item item, NPC target, ref int damage, ref float knockback, ref bool crit)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumModifyNPC(target, item, damage, crit);
        }

        public override void OnHitNPCWithProj(Projectile proj, NPC target, int damage, float knockback, bool crit)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumHitProj(proj, target, damage, crit);
        }

        public override void OnHitNPC(Item item, NPC target, int damage, float knockback, bool crit)
        {
            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
                ThoriumHitNPC(target, item, crit);
        }

        public void AllDamageUp(float dmg)
        {
            player.magicDamage += dmg;
            player.meleeDamage += dmg;
            player.rangedDamage += dmg;
            player.minionDamage += dmg;

            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
            {
                ThoriumDamage(dmg);
            }
        }

        public void AllCritUp(int crit)
        {
            player.meleeCrit += crit;
            player.rangedCrit += crit;
            player.magicCrit += crit;

            if (FargowiltasSoulsDLC.Instance.ThoriumLoaded)
            {
                ThoriumCrit(crit);
            }
        }

        public void AddPet(bool toggle, bool vanityToggle, int buff, int proj)
        {
            if (vanityToggle)
            {
                PetsActive = false;
                return;
            }

            if (SoulConfig.Instance.GetValue(toggle) && player.FindBuffIndex(buff) == -1 && player.ownedProjectileCounts[proj] < 1)
            {
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, proj, 0, 0f, player.whoAmI);
            }
        }

        public void AddMinion(bool toggle, int proj, int damage, float knockback)
        {
            if (player.ownedProjectileCounts[proj] < 1 && player.whoAmI == Main.myPlayer && SoulConfig.Instance.GetValue(toggle))
                Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, proj, damage, knockback, Main.myPlayer);
        }
    }
}
