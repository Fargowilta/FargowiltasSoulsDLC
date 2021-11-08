using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Berserker;
using ThoriumMod.Items.MeleeItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.FallenBeholder;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class BerserkerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
       
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Berserker Enchantment");
            Tooltip.SetDefault(
@"'I'd rather fight for my life than live it'
Attack speed is increased by 5% at every 25% segment of life
Fire surrounds your armour and melee weapons
Enemies that you set on fire or singe will take additional damage over time
Effects of Spring Steps, Slag Stompers, Molten Spear Tip, and Rapier Badge");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂战士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'我更愿意为自己的生命而战斗, 而不只是为活而活'
生命值每下降25%, 增加15%伤害
随着时间的推移,被你点燃或烧伤的敌人会受到额外的伤害
点燃附近敌人
死亡时剧烈爆炸,造成大量伤害
拥有弹簧鞋和熔渣重踏的效果
拥有炽热枪尖和橙色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BerserkerEffect))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("BerserkerMask").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }

            mod.GetItem("MagmaEnchant").UpdateAccessory(player, hideVisual);
            thorium.GetItem("RapierBadge").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<BerserkerMask>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<MagmaEnchant>());
            recipe.AddIngredient(ModContent.ItemType<RapierBadge>());
            recipe.AddIngredient(ModContent.ItemType<WyvernSlayer>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
