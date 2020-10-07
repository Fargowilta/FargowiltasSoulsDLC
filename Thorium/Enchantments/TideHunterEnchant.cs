using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.QueenJelly;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class TideHunterEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tide Hunter Enchantment");
            Tooltip.SetDefault(
@"'Not just for hunting fish'
Critical strikes release a splash of foam, slowing nearby enemies
After four consecutive non-critical strikes, your next attack will mini-crit for 150% damage
Effects of Goblin War Shield and Agnor's Bowl");
            DisplayName.AddTranslation(GameCulture.Chinese, "猎潮者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'不单是为了捕鱼'
暴击释放飞溅泡沫, 缓慢附近的敌人
连续4次攻击不暴击时, 下一次攻击造成150%伤害
拥有哥布林战盾和琵琶鱼球碗的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            //tide hunter set bonus
            modPlayer.TideHunterEnchant = true;
            //angler bowl
            thorium.GetItem("AnglerBowl").UpdateAccessory(player, hideVisual);
            //yew set bonus
            modPlayer.YewEnchant = true;
            //goblin war shield
            thorium.GetItem("GoblinWarshield").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<TideHunterCap>());
            recipe.AddIngredient(ModContent.ItemType<TideHunterChestpiece>());
            recipe.AddIngredient(ModContent.ItemType<TideHunterLeggings>());
            recipe.AddIngredient(ModContent.ItemType<YewWoodEnchant>());
            recipe.AddIngredient(ModContent.ItemType<AnglerBowl>());
            recipe.AddIngredient(ModContent.ItemType<BlunderBuss>());
            recipe.AddIngredient(ModContent.ItemType<PearlPike>());
            recipe.AddIngredient(ModContent.ItemType<HydroCannon>());
            recipe.AddIngredient(ModContent.ItemType<MarineLauncher>());
            recipe.AddIngredient(ModContent.ItemType<JollyRogerPaint>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
