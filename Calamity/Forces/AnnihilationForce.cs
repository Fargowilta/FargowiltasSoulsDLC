using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Calamity.Forces
{
    public class AnnihilationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Annihilation");
            Tooltip.SetDefault(
@"'Where once there was life and light, only ruin remains...'
All armor bonuses from Aerospec, Statigel, and Hydrothermic
All armor bonuses from Xeroc and Fearmonger
Effects of Gladiator's Locket and Unstable Prism
Effects of Counter Scarf and Fungal Symbiote
Effects of Hallowed Rune, Ethereal Extorter, and The Community
Effects of The Evolution, Spectral Veil, and Statis' Void Sash
Summons several pets");
            DisplayName.AddTranslation(GameCulture.Chinese, "湮灭之力");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'此地曾充满生命与光明, 现在只余废墟'
拥有天蓝, 斯塔提斯和渊泉的套装效果
拥有克希洛克，神惧者的套装效果
拥有角斗士金锁和不稳定棱晶的效果
拥有反击围巾和真菌共生体的效果
拥有神圣符文，虚空掠夺者和归一心元石的效果
拥有进化者，幽灵披风和斯塔提斯的虚空饰带的效果
召唤几个宠物");

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
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            mod.GetItem("AerospecEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("StatigelEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("AtaxiaEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("XerocEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("FearmongerEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "AerospecEnchant");
            recipe.AddIngredient(null, "StatigelEnchant");
            recipe.AddIngredient(null, "AtaxiaEnchant");
            recipe.AddIngredient(null, "XerocEnchant");
            recipe.AddIngredient(null, "FearmongerEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
