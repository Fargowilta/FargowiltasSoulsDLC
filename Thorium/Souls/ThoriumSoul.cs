using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSouls.Items.Misc;

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
All armor bonuses from Sandstone, Danger, Flight, Fungus, Living Wood, Bulb, and Life Bloom
All armor bonuses from Depth Diver, Yew Wood, Tide Hunter, Naga-Skin, Icy, Cryomancer, and Whispering
All armor bonuses from Sacred, Warlock, Biotech, Life Binder and Fallen Paladin
All armor bonuses from Crier, Noble, Ornate, Cyber Punk, Marching Band, and Maestro
All armor bonuses from Granite, Bronze, Titan, Conduit, Steel, Darksteel, and Durasteel
All armor bonuses from Lodestone, Valadium, Illumite, Shade Master, Jester, Thorium, and Terrarium
All armor bonuses from Plague Doctor, Lich, White Dwarf, Celestial, and Shooting Star
All armor bonuses from Spirit Trapper, Malignant, Dragon, Dread, Flesh, Demon Blood, Magma, Berserker, and Harbinger
All armor bonuses from Tide Turner, Assassin, Pyromancer, Dream Weaver, and Rhapsodist
Effects of Nightshade Flower, Flawless Chrysalis, and Bee Booties
Effects of Goblin War Shield, Bubble Magnet, Agnor's Bowl, and Ice Bound Strider Hide
Effects of Demon Tongue, Dark Effigy, Aloe Leaf, Equalizer, Karmic Holder, Prydwen, and Rebirth Statuette
Effects of Ring of Unity, Brass Cap, Waxy Rosin, Auto Tuner, Metal Music Player, Diss Track, Concert Tickets, Conductor's Baton, Full Score, and Metronome
Effects of Eye of the Storm, Champion's Rebuttal, Olympic Torch, Spartan Sandals, Spiked Bracers, Rock Music Player, Ogre Sandals, and Mask of the Crystal Eye
Effects of the Abyssal Shell, Astro-Beetle Husk, Obsidian Scale, Mirror of the Beholder, Jazz Music Player, Crietz, Band of Replenishment, Fan Letter, and Terrarium Surround Sound
Effects of Lich's Gaze and Ascension Statuette
Effects of the Enchanted Shield, Mana-Charged Rocketeers, Inner Flame, Crash Boots, Vampire Gland, Spring Steps, Slag Stompers, and Shade Band
Effects of Dart Pouch");
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
            recipe.AddIngredient(ModContent.ItemType<MutantScale>(), 10);

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}