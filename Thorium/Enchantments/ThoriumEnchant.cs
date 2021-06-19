using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Thorium;
using ThoriumMod.Items.Dev;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class ThoriumEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Thorium Enchantment");
            Tooltip.SetDefault(
@"'It pulses with energy'
Shortlived Divermen will occasionally spawn when hitting enemies
Critical strikes ring a bell over your head, slowing all nearby enemies briefly
Effects of Crietz, Band of Replenishment, and Fan Letter");
            DisplayName.AddTranslation(GameCulture.Chinese, "瑟银魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'发出阵阵能量脉冲'
攻击敌人时偶尔会召唤暂时存在的潜水员
暴击时会奏响头顶的铃铛，微幅减速周围所有敌人
拥有精准项链, 大恢复戒指和粉丝的信函的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 1;
            item.value = 40000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //diverman meme
            modPlayer.ThoriumEnchant = true;
            //crietz
            //thoriumPlayer.crietzAcc = true;
            //band of replenish
            thoriumPlayer.accReplenishment = true;
            //jester bonus
            modPlayer.JesterEnchant = true;
            //fan letter
            thoriumPlayer.bardResourceMax2 += 2;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<ThoriumHelmet>());
            recipe.AddIngredient(ModContent.ItemType<ThoriumMail>());
            recipe.AddIngredient(ModContent.ItemType<ThoriumGreaves>());
            recipe.AddIngredient(ModContent.ItemType<JesterEnchant>());
            recipe.AddIngredient(ModContent.ItemType<Crietz>());
            recipe.AddIngredient(ModContent.ItemType<BandofReplenishment>());

           // thoriumdaggers
            //    thorium paxe
            //    purify


            recipe.AddIngredient(ModContent.ItemType<LastSupperPaint>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
