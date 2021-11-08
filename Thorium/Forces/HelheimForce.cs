using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class HelheimForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Helheim");
            Tooltip.SetDefault(
@"'From the halls of Hel, a vision of the end...'
All armor bonuses from Spirit Trapper, Dragon, Dread, Flesh, and Demon Blood
All armor bonuses from Magma, Berserker, White Knight, and Harbinger
Effects of Inner Flame, Crash Boots, and Dragon Talon Necklace
Effects of Vile Flail-Core, Cursed Flail-Core, and Molten Spear Tip
Effects of Vampire Gland, Spring Steps, and Slag Stompers
Effects of Shade Band");
            DisplayName.AddTranslation(GameCulture.Chinese, "海姆冥界之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'从海姆冥界的大厅起始, 一派终末的景象...'
杀死敌人或持续攻击Boss会产生灵魂碎片
集齐5个后, 它们会立即被消耗, 治疗10点生命
你的靴子以不真实的频率振动着, 显著提高移动速度
移动时增加伤害和暴击率
攻击有概率释放龙焰爆炸
攻击提供'蓄血'Buff
充能完毕时, 你的下一次攻击会造成双倍伤害, 并将伤害的20%转化为治疗
连续攻击敌人时概率掉落肉, 拾取肉会获得额外生命并增加伤害
生命值高于75%时变得不稳定
攻击友善NPC的敌人将被标记为恶棍
对恶棍造成50%额外伤害
瓦斯持续时间翻倍, 瓦斯反应多造成20%伤害
杀死敌人会释放灵魂碎片
拥有心灵之火, 震地靴, 龙爪项链和恐惧音箱的效果
拥有吸血鬼试剂, 魔血纹章和血魔音箱的效果
拥有暗影护符, 巫妖之视和瘟疫之主药剂瓶的效果
召唤数个宠物");
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

            mod.GetItem("SpiritTrapperEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("DreadEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("DemonBloodEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("BerserkerEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("HarbingerEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<SpiritTrapperEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DreadEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DemonBloodEnchant>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerEnchant>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerEnchant>());

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
