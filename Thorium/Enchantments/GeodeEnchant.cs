using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Geode;
using ThoriumMod.Items.Misc;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Tracker;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class GeodeEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Geode Enchantment");
            Tooltip.SetDefault(
@"'Made from the most luxurious of materials'
50% increased mining speed
Shows the location of enemies, traps, and treasures
Light is emitted from the player
Summons a pet Magic Lantern and Lock Box");
            DisplayName.AddTranslation(GameCulture.Chinese, "晶体魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'用极尽奢华的材料制成'
增加50%采掘速度
显示敌人，陷阱和宝藏位置
散发光芒
召唤魔法灯笼, 振奋魔镜和海神宝盒");
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

            //increase range from crystallinecharm

            thoriumPlayer.geodeShine = true;
            Lighting.AddLight(player.position, 1.2f, 0.8f, 1.2f);
            //pets
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.BoxPet, hideVisual, thorium.BuffType("LockBoxBuff"), thorium.ProjectileType("LockBoxPet"));
            //mining speed, spelunker, dangersense, light, hunter, pet
            //modPlayer.MinerEffect(hideVisual, .5f);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<GeodeHelmet>());
            recipe.AddIngredient(ModContent.ItemType<GeodeChestplate>());
            recipe.AddIngredient(ModContent.ItemType<GeodeGreaves>());
            //recipe.AddIngredient(ModContent.ItemType<MinerEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CrystalineCharm>());
            recipe.AddIngredient(ModContent.ItemType<EnchantedPickaxe>());
            recipe.AddIngredient(ModContent.ItemType<GnomePick>());
            recipe.AddIngredient(ModContent.ItemType<CrystalPhaser>());
            recipe.AddIngredient(ModContent.ItemType<Lantern>());
            recipe.AddIngredient(ModContent.ItemType<JonesLockBox>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
