using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.Dragon;
using ThoriumMod.Items.NPCItems;
using ThoriumMod.Items.ThrownItems;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class DragonEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Dragon Enchantment");
            Tooltip.SetDefault(
@"'Made from mythical scales'
Your attacks have a chance to unleash an explosion of Dragon's Flame
Effects of Dragon Talon Necklace
Summons a pet Wyvern");
            DisplayName.AddTranslation(GameCulture.Chinese, "绿龙魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'由神话中的鳞片制作而成'
你的攻击有几率释放龙息爆裂
拥有龙爪项链的效果
召唤白龙宠物");
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
            //dragon 
            thoriumPlayer.dragonSet = true;
            //dragon tooth necklace
            player.armorPenetration += 15;
            //wyvern pet
            modPlayer.AddPet(SoulConfig.Instance.thoriumToggles.WyvernPet, hideVisual, thorium.BuffType("WyvernPetBuff"), thorium.ProjectileType("WyvernPet"));
            modPlayer.DragonEnchant = true;

           // discomusicplayer
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<DragonMask>());
            recipe.AddIngredient(ModContent.ItemType<DragonBreastplate>());
            recipe.AddIngredient(ModContent.ItemType<DragonGreaves>());
            recipe.AddIngredient(ModContent.ItemType<DragonTalonNecklace>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerMovementSpeed>());
            recipe.AddIngredient(ModContent.ItemType<DragonsBreath>());
            recipe.AddIngredient(ModContent.ItemType<EbonyTail>());
            recipe.AddIngredient(ModContent.ItemType<CorrupterBalloon>(), 300);
            //recipe.AddIngredient(ItemID.ClingerStaff);
           // Absinthe Fury
            recipe.AddIngredient(ModContent.ItemType<CloudyChewToy>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
