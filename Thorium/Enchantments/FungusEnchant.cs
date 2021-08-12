using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.MiniBoss;
using ThoriumMod.Items.MagicItems;
using ThoriumMod.Items.Consumable;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class FungusEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fungus Enchantment");
            Tooltip.SetDefault(
@"'There's a fungus among us'
Damage done against mycelium infected enemies is increased by 10%
Dealing damage to enemies infected with mycelium briefly increases throwing speed by 10%");
            DisplayName.AddTranslation(GameCulture.Chinese, "真菌魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'我们中出了个真菌'
对真菌寄生状态的敌人加伤10%
攻击真菌寄生状态的敌人能增加10%投掷速度");
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

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            thoriumPlayer.setFungus = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FungusHat>());
            recipe.AddIngredient(ModContent.ItemType<FungusGuard>());
            recipe.AddIngredient(ModContent.ItemType<FungusLeggings>());

            recipe.AddIngredient(ModContent.ItemType<SporeBook>());
            recipe.AddIngredient(ModContent.ItemType<SwampSpike>());
            recipe.AddIngredient(ModContent.ItemType<SporeCoatingItem>(), 10);
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
