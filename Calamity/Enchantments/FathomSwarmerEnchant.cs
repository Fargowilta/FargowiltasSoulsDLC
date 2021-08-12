using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Rogue;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Pets;
using CalamityMod.Buffs.Pets;
using CalamityMod.Projectiles.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class FathomSwarmerEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fathom Swarmer Enchantment");
            Tooltip.SetDefault(
@"''
10% increased minion damage while submerged in liquid
Provides a moderate amount of light and moderately reduces breath loss in the abyss
Attacking and being attacked by enemies inflicts poison
Grants a sulphurous bubble jump that applies venom on hit
Effects of Corrosive Spine and Lumenous Amulet
Effects of Sand Cloak and Alluring Bait");
            DisplayName.AddTranslation(GameCulture.Chinese, "幻渊鱼群魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"''
浸没在液体中时增加10%召唤伤害
在深渊提供适量光照，并适度减少深渊中的氧气损耗
攻击敌人或被敌人攻击赋予他们中毒减益
获得一段硫磺泡泡跳跃，击中敌人赋予毒液减益
拥有腐蚀脊椎和流明护身符的效果
拥有沙尘披风和诱惑鱼饵的效果
召唤几个宠物
");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 300000;
        }

        /*public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(70, 63, 69);
                }
            }
        }*/

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            calamity.Call("SetSetBonus", player, "fathomswarmer", true);
            if (Collision.DrownCollision(player.position, player.width, player.height, player.gravDir))
            {
                player.minionDamage += 0.1f;
            }
            calamity.GetItem("CorrosiveSpine").UpdateAccessory(player, hideVisual);
            calamity.GetItem("LumenousAmulet").UpdateAccessory(player, hideVisual);
            mod.GetItem("SulphurousEnchant").UpdateAccessory(player, hideVisual);

        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerVisage>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<FathomSwarmerBoots>());
            recipe.AddIngredient(ModContent.ItemType<SulphurousEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CorrosiveSpine>());
            recipe.AddIngredient(ModContent.ItemType<LumenousAmulet>());


            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
