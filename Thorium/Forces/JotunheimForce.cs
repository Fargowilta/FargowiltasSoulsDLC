using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;
using FargowiltasSouls;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class JotunheimForce : ModItem
    {
        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Jotunheim");
            Tooltip.SetDefault(
@"'A bitter cold, the power of the Jotuns...'
All armor bonuses from Depth Diver, Yew Wood, and Tide Hunter
All armor bonuses from Naga Skin, Icy, Cryomancer, and Whispering
Effects of Sea Breeze Pendant and Bubble Magnet
Effects of Goblin War Shield, Agnor's Bowl, and Ice Bound Strider Hide");
            DisplayName.AddTranslation(GameCulture.Chinese, "约顿海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'彻骨严寒, 巨人的力量...'
获得水下呼吸能力
获得游泳和水下快速移动的能力
在水中时, 增加20%攻击速度
暴击释放飞溅泡沫, 缓慢附近的敌人
连续4次攻击不暴击时, 下一次远程攻击造成150%伤害
攻击将产生此次伤害值33%的冰刺攻击敌人, 并对敌人造成冻结效果
环绕的冰锥将冰冻敌人
偶尔在地面产生深渊能量触手攻击附近的敌人
最多产生6根触手, 触手的攻击将会为你偷取1点生命和法力
拥有海洋通行证, 泡泡磁铁和渊暗音箱的效果
拥有哥布林战盾, 琵琶鱼球碗和遁蛛契约的效果
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

            mod.GetItem("DepthDiverEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("TideHunterEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("NagaSkinEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("CryomancerEnchant").UpdateAccessory(player, hideVisual);
            mod.GetItem("WhisperingEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DepthDiverEnchant>());
            recipe.AddIngredient(ModContent.ItemType<TideHunterEnchant>());
            recipe.AddIngredient(ModContent.ItemType<NagaSkinEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CryomancerEnchant>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingEnchant>());

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
