using Microsoft.Xna.Framework;
using System;
using Terraria;
using Terraria.DataStructures;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using Microsoft.Xna.Framework.Graphics;

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    public class GunSniper : GunCelebration
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sniper Rifle");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 62;
            npc.height = 24;
        }

        public override void Offset(NPC guntera)
        {
            npc.Center = guntera.Center + new Vector2(54 * npc.spriteDirection, -22).RotatedBy(guntera.rotation);
        }
    }
}