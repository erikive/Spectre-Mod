using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Microsoft.Xna.Framework;

namespace Terraria
{
    class Spectre
    {
        public static int bunnyR = (int)Main.player[Main.projectile[Main.myPlayer].owner].shirtColor.R;
        public static int bunnyG = (int)Main.player[Main.projectile[Main.myPlayer].owner].shirtColor.G;
        public static int bunnyB = (int)Main.player[Main.projectile[Main.myPlayer].owner].shirtColor.B;
        public static bool wWalk = true;
        public static int targetX;
        public static int targetY;
        public static bool cGrav = true;
        public static bool showUI = true;
        public static bool infRocket = true;
        public static int zoom = 1;
        public static int lines = 7;
        public static bool infMana = true;
        public static bool addWalls = false;
        public static bool Bunny = false;
        public static bool addTiles = false;
        public static int tileType = 0;
        public static int wallType = 30;
        public static string lastCommand = "";
        public static bool FullBright = false;
        public static bool immunetoDeBuffs = true;
        public static float LightLevel = 0.8f;
        public static bool infItems = true;
        public static bool Invis = false;
        public static string debugLeftClick = "";
        private static byte selAmount = 1;
        public static int selSize = 1;
        public static int chatSpam = 1;
        public static int speedBonus = 1;

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
                //sendText(Main.chatText, 50, 0xff, 130);
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
                        if (debugLeftClick.CompareTo("Add Lava") == 0)
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
                        //if (Main.tile[i + num, j + num].type == tileType)
                        //{
                            WorldGen.KillTile(i + num, j + num2, false, false, false);
                            WorldGen.PlaceTile(i + num, j + num2, tileType, true, false, -1, 0);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, i + num, j + num2, 1);
                            }
                        //}
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

        private static string[] parameter(string text)
        {
            string[] parameters = text.Split(' ');
            return parameters;
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
            else if ((debugLeftClick.CompareTo("Add Water") == 0) || (debugLeftClick.CompareTo("Add Lava") == 0))
            {
                addLiquid();
            }
            else if (debugLeftClick.CompareTo("Add Tile") == 0)
            {
                addTile(tileType);
            }
            else if (debugLeftClick.CompareTo("Add Wall") == 0)
            {
                addWall(wallType);
            }
            else if (debugLeftClick.CompareTo("deleteWater") == 0)
            {
                deleteWater();
            }
        }

        public static void sendText(string text)
        {
            Main.NewText(text, 255, 195, 0);
        }

        public static bool onChat(string text)
        {
            try
            {
                if (!(text.Substring(0, 1) == "\\"))
                {
                    return true;
                }
                lastCommand = text;
                string str = "empty command";
                string itemName = "empty string";
                var count = 1;

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
                    case "lightmouse":
                        {
                            if (Main.mouseLight == false)
                            {
                                Main.mouseLight = true;
                                sendText("Light mouse activated.");
                            }
                            else
                            {
                                Main.mouseLight = false;
                                sendText("Light mouse deactivated.");
                            }
                            break;
                        }
                    //still a work in progress
                    case "kill":
                        {
                            string name = (text.Substring(text.LastIndexOf(' ') + 1));
                            for (int name1 = 0; name != Main.player[name1].name; name1++) 
                            {
                                if (Main.player[name1].name == name)
                                {
                                    Main.player[name1].statLife = 0;
                                    WorldGen.PlaceTile((int)Main.player[name1].position.X, (((int)Main.player[name1].position.Y) + 4), 138, true, true, -1, 0);
                                }
                            }
                            break;
                        }

                    case "pdebug":
                            {
                                string para;
                                para = parameter(text)[0] + " " + parameter(text)[1] + " " + parameter(text)[2] + " " + parameter(text)[3] + " " + parameter(text)[4];
                                sendText(para);
                                break;
                            }

                    case "grav":
                    case "cgrav":
                            {
                                if (!cGrav == true)
                                {
                                    cGrav = true;
                                }
                                else
                                {
                                    cGrav = false;
                                }
                                break;
                            }

                    case "waterwalk":
                    case "wwalk":
                            {
                                if (!wWalk == true)
                                {
                                    wWalk = true;
                                }
                                else
                                {
                                    wWalk = false;
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

                    case "bunnycolor":
                        {
                            switch (parameter(text)[1])
                            {
                                case "red":
                                    {
                                        bunnyR = (int)Color.Red.R;
                                        bunnyG = (int)Color.Red.G;
                                        bunnyB = (int)Color.Red.B;
                                        break;
                                    }
                                default: break;
                            }
                            break;
                        }

                    case "zoom":
                        {
                            int.TryParse(parameter(text)[1], out zoom);
                            sendText("Zoomed in " + zoom + " times.");
                            break;
                        }

                    case "debuff":
                        {
                            if (immunetoDeBuffs)
                            {
                                immunetoDeBuffs = false;
                                sendText("Immune to debuff mode deactivated.");
                            }
                            else
                            {
                                immunetoDeBuffs = true;
                                sendText("Immune to debuff mode activated.");
                            }
                            break;
                        }

                    case "chatlines":
                        {       
                            int.TryParse(parameter(text)[1], out lines);
                            Main.numChatLines = lines;
                            sendText("Now showing " + Main.numChatLines + " chat lines.");
                            break;
                        }

                    case "i":
                        {
                            switch (parameter(text)[1])
                            {
                                case "usetime":
                                case "ut":
                                    {
                                        int usetime = int.Parse(parameter(text)[2]);
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].useTime = usetime;
                                        sendText("Use time for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + usetime + ".");
                                        break;
                                    }
                                case "shootspeed":
                                case "ss":
                                    {
                                        int shootspeed = int.Parse(parameter(text)[2]);
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shootSpeed = shootspeed;
                                        sendText("Shoot speed for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + shootspeed + ".");
                                        break;
                                    }
                                case "damage":
                                case "d":
                                    {
                                        int damage = int.Parse(parameter(text)[2]);
                                        Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].damage = damage;
                                        sendText("Damage for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + damage + ".");
                                        break;
                                    }
                                case "shoot":
                                case "s":
                                    {
                                        int shoot = int.Parse(parameter(text)[2]);
                                        if (Main.projectile[shoot].name == null)
                                        {
                                            sendText("No such item.");
                                        }
                                        else
                                        {
                                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot = shoot;
                                            sendText(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " now fires " + Main.projectile[shoot].name + "s.");
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
                                case "nocolide":
                                case "penetrate":
                                case "pierce":
                                    {
                                        if (/*Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot.ToString() != null && */Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide)
                                        {
                                            Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide = false;
                                        }
                                        else
                                        {
                                            Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide = true;
                                        }
                                        break;
                                    }
                            }
                            break;
                        }

                    case "clearinv":
                        {
                            for (int n = 10; n <= 40; n++)
                            {
                                Main.player[Main.myPlayer].inventory[n].type = 0;
                            }
                            break;
                        }

                    case "nocolide":
                    case "penetrate":
                    case "pierce":
                        {
                            //if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot && Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide == false)
                            //{
                            //    Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide = true;
                            //}
                            //else
                            //{
                                Main.projectile[Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot].tileCollide = false;
                            //}
                            break;
                        }

                    case "usetime":
                    case "ut":
                        {
                            int usetime = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].useTime = usetime;
                            sendText("Use time for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + usetime + ".");
                            break;
                        }

                    case "ss":
                    case "shootspeed":
                        {
                            int shootspeed = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shootSpeed = shootspeed;
                            sendText("Shoot speed for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + shootspeed + ".");
                            break;
                        }

                    case "damage":
                        {
                            int damage = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].damage = damage;
                            sendText("Damage for " + Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " changed to " + damage + ".");
                            break;
                        }

                    case "shoot":
                        {
                            int shoot = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            if (Main.projectile[shoot].name == null)
                            {
                                sendText("No such item.");
                            }
                            else
                            {
                                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].shoot = shoot;
                                sendText(Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].name + " now fires " + Main.projectile[shoot].name + "s.");
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

                    case "inf":
                    case "infitems":
                    case "infitem":
                        {
                            if (Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].consumable)
                            {
                                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].consumable = false;
                            }
                            else
                            {
                                Main.player[Main.myPlayer].inventory[Main.player[Main.myPlayer].selectedItem].consumable = true;
                            }
                            break;
                        }

                    case "buff":
                        {
                            int buff = 0;
                            int? t = null;
                            int t2 = 0;
                            if (int.TryParse(parameter(text)[2], out t2)) { t = t2; }
                            sendText(t2.ToString());
                            int time = t ?? 18000;
                            if (int.TryParse(parameter(text)[1], out buff))
                            {
                                Main.player[Main.myPlayer].AddBuff(buff, time, false);
                            }
                            else
                            {
                                sendText("Invalid buff type.");
                            }
                            break;
                        }

                    case "infrocket":
                        {
                            if (infRocket)
                            {
                                infRocket = false;
                                sendText("Infinite rocket disabled.");
                            }
                            else
                            {
                                infRocket = true;
                                sendText("Infinite rocket enabled.");
                            }
                            break;
                        }

                    case "bunny":
                        {
                            Main.player[Main.myPlayer].AddBuff(40, 999999, false);
                            sendText("Bunny activated.");
                            break;
                        }

                    case "debug":
                        {
                            if (Main.debugMode)
                            {
                                Main.debugMode = false;
                                sendText("Debug mode deactivated.");
                            }
                            else
                            {
                                Main.debugMode = true;
                                sendText("Debug mode activated.");
                            }
                            break;
                        }

                    case "noclip":
                        {
                            if (Main.noClip)
                            {
                                Main.noClip = false;
                                sendText("Noclip mode deactivated.");
                            }
                            else
                            {
                                Main.noClip = true;
                                sendText("Noclip mode activated.");
                            }
                            break;
                        }

                    case "infammo":
                        {
                            if (Player.infAmmo == true)
                            {
                                Player.infAmmo = false;
                                sendText("Infinite ammo deactivated.");
                            }
                            else
                            {
                                Player.infAmmo = true;
                                sendText("Infinite ammo activated.");
                            }
                            break;
                        }

                    case "water":
                        {
                            if (debugLeftClick == "Add Water")
                            {
                                debugLeftClick = "";
                                sendText("Water off.");
                            }
                            else
                            {
                                debugLeftClick = "Add Water";
                                sendText("Water on.");
                            }
                            break;
                        }

                    case "lava":
                        {
                            if (debugLeftClick == "Add Lava")
                            {
                                debugLeftClick = "";
                                sendText("Lava off.");
                            }
                            else
                            {
                                debugLeftClick = "Add Lava";
                                sendText("Lava on.");
                            }
                            break;
                        }

                    case "deltile":
                        {
                            if (debugLeftClick == "deletetile")
                            {
                                debugLeftClick = "";
                                sendText("Delete tile mode off.");
                            }
                            else
                            {
                                debugLeftClick = "deletetile";
                                sendText("Delete tile mode on.");
                            }
                            break;
                        }

                    case "dellava":
                    case "rlava":
                        {
                            if (debugLeftClick == "deleteLava")
                            {
                                debugLeftClick = "";
                                sendText("Delete lava mode off.");
                            }
                            else
                            {
                                debugLeftClick = "deleteLava";
                                sendText("Delete lava mode on.");
                            }
                            break;
                        }

                    case "rwater":
                        {
                            if (debugLeftClick == "deleteWater")
                            {
                                debugLeftClick = "";
                                sendText("Delete water mode off.");
                            }
                            else
                            {
                                debugLeftClick = "deleteWater";
                                sendText("Delete water mode on.");
                            }
                            break;
                        }

                    case "delwall":
                        {
                            if (debugLeftClick == "deletewall")
                            {
                                debugLeftClick = "";
                                sendText("Delete wall mode off.");
                            }
                            else
                            {
                                debugLeftClick = "deletewall";
                                sendText("Delete wall mode on.");
                            }
                            break;
                        }

                    case "god":
                        {
                            if (Player.godMode)
                            {
                                Player.godMode = false;
                                sendText("Godmode deactivated.");
                            }
                            else
                            {
                                Player.godMode = true;
                                sendText("Godmode activated.");
                            }
                            break;
                        }

                    case "selsize":
                        {
                            selSize = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            sendText("Changing selsize to " + (selSize * 2));
                            if (selSize >= 10)
                            {
                                sendText("WARNING: Large size selected.");
                            }
                            break;
                        }

                    case "tiletype":
                    case "type":
                        {
                            tileType = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            sendText("Changing tiletype to " + tileType);
                            break;
                        }

                    case "walltype":
                        {
                            wallType = int.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            sendText("Changing walltype to " + tileType);
                            break;
                        }

                    case "identify":
                        {
                            sendText("Type: " + Main.tile[targetX, targetY].type);
                            //sendText("Name: " + Main.tile[Main.mouseX, Main.mouseY].);
                            break;
                        }

                    /* Corrupts player file. Do not use.
                    case "noname":
                        {
                            if (Player.nameLen == 0)
                            {
                                Player.nameLen = 100;
                                sendText("You no longer have a blank name.");
                            }
                            else
                            {
                                Player.nameLen = 0;
                                sendText("You now have a blank name.");
                            }
                            break;
                        }
                     */

                    case "light":
                        {
                            if (Spectre.FullBright)
                            {
                                Spectre.FullBright = false;
                                sendText("Light mode deactivated.");
                            }
                            else
                            {
                                Spectre.FullBright = true;
                                sendText("Light mode activated.");
                            }
                            break;
                        }

                    case "speed":
                        {
                            float speed = float.Parse(text.Substring(text.LastIndexOf(' ') + 1));
                            Main.player[Main.myPlayer].moveSpeed = speed;
                            sendText("Changing speed to " + speed + " times original speed");
                            break;
                        }

                    case "build":
                        {
                            if (Player.tileRangeY == 0x1869f && Player.tileRangeX == 0x1869f)
                            {
                                Player.tileRangeY = 5;
                                Player.tileRangeX = 4;
                                sendText("Build mode deactivated.");
                            }
                            else
                            {
                                Player.tileRangeY = 0x1869f;
                                Player.tileRangeX = 0x1869f;
                                sendText("Build mode activated.");
                            }
                            break;
                        }

                    case "addwalls":
                    case "addwall":
                    case "wall":
                        {
                            if (debugLeftClick == "Add Wall")
                            {
                                debugLeftClick = "";
                                sendText("Wall edit mode disabled.");
                            }
                            else
                            {
                                debugLeftClick = "Add Wall";
                                sendText("Wall edit mode enabled.");
                            }
                            break;
                        }

                    case "addtiles":
                    case "addtile":
                    case "tile":
                        {
                            if (debugLeftClick == "Add Tile")
                            {
                                debugLeftClick = "";
                                sendText("Tile edit mode disabled.");
                            } 
                            else
                            { 
                                debugLeftClick = "Add Tile";
                                sendText("Tile edit mode enabled.");
                            }
                            
                            break;
                        }

                    case "allteams":
                        {
                            if (Main.allTeams)
                            {
                                Main.allTeams = false;
                                sendText("Hiding teams.");
                            }
                            else
                            {
                                Main.allTeams = true;
                                sendText("Showing all teams.");
                            }
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
                return false;
            }
        }
    }
}
