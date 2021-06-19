using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class MaestroEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Maestro Enchantment");
            Tooltip.SetDefault(
@"'I'll be Bach'
Pressing the Special Ability key will summon a chorus of music playing ghosts
While in combat, a rainbow of damaging symphonic symbols will follow your movement and stun enemies
Effects of Metronome and Purple Music Player");
            DisplayName.AddTranslation(GameCulture.Chinese, "大师魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'我就是现代巴赫'
按下'套装能力'键以召唤鬼灵乐团
鬼灵会用铜管、风、弦和打击乐器迅速的对敌人造成伤害
拥有节拍器和粉色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.setMaestro = true;

            if (player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.Metronome))
            {
                thorium.GetItem("Metronome").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.MarchingBand))
            {
                thoriumPlayer.setMarchingBand = true;
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<MaestroWig>());
            recipe.AddIngredient(ModContent.ItemType<MaestroSuit>());
            recipe.AddIngredient(ModContent.ItemType<MaestroLeggings>());
            recipe.AddIngredient(ModContent.ItemType<MarchingBandEnchant>());
            recipe.AddIngredient(ModContent.ItemType<Metronome>());
            recipe.AddIngredient(ModContent.ItemType<ConductorsBaton>());
            recipe.AddIngredient(ModContent.ItemType<Organ>());
            recipe.AddIngredient(ModContent.ItemType<Clarinet>());
            recipe.AddIngredient(ModContent.ItemType<FrenchHorn>());
            recipe.AddIngredient(ModContent.ItemType<SpectralSymphonyPaint>());

           // purple music player e

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
