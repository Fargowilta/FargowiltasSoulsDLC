using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class SvartalfheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");
        public int timer;

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Svartalfheim");
            Tooltip.SetDefault(
@"'Behold the craftsmanship of the Dark Elves...'
All armor bonuses from Granite, Bronze, and Darksteel
All armor bonuses from Durasteel, Titan, and Conduit
Effects of Eye of the Storm, Champion's Rebuttal, and Spiked Bracers
Effects of Ogre Sandals, Crystal Spear Tip, Mask of the Crystal Eye, and Abyssal Shell
Summons a pet Omega and Coin Bag");
            DisplayName.AddTranslation(GameCulture.Chinese, "瓦特阿尔海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'黑暗精灵的精湛技艺'
拥有花岗岩，青铜和暗金的套装效果
拥有耐钢，泰坦和电容的套装效果
拥有风暴之眼，反击之盾和尖刺锁的效果
拥有食人魔凉鞋，水晶枪尖，水晶之眼和深渊贝壳的效果
召唤奥米茄驱动器和硬币袋宠物");
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
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.EyeoftheStorm))
            {
                //eye of the storm
                thorium.GetItem("EyeoftheStorm").UpdateAccessory(player, hideVisual);
            }
            
            //bronze
            modPlayer.BronzeEnchant = true;
            //rebuttal
            thoriumPlayer.championShield = true;
            //spawn pet
            player.GetModPlayer<FargoDLCPlayer>().AddPet(SoulConfig.Instance.thoriumToggles.CoinPet, hideVisual, thorium.BuffType("DrachmaBuff"), thorium.ProjectileType("DrachmaBag"));

            //durasteel
            mod.GetItem("DurasteelEnchant").UpdateAccessory(player, hideVisual);
            
            //abyssal shell
            thoriumPlayer.AbyssalShell = true;

            //conduit
            mod.GetItem("ConduitEnchant").UpdateAccessory(player, hideVisual);

            if (modPlayer.ThoriumSoul) return;

            //granite
            player.fireWalk = true;
            player.lavaImmune = true;
            player.buffImmune[24] = true;
            //titan
            modPlayer.AllDamageUp(.1f);
            //crystal eye mask
            thoriumPlayer.critDamage += 0.1f;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "GraniteEnchant");
            recipe.AddIngredient(null, "BronzeEnchant");
            recipe.AddIngredient(null, "DurasteelEnchant");
            recipe.AddIngredient(null, "TitanEnchant");
            recipe.AddIngredient(null, "ConduitEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
