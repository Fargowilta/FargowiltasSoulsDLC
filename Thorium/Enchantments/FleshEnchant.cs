using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Depths;
using ThoriumMod.Items.Flesh;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.HealerItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class FleshEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Flesh Enchantment");
            Tooltip.SetDefault(
@"'Symbiotically attached to your body'
Consecutive attacks against enemies might drop flesh, which grants bonus life and damage
Effects of Vampire Gland
Summons a pet Flying Blister");
            DisplayName.AddTranslation(GameCulture.Chinese, "血肉魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'与你共生'
连续攻击敌人时概率掉落肉，拾起肉时增加生命值和伤害
拥有吸血鬼试剂的效果
召唤泡泡虫宠物");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 4;
            item.value = 120000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            FargoDLCPlayer modPlayer = player.GetModPlayer<FargoDLCPlayer>();
            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //flesh set bonus
            thoriumPlayer.Symbiotic = true;
            //vampire gland
            thoriumPlayer.vampireGland = true;
            //blister pet
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.BlisterPet, hideVisual, thorium.BuffType("BlisterBuff"), thorium.ProjectileType("BlisterPet"));
            modPlayer.FleshEnchant = true;
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<FleshMask>());
            recipe.AddIngredient(ModContent.ItemType<FleshBody>());
            recipe.AddIngredient(ModContent.ItemType<FleshLegs>());
            recipe.AddIngredient(ModContent.ItemType<VampireGland>());
            recipe.AddIngredient(ModContent.ItemType<ToothOfTheConsumer>());
            recipe.AddIngredient(ModContent.ItemType<FleshMace>());
            recipe.AddIngredient(ModContent.ItemType<BloodBelcher>());
            recipe.AddIngredient(ModContent.ItemType<StalkersSnippers>());
            recipe.AddIngredient(ModContent.ItemType<BloodRage>());
            recipe.AddIngredient(ModContent.ItemType<BlisterSack>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
