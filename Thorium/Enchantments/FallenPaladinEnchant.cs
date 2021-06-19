using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Misc;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class FallenPaladinEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Fallen Paladin Enchantment");
            Tooltip.SetDefault(
@"'Silently, they walk the dungeon halls'
Taking damage heals nearby allies equal to 15% of the damage taken
If an ally is below half health, you will gain increased healing abilities
Effects of Wynebgwrthucher and Rebirth Statuette");
            DisplayName.AddTranslation(GameCulture.Chinese, "堕落圣骑士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'静静地在地牢游荡'
受到伤害后治疗周围队友相当于受到伤害的15%血量
如果一个队友低于50%生命，你的治疗属性会增强
拥有祝福之盾和重生雕像的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded || player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //paladin set bonus
            thoriumPlayer.fallenPaladinSet = true;
            //wyne
            thoriumPlayer.Wynebgwrthucher = true;
            //rebirth statue
            thoriumPlayer.quickRevive = true;
            //templar set bonus
            for (int i = 0; i < 255; i++)
            {
                Player player2 = Main.player[i];
                if (player2.active && !player2.dead && player2.statLife < (int)(player2.statLifeMax2 * 0.5) && player2 != player)
                {
                    player.AddBuff(thorium.BuffType("HealingMastery"), 120, false);
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FallenPaladinFacegaurd>());
            recipe.AddIngredient(ModContent.ItemType<FallenPaladinCuirass>());
            recipe.AddIngredient(ModContent.ItemType<FallenPaladinGreaves>());
            recipe.AddIngredient(ModContent.ItemType<TemplarEnchant>());
            recipe.AddIngredient(ModContent.ItemType<Wynebgwrthucher>());
            recipe.AddIngredient(ModContent.ItemType<RebirthStatuette>());
            recipe.AddIngredient(ModContent.ItemType<TwilightStaff>());
            recipe.AddIngredient(ModContent.ItemType<BulwarkStaff>());
            recipe.AddIngredient(ModContent.ItemType<LightBringerWarhammer>());
            recipe.AddIngredient(ModContent.ItemType<GoldDuck>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
