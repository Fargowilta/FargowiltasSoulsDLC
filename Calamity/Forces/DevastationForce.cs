using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Calamity.Forces
{
    public class DevastationForce : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Devastation");
            Tooltip.SetDefault(
@"'Rain hell down on those who resist your power'
All armor bonuses from Wulfrum, Reaver, Plague Reaper, and Demonshade
Effects of Trinket of Chi and Plague Hive
Effects of Plagued Fuel Pack, The Camper, and Profaned Soul Crystal");
            DisplayName.AddTranslation(GameCulture.Chinese, "毁灭之力");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'让那些反抗你的人下地狱吧'
拥有钨钢, 掠夺者，瘟疫死神和魔影的套装效果
拥有气功念珠，传说龟壳和瘟疫蜂巢的效果
拥有瘟疫燃料背包，蜜蜂护符，露营者和渎神魂晶的效果
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

            mod.GetItem("WulfrumEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("ReaverEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("PlagueReaperEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("DemonShadeEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "WulfrumEnchant");
            recipe.AddIngredient(null, "ReaverEnchant");
            recipe.AddIngredient(null, "PlagueReaperEnchant");
            recipe.AddIngredient(null, "DemonShadeEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
