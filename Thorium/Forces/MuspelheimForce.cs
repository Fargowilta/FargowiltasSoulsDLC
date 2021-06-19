﻿using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Buffs.Pet;
using FargowiltasSoulsDLC.Thorium.Enchantments;
using FargowiltasSouls;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class MuspelheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Muspelheim");
            Tooltip.SetDefault(
@"'A blazing heat, the mark of Surtr...'
All armor bonuses from Sandstone, Danger, Flight, and Fungus
All armor bonuses Living Wood, Bulb, and Life Bloom
Effects of Night Shade Petal, Flawless Chrysalis, and Bee Booties
Summons a pet Glitter");
            DisplayName.AddTranslation(GameCulture.Chinese, "穆斯贝尔海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'炽热之火, 史尔特尔的标志...'
拥有砂石，致危，飞羽和真菌的套装效果
拥有生命木，花瓣和树人的套装效果
拥有影缀花，无暇之蛹和蜜蜂靴的效果
召唤闪光宠物");
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

            FargoPlayer fargoPlayer = player.GetModPlayer<FargoPlayer>();

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            
            //life bloom effect
            modPlayer.LifeBloomEnchant = true;
            //chrysalis
            thoriumPlayer.cocoonAcc = true;
            //living wood set bonus
            thoriumPlayer.setLivingWood = true;
            //free boi
            modPlayer.LivingWoodEnchant = true;
            modPlayer.AddMinion(SoulConfig.Instance.thoriumToggles.SaplingMinion, thorium.ProjectileType("MinionSapling"), 10, 2f);

            //bulb set bonus
            modPlayer.BulbEnchant = true;
            //bee booties
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.BeeBooties))
            {
                thorium.GetItem("BeeBoots").UpdateAccessory(player, hideVisual);
                player.moveSpeed -= 0.15f;
                player.maxRunSpeed -= 1f;
            }

            if (modPlayer.ThoriumSoul) return;

            //sandstone
            player.doubleJumpSandstorm = true;
            //danger
            mod.GetItem("DangerEnchant").UpdateAccessory(player, hideVisual);
            //flight
            fargoPlayer.wingTimeModifier += 1f;
            //fungus
            modPlayer.FungusEnchant = true;

        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "SandstoneEnchant");
            recipe.AddIngredient(null, "DangerEnchant");
            recipe.AddIngredient(null, "FlightEnchant");
            recipe.AddIngredient(null, "FungusEnchant");
            recipe.AddIngredient(null, "LifeBloomEnchant");

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
