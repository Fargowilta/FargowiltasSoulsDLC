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
Effects of Vampire Gland, Demon Blood Badge, Spring Steps, and Slag Stompers
Effects of Shade Band and Mana-Charged Rocketeers
Summons several pets");
            DisplayName.AddTranslation(GameCulture.Chinese, "海姆冥界之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'从海姆冥界的大厅起始, 一派终末的景象...'
拥有猎魂者，妖术，绿龙，恐惧，血肉和魔血的套装效果
拥有熔岩，狂战士，白骑士和先兆的套装效果
拥有心灵之火，震地靴和龙爪项链的效果
拥有吸血鬼试剂，魔血徽章，弹簧靴和熔渣重踏的效果
拥有暗影护符和魔力充能火箭靴的效果
召唤几只宠物");
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
            //wyvern pet
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.WyvernPet, hideVisual, thorium.BuffType("WyvernPetBuff"), thorium.ProjectileType("WyvernPet"));
            modPlayer.DragonEnchant = true;

            //demon blood effect
            modPlayer.DemonBloodEnchant = true;
            //demon blood badge
            thoriumPlayer.CrimsonBadge = true;
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
            //blister pet
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.BlisterPet, hideVisual, thorium.BuffType("BlisterBuff"), thorium.ProjectileType("BlisterPet"));
            modPlayer.FleshEnchant = true;
            //pet
            modPlayer.KnightEnchant = true;
            
            //berserker
            mod.GetItem("BerserkerEnchant").UpdateAccessory(player, hideVisual);

            if (modPlayer.ThoriumSoul) return;

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
