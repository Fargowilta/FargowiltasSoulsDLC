using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Blizzard;
using ThoriumMod.Items.MagicItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class CryomancerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cryomancer Enchantment");
            Tooltip.SetDefault(
@"'What killed the dinosaurs? The ice age!'
Your damage will freeze enemies for two seconds
An icy aura surrounds you, which freezes nearby enemies after a short delay
Effects of Ice Bound Strider Hide");
            DisplayName.AddTranslation(GameCulture.Chinese, "冰法魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'是什么灭绝了恐龙? 冰河时代!'
攻击将产生此次伤害值33%的冰刺攻击敌人, 并对敌人造成冻结效果
环绕的冰锥将冰冻敌人
拥有霜火粉袋, 遁蛛契约和蓝色播放器的效果
召唤宠物企鹅和猫头鹰");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //cryo set bonus, dmg duplicate
            modPlayer.CryoEnchant = true;
            //strider hide
            thoriumPlayer.frostBonusDamage = true;

            mod.GetItem("IcyEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<CryomancersCrown>());
            recipe.AddIngredient(ModContent.ItemType<CryomancersTabard>());
            recipe.AddIngredient(ModContent.ItemType<CryomancersLeggings>());
            recipe.AddIngredient(ModContent.ItemType<IcyEnchant>());
            recipe.AddIngredient(ModContent.ItemType<IceBoundStriderHide>());
            recipe.AddIngredient(ModContent.ItemType<IceFairyStaff>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
