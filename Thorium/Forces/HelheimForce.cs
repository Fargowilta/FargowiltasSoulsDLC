using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class HelheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Helheim");
            Tooltip.SetDefault(
@"'From the halls of Hel, a vision of the end...'
All armor bonuses from Spirit Trapper, Malignant, Dragon, Dread, Flesh, and Demon Blood
All armor bonuses from Magma, Berserker, White Knight, and Harbinger
Effects of Inner Flame, Crash Boots, and Dragon Talon Necklace
Effects of Vile Flail-Core, Cursed Flail-Core, and Molten Spear Tip
Effects of Vampire Gland, Spring Steps, and Slag Stompers
Effects of Shade Band, Enchanted Shield, and Mana-Charged Rocketeers");
            DisplayName.AddTranslation(GameCulture.Chinese, "海姆冥界之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'从海姆冥界的大厅起始, 一派终末的景象...'
杀死敌人或持续攻击Boss会产生灵魂碎片
集齐5个后, 它们会立即被消耗, 治疗10点生命
你的靴子以不真实的频率振动着, 显著提高移动速度
移动时增加伤害和暴击率
攻击有概率释放龙焰爆炸
攻击提供'蓄血'Buff
充能完毕时, 你的下一次攻击会造成双倍伤害, 并将伤害的20%转化为治疗
连续攻击敌人时概率掉落肉, 拾取肉会获得额外生命并增加伤害
生命值高于75%时变得不稳定
攻击友善NPC的敌人将被标记为恶棍
对恶棍造成50%额外伤害
瓦斯持续时间翻倍, 瓦斯反应多造成20%伤害
杀死敌人会释放灵魂碎片
拥有心灵之火, 震地靴, 龙爪项链和恐惧音箱的效果
拥有吸血鬼试剂, 魔血纹章和血魔音箱的效果
拥有暗影护符, 巫妖之视和瘟疫之主药剂瓶的效果
召唤数个宠物");
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

            //spirit trapper
            modPlayer.SpiritTrapperEnchant = true;
            thoriumPlayer.setSpiritTrapper = true;
            //inner flame
            thoriumPlayer.spiritFlame = true;

            //malignant
            modPlayer.MalignantEnchant = true;
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.ManaBoots))
            {
                //mana charge rockets
                thorium.GetItem("ManaChargedRocketeers").UpdateAccessory(player, hideVisual);
            }
            //enchanted shield
            thorium.GetItem("EnchantedShield").UpdateAccessory(player, hideVisual);

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.DreadSpeed))
            {
                //dread
                player.moveSpeed += 0.8f;
                player.maxRunSpeed += 10f;
                player.runAcceleration += 0.05f;
                if (player.velocity.X > 0f || player.velocity.X < 0f)
                {
                    modPlayer.AllDamageUp(.25f);
                    modPlayer.AllCritUp(20);

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
            //crash boots
            thorium.GetItem("CrashBoots").UpdateAccessory(player, hideVisual);
            player.moveSpeed -= 0.15f;
            player.maxRunSpeed -= 1f;
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.DragonFlames))
            {
                //dragon 
                thoriumPlayer.dragonSet = true;
            }
            modPlayer.DragonEnchant = true;
            //flail-cores
            thoriumPlayer.accVileCore = true;
            thoriumPlayer.accCursedCore = true;
            //molten spear tip
            thoriumPlayer.spearFlame = true;
            //demon blood effect
            modPlayer.DemonBloodEnchant = true;
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.FleshDrops))
            {
                //flesh set bonus
                thoriumPlayer.Symbiotic = true;
            }
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.VampireGland))
            {
                //vampire gland
                thoriumPlayer.vampireGland = true;
            }
            modPlayer.FleshEnchant = true;
            modPlayer.KnightEnchant = true;
            
            //berserker
            mod.GetItem("BerserkerEnchant").UpdateAccessory(player, hideVisual);

            //dragon tooth necklace
            player.armorPenetration += 15;

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.HarbingerOvercharge))
            {
                //harbinger
                if (player.statLife > (int)(player.statLifeMax2 * 0.75))
                {
                    thoriumPlayer.overCharge = true;
                    modPlayer.AllDamageUp(.5f);
                }
            }
            //shade band
            thoriumPlayer.shadeBand = true;
           
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<SpiritTrapperEnchant>());
            recipe.AddIngredient(ModContent.ItemType<MalignantEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DreadEnchant>());
            recipe.AddIngredient(ModContent.ItemType<DemonBloodEnchant>());
            recipe.AddIngredient(ModContent.ItemType<BerserkerEnchant>());
            recipe.AddIngredient(ModContent.ItemType<HarbingerEnchant>());

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
