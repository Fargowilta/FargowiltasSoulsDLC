using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class VanaheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Vanaheim");
            Tooltip.SetDefault(
@"'Holds a glimpse of the future...'
All armor bonuses from Lich, Plague Doctor, and White Dwarf
All armor bonuses from Celestial and Shooting Star
Effects of Lich's Gaze and Ascension Statuette");
            DisplayName.AddTranslation(GameCulture.Chinese, "华纳海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'对未来的一瞥...'
拥有巫妖，瘟疫医生和白矮星的套装效果
拥有大天使和流星爆破的套装效果
拥有巫妖之凝和飞升雕像效果");
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

            //lich set bonus
            modPlayer.LichEnchant = true;
            //lich gaze
            thoriumPlayer.lichGaze = true;
            //plague doctor
            thoriumPlayer.setPlague = true;

            //white dwarf
            modPlayer.WhiteDwarfEnchant = true;
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.CelestialAura))
            {
                //celestial
                thoriumPlayer.celestialSet = true;
            }

            if (modPlayer.ThoriumSoul) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.AscensionStatue))
            {
                //ascension statue
                thoriumPlayer.ascension = true;
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LichEnchant>());
            recipe.AddIngredient(ModContent.ItemType<WhiteDwarfEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CelestialEnchant>());
            recipe.AddIngredient(ModContent.ItemType<ShootingStarEnchant>());

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
