using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.Audio;

namespace FargowiltasSoulsDLC.Base.Items
{
    public class PandorasBox : ModItem
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Pandora's Box");
            Tooltip.SetDefault("Summons something at random\n" +
                                "Much friendlier options during the day");

            //DisplayName.AddTranslation((int)GameCulture.CultureName.Chinese, "潘多拉之盒");
            //Tooltip.AddTranslation((int)GameCulture.CultureName.Chinese, "随机召唤\n" +
                                                        //"白天时使用是个更友好的选择");
        }

        public override void SetDefaults()
        {
            Item.width = 20;
            Item.height = 20;
            Item.maxStack = 20;
            Item.value = 1000;
            Item.rare = ItemRarityID.Blue;
            Item.useAnimation = 30;
            Item.useTime = 30;
            Item.useStyle = ItemUseStyleID.HoldUp;
            Item.consumable = true;
        }

        public override bool? UseItem(Player player)
        {
            Tile centerTile = Framing.GetTileSafely(player.Center);
            
            //if (centerTile.type == ModLoader.GetMod("Fargowiltas").TileType("EchPaintingSheet")
            //    && centerTile.wall == WallID.LihzahrdBrickUnsafe && Main.eclipse && Main.moonPhase == 0
            //    && NPC.AnyNPCs(NPCID.DungeonGuardian)
            //    && player.controlUp && player.controlDown && !player.controlLeft && !player.controlRight)
            //{
            //    Tile floorTile = Framing.GetTileSafely(new Vector2(player.Center.X, player.position.Y + player.height + 8));
            //    if (floorTile.type == TileID.LunarBrick)
            //    {
            //        int type = mod.NPCType("Echdeath");
            //        NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), type);
            //        Main.PlaySound(SoundID.Roar, (int)player.position.X, (int)player.position.Y, 0);
            //        return true;
            //    }
            //}
            
            //if (centerTile.type == TileID.PlanteraBulb) //spawn guntera when in front of bulb
            //{
            //    int type = ModContent.NPCType<NPCs.Guntera.Guntera>();
            //    NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), type);
            //    Main.PlaySound(SoundID.Roar, (int)player.position.X, (int)player.position.Y, 0);
            //    return true;
            //}

            //if (centerTile.wall == WallID.Flesh) //spawn ceiling when in front of flesh wall and on luminite brick
            //{
            //    Tile floorTile = Framing.GetTileSafely(new Vector2(player.Center.X, player.position.Y + player.height + 8));
            //    if (floorTile.type == TileID.LunarBrick)
            //    {
            //        int type = ModContent.NPCType<NPCs.Ceiling.CeilingOfMoonLord>();
            //        NPC.NewNPC((int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), type);
            //        Main.PlaySound(SoundID.Roar, (int)player.position.X, (int)player.position.Y, 0);
            //        return true;
            //    }
            //}

            int totalNPCs = NPCLoader.NPCCount;

            for (int i = 0; i < 5; i++)
            {
                NPC npc = new NPC();
                npc.SetDefaults(Main.rand.Next(totalNPCs));

                if ((!Main.hardMode && npc.boss)
                    || (!NPC.downedGolemBoss && (npc.type == NPCID.DD2Betsy || npc.type == NPCID.MartianProbe))
                    || (!NPC.downedAncientCultist && (npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerVortex)))
                {
                    i--;
                    continue;
                }

                if (Main.dayTime)
                {
                    if (npc.lifeMax > 200 || npc.boss || npc.townNPC || npc.dontTakeDamage || npc.type == NPCID.BoundGoblin || npc.type == NPCID.BoundMechanic || npc.type == NPCID.BoundWizard || npc.type == NPCID.BartenderUnconscious || npc.type == NPCID.WebbedStylist)
                    {
                        i--;
                    }
                    else
                    {
                        NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), npc.type);
                    }
                }
                //night
                else
                {
                    if (npc.townNPC || npc.dontTakeDamage || npc.type == NPCID.BoundGoblin || npc.type == NPCID.BoundMechanic || npc.type == NPCID.BoundWizard || npc.type == NPCID.BartenderUnconscious || npc.type == NPCID.WebbedStylist || npc.type == NPCID.LunarTowerNebula || npc.type == NPCID.LunarTowerSolar || npc.type == NPCID.LunarTowerStardust || npc.type == NPCID.LunarTowerVortex)
                    {
                        i--;
                    }
                    else
                    {
                        NPC.NewNPC(player.GetSource_ItemUse(Item), (int)player.position.X + Main.rand.Next(-800, 800), (int)player.position.Y + Main.rand.Next(-1000, -250), npc.type);
                    }
                }
            }

            SoundEngine.PlaySound(SoundID.Roar, player.position);
            return true;
        }
    }
}
