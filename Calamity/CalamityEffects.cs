using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;

namespace FargowiltasSoulsDLC
{
    public partial class FargoDLCPlayer : ModPlayer
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        //calamity
        public bool AerospecEnchant;
        public bool AstralEnchant;
        public bool BrimflameEnchant;
        public bool ReaverEnchant;
        public bool StatigelEnchant;
        public bool DaedalusEnchant;
        public bool AtaxiaEnchant;
        public bool MolluskEnchant;
        public bool OmegaBlueEnchant;
        public bool GodSlayerEnchant;
        public bool SilvaEnchant;
        public bool DemonShadeEnchant;
        public bool SulphurEnchant;
        public bool FathomEnchant;

        public void CalamityResetEffects()
        {
            //calamity
            AerospecEnchant = false;
            AstralEnchant = false;
            BrimflameEnchant = false;
            ReaverEnchant = false;
            SulphurEnchant = false;
            StatigelEnchant = false;
            DaedalusEnchant = false;
            AtaxiaEnchant = false;
            MolluskEnchant = false;
            OmegaBlueEnchant = false;
            GodSlayerEnchant = false;
            SilvaEnchant = false;
            DemonShadeEnchant = false;
            FathomEnchant = false;
        }
    }
}
