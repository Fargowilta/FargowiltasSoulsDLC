using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class DaedalusEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Daedalus Enchantment");
            Tooltip.SetDefault(
@"'Icy magic envelopes you...'
You have a 33% chance to reflect projectiles back at enemies
If you reflect a projectile you are also healed for 1/5 of that projectile's damage
Getting hit causes you to emit a blast of crystal shards
You have a 10% chance to absorb physical attacks and projectiles when hit
If you absorb an attack you are healed for 1/2 of that attack's damage
A daedalus crystal floats above you to protect you
Rogue projectiles throw out crystal shards as they travel
You can glide to negate fall damage
Effects of Scuttler's Jewel and Permafrost's Concoction");
            DisplayName.AddTranslation(GameCulture.Chinese, "代达罗斯魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'冰霜魔法保护着你...'
你有33%的几率反弹弹幕
如果你成功反弹了弹幕，你将恢复相当于弹幕伤害1/5的生命值
当你被击中时释放水晶碎片
你有10%的几率吸收一次物理伤害或者弹幕
当你成功吸收了一次攻击后，你将恢复相当于那次攻击的攻击力1/2的生命值
召唤悬浮的代达罗斯水晶保护你
盗贼弹幕飞行时释放水晶碎片
拥有佩码·福洛斯特之秘药和再生冰盾的效果
召唤小熊，肯德拉和第三贤者宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 5;
            item.value = 500000;
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(64, 115, 164);
                }
            }
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DaedalusEffects))
            {
                calamity.Call("SetSetBonus", player, "daedalus_melee", true);
                calamity.Call("SetSetBonus", player, "daedalus_ranged", true);
                calamity.Call("SetSetBonus", player, "daedalus_magic", true);
                calamity.Call("SetSetBonus", player, "daedalus_summon", true);
                calamity.Call("SetSetBonus", player, "daedalus_rogue", true);
            }
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PermafrostPotion))
            {
                //permafrost concoction
                calamity.GetItem("PermafrostsConcoction").UpdateAccessory(player, hideVisual);
            }

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.DaedalusMinion) && player.whoAmI == Main.myPlayer)
            {
                if (player.FindBuffIndex(calamity.BuffType("DaedalusCrystal")) == -1)
                {
                    player.AddBuff(calamity.BuffType("DaedalusCrystal"), 3600, true);
                }
                if (player.ownedProjectileCounts[calamity.ProjectileType("DaedalusCrystal")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("DaedalusCrystal"), (int)(95f * player.minionDamage), 0f, Main.myPlayer, 0f, 0f);
                }
            }

            mod.GetItem("SnowRuffianEnchant").UpdateAccessory(player, hideVisual);            
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyDaedalusHelmet");
            recipe.AddIngredient(ModContent.ItemType<DaedalusBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<DaedalusLeggings>());
            recipe.AddIngredient(ModContent.ItemType<SnowRuffianEnchant>());
            recipe.AddIngredient(ModContent.ItemType<PermafrostsConcoction>());
            recipe.AddIngredient(ModContent.ItemType<CrystalBlade>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
