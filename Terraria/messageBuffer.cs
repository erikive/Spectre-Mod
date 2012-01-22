using System;
using System.Text;
namespace Terraria
{
    public class messageBuffer
    {
        public const int readBufferMax = 65535;
        public const int writeBufferMax = 65535;
        public bool broadcast;
        public byte[] readBuffer = new byte[65535];
        public byte[] writeBuffer = new byte[65535];
        public bool writeLocked;
        public int messageLength;
        public int totalData;
        public int whoAmI;
        public int spamCount;
        public int maxSpam;
        public bool checkBytes;
        public void Reset()
        {
            this.writeBuffer = new byte[65535];
            this.writeLocked = false;
            this.messageLength = 0;
            this.totalData = 0;
            this.spamCount = 0;
            this.broadcast = false;
            this.checkBytes = false;
        }
        public void GetData(int start, int length)
        {
            if (this.whoAmI < 256)
            {
                Netplay.serverSock[this.whoAmI].timeOut = 0;
            }
            else
            {
                Netplay.clientSock.timeOut = 0;
            }
            byte b = 0;
            int num = 0;
            num = start + 1;
            b = this.readBuffer[start];
            Main.rxMsg++;
            Main.rxData += length;
            Main.rxMsgType[(int)b]++;
            Main.rxDataType[(int)b] += length;
            if (Main.netMode == 1 && Netplay.clientSock.statusMax > 0)
            {
                Netplay.clientSock.statusCount++;
            }
            if (Main.verboseNetplay)
            {
                for (int i = start; i < start + length; i++)
                {
                }
                for (int j = start; j < start + length; j++)
                {
                    byte arg_CD_0 = this.readBuffer[j];
                }
            }
            if (Main.netMode == 2 && b != 38 && Netplay.serverSock[this.whoAmI].state == -1)
            {
                NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0);
                return;
            }
            if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state < 10 && b > 12 && b != 16 && b != 42 && b != 50 && b != 38)
            {
                NetMessage.BootPlayer(this.whoAmI, Lang.mp[2]);
            }
            if (b == 1 && Main.netMode == 2)
            {
                if (Main.dedServ && Netplay.CheckBan(Netplay.serverSock[this.whoAmI].tcpClient.Client.RemoteEndPoint.ToString()))
                {
                    NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[3], 0, 0f, 0f, 0f, 0);
                    return;
                }
                if (Netplay.serverSock[this.whoAmI].state == 0)
                {
                    string @string = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
                    if (!(@string == "Terraria" + Main.curRelease))
                    {
                        NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[4], 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    if (Netplay.password == null || Netplay.password == "")
                    {
                        Netplay.serverSock[this.whoAmI].state = 1;
                        NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                        return;
                    }
                    Netplay.serverSock[this.whoAmI].state = -1;
                    NetMessage.SendData(37, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                    return;
                }
            }
            else
            {
                if (b == 2 && Main.netMode == 1)
                {
                    Netplay.disconnect = true;
                    Main.statusText = Encoding.UTF8.GetString(this.readBuffer, start + 1, length - 1);
                    return;
                }
                if (b == 3 && Main.netMode == 1)
                {
                    if (Netplay.clientSock.state == 1)
                    {
                        Netplay.clientSock.state = 2;
                    }
                    int num2 = (int)this.readBuffer[start + 1];
                    if (num2 != Main.myPlayer)
                    {
                        Main.player[num2] = (Player)Main.player[Main.myPlayer].Clone();
                        Main.player[Main.myPlayer] = new Player();
                        Main.player[num2].whoAmi = num2;
                        Main.myPlayer = num2;
                    }
                    NetMessage.SendData(4, -1, -1, Main.player[Main.myPlayer].name, Main.myPlayer, 0f, 0f, 0f, 0);
                    NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                    NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                    NetMessage.SendData(50, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                    for (int k = 0; k < 49; k++)
                    {
                        NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].inventory[k].name, Main.myPlayer, (float)k, (float)Main.player[Main.myPlayer].inventory[k].prefix, 0f, 0);
                    }
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[0].name, Main.myPlayer, 49f, (float)Main.player[Main.myPlayer].armor[0].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[1].name, Main.myPlayer, 50f, (float)Main.player[Main.myPlayer].armor[1].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[2].name, Main.myPlayer, 51f, (float)Main.player[Main.myPlayer].armor[2].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[3].name, Main.myPlayer, 52f, (float)Main.player[Main.myPlayer].armor[3].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[4].name, Main.myPlayer, 53f, (float)Main.player[Main.myPlayer].armor[4].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[5].name, Main.myPlayer, 54f, (float)Main.player[Main.myPlayer].armor[5].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[6].name, Main.myPlayer, 55f, (float)Main.player[Main.myPlayer].armor[6].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[7].name, Main.myPlayer, 56f, (float)Main.player[Main.myPlayer].armor[7].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[8].name, Main.myPlayer, 57f, (float)Main.player[Main.myPlayer].armor[8].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[9].name, Main.myPlayer, 58f, (float)Main.player[Main.myPlayer].armor[9].prefix, 0f, 0);
                    NetMessage.SendData(5, -1, -1, Main.player[Main.myPlayer].armor[10].name, Main.myPlayer, 59f, (float)Main.player[Main.myPlayer].armor[10].prefix, 0f, 0);
                    NetMessage.SendData(6, -1, -1, "", 0, 0f, 0f, 0f, 0);
                    if (Netplay.clientSock.state == 2)
                    {
                        Netplay.clientSock.state = 3;
                        return;
                    }
                }
                else
                {
                    if (b == 4)
                    {
                        bool flag = false;
                        int num3 = (int)this.readBuffer[start + 1];
                        if (Main.netMode == 2)
                        {
                            num3 = this.whoAmI;
                        }
                        if (num3 == Main.myPlayer)
                        {
                            return;
                        }
                        int num4 = (int)this.readBuffer[start + 2];
                        if (num4 >= 36)
                        {
                            num4 = 0;
                        }
                        Main.player[num3].hair = num4;
                        Main.player[num3].whoAmi = num3;
                        num += 2;
                        byte b2 = this.readBuffer[num];
                        num++;
                        if (b2 == 1)
                        {
                            Main.player[num3].male = true;
                        }
                        else
                        {
                            Main.player[num3].male = false;
                        }
                        Main.player[num3].hairColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].hairColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].hairColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].skinColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].skinColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].skinColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].eyeColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].eyeColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].eyeColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].shirtColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].shirtColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].shirtColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].underShirtColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].underShirtColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].underShirtColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].pantsColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].pantsColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].pantsColor.B = this.readBuffer[num];
                        num++;
                        Main.player[num3].shoeColor.R = this.readBuffer[num];
                        num++;
                        Main.player[num3].shoeColor.G = this.readBuffer[num];
                        num++;
                        Main.player[num3].shoeColor.B = this.readBuffer[num];
                        num++;
                        byte difficulty = this.readBuffer[num];
                        Main.player[num3].difficulty = difficulty;
                        num++;
                        string text = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                        text = text.Trim();
                        Main.player[num3].name = text.Trim();
                        if (Main.netMode == 2)
                        {
                            if (Netplay.serverSock[this.whoAmI].state < 10)
                            {
                                for (int l = 0; l < 255; l++)
                                {
                                    if (l != num3 && text == Main.player[l].name && Netplay.serverSock[l].active)
                                    {
                                        flag = true;
                                    }
                                }
                            }
                            if (flag)
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, text + " " + Lang.mp[5], 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            if (text.Length > Player.nameLen)
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, "Name is too long.", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            if (text == "")
                            {
                                NetMessage.SendData(2, this.whoAmI, -1, "Empty name.", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                            Netplay.serverSock[this.whoAmI].oldName = text;
                            Netplay.serverSock[this.whoAmI].name = text;
                            NetMessage.SendData(4, -1, this.whoAmI, text, num3, 0f, 0f, 0f, 0);
                            return;
                        }
                    }
                    else
                    {
                        if (b == 5)
                        {
                            int num5 = (int)this.readBuffer[start + 1];
                            if (Main.netMode == 2)
                            {
                                num5 = this.whoAmI;
                            }
                            if (num5 == Main.myPlayer)
                            {
                                return;
                            }
                            lock (Main.player[num5])
                            {
                                int num6 = (int)this.readBuffer[start + 2];
                                int stack = (int)this.readBuffer[start + 3];
                                byte b3 = this.readBuffer[start + 4];
                                int type = (int)BitConverter.ToInt16(this.readBuffer, start + 5);
                                if (num6 < 49)
                                {
                                    Main.player[num5].inventory[num6] = new Item();
                                    Main.player[num5].inventory[num6].netDefaults(type);
                                    Main.player[num5].inventory[num6].stack = stack;
                                    Main.player[num5].inventory[num6].Prefix((int)b3);
                                }
                                else
                                {
                                    Main.player[num5].armor[num6 - 48 - 1] = new Item();
                                    Main.player[num5].armor[num6 - 48 - 1].netDefaults(type);
                                    Main.player[num5].armor[num6 - 48 - 1].stack = stack;
                                    Main.player[num5].armor[num6 - 48 - 1].Prefix((int)b3);
                                }
                                if (Main.netMode == 2 && num5 == this.whoAmI)
                                {
                                    NetMessage.SendData(5, -1, this.whoAmI, "", num5, (float)num6, (float)b3, 0f, 0);
                                }
                                return;
                            }
                        }
                        if (b == 6)
                        {
                            if (Main.netMode == 2)
                            {
                                if (Netplay.serverSock[this.whoAmI].state == 1)
                                {
                                    Netplay.serverSock[this.whoAmI].state = 2;
                                }
                                NetMessage.SendData(7, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                return;
                            }
                        }
                        else
                        {
                            if (b == 7)
                            {
                                if (Main.netMode == 1)
                                {
                                    Main.time = (double)BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.dayTime = false;
                                    if (this.readBuffer[num] == 1)
                                    {
                                        Main.dayTime = true;
                                    }
                                    num++;
                                    Main.moonPhase = (int)this.readBuffer[num];
                                    num++;
                                    int num7 = (int)this.readBuffer[num];
                                    num++;
                                    if (num7 == 1)
                                    {
                                        Main.bloodMoon = true;
                                    }
                                    else
                                    {
                                        Main.bloodMoon = false;
                                    }
                                    Main.maxTilesX = BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.maxTilesY = BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.spawnTileX = BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.spawnTileY = BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.worldSurface = (double)BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.rockLayer = (double)BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    Main.worldID = BitConverter.ToInt32(this.readBuffer, num);
                                    num += 4;
                                    byte b4 = this.readBuffer[num];
                                    if ((b4 & 1) == 1)
                                    {
                                        WorldGen.shadowOrbSmashed = true;
                                    }
                                    if ((b4 & 2) == 2)
                                    {
                                        NPC.downedBoss1 = true;
                                    }
                                    if ((b4 & 4) == 4)
                                    {
                                        NPC.downedBoss2 = true;
                                    }
                                    if ((b4 & 8) == 8)
                                    {
                                        NPC.downedBoss3 = true;
                                    }
                                    if ((b4 & 16) == 16)
                                    {
                                        Main.hardMode = true;
                                    }
                                    if ((b4 & 32) == 32)
                                    {
                                        NPC.downedClown = true;
                                    }
                                    num++;
                                    Main.worldName = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                    if (Netplay.clientSock.state == 3)
                                    {
                                        Netplay.clientSock.state = 4;
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (b == 8)
                                {
                                    if (Main.netMode == 2)
                                    {
                                        int num8 = BitConverter.ToInt32(this.readBuffer, num);
                                        num += 4;
                                        int num9 = BitConverter.ToInt32(this.readBuffer, num);
                                        num += 4;
                                        bool flag3 = true;
                                        if (num8 == -1 || num9 == -1)
                                        {
                                            flag3 = false;
                                        }
                                        else
                                        {
                                            if (num8 < 10 || num8 > Main.maxTilesX - 10)
                                            {
                                                flag3 = false;
                                            }
                                            else
                                            {
                                                if (num9 < 10 || num9 > Main.maxTilesY - 10)
                                                {
                                                    flag3 = false;
                                                }
                                            }
                                        }
                                        int num10 = 1350;
                                        if (flag3)
                                        {
                                            num10 *= 2;
                                        }
                                        if (Netplay.serverSock[this.whoAmI].state == 2)
                                        {
                                            Netplay.serverSock[this.whoAmI].state = 3;
                                        }
                                        NetMessage.SendData(9, this.whoAmI, -1, Lang.inter[44], num10, 0f, 0f, 0f, 0);
                                        Netplay.serverSock[this.whoAmI].statusText2 = "is receiving tile data";
                                        Netplay.serverSock[this.whoAmI].statusMax += num10;
                                        int sectionX = Netplay.GetSectionX(Main.spawnTileX);
                                        int sectionY = Netplay.GetSectionY(Main.spawnTileY);
                                        for (int m = sectionX - 2; m < sectionX + 3; m++)
                                        {
                                            for (int n = sectionY - 1; n < sectionY + 2; n++)
                                            {
                                                NetMessage.SendSection(this.whoAmI, m, n);
                                            }
                                        }
                                        if (flag3)
                                        {
                                            num8 = Netplay.GetSectionX(num8);
                                            num9 = Netplay.GetSectionY(num9);
                                            for (int num11 = num8 - 2; num11 < num8 + 3; num11++)
                                            {
                                                for (int num12 = num9 - 1; num12 < num9 + 2; num12++)
                                                {
                                                    NetMessage.SendSection(this.whoAmI, num11, num12);
                                                }
                                            }
                                            NetMessage.SendData(11, this.whoAmI, -1, "", num8 - 2, (float)(num9 - 1), (float)(num8 + 2), (float)(num9 + 1), 0);
                                        }
                                        NetMessage.SendData(11, this.whoAmI, -1, "", sectionX - 2, (float)(sectionY - 1), (float)(sectionX + 2), (float)(sectionY + 1), 0);
                                        for (int num13 = 0; num13 < 200; num13++)
                                        {
                                            if (Main.item[num13].active)
                                            {
                                                NetMessage.SendData(21, this.whoAmI, -1, "", num13, 0f, 0f, 0f, 0);
                                                NetMessage.SendData(22, this.whoAmI, -1, "", num13, 0f, 0f, 0f, 0);
                                            }
                                        }
                                        for (int num14 = 0; num14 < 200; num14++)
                                        {
                                            if (Main.npc[num14].active)
                                            {
                                                NetMessage.SendData(23, this.whoAmI, -1, "", num14, 0f, 0f, 0f, 0);
                                            }
                                        }
                                        NetMessage.SendData(49, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(57, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 17, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 18, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 19, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 20, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 22, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 38, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 54, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 107, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 108, 0f, 0f, 0f, 0);
                                        NetMessage.SendData(56, this.whoAmI, -1, "", 124, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (b == 9)
                                    {
                                        if (Main.netMode == 1)
                                        {
                                            int num15 = BitConverter.ToInt32(this.readBuffer, start + 1);
                                            string string2 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
                                            Netplay.clientSock.statusMax += num15;
                                            Netplay.clientSock.statusText = string2;
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (b == 10 && Main.netMode == 1)
                                        {
                                            short num16 = BitConverter.ToInt16(this.readBuffer, start + 1);
                                            int num17 = BitConverter.ToInt32(this.readBuffer, start + 3);
                                            int num18 = BitConverter.ToInt32(this.readBuffer, start + 7);
                                            num = start + 11;
                                            for (int num19 = num17; num19 < num17 + (int)num16; num19++)
                                            {
                                                if (Main.tile[num19, num18] == null)
                                                {
                                                    Main.tile[num19, num18] = new Tile();
                                                }
                                                byte b5 = this.readBuffer[num];
                                                num++;
                                                bool active = Main.tile[num19, num18].active;
                                                if ((b5 & 1) == 1)
                                                {
                                                    Main.tile[num19, num18].active = true;
                                                }
                                                else
                                                {
                                                    Main.tile[num19, num18].active = false;
                                                }
                                                byte arg_1567_0 = (byte)(b5 & 2);
                                                if ((b5 & 4) == 4)
                                                {
                                                    Main.tile[num19, num18].wall = 1;
                                                }
                                                else
                                                {
                                                    Main.tile[num19, num18].wall = 0;
                                                }
                                                if ((b5 & 8) == 8)
                                                {
                                                    Main.tile[num19, num18].liquid = 1;
                                                }
                                                else
                                                {
                                                    Main.tile[num19, num18].liquid = 0;
                                                }
                                                if ((b5 & 16) == 16)
                                                {
                                                    Main.tile[num19, num18].wire = true;
                                                }
                                                else
                                                {
                                                    Main.tile[num19, num18].wire = false;
                                                }
                                                if (Main.tile[num19, num18].active)
                                                {
                                                    int type2 = (int)Main.tile[num19, num18].type;
                                                    Main.tile[num19, num18].type = this.readBuffer[num];
                                                    num++;
                                                    if (Main.tileFrameImportant[(int)Main.tile[num19, num18].type])
                                                    {
                                                        Main.tile[num19, num18].frameX = BitConverter.ToInt16(this.readBuffer, num);
                                                        num += 2;
                                                        Main.tile[num19, num18].frameY = BitConverter.ToInt16(this.readBuffer, num);
                                                        num += 2;
                                                    }
                                                    else
                                                    {
                                                        if (!active || (int)Main.tile[num19, num18].type != type2)
                                                        {
                                                            Main.tile[num19, num18].frameX = -1;
                                                            Main.tile[num19, num18].frameY = -1;
                                                        }
                                                    }
                                                }
                                                if (Main.tile[num19, num18].wall > 0)
                                                {
                                                    Main.tile[num19, num18].wall = this.readBuffer[num];
                                                    num++;
                                                }
                                                if (Main.tile[num19, num18].liquid > 0)
                                                {
                                                    Main.tile[num19, num18].liquid = this.readBuffer[num];
                                                    num++;
                                                    byte b6 = this.readBuffer[num];
                                                    num++;
                                                    if (b6 == 1)
                                                    {
                                                        Main.tile[num19, num18].lava = true;
                                                    }
                                                    else
                                                    {
                                                        Main.tile[num19, num18].lava = false;
                                                    }
                                                }
                                                short num20 = BitConverter.ToInt16(this.readBuffer, num);
                                                num += 2;
                                                int num21 = num19;
                                                while (num20 > 0)
                                                {
                                                    num21++;
                                                    num20 -= 1;
                                                    if (Main.tile[num21, num18] == null)
                                                    {
                                                        Main.tile[num21, num18] = new Tile();
                                                    }
                                                    Main.tile[num21, num18].active = Main.tile[num19, num18].active;
                                                    Main.tile[num21, num18].type = Main.tile[num19, num18].type;
                                                    Main.tile[num21, num18].wall = Main.tile[num19, num18].wall;
                                                    Main.tile[num21, num18].wire = Main.tile[num19, num18].wire;
                                                    if (Main.tileFrameImportant[(int)Main.tile[num21, num18].type])
                                                    {
                                                        Main.tile[num21, num18].frameX = Main.tile[num19, num18].frameX;
                                                        Main.tile[num21, num18].frameY = Main.tile[num19, num18].frameY;
                                                    }
                                                    else
                                                    {
                                                        Main.tile[num21, num18].frameX = -1;
                                                        Main.tile[num21, num18].frameY = -1;
                                                    }
                                                    Main.tile[num21, num18].liquid = Main.tile[num19, num18].liquid;
                                                    Main.tile[num21, num18].lava = Main.tile[num19, num18].lava;
                                                }
                                                num19 = num21;
                                            }
                                            if (Main.netMode == 2)
                                            {
                                                NetMessage.SendData((int)b, -1, this.whoAmI, "", (int)num16, (float)num17, (float)num18, 0f, 0);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (b == 11)
                                            {
                                                if (Main.netMode == 1)
                                                {
                                                    int startX = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                    num += 4;
                                                    int startY = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                    num += 4;
                                                    int endX = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                    num += 4;
                                                    int endY = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                    num += 4;
                                                    WorldGen.SectionTileFrame(startX, startY, endX, endY);
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                if (b == 12)
                                                {
                                                    int num22 = (int)this.readBuffer[num];
                                                    if (Main.netMode == 2)
                                                    {
                                                        num22 = this.whoAmI;
                                                    }
                                                    num++;
                                                    Main.player[num22].SpawnX = BitConverter.ToInt32(this.readBuffer, num);
                                                    num += 4;
                                                    Main.player[num22].SpawnY = BitConverter.ToInt32(this.readBuffer, num);
                                                    num += 4;
                                                    Main.player[num22].Spawn();
                                                    if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state >= 3)
                                                    {
                                                        if (Netplay.serverSock[this.whoAmI].state == 3)
                                                        {
                                                            Netplay.serverSock[this.whoAmI].state = 10;
                                                            NetMessage.greetPlayer(this.whoAmI);
                                                            NetMessage.buffer[this.whoAmI].broadcast = true;
                                                            NetMessage.syncPlayers();
                                                            NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
                                                            return;
                                                        }
                                                        NetMessage.SendData(12, -1, this.whoAmI, "", this.whoAmI, 0f, 0f, 0f, 0);
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    if (b == 13)
                                                    {
                                                        int num23 = (int)this.readBuffer[num];
                                                        if (num23 == Main.myPlayer)
                                                        {
                                                            return;
                                                        }
                                                        if (Main.netMode == 1)
                                                        {
                                                            bool arg_1B63_0 = Main.player[num23].active;
                                                        }
                                                        if (Main.netMode == 2)
                                                        {
                                                            num23 = this.whoAmI;
                                                        }
                                                        num++;
                                                        int num24 = (int)this.readBuffer[num];
                                                        num++;
                                                        int selectedItem = (int)this.readBuffer[num];
                                                        num++;
                                                        float x = BitConverter.ToSingle(this.readBuffer, num);
                                                        num += 4;
                                                        float num25 = BitConverter.ToSingle(this.readBuffer, num);
                                                        num += 4;
                                                        float x2 = BitConverter.ToSingle(this.readBuffer, num);
                                                        num += 4;
                                                        float y = BitConverter.ToSingle(this.readBuffer, num);
                                                        num += 4;
                                                        Main.player[num23].selectedItem = selectedItem;
                                                        Main.player[num23].position.X = x;
                                                        Main.player[num23].position.Y = num25;
                                                        Main.player[num23].velocity.X = x2;
                                                        Main.player[num23].velocity.Y = y;
                                                        Main.player[num23].oldVelocity = Main.player[num23].velocity;
                                                        Main.player[num23].fallStart = (int)(num25 / 16f);
                                                        Main.player[num23].controlUp = false;
                                                        Main.player[num23].controlDown = false;
                                                        Main.player[num23].controlLeft = false;
                                                        Main.player[num23].controlRight = false;
                                                        Main.player[num23].controlJump = false;
                                                        Main.player[num23].controlUseItem = false;
                                                        Main.player[num23].direction = -1;
                                                        if ((num24 & 1) == 1)
                                                        {
                                                            Main.player[num23].controlUp = true;
                                                        }
                                                        if ((num24 & 2) == 2)
                                                        {
                                                            Main.player[num23].controlDown = true;
                                                        }
                                                        if ((num24 & 4) == 4)
                                                        {
                                                            Main.player[num23].controlLeft = true;
                                                        }
                                                        if ((num24 & 8) == 8)
                                                        {
                                                            Main.player[num23].controlRight = true;
                                                        }
                                                        if ((num24 & 16) == 16)
                                                        {
                                                            Main.player[num23].controlJump = true;
                                                        }
                                                        if ((num24 & 32) == 32)
                                                        {
                                                            Main.player[num23].controlUseItem = true;
                                                        }
                                                        if ((num24 & 64) == 64)
                                                        {
                                                            Main.player[num23].direction = 1;
                                                        }
                                                        if (Main.netMode == 2 && Netplay.serverSock[this.whoAmI].state == 10)
                                                        {
                                                            NetMessage.SendData(13, -1, this.whoAmI, "", num23, 0f, 0f, 0f, 0);
                                                            return;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (b == 14)
                                                        {
                                                            if (Main.netMode == 1)
                                                            {
                                                                int num26 = (int)this.readBuffer[num];
                                                                num++;
                                                                int num27 = (int)this.readBuffer[num];
                                                                if (num27 == 1)
                                                                {
                                                                    if (!Main.player[num26].active)
                                                                    {
                                                                        Main.player[num26] = new Player();
                                                                    }
                                                                    Main.player[num26].active = true;
                                                                    return;
                                                                }
                                                                Main.player[num26].active = false;
                                                                return;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (b == 15)
                                                            {
                                                                if (Main.netMode == 2)
                                                                {
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (b == 16)
                                                                {
                                                                    int num28 = (int)this.readBuffer[num];
                                                                    num++;
                                                                    if (num28 == Main.myPlayer)
                                                                    {
                                                                        return;
                                                                    }
                                                                    int statLife = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                    num += 2;
                                                                    int statLifeMax = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                    if (Main.netMode == 2)
                                                                    {
                                                                        num28 = this.whoAmI;
                                                                    }
                                                                    Main.player[num28].statLife = statLife;
                                                                    Main.player[num28].statLifeMax = statLifeMax;
                                                                    if (Main.player[num28].statLife <= 0)
                                                                    {
                                                                        Main.player[num28].dead = true;
                                                                    }
                                                                    if (Main.netMode == 2)
                                                                    {
                                                                        NetMessage.SendData(16, -1, this.whoAmI, "", num28, 0f, 0f, 0f, 0);
                                                                        return;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (b == 17)
                                                                    {
                                                                        byte b7 = this.readBuffer[num];
                                                                        num++;
                                                                        int num29 = BitConverter.ToInt32(this.readBuffer, num);
                                                                        num += 4;
                                                                        int num30 = BitConverter.ToInt32(this.readBuffer, num);
                                                                        num += 4;
                                                                        byte b8 = this.readBuffer[num];
                                                                        num++;
                                                                        int num31 = (int)this.readBuffer[num];
                                                                        bool flag4 = false;
                                                                        if (b8 == 1)
                                                                        {
                                                                            flag4 = true;
                                                                        }
                                                                        if (Main.tile[num29, num30] == null)
                                                                        {
                                                                            Main.tile[num29, num30] = new Tile();
                                                                        }
                                                                        if (Main.netMode == 2)
                                                                        {
                                                                            if (!flag4)
                                                                            {
                                                                                if (b7 == 0 || b7 == 2 || b7 == 4)
                                                                                {
                                                                                    Netplay.serverSock[this.whoAmI].spamDelBlock += 1f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (b7 == 1 || b7 == 3)
                                                                                    {
                                                                                        Netplay.serverSock[this.whoAmI].spamAddBlock += 1f;
                                                                                    }
                                                                                }
                                                                            }
                                                                            if (!Netplay.serverSock[this.whoAmI].tileSection[Netplay.GetSectionX(num29), Netplay.GetSectionY(num30)])
                                                                            {
                                                                                flag4 = true;
                                                                            }
                                                                        }
                                                                        if (b7 == 0)
                                                                        {
                                                                            WorldGen.KillTile(num29, num30, flag4, false, false);
                                                                        }
                                                                        else
                                                                        {
                                                                            if (b7 == 1)
                                                                            {
                                                                                WorldGen.PlaceTile(num29, num30, (int)b8, false, true, -1, num31);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (b7 == 2)
                                                                                {
                                                                                    WorldGen.KillWall(num29, num30, flag4);
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (b7 == 3)
                                                                                    {
                                                                                        WorldGen.PlaceWall(num29, num30, (int)b8, false);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (b7 == 4)
                                                                                        {
                                                                                            WorldGen.KillTile(num29, num30, flag4, false, true);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (b7 == 5)
                                                                                            {
                                                                                                WorldGen.PlaceWire(num29, num30);
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (b7 == 6)
                                                                                                {
                                                                                                    WorldGen.KillWire(num29, num30);
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        if (Main.netMode == 2)
                                                                        {
                                                                            NetMessage.SendData(17, -1, this.whoAmI, "", (int)b7, (float)num29, (float)num30, (float)b8, num31);
                                                                            if (b7 == 1 && b8 == 53)
                                                                            {
                                                                                NetMessage.SendTileSquare(-1, num29, num30, 1);
                                                                                return;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (b == 18)
                                                                        {
                                                                            if (Main.netMode == 1)
                                                                            {
                                                                                byte b9 = this.readBuffer[num];
                                                                                num++;
                                                                                int num32 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                num += 4;
                                                                                short sunModY = BitConverter.ToInt16(this.readBuffer, num);
                                                                                num += 2;
                                                                                short moonModY = BitConverter.ToInt16(this.readBuffer, num);
                                                                                num += 2;
                                                                                if (b9 == 1)
                                                                                {
                                                                                    Main.dayTime = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    Main.dayTime = false;
                                                                                }
                                                                                Main.time = (double)num32;
                                                                                Main.sunModY = sunModY;
                                                                                Main.moonModY = moonModY;
                                                                                if (Main.netMode == 2)
                                                                                {
                                                                                    NetMessage.SendData(18, -1, this.whoAmI, "", 0, 0f, 0f, 0f, 0);
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (b != 19)
                                                                            {
                                                                                if (b == 20)
                                                                                {
                                                                                    short num33 = BitConverter.ToInt16(this.readBuffer, start + 1);
                                                                                    int num34 = BitConverter.ToInt32(this.readBuffer, start + 3);
                                                                                    int num35 = BitConverter.ToInt32(this.readBuffer, start + 7);
                                                                                    num = start + 11;
                                                                                    if (Main.netMode == 2)
                                                                                    {
                                                                                        try
                                                                                        {
                                                                                            if (num33 > 10)
                                                                                            {
                                                                                                return;
                                                                                            }
                                                                                            int num36 = num34 + (int)(num33 / 2);
                                                                                            int num37 = num35;
                                                                                            int num38 = (int)(Main.player[this.whoAmI].position.X + (float)(Main.player[this.whoAmI].width / 2)) / 16;
                                                                                            int num39 = (int)(Main.player[this.whoAmI].position.Y + (float)(Main.player[this.whoAmI].height / 2)) / 16;
                                                                                            if (Math.Abs(num36 - num38) > 20 || Math.Abs(num37 - num39) > 20)
                                                                                            {
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        catch
                                                                                        {
                                                                                            return;
                                                                                        }
                                                                                    }
                                                                                    for (int num40 = num34; num40 < num34 + (int)num33; num40++)
                                                                                    {
                                                                                        for (int num41 = num35; num41 < num35 + (int)num33; num41++)
                                                                                        {
                                                                                            if (Main.tile[num40, num41] == null)
                                                                                            {
                                                                                                Main.tile[num40, num41] = new Tile();
                                                                                            }
                                                                                            byte b10 = this.readBuffer[num];
                                                                                            num++;
                                                                                            bool active2 = Main.tile[num40, num41].active;
                                                                                            if ((b10 & 1) == 1)
                                                                                            {
                                                                                                Main.tile[num40, num41].active = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Main.tile[num40, num41].active = false;
                                                                                            }
                                                                                            if ((b10 & 4) == 4)
                                                                                            {
                                                                                                Main.tile[num40, num41].wall = 1;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Main.tile[num40, num41].wall = 0;
                                                                                            }
                                                                                            bool flag5 = false;
                                                                                            if ((b10 & 8) == 8)
                                                                                            {
                                                                                                flag5 = true;
                                                                                            }
                                                                                            if (Main.netMode != 2)
                                                                                            {
                                                                                                if (flag5)
                                                                                                {
                                                                                                    Main.tile[num40, num41].liquid = 1;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Main.tile[num40, num41].liquid = 0;
                                                                                                }
                                                                                            }
                                                                                            if ((b10 & 16) == 16)
                                                                                            {
                                                                                                Main.tile[num40, num41].wire = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Main.tile[num40, num41].wire = false;
                                                                                            }
                                                                                            if (Main.tile[num40, num41].active)
                                                                                            {
                                                                                                int type3 = (int)Main.tile[num40, num41].type;
                                                                                                Main.tile[num40, num41].type = this.readBuffer[num];
                                                                                                num++;
                                                                                                if (Main.tileFrameImportant[(int)Main.tile[num40, num41].type])
                                                                                                {
                                                                                                    Main.tile[num40, num41].frameX = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                    num += 2;
                                                                                                    Main.tile[num40, num41].frameY = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                    num += 2;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (!active2 || (int)Main.tile[num40, num41].type != type3)
                                                                                                    {
                                                                                                        Main.tile[num40, num41].frameX = -1;
                                                                                                        Main.tile[num40, num41].frameY = -1;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            if (Main.tile[num40, num41].wall > 0)
                                                                                            {
                                                                                                Main.tile[num40, num41].wall = this.readBuffer[num];
                                                                                                num++;
                                                                                            }
                                                                                            if (flag5)
                                                                                            {
                                                                                                Main.tile[num40, num41].liquid = this.readBuffer[num];
                                                                                                num++;
                                                                                                byte b11 = this.readBuffer[num];
                                                                                                num++;
                                                                                                if (Main.netMode != 2)
                                                                                                {
                                                                                                    if (b11 == 1)
                                                                                                    {
                                                                                                        Main.tile[num40, num41].lava = true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        Main.tile[num40, num41].lava = false;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    WorldGen.RangeFrame(num34, num35, num34 + (int)num33, num35 + (int)num33);
                                                                                    if (Main.netMode == 2)
                                                                                    {
                                                                                        NetMessage.SendData((int)b, -1, this.whoAmI, "", (int)num33, (float)num34, (float)num35, 0f, 0);
                                                                                        return;
                                                                                    }
                                                                                    return;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (b == 21)
                                                                                    {
                                                                                        short num42 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                        num += 2;
                                                                                        float num43 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                        num += 4;
                                                                                        float num44 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                        num += 4;
                                                                                        float x3 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                        num += 4;
                                                                                        float y2 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                        num += 4;
                                                                                        byte stack2 = this.readBuffer[num];
                                                                                        num++;
                                                                                        byte pre = this.readBuffer[num];
                                                                                        num++;
                                                                                        short num45 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                        if (Main.netMode == 1)
                                                                                        {
                                                                                            if (num45 == 0)
                                                                                            {
                                                                                                Main.item[(int)num42].active = false;
                                                                                                return;
                                                                                            }
                                                                                            Main.item[(int)num42].netDefaults((int)num45);
                                                                                            Main.item[(int)num42].Prefix((int)pre);
                                                                                            Main.item[(int)num42].stack = (int)stack2;
                                                                                            Main.item[(int)num42].position.X = num43;
                                                                                            Main.item[(int)num42].position.Y = num44;
                                                                                            Main.item[(int)num42].velocity.X = x3;
                                                                                            Main.item[(int)num42].velocity.Y = y2;
                                                                                            Main.item[(int)num42].active = true;
                                                                                            Main.item[(int)num42].wet = Collision.WetCollision(Main.item[(int)num42].position, Main.item[(int)num42].width, Main.item[(int)num42].height);
                                                                                            return;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (num45 == 0)
                                                                                            {
                                                                                                if (num42 < 200)
                                                                                                {
                                                                                                    Main.item[(int)num42].active = false;
                                                                                                    NetMessage.SendData(21, -1, -1, "", (int)num42, 0f, 0f, 0f, 0);
                                                                                                    return;
                                                                                                }
                                                                                                return;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                bool flag6 = false;
                                                                                                if (num42 == 200)
                                                                                                {
                                                                                                    flag6 = true;
                                                                                                }
                                                                                                if (flag6)
                                                                                                {
                                                                                                    Item item = new Item();
                                                                                                    item.netDefaults((int)num45);
                                                                                                    num42 = (short)Item.NewItem((int)num43, (int)num44, item.width, item.height, item.type, (int)stack2, true, 0);
                                                                                                }
                                                                                                Main.item[(int)num42].netDefaults((int)num45);
                                                                                                Main.item[(int)num42].Prefix((int)pre);
                                                                                                Main.item[(int)num42].stack = (int)stack2;
                                                                                                Main.item[(int)num42].position.X = num43;
                                                                                                Main.item[(int)num42].position.Y = num44;
                                                                                                Main.item[(int)num42].velocity.X = x3;
                                                                                                Main.item[(int)num42].velocity.Y = y2;
                                                                                                Main.item[(int)num42].active = true;
                                                                                                Main.item[(int)num42].owner = Main.myPlayer;
                                                                                                if (flag6)
                                                                                                {
                                                                                                    NetMessage.SendData(21, -1, -1, "", (int)num42, 0f, 0f, 0f, 0);
                                                                                                    Main.item[(int)num42].ownIgnore = this.whoAmI;
                                                                                                    Main.item[(int)num42].ownTime = 100;
                                                                                                    Main.item[(int)num42].FindOwner((int)num42);
                                                                                                    return;
                                                                                                }
                                                                                                NetMessage.SendData(21, -1, this.whoAmI, "", (int)num42, 0f, 0f, 0f, 0);
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (b == 22)
                                                                                        {
                                                                                            short num46 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                            num += 2;
                                                                                            byte b12 = this.readBuffer[num];
                                                                                            if (Main.netMode != 2 || Main.item[(int)num46].owner == this.whoAmI)
                                                                                            {
                                                                                                Main.item[(int)num46].owner = (int)b12;
                                                                                                if ((int)b12 == Main.myPlayer)
                                                                                                {
                                                                                                    Main.item[(int)num46].keepTime = 15;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    Main.item[(int)num46].keepTime = 0;
                                                                                                }
                                                                                                if (Main.netMode == 2)
                                                                                                {
                                                                                                    Main.item[(int)num46].owner = 255;
                                                                                                    Main.item[(int)num46].keepTime = 15;
                                                                                                    NetMessage.SendData(22, -1, -1, "", (int)num46, 0f, 0f, 0f, 0);
                                                                                                    return;
                                                                                                }
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (b == 23 && Main.netMode == 1)
                                                                                            {
                                                                                                short num47 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                num += 2;
                                                                                                float x4 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                num += 4;
                                                                                                float y3 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                num += 4;
                                                                                                float x5 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                num += 4;
                                                                                                float y4 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                num += 4;
                                                                                                int target = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                num += 2;
                                                                                                int direction = (int)(this.readBuffer[num] - 1);
                                                                                                num++;
                                                                                                int directionY = (int)(this.readBuffer[num] - 1);
                                                                                                num++;
                                                                                                int num48 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                num += 4;
                                                                                                float[] array = new float[NPC.maxAI];
                                                                                                for (int num49 = 0; num49 < NPC.maxAI; num49++)
                                                                                                {
                                                                                                    array[num49] = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                    num += 4;
                                                                                                }
                                                                                                int num50 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                if (!Main.npc[(int)num47].active || Main.npc[(int)num47].netID != num50)
                                                                                                {
                                                                                                    Main.npc[(int)num47].active = true;
                                                                                                    Main.npc[(int)num47].netDefaults(num50);
                                                                                                }
                                                                                                Main.npc[(int)num47].position.X = x4;
                                                                                                Main.npc[(int)num47].position.Y = y3;
                                                                                                Main.npc[(int)num47].velocity.X = x5;
                                                                                                Main.npc[(int)num47].velocity.Y = y4;
                                                                                                Main.npc[(int)num47].target = target;
                                                                                                Main.npc[(int)num47].direction = direction;
                                                                                                Main.npc[(int)num47].directionY = directionY;
                                                                                                Main.npc[(int)num47].life = num48;
                                                                                                if (num48 <= 0)
                                                                                                {
                                                                                                    Main.npc[(int)num47].active = false;
                                                                                                }
                                                                                                for (int num51 = 0; num51 < NPC.maxAI; num51++)
                                                                                                {
                                                                                                    Main.npc[(int)num47].ai[num51] = array[num51];
                                                                                                }
                                                                                                return;
                                                                                            }
                                                                                            if (b == 24)
                                                                                            {
                                                                                                short num52 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                num += 2;
                                                                                                byte b13 = this.readBuffer[num];
                                                                                                if (Main.netMode == 2)
                                                                                                {
                                                                                                    b13 = (byte)this.whoAmI;
                                                                                                }
                                                                                                Main.npc[(int)num52].StrikeNPC(Main.player[(int)b13].inventory[Main.player[(int)b13].selectedItem].damage, Main.player[(int)b13].inventory[Main.player[(int)b13].selectedItem].knockBack, Main.player[(int)b13].direction, false, false);
                                                                                                if (Main.netMode == 2)
                                                                                                {
                                                                                                    NetMessage.SendData(24, -1, this.whoAmI, "", (int)num52, (float)b13, 0f, 0f, 0);
                                                                                                    NetMessage.SendData(23, -1, -1, "", (int)num52, 0f, 0f, 0f, 0);
                                                                                                    return;
                                                                                                }
                                                                                                return;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (b == 25)
                                                                                                {
                                                                                                    int num53 = (int)this.readBuffer[start + 1];
                                                                                                    if (Main.netMode == 2)
                                                                                                    {
                                                                                                        num53 = this.whoAmI;
                                                                                                    }
                                                                                                    byte b14 = this.readBuffer[start + 2];
                                                                                                    byte b15 = this.readBuffer[start + 3];
                                                                                                    byte b16 = this.readBuffer[start + 4];
                                                                                                    if (Main.netMode == 2)
                                                                                                    {
                                                                                                        b14 = 255;
                                                                                                        b15 = 255;
                                                                                                        b16 = 255;
                                                                                                    }
                                                                                                    string string3 = Encoding.UTF8.GetString(this.readBuffer, start + 5, length - 5);
                                                                                                    if (Main.netMode == 1)
                                                                                                    {
                                                                                                        string newText = string3;
                                                                                                        if (num53 < 255)
                                                                                                        {
                                                                                                            newText = "<" + Main.player[num53].name + "> " + string3;
                                                                                                            Main.player[num53].chatText = string3;
                                                                                                            Main.player[num53].chatShowTime = Main.chatLength / 2;
                                                                                                        }
                                                                                                        Main.NewText(newText, b14, b15, b16);
                                                                                                        return;
                                                                                                    }
                                                                                                    if (Main.netMode != 2)
                                                                                                    {
                                                                                                        return;
                                                                                                    }
                                                                                                    string text2 = string3.ToLower();
                                                                                                    if (text2 == Lang.mp[6])
                                                                                                    {
                                                                                                        string text3 = "";
                                                                                                        for (int num54 = 0; num54 < 255; num54++)
                                                                                                        {
                                                                                                            if (Main.player[num54].active)
                                                                                                            {
                                                                                                                if (text3 == "")
                                                                                                                {
                                                                                                                    text3 += Main.player[num54].name;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    text3 = text3 + ", " + Main.player[num54].name;
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                        NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[7] + " " + text3 + ".", 255, 255f, 240f, 20f, 0);
                                                                                                        return;
                                                                                                    }
                                                                                                    if (text2.Length >= 4 && text2.Substring(0, 4) == "/me ")
                                                                                                    {
                                                                                                        NetMessage.SendData(25, -1, -1, "*" + Main.player[this.whoAmI].name + " " + string3.Substring(4), 255, 200f, 100f, 0f, 0);
                                                                                                        return;
                                                                                                    }
                                                                                                    if (text2 == Lang.mp[8])
                                                                                                    {
                                                                                                        NetMessage.SendData(25, -1, -1, string.Concat(new object[]
																										{
																											"*", 
																											Main.player[this.whoAmI].name, 
																											" ", 
																											Lang.mp[9], 
																											" ", 
																											Main.rand.Next(1, 101)
																										}), 255, 255f, 240f, 20f, 0);
                                                                                                        return;
                                                                                                    }
                                                                                                    if (text2.Length >= 3 && text2.Substring(0, 3) == "/p ")
                                                                                                    {
                                                                                                        if (Main.player[this.whoAmI].team != 0)
                                                                                                        {
                                                                                                            for (int num55 = 0; num55 < 255; num55++)
                                                                                                            {
                                                                                                                if (Main.player[num55].team == Main.player[this.whoAmI].team)
                                                                                                                {
                                                                                                                    NetMessage.SendData(25, num55, -1, string3.Substring(3), num53, (float)Main.teamColor[Main.player[this.whoAmI].team].R, (float)Main.teamColor[Main.player[this.whoAmI].team].G, (float)Main.teamColor[Main.player[this.whoAmI].team].B, 0);
                                                                                                                }
                                                                                                            }
                                                                                                            return;
                                                                                                        }
                                                                                                        NetMessage.SendData(25, this.whoAmI, -1, Lang.mp[10], 255, 255f, 240f, 20f, 0);
                                                                                                        return;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (Main.player[this.whoAmI].difficulty == 2)
                                                                                                        {
                                                                                                            b14 = Main.hcColor.R;
                                                                                                            b15 = Main.hcColor.G;
                                                                                                            b16 = Main.hcColor.B;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (Main.player[this.whoAmI].difficulty == 1)
                                                                                                            {
                                                                                                                b14 = Main.mcColor.R;
                                                                                                                b15 = Main.mcColor.G;
                                                                                                                b16 = Main.mcColor.B;
                                                                                                            }
                                                                                                        }
                                                                                                        NetMessage.SendData(25, -1, -1, string3, num53, (float)b14, (float)b15, (float)b16, 0);
                                                                                                        if (Main.dedServ)
                                                                                                        {
                                                                                                            Console.WriteLine("<" + Main.player[this.whoAmI].name + "> " + string3);
                                                                                                            return;
                                                                                                        }
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (b == 26)
                                                                                                    {
                                                                                                        byte b17 = this.readBuffer[num];
                                                                                                        if (Main.netMode == 2 && this.whoAmI != (int)b17 && (!Main.player[(int)b17].hostile || !Main.player[this.whoAmI].hostile))
                                                                                                        {
                                                                                                            return;
                                                                                                        }
                                                                                                        num++;
                                                                                                        int num56 = (int)(this.readBuffer[num] - 1);
                                                                                                        num++;
                                                                                                        short num57 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                        num += 2;
                                                                                                        byte b18 = this.readBuffer[num];
                                                                                                        num++;
                                                                                                        bool pvp = false;
                                                                                                        byte b19 = this.readBuffer[num];
                                                                                                        num++;
                                                                                                        bool crit = false;
                                                                                                        string string4 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                                                                                        if (b18 != 0)
                                                                                                        {
                                                                                                            pvp = true;
                                                                                                        }
                                                                                                        if (b19 != 0)
                                                                                                        {
                                                                                                            crit = true;
                                                                                                        }
                                                                                                        Main.player[(int)b17].Hurt((int)num57, num56, pvp, true, string4, crit);
                                                                                                        if (Main.netMode == 2)
                                                                                                        {
                                                                                                            NetMessage.SendData(26, -1, this.whoAmI, string4, (int)b17, (float)num56, (float)num57, (float)b18, 0);
                                                                                                            return;
                                                                                                        }
                                                                                                        return;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (b == 27)
                                                                                                        {
                                                                                                            short num58 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                            num += 2;
                                                                                                            float x6 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                            num += 4;
                                                                                                            float y5 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                            num += 4;
                                                                                                            float x7 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                            num += 4;
                                                                                                            float y6 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                            num += 4;
                                                                                                            float knockBack = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                            num += 4;
                                                                                                            short damage = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                            num += 2;
                                                                                                            byte b20 = this.readBuffer[num];
                                                                                                            num++;
                                                                                                            byte b21 = this.readBuffer[num];
                                                                                                            num++;
                                                                                                            float[] array2 = new float[Projectile.maxAI];
                                                                                                            if (Main.netMode == 2)
                                                                                                            {
                                                                                                                b20 = (byte)this.whoAmI;
                                                                                                                if (Main.projHostile[(int)b21])
                                                                                                                {
                                                                                                                    return;
                                                                                                                }
                                                                                                            }
                                                                                                            for (int num59 = 0; num59 < Projectile.maxAI; num59++)
                                                                                                            {
                                                                                                                array2[num59] = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                                num += 4;
                                                                                                            }
                                                                                                            int num60 = 1000;
                                                                                                            for (int num61 = 0; num61 < 1000; num61++)
                                                                                                            {
                                                                                                                if (Main.projectile[num61].owner == (int)b20 && Main.projectile[num61].identity == (int)num58 && Main.projectile[num61].active)
                                                                                                                {
                                                                                                                    num60 = num61;
                                                                                                                    break;
                                                                                                                }
                                                                                                            }
                                                                                                            if (num60 == 1000)
                                                                                                            {
                                                                                                                for (int num62 = 0; num62 < 1000; num62++)
                                                                                                                {
                                                                                                                    if (!Main.projectile[num62].active)
                                                                                                                    {
                                                                                                                        num60 = num62;
                                                                                                                        break;
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                            if (!Main.projectile[num60].active || Main.projectile[num60].type != (int)b21)
                                                                                                            {
                                                                                                                Main.projectile[num60].SetDefaults((int)b21);
                                                                                                                if (Main.netMode == 2)
                                                                                                                {
                                                                                                                    Netplay.serverSock[this.whoAmI].spamProjectile += 1f;
                                                                                                                }
                                                                                                            }
                                                                                                            Main.projectile[num60].identity = (int)num58;
                                                                                                            Main.projectile[num60].position.X = x6;
                                                                                                            Main.projectile[num60].position.Y = y5;
                                                                                                            Main.projectile[num60].velocity.X = x7;
                                                                                                            Main.projectile[num60].velocity.Y = y6;
                                                                                                            Main.projectile[num60].damage = (int)damage;
                                                                                                            Main.projectile[num60].type = (int)b21;
                                                                                                            Main.projectile[num60].owner = (int)b20;
                                                                                                            Main.projectile[num60].knockBack = knockBack;
                                                                                                            for (int num63 = 0; num63 < Projectile.maxAI; num63++)
                                                                                                            {
                                                                                                                Main.projectile[num60].ai[num63] = array2[num63];
                                                                                                            }
                                                                                                            if (Main.netMode == 2)
                                                                                                            {
                                                                                                                NetMessage.SendData(27, -1, this.whoAmI, "", num60, 0f, 0f, 0f, 0);
                                                                                                                return;
                                                                                                            }
                                                                                                            return;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (b == 28)
                                                                                                            {
                                                                                                                short num64 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                num += 2;
                                                                                                                short num65 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                num += 2;
                                                                                                                float num66 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                                num += 4;
                                                                                                                int num67 = (int)(this.readBuffer[num] - 1);
                                                                                                                num++;
                                                                                                                int num68 = (int)this.readBuffer[num];
                                                                                                                if (num65 >= 0)
                                                                                                                {
                                                                                                                    if (num68 == 1)
                                                                                                                    {
                                                                                                                        Main.npc[(int)num64].StrikeNPC((int)num65, num66, num67, true, false);
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        Main.npc[(int)num64].StrikeNPC((int)num65, num66, num67, false, false);
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    Main.npc[(int)num64].life = 0;
                                                                                                                    Main.npc[(int)num64].HitEffect(0, 10.0);
                                                                                                                    Main.npc[(int)num64].active = false;
                                                                                                                }
                                                                                                                if (Main.netMode != 2)
                                                                                                                {
                                                                                                                    return;
                                                                                                                }
                                                                                                                if (Main.npc[(int)num64].life <= 0)
                                                                                                                {
                                                                                                                    NetMessage.SendData(28, -1, this.whoAmI, "", (int)num64, (float)num65, num66, (float)num67, num68);
                                                                                                                    NetMessage.SendData(23, -1, -1, "", (int)num64, 0f, 0f, 0f, 0);
                                                                                                                    return;
                                                                                                                }
                                                                                                                NetMessage.SendData(28, -1, this.whoAmI, "", (int)num64, (float)num65, num66, (float)num67, num68);
                                                                                                                Main.npc[(int)num64].netUpdate = true;
                                                                                                                return;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (b == 29)
                                                                                                                {
                                                                                                                    short num69 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                    num += 2;
                                                                                                                    byte b22 = this.readBuffer[num];
                                                                                                                    if (Main.netMode == 2)
                                                                                                                    {
                                                                                                                        b22 = (byte)this.whoAmI;
                                                                                                                    }
                                                                                                                    for (int num70 = 0; num70 < 1000; num70++)
                                                                                                                    {
                                                                                                                        if (Main.projectile[num70].owner == (int)b22 && Main.projectile[num70].identity == (int)num69 && Main.projectile[num70].active)
                                                                                                                        {
                                                                                                                            Main.projectile[num70].Kill();
                                                                                                                            break;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    if (Main.netMode == 2)
                                                                                                                    {
                                                                                                                        NetMessage.SendData(29, -1, this.whoAmI, "", (int)num69, (float)b22, 0f, 0f, 0);
                                                                                                                        return;
                                                                                                                    }
                                                                                                                    return;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (b == 30)
                                                                                                                    {
                                                                                                                        byte b23 = this.readBuffer[num];
                                                                                                                        if (Main.netMode == 2)
                                                                                                                        {
                                                                                                                            b23 = (byte)this.whoAmI;
                                                                                                                        }
                                                                                                                        num++;
                                                                                                                        byte b24 = this.readBuffer[num];
                                                                                                                        if (b24 == 1)
                                                                                                                        {
                                                                                                                            Main.player[(int)b23].hostile = true;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            Main.player[(int)b23].hostile = false;
                                                                                                                        }
                                                                                                                        if (Main.netMode == 2)
                                                                                                                        {
                                                                                                                            NetMessage.SendData(30, -1, this.whoAmI, "", (int)b23, 0f, 0f, 0f, 0);
                                                                                                                            string str = " " + Lang.mp[11];
                                                                                                                            if (b24 == 0)
                                                                                                                            {
                                                                                                                                str = " " + Lang.mp[12];
                                                                                                                            }
                                                                                                                            NetMessage.SendData(25, -1, -1, Main.player[(int)b23].name + str, 255, (float)Main.teamColor[Main.player[(int)b23].team].R, (float)Main.teamColor[Main.player[(int)b23].team].G, (float)Main.teamColor[Main.player[(int)b23].team].B, 0);
                                                                                                                            return;
                                                                                                                        }
                                                                                                                        return;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (b == 31)
                                                                                                                        {
                                                                                                                            if (Main.netMode != 2)
                                                                                                                            {
                                                                                                                                return;
                                                                                                                            }
                                                                                                                            int x8 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                            num += 4;
                                                                                                                            int y7 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                            num += 4;
                                                                                                                            int num71 = Chest.FindChest(x8, y7);
                                                                                                                            if (num71 > -1 && Chest.UsingChest(num71) == -1)
                                                                                                                            {
                                                                                                                                for (int num72 = 0; num72 < Chest.maxItems; num72++)
                                                                                                                                {
                                                                                                                                    NetMessage.SendData(32, this.whoAmI, -1, "", num71, (float)num72, 0f, 0f, 0);
                                                                                                                                }
                                                                                                                                NetMessage.SendData(33, this.whoAmI, -1, "", num71, 0f, 0f, 0f, 0);
                                                                                                                                Main.player[this.whoAmI].chest = num71;
                                                                                                                                return;
                                                                                                                            }
                                                                                                                            return;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (b == 32)
                                                                                                                            {
                                                                                                                                int num73 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                num += 2;
                                                                                                                                int num74 = (int)this.readBuffer[num];
                                                                                                                                num++;
                                                                                                                                int stack3 = (int)this.readBuffer[num];
                                                                                                                                num++;
                                                                                                                                int pre2 = (int)this.readBuffer[num];
                                                                                                                                num++;
                                                                                                                                int type4 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                if (Main.chest[num73] == null)
                                                                                                                                {
                                                                                                                                    Main.chest[num73] = new Chest();
                                                                                                                                }
                                                                                                                                if (Main.chest[num73].item[num74] == null)
                                                                                                                                {
                                                                                                                                    Main.chest[num73].item[num74] = new Item();
                                                                                                                                }
                                                                                                                                Main.chest[num73].item[num74].netDefaults(type4);
                                                                                                                                Main.chest[num73].item[num74].Prefix(pre2);
                                                                                                                                Main.chest[num73].item[num74].stack = stack3;
                                                                                                                                return;
                                                                                                                            }
                                                                                                                            if (b == 33)
                                                                                                                            {
                                                                                                                                int num75 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                num += 2;
                                                                                                                                int chestX = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                num += 4;
                                                                                                                                int chestY = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                if (Main.netMode == 1)
                                                                                                                                {
                                                                                                                                    if (Main.player[Main.myPlayer].chest == -1)
                                                                                                                                    {
                                                                                                                                        Main.playerInventory = true;
                                                                                                                                        Main.PlaySound(10, -1, -1, 1);
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (Main.player[Main.myPlayer].chest != num75 && num75 != -1)
                                                                                                                                        {
                                                                                                                                            Main.playerInventory = true;
                                                                                                                                            Main.PlaySound(12, -1, -1, 1);
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (Main.player[Main.myPlayer].chest != -1 && num75 == -1)
                                                                                                                                            {
                                                                                                                                                Main.PlaySound(11, -1, -1, 1);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    Main.player[Main.myPlayer].chest = num75;
                                                                                                                                    Main.player[Main.myPlayer].chestX = chestX;
                                                                                                                                    Main.player[Main.myPlayer].chestY = chestY;
                                                                                                                                    return;
                                                                                                                                }
                                                                                                                                Main.player[this.whoAmI].chest = num75;
                                                                                                                                return;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (b == 34)
                                                                                                                                {
                                                                                                                                    if (Main.netMode != 2)
                                                                                                                                    {
                                                                                                                                        return;
                                                                                                                                    }
                                                                                                                                    int num76 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                    num += 4;
                                                                                                                                    int num77 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                    if (Main.tile[num76, num77].type != 21)
                                                                                                                                    {
                                                                                                                                        return;
                                                                                                                                    }
                                                                                                                                    WorldGen.KillTile(num76, num77, false, false, false);
                                                                                                                                    if (!Main.tile[num76, num77].active)
                                                                                                                                    {
                                                                                                                                        NetMessage.SendData(17, -1, -1, "", 0, (float)num76, (float)num77, 0f, 0);
                                                                                                                                        return;
                                                                                                                                    }
                                                                                                                                    return;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (b == 35)
                                                                                                                                    {
                                                                                                                                        int num78 = (int)this.readBuffer[num];
                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                        {
                                                                                                                                            num78 = this.whoAmI;
                                                                                                                                        }
                                                                                                                                        num++;
                                                                                                                                        int num79 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                        num += 2;
                                                                                                                                        if (num78 != Main.myPlayer)
                                                                                                                                        {
                                                                                                                                            Main.player[num78].HealEffect(num79);
                                                                                                                                        }
                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                        {
                                                                                                                                            NetMessage.SendData(35, -1, this.whoAmI, "", num78, (float)num79, 0f, 0f, 0);
                                                                                                                                            return;
                                                                                                                                        }
                                                                                                                                        return;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (b == 36)
                                                                                                                                        {
                                                                                                                                            int num80 = (int)this.readBuffer[num];
                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                            {
                                                                                                                                                num80 = this.whoAmI;
                                                                                                                                            }
                                                                                                                                            num++;
                                                                                                                                            int num81 = (int)this.readBuffer[num];
                                                                                                                                            num++;
                                                                                                                                            int num82 = (int)this.readBuffer[num];
                                                                                                                                            num++;
                                                                                                                                            int num83 = (int)this.readBuffer[num];
                                                                                                                                            num++;
                                                                                                                                            int num84 = (int)this.readBuffer[num];
                                                                                                                                            num++;
                                                                                                                                            int num85 = (int)this.readBuffer[num];
                                                                                                                                            num++;
                                                                                                                                            if (num81 == 0)
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneEvil = false;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneEvil = true;
                                                                                                                                            }
                                                                                                                                            if (num82 == 0)
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneMeteor = false;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneMeteor = true;
                                                                                                                                            }
                                                                                                                                            if (num83 == 0)
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneDungeon = false;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneDungeon = true;
                                                                                                                                            }
                                                                                                                                            if (num84 == 0)
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneJungle = false;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneJungle = true;
                                                                                                                                            }
                                                                                                                                            if (num85 == 0)
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneHoly = false;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                Main.player[num80].zoneHoly = true;
                                                                                                                                            }
                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                            {
                                                                                                                                                NetMessage.SendData(36, -1, this.whoAmI, "", num80, 0f, 0f, 0f, 0);
                                                                                                                                                return;
                                                                                                                                            }
                                                                                                                                            return;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (b == 37)
                                                                                                                                            {
                                                                                                                                                if (Main.netMode != 1)
                                                                                                                                                {
                                                                                                                                                    return;
                                                                                                                                                }
                                                                                                                                                if (Main.autoPass)
                                                                                                                                                {
                                                                                                                                                    NetMessage.SendData(38, -1, -1, Netplay.password, 0, 0f, 0f, 0f, 0);
                                                                                                                                                    Main.autoPass = false;
                                                                                                                                                    return;
                                                                                                                                                }
                                                                                                                                                Netplay.password = "";
                                                                                                                                                Main.menuMode = 31;
                                                                                                                                                return;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (b == 38)
                                                                                                                                                {
                                                                                                                                                    if (Main.netMode != 2)
                                                                                                                                                    {
                                                                                                                                                        return;
                                                                                                                                                    }
                                                                                                                                                    string string5 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                                                                                                                                    if (string5 == Netplay.password)
                                                                                                                                                    {
                                                                                                                                                        Netplay.serverSock[this.whoAmI].state = 1;
                                                                                                                                                        NetMessage.SendData(3, this.whoAmI, -1, "", 0, 0f, 0f, 0f, 0);
                                                                                                                                                        return;
                                                                                                                                                    }
                                                                                                                                                    NetMessage.SendData(2, this.whoAmI, -1, Lang.mp[1], 0, 0f, 0f, 0f, 0);
                                                                                                                                                    return;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (b == 39 && Main.netMode == 1)
                                                                                                                                                    {
                                                                                                                                                        short num86 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                        Main.item[(int)num86].owner = 255;
                                                                                                                                                        NetMessage.SendData(22, -1, -1, "", (int)num86, 0f, 0f, 0f, 0);
                                                                                                                                                        return;
                                                                                                                                                    }
                                                                                                                                                    if (b == 40)
                                                                                                                                                    {
                                                                                                                                                        byte b25 = this.readBuffer[num];
                                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                                        {
                                                                                                                                                            b25 = (byte)this.whoAmI;
                                                                                                                                                        }
                                                                                                                                                        num++;
                                                                                                                                                        int talkNPC = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                        num += 2;
                                                                                                                                                        Main.player[(int)b25].talkNPC = talkNPC;
                                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                                        {
                                                                                                                                                            NetMessage.SendData(40, -1, this.whoAmI, "", (int)b25, 0f, 0f, 0f, 0);
                                                                                                                                                            return;
                                                                                                                                                        }
                                                                                                                                                        return;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (b == 41)
                                                                                                                                                        {
                                                                                                                                                            byte b26 = this.readBuffer[num];
                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                            {
                                                                                                                                                                b26 = (byte)this.whoAmI;
                                                                                                                                                            }
                                                                                                                                                            num++;
                                                                                                                                                            float itemRotation = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                                                                            num += 4;
                                                                                                                                                            int itemAnimation = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                            Main.player[(int)b26].itemRotation = itemRotation;
                                                                                                                                                            Main.player[(int)b26].itemAnimation = itemAnimation;
                                                                                                                                                            Main.player[(int)b26].channel = Main.player[(int)b26].inventory[Main.player[(int)b26].selectedItem].channel;
                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                            {
                                                                                                                                                                NetMessage.SendData(41, -1, this.whoAmI, "", (int)b26, 0f, 0f, 0f, 0);
                                                                                                                                                                return;
                                                                                                                                                            }
                                                                                                                                                            return;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (b == 42)
                                                                                                                                                            {
                                                                                                                                                                int num87 = (int)this.readBuffer[num];
                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                {
                                                                                                                                                                    num87 = this.whoAmI;
                                                                                                                                                                }
                                                                                                                                                                num++;
                                                                                                                                                                int statMana = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                num += 2;
                                                                                                                                                                int statManaMax = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                {
                                                                                                                                                                    num87 = this.whoAmI;
                                                                                                                                                                }
                                                                                                                                                                Main.player[num87].statMana = statMana;
                                                                                                                                                                Main.player[num87].statManaMax = statManaMax;
                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                {
                                                                                                                                                                    NetMessage.SendData(42, -1, this.whoAmI, "", num87, 0f, 0f, 0f, 0);
                                                                                                                                                                    return;
                                                                                                                                                                }
                                                                                                                                                                return;
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (b == 43)
                                                                                                                                                                {
                                                                                                                                                                    int num88 = (int)this.readBuffer[num];
                                                                                                                                                                    if (Main.netMode == 2)
                                                                                                                                                                    {
                                                                                                                                                                        num88 = this.whoAmI;
                                                                                                                                                                    }
                                                                                                                                                                    num++;
                                                                                                                                                                    int num89 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                    num += 2;
                                                                                                                                                                    if (num88 != Main.myPlayer)
                                                                                                                                                                    {
                                                                                                                                                                        Main.player[num88].ManaEffect(num89);
                                                                                                                                                                    }
                                                                                                                                                                    if (Main.netMode == 2)
                                                                                                                                                                    {
                                                                                                                                                                        NetMessage.SendData(43, -1, this.whoAmI, "", num88, (float)num89, 0f, 0f, 0);
                                                                                                                                                                        return;
                                                                                                                                                                    }
                                                                                                                                                                    return;
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (b == 44)
                                                                                                                                                                    {
                                                                                                                                                                        byte b27 = this.readBuffer[num];
                                                                                                                                                                        if ((int)b27 == Main.myPlayer)
                                                                                                                                                                        {
                                                                                                                                                                            return;
                                                                                                                                                                        }
                                                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                                                        {
                                                                                                                                                                            b27 = (byte)this.whoAmI;
                                                                                                                                                                        }
                                                                                                                                                                        num++;
                                                                                                                                                                        int num90 = (int)(this.readBuffer[num] - 1);
                                                                                                                                                                        num++;
                                                                                                                                                                        short num91 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                        num += 2;
                                                                                                                                                                        byte b28 = this.readBuffer[num];
                                                                                                                                                                        num++;
                                                                                                                                                                        string string6 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                                                                                                                                                        bool pvp2 = false;
                                                                                                                                                                        if (b28 != 0)
                                                                                                                                                                        {
                                                                                                                                                                            pvp2 = true;
                                                                                                                                                                        }
                                                                                                                                                                        Main.player[(int)b27].KillMe((double)num91, num90, pvp2, string6);
                                                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                                                        {
                                                                                                                                                                            NetMessage.SendData(44, -1, this.whoAmI, string6, (int)b27, (float)num90, (float)num91, (float)b28, 0);
                                                                                                                                                                            return;
                                                                                                                                                                        }
                                                                                                                                                                        return;
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (b == 45)
                                                                                                                                                                        {
                                                                                                                                                                            int num92 = (int)this.readBuffer[num];
                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                            {
                                                                                                                                                                                num92 = this.whoAmI;
                                                                                                                                                                            }
                                                                                                                                                                            num++;
                                                                                                                                                                            int num93 = (int)this.readBuffer[num];
                                                                                                                                                                            num++;
                                                                                                                                                                            int team = Main.player[num92].team;
                                                                                                                                                                            Main.player[num92].team = num93;
                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                            {
                                                                                                                                                                                NetMessage.SendData(45, -1, this.whoAmI, "", num92, 0f, 0f, 0f, 0);
                                                                                                                                                                                string str2 = "";
                                                                                                                                                                                if (num93 == 0)
                                                                                                                                                                                {
                                                                                                                                                                                    str2 = " " + Lang.mp[13];
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    if (num93 == 1)
                                                                                                                                                                                    {
                                                                                                                                                                                        str2 = " " + Lang.mp[14];
                                                                                                                                                                                    }
                                                                                                                                                                                    else
                                                                                                                                                                                    {
                                                                                                                                                                                        if (num93 == 2)
                                                                                                                                                                                        {
                                                                                                                                                                                            str2 = " " + Lang.mp[15];
                                                                                                                                                                                        }
                                                                                                                                                                                        else
                                                                                                                                                                                        {
                                                                                                                                                                                            if (num93 == 3)
                                                                                                                                                                                            {
                                                                                                                                                                                                str2 = " " + Lang.mp[16];
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (num93 == 4)
                                                                                                                                                                                                {
                                                                                                                                                                                                    str2 = " " + Lang.mp[17];
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                                for (int num94 = 0; num94 < 255; num94++)
                                                                                                                                                                                {
                                                                                                                                                                                    if (num94 == this.whoAmI || (team > 0 && Main.player[num94].team == team) || (num93 > 0 && Main.player[num94].team == num93))
                                                                                                                                                                                    {
                                                                                                                                                                                        NetMessage.SendData(25, num94, -1, Main.player[num92].name + str2, 255, (float)Main.teamColor[num93].R, (float)Main.teamColor[num93].G, (float)Main.teamColor[num93].B, 0);
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                                return;
                                                                                                                                                                            }
                                                                                                                                                                            return;
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (b == 46)
                                                                                                                                                                            {
                                                                                                                                                                                if (Main.netMode != 2)
                                                                                                                                                                                {
                                                                                                                                                                                    return;
                                                                                                                                                                                }
                                                                                                                                                                                int i2 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                num += 4;
                                                                                                                                                                                int j2 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                num += 4;
                                                                                                                                                                                int num95 = Sign.ReadSign(i2, j2);
                                                                                                                                                                                if (num95 >= 0)
                                                                                                                                                                                {
                                                                                                                                                                                    NetMessage.SendData(47, this.whoAmI, -1, "", num95, 0f, 0f, 0f, 0);
                                                                                                                                                                                    return;
                                                                                                                                                                                }
                                                                                                                                                                                return;
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                if (b == 47)
                                                                                                                                                                                {
                                                                                                                                                                                    int num96 = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                    num += 2;
                                                                                                                                                                                    int x9 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                    num += 4;
                                                                                                                                                                                    int y8 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                    num += 4;
                                                                                                                                                                                    string string7 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                                                                                                                                                                    Main.sign[num96] = new Sign();
                                                                                                                                                                                    Main.sign[num96].x = x9;
                                                                                                                                                                                    Main.sign[num96].y = y8;
                                                                                                                                                                                    Sign.TextSign(num96, string7);
                                                                                                                                                                                    if (Main.netMode == 1 && Main.sign[num96] != null && num96 != Main.player[Main.myPlayer].sign)
                                                                                                                                                                                    {
                                                                                                                                                                                        Main.playerInventory = false;
                                                                                                                                                                                        Main.player[Main.myPlayer].talkNPC = -1;
                                                                                                                                                                                        Main.editSign = false;
                                                                                                                                                                                        Main.PlaySound(10, -1, -1, 1);
                                                                                                                                                                                        Main.player[Main.myPlayer].sign = num96;
                                                                                                                                                                                        Main.npcChatText = Main.sign[num96].text;
                                                                                                                                                                                        return;
                                                                                                                                                                                    }
                                                                                                                                                                                    return;
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    if (b == 48)
                                                                                                                                                                                    {
                                                                                                                                                                                        int num97 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                        num += 4;
                                                                                                                                                                                        int num98 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                        num += 4;
                                                                                                                                                                                        byte liquid = this.readBuffer[num];
                                                                                                                                                                                        num++;
                                                                                                                                                                                        byte b29 = this.readBuffer[num];
                                                                                                                                                                                        num++;
                                                                                                                                                                                        if (Main.netMode == 2 && Netplay.spamCheck)
                                                                                                                                                                                        {
                                                                                                                                                                                            int num99 = this.whoAmI;
                                                                                                                                                                                            int num100 = (int)(Main.player[num99].position.X + (float)(Main.player[num99].width / 2));
                                                                                                                                                                                            int num101 = (int)(Main.player[num99].position.Y + (float)(Main.player[num99].height / 2));
                                                                                                                                                                                            int num102 = 10;
                                                                                                                                                                                            int num103 = num100 - num102;
                                                                                                                                                                                            int num104 = num100 + num102;
                                                                                                                                                                                            int num105 = num101 - num102;
                                                                                                                                                                                            int num106 = num101 + num102;
                                                                                                                                                                                            if (num100 < num103 || num100 > num104 || num101 < num105 || num101 > num106)
                                                                                                                                                                                            {
                                                                                                                                                                                                NetMessage.BootPlayer(this.whoAmI, "Cheating attempt detected: Liquid spam");
                                                                                                                                                                                                return;
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                        if (Main.tile[num97, num98] == null)
                                                                                                                                                                                        {
                                                                                                                                                                                            Main.tile[num97, num98] = new Tile();
                                                                                                                                                                                        }
                                                                                                                                                                                        lock (Main.tile[num97, num98])
                                                                                                                                                                                        {
                                                                                                                                                                                            Main.tile[num97, num98].liquid = liquid;
                                                                                                                                                                                            if (b29 == 1)
                                                                                                                                                                                            {
                                                                                                                                                                                                Main.tile[num97, num98].lava = true;
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                Main.tile[num97, num98].lava = false;
                                                                                                                                                                                            }
                                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                                            {
                                                                                                                                                                                                WorldGen.SquareTileFrame(num97, num98, true);
                                                                                                                                                                                            }
                                                                                                                                                                                            return;
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                    if (b == 49)
                                                                                                                                                                                    {
                                                                                                                                                                                        if (Netplay.clientSock.state == 6)
                                                                                                                                                                                        {
                                                                                                                                                                                            Netplay.clientSock.state = 10;
                                                                                                                                                                                            Main.player[Main.myPlayer].Spawn();
                                                                                                                                                                                            return;
                                                                                                                                                                                        }
                                                                                                                                                                                        return;
                                                                                                                                                                                    }
                                                                                                                                                                                    else
                                                                                                                                                                                    {
                                                                                                                                                                                        if (b == 50)
                                                                                                                                                                                        {
                                                                                                                                                                                            int num107 = (int)this.readBuffer[num];
                                                                                                                                                                                            num++;
                                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                                            {
                                                                                                                                                                                                num107 = this.whoAmI;
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (num107 == Main.myPlayer)
                                                                                                                                                                                                {
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                            for (int num108 = 0; num108 < 10; num108++)
                                                                                                                                                                                            {
                                                                                                                                                                                                Main.player[num107].buffType[num108] = (int)this.readBuffer[num];
                                                                                                                                                                                                if (Main.player[num107].buffType[num108] > 0)
                                                                                                                                                                                                {
                                                                                                                                                                                                    Main.player[num107].buffTime[num108] = 60;
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    Main.player[num107].buffTime[num108] = 0;
                                                                                                                                                                                                }
                                                                                                                                                                                                num++;
                                                                                                                                                                                            }
                                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                                            {
                                                                                                                                                                                                NetMessage.SendData(50, -1, this.whoAmI, "", num107, 0f, 0f, 0f, 0);
                                                                                                                                                                                                return;
                                                                                                                                                                                            }
                                                                                                                                                                                            return;
                                                                                                                                                                                        }
                                                                                                                                                                                        else
                                                                                                                                                                                        {
                                                                                                                                                                                            if (b == 51)
                                                                                                                                                                                            {
                                                                                                                                                                                                byte b30 = this.readBuffer[num];
                                                                                                                                                                                                num++;
                                                                                                                                                                                                byte b31 = this.readBuffer[num];
                                                                                                                                                                                                if (b31 == 1)
                                                                                                                                                                                                {
                                                                                                                                                                                                    NPC.SpawnSkeletron();
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                                if (b31 != 2)
                                                                                                                                                                                                {
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                                if (Main.netMode != 2)
                                                                                                                                                                                                {
                                                                                                                                                                                                    Main.PlaySound(2, (int)Main.player[(int)b30].position.X, (int)Main.player[(int)b30].position.Y, 1);
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                                                {
                                                                                                                                                                                                    NetMessage.SendData(51, -1, this.whoAmI, "", (int)b30, (float)b31, 0f, 0f, 0);
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                                return;
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (b == 52)
                                                                                                                                                                                                {
                                                                                                                                                                                                    byte number = this.readBuffer[num];
                                                                                                                                                                                                    num++;
                                                                                                                                                                                                    byte b32 = this.readBuffer[num];
                                                                                                                                                                                                    num++;
                                                                                                                                                                                                    int num109 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                    num += 4;
                                                                                                                                                                                                    int num110 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                    num += 4;
                                                                                                                                                                                                    if (b32 != 1)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        return;
                                                                                                                                                                                                    }
                                                                                                                                                                                                    Chest.Unlock(num109, num110);
                                                                                                                                                                                                    if (Main.netMode == 2)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        NetMessage.SendData(52, -1, this.whoAmI, "", (int)number, (float)b32, (float)num109, (float)num110, 0);
                                                                                                                                                                                                        NetMessage.SendTileSquare(-1, num109, num110, 2);
                                                                                                                                                                                                        return;
                                                                                                                                                                                                    }
                                                                                                                                                                                                    return;
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    if (b == 53)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        short num111 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                        num += 2;
                                                                                                                                                                                                        byte type5 = this.readBuffer[num];
                                                                                                                                                                                                        num++;
                                                                                                                                                                                                        short time = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                        num += 2;
                                                                                                                                                                                                        Main.npc[(int)num111].AddBuff((int)type5, (int)time, true);
                                                                                                                                                                                                        if (Main.netMode == 2)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            NetMessage.SendData(54, -1, -1, "", (int)num111, 0f, 0f, 0f, 0);
                                                                                                                                                                                                            return;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        return;
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (b == 54)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (Main.netMode == 1)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                short num112 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                num += 2;
                                                                                                                                                                                                                for (int num113 = 0; num113 < 5; num113++)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Main.npc[(int)num112].buffType[num113] = (int)this.readBuffer[num];
                                                                                                                                                                                                                    num++;
                                                                                                                                                                                                                    Main.npc[(int)num112].buffTime[num113] = (int)BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                    num += 2;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                return;
                                                                                                                                                                                                            }
                                                                                                                                                                                                            return;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (b == 55)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                byte b33 = this.readBuffer[num];
                                                                                                                                                                                                                num++;
                                                                                                                                                                                                                byte b34 = this.readBuffer[num];
                                                                                                                                                                                                                num++;
                                                                                                                                                                                                                short num114 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                num += 2;
                                                                                                                                                                                                                if (Main.netMode == 2 && (int)b33 != this.whoAmI && !Main.pvpBuff[(int)b34])
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                if (Main.netMode == 1 && (int)b33 == Main.myPlayer)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    Main.player[(int)b33].AddBuff((int)b34, (int)num114, true);
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    NetMessage.SendData(55, (int)b33, -1, "", (int)b33, (float)b34, (float)num114, 0f, 0);
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                return;
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (b == 56)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (Main.netMode == 1)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        short num115 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                        num += 2;
                                                                                                                                                                                                                        string string8 = Encoding.UTF8.GetString(this.readBuffer, num, length - num + start);
                                                                                                                                                                                                                        Main.chrName[(int)num115] = string8;
                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (b == 57)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        if (Main.netMode == 1)
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            WorldGen.tGood = this.readBuffer[num];
                                                                                                                                                                                                                            num++;
                                                                                                                                                                                                                            WorldGen.tEvil = this.readBuffer[num];
                                                                                                                                                                                                                            return;
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        if (b == 58)
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            byte b35 = this.readBuffer[num];
                                                                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                b35 = (byte)this.whoAmI;
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                            num++;
                                                                                                                                                                                                                            float num116 = BitConverter.ToSingle(this.readBuffer, num);
                                                                                                                                                                                                                            num += 4;
                                                                                                                                                                                                                            if (Main.netMode == 2)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                NetMessage.SendData(58, -1, this.whoAmI, "", this.whoAmI, num116, 0f, 0f, 0);
                                                                                                                                                                                                                                return;
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                            Main.harpNote = num116;
                                                                                                                                                                                                                            int style = 26;
                                                                                                                                                                                                                            if (Main.player[(int)b35].inventory[Main.player[(int)b35].selectedItem].type == 507)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                style = 35;
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                            Main.PlaySound(2, (int)Main.player[(int)b35].position.X, (int)Main.player[(int)b35].position.Y, style);
                                                                                                                                                                                                                            return;
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        else
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            if (b == 59)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                int num117 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                                                num += 4;
                                                                                                                                                                                                                                int num118 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                                                num += 4;
                                                                                                                                                                                                                                WorldGen.hitSwitch(num117, num118);
                                                                                                                                                                                                                                if (Main.netMode == 2)
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    NetMessage.SendData(59, -1, this.whoAmI, "", num117, (float)num118, 0f, 0f, 0);
                                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                return;
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                            else
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                if (b == 60)
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    short num119 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                                    num += 2;
                                                                                                                                                                                                                                    short num120 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                                    num += 2;
                                                                                                                                                                                                                                    short num121 = BitConverter.ToInt16(this.readBuffer, num);
                                                                                                                                                                                                                                    num += 2;
                                                                                                                                                                                                                                    byte b36 = this.readBuffer[num];
                                                                                                                                                                                                                                    num++;
                                                                                                                                                                                                                                    bool homeless = false;
                                                                                                                                                                                                                                    if (b36 == 1)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        homeless = true;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    if (Main.netMode == 1)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        Main.npc[(int)num119].homeless = homeless;
                                                                                                                                                                                                                                        Main.npc[(int)num119].homeTileX = (int)num120;
                                                                                                                                                                                                                                        Main.npc[(int)num119].homeTileY = (int)num121;
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    if (b36 == 0)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        WorldGen.kickOut((int)num119);
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    WorldGen.moveRoom((int)num120, (int)num121, (int)num119);
                                                                                                                                                                                                                                    return;
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    if (b != 61)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    int plr = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                                                    num += 4;
                                                                                                                                                                                                                                    int num122 = BitConverter.ToInt32(this.readBuffer, num);
                                                                                                                                                                                                                                    num += 4;
                                                                                                                                                                                                                                    if (Main.netMode != 2)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    if (num122 == 4 || num122 == 13 || num122 == 50 || num122 == 125 || num122 == 126 || num122 == 134 || num122 == 127 || num122 == 128)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        bool flag8 = true;
                                                                                                                                                                                                                                        for (int num123 = 0; num123 < 200; num123++)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            if (Main.npc[num123].active && Main.npc[num123].type == num122)
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                flag8 = false;
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        if (flag8)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            NPC.SpawnOnPlayer(plr, num122);
                                                                                                                                                                                                                                            return;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        if (num122 >= 0)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            return;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        int num124 = -1;
                                                                                                                                                                                                                                        if (num122 == -1)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            num124 = 1;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        if (num122 == -2)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            num124 = 2;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        if (num124 > 0 && Main.invasionType == 0)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            Main.invasionDelay = 0;
                                                                                                                                                                                                                                            Main.StartInvasion(num124);
                                                                                                                                                                                                                                            return;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        return;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                }
                                                                                                                                                                                                            }
                                                                                                                                                                                                        }
                                                                                                                                                                                                    }
                                                                                                                                                                                                }
                                                                                                                                                                                            }
                                                                                                                                                                                        }
                                                                                                                                                                                    }
                                                                                                                                                                                }
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                    }
                                                                                                                                                                }
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                }
                                                                                                                            }
                                                                                                                        }
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                return;
                                                                            }
                                                                            byte b37 = this.readBuffer[num];
                                                                            num++;
                                                                            int num125 = BitConverter.ToInt32(this.readBuffer, num);
                                                                            num += 4;
                                                                            int num126 = BitConverter.ToInt32(this.readBuffer, num);
                                                                            num += 4;
                                                                            int num127 = (int)this.readBuffer[num];
                                                                            int direction2 = 0;
                                                                            if (num127 == 0)
                                                                            {
                                                                                direction2 = -1;
                                                                            }
                                                                            if (b37 == 0)
                                                                            {
                                                                                WorldGen.OpenDoor(num125, num126, direction2);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (b37 == 1)
                                                                                {
                                                                                    WorldGen.CloseDoor(num125, num126, true);
                                                                                }
                                                                            }
                                                                            if (Main.netMode == 2)
                                                                            {
                                                                                NetMessage.SendData(19, -1, this.whoAmI, "", (int)b37, (float)num125, (float)num126, (float)num127, 0);
                                                                                return;
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
