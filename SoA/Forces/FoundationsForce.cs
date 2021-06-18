using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;

namespace FargowiltasSoulsDLC.SoA.Forces
{
    public class FoundationsForce : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Foundations");
            Tooltip.SetDefault(
@"':HeyMF:'
All armor bonuses from Prairie, Frosthunter, Lapis, and Blightbone
Effects of Frigid Pendant, Lapis Pendant, and Dreadflame Emblem");
            DisplayName.AddTranslation(GameCulture.Chinese, "基层之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
拥有Prairie, 霜冻猎人，青金石和荒骨的套装效果
拥有青金石挂饰, 极寒吊坠和南瓜护身符的效果");
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
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //lapis pendant
            modPlayer.LapisPendant = true;
            //frosthunter
            modPlayer.frostburnRanged = true;
            //frigid pendant
            modPlayer.decreePendant = true;
            if (hideVisual)
            {
                modPlayer.decreePendantHide = true;
            }
            //blightbone
            modPlayer.blightEmpowerment = true;
            //dreadflame emblem
            modPlayer.dreadEmblem = true;

            //pets soon tm
        }


        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "PrairieEnchant");
            recipe.AddIngredient(null, "LapisEnchant");
            recipe.AddIngredient(null, "FrosthunterEnchant");
            recipe.AddIngredient(null, "BlightboneEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
