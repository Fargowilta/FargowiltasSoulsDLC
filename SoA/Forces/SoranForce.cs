using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;
using Microsoft.Xna.Framework;

namespace FargowiltasSoulsDLC.SoA.Forces
{
    public class SoranForce : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Soran");
            Tooltip.SetDefault(
@"'The true power of the Soraniti'
All armor bonuses from Blazing Brute, Cosmic Commander, and Nebulous Apprentice
All armor bonuses from Stellar Priest, Quasar, and Fallen Prince
Effects of Nuba's Blessing, Novaniel's Resolve, and Celestial Ring");
            DisplayName.AddTranslation(GameCulture.Chinese, "索兰之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'索兰的真正力量'
拥有赤炎, 宇宙指挥官和星云学徒的套装效果
拥有恒星牧师和堕落王子的套装效果
拥有努巴的祝福, 诺瓦尼尔的决心和天体星环的效果
召唤数个宠物");
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
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModdedPlayer modPlayer = player.GetModPlayer<ModdedPlayer>();

            //blazing brute
            modPlayer.SolariusArmor = true;
            //cosmic commander
            modPlayer.VoxaArmor = true;
            //nebulous apprentice
            modPlayer.NubaArmor = true;
            //nubas blessing
            modPlayer.NubaBlessing = true;
            //stellar priest
            modPlayer.DustiteArmor = true;
            if (player.ownedProjectileCounts[soa.ProjectileType("StellarGuardian")] == 0 && !player.dead)
            {
                Projectile.NewProjectile(player.Center, Vector2.Zero, soa.ProjectileType("StellarGuardian"), (int)(1000f * player.minionDamage), 0f, player.whoAmI, 0f, 0f);
            }
            //quasar
            modPlayer.NovaSetEffect = true;
            //fallen prince
            modPlayer.NovanielArmor = true;
            //novaniels resolve
            ModLoader.GetMod("SacredTools").GetItem("NovanielResolve").UpdateAccessory(player, hideVisual);
            //celestial ring
            ModLoader.GetMod("SacredTools").GetItem("LunarRing").UpdateAccessory(player, hideVisual);

        }


        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "BlazingBruteEnchant");
            recipe.AddIngredient(null, "CosmicCommanderEnchant");
            recipe.AddIngredient(null, "NebulousApprenticeEnchant");
            recipe.AddIngredient(null, "StellarPriestEnchant");
            recipe.AddIngredient(null, "QuasarEnchant");
            recipe.AddIngredient(null, "FallenPrinceEnchant");
            recipe.AddIngredient(soa.ItemType("LunarRing"));
            recipe.AddIngredient(soa.ItemType("TrueMoonEdgedPandolarra"));

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
