using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.DataStructures;
using Terraria.Localization;
using Terraria.ModLoader;
using Terraria.ID;
using FargowiltasSouls;
using FargowiltasSouls.NPCs;

namespace FargowiltasSoulsDLC.Base.NPCs
{
    [AutoloadBossHead]
    public class Echdeath : ModNPC
    {
        public override void SetStaticDefaults()
        {
            DisplayName.SetDefault("Echdeath");
            Main.npcFrameCount[npc.type] = 11;
        }

        public override void SetDefaults()
        {
            npc.width = 60;
            npc.height = 60;
            npc.damage = int.MaxValue / 10;
            npc.defense = int.MaxValue / 10;
            npc.lifeMax = int.MaxValue / 10;
            npc.HitSound = SoundID.NPCHit57;
            npc.noGravity = true;
            npc.noTileCollide = true;
            npc.knockBackResist = 0f;
            npc.lavaImmune = true;
            npc.aiStyle = -1;
            npc.boss = true;
            npc.GetGlobalNPC<FargoSoulsGlobalNPC>().SpecialEnchantImmune = true;

            if (ModLoader.GetMod("MasomodeEX") != null)
            {
                music = ModLoader.GetMod("MasomodeEX").GetSoundSlot(SoundType.Music, "Sounds/Music/rePrologue");
            }
            else
            {
                Mod musicMod = ModLoader.GetMod("FargowiltasMusic");
                music = musicMod != null ? ModLoader.GetMod("FargowiltasMusic").GetSoundSlot(SoundType.Music, "Sounds/Music/SteelRed") : MusicID.LunarBoss;
            }
            musicPriority = (MusicPriority)12;
        }

        public override void ScaleExpertStats(int numPlayers, float bossLifeScale)
        {
            npc.damage = int.MaxValue / 10;
            npc.lifeMax = int.MaxValue / 10;
        }

        public override void BossLoot(ref string name, ref int potionType)
        {
            potionType = mod.ItemType("Sadism");
        }

        public override bool CanHitPlayer(Player target, ref int cooldownSlot)
        {
            cooldownSlot = 1;
            return true;
        }

        public override void AI()
        {
            if (!npc.HasValidTarget)
            {
                //npc.ai[0] = 0;
                npc.TargetClosest();
                /*if (!npc.HasValidTarget)
                {
                    npc.active = false;
                    return;
                }*/
            }

            //npc.life = npc.lifeMax;
            npc.damage = npc.defDamage;
            npc.defense = npc.defDefense;

            npc.ai[0] += 0.05f;
            
            if (npc.velocity == Vector2.Zero)
                npc.velocity = -Vector2.UnitY * npc.ai[0];

            if (npc.HasValidTarget)
            {
                Player player = Main.player[npc.target];
                npc.direction = npc.spriteDirection = npc.Center.X < player.Center.X ? 1 : -1;
                if (npc.ai[1] == 1)
                    npc.position += (player.position - player.oldPosition) * 0.25f;
                npc.velocity = npc.DirectionTo(player.Center) * npc.ai[0];
                if (npc.velocity.Length() > npc.Distance(player.Center))
                    npc.Center = player.Center;

                if (npc.timeLeft < 600)
                    npc.timeLeft = 600;
            }
            else
            {
                npc.velocity = Vector2.Normalize(npc.velocity) * npc.ai[0];
                if (npc.timeLeft > 60)
                    npc.timeLeft = 60;
            }

            npc.scale = 1f + npc.ai[0] / 4f;
            
            if (Main.netMode != NetmodeID.MultiplayerClient)
            {
                int fullSize = (int)(40 * npc.scale);

                if (npc.ai[1] == 1)
                {
                    for (int i = -fullSize / 2; i <= fullSize / 2; i += 8)
                    {
                        for (int j = -fullSize / 2; j <= fullSize / 2; j += 8)
                        {
                            int tileX = (int)(npc.Center.X + i) / 16;
                            int tileY = (int)(npc.Center.Y + j) / 16;

                            //out of bounds checks
                            if (tileX > -1 && tileX < Main.maxTilesX && tileY > -1 && tileY < Main.maxTilesY)
                            {
                                Tile tile = Framing.GetTileSafely(tileX, tileY);
                                if (tile.type != 0 || tile.wall != 0)
                                {
                                    WorldGen.KillTile(tileX, tileY, noItem: true);
                                    WorldGen.KillWall(tileX, tileY);
                                    if (Main.netMode == NetmodeID.Server)
                                        NetMessage.SendData(MessageID.TileChange, -1, -1, null, 0, tileX, tileY);
                                }
                            }
                        }
                    }
                }

                for (int i = 0; i < Main.maxNPCs; i++)
                {
                    if (Main.npc[i].active && Main.npc[i].type != npc.type && npc.Distance(Main.npc[i].Center) < fullSize / 2)
                    {
                        if (Main.netMode == NetmodeID.SinglePlayer)
                            Main.NewText(":echdeath:", Color.Red);
                        else if (Main.netMode == NetmodeID.Server)
                            NetMessage.BroadcastChatMessage(NetworkText.FromLiteral(":echdeath:"), Color.Red);
                        
                        Main.npc[i].StrikeNPC(npc.damage, 99f, npc.Center.X < Main.npc[i].Center.X ? 1 : -1);
                        for (int j = 0; j < 100; j++)
                            CombatText.NewText(Main.npc[i].Hitbox, Color.Red, Main.rand.Next(npc.damage), true);
                    }
                }
            }

            if (Main.LocalPlayer.active && !Main.LocalPlayer.dead && !Main.LocalPlayer.ghost
                && npc.Hitbox.Intersects(Main.LocalPlayer.Hitbox))
            {
                Main.NewText(":echdeath:", Color.Red);
                Main.LocalPlayer.ResetEffects();
                Main.LocalPlayer.ghost = true;
                Main.LocalPlayer.KillMe(PlayerDeathReason.ByNPC(npc.whoAmI), npc.damage, 0);
                for (int i = 0; i < 100; i++)
                    CombatText.NewText(Main.LocalPlayer.Hitbox, Color.Red, Main.rand.Next(npc.damage), true);
            }

            if (npc.ai[1] == 1)
            {
                if (!Main.dedServ && Main.LocalPlayer.active)
                    Main.LocalPlayer.GetModPlayer<FargoPlayer>().Screenshake = 2;

                if (npc.localAI[0] == 0)
                {
                    Main.NewText("Echdeath has enraged.", Color.DarkRed);
                    npc.localAI[0] = 1;
                    for (int i = 0; i < npc.buffImmune.Length; i++)
                        npc.buffImmune[i] = true;
                }
                while (npc.buffType[0] != 0)
                    npc.DelBuff(0);
                if (npc.ai[2] == 0) //force life back to max until it works
                {
                    if (npc.life == npc.lifeMax)
                        npc.ai[2] = 1;
                    npc.life = npc.lifeMax;
                }
            }
            else
            {
                if (npc.ai[0] > 30)
                    npc.ai[0] = 30;
            }
        }

        public override void FindFrame(int frameHeight)
        {
            if (++npc.frameCounter > 34 - npc.ai[0])
            {
                npc.frameCounter = 0;
                npc.frame.Y += frameHeight;
                if (npc.frame.Y >= Main.npcFrameCount[npc.type] * frameHeight)
                    npc.frame.Y = 0;
            }
        }

        public override bool StrikeNPC(ref double damage, int defense, ref float knockback, int hitDirection, ref bool crit)
        {
            if (npc.ai[1] == 1)
            {
                while (npc.buffType[0] != 0)
                    npc.DelBuff(0);

                damage = 1;
                crit = false;
                return false;
            }
            return true;
        }

        public override void ModifyHitPlayer(Player target, ref int damage, ref bool crit)
        {
            if (target.active && !target.dead && !target.ghost)
            {
                Main.NewText(":echdeath:", Color.Red);
                target.ResetEffects();
                target.ghost = true;
                target.KillMe(PlayerDeathReason.ByNPC(npc.whoAmI), npc.damage, 0);
                for (int i = 0; i < 100; i++)
                    CombatText.NewText(target.Hitbox, Color.Red, Main.rand.Next(npc.damage), true);
            }
        }

        public override bool CheckDead()
        {
            if (npc.ai[1] == 1 && npc.ai[2] == 1)
                return true;

            npc.active = true;
            if (Main.netMode == NetmodeID.MultiplayerClient)
            {
                npc.life = 1;
            }
            else
            {
                npc.life = npc.lifeMax;
                npc.ai[1] = 1;
            }
            return false;
        }

        public override bool PreNPCLoot()
        {
            return false;
        }

        public override void NPCLoot()
        {
            Main.NewText("HOW", Color.Red);
            Item.NewItem(npc.Hitbox, mod.ItemType("HentaiSpear"));
            Item.NewItem(npc.Hitbox, mod.ItemType("SparklingLove"));
            Item.NewItem(npc.Hitbox, mod.ItemType("StyxGazer"));
        }

        public override void BossHeadSpriteEffects(ref SpriteEffects spriteEffects)
        {
            spriteEffects = npc.spriteDirection < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;
        }

        public override bool PreDraw(SpriteBatch spriteBatch, Color lightColor)
        {
            Texture2D texture2D13 = Main.npcTexture[npc.type];
            Rectangle rectangle = npc.frame;
            Vector2 origin2 = rectangle.Size() / 2f;

            Color color26 = lightColor;
            color26 = npc.GetAlpha(color26);

            SpriteEffects effects = npc.spriteDirection < 0 ? SpriteEffects.FlipHorizontally : SpriteEffects.None;

            Main.spriteBatch.Draw(texture2D13, npc.Center - Main.screenPosition + new Vector2(0f, npc.gfxOffY), new Microsoft.Xna.Framework.Rectangle?(rectangle), npc.GetAlpha(lightColor), npc.rotation, origin2, npc.scale, effects, 0f);
            return false;
        }
    }
}
