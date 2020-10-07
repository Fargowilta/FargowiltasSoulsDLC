using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.DD;
using ThoriumMod.Items.Hero;
using ThoriumMod.Items.QueenJelly;
using ThoriumMod.Items.Scouter;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class MalignantEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Malignant Enchantment");
            Tooltip.SetDefault(
@"'How evil is too evil?'
Critical strikes engulf enemies in a long lasting void flame
Effects of Mana-Charged Rocketeers");
            DisplayName.AddTranslation(GameCulture.Chinese, "妖术魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'要多邪恶才能算得上太邪恶呢?'
暴击释放虚空之焰吞没敌人
拥有魔力充能火箭靴的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            modPlayer.MalignantEnchant = true;
            //mana charge rockets
            thorium.GetItem("ManaChargedRocketeers").UpdateAccessory(player, hideVisual);

            //enchantedshield
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<MalignantCap>());
            recipe.AddIngredient(ModContent.ItemType<MalignantRobe>());
            recipe.AddIngredient(ModContent.ItemType<SilkEnchant>());
            recipe.AddIngredient(ModContent.ItemType<ManaChargedRocketeers>());
            recipe.AddIngredient(ModContent.ItemType<EnchantedShield>());
            recipe.AddIngredient(ModContent.ItemType<JellyPondWand>());
            recipe.AddIngredient(ModContent.ItemType<DarkTome>());
            recipe.AddIngredient(ModContent.ItemType<ChampionBomberStaff>());
            recipe.AddIngredient(ModContent.ItemType<GaussSpark>());
            recipe.AddIngredient(ItemID.PurpleEmperorButterfly);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
