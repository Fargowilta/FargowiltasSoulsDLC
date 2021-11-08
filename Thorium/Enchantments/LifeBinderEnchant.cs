using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.ThrownItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class LifeBinderEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Life Binder Enchantment");
            Tooltip.SetDefault(
@"'Vegetation grows from your fingertips'
Healing spells will shortly increase the healed player's maximum life by 50
Your radiant damage has a 15% chance to release a blinding flash of light
The flash heals nearby allies equal to your bonus healing and confuses enemies
Effects of Aloe Leaf and Equalizer");
            DisplayName.AddTranslation(GameCulture.Chinese, "生命束缚者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'植物从你的之间生长'
治疗队友将会短暂增加其50最大生命值
光辉伤害有15%概率造成闪光爆炸
闪光爆炸将迷惑敌人并治疗队友(受额外治疗量影响)
拥有芦荟叶和平等护符效果
召唤宠物神圣山羊");
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

            string oldSetBonus = player.setBonus;
            thorium.GetItem("DewBinderMask").UpdateArmorSet(player);
            player.setBonus = oldSetBonus;

            mod.GetItem("IridescentEnchant").UpdateAccessory(player, hideVisual);

            thorium.GetItem("DewCollector").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DewBinderMask>());
            recipe.AddIngredient(ModContent.ItemType<DewBinderBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<DewBinderGreaves>());
            recipe.AddIngredient(ModContent.ItemType<IridescentEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DewCollector>());
            recipe.AddIngredient(ModContent.ItemType<SunrayStaff>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
