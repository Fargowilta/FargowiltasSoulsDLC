using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.EndofDays.Rhapsodist;
using ThoriumMod.Items.Abyssion;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class RhapsodistEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Rhapsodist Enchantment");
            Tooltip.SetDefault(
@"'Allow your song to inspire an army, Prove to all that your talent is second to none'
Inspiration notes that drop will become more potent
Additionally, they give a random level 1 empowerment to all nearby allies
Pressing the 'Special Ability' key will grant you infinite inspiration and increased symphonic damage and playing speed
It also overloads all nearby allies with every empowerment III for 15 seconds
These effects needs to recharge for 1 minute");
            DisplayName.AddTranslation(GameCulture.Chinese, "狂想曲魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'歌曲振奋军队, 向所有人证明你的才华独一无二'
掉落的灵感音符会更有效
同时，这些灵感音符会随机给所有队友提供一个等级为1的咒音增幅
按'套装技能'键会鼓舞周围友军,给他们提供所有等级为3的咒音增幅，持续15秒
此效果有1分钟冷却时间");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 400000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color?(new Color(255, 128, 0));
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //notes heal more and give random empowerments
            thoriumPlayer.armInspirator = true;
            //hotkey buff allies 
            thoriumPlayer.setInspirator = true;
            //hotkey buff self
            thoriumPlayer.setSoloist = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<SoloistHat>());
            recipe.AddIngredient(ModContent.ItemType<RallyHat>());
            recipe.AddIngredient(ModContent.ItemType<RhapsodistChestWoofer>());
            recipe.AddIngredient(ModContent.ItemType<RhapsodistBoots>());
            recipe.AddIngredient(ModContent.ItemType<SirensAllure>());
            recipe.AddIngredient(ModContent.ItemType<JingleBells>());
            //recipe.AddIngredient(ModContent.ItemType<TerrariumAutoharp>()); theset
            recipe.AddIngredient(ModContent.ItemType<Sousaphone>());
            recipe.AddIngredient(ModContent.ItemType<Holophonor>());
            recipe.AddIngredient(ModContent.ItemType<EdgeofImagination>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
