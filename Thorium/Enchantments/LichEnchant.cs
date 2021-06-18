using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Lich;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.Painting;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class LichEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lich Enchantment");
            Tooltip.SetDefault(
@"'Embrace death...'
Killing an enemy will release a soul fragment
Touching a soul fragment greatly increases your movement and throwing speed briefly
Your plague gas will linger in the air twice as long and your plague reactions will deal 20% more damage
Effects of Lich's Gaze");
            DisplayName.AddTranslation(GameCulture.Chinese, "巫妖魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'拥抱死亡...'
击杀敌人释放灵魂碎片
触碰灵魂碎片短暂地大幅增加你的投掷速度和移速
拥有巫妖之凝的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //plague effect
            thoriumPlayer.setPlague = true;
            //lich effect
            modPlayer.LichEnchant = true;
            //lich gaze
            thoriumPlayer.lichGaze = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LichCowl>());
            recipe.AddIngredient(ModContent.ItemType<LichCarapace>());
            recipe.AddIngredient(ModContent.ItemType<LichTalon>());
            recipe.AddIngredient(ModContent.ItemType<PlagueDoctorEnchant>());
            recipe.AddIngredient(ModContent.ItemType<LichGaze>());
            recipe.AddIngredient(ModContent.ItemType<SoulCleaver>());
            recipe.AddIngredient(ModContent.ItemType<SoulBomb>(), 300);
            recipe.AddIngredient(ModContent.ItemType<CadaverCornet>());
            recipe.AddIngredient(ModContent.ItemType<LethalInjection>());
            recipe.AddIngredient(ModContent.ItemType<PumpkinPaint>());

            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
