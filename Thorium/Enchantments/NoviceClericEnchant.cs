using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class NoviceClericEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Novice Cleric Enchantment");
            Tooltip.SetDefault(
@"'Cleansed of all evil'
Every 5 seconds you generate up to 3 holy crosses
When casting healing spells, a cross is used instead of mana
Effects of Nurse Purse");
            DisplayName.AddTranslation(GameCulture.Chinese, "牧师学徒魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'扫除一切恶'
每5秒产生一个圣十字架, 上限为3个
施放治疗法术时, 十字架将代替魔力消耗");
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

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.NoviceClericEffect))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("NoviceClericCowl").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }

            thorium.GetItem("NursePurse").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<NoviceClericCowl>());
            recipe.AddIngredient(ModContent.ItemType<NoviceClericTabard>());
            recipe.AddIngredient(ModContent.ItemType<NoviceClericPants>());
            recipe.AddIngredient(ModContent.ItemType<NursePurse>());
            recipe.AddIngredient(ModContent.ItemType<PalmCross>());
            recipe.AddIngredient(ModContent.ItemType<Renew>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
