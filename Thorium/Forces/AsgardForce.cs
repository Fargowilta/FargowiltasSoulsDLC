using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class AsgardForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Asgard");
            Tooltip.SetDefault(
@"'What's this about Ragnarok?'
All armor bonuses from Tide Turner, Assassin, and Pyromancer
All armor bonuses from Dream Weaver and Rhapsodist
Effects of Dart Pouch");
            DisplayName.AddTranslation(GameCulture.Chinese, "阿斯加德之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'诸神黄昏是怎么回事?'
每0.5秒产生一颗浮球
每颗浮球都将增加防御力, 并使下一次投掷攻击变为小型暴击
攻击有20%概率释放6把会追踪的波纹飞刀
攻击有10%概率复制并增加15%伤害
攻击有5%概率即死敌人
攻击将焚烧目标及所有临近敌人
按下'特殊能力'键开启以下效果:
将你包裹在封闭泡泡中,
释放熔火之灵的余烬,
入梦并扭曲现实结构,
获得无限灵感, 增加音波伤害和演奏速度,
超载附近队友, 给予他们所有种类的3级咒音增幅
召唤宠物女仆");
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

            //tide turner
            mod.GetItem("TideTurnerEnchant").UpdateAccessory(player, hideVisual);
            //assassin
            modPlayer.AssassinEnchant = true;
            //dart pouch
            thorium.GetItem("DartPouch").UpdateAccessory(player, hideVisual);
            //pyro
            modPlayer.PyroEnchant = true;
            thoriumPlayer.napalmSet = true;
            //dream weaver
            thoriumPlayer.dreamHoodSet = true;
            thoriumPlayer.dreamSet = true;

            //rhapsodist
            //hotkey buff allies 
            thoriumPlayer.setInspirator = true;
            //hotkey buff self
            thoriumPlayer.setSoloist = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "TideTurnerEnchant");
            recipe.AddIngredient(null, "AssassinEnchant");
            recipe.AddIngredient(null, "PyromancerEnchant");
            recipe.AddIngredient(null, "DreamWeaverEnchant");
            recipe.AddIngredient(null, "RhapsodistEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
