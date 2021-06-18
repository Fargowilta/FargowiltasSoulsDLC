using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.MagicItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Blizzard;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class WhiteKnightEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("White Knight Enchantment");
            Tooltip.SetDefault(
@"'Protect e-girls at all costs'
Enemies that attack friendly NPCs are marked as Villains
You deal 50% bonus damage to Villains
Effects of Shade Band");
            DisplayName.AddTranslation(GameCulture.Chinese, "白骑士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'不惜一切代价保护电工妹'
攻击友善NPC的敌人将被标记为恶棍
对恶棍造成50%额外伤害
拥有暗影护符的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //shade band
            thoriumPlayer.shadeBand = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<WhiteKnightMask>());
            recipe.AddIngredient(ModContent.ItemType<WhiteKnightTabard>());
            recipe.AddIngredient(ModContent.ItemType<WhiteKnightLeggings>());
            recipe.AddIngredient(ModContent.ItemType<ShadeBand>());
            recipe.AddIngredient(ModContent.ItemType<PrismiteStaff>());
            recipe.AddIngredient(ModContent.ItemType<VileSpitter>());
            recipe.AddIngredient(ModContent.ItemType<FrostFang>());
            recipe.AddIngredient(ModContent.ItemType<TitaniumStaff>());
            recipe.AddIngredient(ModContent.ItemType<DynastyWarFan>());
            recipe.AddIngredient(ItemID.SkyFracture);

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
