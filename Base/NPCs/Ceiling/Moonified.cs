using Terraria;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Base.NPCs.Ceiling
{
    public class Moonified : ModBuff
    {
        public override void SetDefaults()
        {
            DisplayName.SetDefault("Moonified");
            Description.SetDefault("There is a giant moon coming for you, who wouldn't be scared?\nOh, by the way, you can't escape.");
            Main.debuff[Type] = true;
            Main.buffNoSave[Type] = true;
            Main.buffNoTimeDisplay[Type] = true;
            longerExpertDebuff = false;
            canBeCleared = false;
        }
    }
}