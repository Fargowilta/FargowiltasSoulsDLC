using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Items.Dread;
using ThoriumMod.Items.BasicAccessories;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.SummonItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DreadEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dread Enchantment");
            Tooltip.SetDefault(
@"'Infused with souls of the damned'
Your boots vibrate at an unreal frequency, increasing movement speed significantly
While moving, your damage and critical strike chance are increased
Your attacks have a chance to unleash an explosion of Dragon's Flame
Effects of Crash Boots, Dragon Talon Necklace, Disco Music Player, and Cursed Flail-Core");
            DisplayName.AddTranslation(GameCulture.Chinese, "恐惧魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'充满被诅咒的灵魂'
你的靴子以不真实的频率振动着, 显著提高移动速度
移动时增加伤害和暴击率
攻击有概率释放龙焰爆炸
拥有震地, 龙爪项链和诅咒链球核心的效果
拥有恐惧音箱和绿色播放器的效果
召唤宠物小飞龙");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 7;
            item.value = 200000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.DreadSpeed))
            {
                //dread set bonus
                player.moveSpeed += 0.8f;
                player.maxRunSpeed += 10f;
                player.runAcceleration += 0.05f;
                if (player.velocity.X > 0f || player.velocity.X < 0f)
                {
                    modPlayer.AllDamageUp(.25f);
                    modPlayer.AllCritUp(20);
                    player.endurance += 0.1f;
                    for (int i = 0; i < 2; i++)
                    {
                        int num = Dust.NewDust(new Vector2(player.position.X, player.position.Y) - player.velocity * 0.5f, player.width, player.height, 65, 0f, 0f, 0, default(Color), 1.75f);
                        int num2 = Dust.NewDust(new Vector2(player.position.X, player.position.Y) - player.velocity * 0.5f, player.width, player.height, 75, 0f, 0f, 0, default(Color), 1f);
                        Main.dust[num].noGravity = true;
                        Main.dust[num2].noGravity = true;
                        Main.dust[num].noLight = true;
                        Main.dust[num2].noLight = true;
                    }
                }
            }

            mod.GetItem("DragonEnchant").UpdateAccessory(player, hideVisual);
            thorium.GetItem("CrashBoots").UpdateAccessory(player, hideVisual);
            thorium.GetItem("CursedCore").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DreadSkull>());
            recipe.AddIngredient(ModContent.ItemType<DreadChestPlate>());
            recipe.AddIngredient(ModContent.ItemType<DreadGreaves>());
            recipe.AddIngredient(ModContent.ItemType<DragonEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CrashBoots>());
            recipe.AddIngredient(ModContent.ItemType<CursedCore>());
            
            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
