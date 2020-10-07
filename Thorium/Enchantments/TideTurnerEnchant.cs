using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.EndofDays.Aqua;
using ThoriumMod.Items.MiniBoss;
using ThoriumMod.Items.Abyssion;
using ThoriumMod.Items.Misc;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class TideTurnerEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Tide Turner Enchantment");
            Tooltip.SetDefault(
@"'Become as unstoppable as the tides, Unleash aquatic wrath upon your foes'
Pressing the 'Special Ability' key will envelop you within an impervious bubble
While the bubble is active, all damage taken is converted into healing
Produces a floating globule every half second
Every globule increases defense and makes your next attack a mini-crit
Attacks have a 20% chance to unleash aquatic homing daggers all around you");
            DisplayName.AddTranslation(GameCulture.Chinese, "洪流逆潮者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'像潮水一样势不可挡, 向敌人释放波涛的愤怒'
按下'特殊能力'键将你包裹在封闭泡泡中
泡泡激活时, 收到的所有伤害转化为治疗
每0.5秒产生一颗浮球
每颗浮球都将增加防御力, 并使下一次攻击变为小型暴击
溢出的伤害转化为能量攻击附近的敌人
攻击有20%概率释放6把会追踪的波纹飞刀");
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

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //mini crits and daggers
            modPlayer.TideTurnerEnchant = true;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.TideGlobules))
            {
                //floating globs and defense
                thoriumPlayer.tideHelmet = true;
                if (thoriumPlayer.tideOrb < 8)
                {
                    timer++;
                    if (timer > 30)
                    {
                        float num = 30f;
                        int num2 = 0;
                        while (num2 < num)
                        {
                            Vector2 vector = Vector2.UnitX * 0f;
                            vector += -Utils.RotatedBy(Vector2.UnitY, (num2 * (6.28318548f / num)), default(Vector2)) * new Vector2(25f, 25f);
                            vector = Utils.RotatedBy(vector, Utils.ToRotation(player.velocity), default(Vector2));
                            int num3 = Dust.NewDust(player.Center, 0, 0, 113, 0f, 0f, 0, default(Color), 1f);
                            Main.dust[num3].scale = 1.6f;
                            Main.dust[num3].noGravity = true;
                            Main.dust[num3].position = player.Center + vector;
                            Main.dust[num3].velocity = player.velocity * 0f + Utils.SafeNormalize(vector, Vector2.UnitY) * 1f;
                            int num4 = num2;
                            num2 = num4 + 1;
                        }
                        thoriumPlayer.tideOrb++;
                        timer = 0;
                    }
                }
            }
            //set bonus damage to healing hot key
            thoriumPlayer.tideSet = true;

           // fishegg pet
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<TideTurnerHelmet>());
            recipe.AddIngredient(ModContent.ItemType<TideTurnersGaze>());
            recipe.AddIngredient(ModContent.ItemType<TideTurnerBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<TideTurnerGreaves>());
            recipe.AddIngredient(ModContent.ItemType<PoseidonCharge>());
            recipe.AddIngredient(ModContent.ItemType<MantisPunch>());
            recipe.AddIngredient(ModContent.ItemType<OceansJudgment>());
            recipe.AddIngredient(ModContent.ItemType<Trefork>());
            recipe.AddIngredient(ModContent.ItemType<TidalWave>());
            recipe.AddIngredient(ModContent.ItemType<FishEgg>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
