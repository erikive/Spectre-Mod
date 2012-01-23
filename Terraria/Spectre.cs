using System;
using System.Threading;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace Terraria
{
    class Spectre
    {
        public static bool addWalls = false;
        public static bool Bunny = false;
        public static bool addTiles = false;
        public static int tileType = 0;
        public static int wallType = 30;
        public static bool showUI = true;
        public static string lastCommand = "";
        public static bool FullBright = false;
        public static bool immunetoDeBuffs = true;
        public static float LightLevel = 0.8f;
        public static bool infItems = true;
        public static int cblue = 0xff;
        public static bool hellwall = false;
        public static bool cBuffInfinite = false;
        private static string[] cCmd = new string[100];
        public static bool cGrav = true;
        public static int cgreen = 0xff;
        private static string[] cKeys = new string[100];
        public static int cred = 0xff;
        public static int cStack = 0;
        private static string debugLeftClick = "";
        public static char[] delimit = new char[] { ' ' };
        public static char[] delimit2 = new char[] { ';' };
        private static int monstersLeft = 0;
        private static int monsterType = 0;
        private static byte selAmount = 0xff;
        public static bool mouseReleaseNeeded = true;
        private static int selSize = 1;
        private static bool spawnCur = false;
        public int Index { get; protected set; }
        public static int chatSpam = 1;
        public static int speedBonus = 1;
        public static bool Ghost;

        public static Color GetStatusColor(bool test)
        {
            return new Color(Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor, Main.mouseTextColor);
        }

        public static void spam()
        {
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7))
            {
                NetMessage.SendData(25, -1, -1, Main.chatText, 0xff, 0f, 0f, 0f, 0);
                Thread.Sleep(0);
            }
        }

        public static void spamcount()
        {
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F8))
            {
                //Main.NewText(Main.chatText, 50, 0xff, 130);
                //NetMessage.SendData(25, -1, -1, Main.chatText, 0xff, 0f, 0f, 0f, 0);
                NetMessage.SendData(25, -1, -1, chatSpam.ToString() + " " + Main.chatText, 0xff, 0f, 0f, 0f, 0);
                Thread.Sleep(0);
                chatSpam++;
            }
        }

        //public static void onKeys(Microsoft.Xna.Framework.Input.Keys[] pressedKeys)
        //{
        //    if ((Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.LeftControl)) && (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.V)))
        //    {
        //        Main.chatText = Clipboard.GetText(TextDataFormat.Text);
        //        NetMessage.SendData(0x19, -1, -1, (Clipboard.GetText(TextDataFormat.Text)), 0xff, 0f, 0f, 0f, 0);
        //    }
        //    if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F6))
        //    {
        //        if (Main.noClip)
        //        {
        //            Main.noClip = false;
        //        }
        //        else
        //        {
        //            Main.noClip = true;
        //        }
        //        previousKeys = pressedKeys;
        //    }
        //}

        private static int IndexOfOccurence(string s, string match, int occurence)
        {
            int num = 1;
            int num2 = 0;
            while ((num <= occurence) && ((num2 = s.IndexOf(match, (int)(num2 + 1))) != -1))
            {
                if (num == occurence)
                {
                    return num2;
                }
                num++;
            }
            return -1;
        }

        private static void addLiquid()
        {
            int num = 0;
            int num2 = 0;
            num = (int)((Main.mouseState.X + Main.screenPosition.X) / 16f);
            num2 = (int)((Main.mouseState.Y + Main.screenPosition.Y) / 16f);
            if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                for (int i = -selSize; i <= selSize; i++)
                {
                    for (int j = selSize; j >= -selSize; j--)
                    {
                        if (debugLeftClick.CompareTo("addlava") == 0)
                        {
                            Main.tile[num + i, num2 + j].lava = true;
                        }
                        Main.tile[num + i, num2 + j].liquid = selAmount;
                        Liquid.AddWater(num + i, num2 + j);
                        WorldGen.SquareTileFrame(num + i, num2 + j, true);
                        if (Main.netMode == 1)
                        {
                            NetMessage.sendWater(num + i, num2 + j);
                        }
                    }
                }
            }
        }

        private static void addTile(int tileType)
        {
            int i = 0;
            int j = 0;
            i = (int)((Main.mouseState.X + Main.screenPosition.X) / 16f);
            j = (int)((Main.mouseState.Y + Main.screenPosition.Y) / 16f);
            if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                for (int num = -selSize; num <= selSize; num++)
                {
                    for (int num2 = selSize; num2 >= -selSize; num2--)
                    {
                        WorldGen.KillTile(i + num, j + num2, false, false, false);
                        WorldGen.PlaceTile(i + num, j + num2, tileType, true, false, -1, 0);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendTileSquare(-1, i +num, j + num2, 1);
                        }
                    }
                }
            }
        }

        private static void addWall(int wallType)
        {
            int i = 0;
            int j = 0;
            i = (int)((Main.mouseState.X + Main.screenPosition.X) / 16f);
            j = (int)((Main.mouseState.Y + Main.screenPosition.Y) / 16f);
            if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                for (int num = -selSize; num <= selSize; num++)
                {
                    for (int num2 = selSize; num2 >= -selSize; num2--)
                    {
                        WorldGen.KillWall(i + num, j + num2, false);
                        WorldGen.PlaceWall(i + num, j + num2, wallType, true);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendTileSquare(-1, i, j, 1);
                        }
                    }
                }
            }
        }

        private static void deleteLava()
        {
            int i = (Main.mouseState.X + ((int)Main.screenPosition.X)) / 0x10;
            int j = (Main.mouseState.Y + ((int)Main.screenPosition.Y)) / 0x10;
            if ((Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) && (selSize > 0))
            {
                for (int k = -selSize; k <= selSize; k++)
                {
                    for (int m = selSize; m >= -selSize; m--)
                    {
                        if (debugLeftClick.CompareTo("deleteLava") == 0)
                        {
                            Main.tile[k + i, m + j].lava = false;
                        }
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x11, -1, -1, "", 4, i + j, j + m, 0f, 0);
                        }
                    }
                }
            }
        }

        private static void deleteWater()
        {
            int i = (Main.mouseState.X + ((int)Main.screenPosition.X)) / 0x10;
            int j = (Main.mouseState.Y + ((int)Main.screenPosition.Y)) / 0x10;
            if ((Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) && (selSize > 0))
            {
                for (int k = -selSize; k <= selSize; k++)
                {
                    for (int m = selSize; m >= -selSize; m--)
                    {
                        if (debugLeftClick.CompareTo("deleteWater") == 0)
                        {
                            Main.tile[k + i, m + j].liquid = 0;
                        }
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x11, -1, -1, "", 4, i + j, j + m, 0f, 0);
                        }
                    }
                }
            }
        }

        private static void deleteWall()
        {
            int i = (Main.mouseState.X + ((int)Main.screenPosition.X)) / 0x10;
            int j = (Main.mouseState.Y + ((int)Main.screenPosition.Y)) / 0x10;
            if ((Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) && (selSize > 0))
            {
                for (int k = -selSize; k <= selSize; k++)
                {
                    for (int m = selSize; m >= -selSize; m--)
                    {
                        WorldGen.KillWall(i + k, j + m, false);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x11, -1, -1, "", 4, i + j, j + m, 0f, 0);
                        }
                    }
                }
            }
            else if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                WorldGen.KillWall(i, j, false);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x11, -1, -1, "", 4, (float)i, (float)j, 0f, 0);
                }
            }
        }

        private static void deleteTile()
        {
            int i = (Main.mouseState.X + ((int)Main.screenPosition.X)) / 0x10;
            int j = (Main.mouseState.Y + ((int)Main.screenPosition.Y)) / 0x10;
            if ((Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed) && (selSize > 0))
            {
                for (int k = -selSize; k <= selSize; k++)
                {
                    for (int m = selSize; m >= -selSize; m--)
                    {
                        WorldGen.KillTile(i + k, j + m, false, false, true);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(0x11, -1, -1, "", 4, i + j, j + m, 0f, 0);
                        }
                    }
                }
            }
            else if (Main.mouseState.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed)
            {
                WorldGen.KillTile(i, j, false, false, true);
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(0x11, -1, -1, "", 4, (float)i, (float)j, 0f, 0);
                }
            }
        }

        public static void main()
        {
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F6))
            {
                NPC.SpawnOnPlayer(0, 4);
            }
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F7))
            {
                NPC.SpawnOnPlayer(0, 13);
            }
            if (Main.keyState.IsKeyDown(Microsoft.Xna.Framework.Input.Keys.F8))
            {
                NPC.SpawnOnPlayer(0, 0x23);
            }
            if ((monstersLeft > 0) && (monsterType != 0))
            {
                if (!spawnCur)
                {
                    NPC.SpawnOnPlayer(0, monsterType);
                    Main.NewText(monstersLeft.ToString() + " left", 0xaf, 0x4b, 0xff);
                }
                else
                {
                    int num = (Main.mouseState.X + ((int)Main.screenPosition.X)) / 0x10;
                    int num2 = (Main.mouseState.Y + ((int)Main.screenPosition.Y)) / 0x10;
                    int index = NPC.NewNPC((int)Main.player[Main.myPlayer].position.X, (int)Main.player[Main.myPlayer].position.Y, monsterType, 0);
                    Main.npc[index].netUpdate = true;
                    Main.NewText(monstersLeft.ToString() + " left", 0xaf, 0x4b, 0xff);
                }
                monstersLeft--;
            }
            if (debugLeftClick.CompareTo("deletetile") == 0)
            {
                deleteTile();
            }
            if (debugLeftClick.CompareTo("deleteLava") == 0)
            {
                deleteLava();
            }
            if (debugLeftClick.CompareTo("deletewall") == 0)
            {
                deleteWall();
            }
            else if ((debugLeftClick.CompareTo("addwater") == 0) || (debugLeftClick.CompareTo("addlava") == 0))
            {
                addLiquid();
            }
            else if (debugLeftClick.CompareTo("addtile") == 0)
            {
                addTile(tileType);
            }
            else if (debugLeftClick.CompareTo("addwall") == 0)
            {
                addWall(wallType);
            }
            else if (debugLeftClick.CompareTo("deleteWater") == 0)
            {
                deleteWater();
            }
        }

        public static bool onChat(string text)
        {
            bool flag3;
            try
            {
                if (!(text.Substring(0, 1) == "\\"))
                {
                    return true;
                }
                lastCommand = text;
                string parameter = "off";
                string str = "empty command";
                string itemName = "empty string";
                int time = 1;
                var count = 1;

                if (text.IndexOf(' ') != text.LastIndexOf(' '))
                {
                    count = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                    if (count != 0)
                    {
                        parameter = parameter.Substring(0, parameter.LastIndexOf(' '));
                    }
                    else
                    {
                        count = 1;
                    }
                }


                if (IndexOfOccurence(text, " ", 1) == -1)
                {
                    str = text.Substring(1);
                }
                else if (text.IndexOf(' ') == text.LastIndexOf(' '))
                {
                    count = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                    str = text.Substring(1, text.IndexOf(' ') - 1);
                    itemName = text.Substring(text.IndexOf(' ') + 1);
                }
                else
                {
                    int num2 = IndexOfOccurence(text, " ", 2);
                    str = text.Substring(1, text.IndexOf(' ') - 1);
                    itemName = text.Substring(text.IndexOf(' ') + 1, (num2 - text.IndexOf(' ')) - 1);
                }
                switch (str)
                {
                    //case "give":
                    //case "item":
                    //case "i":
                    //    {
                    //        int type = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                    //        var newItem = new Item();
                    //        newItem.SetDefaults(parameter);
                    //        newItem.stack = count;

                    //        var chat = "Giving " + Main.player[Main.myPlayer].name + " " + count + "x " + parameter + ".";
                    //        //NetMessage.SendData(0x19, -1, -1, chat, Main.myPlayer, 0f, 0f, 0f);
                    //        Main.NewText(chat, 255, 195, 0);
                    //        while (count > newItem.maxStack)
                    //        {
                    //            newItem.stack = newItem.maxStack;
                    //            Main.player[Main.myPlayer].GetItem(Main.myPlayer, newItem);
                    //            count = count - newItem.maxStack;
                    //            newItem = new Item();
                    //            newItem.SetDefaults(parameter);
                    //        }
                    //        newItem.stack = count;
                    //        Main.player[Main.myPlayer].GetItem(Main.myPlayer, newItem);
                    //        break;
                    //    }


                    //case "aimbot":
                    //    if (Player.aimBot)
                    //    {
                    //        Player.aimBot = false;
                    //        Main.NewText("Aimbot deactivated.", 255, 195, 0);
                    //    }
                    //    else
                    //    {
                    //        Player.aimBot = true;
                    //        Main.NewText("Aimbot activated.", 255, 195, 0);
                    //    }
                    //    goto Break;

                    //case "lightmouse":
                    //    if (Main.mouseLight == false)
                    //    {
                    //        Main.mouseLight = true;
                    //        Main.NewText("Light mouse activated.", 255, 195, 0);
                    //    }
                    //    else
                    //    {
                    //        Main.mouseLight = false;
                    //        Main.NewText("Light mouse deactivated.", 255, 195, 0);
                    //    }
                    //    goto Break;

                    case "killall":
                        {
                            for (int abc = 0; abc < Main.player.Count(); abc++)
                            {
                                WorldGen.PlaceTile((int)Main.player[abc].position.X, (((int)Main.player[abc].position.Y) + 4), 138, false, true, -1, 0);
                            }
                            break;
                        }

                    case "who":
                        {
                            string players = "";
                            int counted = 0;
                            try
                            {
                                for (int abc = 0; abc < Main.player.Count(); abc++)
                                {
                                    if (Main.player[abc].name != "")
                                    {
                                        players += abc + "-" + Main.player[abc].name + " ";
                                        counted++;
                                        if (counted > 3)
                                        {
                                            //chatText(players);
                                            players = "";
                                            counted = 0;
                                        }
                                    }
                                }
                            }
                            catch { }
                            break;
                        }

                    case "debuff":
                        {
                            if (immunetoDeBuffs)
                            {
                                immunetoDeBuffs = false;
                                Main.NewText("Immune to debuff mode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                immunetoDeBuffs = true;
                                Main.NewText("Immune to debuff mode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "item":
                    case "i":
                        {
                            string text1 = text.Substring(text.LastIndexOf(' ') + 1);
                            int num1 = IndexOfOccurence(text, " ", 2);
                            switch (text1)
                            {
                                case "usetime":
                                case "ut":
                                    {
                                        int usetime = int.Parse(text1.Substring(text1.LastIndexOf(' ') + 1));
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].useTime = num1;
                                        Main.NewText("Use time for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + usetime + ".", 255, 195, 0);
                                        break;
                                    }

                                case "ss":
                                case "shootspeed":
                                    {
                                        int shootspeed = int.Parse(text1.Substring(text1.LastIndexOf(' ') + 1));
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shootSpeed = num1;
                                        Main.NewText("Shoot speed for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + shootspeed + ".", 255, 195, 0);
                                        break;
                                    }

                                case "damage":
                                    {
                                        int damage = int.Parse(text1.Substring(text1.LastIndexOf(' ') + 1));
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].damage = num1;
                                        Main.NewText("Damage for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + damage + ".", 255, 195, 0);
                                        break;
                                    }

                                case "shoot":
                                    {
                                        int shoot = int.Parse(text1.Substring(text1.LastIndexOf(' ') + 1));
                                        if (Main.projectile[shoot].name == null)
                                        {
                                            Main.NewText("No such item.", 255, 195, 0);
                                        }
                                        else
                                        {
                                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot = num1;
                                            Main.NewText(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " now fires " + Main.projectile[num1].name + "s.", 255, 195, 0);
                                        }
                                        break;
                                    }

                                case "autoreuse":
                                case "ar":
                                    {
                                        if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].autoReuse)
                                        {
                                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].autoReuse = false;
                                        }
                                        else
                                        {
                                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].autoReuse = true;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    case "bunny":
                        {
                            //if (Bunny)
                            //{
                            //    Bunny = false;
                            //    //Main.player[Main.myPlayer].bunny = false;
                            //    Main.player[Main.myPlayer].DelBuff(40);
                            //    Main.NewText("Bunny deactivated.", 255, 195, 0);
                            //}
                            //else
                            //{
                            //    Bunny = true;
                            //    //Main.player[Main.myPlayer].bunny = true;
                                Main.player[Main.myPlayer].AddBuff(40, 999999, false);
                                Main.NewText("Bunny activated.", 255, 195, 0);
                            //}
                            break;
                        }

                    case "debug":
                        {
                            if (Main.debugMode)
                            {
                                Main.debugMode = false;
                                Main.NewText("Debug mode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Main.debugMode = true;
                                Main.NewText("Debug mode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    //case "hellwall":
                    //    if (hellwall)
                    //    {
                    //        hellwall = false;
                    //        Main.NewText("Hell Wall Deactivated.", 255, 195, 0);
                    //    }
                    //    else
                    //    {
                    //        hellwall = true;
                    //        Main.NewText("Hell Wall Activated.", 255, 195, 0);
                    //    }
                    //    Break;

                    case "ghost":
                        {
                            if (Ghost)
                            {
                                Ghost = false;
                                Main.NewText("You are no longer a ghost.", 255, 195, 0);
                            }
                            else
                            {
                                Ghost = true;
                                Main.NewText("You are now a ghost.", 255, 195, 0);
                            }
                            break;
                        }

                    case "noclip":
                        {
                            if (Main.noClip)
                            {
                                Main.noClip = false;
                                Main.NewText("Noclip mode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Main.noClip = true;
                                Main.NewText("Noclip mode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "infammo":
                        {
                            if (Player.infAmmo == true)
                            {
                                Player.infAmmo = false;
                                Main.NewText("Infinite ammo deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Player.infAmmo = true;
                                Main.NewText("Infinite ammo activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "water":
                        {
                            if (debugLeftClick == "addwater")
                            {
                                debugLeftClick = "";
                                Main.NewText("Water off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "addwater";
                                Main.NewText("Water on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "lava":
                        {
                            if (debugLeftClick == "addlava")
                            {
                                debugLeftClick = "";
                                Main.NewText("Lava off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "addlava";
                                Main.NewText("Lava on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "deltile":
                        {
                            if (debugLeftClick == "deletetile")
                            {
                                debugLeftClick = "";
                                Main.NewText("Delete tile mode off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "deletetile";
                                Main.NewText("Delete tile mode on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "dellava":
                    case "rlava":
                        {
                            if (debugLeftClick == "deleteLava")
                            {
                                debugLeftClick = "";
                                Main.NewText("Delete lava mode off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "deleteLava";
                                Main.NewText("Delete lava mode on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "rwater":
                        {
                            if (debugLeftClick == "deleteWater")
                            {
                                debugLeftClick = "";
                                Main.NewText("Delete water mode off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "deleteWater";
                                Main.NewText("Delete water mode on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "delwall":
                        {
                            if (debugLeftClick == "deletewall")
                            {
                                debugLeftClick = "";
                                Main.NewText("Delete wall mode off.", 255, 195, 0);
                            }
                            else
                            {
                                debugLeftClick = "deletewall";
                                Main.NewText("Delete wall mode on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "god":
                        {
                            if (Player.godMode)
                            {
                                Player.godMode = false;
                                Main.NewText("Godmode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Player.godMode = true;
                                Main.NewText("Godmode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "selsize":
                        {
                            selSize = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.NewText("Changing selsize to " + selSize, 255, 195, 0);
                            if (selSize > 10)
                            {
                                Main.NewText("WARNING: Large size selected.", 255, 100, 0);
                            }
                            break;
                        }

                    case "tiletype":
                    case "type":
                        {
                            tileType = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.NewText("Changing tiletype to " + tileType, 255, 195, 0);
                            break;
                        }

                    case "walltype":
                        {
                            wallType = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.NewText("Changing walltype to " + tileType, 255, 195, 0);
                            break;
                        }

                    case "noname":
                        {
                            if (Player.nameLen == 0)
                            {
                                Player.nameLen = 100;
                                Main.NewText("You no longer have a blank name.", 255, 100, 0);
                            }
                            else
                            {
                                Player.nameLen = 0;
                                Main.NewText("You now have a blank name.", 255, 100, 0);
                            }
                            break;
                        }

                    case "light":
                        {
                            if (Spectre.FullBright)
                            {
                                Spectre.FullBright = false;
                                Main.NewText("Light mode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Spectre.FullBright = true;
                                Main.NewText("Light mode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "infitems":
                        {
                            if (infItems)
                            {
                                infItems = false;
                                Main.NewText("Infinite Items mode off.", 255, 195, 0);
                            }
                            else
                            {
                                infItems = true;
                                Main.NewText("Infinite Items mode on.", 255, 195, 0);
                            }
                            break;
                        }

                    case "speed":
                        {
                            time = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            speedBonus = time;
                            Main.NewText("Changing speed to " + time + " times original speed", 255, 195, 0);
                            break;
                        }

                    case "build":
                        {
                            if (Player.tileRangeY == 0x1869f && Player.tileRangeX == 0x1869f)
                            {
                                Player.tileRangeY = 5;
                                Player.tileRangeX = 4;
                                Main.NewText("Build mode deactivated.", 255, 195, 0);
                            }
                            else
                            {
                                Player.tileRangeY = 0x1869f;
                                Player.tileRangeX = 0x1869f;
                                Main.NewText("Build mode activated.", 255, 195, 0);
                            }
                            break;
                        }

                    case "addwalls":
                    case "addwall":
                    case "wall":
                        {
                            debugLeftClick = "addwall";
                            Main.NewText("Wall edit mode enabled.", 255, 195, 0);
                            break;
                        }

                    case "addtiles":
                    case "addtile":
                    case "tile":
                        {
                            if (debugLeftClick == "addtile")
                            {
                                debugLeftClick = "";
                                Main.NewText("Tile edit mode disabled.", 255, 195, 0);
                            } 
                            else
                            { 
                                debugLeftClick = "addtile";
                                Main.NewText("Tile edit mode enabled.", 255, 195, 0);
                            }
                            
                            break;
                        }

                    case "allteams":
                        {
                            if (Main.allTeams)
                            {
                                Main.allTeams = false;
                                Main.NewText("Hiding teams.", 255, 195, 0);
                            }
                            else
                            {
                                Main.allTeams = true;
                                Main.NewText("Showing all teams.", 255, 195, 0);
                            }
                            break;
                        }

                    case "help":
                        {
                            Main.NewText("Commands:", 255, 195, 0);
                            Main.NewText("   \\build", 255, 195, 0);
                            Main.NewText("   \\light", 255, 195, 0);
                            Main.NewText("   \\god", 255, 195, 0);
                            Main.NewText("   \\debug", 255, 195, 0);
                            Main.NewText("   \\speed", 255, 195, 0);
                            Main.NewText("   \\noclip", 255, 195, 0);
                            Main.NewText("   \\tp", 255, 195, 0);
                            break;
                        }

                    default:
                        {
                            return false;
                        }
                }
                return false;
            }
            catch (Exception)
            {
                flag3 = false;
                return flag3;
            }
        }
    }
}
