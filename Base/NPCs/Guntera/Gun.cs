using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Base.NPCs.Guntera
{
    public class Gun : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("gun");
            Description.SetDefault("gun");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = true;
        }
    }
}