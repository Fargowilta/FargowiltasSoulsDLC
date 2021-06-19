using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.NPCs;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.Tracker;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class WarlockEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Warlock Enchantment");
            Tooltip.SetDefault(
@"'Better than a wizard'
Critical strikes will generate up to 15 shadow wisps
Pressing the 'Special Ability' key will unleash every stored shadow wisp towards your cursor's position
Effects of Demon Tongue and Dark Effigy");
            DisplayName.AddTranslation(GameCulture.Chinese, "术士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'比巫师更强'
暴击能生成最多15只暗影精灵
按下'套装技能'键会将生成的暗影精灵投向鼠标所在位置
拥有恶魔之舌和鬼影塑像的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            thoriumPlayer.warlockSet = true;

            if (modPlayer.ThoriumSoul) return;

            //demon tongue
            thoriumPlayer.darkAura = true;
            thoriumPlayer.radiantLifeCost = 2;

            //dark effigy
            thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            for (int i = 0; i < 200; i++)
            {
                NPC npc = Main.npc[i];
                if (npc.active && !npc.friendly && (npc.shadowFlame || npc.GetGlobalNPC<ThoriumGlobalNPC>().lightLament) && npc.DistanceSQ(player.Center) < 1000000f)
                {
                    thoriumPlayer.effigy++;
                }
            }
            if (thoriumPlayer.effigy > 0)
            {
                player.AddBuff(thorium.BuffType("EffigyRegen"), 2, true);
            }
        }
        
        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<WarlockHood>());
            recipe.AddIngredient(ModContent.ItemType<WarlockGarb>());
            recipe.AddIngredient(ModContent.ItemType<WarlockLeggings>());
            recipe.AddIngredient(ModContent.ItemType<EbonEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DemonTongue>());
            recipe.AddIngredient(ModContent.ItemType<Effigy>());
            recipe.AddIngredient(ModContent.ItemType<Omen>());
            recipe.AddIngredient(ModContent.ItemType<ShadowStaff>());
            recipe.AddIngredient(ModContent.ItemType<NecroticStaff>());
            recipe.AddIngredient(ModContent.ItemType<CursedHammer>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
