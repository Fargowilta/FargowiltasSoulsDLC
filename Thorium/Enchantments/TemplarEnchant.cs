using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Terraria.Localization;
using ThoriumMod.Items.HealerItems;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class TemplarEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Templar Enchantment");
            Tooltip.SetDefault(
@"'For the church!'
If an ally is below half health, you will gain increased healing abilities");
            DisplayName.AddTranslation(GameCulture.Chinese, "圣殿骑士魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'为了教堂!'
队友生命值低于一半时, 增强治疗能力");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 3;
            item.value = 80000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            //set bonus
            for (int i = 0; i < 255; i++)
            {
                Player player2 = Main.player[i];
                if (player2.active && !player2.dead && player2.statLife < (int)(player2.statLifeMax2 * 0.5) && player2 != player)
                {
                    player.lifeRegen += 3;
                    player.moveSpeed += .1f;
                }
            }
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<TemplarsCirclet>());
            recipe.AddIngredient(ModContent.ItemType<TemplarsTabard>());
            recipe.AddIngredient(ModContent.ItemType<TemplarsLeggings>());
            recipe.AddIngredient(ModContent.ItemType<LifesGift>());
            recipe.AddIngredient(ModContent.ItemType<TemplarsGrace>());
            recipe.AddIngredient(ModContent.ItemType<TemplarJudgment>());
            recipe.AddIngredient(ModContent.ItemType<GraniteIonStaff>());
            recipe.AddIngredient(ModContent.ItemType<Prophecy>());
            recipe.AddIngredient(ModContent.ItemType<LifeDisperser>());
            recipe.AddIngredient(ModContent.ItemType<BoneTrumpet>());

            recipe.AddTile(TileID.DemonAltar);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
