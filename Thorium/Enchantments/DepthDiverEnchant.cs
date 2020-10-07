using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.QueenJelly;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.Painting;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DepthDiverEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Depth Diver Enchantment");
            Tooltip.SetDefault(
@"'Become a selfless protector'
Allows you and nearby allies to breathe underwater
Grants the ability to swim
You and nearby allies gain 10% increased damage and movement speed
Effects of Sea Breeze Pendant and Bubble Magnet
Summons a pet Jellyfish");
            DisplayName.AddTranslation(GameCulture.Chinese, "深渊潜游者魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'成为无私的保卫者'
使你和附近的队友能够水下呼吸
获得游泳能力
你和附近的队友获得10%伤害和移动速度加成
拥有海洋通行证, 泡泡磁铁和渊暗音箱的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //depth diver set
            for (int i = 0; i < 255; i++)
            {
                Player player2 = Main.player[i];
                if (player2.active && Vector2.Distance(player2.Center, player.Center) < 250f)
                {
                    player2.AddBuff(thorium.BuffType("DepthSpeed"), 30, false);
                    player2.AddBuff(thorium.BuffType("DepthDamage"), 30, false);
                    player2.AddBuff(thorium.BuffType("DepthBreath"), 30, false);
                }
            }
            
            //sea breeze pendant
            player.accFlipper = true;

            if (player.wet || thoriumPlayer.drownedDoubloon)
            {
                player.AddBuff(thorium.BuffType("AquaticAptitude"), 60, true);
                player.GetModPlayer<FargoDLCPlayer>().AllDamageUp(.1f);
            }

            //bubble magnet
            thoriumPlayer.bubbleMagnet = true;
            modPlayer.DepthEnchant = true;
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.JellyfishPet, hideVisual, thorium.BuffType("JellyPet"), thorium.ProjectileType("JellyfishPet"));
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DepthDiverHelmet>());
            recipe.AddIngredient(ModContent.ItemType<DepthDiverChestplate>());
            recipe.AddIngredient(ModContent.ItemType<DepthDiverGreaves>());
            recipe.AddIngredient(ModContent.ItemType<OceanEnchant>());
            recipe.AddIngredient(ModContent.ItemType<MagicConch>());
            recipe.AddIngredient(ModContent.ItemType<GeyserStaff>());
            recipe.AddIngredient(ModContent.ItemType<AnglerBulb>());
            recipe.AddIngredient(ModContent.ItemType<QueensGlowstick>());
            recipe.AddIngredient(ModContent.ItemType<JellyFishIdol>());
            recipe.AddIngredient(ModContent.ItemType<AquaticParadisePaint>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
