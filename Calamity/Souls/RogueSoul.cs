using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using FargowiltasSoulsDLC.Calamity.Essences;

namespace FargowiltasSoulsDLC.Calamity.Souls
{
    public class RogueSoul : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Vagabond's Soul");
            Tooltip.SetDefault(
@"'They’ll never see it coming'
30% increased rogue damage
15% increased rogue velocity
15% increased rogue critical strike chance
Effects of Eclipse Mirror, Nanotech, Venerated Locket, and Dragon Scales");
            DisplayName.AddTranslation(GameCulture.Chinese, "流浪者之魂");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'尔等永不见君临'
增加30%盗贼伤害
增加15%盗贼弹幕速度
增加15%盗贼暴击率
拥有日蚀魔镜，纳米技术，敬天神盗盒和浴火龙鳞的效果");
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
            item.value = 1000000;
            item.rare = 11;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("AddRogueDamage", player, 0.3f);
            calamity.Call("AddRogueCrit", player, 15);
            calamity.Call("AddRogueVelocity", player, 0.15f);

            calamity.GetItem("EclipseMirror").UpdateAccessory(player, hideVisual);
            calamity.GetItem("Nanotech").UpdateAccessory(player, hideVisual);
            calamity.GetItem("VeneratedLocket").UpdateAccessory(player, hideVisual);
            calamity.GetItem("DragonScales").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);
            recipe.AddIngredient(ModContent.ItemType<RogueEssence>());
            recipe.AddIngredient(ModContent.ItemType<EclipseMirror>());
            recipe.AddIngredient(ModContent.ItemType<Nanotech>());
            recipe.AddIngredient(ModContent.ItemType<VeneratedLocket>());
            recipe.AddIngredient(ModContent.ItemType<DragonScales>());
            recipe.AddIngredient(ModContent.ItemType<HellsSun>(), 10);
            recipe.AddIngredient(ModContent.ItemType<SylvanSlasher>());
            recipe.AddIngredient(ModContent.ItemType<JawsOfOblivion>());
            recipe.AddIngredient(ModContent.ItemType<DeepSeaDumbbell>());
            recipe.AddIngredient(ModContent.ItemType<TimeBolt>());
            recipe.AddIngredient(ModContent.ItemType<Eradicator>());
            recipe.AddIngredient(ModContent.ItemType<EclipsesFall>());
            recipe.AddIngredient(ModContent.ItemType<Celestus>());
            recipe.AddIngredient(ModContent.ItemType<ScarletDevil>());

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
