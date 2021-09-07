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
Effects of Full Score, Metronome, and Conductor's Baton");
            DisplayName.AddTranslation(GameCulture.Chinese, "指挥魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'我就是现代巴赫'
按下'特殊能力'键召唤亡灵合唱团
掉落的灵感音符双倍强度, 短暂增加音波伤害
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
            //maestro
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.setMaestro = true;

            if (player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul) return;
            //metronome
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.Metronome))
            {
                thorium.GetItem("Metronome").UpdateAccessory(player, hideVisual);
            }
            //conductor's baton
            thorium.GetItem("ConductorsBaton").UpdateAccessory(player, hideVisual);
            //marching band
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.MarchingBand))
            {
                thoriumPlayer.setMarchingBand = true;
            }
            //full score
            thorium.GetItem("FullScore").UpdateAccessory(player, hideVisual);
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

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
