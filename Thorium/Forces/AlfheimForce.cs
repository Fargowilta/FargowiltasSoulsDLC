using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class AlfheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Alfheim");
            Tooltip.SetDefault(
@"'Elven mysteries unfold before you...'
All armor bonuses from Novice Cleric, Sacred, Warlock, and Biotech
All armor bonuses from Iridescent, Life Binder, Templar, and Fallen Paladin
Effects of Demon Tongue, Dark Effigy, Aloe Leaf, and Equalizer
Effects of Karmic Holder, Wynebgwrthucher, and Rebirth Statuette
Summons a pet Life Spirit");
            DisplayName.AddTranslation(GameCulture.Chinese, "亚尔夫海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'精灵之秘在你眼前展开...'
生命药水额外回复50%生命值
治疗法术短暂增加队友50最大生命值
每5秒产生一个圣十字架, 上限为3个
暴击产生至多15个暗影魂火
按下'特殊能力'键向光标方向释放所有存留的暗影魂火
召唤一个生物工程探测器协助你队友
光辉伤害有15%的概率造成闪光爆炸
受到伤害的15%将治疗附近队友
队友生命值低于50%时, 增强治疗能力
拥有恶魔之舌,芦荟叶和平等护符效果
拥有祝福之盾和重生雕像效果
召唤小天使和小恶魔
召唤宠物神圣山羊和生命之灵");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 11;
            item.value = 600000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            //sacred
            mod.GetItem("SacredEnchant").UpdateAccessory(player, hideVisual);
            //warlock
            mod.GetItem("WarlockEnchant").UpdateAccessory(player, hideVisual);
            //biotech
            mod.GetItem("BiotechEnchant").UpdateAccessory(player, hideVisual);
            //life binder
            mod.GetItem("LifeBinderEnchant").UpdateAccessory(player, hideVisual);
            //fallen paladin
            mod.GetItem("FallenPaladinEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "SacredEnchant");
            recipe.AddIngredient(null, "WarlockEnchant");
            recipe.AddIngredient(null, "BiotechEnchant");
            recipe.AddIngredient(null, "LifeBinderEnchant");
            recipe.AddIngredient(null, "FallenPaladinEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
