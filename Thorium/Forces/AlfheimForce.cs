using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class AlfheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Alfheim");
            Tooltip.SetDefault(
@"'Elven mysteries unfold before you...'
All armor bonuses from Novice Cleric, Sacred, Warlock, and Biotech
All armor bonuses from Iridescent, Life Binder, Templar, and Fallen Paladin
Effects of Demon Tongue, Dark Effigy, Aloe Leaf, and Equalizer
Effects of Karmic Holder, Wynebgwrthucher, and Rebirth Statuette
Summons a pet Life Spirit");
            DisplayName.AddTranslation(GameCulture.Chinese, "亚尔夫海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'精灵之秘在你眼前展开...'
拥有牧师学徒，圣崇，术士和生物工程的套装效果
拥有光耀，生命束缚者，圣殿骑士和堕落圣骑士的套装效果
拥有恶魔之舌，鬼影塑像，芦荟叶和平等护符的效果
拥有业果之握，祝福之盾和重生塑像的效果
召唤生命之灵宠物");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            //sacred
            mod.GetItem("SacredEnchant").UpdateAccessory(player, hideVisual);
            //warlock
            mod.GetItem("WarlockEnchant").UpdateAccessory(player, hideVisual);
            //biotech
            mod.GetItem("BiotechEnchant").UpdateAccessory(player, hideVisual);
            //life binder
            mod.GetItem("LifeBinderEnchant").UpdateAccessory(player, hideVisual);
            //fallen paladin
            mod.GetItem("FallenPaladinEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "SacredEnchant");
            recipe.AddIngredient(null, "WarlockEnchant");
            recipe.AddIngredient(null, "BiotechEnchant");
            recipe.AddIngredient(null, "LifeBinderEnchant");
            recipe.AddIngredient(null, "FallenPaladinEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
