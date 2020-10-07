using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Souls
{
    public class ThoriumSoul : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of Yggdrasil");

            Tooltip.SetDefault(@"'The true might of the 9 realms is yours!'
All armor bonuses from Living Wood, Bulb, Life Bloom, Yew Wood, and Tide Hunter
All armor bonuses from Icy, Cryomancer, and Whispering
All armor bonuses from Sacred, Warlock, and Biotech
All armor bonuses from Cyber Punk and Maestro
All armor bonuses from Bronze, Darksteel, and Durasteel
All armor bonuses from Conduit, Lodestone, and Illumite
All armor bonuses from Jester, Thorium, and Terrarium
All armor bonuses from Malignant, White Dwarf, and Celestial
All armor bonuses from Spirit Trapper, Dragon, Dread, and Flesh
All armor bonuses from Demon Blood, Magma, and Berserker
All armor bonuses from Tide Turner, Assassin, Pyromancer, and Dream Weaver 
Effects of Flawless Chrysalis, Bee Booties, Bubble Magnet, and Agnor's Bowl
Effects of Ice Bound Strider Hide, Ring of Unity, and Mix Tape 
Effects of Eye of the Storm and Champion's Rebuttal
Effects of the Abyssal Shell and Astro-Beetle Husk
Effects of Eye of the Beholder, Crietz, and Mana-Charged Rocketeers 
Effects of Inner Flame, Crash Boots, Vampire Gland, and Spring Steps
Effects of Slag Stompers, Demon Blood Badge, and Lich's Gaze
Summons several pets");
            DisplayName.AddTranslation(GameCulture.Chinese, "世界树之魂");
            Tooltip.AddTranslation(GameCulture.Chinese, @"'九界的真正力量归于汝身!'
冰霜光环围绕着你, 在短暂的延迟后冻结附近的敌人
偶尔会产生一个深渊能量触手, 攻击附近的敌人
召唤一个生命之木树苗, 一个生物工程探测器, 一个小天使和一个小恶魔
获得向敌人冲刺的能力, 右键用盾牌保护你
泰拉瑞亚的能量试图保护你, 攻击时每隔几秒钟就会有一场流星雨
攻击有机会释放追踪水匕首, 复制自身, 或即死敌人
按下'特殊能力'键将会释放出影子, 召唤鬼魂, 用泡泡盾保护你, 释放熔火之灵,
拥有无暇之蛹, 植物纤维绳索宝典和琵琶鱼球碗的效果
拥有遁蛛契约, 杂集磁带和风暴之眼的效果
拥有反击之盾, 食人魔的凉鞋, 贪婪磁铁和深远贝壳的效果
拥有注视者之眼, 精准项链, 魔力充能火箭靴和震地靴的效果
拥有吸血鬼腺体, 魔血徽章, 巫妖之视和瘟疫之主的药剂瓶的效果
许多材料魂的效果, 召唤数个宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.value = 5000000;

            item.rare = -12;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            modPlayer.ThoriumSoul = true;

            //MUSPELHEIM
            mod.GetItem("MuspelheimForce").UpdateAccessory(player, hideVisual);
            //JOTUNHEIM
            mod.GetItem("JotunheimForce").UpdateAccessory(player, hideVisual);
            //ALFHEIM
            mod.GetItem("AlfheimForce").UpdateAccessory(player, hideVisual);
            //NIFLHEIM
            mod.GetItem("NiflheimForce").UpdateAccessory(player, hideVisual);
            //SVARTALFHEIM
            mod.GetItem("SvartalfheimForce").UpdateAccessory(player, hideVisual);
            //MIDGARD
            mod.GetItem("MidgardForce").UpdateAccessory(player, hideVisual);
            //VANAHEIM
            mod.GetItem("VanaheimForce").UpdateAccessory(player, hideVisual);
            //HELHEIM
            mod.GetItem("HelheimForce").UpdateAccessory(player, hideVisual);
            //ASGARD
            mod.GetItem("AsgardForce").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "MuspelheimForce");
            recipe.AddIngredient(null, "JotunheimForce");
            recipe.AddIngredient(null, "AlfheimForce");
            recipe.AddIngredient(null, "NiflheimForce");
            recipe.AddIngredient(null, "SvartalfheimForce");
            recipe.AddIngredient(null, "MidgardForce");
            recipe.AddIngredient(null, "VanaheimForce");
            recipe.AddIngredient(null, "HelheimForce");
            recipe.AddIngredient(null, "AsgardForce");
            //recipe.AddIngredient(null, "MutantScale", 10);

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}