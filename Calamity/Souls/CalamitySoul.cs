using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using FargowiltasSouls.Items.Misc;

namespace FargowiltasSoulsDLC.Calamity.Souls
{
    public class CalamitySoul : ModItem
    {
        private readonly Mod calamity = ModLoader.GetMod("CalamityMod");
        public int dragonTimer = 60;
        public const int FireProjectiles = 2;
        public const float FireAngleSpread = 120f;
        public int FireCountdown;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("CalamityMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Soul of the Tyrant");
            Tooltip.SetDefault(
@"'And the land grew quiet once more...'
All armor bonuses from Aerospec, Statigel, and Hydrothermic
All armor bonuses from Xeroc and Fearmonger
All armor bonuses from Daedalus, Snow Ruffian, Umbraphile, and Astral
All armor bonuses from Omega Blue, Mollusk, Victide, Fathom Swarmer, and Sulphurous
All armor bonuses from Wulfrum, Reaver, Plague Reaper, and Demonshade
All armor bonuses from Tarragon, Bloodflare, and Brimflame
All armor bonuses from God Slayer, Silva, and Auric
Effects of Gladiator's Locket and Unstable Prism
Effects of Counter Scarf and Fungal Symbiote
Effects of Hallowed Rune, Ethereal Extorter, and The Community
Effects of Spectral Veil and Statis' Void Sash
Effects of Scuttler's Jewel and Permafrost's Concoction
Effects of Thief's Dime, Vampiric Talisman, and Momentum Capacitor
Effects of the Astral Arcanum and Gravistar Sabaton
Effects of the Abyssal Diving Suit and Mutated Truffle
Effects of Giant Pearl and Amidias' Pendant
Effects of Aquatic Emblem and Enchanted Pearl
Effects of Ocean's Crest and Luxor's Gift
Effects of Corrosive Spine and Lumenous Amulet
Effects of Sand Cloak and Alluring Bait
Effects of Trinket of Chi and Plague Hive
Effects of Plagued Fuel Pack, The Camper, and Profaned Soul Crystal
Effects of Blazing Core, Dark Sun Ring, and Core of the Blood God
Effects of Nebulous Core and Draedon's Heart
Effects of the The Amalgam and Godly Soul Artifact
Effects of Yharim's Gift, Heart of the Elements, and The Sponge");
            DisplayName.AddTranslation(GameCulture.Chinese, "暴君之魂");
            Tooltip.AddTranslation(GameCulture.Chinese,
@"'然后大地再次恢复了宁静...'
拥有天蓝, 斯塔提斯, 代达罗斯和渊泉的套装效果
拥有克希洛克，神惧者的套装效果
拥有代达罗斯, 雪境暴徒，日影和星幻的套装效果
拥有欧米伽蓝，软壳，胜潮，幻渊鱼群和硫磺的套装效果
拥有钨钢, 掠夺者，瘟疫死神和魔影的套装效果
拥有龙蒿，血炎和硫火的套装效果
拥有弑神者，始源林海和古圣金源的套装效果
拥有角斗士金锁和不稳定棱晶的效果
拥有反击围巾和真菌共生体的效果
拥有神圣符文，虚空掠夺者和归一心元石的效果
拥有进化者，幽灵披风和斯塔提斯的虚空饰带的效果
拥有潜遁者宝石，佩码·福洛斯特之秘药和再生冰盾的效果
拥有盗贼铸币，吸血鬼符咒和动量电容器的效果
拥有星辉秘术，星神隐壳和引力靴的效果
拥有深渊潜游服，突变松露和硫海遗爵之鳞的效果
拥有大珍珠和阿米迪亚斯之垂饰的效果
拥有海波纹章和附魔珍珠的效果
拥有海波项链，深潜者，变压护符和卢克索的礼物的效果
拥有腐蚀脊椎和流明护身符的效果
拥有沙尘披风和诱惑鱼饵的效果
拥有气功念珠，传说龟壳和瘟疫蜂巢的效果
拥有瘟疫燃料背包，蜜蜂护符，露营者和渎神魂晶的效果
拥有渎火核心，蚀日尊戒和血神核心的效果
拥有灾劫之尖啸，星云核心和嘉登之心的效果
拥有聚合之脑，痴愚金龙干细胞和圣魂神物的效果
拥有魔君的礼物，元素之心和化绵留香石的效果
召唤几个宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 10;//
            item.value = 20000000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            mod.GetItem("AnnihilationForce").UpdateAccessory(player, hideVisual);
            mod.GetItem("DesolationForce").UpdateAccessory(player, hideVisual);
            mod.GetItem("DevastationForce").UpdateAccessory(player, hideVisual);
            mod.GetItem("ExaltationForce").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.CalamityLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "AnnihilationForce");
            recipe.AddIngredient(null, "DevastationForce");
            recipe.AddIngredient(null, "DesolationForce");
            recipe.AddIngredient(null, "ExaltationForce");
            recipe.AddIngredient(ModContent.ItemType<AbomEnergy>(), 10);

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
