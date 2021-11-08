using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Lodestone;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.MiniBoss;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.Donate;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class LodestoneEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Lodestone Enchantment");
            Tooltip.SetDefault(
@"'Sturdy'
Damage reduction is increased by 10% at every 25% segment of life
Maximum damage reduction is reached at 30% while below 50% life
Effects of Astro-Beetle Husk, Obsidian Scale, and Sandweaver's Tiara");
            DisplayName.AddTranslation(GameCulture.Chinese, "地脉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'坚实'
生命值每下降25%, 增加10%伤害减免
生命值低于50%时达到上限: 30%
拥有太空甲虫壳效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.ManaBoots))
            {
                string oldSetBonus = player.setBonus;
                thorium.GetItem("LodeStoneFaceGuard").UpdateArmorSet(player);
                player.setBonus = oldSetBonus;
            }

            thorium.GetItem("AstroBeetleHusk").UpdateAccessory(player, true);
            thorium.GetItem("ObsidianScale").UpdateAccessory(player, true);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.SandweaversTiara))
            {
                thorium.GetItem("SandweaversTiara").UpdateAccessory(player, true);
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<LodeStoneFaceGuard>());
            recipe.AddIngredient(ModContent.ItemType<LodeStoneChestGaurd>());
            recipe.AddIngredient(ModContent.ItemType<LodeStoneShinGaurds>());
            recipe.AddIngredient(ModContent.ItemType<AstroBeetleHusk>());
            recipe.AddIngredient(ModContent.ItemType<ObsidianScale>());
            recipe.AddIngredient(ModContent.ItemType<SandweaversTiara>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
