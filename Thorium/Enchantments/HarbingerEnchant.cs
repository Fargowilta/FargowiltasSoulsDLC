using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Harbinger;
using ThoriumMod.Items.MagicItems;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class HarbingerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Harbinger Enchantment");
            Tooltip.SetDefault(
@"'Doom comes next'
Maximum mana increased by 50%
While above 75% maximum mana, you become unstable
Enemies that attack friendly NPCs are marked as Villains
You deal 50% bonus damage to Villains
Effects of Shade Band");
            DisplayName.AddTranslation(GameCulture.Chinese, "先知魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'末日将至'
增加50%最大法力值
法力值高于75%时变得不稳定
攻击友善NPC的敌人将被标记为恶棍
对恶棍造成50%额外伤害
拥有暗影护符和白色播放器的效果
召唤宠物小喵");
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
            //set bonus
            player.statManaMax2 += (int)(player.statManaMax2 * 0.5);
            if (player.statMana > (int)(player.statManaMax2 * 0.75) || player.statMana > 300)
            {
                player.AddBuff(thorium.BuffType("Overcharge"), 2, true);
                player.magicDamage += 0.5f;
                player.magicCrit += 26;
            }
            //shade band
            thoriumPlayer.shadeBand = true;
            //villain damage 
            modPlayer.KnightEnchant = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<HarbingerHelmet>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerChestGuard>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<WhiteKnightEnchant>());
            recipe.AddIngredient(ModContent.ItemType<BlackholeCannon>());
            recipe.AddIngredient(ModContent.ItemType<SpiritStaff>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
