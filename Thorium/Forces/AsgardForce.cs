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
All armor bonuses from Dream Weaver and Rhapsodist");
            DisplayName.AddTranslation(GameCulture.Chinese, "阿斯加德之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'诸神黄昏是怎么回事?'
拥有洪流逆潮者，刺客和炎法的套装效果
拥有织梦者和狂想者的套装效果");
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
            //pyro
            modPlayer.PyroEnchant = true;
            thoriumPlayer.napalmSet = true;
            //dream weaver
            thoriumPlayer.dreamHoodSet = true;
            thoriumPlayer.dreamSet = true;

            if (modPlayer.ThoriumSoul) return;

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
