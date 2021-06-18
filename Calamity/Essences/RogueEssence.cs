using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;

namespace FargowiltasSoulsDLC.Calamity.Essences
{
    public class RogueEssence : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Outlaw's Essence");
            Tooltip.SetDefault(
@"18% increased rogue damage
5% increased rogue velocity
5% increased rogue critical strike chance
'This is only the beginning..'");
            DisplayName.AddTranslation(GameCulture.Chinese, "逃犯精华");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'这是个开始...'
增加18%盗贼伤害
增加5%盗贼弹幕速度
增加5%盗贼暴击率
");
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 30, 247));
                }
            }
        }*/

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            item.rare = 4;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("AddRogueDamage", player, 0.18f);
            calamity.Call("AddRogueCrit", player, 5);
            calamity.Call("AddRogueVelocity", player, 0.05f);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RogueEmblem>());
            recipe.AddIngredient(ModContent.ItemType<GildedDagger>());
            recipe.AddIngredient(ModContent.ItemType<WebBall>(), 300);
            recipe.AddIngredient(ModContent.ItemType<BouncingEyeball>());
            recipe.AddIngredient(ModContent.ItemType<Shroomerang>());
            recipe.AddIngredient(ModContent.ItemType<MeteorFist>());
            recipe.AddIngredient(ModContent.ItemType<SludgeSplotch>(), 300);
            recipe.AddIngredient(ModContent.ItemType<SkyStabber>(), 4);
            recipe.AddIngredient(ModContent.ItemType<PoisonPack>(), 3);
            recipe.AddIngredient(ModContent.ItemType<HardenedHoneycomb>(), 300);
            recipe.AddIngredient(ModContent.ItemType<ShinobiBlade>());
            recipe.AddIngredient(ModContent.ItemType<MetalMonstrosity>());
            recipe.AddIngredient(ModContent.ItemType<InfernalKris>(), 300);
            recipe.AddIngredient(ModContent.ItemType<AshenStalactite>());

            recipe.AddTile(TileID.TinkerersWorkbench);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
