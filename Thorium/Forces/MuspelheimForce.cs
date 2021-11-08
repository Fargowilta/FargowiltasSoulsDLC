using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;
using FargowiltasSouls;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class MuspelheimForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Muspelheim");
            Tooltip.SetDefault(
@"'A blazing heat, the mark of Surtr...'
All armor bonuses from Sandstone, Danger, Flight, and Fungus
All armor bonuses Living Wood, Blooming, and Life Bloom
Effects of Faberge Egg, Kick Petal, and Petal Shield
Effects of Nightshade Flower, Flawless Chrysalis, and Bee Booties");
            DisplayName.AddTranslation(GameCulture.Chinese, "穆斯贝尔海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'炽热之火, 史尔特尔的标志...'
沙暴增强了你的靴子, 能够额外跳跃一次
免疫一些造成伤害的Debuff
暴击获得野性咆哮效果, 并短暂增加召唤物伤害
攻击有33%的概率治疗你
召唤具有追踪攻击能力的小树苗
拥有无暇之蛹和植物纤维绳索宝典的效果");
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

            mod.GetItem("LifeBloomEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("SandstoneEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("DangerEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("FlightEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("FungusEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "SandstoneEnchant");
            recipe.AddIngredient(null, "DangerEnchant");
            recipe.AddIngredient(null, "FlightEnchant");
            recipe.AddIngredient(null, "FungusEnchant");
            recipe.AddIngredient(null, "LifeBloomEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
