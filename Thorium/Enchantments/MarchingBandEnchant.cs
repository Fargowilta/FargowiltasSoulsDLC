using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class MarchingBandEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Marching Band Enchantment");
            Tooltip.SetDefault(
@"'Step to the beat'
While in combat, a rainbow of damaging symphonic symbols will follow your movement and stun enemies");
            DisplayName.AddTranslation(GameCulture.Chinese, "仪仗队魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'脚步合拍'
在战斗中,一枚可眩晕敌人的彩虹音符会跟随你");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.MarchingBand))
            {
                //marching band set 
                thoriumPlayer.setMarchingBand = true;
            }

            //fullscore
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<MarchingBandCap>());
            recipe.AddIngredient(ModContent.ItemType<MarchingBandUniform>());
            recipe.AddIngredient(ModContent.ItemType<MarchingBandLeggings>());
            recipe.AddIngredient(ModContent.ItemType<FullScore>());
            recipe.AddIngredient(ModContent.ItemType<Cymbals>());
            recipe.AddIngredient(ModContent.ItemType<Violin>());
            recipe.AddIngredient(ModContent.ItemType<Trombone>());
            recipe.AddIngredient(ModContent.ItemType<SummonerWarhorn>());
            recipe.AddIngredient(ModContent.ItemType<Tuba>());
            recipe.AddIngredient(ModContent.ItemType<DragonsWail>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
