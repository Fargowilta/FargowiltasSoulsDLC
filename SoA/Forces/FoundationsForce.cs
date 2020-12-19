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
            DisplayName.AddTranslation(GameCulture.Chinese, "世代之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'这么多年来, 从未出现过像你这样的人'
拥有铋, 霜冻猎人和荒骨的套装效果
拥有惧焰, 太空垃圾和火星科技的套装效果
拥有恐惧火焰徽记, 青金石挂饰, 极寒吊坠和南瓜护身符的效果
召唤数个宠物");
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