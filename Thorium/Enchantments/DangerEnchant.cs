using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.ArcaneArmor;
using ThoriumMod.Items.Tracker;
using ThoriumMod.Items.NPCItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DangerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Danger Enchantment");
            Tooltip.SetDefault(
@"'Let's get dangerous...'
You are immune to most damage-inflicting debuffs
Effects of Nightshade Flower");
            DisplayName.AddTranslation(GameCulture.Chinese, "致危魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'Let's get dangerous...'
战斗时+2生命回复
免疫大多数造成伤害的Debuff");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 2;
            item.value = 60000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            player.buffImmune[BuffID.Frostburn] = true;
            player.buffImmune[BuffID.Poisoned] = true;
            player.buffImmune[BuffID.OnFire] = true;
            player.buffImmune[BuffID.Bleeding] = true;
            player.buffImmune[BuffID.Venom] = true;

            //nightshade flower
            thoriumPlayer.nightshadeBoost = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DangerHelmet>());
            recipe.AddIngredient(ModContent.ItemType<DangerMail>());
            recipe.AddIngredient(ModContent.ItemType<DangerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<NightShadePetal>());
            recipe.AddIngredient(ModContent.ItemType<TrackerBlade>());
            recipe.AddIngredient(ItemID.Rally);

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
