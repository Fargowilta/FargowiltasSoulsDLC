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
    public class GunShotgun : GunCelebration
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tactical Shotgun");
        }

        public override void SetDefaults()
        {
            base.SetDefaults();
            npc.width = 46;
            npc.height = 26;
        }

        public override void Offset(NPC guntera)
        {
            npc.Center = guntera.Center + new Vector2(-60, -10).RotatedBy(guntera.rotation);
        }
    }
}