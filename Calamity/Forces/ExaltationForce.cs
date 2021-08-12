using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Calamity.Forces
{
    public class ExaltationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Exaltation");
            Tooltip.SetDefault(
@"''
All armor bonuses from Tarragon, Bloodflare, and Brimflame
All armor bonuses from God Slayer, Silva, and Auric
Effects of Blazing Core, Dark Sun Ring, and Core of the Blood God
Effects of Nebulous Core and Draedon's Heart
Effects of the The Amalgam and Godly Soul Artifact
Effects of Yharim's Gift, Heart of the Elements, and The Sponge");
            DisplayName.AddTranslation(GameCulture.Chinese, "晋升之力");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"''
拥有龙蒿，血炎和硫火的套装效果
拥有弑神者，始源林海和古圣金源的套装效果
拥有渎火核心，蚀日尊戒和血神核心的效果
拥有灾劫之尖啸，星云核心和嘉登之心的效果
拥有聚合之脑，痴愚金龙干细胞和圣魂神物的效果
拥有魔君的礼物，元素之心和化绵留香石的效果");

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

            mod.GetItem("TarragonEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("BloodflareEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("GodSlayerEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("SilvaEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("AuricEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "TarragonEnchant");
            recipe.AddIngredient(null, "BloodflareEnchant");
            recipe.AddIngredient(null, "GodSlayerEnchant");
            recipe.AddIngredient(null, "SilvaEnchant");
            recipe.AddIngredient(null, "AuricEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
