using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Misc;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class FallenPaladinEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Paladin Enchantment");
            Tooltip.SetDefault(
@"'Silently, they walk the dungeon halls'
Taking damage heals nearby allies equal to 15% of the damage taken
If an ally is below half health, you will gain increased healing abilities
Effects of Prydwen and Nirvana Statuette");
            DisplayName.AddTranslation(GameCulture.Chinese, "堕落圣骑士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'静静地在地牢游荡'
受到伤害的15%将治疗附近队友
队友生命值低于50%时, 增加治疗量
拥有祝福之盾和重生雕像的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded || player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul) return;

            string oldSetBonus = player.setBonus;
            thorium.GetItem("FallenPaladinFacegaurd").UpdateArmorSet(player);
            thorium.GetItem("Wynebgwrthucher").UpdateAccessory(player, hideVisual);
            thorium.GetItem("NirvanaStatuette").UpdateAccessory(player, hideVisual);
            thorium.GetItem("TemplarsCirclet").UpdateArmorSet(player);
            player.setBonus = oldSetBonus;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FallenPaladinFacegaurd>());
            recipe.AddIngredient(ModContent.ItemType<FallenPaladinCuirass>());
            recipe.AddIngredient(ModContent.ItemType<FallenPaladinGreaves>());
            recipe.AddIngredient(ModContent.ItemType<TemplarEnchant>());
            recipe.AddIngredient(ModContent.ItemType<Wynebgwrthucher>());
            recipe.AddIngredient(ModContent.ItemType<NirvanaStatuette>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
