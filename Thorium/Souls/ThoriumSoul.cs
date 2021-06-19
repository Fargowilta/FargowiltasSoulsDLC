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
拥有生命木，花瓣，树人，紫衫木和猎潮者的套装效果
拥有碎冰，极寒巫师和低语者的套装效果
拥有圣崇，术士和生物工程的套装效果
拥有赛博朋克和大师的套装效果
拥有青铜，暗金和耐钢的套装效果
拥有电容，地脉和荧光的套装效果
拥有小丑，瑟银和元素之灵的套装效果
拥有妖术，白矮星和大天使的套装效果
拥有猎魂者，绿龙，恐惧和血肉的套装效果
拥有魔血，熔岩和狂战士的套装效果
拥有洪流逆潮者，刺客，炎法和织梦者的套装效果
拥有无暇之蛹，蜜蜂靴，泡泡磁铁和琵琶鱼球碗的效果
拥有遁蛛契约，团结之戒和杂集磁带的效果
拥有风暴之眼和反击之盾的效果
拥有深渊贝壳和太空甲虫壳的效果
拥有注视者之眼，精准项链和魔力充能火箭靴的效果
拥有心灵之火，震地靴，吸血鬼试剂和弹簧靴的效果
拥有熔渣重踏，魔血徽章和巫妖之凝效果
召唤几个宠物");
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
