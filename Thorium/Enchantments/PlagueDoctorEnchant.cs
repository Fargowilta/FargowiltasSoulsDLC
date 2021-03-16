using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class PlagueDoctorEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Plague Doctor Enchantment");
            Tooltip.SetDefault(
@"'What nasty concoction could you be brewing?'
Your plague gas will linger in the air twice as long and your plague reactions will deal 20% more damage");
            DisplayName.AddTranslation(GameCulture.Chinese, "瘟疫医生魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'你都能酿出什么恶心的药剂呢?'
瓦斯持续时间翻倍, 瓦斯反应多造成20%伤害
杀死敌人会释放灵魂碎片
触摸灵魂碎片会在短时间内极大增加移动速度和投掷速度
拥有瘟疫之主药剂瓶和巫妖之视效果");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //plague effect
            thoriumPlayer.setPlague = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<PlagueDoctersMask>());
            recipe.AddIngredient(ModContent.ItemType<PlagueDoctersGarb>());
            recipe.AddIngredient(ModContent.ItemType<PlagueDoctersLeggings>());
            recipe.AddIngredient(ModContent.ItemType<GasContainer>(), 300);
            recipe.AddIngredient(ModContent.ItemType<CombustionFlask>(), 300);
            recipe.AddIngredient(ModContent.ItemType<NitrogenVial>(), 300);
            recipe.AddIngredient(ModContent.ItemType<CorrosionBeaker>(), 300);
            recipe.AddIngredient(ModContent.ItemType<AphrodisiacVial>(), 300);
            recipe.AddIngredient(ModContent.ItemType<RocketFist>());
            recipe.AddIngredient(ModContent.ItemType<FrostPlagueStaff>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
