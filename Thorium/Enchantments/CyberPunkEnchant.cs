using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Empowerments;
using ThoriumMod.Items;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class CyberPunkEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyber Punk Enchantment");
            Tooltip.SetDefault(
@"'Techno rave!'
Pressing the 'Special Ability' key will cycle you through four states
Effects of Auto Tuner, Metal Music Player, and Diss Track");
            DisplayName.AddTranslation(GameCulture.Chinese, "赛博朋克魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'科技电音狂欢!'
按下'特殊能力'键循环切换增幅状态
拥有自动校音器和红色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.CyberStates))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("CyberPunkHeadset").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }
                
            thorium.GetItem("AutoTuner").UpdateAccessory(player, hideVisual);
            thorium.GetItem("TunePlayerDamage").UpdateAccessory(player, hideVisual);
            thorium.GetItem("DissTrack").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<CyberPunkHeadset>());
            recipe.AddIngredient(ModContent.ItemType<CyberPunkSuit>());
            recipe.AddIngredient(ModContent.ItemType<CyberPunkLeggings>());
            recipe.AddIngredient(ModContent.ItemType<AutoTuner>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerDamage>());
            recipe.AddIngredient(ModContent.ItemType<DissTrack>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
