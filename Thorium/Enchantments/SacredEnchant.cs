using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class SacredEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Sacred Enchantment");
            Tooltip.SetDefault(
@"'It glimmers with comforting power'
Healing potions heal 50% more life
Every 5 seconds you generate up to 3 holy crosses
When casting healing spells, a cross is used instead of mana
Effects of Karmic Holder");
            DisplayName.AddTranslation(GameCulture.Chinese, "圣骑士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'闪耀抚慰人心的力量'
生命药水额外回复50%生命值
每5秒产生一个圣十字架, 上限为3个
施放治疗法术时, 十字架将代替魔力消耗
召唤小天使周期性治疗队友
召唤宠物生命之灵");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            //sacred effect
            modPlayer.SacredEnchant = true;

            mod.GetItem("NoviceClericEnchant").UpdateAccessory(player, true);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.KarmicHolder))
            {
                thorium.GetItem("KarmicHolder").UpdateAccessory(player, true);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<HallowedPaladinHelmet>());
            recipe.AddIngredient(ModContent.ItemType<HallowedPaladinBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<HallowedPaladinLeggings>());
            recipe.AddIngredient(ModContent.ItemType<NoviceClericEnchant>());
            recipe.AddIngredient(ModContent.ItemType<KarmicHolder>());
            recipe.AddIngredient(ModContent.ItemType<Liberation>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
