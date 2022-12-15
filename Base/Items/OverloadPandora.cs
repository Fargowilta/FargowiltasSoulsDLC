//using Microsoft.Xna.Framework;
//using Terraria;
//using Terraria.ID;
//using Terraria.Localization;
//using Terraria.ModLoader;

//namespace Fargowiltas.Items.Summons.SwarmSummons
//{
//    public class OverloadPandora : ModItem
//    {
//        public override void SetStaticDefaults()
//        {
//            DisplayName.SetDefault("Pandora's Tesseract");
//            Tooltip.SetDefault("The ultimate swarm");
//        }

//        public override void SetDefaults()
//        {
//            Item.width = 20;
//            Item.height = 20;
//            Item.maxStack = 1;
//            Item.value = 1000;
//            Item.rare = 11;
//            Item.useAnimation = 30;
//            Item.useTime = 30;
//            Item.useStyle = 4;
//            Item.consumable = true;
//        }

//        //public override bool CanUseItem(Player player)
//        //{
//        //    return !Fargowiltas.SwarmActive && !Main.dayTime;
//        //}

//        //public override bool UseItem(Player player)
//        //{
//        //    Fargowiltas.SwarmActive = true;
//        //    Fargowiltas.SwarmTotal = 500;
//        //    Fargowiltas.SwarmKills = 0;
//        //    Fargowiltas.SwarmSpawned = 40;

//        //    for (int i = 0; i < Fargowiltas.SwarmSpawned; i++)
//        //    {
//        //        int boss = NPC.NewNPC((int)player.position.X + Main.rand.Next(-1000, 1000), (int)player.position.Y + Main.rand.Next(-1000, -400), FargoGlobalNPC.Bosses[Main.rand.Next(FargoGlobalNPC.Bosses.Length)]);
//        //        Main.npc[boss].GetGlobalNPC<FargoGlobalNPC>().PandoraActive = true;
//        //    }

//        //    /*if (Main.netMode == 2)
//        //    {
//        //        NetMessage.BroadcastChatMessage(NetworkText.FromLiteral("The jungle beats as one!"), new Color(175, 75, 255));
//        //    }
//        //    else
//        //    {
//        //        Main.NewText("The jungle beats as one!", 175, 75, 255);
//        //    }*/

//        //    Main.PlaySound(15, (int)player.position.X, (int)player.position.Y, 0);
//        //    return true;
//        //}

//        public override void AddRecipes()
//        {
//            ModRecipe recipe = new ModRecipe(mod);
//            recipe.AddIngredient(null, "OverloadSlimeCrown");
//            recipe.AddIngredient(null, "OverloadEye");
//            recipe.AddIngredient(null, "OverloadWorm");
//            recipe.AddIngredient(null, "OverloadBrain");
//            recipe.AddIngredient(null, "OverloadBee");
//            recipe.AddIngredient(null, "OverloadSkele");
//            recipe.AddIngredient(null, "OverloadDestroyer");
//            recipe.AddIngredient(null, "OverloadTwins");
//            recipe.AddIngredient(null, "OverloadPrime");
//            recipe.AddIngredient(null, "OverloadPlant");
//            recipe.AddIngredient(null, "OverloadGolem");
//            recipe.AddIngredient(null, "OverloadFish");
//            recipe.AddIngredient(null, "OverloadMoon");
//            recipe.AddTile(TileID.DemonAltar);
//            recipe.SetResult(this);
//            recipe.AddRecipe();
//        }
//    }
//}