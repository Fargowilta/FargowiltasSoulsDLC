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
While in combat, a rainbow of damaging symphonic symbols will follow your movement and stun enemies
Effects of Full Score");
            DisplayName.AddTranslation(GameCulture.Chinese, "仪仗队魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'脚步合拍'
掉落的灵感音符双倍强度, 短暂增加音波伤害");
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

            thorium.GetItem("FullScore").UpdateAccessory(player, hideVisual);
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
            recipe.AddIngredient(ModContent.ItemType<SummonerWarhorn>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
