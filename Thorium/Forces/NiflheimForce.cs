﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class NiflheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Niflheim");
            Tooltip.SetDefault(
@"'A world of mist, a sign of the dead...'
All armor bonuses from Crier, Noble, Cyber Punk, Ornate, and Maestro
Effects of Ring of Unity and Mix Tape
Effects of Auto Tuner, Concert Tickets, and Metronome");
            DisplayName.AddTranslation(GameCulture.Chinese, "尼福尔海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'迷雾之界, 死亡的象征...'
拥有传讯员，贵族，赛博朋克，华贵和大师的套装效果
拥有团结之戒和杂集磁带的效果
拥有自动校音器, 音乐会门票和节拍器的效果");
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

            //noble
            mod.GetItem("NobleEnchant").UpdateAccessory(player, hideVisual);
            //cyber punk
            mod.GetItem("CyberPunkEnchant").UpdateAccessory(player, hideVisual);
            //Maestro
            mod.GetItem("MaestroEnchant").UpdateAccessory(player, hideVisual);

            if (modPlayer.ThoriumSoul) return;

            //crier
            thoriumPlayer.bardBuffDuration += 180;
            //ornate
            mod.GetItem("OrnateEnchant").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "CrierEnchant");
            recipe.AddIngredient(null, "NobleEnchant");
            recipe.AddIngredient(null, "CyberPunkEnchant");
            recipe.AddIngredient(null, "OrnateEnchant");
            recipe.AddIngredient(null, "MaestroEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
