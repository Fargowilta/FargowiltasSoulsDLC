using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using FargowiltasSoulsDLC.Thorium.Enchantments;
using FargowiltasSouls;

namespace FargowiltasSoulsDLC.Thorium.Forces
{
    public class JotunheimForce : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Jotunheim");
            Tooltip.SetDefault(
@"'A bitter cold, the power of the Jotuns...'
All armor bonuses from Depth Diver, Yew Wood, and Tide Hunter
All armor bonuses from Naga Skin, Icy, Cryomancer, and Whispering
Effects of Sea Breeze Pendant and Bubble Magnet
Effects of Goblin War Shield, Agnor's Bowl, and Ice Bound Strider Hide
Summons several pets");
            DisplayName.AddTranslation(GameCulture.Chinese, "约顿海姆之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'彻骨严寒, 巨人的力量...'
拥有深渊潜游者，紫衫木和猎潮者的套装效果
拥有娜迦，碎冰，极寒巫师和低语者的套装效果  
拥有海洋通行证和泡泡磁铁的效果
拥有哥布林战盾, 琵琶鱼球碗和遁蛛契约的效果
召唤几个宠物");
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

            //bubble magnet
            thoriumPlayer.bubbleMagnet = true;
            modPlayer.DepthEnchant = true;
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.JellyfishPet, hideVisual, thorium.BuffType("JellyPet"), thorium.ProjectileType("JellyfishPet"));

            //tide hunter
            modPlayer.TideHunterEnchant = true;
            //angler bowl
            thorium.GetItem("AnglerBowl").UpdateAccessory(player, hideVisual);
            //yew wood
            modPlayer.YewEnchant = true;
            
            //strider hide
            thoriumPlayer.frostBonusDamage = true;
            //pets
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.OwlPet, hideVisual, thorium.BuffType("SnowyOwlBuff"), thorium.ProjectileType("SnowyOwlPet"));

            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.IcyBarrier))
            {
                //icy set bonus
                thoriumPlayer.setIcy = true;
                if (player.ownedProjectileCounts[thorium.ProjectileType("IcyAura")] < 1)
                {
                    Projectile.NewProjectile(player.Center.X, player.Center.Y, 0f, 0f, thorium.ProjectileType("IcyAura"), 0, 0f, player.whoAmI, 0f, 0f);
                }
            }
            //cryo
            modPlayer.CryoEnchant = true;
            
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.WhisperingTentacles))
            {
                mod.GetItem("WhisperingEnchant").UpdateAccessory(player, hideVisual);
            }

            if (modPlayer.ThoriumSoul) return;

            //water bonuses
            if (player.breath <= player.breathMax + 2)
            {
                player.breath = player.breathMax + 3;
            }
            //sea breeze pendant
            player.accFlipper = true;
            if (player.wet || thoriumPlayer.drownedDoubloon)
            {
                player.AddBuff(thorium.BuffType("AquaticAptitude"), 60, true);
                player.GetModPlayer<FargoDLCPlayer>().AllDamageUp(.1f);
                fargoPlayer.AttackSpeed += .2f;
            }
            //quicker in water
            player.ignoreWater = true;
            if (player.wet)
            {
                player.moveSpeed += 0.15f;
            }

            //goblin war shield
            thorium.GetItem("GoblinWarshield").UpdateAccessory(player, hideVisual);
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DepthDiverEnchant>());
            recipe.AddIngredient(ModContent.ItemType<TideHunterEnchant>());
            recipe.AddIngredient(ModContent.ItemType<NagaSkinEnchant>());
            recipe.AddIngredient(ModContent.ItemType<CryomancerEnchant>());
            recipe.AddIngredient(ModContent.ItemType<WhisperingEnchant>());

            recipe.AddTile(TileID.LunarCraftingStation);

            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
