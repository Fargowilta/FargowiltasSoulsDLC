using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using ThoriumMod;
using Microsoft.Xna.Framework;
using Terraria.Localization;
using ThoriumMod.Empowerments;
using ThoriumMod.Items;
using ThoriumMod.Items.BardItems;

namespace FargowiltasSoulsDLC.Thorium.Enchantments
{
    public class CyberPunkEnchant : ModItem
    {
        private readonly Mod thorium = ModLoader.GetMod("ThoriumMod");

        public override bool Autoload(ref string name)
        {
            return ModLoader.GetMod("ThoriumMod") != null;
        }
        
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Cyber Punk Enchantment");
            Tooltip.SetDefault(
@"'Techno rave!'
Pressing the 'Special Ability' key will cycle you through four states
Effects of Auto Tuner and Metal Music Player");
            DisplayName.AddTranslation(GameCulture.Chinese, "赛博朋克魔石");
            Tooltip.AddTranslation(GameCulture.Chinese, 
@"'科技电音狂欢!'
按下'套装技能'键使你在下列四种状态下切换：
红色 - 你和周围友军获得降调伤害II与伤害II
绿色 - 你和周围友军获得移速II与飞行时间II
紫色 - 你和周围友军获得资源上限II与资源再生II
蓝色 - 你和周围友军获得防御II与伤害减免II
拥有自动校音器和红色播放器的效果");
        }

        public override void SetDefaults()
        {
            item.width = 20;
            item.height = 20;
            item.accessory = true;
            ItemID.Sets.ItemNoGravity[item.type] = true;
            item.rare = 6;
            item.value = 150000;
        }

        public override void UpdateAccessory(Player player, bool hideVisual)
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;

            ThoriumPlayer thoriumPlayer = player.GetModPlayer<ThoriumPlayer>();
            if (SoulConfig.Instance.GetValue(SoulConfig.Instance.thoriumToggles.CyberStates))
            {
                //cyber set bonus, good lord
                thoriumPlayer.cyberHeadAllowed = true;
                thoriumPlayer.cyberBodyAllowed = true;
                thoriumPlayer.cyberLegsAllowed = true;

                thoriumPlayer.setCyberPunk = true;

                //EmpowermentPool empowermentPool = new EmpowermentPool();
                
                //empowermentPool.Add<FlatDamage>(2);
                //empowermentPool.Add<Damage>(2);

                //Main.NewText(thoriumPlayer.setCyberPunkValue);

                switch (thoriumPlayer.setCyberPunkValue)
                {
                    case 0:
                        {
                            //EmpowermentLoader.appl

                            Lighting.AddLight(player.position, 0.45f, 0.1f, 0.1f);
                            EmpowermentTimer empTimer = thoriumPlayer.GetEmpTimer<FlatDamage>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                            }
                            empTimer = thoriumPlayer.GetEmpTimer<Damage>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                                return;
                            }
                            break;
                        }
                    case 1:
                        {
                            Lighting.AddLight(player.position, 0.15f, 0.45f, 0.15f);
                            EmpowermentTimer empTimer = thoriumPlayer.GetEmpTimer<MovementSpeed>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                            }
                            empTimer = thoriumPlayer.GetEmpTimer<FlightTime>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                                return;
                            }
                            break;
                        }
                    case 2:
                        {
                            Lighting.AddLight(player.position, 0.35f, 0.1f, 0.45f);
                            EmpowermentTimer empTimer = thoriumPlayer.GetEmpTimer<ResourceMaximum>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                            }
                            empTimer = thoriumPlayer.GetEmpTimer<ResourceRegen>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                                return;
                            }
                            break;
                        }
                    case 3:
                        {
                            Lighting.AddLight(player.position, 0.1f, 0.2f, 0.65f);
                            EmpowermentTimer empTimer = thoriumPlayer.GetEmpTimer<Defense>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                            }
                            empTimer = thoriumPlayer.GetEmpTimer<DamageReduction>();
                            if (empTimer.level == 2)
                            {
                                empTimer.fade = false;
                            }
                            break;
                        }
                    default:
                        return;
                }
            }

            if (player.GetModPlayer<FargoDLCPlayer>().ThoriumSoul) return;

            //auto tuner
            thoriumPlayer.accAutoTuner = true;
            //music player
            thoriumPlayer.accMusicPlayer = true;
            thoriumPlayer.accMP3Brass = true;

            //disstrck, mention/fix music player
        }

        public override void AddRecipes()
        {
            if (!FargowiltasSoulsDLC.Instance.ThoriumLoaded) return;
            
            ModRecipe recipe = new ModRecipe(mod);

            recipe.AddIngredient(ModContent.ItemType<CyberPunkHeadset>());
            recipe.AddIngredient(ModContent.ItemType<CyberPunkSuit>());
            recipe.AddIngredient(ModContent.ItemType<CyberPunkLeggings>());
            recipe.AddIngredient(ModContent.ItemType<AutoTuner>());
            recipe.AddIngredient(ModContent.ItemType<TunePlayerDamage>());
            recipe.AddIngredient(ModContent.ItemType<DissTrack>());
            recipe.AddIngredient(ModContent.ItemType<Kazoo>());
            recipe.AddIngredient(ModContent.ItemType<HallowedMegaphone>());
            recipe.AddIngredient(ModContent.ItemType<MidnightBassBooster>());
            recipe.AddIngredient(ModContent.ItemType<RiffWeaver>());

            recipe.AddTile(TileID.CrystalBall);
            recipe.SetResult(this);
            recipe.AddRecipe();
        }
    }
}
