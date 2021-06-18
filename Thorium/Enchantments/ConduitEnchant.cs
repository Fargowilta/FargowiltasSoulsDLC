using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Misc;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.BardItems;
using ThoriumMod.Items.Scouter;
using ThoriumMod.Items.Cultist;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class ConduitEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Conduit Enchantment");
            Tooltip.SetDefault(
@"'Shocked out of this world'
Moving around generates up to 5 static rings, with each one generating life shielding
When fully charged, a bubble of energy will protect you from one attack 
When the bubble blocks an attack, an electrical discharge is released at nearby enemies
Summons a pet Omega");
            DisplayName.AddTranslation(GameCulture.Chinese, "电容魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'震惊世界'
移动时产生最多5层静电环, 静电环可以回复护盾值
完全充能时, 产生一个能量泡保护你免受一次攻击的伤害
泡泡挡住一次攻击时, 向周围敌人放电
召唤奥米茄驱动器宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 8;
            item.value = 250000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
           
            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.ConduitShield))
            {
                //conduit set bonus
                thoriumPlayer.conduitSet = true;
                thoriumPlayer.orbital = true;
                thoriumPlayer.orbitalRotation1 = Utils.RotatedBy(thoriumPlayer.orbitalRotation1, -0.10000000149011612, default(Vector2));
                Lighting.AddLight(player.position, 0.2f, 0.35f, 0.7f);
                if ((player.velocity.X > 0f || player.velocity.X < 0f) && thoriumPlayer.circuitStage < 6)
                {
                    thoriumPlayer.circuitCharge++;
                    for (int i = 0; i < 1; i++)
                    {
                        int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y) - player.velocity * 0.5f, player.width, player.height, 185, 0f, 0f, 100, default(Color), 1f);
                        Main.dust[num].noGravity = true;
                    }
                }
            }
            //pets
            //ModContent.\1Type<\2>\(\));
            modPlayer.ConduitEnchant = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<ConduitHelmet>());
            recipe.AddIngredient(ModContent.ItemType<ConduitSuit>());
            recipe.AddIngredient(ModContent.ItemType<ConduitLeggings>());
            recipe.AddIngredient(ModContent.ItemType<VegaPhaser>());
            recipe.AddIngredient(ModContent.ItemType<LivewireCrasher>());
            recipe.AddIngredient(ModContent.ItemType<ElectroRebounder>(), 300);
            recipe.AddIngredient(ModContent.ItemType<Triangle>());
            recipe.AddIngredient(ModContent.ItemType<Turntable>());
            recipe.AddIngredient(ModContent.ItemType<AncientSpark>());
            recipe.AddIngredient(ModContent.ItemType<OmegaDrive>());
            

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
