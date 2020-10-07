using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria.Localization;
using CalamityMod.Items.Armor;
using CalamityMod.Items.Accessories;
using CalamityMod.Items.Weapons.Melee;
using CalamityMod.Items.Weapons.Magic;
using CalamityMod.Items.Weapons.Ranged;
using CalamityMod.Items.Weapons.Summon;
using CalamityMod.Items.Pets;

namespace FargowiltasSoulsDLC.Calamity.Enchantments
{
    public class BloodflareEnchant : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Bloodflare Enchantment");
            Tooltip.SetDefault(
@"'The souls of the fallen are at your disposal...'
Press Y to trigger a brimflame frenzy effect
While under this effect, your damage is significantly boosted
However, this comes at the cost of rapid life loss and no mana regeneration
Enemies below 50% life have a chance to drop hearts when struck
Enemies above 50% life have a chance to drop mana stars when struck
Enemies killed during a Blood Moon have a much higher chance to drop Blood Orbs
True melee strikes will heal you
After striking an enemy 15 times with true melee you will enter a blood frenzy for 5 seconds
During this you will gain 25% increased melee damage, critical strike chance, and contact damage is halved
This effect has a 30 second cooldown
Press Y to unleash the lost souls of polterghast to destroy your enemies
This effect has a 30 second cooldown
Ranged weapons have a chance to fire bloodsplosion orbs
Magic weapons will sometimes fire ghostly bolts
Magic critical strikes cause flame explosions every 2 seconds
Summons polterghast mines to circle you
Rogue critical strikes have a 50% chance to heal you
Effects of the Core of the Blood God and Affliction
Summons a Brimling pet");
            DisplayName.AddTranslation(GameCulture.Chinese, "血炎魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'堕落者的灵魂由你支配...'
按Y键进入硫火狂暴模式
在此模式下，你造成的伤害会显著增加
然而这是以快速的生命流失和魔力再生速度归零为代价的
击中一个生命值低于50%的敌人有几率掉落红心
击中一个生命值高于50%的敌人有几率掉落魔力星
血月期间击杀的敌人掉落血珠的概率大幅提高
真正的近战攻击会治疗你
使用真正的近战武器打击敌人15次进入鲜血狂怒状态，持续5秒
此期间近战伤害和暴击率提升25%，来自敌人的接触伤害减半
此效果有30秒冷却时间
按下Y键释放噬魂幽花的冤魂摧毁你的敌人
此效果有30秒冷却时间
远程武器有几率引发血炎爆炸
魔法武器有时候会发射灵魂射弹
魔法武器暴击产生火焰爆炸，两秒钟内至多触发一次
召唤环绕你的噬魂幽花地雷
盗贼武器暴击有50%几率治疗你
拥有血神核心和灾劫之尖啸的效果
召唤小硫火灵宠物");
        }

        public override void ModifyTooltips(List<TooltipLine> list)
        {
            foreach (TooltipLine tooltipLine in list)
            {
                if (tooltipLine.mod == "Terraria" && tooltipLine.Name == "ItemName")
                {
                    tooltipLine.overrideColor = new Color(191, 68, 59);
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

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.BloodflareEffects))
            {
                calamity.Call("SetSetBonus", player, "bloodflare", true);
                calamity.Call("SetSetBonus", player, "bloodflare_melee", true);
                calamity.Call("SetSetBonus", player, "bloodflare_ranged", true);
                calamity.Call("SetSetBonus", player, "bloodflare_magic", true);
                calamity.Call("SetSetBonus", player, "bloodflare_rogue", true);
            }
           
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.calamityToggles.PolterMines))
            {
                calamity.Call("SetSetBonus", player, "bloodflare_summon", true);
            }

            //core of the blood god
            calamity.GetItem("CoreOfTheBloodGod").UpdateAccessory(player, hideVisual);
            //affliction
            calamity.GetItem("Affliction").UpdateAccessory(player, hideVisual);
            //brimflame
            mod.GetItem("BrimflameEnchant").UpdateAccessory(player, hideVisual);

            /* modPlayer.StatigelEnchant = true;
             //modPlayer.AddPet("Perforator Pet", hideVisual, calamity.BuffType("BloodBound"), calamity.ProjectileType("PerforaMini"));

             if (player.FindBuffIndex(calamity.BuffType("BloodBound")) == -1 && player.ownedProjectileCounts[calamity.ProjectileType("PerforaMini")] < 1)
             {
                 Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, -1f, calamity.ProjectileType("PerforaMini"), 0, 0f, player.whoAmI);
             }*/
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddRecipeGroup("FargowiltasSoulsDLC:AnyBloodflareHelmet");
            recipe.AddIngredient(ModContent.ItemType<BloodflareBodyArmor>());
            recipe.AddIngredient(ModContent.ItemType<BloodflareCuisses>());
            recipe.AddIngredient(ModContent.ItemType<BrimflameEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CoreOfTheBloodGod>());
            recipe.AddIngredient(ModContent.ItemType<EldritchSoulArtifact>());
            recipe.AddIngredient(ModContent.ItemType<Affliction>());
            recipe.AddIngredient(ModContent.ItemType<DevilsSunrise>());
            recipe.AddIngredient(ModContent.ItemType<DarkSpark>());
            recipe.AddIngredient(ModContent.ItemType<DodusHandcannon>());
            recipe.AddIngredient(ModContent.ItemType<TheLastMourning>());
            recipe.AddIngredient(ModContent.ItemType<LightGodsBrilliance>());
            recipe.AddIngredient(ModContent.ItemType<LanternoftheSoul>());
            recipe.AddIngredient(ModContent.ItemType<BloodyVein>());

            recipe.AddTile(TileID.LunarCraftingStation);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
