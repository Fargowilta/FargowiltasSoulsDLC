using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class TarragonEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tarragon Enchantment");
            Tooltip.SetDefault(
@"'Braelor's undying might flows through you...'
Increased heart pickup range
Enemies have a chance to drop extra hearts on death
You have a 25% chance to regen health quickly when you take damage
Press Y to cloak yourself in life energy that heavily reduces enemy contact damage for 10 seconds
Ranged critical strikes will cause an explosion of leaves
Ranged projectiles have a chance to split into life energy on death
On every 5th critical strike you will fire a leaf storm
Magic projectiles have a 50% chance to heal you on enemy hits
At full health you gain +2 max minions and 10% increased minion damage
Summons a life aura around you that damages nearby enemies
After every 25 rogue critical hits you will gain 5 seconds of damage immunity
While under the effects of a debuff you gain 10% increased rogue damage
Effects of Blazing Core and Dark Sun Ring");
            DisplayName.AddTranslation(GameCulture.Chinese, "龙蒿魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'布拉洛的不死之力从你身上流过...'
增加红心拾取范围
敌人死亡时有几率掉落更多红心
受到伤害时你有25%的几率获得生命恢复的增益
按“Y”键将自已以生命能量包裹，大大降低你受到的接触伤害，持续10秒
远程暴击造成叶片爆炸
远程弹幕在因击中敌人而消失时有几率分裂为生命能量
每五次暴击时发射叶片风暴
魔法弹幕击中敌人时有50%的几率治疗你
召唤围绕你的生命光环，对敌人造成伤害
使用盗贼武器暴击敌人25次时你会获得5秒无敌时间
若你受到减益影响，则提示10%暴击率
拥有渎火核心和蚀日尊戒的效果");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(169, 106, 52);
                }
            }
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;
            item.value = 3000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.TarragonEffects))
            {
                calamity.Call("SetSetBonus", player, "tarragon", true);
                calamity.Call("SetSetBonus", player, "tarragon_melee", true);
                calamity.Call("SetSetBonus", player, "tarragon_ranged", true);
                calamity.Call("SetSetBonus", player, "tarragon_magic", true);
                calamity.Call("SetSetBonus", player, "tarragon_summon", true);
                calamity.Call("SetSetBonus", player, "tarragon_rogue", true);
            }
            
            calamity.GetItem("BlazingCore").UpdateAccessory(player, hideVisual);
            //dark sun ring
            calamity.GetItem("DarkSunRing").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyTarragonHelmet");
            recipe.AddIngredient(ModContent.ItemType<TarragonBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<TarragonLeggings>());
            recipe.AddIngredient(ModContent.ItemType<BlazingCore>());
            recipe.AddIngredient(ModContent.ItemType<DarkSunRing>());
            recipe.AddIngredient(ModContent.ItemType<TrueTyrantYharimsUltisword>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
