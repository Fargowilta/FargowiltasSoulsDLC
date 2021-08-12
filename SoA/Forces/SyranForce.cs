using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Localization;
using SacredTools;

namespace FargowiltasSoulsDLC.SoA.Forces
{
    public class SyranForce : ModItem
    {
        private readonly Mod soa = ModLoader.GetMod("SacredTools");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("SacredTools") != null;
        }

        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Force of Syrus");
            Tooltip.SetDefault(
@"'Dragon Rage empowers you, and encourages you to go on'
All armor bonuses from Void Warden, Vulcan Reaper, and Flarium
All armor bonuses from Asthraltite
Effects of Ring of the Fallen, Memento Mori, and Arcanum of the Caster");
            DisplayName.AddTranslation(GameCulture.Chinese, "赛伦之力");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'胸腔中充斥着龙之怒, 激励着你继续前进'
拥有虚空守望, 火神收割者和熔火的套装效果
拥有阿斯德罗特的套装效果
拥有堕落之戒, 死亡意志和魔法奥秘的效果
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

            //void warden
            modPlayer.voidDefense = true;
            modPlayer.voidOffense = true;

            //vulcan reaper
            player.buffImmune[soa.BuffType("SerpentWrath")] = true;
            player.buffImmune[soa.BuffType("ObsidianCurse")] = true;

            //flarium
            modPlayer.DragonSetEffect = true;

            //exitum
            //soon tm

            //asthraltite
            modPlayer.AstralSet = true;
            //ring of the fallen
            ModLoader.GetMod("SacredTools").GetItem("AsthralRing").UpdateAccessory(player, hideVisual);
            //memento mori
            ModLoader.GetMod("SacredTools").GetItem("MementoMori").UpdateAccessory(player, hideVisual);
            //arcanum of the caster
            ModLoader.GetMod("SacredTools").GetItem("CasterArcanum").UpdateAccessory(player, hideVisual);

        }


        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.SoALoaded) return;

            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(null, "VoidWardenEnchant");
            recipe.AddIngredient(null, "VulcanReaperEnchant");
            recipe.AddIngredient(null, "FlariumEnchant");
            recipe.AddIngredient(null, "ExitumLuxEnchant");
            recipe.AddIngredient(null, "AsthraltiteEnchant");

            recipe.AddTile(ModLoader.GetMod("Fargowiltas").TileType("CrucibleCosmosSheet"));
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
