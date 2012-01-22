using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
namespace Terraria
{
    public class Player
    {
        //mods
        public static bool godMode = true;
        public static bool infAmmo = true;
        //end mods
        public const int maxBuffs = 10;
        public bool flapSound;
        public int wingTime;
        public int wings;
        public int wingFrame;
        public int wingFrameCounter;
        public bool male = true;
        public bool ghost;
        public int ghostFrame;
        public int ghostFrameCounter;
        public bool pvpDeath;
        public bool zoneDungeon;
        public bool zoneEvil;
        public bool zoneHoly;
        public bool zoneMeteor;
        public bool zoneJungle;
        public bool boneArmor;
        public float townNPCs;
        public Vector2 position;
        public Vector2 oldPosition;
        public Vector2 velocity;
        public Vector2 oldVelocity;
        public double headFrameCounter;
        public double bodyFrameCounter;
        public double legFrameCounter;
        public int netSkip;
        public int oldSelectItem;
        public bool immune;
        public int immuneTime;
        public int immuneAlphaDirection;
        public int immuneAlpha;
        public int team;
        public bool hbLocked;
        public static int nameLen = 20;
        private float maxRegenDelay;
        public string chatText = "";
        public int sign = -1;
        public int chatShowTime;
        public int reuseDelay;
        public float activeNPCs;
        public bool mouseInterface;
        public int noThrow;
        public int changeItem = -1;
        public int selectedItem;
        public Item[] armor = new Item[11];
        public int itemAnimation;
        public int itemAnimationMax;
        public int itemTime;
        public int toolTime;
        public float itemRotation;
        public int itemWidth;
        public int itemHeight;
        public Vector2 itemLocation;
        public float ghostFade;
        public float ghostDir = 1f;
        public int[] buffType = new int[10];
        public int[] buffTime = new int[10];
        public int heldProj = -1;
        public int breathCD;
        public int breathMax = 200;
        public int breath = 200;
        public bool socialShadow;
        public string setBonus = "";
        public Item[] inventory = new Item[49];
        public Item[] bank = new Item[Chest.maxItems];
        public Item[] bank2 = new Item[Chest.maxItems];
        public float headRotation;
        public float bodyRotation;
        public float legRotation;
        public Vector2 headPosition;
        public Vector2 bodyPosition;
        public Vector2 legPosition;
        public Vector2 headVelocity;
        public Vector2 bodyVelocity;
        public Vector2 legVelocity;
        public int nonTorch = -1;
        public static bool deadForGood = false;
        public bool dead;
        public int respawnTimer;
        public string name = "";
        public int attackCD;
        public int potionDelay;
        public byte difficulty;
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        public int hitTile;
        public int hitTileX;
        public int hitTileY;
        public int jump;
        public int head = -1;
        public int body = -1;
        public int legs = -1;
        public Rectangle headFrame;
        public Rectangle bodyFrame;
        public Rectangle legFrame;
        public Rectangle hairFrame;
        public bool controlLeft;
        public bool controlRight;
        public bool controlUp;
        public bool controlDown;
        public bool controlJump;
        public bool controlUseItem;
        public bool controlUseTile;
        public bool controlThrow;
        public bool controlInv;
        public bool controlHook;
        public bool controlTorch;
        public bool releaseJump;
        public bool releaseUseItem;
        public bool releaseUseTile;
        public bool releaseInventory;
        public bool releaseHook;
        public bool releaseThrow;
        public bool releaseQuickMana;
        public bool releaseQuickHeal;
        public bool delayUseItem;
        public bool active;
        public int width = 20;
        public int height = 42;
        public int direction = 1;
        public bool showItemIcon;
        public int showItemIcon2;
        public int whoAmi;
        public int runSoundDelay;
        public float shadow;
        public float manaCost = 1f;
        public bool fireWalk;
        public Vector2[] shadowPos = new Vector2[3];
        public int shadowCount;
        public bool channel;
        public int step = -1;
        public int statDefense;
        public int statAttack;
        public int statLifeMax = 100;
        public int statLife = 100;
        public int statMana;
        public int statManaMax;
        public int statManaMax2;
        public int lifeRegen;
        public int lifeRegenCount;
        public int lifeRegenTime;
        public int manaRegen;
        public int manaRegenCount;
        public int manaRegenDelay;
        public bool manaRegenBuff;
        public bool noKnockback;
        public bool spaceGun;
        public float gravDir = 1f;
        public bool ammoCost80;
        public bool ammoCost75;
        public int stickyBreak;
        public bool lightOrb;
        public bool fairy;
        public bool bunny;
        public bool archery;
        public bool poisoned;
        public bool blind;
        public bool onFire;
        public bool onFire2;
        public bool noItems;
        public bool wereWolf;
        public bool wolfAcc;
        public bool rulerAcc;
        public bool bleed;
        public bool confused;
        public bool accMerman;
        public bool merman;
        public bool brokenArmor;
        public bool silence;
        public bool slow;
        public bool gross;
        public bool tongued;
        public bool kbGlove;
        public bool starCloak;
        public bool longInvince;
        public bool pStone;
        public bool manaFlower;
        public int meleeCrit = 4;
        public int rangedCrit = 4;
        public int magicCrit = 4;
        public float meleeDamage = 1f;
        public float rangedDamage = 1f;
        public float magicDamage = 1f;
        public float meleeSpeed = 1f;
        public float moveSpeed = 1f;
        public float pickSpeed = 1f;
        public int SpawnX = -1;
        public int SpawnY = -1;
        public int[] spX = new int[200];
        public int[] spY = new int[200];
        public string[] spN = new string[200];
        public int[] spI = new int[200];
        public static int tileRangeX = 5;
        public static int tileRangeY = 4;
        private static int tileTargetX;
        private static int tileTargetY;
        private static int jumpHeight = 15;
        private static float jumpSpeed = 5.01f;
        public bool adjWater;
        public bool oldAdjWater;
        public bool[] adjTile = new bool[150];
        public bool[] oldAdjTile = new bool[150];
        private static int itemGrabRange = 38;
        private static float itemGrabSpeed = 0.45f;
        private static float itemGrabSpeedMax = 4f;
        public Color hairColor = new Color(215, 90, 55);
        public Color skinColor = new Color(255, 125, 90);
        public Color eyeColor = new Color(105, 90, 75);
        public Color shirtColor = new Color(175, 165, 140);
        public Color underShirtColor = new Color(160, 180, 215);
        public Color pantsColor = new Color(255, 230, 175);
        public Color shoeColor = new Color(160, 105, 60);
        public int hair;
        public bool hostile;
        public int accCompass;
        public int accWatch;
        public int accDepthMeter;
        public bool accDivingHelm;
        public bool accFlipper;
        public bool doubleJump;
        public bool jumpAgain;
        public bool spawnMax;
        public int blockRange;
        public int[] grappling = new int[20];
        public int grapCount;
        public int rocketTime;
        public int rocketTimeMax = 7;
        public int rocketDelay;
        public int rocketDelay2;
        public bool rocketRelease;
        public bool rocketFrame;
        public int rocketBoots;
        public bool canRocket;
        public bool jumpBoost;
        public bool noFallDmg;
        public int swimTime;
        public bool killGuide;
        public bool lavaImmune;
        public bool gills;
        public bool slowFall;
        public bool findTreasure;
        public bool invis;
        public bool detectCreature;
        public bool nightVision;
        public bool enemySpawns;
        public bool thorns;
        public bool waterWalk;
        public bool gravControl;
        public int chest = -1;
        public int chestX;
        public int chestY;
        public int talkNPC = -1;
        public int fallStart;
        public int slowCount;
        public int potionDelayTime = Item.potionDelay;
        public void HealEffect(int healAmount)
        {
            CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 255, 100, 255), string.Concat(healAmount), false);
            if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
            {
                NetMessage.SendData(35, -1, -1, "", this.whoAmi, (float)healAmount, 0f, 0f, 0);
            }
        }
        public void ManaEffect(int manaAmount)
        {
            CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(100, 100, 255, 255), string.Concat(manaAmount), false);
            if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
            {
                NetMessage.SendData(43, -1, -1, "", this.whoAmi, (float)manaAmount, 0f, 0f, 0);
            }
        }
        public static byte FindClosest(Vector2 Position, int Width, int Height)
        {
            byte result = 0;
            for (int i = 0; i < 255; i++)
            {
                if (Main.player[i].active)
                {
                    result = (byte)i;
                    break;
                }
            }
            float num = -1f;
            for (int j = 0; j < 255; j++)
            {
                if (Main.player[j].active && !Main.player[j].dead && (num == -1f || Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2)) < num))
                {
                    num = Math.Abs(Main.player[j].position.X + (float)(Main.player[j].width / 2) - Position.X + (float)(Width / 2)) + Math.Abs(Main.player[j].position.Y + (float)(Main.player[j].height / 2) - Position.Y + (float)(Height / 2));
                    result = (byte)j;
                }
            }
            return result;
        }
        public void checkArmor()
        {
        }
        public void toggleInv()
        {
            if (this.talkNPC >= 0)
            {
                this.talkNPC = -1;
                Main.npcChatText = "";
                Main.PlaySound(11, -1, -1, 1);
                return;
            }
            if (this.sign >= 0)
            {
                this.sign = -1;
                Main.editSign = false;
                Main.npcChatText = "";
                Main.PlaySound(11, -1, -1, 1);
                return;
            }
            if (!Main.playerInventory)
            {
                Recipe.FindRecipes();
                Main.playerInventory = true;
                Main.PlaySound(10, -1, -1, 1);
                return;
            }
            Main.playerInventory = false;
            Main.PlaySound(11, -1, -1, 1);
        }
        public void dropItemCheck()
        {
            if (!Main.playerInventory)
            {
                this.noThrow = 0;
            }
            if (this.noThrow > 0)
            {
                this.noThrow--;
            }
            if (!Main.craftGuide && Main.guideItem.type > 0)
            {
                int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.guideItem.type, 1, false, 0);
                Main.guideItem.position = Main.item[num].position;
                Main.item[num] = Main.guideItem;
                Main.guideItem = new Item();
                if (Main.netMode == 0)
                {
                    Main.item[num].noGrabDelay = 100;
                }
                Main.item[num].velocity.Y = -2f;
                Main.item[num].velocity.X = (float)(4 * this.direction) + this.velocity.X;
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
                }
            }
            if (!Main.reforge && Main.reforgeItem.type > 0)
            {
                int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, Main.reforgeItem.type, 1, false, 0);
                Main.reforgeItem.position = Main.item[num2].position;
                Main.item[num2] = Main.reforgeItem;
                Main.reforgeItem = new Item();
                if (Main.netMode == 0)
                {
                    Main.item[num2].noGrabDelay = 100;
                }
                Main.item[num2].velocity.Y = -2f;
                Main.item[num2].velocity.X = (float)(4 * this.direction) + this.velocity.X;
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
                }
            }
            if (Main.myPlayer == this.whoAmi)
            {
                this.inventory[48] = (Item)Main.mouseItem.Clone();
            }
            bool flag = true;
            if (Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
            {
                Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
                Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
                if (this.selectedItem != 48)
                {
                    this.oldSelectItem = this.selectedItem;
                }
                this.selectedItem = 48;
                flag = false;
            }
            if (flag && this.selectedItem == 48)
            {
                this.selectedItem = this.oldSelectItem;
            }
            if (((this.controlThrow && this.releaseThrow && this.inventory[this.selectedItem].type > 0 && !Main.chatMode) || (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)) && this.noThrow <= 0)
            {
                Item item = new Item();
                bool flag2 = false;
                if (((Main.mouseRight && !this.mouseInterface && Main.mouseRightRelease) || !Main.playerInventory) && Main.mouseItem.type > 0 && Main.mouseItem.stack > 0)
                {
                    item = this.inventory[this.selectedItem];
                    this.inventory[this.selectedItem] = Main.mouseItem;
                    this.delayUseItem = true;
                    this.controlUseItem = false;
                    flag2 = true;
                }
                int num3 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[this.selectedItem].type, 1, false, 0);
                if (!flag2 && this.inventory[this.selectedItem].type == 8 && this.inventory[this.selectedItem].stack > 1)
                {
                    this.inventory[this.selectedItem].stack--;
                }
                else
                {
                    this.inventory[this.selectedItem].position = Main.item[num3].position;
                    Main.item[num3] = this.inventory[this.selectedItem];
                    this.inventory[this.selectedItem] = new Item();
                }
                if (Main.netMode == 0)
                {
                    Main.item[num3].noGrabDelay = 100;
                }
                Main.item[num3].velocity.Y = -2f;
                Main.item[num3].velocity.X = (float)(4 * this.direction) + this.velocity.X;
                if (((Main.mouseRight && !this.mouseInterface) || !Main.playerInventory) && Main.mouseItem.type > 0)
                {
                    this.inventory[this.selectedItem] = item;
                    Main.mouseItem = new Item();
                }
                else
                {
                    this.itemAnimation = 10;
                    this.itemAnimationMax = 10;
                }
                Recipe.FindRecipes();
                if (Main.netMode == 1)
                {
                    NetMessage.SendData(21, -1, -1, "", num3, 0f, 0f, 0f, 0);
                }
            }
        }
        public void AddBuff(int type, int time, bool quiet = true)
        {
            if (!quiet && Main.netMode == 1)
            {
                NetMessage.SendData(55, -1, -1, "", this.whoAmi, (float)type, (float)time, 0f, 0);
            }
            int num = -1;
            for (int i = 0; i < 10; i++)
            {
                if (this.buffType[i] == type)
                {
                    if (this.buffTime[i] < time)
                    {
                        this.buffTime[i] = time;
                    }
                    return;
                }
            }
            while (num == -1)
            {
                int num2 = -1;
                for (int j = 0; j < 10; j++)
                {
                    if (!Main.debuff[this.buffType[j]])
                    {
                        num2 = j;
                        break;
                    }
                }
                if (num2 == -1)
                {
                    return;
                }
                for (int k = num2; k < 10; k++)
                {
                    if (this.buffType[k] == 0)
                    {
                        num = k;
                        break;
                    }
                }
                if (num == -1)
                {
                    this.DelBuff(num2);
                }
            }
            this.buffType[num] = type;
            this.buffTime[num] = time;
        }
        public void DelBuff(int b)
        {
            this.buffTime[b] = 0;
            this.buffType[b] = 0;
            for (int i = 0; i < 9; i++)
            {
                if (this.buffTime[i] == 0 || this.buffType[i] == 0)
                {
                    for (int j = i + 1; j < 10; j++)
                    {
                        this.buffTime[j - 1] = this.buffTime[j];
                        this.buffType[j - 1] = this.buffType[j];
                        this.buffTime[j] = 0;
                        this.buffType[j] = 0;
                    }
                }
            }
        }
        public void QuickHeal()
        {
            if (this.noItems)
            {
                return;
            }
            if (this.statLife == this.statLifeMax || this.potionDelay > 0)
            {
                return;
            }
            for (int i = 0; i < 48; i++)
            {
                if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].potion && this.inventory[i].healLife > 0)
                {
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
                    if (this.inventory[i].potion)
                    {
                        this.potionDelay = this.potionDelayTime;
                        this.AddBuff(21, this.potionDelay, true);
                    }
                    this.statLife += this.inventory[i].healLife;
                    this.statMana += this.inventory[i].healMana;
                    if (this.statLife > this.statLifeMax)
                    {
                        this.statLife = this.statLifeMax;
                    }
                    if (this.statMana > this.statManaMax2)
                    {
                        this.statMana = this.statManaMax2;
                    }
                    if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(this.inventory[i].healLife);
                    }
                    if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(this.inventory[i].healMana);
                    }
                    this.inventory[i].stack--;
                    if (this.inventory[i].stack <= 0)
                    {
                        this.inventory[i].type = 0;
                        this.inventory[i].name = "";
                    }
                    Recipe.FindRecipes();
                    return;
                }
            }
        }
        public void QuickMana()
        {
            if (this.noItems)
            {
                return;
            }
            if (this.statMana == this.statManaMax2)
            {
                return;
            }
            for (int i = 0; i < 48; i++)
            {
                if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].healMana > 0 && (this.potionDelay == 0 || !this.inventory[i].potion))
                {
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[i].useSound);
                    if (this.inventory[i].potion)
                    {
                        this.potionDelay = this.potionDelayTime;
                        this.AddBuff(21, this.potionDelay, true);
                    }
                    this.statLife += this.inventory[i].healLife;
                    this.statMana += this.inventory[i].healMana;
                    if (this.statLife > this.statLifeMax)
                    {
                        this.statLife = this.statLifeMax;
                    }
                    if (this.statMana > this.statManaMax2)
                    {
                        this.statMana = this.statManaMax2;
                    }
                    if (this.inventory[i].healLife > 0 && Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(this.inventory[i].healLife);
                    }
                    if (this.inventory[i].healMana > 0 && Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(this.inventory[i].healMana);
                    }
                    this.inventory[i].stack--;
                    if (this.inventory[i].stack <= 0)
                    {
                        this.inventory[i].type = 0;
                        this.inventory[i].name = "";
                    }
                    Recipe.FindRecipes();
                    return;
                }
            }
        }
        public int countBuffs()
        {
            int num = 0;
            for (int i = 0; i < 10; i++)
            {
                if (this.buffType[num] > 0)
                {
                    num++;
                }
            }
            return num;
        }
        public void QuickBuff()
        {
            if (this.noItems)
            {
                return;
            }
            int num = 0;
            for (int i = 0; i < 48; i++)
            {
                if (this.countBuffs() == 10)
                {
                    return;
                }
                if (this.inventory[i].stack > 0 && this.inventory[i].type > 0 && this.inventory[i].buffType > 0)
                {
                    bool flag = true;
                    for (int j = 0; j < 10; j++)
                    {
                        if (this.buffType[j] == this.inventory[i].buffType)
                        {
                            flag = false;
                            break;
                        }
                    }
                    if (this.inventory[i].mana > 0 && flag)
                    {
                        if (this.statMana >= (int)((float)this.inventory[i].mana * this.manaCost))
                        {
                            this.manaRegenDelay = (int)this.maxRegenDelay;
                            this.statMana -= (int)((float)this.inventory[i].mana * this.manaCost);
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    if (this.whoAmi == Main.myPlayer && this.inventory[i].type == 603 && !Main.cEd)
                    {
                        flag = false;
                    }
                    if (flag)
                    {
                        num = this.inventory[i].useSound;
                        int num2 = this.inventory[i].buffTime;
                        if (num2 == 0)
                        {
                            num2 = 3600;
                        }
                        this.AddBuff(this.inventory[i].buffType, num2, true);
                        if (this.inventory[i].consumable)
                        {
                            this.inventory[i].stack--;
                            if (this.inventory[i].stack <= 0)
                            {
                                this.inventory[i].type = 0;
                                this.inventory[i].name = "";
                            }
                        }
                    }
                }
            }
            if (num > 0)
            {
                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, num);
                Recipe.FindRecipes();
            }
        }
        public void StatusNPC(int type, int i)
        {
            if (type == 121)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.npc[i].AddBuff(24, 180, false);
                    return;
                }
            }
            else
            {
                if (type == 122)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Main.npc[i].AddBuff(24, 180, false);
                        return;
                    }
                }
                else
                {
                    if (type == 190)
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            Main.npc[i].AddBuff(20, 420, false);
                            return;
                        }
                    }
                    else
                    {
                        if (type == 217 && Main.rand.Next(5) == 0)
                        {
                            Main.npc[i].AddBuff(24, 180, false);
                        }
                    }
                }
            }
        }
        public void StatusPvP(int type, int i)
        {
            if (type == 121)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Main.player[i].AddBuff(24, 180, false);
                    return;
                }
            }
            else
            {
                if (type == 122)
                {
                    if (Main.rand.Next(10) == 0)
                    {
                        Main.player[i].AddBuff(24, 180, false);
                        return;
                    }
                }
                else
                {
                    if (type == 190)
                    {
                        if (Main.rand.Next(4) == 0)
                        {
                            Main.player[i].AddBuff(20, 420, false);
                            return;
                        }
                    }
                    else
                    {
                        if (type == 217 && Main.rand.Next(5) == 0)
                        {
                            Main.player[i].AddBuff(24, 180, false);
                        }
                    }
                }
            }
        }
        public void Ghost()
        {
            this.immune = false;
            this.immuneAlpha = 0;
            this.controlUp = false;
            this.controlLeft = false;
            this.controlDown = false;
            this.controlRight = false;
            this.controlJump = false;
            if (Main.hasFocus && !Main.chatMode && !Main.editSign)
            {
                Keys[] pressedKeys = Main.keyState.GetPressedKeys();
                for (int i = 0; i < pressedKeys.Length; i++)
                {
                    string a = string.Concat(pressedKeys[i]);
                    if (a == Main.cUp)
                    {
                        this.controlUp = true;
                    }
                    if (a == Main.cLeft)
                    {
                        this.controlLeft = true;
                    }
                    if (a == Main.cDown)
                    {
                        this.controlDown = true;
                    }
                    if (a == Main.cRight)
                    {
                        this.controlRight = true;
                    }
                    if (a == Main.cJump)
                    {
                        this.controlJump = true;
                    }
                }
            }
            if (this.controlUp || this.controlJump)
            {
                if (this.velocity.Y > 0f)
                {
                    this.velocity.Y = this.velocity.Y * 0.9f;
                }
                this.velocity.Y = this.velocity.Y - 0.1f;
                if (this.velocity.Y < -3f)
                {
                    this.velocity.Y = -3f;
                }
            }
            else
            {
                if (this.controlDown)
                {
                    if (this.velocity.Y < 0f)
                    {
                        this.velocity.Y = this.velocity.Y * 0.9f;
                    }
                    this.velocity.Y = this.velocity.Y + 0.1f;
                    if (this.velocity.Y > 3f)
                    {
                        this.velocity.Y = 3f;
                    }
                }
                else
                {
                    if ((double)this.velocity.Y < -0.1 || (double)this.velocity.Y > 0.1)
                    {
                        this.velocity.Y = this.velocity.Y * 0.9f;
                    }
                    else
                    {
                        this.velocity.Y = 0f;
                    }
                }
            }
            if (this.controlLeft && !this.controlRight)
            {
                if (this.velocity.X > 0f)
                {
                    this.velocity.X = this.velocity.X * 0.9f;
                }
                this.velocity.X = this.velocity.X - 0.1f;
                if (this.velocity.X < -3f)
                {
                    this.velocity.X = -3f;
                }
            }
            else
            {
                if (this.controlRight && !this.controlLeft)
                {
                    if (this.velocity.X < 0f)
                    {
                        this.velocity.X = this.velocity.X * 0.9f;
                    }
                    this.velocity.X = this.velocity.X + 0.1f;
                    if (this.velocity.X > 3f)
                    {
                        this.velocity.X = 3f;
                    }
                }
                else
                {
                    if ((double)this.velocity.X < -0.1 || (double)this.velocity.X > 0.1)
                    {
                        this.velocity.X = this.velocity.X * 0.9f;
                    }
                    else
                    {
                        this.velocity.X = 0f;
                    }
                }
            }
            this.position += this.velocity;
            this.ghostFrameCounter++;
            if (this.velocity.X < 0f)
            {
                this.direction = -1;
            }
            else
            {
                if (this.velocity.X > 0f)
                {
                    this.direction = 1;
                }
            }
            if (this.ghostFrameCounter >= 8)
            {
                this.ghostFrameCounter = 0;
                this.ghostFrame++;
                if (this.ghostFrame >= 4)
                {
                    this.ghostFrame = 0;
                }
            }
            if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
            {
                this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
                this.velocity.X = 0f;
            }
            if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
            {
                this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
                this.velocity.X = 0f;
            }
            if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
            {
                this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
                if ((double)this.velocity.Y < -0.1)
                {
                    this.velocity.Y = -0.1f;
                }
            }
            if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
            {
                this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
                this.velocity.Y = 0f;
            }
        }
        public void UpdatePlayer(int i)
        {
            float num = 10f;
            float num2 = 0.4f;
            Player.jumpHeight = 15;
            Player.jumpSpeed = 5.01f;
            if (this.wet)
            {
                if (this.merman)
                {
                    num2 = 0.3f;
                    num = 7f;
                }
                else
                {
                    num2 = 0.2f;
                    num = 5f;
                    Player.jumpHeight = 30;
                    Player.jumpSpeed = 6.01f;
                }
            }
            float num3 = 3f;
            float num4 = 0.08f;
            float num5 = 0.2f;
            float num6 = num3;
            this.heldProj = -1;
            if (this.active)
            {
                float num7 = (float)(Main.maxTilesX / 4200);
                num7 *= num7;
                float num8 = (float)((double)(this.position.Y / 16f - (60f + 10f * num7)) / (Main.worldSurface / 6.0));
                if ((double)num8 < 0.25)
                {
                    num8 = 0.25f;
                }
                if (num8 > 1f)
                {
                    num8 = 1f;
                }
                num2 *= num8;
                this.maxRegenDelay = (1f - (float)this.statMana / (float)this.statManaMax2) * 60f * 4f + 45f;
                this.shadowCount++;
                if (this.shadowCount == 1)
                {
                    this.shadowPos[2] = this.shadowPos[1];
                }
                else
                {
                    if (this.shadowCount == 2)
                    {
                        this.shadowPos[1] = this.shadowPos[0];
                    }
                    else
                    {
                        if (this.shadowCount >= 3)
                        {
                            this.shadowCount = 0;
                            this.shadowPos[0] = this.position;
                        }
                    }
                }
                this.whoAmi = i;
                if (this.runSoundDelay > 0)
                {
                    this.runSoundDelay--;
                }
                if (this.attackCD > 0)
                {
                    this.attackCD--;
                }
                if (this.itemAnimation == 0)
                {
                    this.attackCD = 0;
                }
                if (this.chatShowTime > 0)
                {
                    this.chatShowTime--;
                }
                if (this.potionDelay > 0)
                {
                    this.potionDelay--;
                }
                if (i == Main.myPlayer)
                {
                    this.zoneEvil = false;
                    if (Main.evilTiles >= 200)
                    {
                        this.zoneEvil = true;
                    }
                    this.zoneHoly = false;
                    if (Main.holyTiles >= 100)
                    {
                        this.zoneHoly = true;
                    }
                    this.zoneMeteor = false;
                    if (Main.meteorTiles >= 50)
                    {
                        this.zoneMeteor = true;
                    }
                    this.zoneDungeon = false;
                    if (Main.dungeonTiles >= 250 && (double)this.position.Y > Main.worldSurface * 16.0)
                    {
                        int num9 = (int)this.position.X / 16;
                        int num10 = (int)this.position.Y / 16;
                        if (Main.tile[num9, num10].wall > 0 && !Main.wallHouse[(int)Main.tile[num9, num10].wall])
                        {
                            this.zoneDungeon = true;
                        }
                    }
                    this.zoneJungle = false;
                    if (Main.jungleTiles >= 80)
                    {
                        this.zoneJungle = true;
                    }
                }
                if (this.ghost)
                {
                    this.Ghost();
                    return;
                }
                if (!this.dead)
                {
                    if (i == Main.myPlayer)
                    {
                        this.controlUp = false;
                        this.controlLeft = false;
                        this.controlDown = false;
                        this.controlRight = false;
                        this.controlJump = false;
                        this.controlUseItem = false;
                        this.controlUseTile = false;
                        this.controlThrow = false;
                        this.controlInv = false;
                        this.controlHook = false;
                        this.controlTorch = false;
                        if (Main.hasFocus)
                        {
                            if (!Main.chatMode && !Main.editSign)
                            {
                                Keys[] pressedKeys = Main.keyState.GetPressedKeys();
                                bool flag = false;
                                bool flag2 = false;
                                for (int j = 0; j < pressedKeys.Length; j++)
                                {
                                    string a = string.Concat(pressedKeys[j]);
                                    if (a == Main.cUp)
                                    {
                                        this.controlUp = true;
                                    }
                                    if (a == Main.cLeft)
                                    {
                                        this.controlLeft = true;
                                    }
                                    if (a == Main.cDown)
                                    {
                                        this.controlDown = true;
                                    }
                                    if (a == Main.cRight)
                                    {
                                        this.controlRight = true;
                                    }
                                    if (a == Main.cJump)
                                    {
                                        this.controlJump = true;
                                    }
                                    if (a == Main.cThrowItem)
                                    {
                                        this.controlThrow = true;
                                    }
                                    if (a == Main.cInv)
                                    {
                                        this.controlInv = true;
                                    }
                                    if (a == Main.cBuff)
                                    {
                                        this.QuickBuff();
                                    }
                                    if (a == Main.cHeal)
                                    {
                                        flag2 = true;
                                    }
                                    if (a == Main.cMana)
                                    {
                                        flag = true;
                                    }
                                    if (a == Main.cHook)
                                    {
                                        this.controlHook = true;
                                    }
                                    if (a == Main.cTorch)
                                    {
                                        this.controlTorch = true;
                                    }
                                }
                                if (Main.gamePad)
                                {
                                    GamePadState state = GamePad.GetState(PlayerIndex.One);
                                    GamePadDPad dPad = state.DPad;
                                    if (dPad.Up == ButtonState.Pressed)
                                    {
                                        this.controlUp = true;
                                    }
                                    dPad = state.DPad;
                                    if (dPad.Down == ButtonState.Pressed)
                                    {
                                        this.controlDown = true;
                                    }
                                    dPad = state.DPad;
                                    if (dPad.Left == ButtonState.Pressed)
                                    {
                                        this.controlLeft = true;
                                    }
                                    dPad = state.DPad;
                                    if (dPad.Right == ButtonState.Pressed)
                                    {
                                        this.controlRight = true;
                                    }
                                    GamePadTriggers triggers = state.Triggers;
                                    if (triggers.Left > 0f)
                                    {
                                        this.controlJump = true;
                                    }
                                    triggers = state.Triggers;
                                    if (triggers.Right > 0f)
                                    {
                                        this.controlUseItem = true;
                                    }
                                    float arg_846_0 = (float)(Main.screenWidth / 2);
                                    GamePadThumbSticks thumbSticks = state.ThumbSticks;
                                    Main.mouseX = (int)(arg_846_0 + thumbSticks.Right.X * (float)Player.tileRangeX * 16f);
                                    float arg_877_0 = (float)(Main.screenHeight / 2);
                                    thumbSticks = state.ThumbSticks;
                                    Main.mouseY = (int)(arg_877_0 - thumbSticks.Right.Y * (float)Player.tileRangeX * 16f);
                                    thumbSticks = state.ThumbSticks;
                                    if (thumbSticks.Right.X == 0f)
                                    {
                                        Main.mouseX = Main.screenWidth / 2 + this.direction * 2;
                                    }
                                }
                                if (flag2)
                                {
                                    if (this.releaseQuickHeal)
                                    {
                                        this.QuickHeal();
                                    }
                                    this.releaseQuickHeal = false;
                                }
                                else
                                {
                                    this.releaseQuickHeal = true;
                                }
                                if (flag)
                                {
                                    if (this.releaseQuickMana)
                                    {
                                        this.QuickMana();
                                    }
                                    this.releaseQuickMana = false;
                                }
                                else
                                {
                                    this.releaseQuickMana = true;
                                }
                                if (this.controlLeft && this.controlRight)
                                {
                                    this.controlLeft = false;
                                    this.controlRight = false;
                                }
                            }
                            if (this.confused)
                            {
                                bool flag3 = this.controlLeft;
                                bool flag4 = this.controlUp;
                                this.controlLeft = this.controlRight;
                                this.controlRight = flag3;
                                this.controlUp = this.controlRight;
                                this.controlDown = flag4;
                            }
                            if (Main.mouseLeft && !this.mouseInterface)
                            {
                                this.controlUseItem = true;
                            }
                            if (Main.mouseRight && !this.mouseInterface)
                            {
                                this.controlUseTile = true;
                            }
                            if (this.controlInv)
                            {
                                if (this.releaseInventory)
                                {
                                    this.toggleInv();
                                }
                                this.releaseInventory = false;
                            }
                            else
                            {
                                this.releaseInventory = true;
                            }
                            if (this.delayUseItem)
                            {
                                if (!this.controlUseItem)
                                {
                                    this.delayUseItem = false;
                                }
                                this.controlUseItem = false;
                            }
                            if (this.itemAnimation == 0 && this.itemTime == 0)
                            {
                                this.dropItemCheck();
                                int num11 = this.selectedItem;
                                if (!Main.chatMode && this.selectedItem != 48)
                                {
                                    if (Main.keyState.IsKeyDown(Keys.D1))
                                    {
                                        this.selectedItem = 0;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D2))
                                    {
                                        this.selectedItem = 1;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D3))
                                    {
                                        this.selectedItem = 2;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D4))
                                    {
                                        this.selectedItem = 3;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D5))
                                    {
                                        this.selectedItem = 4;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D6))
                                    {
                                        this.selectedItem = 5;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D7))
                                    {
                                        this.selectedItem = 6;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D8))
                                    {
                                        this.selectedItem = 7;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D9))
                                    {
                                        this.selectedItem = 8;
                                    }
                                    if (Main.keyState.IsKeyDown(Keys.D0))
                                    {
                                        this.selectedItem = 9;
                                    }
                                }
                                if (num11 != this.selectedItem)
                                {
                                    Main.PlaySound(12, -1, -1, 1);
                                }
                                if (!Main.playerInventory)
                                {
                                    int k;
                                    for (k = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120; k > 9; k -= 10)
                                    {
                                    }
                                    while (k < 0)
                                    {
                                        k += 10;
                                    }
                                    this.selectedItem -= k;
                                    if (k != 0)
                                    {
                                        Main.PlaySound(12, -1, -1, 1);
                                    }
                                    if (this.changeItem >= 0)
                                    {
                                        if (this.selectedItem != this.changeItem)
                                        {
                                            Main.PlaySound(12, -1, -1, 1);
                                        }
                                        this.selectedItem = this.changeItem;
                                        this.changeItem = -1;
                                    }
                                    while (this.selectedItem > 9)
                                    {
                                        this.selectedItem -= 10;
                                    }
                                    while (this.selectedItem < 0)
                                    {
                                        this.selectedItem += 10;
                                    }
                                }
                                else
                                {
                                    int num12 = (Main.mouseState.ScrollWheelValue - Main.oldMouseState.ScrollWheelValue) / 120;
                                    Main.focusRecipe += num12;
                                    if (Main.focusRecipe > Main.numAvailableRecipes - 1)
                                    {
                                        Main.focusRecipe = Main.numAvailableRecipes - 1;
                                    }
                                    if (Main.focusRecipe < 0)
                                    {
                                        Main.focusRecipe = 0;
                                    }
                                }
                            }
                        }
                        if (this.selectedItem == 48)
                        {
                            this.nonTorch = -1;
                        }
                        else
                        {
                            if (this.controlTorch && this.itemAnimation == 0)
                            {
                                int num13 = 0;
                                int num14 = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
                                int num15 = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
                                if (this.position.X / 16f - (float)Player.tileRangeX <= (float)num14 && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)num14 && this.position.Y / 16f - (float)Player.tileRangeY <= (float)num15 && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)num15)
                                {
                                    try
                                    {
                                        if (Main.tile[num14, num15].active)
                                        {
                                            int type = (int)Main.tile[num14, num15].type;
                                            if (Main.tileHammer[type])
                                            {
                                                num13 = 1;
                                            }
                                            else
                                            {
                                                if (Main.tileAxe[type])
                                                {
                                                    num13 = 2;
                                                }
                                                else
                                                {
                                                    num13 = 3;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (Main.tile[num14, num15].liquid > 0 && this.wet)
                                            {
                                                num13 = 4;
                                            }
                                        }
                                        goto IL_D75;
                                    }
                                    catch
                                    {
                                        goto IL_D75;
                                    }
                                }
                                if (this.wet)
                                {
                                    num13 = 4;
                                }
                            IL_D75:
                                if (num13 == 0)
                                {
                                    float num16 = Math.Abs((float)Main.mouseX + Main.screenPosition.X - (this.position.X + (float)(this.width / 2)));
                                    float num17 = Math.Abs((float)Main.mouseY + Main.screenPosition.Y - (this.position.Y + (float)(this.height / 2))) * 1.3f;
                                    float num18 = (float)Math.Sqrt((double)(num16 * num16 + num17 * num17));
                                    if (num18 > 200f)
                                    {
                                        num13 = 5;
                                    }
                                }
                                for (int l = 0; l < 40; l++)
                                {
                                    int type2 = this.inventory[l].type;
                                    if (num13 == 0)
                                    {
                                        if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523)
                                        {
                                            if (this.nonTorch == -1)
                                            {
                                                this.nonTorch = this.selectedItem;
                                            }
                                            this.selectedItem = l;
                                            break;
                                        }
                                        if (type2 == 282 || type2 == 286)
                                        {
                                            if (this.nonTorch == -1)
                                            {
                                                this.nonTorch = this.selectedItem;
                                            }
                                            this.selectedItem = l;
                                        }
                                    }
                                    else
                                    {
                                        if (num13 == 1)
                                        {
                                            if (this.inventory[l].hammer > 0)
                                            {
                                                if (this.nonTorch == -1)
                                                {
                                                    this.nonTorch = this.selectedItem;
                                                }
                                                this.selectedItem = l;
                                                break;
                                            }
                                        }
                                        else
                                        {
                                            if (num13 == 2)
                                            {
                                                if (this.inventory[l].axe > 0)
                                                {
                                                    if (this.nonTorch == -1)
                                                    {
                                                        this.nonTorch = this.selectedItem;
                                                    }
                                                    this.selectedItem = l;
                                                    break;
                                                }
                                            }
                                            else
                                            {
                                                if (num13 == 3)
                                                {
                                                    if (this.inventory[l].pick > 0)
                                                    {
                                                        if (this.nonTorch == -1)
                                                        {
                                                            this.nonTorch = this.selectedItem;
                                                        }
                                                        this.selectedItem = l;
                                                        break;
                                                    }
                                                }
                                                else
                                                {
                                                    if (num13 == 4)
                                                    {
                                                        if (type2 == 282 || type2 == 286 || type2 == 523)
                                                        {
                                                            if (this.nonTorch == -1)
                                                            {
                                                                this.nonTorch = this.selectedItem;
                                                            }
                                                            this.selectedItem = l;
                                                            break;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (num13 == 5)
                                                        {
                                                            if (type2 == 8 || type2 == 427 || type2 == 428 || type2 == 429 || type2 == 430 || type2 == 431 || type2 == 432 || type2 == 433 || type2 == 523)
                                                            {
                                                                if (this.nonTorch == -1)
                                                                {
                                                                    this.nonTorch = this.selectedItem;
                                                                }
                                                                this.selectedItem = l;
                                                            }
                                                            else
                                                            {
                                                                if (type2 == 282 || type2 == 286)
                                                                {
                                                                    if (this.nonTorch == -1)
                                                                    {
                                                                        this.nonTorch = this.selectedItem;
                                                                    }
                                                                    this.selectedItem = l;
                                                                    break;
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
                            else
                            {
                                if (this.nonTorch > -1 && this.itemAnimation == 0)
                                {
                                    this.selectedItem = this.nonTorch;
                                    this.nonTorch = -1;
                                }
                            }
                        }
                        if (!this.controlThrow)
                        {
                            this.releaseThrow = true;
                        }
                        else
                        {
                            this.releaseThrow = false;
                        }
                        if (Main.netMode == 1)
                        {
                            bool flag5 = false;
                            if (this.statLife != Main.clientPlayer.statLife || this.statLifeMax != Main.clientPlayer.statLifeMax)
                            {
                                NetMessage.SendData(16, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                                flag5 = true;
                            }
                            if (this.statMana != Main.clientPlayer.statMana || this.statManaMax != Main.clientPlayer.statManaMax)
                            {
                                NetMessage.SendData(42, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                                flag5 = true;
                            }
                            if (this.controlUp != Main.clientPlayer.controlUp)
                            {
                                flag5 = true;
                            }
                            if (this.controlDown != Main.clientPlayer.controlDown)
                            {
                                flag5 = true;
                            }
                            if (this.controlLeft != Main.clientPlayer.controlLeft)
                            {
                                flag5 = true;
                            }
                            if (this.controlRight != Main.clientPlayer.controlRight)
                            {
                                flag5 = true;
                            }
                            if (this.controlJump != Main.clientPlayer.controlJump)
                            {
                                flag5 = true;
                            }
                            if (this.controlUseItem != Main.clientPlayer.controlUseItem)
                            {
                                flag5 = true;
                            }
                            if (this.selectedItem != Main.clientPlayer.selectedItem)
                            {
                                flag5 = true;
                            }
                            if (flag5)
                            {
                                NetMessage.SendData(13, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                            }
                        }
                        if (Main.playerInventory)
                        {
                            this.AdjTiles();
                        }
                        if (this.chest != -1)
                        {
                            int num19 = (int)(((double)this.position.X + (double)this.width * 0.5) / 16.0);
                            int num20 = (int)(((double)this.position.Y + (double)this.height * 0.5) / 16.0);
                            if (num19 < this.chestX - 5 || num19 > this.chestX + 6 || num20 < this.chestY - 4 || num20 > this.chestY + 5)
                            {
                                if (this.chest != -1)
                                {
                                    Main.PlaySound(11, -1, -1, 1);
                                }
                                this.chest = -1;
                            }
                            if (!Main.tile[this.chestX, this.chestY].active)
                            {
                                Main.PlaySound(11, -1, -1, 1);
                                this.chest = -1;
                            }
                        }
                        if (this.velocity.Y == 0f)
                        {
                            int num21 = (int)(this.position.Y / 16f) - this.fallStart;
                            if (((this.gravDir == 1f && num21 > 25) || (this.gravDir == -1f && num21 < -25)) && !this.noFallDmg && this.wings == 0)
                            {
                                int damage = (int)((float)num21 * this.gravDir - 25f) * 10;
                                this.immune = false;
                                this.Hurt(damage, 0, false, false, Lang.deathMsg(-1, -1, -1, 0), false);
                            }
                            this.fallStart = (int)(this.position.Y / 16f);
                        }
                        if (this.jump > 0 || this.rocketDelay > 0 || this.wet || this.slowFall || (double)num8 < 0.8 || this.tongued)
                        {
                            this.fallStart = (int)(this.position.Y / 16f);
                        }
                    }
                    if (this.mouseInterface)
                    {
                        this.delayUseItem = true;
                    }
                    Player.tileTargetX = (int)(((float)Main.mouseX + Main.screenPosition.X) / 16f);
                    Player.tileTargetY = (int)(((float)Main.mouseY + Main.screenPosition.Y) / 16f);
                    if (this.immune)
                    {
                        this.immuneTime--;
                        if (this.immuneTime <= 0)
                        {
                            this.immune = false;
                        }
                        this.immuneAlpha += this.immuneAlphaDirection * 50;
                        if (this.immuneAlpha <= 50)
                        {
                            this.immuneAlphaDirection = 1;
                        }
                        else
                        {
                            if (this.immuneAlpha >= 205)
                            {
                                this.immuneAlphaDirection = -1;
                            }
                        }
                    }
                    else
                    {
                        this.immuneAlpha = 0;
                    }
                    this.potionDelayTime = Item.potionDelay;
                    if (this.pStone)
                    {
                        this.potionDelayTime -= 900;
                    }
                    this.statDefense = 0;
                    this.accWatch = 0;
                    this.accCompass = 0;
                    this.accDepthMeter = 0;
                    this.accDivingHelm = false;
                    this.lifeRegen = 0;
                    this.manaCost = 1f;
                    this.meleeSpeed = 1f;
                    this.meleeDamage = 1f;
                    this.rangedDamage = 1f;
                    this.magicDamage = 1f;
                    this.moveSpeed = 1f;
                    this.boneArmor = false;
                    this.rocketBoots = 0;
                    this.fireWalk = false;
                    this.noKnockback = false;
                    this.jumpBoost = false;
                    this.noFallDmg = false;
                    this.accFlipper = false;
                    this.spawnMax = false;
                    this.spaceGun = false;
                    this.killGuide = false;
                    this.lavaImmune = false;
                    this.gills = false;
                    this.slowFall = false;
                    this.findTreasure = false;
                    this.invis = false;
                    this.nightVision = false;
                    this.enemySpawns = false;
                    this.thorns = false;
                    this.waterWalk = false;
                    this.detectCreature = false;
                    this.gravControl = false;
                    this.statManaMax2 = this.statManaMax;
                    this.ammoCost80 = false;
                    this.ammoCost75 = false;
                    this.manaRegenBuff = false;
                    this.meleeCrit = 4;
                    this.rangedCrit = 4;
                    this.magicCrit = 4;
                    this.lightOrb = false;
                    this.fairy = false;
                    this.bunny = false;
                    this.archery = false;
                    this.poisoned = false;
                    this.blind = false;
                    this.onFire = false;
                    this.onFire2 = false;
                    this.noItems = false;
                    this.blockRange = 0;
                    this.pickSpeed = 1f;
                    this.wereWolf = false;
                    this.rulerAcc = false;
                    this.bleed = false;
                    this.confused = false;
                    this.wings = 0;
                    this.brokenArmor = false;
                    this.silence = false;
                    this.slow = false;
                    this.gross = false;
                    this.tongued = false;
                    this.kbGlove = false;
                    this.starCloak = false;
                    this.longInvince = false;
                    this.pStone = false;
                    this.manaFlower = false;
                    this.meleeCrit += this.inventory[this.selectedItem].crit;
                    this.magicCrit += this.inventory[this.selectedItem].crit;
                    this.rangedCrit += this.inventory[this.selectedItem].crit;
                    if (this.whoAmi == Main.myPlayer)
                    {
                        Main.musicBox2 = -1;
                    }
                    for (int m = 0; m < 10; m++)
                    {
                        if (this.buffType[m] > 0 && this.buffTime[m] > 0)
                        {
                            if (this.whoAmi == Main.myPlayer && this.buffType[m] != 28)
                            {
                                this.buffTime[m]--;
                            }
                            if (this.buffType[m] == 1)
                            {
                                this.lavaImmune = true;
                                this.fireWalk = true;
                            }
                            else
                            {
                                if (this.buffType[m] == 2)
                                {
                                    this.lifeRegen += 2;
                                }
                                else
                                {
                                    if (this.buffType[m] == 3)
                                    {
                                        this.moveSpeed += 0.25f;
                                    }
                                    else
                                    {
                                        if (this.buffType[m] == 4)
                                        {
                                            this.gills = true;
                                        }
                                        else
                                        {
                                            if (this.buffType[m] == 5)
                                            {
                                                this.statDefense += 8;
                                            }
                                            else
                                            {
                                                if (this.buffType[m] == 6)
                                                {
                                                    this.manaRegenBuff = true;
                                                }
                                                else
                                                {
                                                    if (this.buffType[m] == 7)
                                                    {
                                                        this.magicDamage += 0.2f;
                                                    }
                                                    else
                                                    {
                                                        if (this.buffType[m] == 8)
                                                        {
                                                            this.slowFall = true;
                                                        }
                                                        else
                                                        {
                                                            if (this.buffType[m] == 9)
                                                            {
                                                                this.findTreasure = true;
                                                            }
                                                            else
                                                            {
                                                                if (this.buffType[m] == 10)
                                                                {
                                                                    this.invis = true;
                                                                }
                                                                else
                                                                {
                                                                    if (this.buffType[m] == 11)
                                                                    {
                                                                        Lighting.addLight((int)(this.position.X + (float)(this.width / 2)) / 16, (int)(this.position.Y + (float)(this.height / 2)) / 16, 0.8f, 0.95f, 1f);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.buffType[m] == 12)
                                                                        {
                                                                            this.nightVision = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.buffType[m] == 13)
                                                                            {
                                                                                this.enemySpawns = true;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.buffType[m] == 14)
                                                                                {
                                                                                    this.thorns = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.buffType[m] == 15)
                                                                                    {
                                                                                        this.waterWalk = true;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.buffType[m] == 16)
                                                                                        {
                                                                                            this.archery = true;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.buffType[m] == 17)
                                                                                            {
                                                                                                this.detectCreature = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (this.buffType[m] == 18)
                                                                                                {
                                                                                                    this.gravControl = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.buffType[m] == 30 && !Spectre.immunetoDeBuffs)
                                                                                                    {
                                                                                                        this.bleed = true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.buffType[m] == 31 && !Spectre.immunetoDeBuffs)
                                                                                                        {
                                                                                                            this.confused = true;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (this.buffType[m] == 32 && !Spectre.immunetoDeBuffs)
                                                                                                            {
                                                                                                                this.slow = true;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (this.buffType[m] == 35 && !Spectre.immunetoDeBuffs)
                                                                                                                {
                                                                                                                    this.silence = true;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (this.buffType[m] == 36 && !Spectre.immunetoDeBuffs)
                                                                                                                    {
                                                                                                                        this.brokenArmor = true;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (this.buffType[m] == 37)
                                                                                                                        {
                                                                                                                            if (Main.wof >= 0 && Main.npc[Main.wof].type == 113)
                                                                                                                            {
                                                                                                                                this.gross = true;
                                                                                                                                this.buffTime[m] = 10;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                this.DelBuff(m);
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (this.buffType[m] == 38)
                                                                                                                            {
                                                                                                                                this.buffTime[m] = 10;
                                                                                                                                this.tongued = true;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (this.buffType[m] == 19)
                                                                                                                                {
                                                                                                                                    this.lightOrb = true;
                                                                                                                                    bool flag6 = true;
                                                                                                                                    for (int n = 0; n < 1000; n++)
                                                                                                                                    {
                                                                                                                                        if (Main.projectile[n].active && Main.projectile[n].owner == this.whoAmi && Main.projectile[n].type == 18)
                                                                                                                                        {
                                                                                                                                            flag6 = false;
                                                                                                                                            break;
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    if (flag6)
                                                                                                                                    {
                                                                                                                                        Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 18, 0, 0f, this.whoAmi);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (this.buffType[m] == 27)
                                                                                                                                    {
                                                                                                                                        this.fairy = true;
                                                                                                                                        bool flag7 = true;
                                                                                                                                        for (int num22 = 0; num22 < 1000; num22++)
                                                                                                                                        {
                                                                                                                                            if (Main.projectile[num22].active && Main.projectile[num22].owner == this.whoAmi && (Main.projectile[num22].type == 72 || Main.projectile[num22].type == 86 || Main.projectile[num22].type == 87))
                                                                                                                                            {
                                                                                                                                                flag7 = false;
                                                                                                                                                break;
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        if (flag7)
                                                                                                                                        {
                                                                                                                                            int num23 = Main.rand.Next(3);
                                                                                                                                            if (num23 == 0)
                                                                                                                                            {
                                                                                                                                                num23 = 72;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (num23 == 1)
                                                                                                                                                {
                                                                                                                                                    num23 = 86;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (num23 == 2)
                                                                                                                                                    {
                                                                                                                                                        num23 = 87;
                                                                                                                                                    }
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                            Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, num23, 0, 0f, this.whoAmi);
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (this.buffType[m] == 40)
                                                                                                                                        {
                                                                                                                                            this.buffTime[m] = 18000;
                                                                                                                                            this.bunny = true;
                                                                                                                                            bool flag8 = true;
                                                                                                                                            for (int num24 = 0; num24 < 1000; num24++)
                                                                                                                                            {
                                                                                                                                                if (Main.projectile[num24].active && Main.projectile[num24].owner == this.whoAmi && Main.projectile[num24].type == 111)
                                                                                                                                                {
                                                                                                                                                    flag8 = false;
                                                                                                                                                    break;
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                            if (flag8)
                                                                                                                                            {
                                                                                                                                                Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.height / 2), 0f, 0f, 111, 0, 0f, this.whoAmi);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (this.buffType[m] == 20 && !Spectre.immunetoDeBuffs)
                                                                                                                                            {
                                                                                                                                                this.poisoned = true;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (this.buffType[m] == 21 && !Spectre.immunetoDeBuffs)
                                                                                                                                                {
                                                                                                                                                    this.potionDelay = this.buffTime[m];
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (this.buffType[m] == 22 && !Spectre.immunetoDeBuffs)
                                                                                                                                                    {
                                                                                                                                                        this.blind = true;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (this.buffType[m] == 23 && !Spectre.immunetoDeBuffs)
                                                                                                                                                        {
                                                                                                                                                            this.noItems = true;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (this.buffType[m] == 24 && !Spectre.immunetoDeBuffs)
                                                                                                                                                            {
                                                                                                                                                                this.onFire = true;
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (this.buffType[m] == 39 && !Spectre.immunetoDeBuffs)
                                                                                                                                                                {
                                                                                                                                                                    this.onFire2 = true;
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (this.buffType[m] == 29)
                                                                                                                                                                    {
                                                                                                                                                                        this.magicCrit += 2;
                                                                                                                                                                        this.magicDamage += 0.05f;
                                                                                                                                                                        this.statManaMax2 += 20;
                                                                                                                                                                        this.manaCost -= 0.02f;
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (this.buffType[m] == 28)
                                                                                                                                                                        {
                                                                                                                                                                            if (!Main.dayTime && Main.moonPhase == 0 && this.wolfAcc && !this.merman)
                                                                                                                                                                            {
                                                                                                                                                                                this.wereWolf = true;
                                                                                                                                                                                this.meleeCrit++;
                                                                                                                                                                                this.meleeDamage += 0.051f;
                                                                                                                                                                                this.meleeSpeed += 0.051f;
                                                                                                                                                                                this.statDefense++;
                                                                                                                                                                                this.moveSpeed += 0.05f;
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                this.DelBuff(m);
                                                                                                                                                                            }
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (this.buffType[m] == 33)
                                                                                                                                                                            {
                                                                                                                                                                                this.meleeDamage -= 0.051f;
                                                                                                                                                                                this.meleeSpeed -= 0.051f;
                                                                                                                                                                                this.statDefense -= 4;
                                                                                                                                                                                this.moveSpeed -= 0.1f;
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                if (this.buffType[m] == 25)
                                                                                                                                                                                {
                                                                                                                                                                                    this.statDefense -= 4;
                                                                                                                                                                                    this.meleeCrit += 2;
                                                                                                                                                                                    this.meleeDamage += 0.1f;
                                                                                                                                                                                    this.meleeSpeed += 0.1f;
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    if (this.buffType[m] == 26)
                                                                                                                                                                                    {
                                                                                                                                                                                        this.statDefense++;
                                                                                                                                                                                        this.meleeCrit++;
                                                                                                                                                                                        this.meleeDamage += 0.05f;
                                                                                                                                                                                        this.meleeSpeed += 0.05f;
                                                                                                                                                                                        this.magicCrit++;
                                                                                                                                                                                        this.magicDamage += 0.05f;
                                                                                                                                                                                        this.rangedCrit++;
                                                                                                                                                                                        this.magicDamage += 0.05f;
                                                                                                                                                                                        this.moveSpeed += 0.1f;
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
                            }
                        }
                    }
                    if (this.accMerman && this.wet && !this.lavaWet)
                    {
                        this.releaseJump = true;
                        this.wings = 0;
                        this.merman = true;
                        this.accFlipper = true;
                        this.AddBuff(34, 2, true);
                    }
                    else
                    {
                        this.merman = false;
                    }
                    this.accMerman = false;
                    if (this.wolfAcc && !this.merman && !Main.dayTime && Main.moonPhase == 0 && !this.wereWolf)
                    {
                        this.AddBuff(28, 60, true);
                    }
                    this.wolfAcc = false;
                    if (this.whoAmi == Main.myPlayer)
                    {
                        for (int num25 = 0; num25 < 10; num25++)
                        {
                            if (this.buffType[num25] > 0 && this.buffTime[num25] <= 0)
                            {
                                this.DelBuff(num25);
                            }
                        }
                    }
                    this.doubleJump = false;
                    for (int num26 = 0; num26 < 8; num26++)
                    {
                        this.statDefense += this.armor[num26].defense;
                        this.lifeRegen += this.armor[num26].lifeRegen;
                        if (this.armor[num26].type == 238)
                        {
                            this.magicDamage += 0.15f;
                        }
                        if (this.armor[num26].type == 123 || this.armor[num26].type == 124 || this.armor[num26].type == 125)
                        {
                            this.magicDamage += 0.05f;
                        }
                        if (this.armor[num26].type == 151 || this.armor[num26].type == 152 || this.armor[num26].type == 153)
                        {
                            this.rangedDamage += 0.05f;
                        }
                        if (this.armor[num26].type == 111 || this.armor[num26].type == 228 || this.armor[num26].type == 229 || this.armor[num26].type == 230)
                        {
                            this.statManaMax2 += 20;
                        }
                        if (this.armor[num26].type == 228 || this.armor[num26].type == 229 || this.armor[num26].type == 230)
                        {
                            this.magicCrit += 3;
                        }
                        if (this.armor[num26].type == 100 || this.armor[num26].type == 101 || this.armor[num26].type == 102)
                        {
                            this.meleeSpeed += 0.07f;
                        }
                        if (this.armor[num26].type == 371)
                        {
                            this.magicCrit += 9;
                            this.statManaMax2 += 40;
                        }
                        if (this.armor[num26].type == 372)
                        {
                            this.moveSpeed += 0.07f;
                            this.meleeSpeed += 0.12f;
                        }
                        if (this.armor[num26].type == 373)
                        {
                            this.rangedDamage += 0.1f;
                            this.rangedCrit += 6;
                        }
                        if (this.armor[num26].type == 374)
                        {
                            this.magicCrit += 3;
                            this.meleeCrit += 3;
                            this.rangedCrit += 3;
                        }
                        if (this.armor[num26].type == 375)
                        {
                            this.moveSpeed += 0.1f;
                        }
                        if (this.armor[num26].type == 376)
                        {
                            this.magicDamage += 0.15f;
                            this.statManaMax2 += 60;
                        }
                        if (this.armor[num26].type == 377)
                        {
                            this.meleeCrit += 5;
                            this.meleeDamage += 0.1f;
                        }
                        if (this.armor[num26].type == 378)
                        {
                            this.rangedDamage += 0.12f;
                            this.rangedCrit += 7;
                        }
                        if (this.armor[num26].type == 379)
                        {
                            this.rangedDamage += 0.05f;
                            this.meleeDamage += 0.05f;
                            this.magicDamage += 0.05f;
                        }
                        if (this.armor[num26].type == 380)
                        {
                            this.magicCrit += 3;
                            this.meleeCrit += 3;
                            this.rangedCrit += 3;
                        }
                        if (this.armor[num26].type == 268)
                        {
                            this.accDivingHelm = true;
                        }
                        if (this.armor[num26].type == 400)
                        {
                            this.magicDamage += 0.11f;
                            this.magicCrit += 11;
                            this.statManaMax2 += 80;
                        }
                        if (this.armor[num26].type == 401)
                        {
                            this.meleeCrit += 7;
                            this.meleeDamage += 0.14f;
                        }
                        if (this.armor[num26].type == 402)
                        {
                            this.rangedDamage += 0.14f;
                            this.rangedCrit += 8;
                        }
                        if (this.armor[num26].type == 403)
                        {
                            this.rangedDamage += 0.06f;
                            this.meleeDamage += 0.06f;
                            this.magicDamage += 0.06f;
                        }
                        if (this.armor[num26].type == 404)
                        {
                            this.magicCrit += 4;
                            this.meleeCrit += 4;
                            this.rangedCrit += 4;
                            this.moveSpeed += 0.05f;
                        }
                        if (this.armor[num26].type == 558)
                        {
                            this.magicDamage += 0.12f;
                            this.magicCrit += 12;
                            this.statManaMax2 += 100;
                        }
                        if (this.armor[num26].type == 559)
                        {
                            this.meleeCrit += 10;
                            this.meleeDamage += 0.1f;
                            this.meleeSpeed += 0.1f;
                        }
                        if (this.armor[num26].type == 553)
                        {
                            this.rangedDamage += 0.15f;
                            this.rangedCrit += 8;
                        }
                        if (this.armor[num26].type == 551)
                        {
                            this.magicCrit += 7;
                            this.meleeCrit += 7;
                            this.rangedCrit += 7;
                        }
                        if (this.armor[num26].type == 552)
                        {
                            this.rangedDamage += 0.07f;
                            this.meleeDamage += 0.07f;
                            this.magicDamage += 0.07f;
                            this.moveSpeed += 0.08f;
                        }
                        if (this.armor[num26].prefix == 62)
                        {
                            this.statDefense++;
                        }
                        if (this.armor[num26].prefix == 63)
                        {
                            this.statDefense += 2;
                        }
                        if (this.armor[num26].prefix == 64)
                        {
                            this.statDefense += 3;
                        }
                        if (this.armor[num26].prefix == 65)
                        {
                            this.statDefense += 4;
                        }
                        if (this.armor[num26].prefix == 66)
                        {
                            this.statManaMax2 += 20;
                        }
                        if (this.armor[num26].prefix == 67)
                        {
                            this.meleeCrit++;
                            this.rangedCrit++;
                            this.magicCrit++;
                        }
                        if (this.armor[num26].prefix == 68)
                        {
                            this.meleeCrit += 2;
                            this.rangedCrit += 2;
                            this.magicCrit += 2;
                        }
                        if (this.armor[num26].prefix == 69)
                        {
                            this.meleeDamage += 0.01f;
                            this.rangedDamage += 0.01f;
                            this.magicDamage += 0.01f;
                        }
                        if (this.armor[num26].prefix == 70)
                        {
                            this.meleeDamage += 0.02f;
                            this.rangedDamage += 0.02f;
                            this.magicDamage += 0.02f;
                        }
                        if (this.armor[num26].prefix == 71)
                        {
                            this.meleeDamage += 0.03f;
                            this.rangedDamage += 0.03f;
                            this.magicDamage += 0.03f;
                        }
                        if (this.armor[num26].prefix == 72)
                        {
                            this.meleeDamage += 0.04f;
                            this.rangedDamage += 0.04f;
                            this.magicDamage += 0.04f;
                        }
                        if (this.armor[num26].prefix == 73)
                        {
                            this.moveSpeed += 0.01f;
                        }
                        if (this.armor[num26].prefix == 74)
                        {
                            this.moveSpeed += 0.02f;
                        }
                        if (this.armor[num26].prefix == 75)
                        {
                            this.moveSpeed += 0.03f;
                        }
                        if (this.armor[num26].prefix == 76)
                        {
                            this.moveSpeed += 0.04f;
                        }
                        if (this.armor[num26].prefix == 77)
                        {
                            this.meleeSpeed += 0.01f;
                        }
                        if (this.armor[num26].prefix == 78)
                        {
                            this.meleeSpeed += 0.02f;
                        }
                        if (this.armor[num26].prefix == 79)
                        {
                            this.meleeSpeed += 0.03f;
                        }
                        if (this.armor[num26].prefix == 80)
                        {
                            this.meleeSpeed += 0.04f;
                        }
                    }
                    this.head = this.armor[0].headSlot;
                    this.body = this.armor[1].bodySlot;
                    this.legs = this.armor[2].legSlot;
                    for (int num27 = 3; num27 < 8; num27++)
                    {
                        if (this.armor[num27].type == 15 && this.accWatch < 1)
                        {
                            this.accWatch = 1;
                        }
                        if (this.armor[num27].type == 16 && this.accWatch < 2)
                        {
                            this.accWatch = 2;
                        }
                        if (this.armor[num27].type == 17 && this.accWatch < 3)
                        {
                            this.accWatch = 3;
                        }
                        if (this.armor[num27].type == 18 && this.accDepthMeter < 1)
                        {
                            this.accDepthMeter = 1;
                        }
                        if (this.armor[num27].type == 53)
                        {
                            this.doubleJump = true;
                        }
                        if (this.armor[num27].type == 54)
                        {
                            num6 = 6f;
                        }
                        if (this.armor[num27].type == 128)
                        {
                            this.rocketBoots = 1;
                        }
                        if (this.armor[num27].type == 156)
                        {
                            this.noKnockback = true;
                        }
                        if (this.armor[num27].type == 158)
                        {
                            this.noFallDmg = true;
                        }
                        if (this.armor[num27].type == 159)
                        {
                            this.jumpBoost = true;
                        }
                        if (this.armor[num27].type == 187)
                        {
                            this.accFlipper = true;
                        }
                        if (this.armor[num27].type == 211)
                        {
                            this.meleeSpeed += 0.12f;
                        }
                        if (this.armor[num27].type == 223)
                        {
                            this.manaCost -= 0.06f;
                        }
                        if (this.armor[num27].type == 285)
                        {
                            this.moveSpeed += 0.05f;
                        }
                        if (this.armor[num27].type == 212)
                        {
                            this.moveSpeed += 0.1f;
                        }
                        if (this.armor[num27].type == 267)
                        {
                            this.killGuide = true;
                        }
                        if (this.armor[num27].type == 193)
                        {
                            this.fireWalk = true;
                        }
                        if (this.armor[num27].type == 485)
                        {
                            this.wolfAcc = true;
                        }
                        if (this.armor[num27].type == 486)
                        {
                            this.rulerAcc = true;
                        }
                        if (this.armor[num27].type == 393)
                        {
                            this.accCompass = 1;
                        }
                        if (this.armor[num27].type == 394)
                        {
                            this.accFlipper = true;
                            this.accDivingHelm = true;
                        }
                        if (this.armor[num27].type == 395)
                        {
                            this.accWatch = 3;
                            this.accDepthMeter = 1;
                            this.accCompass = 1;
                        }
                        if (this.armor[num27].type == 396)
                        {
                            this.noFallDmg = true;
                            this.fireWalk = true;
                        }
                        if (this.armor[num27].type == 397)
                        {
                            this.noKnockback = true;
                            this.fireWalk = true;
                        }
                        if (this.armor[num27].type == 399)
                        {
                            this.jumpBoost = true;
                            this.doubleJump = true;
                        }
                        if (this.armor[num27].type == 405)
                        {
                            num6 = 6f;
                            this.rocketBoots = 2;
                        }
                        if (this.armor[num27].type == 407)
                        {
                            this.blockRange = 1;
                        }
                        if (this.armor[num27].type == 489)
                        {
                            this.magicDamage += 0.15f;
                        }
                        if (this.armor[num27].type == 490)
                        {
                            this.meleeDamage += 0.15f;
                        }
                        if (this.armor[num27].type == 491)
                        {
                            this.rangedDamage += 0.15f;
                        }
                        if (this.armor[num27].type == 492)
                        {
                            this.wings = 1;
                        }
                        if (this.armor[num27].type == 493)
                        {
                            this.wings = 2;
                        }
                        if (this.armor[num27].type == 497)
                        {
                            this.accMerman = true;
                        }
                        if (this.armor[num27].type == 535)
                        {
                            this.pStone = true;
                        }
                        if (this.armor[num27].type == 536)
                        {
                            this.kbGlove = true;
                        }
                        if (this.armor[num27].type == 532)
                        {
                            this.starCloak = true;
                        }
                        if (this.armor[num27].type == 554)
                        {
                            this.longInvince = true;
                        }
                        if (this.armor[num27].type == 555)
                        {
                            this.manaFlower = true;
                            this.manaCost -= 0.08f;
                        }
                        if (Main.myPlayer == this.whoAmi)
                        {
                            if (this.armor[num27].type == 576 && Main.rand.Next(18000) == 0 && Main.curMusic > 0)
                            {
                                int num28 = 0;
                                if (Main.curMusic == 1)
                                {
                                    num28 = 0;
                                }
                                if (Main.curMusic == 2)
                                {
                                    num28 = 1;
                                }
                                if (Main.curMusic == 3)
                                {
                                    num28 = 2;
                                }
                                if (Main.curMusic == 4)
                                {
                                    num28 = 4;
                                }
                                if (Main.curMusic == 5)
                                {
                                    num28 = 5;
                                }
                                if (Main.curMusic == 7)
                                {
                                    num28 = 6;
                                }
                                if (Main.curMusic == 8)
                                {
                                    num28 = 7;
                                }
                                if (Main.curMusic == 9)
                                {
                                    num28 = 9;
                                }
                                if (Main.curMusic == 10)
                                {
                                    num28 = 8;
                                }
                                if (Main.curMusic == 11)
                                {
                                    num28 = 11;
                                }
                                if (Main.curMusic == 12)
                                {
                                    num28 = 10;
                                }
                                if (Main.curMusic == 13)
                                {
                                    num28 = 12;
                                }
                                this.armor[num27].SetDefaults(num28 + 562, false);
                            }
                            if (this.armor[num27].type >= 562 && this.armor[num27].type <= 574)
                            {
                                Main.musicBox2 = this.armor[num27].type - 562;
                            }
                        }
                    }
                    if (this.head == 11)
                    {
                        int i2 = (int)(this.position.X + (float)(this.width / 2) + (float)(8 * this.direction)) / 16;
                        int j2 = (int)(this.position.Y + 2f) / 16;
                        Lighting.addLight(i2, j2, 0.92f, 0.8f, 0.65f);
                    }
                    this.setBonus = "";
                    if ((this.head == 1 && this.body == 1 && this.legs == 1) || (this.head == 2 && this.body == 2 && this.legs == 2))
                    {
                        this.setBonus = Lang.setBonus(0);
                        this.statDefense += 2;
                    }
                    if ((this.head == 3 && this.body == 3 && this.legs == 3) || (this.head == 4 && this.body == 4 && this.legs == 4))
                    {
                        this.setBonus = Lang.setBonus(1);
                        this.statDefense += 3;
                    }
                    if (this.head == 5 && this.body == 5 && this.legs == 5)
                    {
                        this.setBonus = Lang.setBonus(2);
                        this.moveSpeed += 0.15f;
                    }
                    if (this.head == 6 && this.body == 6 && this.legs == 6)
                    {
                        this.setBonus = Lang.setBonus(3);
                        this.spaceGun = true;
                    }
                    if (this.head == 7 && this.body == 7 && this.legs == 7)
                    {
                        this.setBonus = Lang.setBonus(4);
                        this.ammoCost80 = true;
                    }
                    if (this.head == 8 && this.body == 8 && this.legs == 8)
                    {
                        this.setBonus = Lang.setBonus(5);
                        this.manaCost -= 0.16f;
                    }
                    if (this.head == 9 && this.body == 9 && this.legs == 9)
                    {
                        this.setBonus = Lang.setBonus(6);
                        this.meleeDamage += 0.17f;
                    }
                    if (this.head == 11 && this.body == 20 && this.legs == 19)
                    {
                        this.setBonus = Lang.setBonus(7);
                        this.pickSpeed = 0.8f;
                    }
                    if (this.body == 17 && this.legs == 16)
                    {
                        if (this.head == 29)
                        {
                            this.setBonus = Lang.setBonus(8);
                            this.manaCost -= 0.14f;
                        }
                        else
                        {
                            if (this.head == 30)
                            {
                                this.setBonus = Lang.setBonus(9);
                                this.meleeSpeed += 0.15f;
                            }
                            else
                            {
                                if (this.head == 31)
                                {
                                    this.setBonus = Lang.setBonus(10);
                                    this.ammoCost80 = true;
                                }
                            }
                        }
                    }
                    if (this.body == 18 && this.legs == 17)
                    {
                        if (this.head == 32)
                        {
                            this.setBonus = Lang.setBonus(11);
                            this.manaCost -= 0.17f;
                        }
                        else
                        {
                            if (this.head == 33)
                            {
                                this.setBonus = Lang.setBonus(12);
                                this.meleeCrit += 5;
                            }
                            else
                            {
                                if (this.head == 34)
                                {
                                    this.setBonus = Lang.setBonus(13);
                                    this.ammoCost80 = true;
                                }
                            }
                        }
                    }
                    if (this.body == 19 && this.legs == 18)
                    {
                        if (this.head == 35)
                        {
                            this.setBonus = Lang.setBonus(14);
                            this.manaCost -= 0.19f;
                        }
                        else
                        {
                            if (this.head == 36)
                            {
                                this.setBonus = Lang.setBonus(15);
                                this.meleeSpeed += 0.18f;
                                this.moveSpeed += 0.18f;
                            }
                            else
                            {
                                if (this.head == 37)
                                {
                                    this.setBonus = Lang.setBonus(16);
                                    this.ammoCost75 = true;
                                }
                            }
                        }
                    }
                    if (this.body == 24 && this.legs == 23)
                    {
                        if (this.head == 42)
                        {
                            this.setBonus = Lang.setBonus(17);
                            this.manaCost -= 0.2f;
                        }
                        else
                        {
                            if (this.head == 43)
                            {
                                this.setBonus = Lang.setBonus(18);
                                this.meleeSpeed += 0.19f;
                                this.moveSpeed += 0.19f;
                            }
                            else
                            {
                                if (this.head == 41)
                                {
                                    this.setBonus = Lang.setBonus(19);
                                    this.ammoCost75 = true;
                                }
                            }
                        }
                    }
                    if (this.merman)
                    {
                        this.wings = 0;
                    }
                    if (this.meleeSpeed > 4f)
                    {
                        this.meleeSpeed = 4f;
                    }
                    if ((double)this.moveSpeed > 1.4)
                    {
                        this.moveSpeed = 1.4f;
                    }
                    if (this.slow)
                    {
                        this.moveSpeed *= 0.5f;
                    }
                    if (this.statManaMax2 > 400)
                    {
                        this.statManaMax2 = 400;
                    }
                    if (this.statDefense < 0)
                    {
                        this.statDefense = 0;
                    }
                    this.meleeSpeed = 1f / this.meleeSpeed;
                    if (this.poisoned)
                    {
                        this.lifeRegenTime = 0;
                        this.lifeRegen = -4;
                    }
                    if (this.onFire)
                    {
                        this.lifeRegenTime = 0;
                        this.lifeRegen = -8;
                    }
                    if (this.onFire2)
                    {
                        this.lifeRegenTime = 0;
                        this.lifeRegen = -8;
                    }
                    this.lifeRegenTime++;
                    if (this.bleed)
                    {
                        this.lifeRegenTime = 0;
                    }
                    float num29 = 0f;
                    if (this.lifeRegenTime >= 300)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 600)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 900)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 1200)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 1500)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 1800)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 2400)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 3000)
                    {
                        num29 += 1f;
                    }
                    if (this.lifeRegenTime >= 3600)
                    {
                        num29 += 1f;
                        this.lifeRegenTime = 3600;
                    }
                    if (this.velocity.X == 0f || this.grappling[0] > 0)
                    {
                        num29 *= 1.25f;
                    }
                    else
                    {
                        num29 *= 0.5f;
                    }
                    float num30 = (float)this.statLifeMax / 400f * 0.85f + 0.15f;
                    num29 *= num30;
                    this.lifeRegen += (int)Math.Round((double)num29);
                    this.lifeRegenCount += this.lifeRegen;
                    while (this.lifeRegenCount >= 120)
                    {
                        this.lifeRegenCount -= 120;
                        if (this.statLife < this.statLifeMax)
                        {
                            this.statLife++;
                        }
                        if (this.statLife > this.statLifeMax)
                        {
                            this.statLife = this.statLifeMax;
                        }
                    }
                    while (this.lifeRegenCount <= -120)
                    {
                        this.lifeRegenCount += 120;
                        this.statLife--;
                        if (this.statLife <= 0 && this.whoAmi == Main.myPlayer)
                        {
                            if (this.poisoned)
                            {
                                this.KillMe(10.0, 0, false, " " + Lang.dt[0]);
                            }
                            else
                            {
                                if (this.onFire)
                                {
                                    this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
                                }
                                else
                                {
                                    if (this.onFire2)
                                    {
                                        this.KillMe(10.0, 0, false, " " + Lang.dt[1]);
                                    }
                                }
                            }
                        }
                    }
                    if (this.manaRegenDelay > 0 && !this.channel)
                    {
                        this.manaRegenDelay--;
                        if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
                        {
                            this.manaRegenDelay--;
                        }
                    }
                    if (this.manaRegenBuff && this.manaRegenDelay > 20)
                    {
                        this.manaRegenDelay = 20;
                    }
                    if (this.manaRegenDelay <= 0)
                    {
                        this.manaRegenDelay = 0;
                        this.manaRegen = this.statManaMax2 / 7 + 1;
                        if ((this.velocity.X == 0f && this.velocity.Y == 0f) || this.grappling[0] >= 0 || this.manaRegenBuff)
                        {
                            this.manaRegen += this.statManaMax2 / 2;
                        }
                        float num31 = (float)this.statMana / (float)this.statManaMax2 * 0.8f + 0.2f;
                        if (this.manaRegenBuff)
                        {
                            num31 = 1f;
                        }
                        this.manaRegen = (int)((float)this.manaRegen * num31);
                    }
                    else
                    {
                        this.manaRegen = 0;
                    }
                    this.manaRegenCount += this.manaRegen;
                    while (this.manaRegenCount >= 120)
                    {
                        bool flag9 = false;
                        this.manaRegenCount -= 120;
                        if (this.statMana < this.statManaMax2)
                        {
                            this.statMana++;
                            flag9 = true;
                        }
                        if (this.statMana >= this.statManaMax2)
                        {
                            if (this.whoAmi == Main.myPlayer && flag9)
                            {
                                Main.PlaySound(25, -1, -1, 1);
                                for (int num32 = 0; num32 < 5; num32++)
                                {
                                    Vector2 arg_3B6D_0 = this.position;
                                    int arg_3B6D_1 = this.width;
                                    int arg_3B6D_2 = this.height;
                                    int arg_3B6D_3 = 45;
                                    float arg_3B6D_4 = 0f;
                                    float arg_3B6D_5 = 0f;
                                    int arg_3B6D_6 = 255;
                                    Color newColor = default(Color);
                                    int num33 = Dust.NewDust(arg_3B6D_0, arg_3B6D_1, arg_3B6D_2, arg_3B6D_3, arg_3B6D_4, arg_3B6D_5, arg_3B6D_6, newColor, (float)Main.rand.Next(20, 26) * 0.1f);
                                    Main.dust[num33].noLight = true;
                                    Main.dust[num33].noGravity = true;
                                    Dust expr_3B98 = Main.dust[num33];
                                    expr_3B98.velocity *= 0.5f;
                                }
                            }
                            this.statMana = this.statManaMax2;
                        }
                    }
                    if (this.manaRegenCount < 0)
                    {
                        this.manaRegenCount = 0;
                    }
                    if (this.statMana > this.statManaMax2)
                    {
                        this.statMana = this.statManaMax2;
                    }
                    num4 *= this.moveSpeed;
                    num3 *= this.moveSpeed;
                    if (this.jumpBoost)
                    {
                        Player.jumpHeight = 20;
                        Player.jumpSpeed = 6.51f;
                    }
                    if (this.wereWolf)
                    {
                        Player.jumpHeight += 2;
                        Player.jumpSpeed += 0.2f;
                    }
                    if (this.brokenArmor)
                    {
                        this.statDefense /= 2;
                    }
                    if (!this.doubleJump)
                    {
                        this.jumpAgain = false;
                    }
                    else
                    {
                        if (this.velocity.Y == 0f)
                        {
                            this.jumpAgain = true;
                        }
                    }
                    if (this.grappling[0] == -1 && !this.tongued)
                    {
                        if (this.controlLeft && this.velocity.X > -num3)
                        {
                            if (this.velocity.X > num5)
                            {
                                this.velocity.X = this.velocity.X - num5;
                            }
                            this.velocity.X = this.velocity.X - num4;
                            if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                            {
                                this.direction = -1;
                            }
                        }
                        else
                        {
                            if (this.controlRight && this.velocity.X < num3)
                            {
                                if (this.velocity.X < -num5)
                                {
                                    this.velocity.X = this.velocity.X + num5;
                                }
                                this.velocity.X = this.velocity.X + num4;
                                if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                                {
                                    this.direction = 1;
                                }
                            }
                            else
                            {
                                if (this.controlLeft && this.velocity.X > -num6)
                                {
                                    if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                                    {
                                        this.direction = -1;
                                    }
                                    if (this.velocity.Y == 0f || this.wings > 0)
                                    {
                                        if (this.velocity.X > num5)
                                        {
                                            this.velocity.X = this.velocity.X - num5;
                                        }
                                        this.velocity.X = this.velocity.X - num4 * 0.2f;
                                    }
                                    if (this.velocity.X < -(num6 + num3) / 2f && this.velocity.Y == 0f)
                                    {
                                        int num34 = 0;
                                        if (this.gravDir == -1f)
                                        {
                                            num34 -= this.height;
                                        }
                                        if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
                                        {
                                            Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
                                            this.runSoundDelay = 9;
                                        }
                                        Vector2 arg_3F27_0 = new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num34);
                                        int arg_3F27_1 = this.width + 8;
                                        int arg_3F27_2 = 4;
                                        int arg_3F27_3 = 16;
                                        float arg_3F27_4 = -this.velocity.X * 0.5f;
                                        float arg_3F27_5 = this.velocity.Y * 0.5f;
                                        int arg_3F27_6 = 50;
                                        Color newColor = default(Color);
                                        int num35 = Dust.NewDust(arg_3F27_0, arg_3F27_1, arg_3F27_2, arg_3F27_3, arg_3F27_4, arg_3F27_5, arg_3F27_6, newColor, 1.5f);
                                        Main.dust[num35].velocity.X = Main.dust[num35].velocity.X * 0.2f;
                                        Main.dust[num35].velocity.Y = Main.dust[num35].velocity.Y * 0.2f;
                                    }
                                }
                                else
                                {
                                    if (this.controlRight && this.velocity.X < num6)
                                    {
                                        if (this.itemAnimation == 0 || this.inventory[this.selectedItem].useTurn)
                                        {
                                            this.direction = 1;
                                        }
                                        if (this.velocity.Y == 0f || this.wings > 0)
                                        {
                                            if (this.velocity.X < -num5)
                                            {
                                                this.velocity.X = this.velocity.X + num5;
                                            }
                                            this.velocity.X = this.velocity.X + num4 * 0.2f;
                                        }
                                        if (this.velocity.X > (num6 + num3) / 2f && this.velocity.Y == 0f)
                                        {
                                            int num36 = 0;
                                            if (this.gravDir == -1f)
                                            {
                                                num36 -= this.height;
                                            }
                                            if (this.runSoundDelay == 0 && this.velocity.Y == 0f)
                                            {
                                                Main.PlaySound(17, (int)this.position.X, (int)this.position.Y, 1);
                                                this.runSoundDelay = 9;
                                            }
                                            Vector2 arg_4117_0 = new Vector2(this.position.X - 4f, this.position.Y + (float)this.height + (float)num36);
                                            int arg_4117_1 = this.width + 8;
                                            int arg_4117_2 = 4;
                                            int arg_4117_3 = 16;
                                            float arg_4117_4 = -this.velocity.X * 0.5f;
                                            float arg_4117_5 = this.velocity.Y * 0.5f;
                                            int arg_4117_6 = 50;
                                            Color newColor = default(Color);
                                            int num37 = Dust.NewDust(arg_4117_0, arg_4117_1, arg_4117_2, arg_4117_3, arg_4117_4, arg_4117_5, arg_4117_6, newColor, 1.5f);
                                            Main.dust[num37].velocity.X = Main.dust[num37].velocity.X * 0.2f;
                                            Main.dust[num37].velocity.Y = Main.dust[num37].velocity.Y * 0.2f;
                                        }
                                    }
                                    else
                                    {
                                        if (this.velocity.Y == 0f)
                                        {
                                            if (this.velocity.X > num5)
                                            {
                                                this.velocity.X = this.velocity.X - num5;
                                            }
                                            else
                                            {
                                                if (this.velocity.X < -num5)
                                                {
                                                    this.velocity.X = this.velocity.X + num5;
                                                }
                                                else
                                                {
                                                    this.velocity.X = 0f;
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if ((double)this.velocity.X > (double)num5 * 0.5)
                                            {
                                                this.velocity.X = this.velocity.X - num5 * 0.5f;
                                            }
                                            else
                                            {
                                                if ((double)this.velocity.X < (double)(-(double)num5) * 0.5)
                                                {
                                                    this.velocity.X = this.velocity.X + num5 * 0.5f;
                                                }
                                                else
                                                {
                                                    this.velocity.X = 0f;
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        if (this.gravControl)
                        {
                            if (this.controlUp && this.gravDir == 1f)
                            {
                                this.gravDir = -1f;
                                this.fallStart = (int)(this.position.Y / 16f);
                                this.jump = 0;
                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
                            }
                            if (this.controlDown && this.gravDir == -1f)
                            {
                                this.gravDir = 1f;
                                this.fallStart = (int)(this.position.Y / 16f);
                                this.jump = 0;
                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
                            }
                        }
                        else
                        {
                            this.gravDir = 1f;
                        }
                        if (this.controlJump)
                        {
                            if (this.jump > 0)
                            {
                                if (this.velocity.Y == 0f)
                                {
                                    if (this.merman)
                                    {
                                        this.jump = 10;
                                    }
                                    this.jump = 0;
                                }
                                else
                                {
                                    this.velocity.Y = -Player.jumpSpeed * this.gravDir;
                                    if (this.merman)
                                    {
                                        if (this.swimTime <= 10)
                                        {
                                            this.swimTime = 30;
                                        }
                                    }
                                    else
                                    {
                                        this.jump--;
                                    }
                                }
                            }
                            else
                            {
                                if ((this.velocity.Y == 0f || this.jumpAgain || (this.wet && this.accFlipper)) && this.releaseJump)
                                {
                                    bool flag10 = false;
                                    if (this.wet && this.accFlipper)
                                    {
                                        if (this.swimTime == 0)
                                        {
                                            this.swimTime = 30;
                                        }
                                        flag10 = true;
                                    }
                                    this.jumpAgain = false;
                                    this.canRocket = false;
                                    this.rocketRelease = false;
                                    if (this.velocity.Y == 0f && this.doubleJump)
                                    {
                                        this.jumpAgain = true;
                                    }
                                    if (this.velocity.Y == 0f || flag10)
                                    {
                                        this.velocity.Y = -Player.jumpSpeed * this.gravDir;
                                        this.jump = Player.jumpHeight;
                                    }
                                    else
                                    {
                                        int num38 = this.height;
                                        if (this.gravDir == -1f)
                                        {
                                            num38 = 0;
                                        }
                                        Main.PlaySound(16, (int)this.position.X, (int)this.position.Y, 1);
                                        this.velocity.Y = -Player.jumpSpeed * this.gravDir;
                                        this.jump = Player.jumpHeight / 2;
                                        for (int num39 = 0; num39 < 10; num39++)
                                        {
                                            Vector2 arg_456D_0 = new Vector2(this.position.X - 34f, this.position.Y + (float)num38 - 16f);
                                            int arg_456D_1 = 102;
                                            int arg_456D_2 = 32;
                                            int arg_456D_3 = 16;
                                            float arg_456D_4 = -this.velocity.X * 0.5f;
                                            float arg_456D_5 = this.velocity.Y * 0.5f;
                                            int arg_456D_6 = 100;
                                            Color newColor = default(Color);
                                            int num40 = Dust.NewDust(arg_456D_0, arg_456D_1, arg_456D_2, arg_456D_3, arg_456D_4, arg_456D_5, arg_456D_6, newColor, 1.5f);
                                            Main.dust[num40].velocity.X = Main.dust[num40].velocity.X * 0.5f - this.velocity.X * 0.1f;
                                            Main.dust[num40].velocity.Y = Main.dust[num40].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
                                        }
                                        int num41 = Gore.NewGore(new Vector2(this.position.X + (float)(this.width / 2) - 16f, this.position.Y + (float)num38 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                                        Main.gore[num41].velocity.X = Main.gore[num41].velocity.X * 0.1f - this.velocity.X * 0.1f;
                                        Main.gore[num41].velocity.Y = Main.gore[num41].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
                                        num41 = Gore.NewGore(new Vector2(this.position.X - 36f, this.position.Y + (float)num38 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                                        Main.gore[num41].velocity.X = Main.gore[num41].velocity.X * 0.1f - this.velocity.X * 0.1f;
                                        Main.gore[num41].velocity.Y = Main.gore[num41].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
                                        num41 = Gore.NewGore(new Vector2(this.position.X + (float)this.width + 4f, this.position.Y + (float)num38 - 16f), new Vector2(-this.velocity.X, -this.velocity.Y), Main.rand.Next(11, 14), 1f);
                                        Main.gore[num41].velocity.X = Main.gore[num41].velocity.X * 0.1f - this.velocity.X * 0.1f;
                                        Main.gore[num41].velocity.Y = Main.gore[num41].velocity.Y * 0.1f - this.velocity.Y * 0.05f;
                                    }
                                }
                            }
                            this.releaseJump = false;
                        }
                        else
                        {
                            this.jump = 0;
                            this.releaseJump = true;
                            this.rocketRelease = true;
                        }
                        if (this.doubleJump && !this.jumpAgain && ((this.gravDir == 1f && this.velocity.Y < 0f) || (this.gravDir == -1f && this.velocity.Y > 0f)) && this.rocketBoots == 0 && !this.accFlipper)
                        {
                            int num42 = this.height;
                            if (this.gravDir == -1f)
                            {
                                num42 = -6;
                            }
                            Vector2 arg_49A6_0 = new Vector2(this.position.X - 4f, this.position.Y + (float)num42);
                            int arg_49A6_1 = this.width + 8;
                            int arg_49A6_2 = 4;
                            int arg_49A6_3 = 16;
                            float arg_49A6_4 = -this.velocity.X * 0.5f;
                            float arg_49A6_5 = this.velocity.Y * 0.5f;
                            int arg_49A6_6 = 100;
                            Color newColor = default(Color);
                            int num43 = Dust.NewDust(arg_49A6_0, arg_49A6_1, arg_49A6_2, arg_49A6_3, arg_49A6_4, arg_49A6_5, arg_49A6_6, newColor, 1.5f);
                            Main.dust[num43].velocity.X = Main.dust[num43].velocity.X * 0.5f - this.velocity.X * 0.1f;
                            Main.dust[num43].velocity.Y = Main.dust[num43].velocity.Y * 0.5f - this.velocity.Y * 0.3f;
                        }
                        if (((this.gravDir == 1f && this.velocity.Y > -Player.jumpSpeed) || (this.gravDir == -1f && this.velocity.Y < Player.jumpSpeed)) && this.velocity.Y != 0f)
                        {
                            this.canRocket = true;
                        }
                        bool flag11 = false;
                        if (this.velocity.Y == 0f)
                        {
                            this.wingTime = 90;
                        }
                        if (this.wings > 0 && this.controlJump && this.wingTime > 0 && !this.jumpAgain && this.jump == 0 && this.velocity.Y != 0f)
                        {
                            flag11 = true;
                        }
                        if (flag11)
                        {
                            this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
                            if (this.gravDir == 1f)
                            {
                                if (this.velocity.Y > 0f)
                                {
                                    this.velocity.Y = this.velocity.Y - 0.5f;
                                }
                                else
                                {
                                    if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
                                    {
                                        this.velocity.Y = this.velocity.Y - 0.1f;
                                    }
                                }
                                if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
                                {
                                    this.velocity.Y = -Player.jumpSpeed * 1.5f;
                                }
                            }
                            else
                            {
                                if (this.velocity.Y < 0f)
                                {
                                    this.velocity.Y = this.velocity.Y + 0.5f;
                                }
                                else
                                {
                                    if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
                                    {
                                        this.velocity.Y = this.velocity.Y + 0.1f;
                                    }
                                }
                                if (this.velocity.Y > Player.jumpSpeed * 1.5f)
                                {
                                    this.velocity.Y = Player.jumpSpeed * 1.5f;
                                }
                            }
                            this.wingTime--;
                        }
                        if (flag11 || this.jump > 0)
                        {
                            this.wingFrameCounter++;
                            if (this.wingFrameCounter > 4)
                            {
                                this.wingFrame++;
                                this.wingFrameCounter = 0;
                                if (this.wingFrame >= 4)
                                {
                                    this.wingFrame = 0;
                                }
                            }
                        }
                        else
                        {
                            if (this.velocity.Y != 0f)
                            {
                                this.wingFrame = 1;
                            }
                            else
                            {
                                this.wingFrame = 0;
                            }
                        }
                        if (this.wings > 0 && this.rocketBoots > 0)
                        {
                            this.wingTime += this.rocketTime * 10;
                            this.rocketTime = 0;
                        }
                        if (flag11)
                        {
                            if (this.wingFrame == 3)
                            {
                                if (!this.flapSound)
                                {
                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 32);
                                }
                                this.flapSound = true;
                            }
                            else
                            {
                                this.flapSound = false;
                            }
                        }
                        if (this.velocity.Y == 0f)
                        {
                            this.rocketTime = this.rocketTimeMax;
                        }
                        if ((this.wingTime == 0 || this.wings == 0) && this.rocketBoots > 0 && this.controlJump && this.rocketDelay == 0 && this.canRocket && this.rocketRelease && !this.jumpAgain)
                        {
                            if (this.rocketTime > 0)
                            {
                                this.rocketTime--;
                                this.rocketDelay = 10;
                                if (this.rocketDelay2 <= 0)
                                {
                                    if (this.rocketBoots == 1)
                                    {
                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 13);
                                        this.rocketDelay2 = 30;
                                    }
                                    else
                                    {
                                        if (this.rocketBoots == 2)
                                        {
                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 24);
                                            this.rocketDelay2 = 15;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                this.canRocket = false;
                            }
                        }
                        if (this.rocketDelay2 > 0)
                        {
                            this.rocketDelay2--;
                        }
                        if (this.rocketDelay == 0)
                        {
                            this.rocketFrame = false;
                        }
                        if (this.rocketDelay > 0)
                        {
                            int num44 = this.height;
                            if (this.gravDir == -1f)
                            {
                                num44 = 4;
                            }
                            this.rocketFrame = true;
                            for (int num45 = 0; num45 < 2; num45++)
                            {
                                int num46 = 6;
                                float scale = 2.5f;
                                int num47 = 100;
                                if (this.rocketBoots == 2)
                                {
                                    num46 = 16;
                                    scale = 1.5f;
                                    num47 = 20;
                                }
                                else
                                {
                                    if (this.socialShadow)
                                    {
                                        num46 = 27;
                                        scale = 1.5f;
                                    }
                                }
                                if (num45 == 0)
                                {
                                    Vector2 arg_4F12_0 = new Vector2(this.position.X - 4f, this.position.Y + (float)num44 - 10f);
                                    int arg_4F12_1 = 8;
                                    int arg_4F12_2 = 8;
                                    int arg_4F12_3 = num46;
                                    float arg_4F12_4 = 0f;
                                    float arg_4F12_5 = 0f;
                                    int arg_4F12_6 = num47;
                                    Color newColor = default(Color);
                                    int num48 = Dust.NewDust(arg_4F12_0, arg_4F12_1, arg_4F12_2, arg_4F12_3, arg_4F12_4, arg_4F12_5, arg_4F12_6, newColor, scale);
                                    if (this.rocketBoots == 1)
                                    {
                                        Main.dust[num48].noGravity = true;
                                    }
                                    Main.dust[num48].velocity.X = Main.dust[num48].velocity.X * 1f - 2f - this.velocity.X * 0.3f;
                                    Main.dust[num48].velocity.Y = Main.dust[num48].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
                                    if (this.rocketBoots == 2)
                                    {
                                        Dust expr_4FCF = Main.dust[num48];
                                        expr_4FCF.velocity *= 0.1f;
                                    }
                                }
                                else
                                {
                                    Vector2 arg_5038_0 = new Vector2(this.position.X + (float)this.width - 4f, this.position.Y + (float)num44 - 10f);
                                    int arg_5038_1 = 8;
                                    int arg_5038_2 = 8;
                                    int arg_5038_3 = num46;
                                    float arg_5038_4 = 0f;
                                    float arg_5038_5 = 0f;
                                    int arg_5038_6 = num47;
                                    Color newColor = default(Color);
                                    int num49 = Dust.NewDust(arg_5038_0, arg_5038_1, arg_5038_2, arg_5038_3, arg_5038_4, arg_5038_5, arg_5038_6, newColor, scale);
                                    if (this.rocketBoots == 1)
                                    {
                                        Main.dust[num49].noGravity = true;
                                    }
                                    Main.dust[num49].velocity.X = Main.dust[num49].velocity.X * 1f + 2f - this.velocity.X * 0.3f;
                                    Main.dust[num49].velocity.Y = Main.dust[num49].velocity.Y * 1f + 2f * this.gravDir - this.velocity.Y * 0.3f;
                                    if (this.rocketBoots == 2)
                                    {
                                        Dust expr_50F2 = Main.dust[num49];
                                        expr_50F2.velocity *= 0.1f;
                                    }
                                }
                            }
                            if (this.rocketDelay == 0)
                            {
                                this.releaseJump = true;
                            }
                            this.rocketDelay--;
                            this.velocity.Y = this.velocity.Y - 0.1f * this.gravDir;
                            if (this.gravDir == 1f)
                            {
                                if (this.velocity.Y > 0f)
                                {
                                    this.velocity.Y = this.velocity.Y - 0.5f;
                                }
                                else
                                {
                                    if ((double)this.velocity.Y > (double)(-(double)Player.jumpSpeed) * 0.5)
                                    {
                                        this.velocity.Y = this.velocity.Y - 0.1f;
                                    }
                                }
                                if (this.velocity.Y < -Player.jumpSpeed * 1.5f)
                                {
                                    this.velocity.Y = -Player.jumpSpeed * 1.5f;
                                }
                            }
                            else
                            {
                                if (this.velocity.Y < 0f)
                                {
                                    this.velocity.Y = this.velocity.Y + 0.5f;
                                }
                                else
                                {
                                    if ((double)this.velocity.Y < (double)Player.jumpSpeed * 0.5)
                                    {
                                        this.velocity.Y = this.velocity.Y + 0.1f;
                                    }
                                }
                                if (this.velocity.Y > Player.jumpSpeed * 1.5f)
                                {
                                    this.velocity.Y = Player.jumpSpeed * 1.5f;
                                }
                            }
                        }
                        else
                        {
                            if (!flag11)
                            {
                                if (this.slowFall && ((!this.controlDown && this.gravDir == 1f) || (!this.controlUp && this.gravDir == -1f)))
                                {
                                    if ((this.controlUp && this.gravDir == 1f) || (this.controlDown && this.gravDir == -1f))
                                    {
                                        this.velocity.Y = this.velocity.Y + num2 / 10f * this.gravDir;
                                    }
                                    else
                                    {
                                        this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
                                    }
                                }
                                else
                                {
                                    if (this.wings > 0 && this.controlJump && this.velocity.Y > 0f)
                                    {
                                        this.fallStart = (int)(this.position.Y / 16f);
                                        if (this.velocity.Y > 0f)
                                        {
                                            this.wingFrame = 2;
                                        }
                                        this.velocity.Y = this.velocity.Y + num2 / 3f * this.gravDir;
                                        if (this.gravDir == 1f)
                                        {
                                            if (this.velocity.Y > num / 3f && !this.controlDown)
                                            {
                                                this.velocity.Y = num / 3f;
                                            }
                                        }
                                        else
                                        {
                                            if (this.velocity.Y < -num / 3f && !this.controlUp)
                                            {
                                                this.velocity.Y = -num / 3f;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        this.velocity.Y = this.velocity.Y + num2 * this.gravDir;
                                    }
                                }
                            }
                        }
                        if (this.gravDir == 1f)
                        {
                            if (this.velocity.Y > num)
                            {
                                this.velocity.Y = num;
                            }
                            if (this.slowFall && this.velocity.Y > num / 3f && !this.controlDown)
                            {
                                this.velocity.Y = num / 3f;
                            }
                            if (this.slowFall && this.velocity.Y > num / 5f && this.controlUp)
                            {
                                this.velocity.Y = num / 10f;
                            }
                        }
                        else
                        {
                            if (this.velocity.Y < -num)
                            {
                                this.velocity.Y = -num;
                            }
                            if (this.slowFall && this.velocity.Y < -num / 3f && !this.controlUp)
                            {
                                this.velocity.Y = -num / 3f;
                            }
                            if (this.slowFall && this.velocity.Y < -num / 5f && this.controlDown)
                            {
                                this.velocity.Y = -num / 10f;
                            }
                        }
                    }
                    for (int num50 = 0; num50 < 200; num50++)
                    {
                        if (Main.item[num50].active && Main.item[num50].noGrabDelay == 0 && Main.item[num50].owner == i)
                        {
                            Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
                            if (rectangle.Intersects(new Rectangle((int)Main.item[num50].position.X, (int)Main.item[num50].position.Y, Main.item[num50].width, Main.item[num50].height)))
                            {
                                if (i == Main.myPlayer && (this.inventory[this.selectedItem].type != 0 || this.itemAnimation <= 0))
                                {
                                    if (Main.item[num50].type == 58)
                                    {
                                        Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                                        this.statLife += 20;
                                        if (Main.myPlayer == this.whoAmi)
                                        {
                                            this.HealEffect(20);
                                        }
                                        if (this.statLife > this.statLifeMax)
                                        {
                                            this.statLife = this.statLifeMax;
                                        }
                                        Main.item[num50] = new Item();
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.SendData(21, -1, -1, "", num50, 0f, 0f, 0f, 0);
                                        }
                                    }
                                    else
                                    {
                                        if (Main.item[num50].type == 184)
                                        {
                                            Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                                            this.statMana += 100;
                                            if (Main.myPlayer == this.whoAmi)
                                            {
                                                this.ManaEffect(100);
                                            }
                                            if (this.statMana > this.statManaMax2)
                                            {
                                                this.statMana = this.statManaMax2;
                                            }
                                            Main.item[num50] = new Item();
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(21, -1, -1, "", num50, 0f, 0f, 0f, 0);
                                            }
                                        }
                                        else
                                        {
                                            Main.item[num50] = this.GetItem(i, Main.item[num50]);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(21, -1, -1, "", num50, 0f, 0f, 0f, 0);
                                            }
                                        }
                                    }
                                }
                            }
                            else
                            {
                                rectangle = new Rectangle((int)this.position.X - Player.itemGrabRange, (int)this.position.Y - Player.itemGrabRange, this.width + Player.itemGrabRange * 2, this.height + Player.itemGrabRange * 2);
                                if (rectangle.Intersects(new Rectangle((int)Main.item[num50].position.X, (int)Main.item[num50].position.Y, Main.item[num50].width, Main.item[num50].height)) && this.ItemSpace(Main.item[num50]))
                                {
                                    Main.item[num50].beingGrabbed = true;
                                    if ((double)this.position.X + (double)this.width * 0.5 > (double)Main.item[num50].position.X + (double)Main.item[num50].width * 0.5)
                                    {
                                        if (Main.item[num50].velocity.X < Player.itemGrabSpeedMax + this.velocity.X)
                                        {
                                            Item expr_593E_cp_0 = Main.item[num50];
                                            expr_593E_cp_0.velocity.X = expr_593E_cp_0.velocity.X + Player.itemGrabSpeed;
                                        }
                                        if (Main.item[num50].velocity.X < 0f)
                                        {
                                            Item expr_5978_cp_0 = Main.item[num50];
                                            expr_5978_cp_0.velocity.X = expr_5978_cp_0.velocity.X + Player.itemGrabSpeed * 0.75f;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.item[num50].velocity.X > -Player.itemGrabSpeedMax + this.velocity.X)
                                        {
                                            Item expr_59C7_cp_0 = Main.item[num50];
                                            expr_59C7_cp_0.velocity.X = expr_59C7_cp_0.velocity.X - Player.itemGrabSpeed;
                                        }
                                        if (Main.item[num50].velocity.X > 0f)
                                        {
                                            Item expr_59FE_cp_0 = Main.item[num50];
                                            expr_59FE_cp_0.velocity.X = expr_59FE_cp_0.velocity.X - Player.itemGrabSpeed * 0.75f;
                                        }
                                    }
                                    if ((double)this.position.Y + (double)this.height * 0.5 > (double)Main.item[num50].position.Y + (double)Main.item[num50].height * 0.5)
                                    {
                                        if (Main.item[num50].velocity.Y < Player.itemGrabSpeedMax)
                                        {
                                            Item expr_5A87_cp_0 = Main.item[num50];
                                            expr_5A87_cp_0.velocity.Y = expr_5A87_cp_0.velocity.Y + Player.itemGrabSpeed;
                                        }
                                        if (Main.item[num50].velocity.Y < 0f)
                                        {
                                            Item expr_5AC1_cp_0 = Main.item[num50];
                                            expr_5AC1_cp_0.velocity.Y = expr_5AC1_cp_0.velocity.Y + Player.itemGrabSpeed * 0.75f;
                                        }
                                    }
                                    else
                                    {
                                        if (Main.item[num50].velocity.Y > -Player.itemGrabSpeedMax)
                                        {
                                            Item expr_5B01_cp_0 = Main.item[num50];
                                            expr_5B01_cp_0.velocity.Y = expr_5B01_cp_0.velocity.Y - Player.itemGrabSpeed;
                                        }
                                        if (Main.item[num50].velocity.Y > 0f)
                                        {
                                            Item expr_5B38_cp_0 = Main.item[num50];
                                            expr_5B38_cp_0.velocity.Y = expr_5B38_cp_0.velocity.Y - Player.itemGrabSpeed * 0.75f;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (this.position.X / 16f - (float)Player.tileRangeX <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY - 2f >= (float)Player.tileTargetY)
                    {
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY] == null)
                        {
                            Main.tile[Player.tileTargetX, Player.tileTargetY] = new Tile();
                        }
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 359;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 224;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
                                {
                                    this.showItemIcon2 = 348;
                                }
                                else
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
                                    {
                                        this.showItemIcon2 = 343;
                                    }
                                    else
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 144)
                                        {
                                            this.showItemIcon2 = 329;
                                        }
                                        else
                                        {
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 108)
                                            {
                                                this.showItemIcon2 = 328;
                                            }
                                            else
                                            {
                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
                                                {
                                                    this.showItemIcon2 = 327;
                                                }
                                                else
                                                {
                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 36)
                                                    {
                                                        this.showItemIcon2 = 306;
                                                    }
                                                    else
                                                    {
                                                        this.showItemIcon2 = 48;
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                int num51 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 22);
                                if (num51 == 0)
                                {
                                    this.showItemIcon2 = 8;
                                }
                                else
                                {
                                    if (num51 == 8)
                                    {
                                        this.showItemIcon2 = 523;
                                    }
                                    else
                                    {
                                        this.showItemIcon2 = 426 + num51;
                                    }
                                }
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 72)
                                {
                                    this.showItemIcon2 = 351;
                                }
                                else
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 54)
                                    {
                                        this.showItemIcon2 = 350;
                                    }
                                    else
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 18)
                                        {
                                            this.showItemIcon2 = 28;
                                        }
                                        else
                                        {
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 36)
                                            {
                                                this.showItemIcon2 = 110;
                                            }
                                            else
                                            {
                                                this.showItemIcon2 = 31;
                                            }
                                        }
                                    }
                                }
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 87;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 346;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 105;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 148;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50)
                            {
                                this.noThrow = 2;
                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90)
                                {
                                    this.showItemIcon = true;
                                    this.showItemIcon2 = 165;
                                }
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
                            {
                                this.noThrow = 2;
                                int num52 = Player.tileTargetX;
                                int num53 = Player.tileTargetY;
                                int num54 = 0;
                                for (int num55 = (int)(Main.tile[num52, num53].frameY / 18); num55 >= 2; num55 -= 2)
                                {
                                    num54++;
                                }
                                this.showItemIcon = true;
                                this.showItemIcon2 = 562 + num54;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
                            {
                                this.noThrow = 2;
                                int num56 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
                                int num57 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
                                while (num56 > 1)
                                {
                                    num56 -= 2;
                                }
                                int num58 = Player.tileTargetX - num56;
                                int num59 = Player.tileTargetY - num57;
                                Main.signBubble = true;
                                Main.signX = num58 * 16 + 16;
                                Main.signY = num59 * 16;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 25;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 487;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 513;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = 538;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
                            {
                                this.noThrow = 2;
                                this.showItemIcon = true;
                                this.showItemIcon2 = (int)(583 + Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128)
                            {
                                this.noThrow = 2;
                                int num60 = Player.tileTargetX;
                                int num61 = Player.tileTargetY;
                                int num62;
                                for (num62 = (int)Main.tile[num60, num61].frameX; num62 >= 100; num62 -= 100)
                                {
                                }
                                while (num62 >= 36)
                                {
                                    num62 -= 36;
                                }
                                if (num62 == 18)
                                {
                                    num60--;
                                }
                                int num63 = (int)Main.tile[num60, num61].frameX;
                                if (num63 >= 100)
                                {
                                    int num64 = 0;
                                    while (num63 >= 100)
                                    {
                                        num63 -= 100;
                                        num64++;
                                    }
                                    this.showItemIcon = true;
                                    int num65 = (int)(Main.tile[num60, num61].frameY / 18);
                                    if (num65 == 0)
                                    {
                                        this.showItemIcon2 = Item.headType[num64];
                                    }
                                    if (num65 == 1)
                                    {
                                        this.showItemIcon2 = Item.bodyType[num64];
                                    }
                                    if (num65 == 2)
                                    {
                                        this.showItemIcon2 = Item.legType[num64];
                                    }
                                }
                            }
                            if (this.controlUseTile)
                            {
                                if (this.releaseUseTile)
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 132 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 136 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 144)
                                    {
                                        WorldGen.hitSwitch(Player.tileTargetX, Player.tileTargetY);
                                        NetMessage.SendData(59, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
                                    }
                                    else
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 139)
                                        {
                                            Main.PlaySound(28, Player.tileTargetX * 16, Player.tileTargetY * 16, 0);
                                            WorldGen.SwitchMB(Player.tileTargetX, Player.tileTargetY);
                                        }
                                        else
                                        {
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 128)
                                            {
                                                int num66 = Player.tileTargetX;
                                                int num67 = Player.tileTargetY;
                                                int num68;
                                                for (num68 = (int)Main.tile[num66, num67].frameX; num68 >= 100; num68 -= 100)
                                                {
                                                }
                                                while (num68 >= 36)
                                                {
                                                    num68 -= 36;
                                                }
                                                if (num68 == 18)
                                                {
                                                    num66--;
                                                }
                                                int frameX = (int)Main.tile[num66, num67].frameX;
                                                if (frameX >= 100)
                                                {
                                                    WorldGen.KillTile(num66, num67, true, false, false);
                                                    if (Main.netMode == 1)
                                                    {
                                                        NetMessage.SendData(17, -1, -1, "", 0, (float)num66, (float)num67, 1f, 0);
                                                    }
                                                }
                                            }
                                            else
                                            {
                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 4 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 13 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 33 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 49 || (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 50 && Main.tile[Player.tileTargetX, Player.tileTargetY].frameX == 90))
                                                {
                                                    WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                                    if (Main.netMode == 1)
                                                    {
                                                        NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                                                    }
                                                }
                                                else
                                                {
                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 125)
                                                    {
                                                        this.AddBuff(29, 36000, true);
                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 4);
                                                    }
                                                    else
                                                    {
                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 79)
                                                        {
                                                            int num69 = Player.tileTargetX;
                                                            int num70 = Player.tileTargetY;
                                                            num69 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18 * -1);
                                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 72)
                                                            {
                                                                num69 += 4;
                                                                num69++;
                                                            }
                                                            else
                                                            {
                                                                num69 += 2;
                                                            }
                                                            num70 += (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18 * -1);
                                                            num70 += 2;
                                                            if (Player.CheckSpawn(num69, num70))
                                                            {
                                                                this.ChangeSpawn(num69, num70);
                                                                Main.NewText("Spawn point set!", 255, 240, 20);
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 55 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 85)
                                                            {
                                                                bool flag12 = true;
                                                                if (this.sign >= 0)
                                                                {
                                                                    int num71 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
                                                                    if (num71 == this.sign)
                                                                    {
                                                                        this.sign = -1;
                                                                        Main.npcChatText = "";
                                                                        Main.editSign = false;
                                                                        Main.PlaySound(11, -1, -1, 1);
                                                                        flag12 = false;
                                                                    }
                                                                }
                                                                if (flag12)
                                                                {
                                                                    if (Main.netMode == 0)
                                                                    {
                                                                        this.talkNPC = -1;
                                                                        Main.playerInventory = false;
                                                                        Main.editSign = false;
                                                                        Main.PlaySound(10, -1, -1, 1);
                                                                        int num72 = Sign.ReadSign(Player.tileTargetX, Player.tileTargetY);
                                                                        this.sign = num72;
                                                                        Main.npcChatText = Main.sign[num72].text;
                                                                    }
                                                                    else
                                                                    {
                                                                        int num73 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18);
                                                                        int num74 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
                                                                        while (num73 > 1)
                                                                        {
                                                                            num73 -= 2;
                                                                        }
                                                                        int num75 = Player.tileTargetX - num73;
                                                                        int num76 = Player.tileTargetY - num74;
                                                                        if (Main.tile[num75, num76].type == 55 || Main.tile[num75, num76].type == 85)
                                                                        {
                                                                            NetMessage.SendData(46, -1, -1, "", num75, (float)num76, 0f, 0f, 0);
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 104)
                                                                {
                                                                    string text = "AM";
                                                                    double num77 = Main.time;
                                                                    if (!Main.dayTime)
                                                                    {
                                                                        num77 += 54000.0;
                                                                    }
                                                                    num77 = num77 / 86400.0 * 24.0;
                                                                    double num78 = 7.5;
                                                                    num77 = num77 - num78 - 12.0;
                                                                    if (num77 < 0.0)
                                                                    {
                                                                        num77 += 24.0;
                                                                    }
                                                                    if (num77 >= 12.0)
                                                                    {
                                                                        text = "PM";
                                                                    }
                                                                    int num79 = (int)num77;
                                                                    double num80 = num77 - (double)num79;
                                                                    num80 = (double)((int)(num80 * 60.0));
                                                                    string text2 = string.Concat(num80);
                                                                    if (num80 < 10.0)
                                                                    {
                                                                        text2 = "0" + text2;
                                                                    }
                                                                    if (num79 > 12)
                                                                    {
                                                                        num79 -= 12;
                                                                    }
                                                                    if (num79 == 0)
                                                                    {
                                                                        num79 = 12;
                                                                    }
                                                                    string newText = string.Concat(new object[]
																	{
																		"Time: ", 
																		num79, 
																		":", 
																		text2, 
																		" ", 
																		text
																	});
                                                                    Main.NewText(newText, 255, 240, 20);
                                                                }
                                                                else
                                                                {
                                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 10)
                                                                    {
                                                                        WorldGen.OpenDoor(Player.tileTargetX, Player.tileTargetY, this.direction);
                                                                        NetMessage.SendData(19, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 11)
                                                                        {
                                                                            if (WorldGen.CloseDoor(Player.tileTargetX, Player.tileTargetY, false))
                                                                            {
                                                                                NetMessage.SendData(19, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.direction, 0);
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if ((Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97) && this.talkNPC == -1)
                                                                            {
                                                                                int num81 = 0;
                                                                                int num82;
                                                                                for (num82 = (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameX / 18); num82 > 1; num82 -= 2)
                                                                                {
                                                                                }
                                                                                num82 = Player.tileTargetX - num82;
                                                                                int num83 = Player.tileTargetY - (int)(Main.tile[Player.tileTargetX, Player.tileTargetY].frameY / 18);
                                                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 29)
                                                                                {
                                                                                    num81 = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 97)
                                                                                    {
                                                                                        num81 = 2;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 216)
                                                                                        {
                                                                                            Main.chestText = "Trash Can";
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].frameX >= 180)
                                                                                            {
                                                                                                Main.chestText = "Barrel";
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                Main.chestText = "Chest";
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                                if (Main.netMode == 1 && num81 == 0 && (Main.tile[num82, num83].frameX < 72 || Main.tile[num82, num83].frameX > 106) && (Main.tile[num82, num83].frameX < 144 || Main.tile[num82, num83].frameX > 178))
                                                                                {
                                                                                    if (num82 == this.chestX && num83 == this.chestY && this.chest != -1)
                                                                                    {
                                                                                        this.chest = -1;
                                                                                        Main.PlaySound(11, -1, -1, 1);
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        NetMessage.SendData(31, -1, -1, "", num82, (float)num83, 0f, 0f, 0);
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    int num84 = -1;
                                                                                    if (num81 == 1)
                                                                                    {
                                                                                        num84 = -2;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (num81 == 2)
                                                                                        {
                                                                                            num84 = -3;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            bool flag13 = false;
                                                                                            if ((Main.tile[num82, num83].frameX >= 72 && Main.tile[num82, num83].frameX <= 106) || (Main.tile[num82, num83].frameX >= 144 && Main.tile[num82, num83].frameX <= 178))
                                                                                            {
                                                                                                int num85 = 327;
                                                                                                if (Main.tile[num82, num83].frameX >= 144 && Main.tile[num82, num83].frameX <= 178)
                                                                                                {
                                                                                                    num85 = 329;
                                                                                                }
                                                                                                flag13 = true;
                                                                                                for (int num86 = 0; num86 < 48; num86++)
                                                                                                {
                                                                                                    if (this.inventory[num86].type == num85 && this.inventory[num86].stack > 0)
                                                                                                    {
                                                                                                        if (num85 != 329)
                                                                                                        {
                                                                                                            this.inventory[num86].stack--;
                                                                                                            if (this.inventory[num86].stack <= 0)
                                                                                                            {
                                                                                                                this.inventory[num86] = new Item();
                                                                                                            }
                                                                                                        }
                                                                                                        Chest.Unlock(num82, num83);
                                                                                                        if (Main.netMode == 1)
                                                                                                        {
                                                                                                            NetMessage.SendData(52, -1, -1, "", this.whoAmi, 1f, (float)num82, (float)num83, 0);
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            if (!flag13)
                                                                                            {
                                                                                                num84 = Chest.FindChest(num82, num83);
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    if (num84 != -1)
                                                                                    {
                                                                                        if (num84 == this.chest)
                                                                                        {
                                                                                            this.chest = -1;
                                                                                            Main.PlaySound(11, -1, -1, 1);
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (num84 != this.chest && this.chest == -1)
                                                                                            {
                                                                                                this.chest = num84;
                                                                                                Main.playerInventory = true;
                                                                                                Main.PlaySound(10, -1, -1, 1);
                                                                                                this.chestX = num82;
                                                                                                this.chestY = num83;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.chest = num84;
                                                                                                Main.playerInventory = true;
                                                                                                Main.PlaySound(12, -1, -1, 1);
                                                                                                this.chestX = num82;
                                                                                                this.chestY = num83;
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
                                this.releaseUseTile = false;
                            }
                            else
                            {
                                this.releaseUseTile = true;
                            }
                        }
                    }
                    if (this.tongued)
                    {
                        bool flag14 = false;
                        if (Main.wof >= 0)
                        {
                            float num87 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2);
                            num87 += (float)(Main.npc[Main.wof].direction * 200);
                            float num88 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2);
                            Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                            float num89 = num87 - vector.X;
                            float num90 = num88 - vector.Y;
                            float num91 = (float)Math.Sqrt((double)(num89 * num89 + num90 * num90));
                            float num92 = 11f;
                            float num93 = num91;
                            if (num91 > num92)
                            {
                                num93 = num92 / num91;
                            }
                            else
                            {
                                num93 = 1f;
                                flag14 = true;
                            }
                            num89 *= num93;
                            num90 *= num93;
                            this.velocity.X = num89;
                            this.velocity.Y = num90;
                        }
                        else
                        {
                            flag14 = true;
                        }
                        if (flag14 && Main.myPlayer == this.whoAmi)
                        {
                            for (int num94 = 0; num94 < 10; num94++)
                            {
                                if (this.buffType[num94] == 38)
                                {
                                    this.DelBuff(num94);
                                }
                            }
                        }
                    }
                    if (Main.myPlayer == this.whoAmi)
                    {
                        if (Main.wof >= 0 && Main.npc[Main.wof].active)
                        {
                            float num95 = Main.npc[Main.wof].position.X + 40f;
                            if (Main.npc[Main.wof].direction > 0)
                            {
                                num95 -= 96f;
                            }
                            if (this.position.X + (float)this.width > num95 && this.position.X < num95 + 140f && this.gross)
                            {
                                this.noKnockback = false;
                                this.Hurt(50, Main.npc[Main.wof].direction, false, false, " was slain...", false);
                            }
                            if (!this.gross && this.position.Y > (float)((Main.maxTilesY - 250) * 16) && this.position.X > num95 - 1920f && this.position.X < num95 + 1920f)
                            {
                                this.AddBuff(37, 10, true);
                                Main.PlaySound(4, (int)Main.npc[Main.wof].position.X, (int)Main.npc[Main.wof].position.Y, 10);
                            }
                            if (this.gross)
                            {
                                if (this.position.Y < (float)((Main.maxTilesY - 200) * 16))
                                {
                                    this.AddBuff(38, 10, true);
                                }
                                if (Main.npc[Main.wof].direction < 0)
                                {
                                    if (this.position.X + (float)(this.width / 2) > Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) + 40f)
                                    {
                                        this.AddBuff(38, 10, true);
                                    }
                                }
                                else
                                {
                                    if (this.position.X + (float)(this.width / 2) < Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - 40f)
                                    {
                                        this.AddBuff(38, 10, true);
                                    }
                                }
                            }
                            if (this.tongued)
                            {
                                this.controlHook = false;
                                this.controlUseItem = false;
                                for (int num96 = 0; num96 < 1000; num96++)
                                {
                                    if (Main.projectile[num96].active && Main.projectile[num96].owner == Main.myPlayer && Main.projectile[num96].aiStyle == 7)
                                    {
                                        Main.projectile[num96].Kill();
                                    }
                                }
                                Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                float num97 = Main.npc[Main.wof].position.X + (float)(Main.npc[Main.wof].width / 2) - vector2.X;
                                float num98 = Main.npc[Main.wof].position.Y + (float)(Main.npc[Main.wof].height / 2) - vector2.Y;
                                float num99 = (float)Math.Sqrt((double)(num97 * num97 + num98 * num98));
                                if (num99 > 3000f)
                                {
                                    this.KillMe(1000.0, 0, false, " tried to escape.");
                                }
                                else
                                {
                                    if (Main.npc[Main.wof].position.X < 608f || Main.npc[Main.wof].position.X > (float)((Main.maxTilesX - 38) * 16))
                                    {
                                        this.KillMe(1000.0, 0, false, " was licked.");
                                    }
                                }
                            }
                        }
                        if (this.controlHook)
                        {
                            if (this.releaseHook)
                            {
                                this.QuickGrapple();
                            }
                            this.releaseHook = false;
                        }
                        else
                        {
                            this.releaseHook = true;
                        }
                        if (this.talkNPC >= 0)
                        {
                            Rectangle rectangle2 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
                            Rectangle value = new Rectangle((int)Main.npc[this.talkNPC].position.X, (int)Main.npc[this.talkNPC].position.Y, Main.npc[this.talkNPC].width, Main.npc[this.talkNPC].height);
                            if (!rectangle2.Intersects(value) || this.chest != -1 || !Main.npc[this.talkNPC].active)
                            {
                                if (this.chest == -1)
                                {
                                    Main.PlaySound(11, -1, -1, 1);
                                }
                                this.talkNPC = -1;
                                Main.npcChatText = "";
                            }
                        }
                        if (this.sign >= 0)
                        {
                            Rectangle rectangle3 = new Rectangle((int)(this.position.X + (float)(this.width / 2) - (float)(Player.tileRangeX * 16)), (int)(this.position.Y + (float)(this.height / 2) - (float)(Player.tileRangeY * 16)), Player.tileRangeX * 16 * 2, Player.tileRangeY * 16 * 2);
                            try
                            {
                                Rectangle value2 = new Rectangle(Main.sign[this.sign].x * 16, Main.sign[this.sign].y * 16, 32, 32);
                                if (!rectangle3.Intersects(value2))
                                {
                                    Main.PlaySound(11, -1, -1, 1);
                                    this.sign = -1;
                                    Main.editSign = false;
                                    Main.npcChatText = "";
                                }
                            }
                            catch
                            {
                                Main.PlaySound(11, -1, -1, 1);
                                this.sign = -1;
                                Main.editSign = false;
                                Main.npcChatText = "";
                            }
                        }
                        if (Main.editSign)
                        {
                            if (this.sign == -1)
                            {
                                Main.editSign = false;
                            }
                            else
                            {
                                Main.npcChatText = Main.GetInputText(Main.npcChatText);
                                if (Main.inputTextEnter)
                                {
                                    byte[] bytes = new byte[]
									{
										10
									};
                                    Main.npcChatText += Encoding.ASCII.GetString(bytes);
                                }
                            }
                        }
                        if (!this.immune)
                        {
                            Rectangle rectangle4 = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
                            for (int num100 = 0; num100 < 200; num100++)
                            {
                                if (Main.npc[num100].active && !Main.npc[num100].friendly && Main.npc[num100].damage > 0 && rectangle4.Intersects(new Rectangle((int)Main.npc[num100].position.X, (int)Main.npc[num100].position.Y, Main.npc[num100].width, Main.npc[num100].height)))
                                {
                                    int num101 = -1;
                                    if (Main.npc[num100].position.X + (float)(Main.npc[num100].width / 2) < this.position.X + (float)(this.width / 2))
                                    {
                                        num101 = 1;
                                    }
                                    int num102 = Main.DamageVar((float)Main.npc[num100].damage);
                                    if (this.whoAmi == Main.myPlayer && this.thorns && !this.immune && !Main.npc[num100].dontTakeDamage)
                                    {
                                        int num103 = num102 / 3;
                                        int num104 = 10;
                                        Main.npc[num100].StrikeNPC(num103, (float)num104, -num101, false, false);
                                        if (Main.netMode != 0)
                                        {
                                            NetMessage.SendData(28, -1, -1, "", num100, (float)num103, (float)num104, (float)(-(float)num101), 0);
                                        }
                                    }
                                    if (!this.immune)
                                    {
                                        if (((Main.npc[num100].type == 1 && Main.npc[num100].name == "Black Slime") || Main.npc[num100].type == 81 || Main.npc[num100].type == 79) && Main.rand.Next(4) == 0)
                                        {
                                            this.AddBuff(22, 900, true);
                                        }
                                        if ((Main.npc[num100].type == 23 || Main.npc[num100].type == 25) && Main.rand.Next(3) == 0)
                                        {
                                            this.AddBuff(24, 420, true);
                                        }
                                        if ((Main.npc[num100].type == 34 || Main.npc[num100].type == 83 || Main.npc[num100].type == 84) && Main.rand.Next(3) == 0)
                                        {
                                            this.AddBuff(23, 240, true);
                                        }
                                        if ((Main.npc[num100].type == 104 || Main.npc[num100].type == 102) && Main.rand.Next(8) == 0)
                                        {
                                            this.AddBuff(30, 2700, true);
                                        }
                                        if (Main.npc[num100].type == 75 && Main.rand.Next(10) == 0)
                                        {
                                            this.AddBuff(35, 420, true);
                                        }
                                        if ((Main.npc[num100].type == 79 || Main.npc[num100].type == 103) && Main.rand.Next(5) == 0)
                                        {
                                            this.AddBuff(35, 420, true);
                                        }
                                        if ((Main.npc[num100].type == 75 || Main.npc[num100].type == 78 || Main.npc[num100].type == 82) && Main.rand.Next(8) == 0)
                                        {
                                            this.AddBuff(32, 900, true);
                                        }
                                        if ((Main.npc[num100].type == 93 || Main.npc[num100].type == 109 || Main.npc[num100].type == 80) && Main.rand.Next(12) == 0)
                                        {
                                            this.AddBuff(31, 420, true);
                                        }
                                        if (Main.npc[num100].type == 77 && Main.rand.Next(6) == 0)
                                        {
                                            this.AddBuff(36, 18000, true);
                                        }
                                        if (Main.npc[num100].type == 112 && Main.rand.Next(20) == 0)
                                        {
                                            this.AddBuff(33, 18000, true);
                                        }
                                        if (Main.npc[num100].type == 141 && Main.rand.Next(2) == 0)
                                        {
                                            this.AddBuff(20, 600, true);
                                        }
                                    }
                                    this.Hurt(num102, num101, false, false, Lang.deathMsg(-1, num100, -1, -1), false);
                                }
                            }
                        }
                        Vector2 vector3 = Collision.HurtTiles(this.position, this.velocity, this.width, this.height, this.fireWalk);
                        if (vector3.Y != 0f)
                        {
                            int damage2 = Main.DamageVar(vector3.Y);
                            this.Hurt(damage2, 0, false, false, Lang.deathMsg(-1, -1, -1, 3), false);
                        }
                    }
                    if (this.grappling[0] >= 0)
                    {
                        this.wingFrame = 1;
                        if (this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02))
                        {
                            this.wingFrame = 0;
                        }
                        this.wingTime = 90;
                        this.rocketTime = this.rocketTimeMax;
                        this.rocketDelay = 0;
                        this.rocketFrame = false;
                        this.canRocket = false;
                        this.rocketRelease = false;
                        this.fallStart = (int)(this.position.Y / 16f);
                        float num105 = 0f;
                        float num106 = 0f;
                        for (int num107 = 0; num107 < this.grapCount; num107++)
                        {
                            num105 += Main.projectile[this.grappling[num107]].position.X + (float)(Main.projectile[this.grappling[num107]].width / 2);
                            num106 += Main.projectile[this.grappling[num107]].position.Y + (float)(Main.projectile[this.grappling[num107]].height / 2);
                        }
                        num105 /= (float)this.grapCount;
                        num106 /= (float)this.grapCount;
                        Vector2 vector4 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                        float num108 = num105 - vector4.X;
                        float num109 = num106 - vector4.Y;
                        float num110 = (float)Math.Sqrt((double)(num108 * num108 + num109 * num109));
                        float num111 = 11f;
                        float num112 = num110;
                        if (num110 > num111)
                        {
                            num112 = num111 / num110;
                        }
                        else
                        {
                            num112 = 1f;
                        }
                        num108 *= num112;
                        num109 *= num112;
                        this.velocity.X = num108;
                        this.velocity.Y = num109;
                        if (this.itemAnimation == 0)
                        {
                            if (this.velocity.X > 0f)
                            {
                                this.direction = 1;
                            }
                            if (this.velocity.X < 0f)
                            {
                                this.direction = -1;
                            }
                        }
                        if (this.controlJump)
                        {
                            if (this.releaseJump)
                            {
                                if ((this.velocity.Y == 0f || (this.wet && (double)this.velocity.Y > -0.02 && (double)this.velocity.Y < 0.02)) && !this.controlDown)
                                {
                                    this.velocity.Y = -Player.jumpSpeed;
                                    this.jump = Player.jumpHeight / 2;
                                    this.releaseJump = false;
                                }
                                else
                                {
                                    this.velocity.Y = this.velocity.Y + 0.01f;
                                    this.releaseJump = false;
                                }
                                if (this.doubleJump)
                                {
                                    this.jumpAgain = true;
                                }
                                this.grappling[0] = 0;
                                this.grapCount = 0;
                                for (int num113 = 0; num113 < 1000; num113++)
                                {
                                    if (Main.projectile[num113].active && Main.projectile[num113].owner == i && Main.projectile[num113].aiStyle == 7)
                                    {
                                        Main.projectile[num113].Kill();
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.releaseJump = true;
                        }
                    }
                    int num114 = this.width / 2;
                    int num115 = this.height / 2;
                    new Vector2(this.position.X + (float)(this.width / 2) - (float)(num114 / 2), this.position.Y + (float)(this.height / 2) - (float)(num115 / 2));
                    Vector2 vector5 = Collision.StickyTiles(this.position, this.velocity, this.width, this.height);
                    if (vector5.Y != -1f && vector5.X != -1f)
                    {
                        if (this.whoAmi == Main.myPlayer && (this.velocity.X != 0f || this.velocity.Y != 0f))
                        {
                            this.stickyBreak++;
                            if (this.stickyBreak > Main.rand.Next(20, 100))
                            {
                                this.stickyBreak = 0;
                                int num116 = (int)vector5.X;
                                int num117 = (int)vector5.Y;
                                WorldGen.KillTile(num116, num117, false, false, false);
                                if (Main.netMode == 1 && !Main.tile[num116, num117].active && Main.netMode == 1)
                                {
                                    NetMessage.SendData(17, -1, -1, "", 0, (float)num116, (float)num117, 0f, 0);
                                }
                            }
                        }
                        this.fallStart = (int)(this.position.Y / 16f);
                        this.jump = 0;
                        if (this.velocity.X > 1f)
                        {
                            this.velocity.X = 1f;
                        }
                        if (this.velocity.X < -1f)
                        {
                            this.velocity.X = -1f;
                        }
                        if (this.velocity.Y > 1f)
                        {
                            this.velocity.Y = 1f;
                        }
                        if (this.velocity.Y < -5f)
                        {
                            this.velocity.Y = -5f;
                        }
                        if ((double)this.velocity.X > 0.75 || (double)this.velocity.X < -0.75)
                        {
                            this.velocity.X = this.velocity.X * 0.85f;
                        }
                        else
                        {
                            this.velocity.X = this.velocity.X * 0.6f;
                        }
                        if (this.velocity.Y < 0f)
                        {
                            this.velocity.Y = this.velocity.Y * 0.96f;
                        }
                        else
                        {
                            this.velocity.Y = this.velocity.Y * 0.3f;
                        }
                    }
                    else
                    {
                        this.stickyBreak = 0;
                    }
                    bool flag15 = Collision.DrownCollision(this.position, this.width, this.height, this.gravDir);
                    if (this.armor[0].type == 250)
                    {
                        flag15 = true;
                    }
                    if (this.inventory[this.selectedItem].type == 186)
                    {
                        try
                        {
                            int num118 = (int)((this.position.X + (float)(this.width / 2) + (float)(6 * this.direction)) / 16f);
                            int num119 = 0;
                            if (this.gravDir == -1f)
                            {
                                num119 = this.height;
                            }
                            int num120 = (int)((this.position.Y + (float)num119 - 44f * this.gravDir) / 16f);
                            if (Main.tile[num118, num120].liquid < 128)
                            {
                                if (Main.tile[num118, num120] == null)
                                {
                                    Main.tile[num118, num120] = new Tile();
                                }
                                if (!Main.tile[num118, num120].active || !Main.tileSolid[(int)Main.tile[num118, num120].type] || Main.tileSolidTop[(int)Main.tile[num118, num120].type])
                                {
                                    flag15 = false;
                                }
                            }
                        }
                        catch
                        {
                        }
                    }
                    if (this.gills)
                    {
                        flag15 = !flag15;
                    }
                    if (Main.myPlayer == i)
                    {
                        if (this.merman)
                        {
                            flag15 = false;
                        }
                        if (flag15)
                        {
                            this.breathCD++;
                            int num121 = 7;
                            if (this.inventory[this.selectedItem].type == 186)
                            {
                                num121 *= 2;
                            }
                            if (this.accDivingHelm)
                            {
                                num121 *= 4;
                            }
                            if (this.breathCD >= num121)
                            {
                                this.breathCD = 0;
                                this.breath--;
                                if (this.breath == 0)
                                {
                                    Main.PlaySound(23, -1, -1, 1);
                                }
                                if (this.breath <= 0)
                                {
                                    this.lifeRegenTime = 0;
                                    this.breath = 0;
                                    this.statLife -= 2;
                                    if (this.statLife <= 0)
                                    {
                                        this.statLife = 0;
                                        this.KillMe(10.0, 0, false, Lang.deathMsg(-1, -1, -1, 1));
                                    }
                                }
                            }
                        }
                        else
                        {
                            this.breath += 3;
                            if (this.breath > this.breathMax)
                            {
                                this.breath = this.breathMax;
                            }
                            this.breathCD = 0;
                        }
                    }
                    if (flag15 && Main.rand.Next(20) == 0 && !this.lavaWet)
                    {
                        int num122 = 0;
                        if (this.gravDir == -1f)
                        {
                            num122 += this.height - 12;
                        }
                        if (this.inventory[this.selectedItem].type == 186)
                        {
                            Vector2 arg_859E_0 = new Vector2(this.position.X + (float)(10 * this.direction) + 4f, this.position.Y + (float)num122 - 54f * this.gravDir);
                            int arg_859E_1 = this.width - 8;
                            int arg_859E_2 = 8;
                            int arg_859E_3 = 34;
                            float arg_859E_4 = 0f;
                            float arg_859E_5 = 0f;
                            int arg_859E_6 = 0;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_859E_0, arg_859E_1, arg_859E_2, arg_859E_3, arg_859E_4, arg_859E_5, arg_859E_6, newColor, 1.2f);
                        }
                        else
                        {
                            Vector2 arg_8602_0 = new Vector2(this.position.X + (float)(12 * this.direction), this.position.Y + (float)num122 + 4f * this.gravDir);
                            int arg_8602_1 = this.width - 8;
                            int arg_8602_2 = 8;
                            int arg_8602_3 = 34;
                            float arg_8602_4 = 0f;
                            float arg_8602_5 = 0f;
                            int arg_8602_6 = 0;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_8602_0, arg_8602_1, arg_8602_2, arg_8602_3, arg_8602_4, arg_8602_5, arg_8602_6, newColor, 1.2f);
                        }
                    }
                    int num123 = this.height;
                    if (this.waterWalk)
                    {
                        num123 -= 6;
                    }
                    bool flag16 = Collision.LavaCollision(this.position, this.width, num123);
                    if (flag16)
                    {
                        if (!this.lavaImmune && Main.myPlayer == i && !this.immune)
                        {
                            this.AddBuff(24, 420, true);
                            this.Hurt(80, 0, false, false, Lang.deathMsg(-1, -1, -1, 2), false);
                        }
                        this.lavaWet = true;
                    }
                    bool flag17 = Collision.WetCollision(this.position, this.width, this.height);
                    if (flag17)
                    {
                        if (this.onFire && !this.lavaWet)
                        {
                            for (int num124 = 0; num124 < 10; num124++)
                            {
                                if (this.buffType[num124] == 24)
                                {
                                    this.DelBuff(num124);
                                }
                            }
                        }
                        if (!this.wet)
                        {
                            if (this.wetCount == 0)
                            {
                                this.wetCount = 10;
                                if (!flag16)
                                {
                                    for (int num125 = 0; num125 < 50; num125++)
                                    {
                                        Vector2 arg_8755_0 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
                                        int arg_8755_1 = this.width + 12;
                                        int arg_8755_2 = 24;
                                        int arg_8755_3 = 33;
                                        float arg_8755_4 = 0f;
                                        float arg_8755_5 = 0f;
                                        int arg_8755_6 = 0;
                                        Color newColor = default(Color);
                                        int num126 = Dust.NewDust(arg_8755_0, arg_8755_1, arg_8755_2, arg_8755_3, arg_8755_4, arg_8755_5, arg_8755_6, newColor, 1f);
                                        Dust expr_8769_cp_0 = Main.dust[num126];
                                        expr_8769_cp_0.velocity.Y = expr_8769_cp_0.velocity.Y - 4f;
                                        Dust expr_8787_cp_0 = Main.dust[num126];
                                        expr_8787_cp_0.velocity.X = expr_8787_cp_0.velocity.X * 2.5f;
                                        Main.dust[num126].scale = 1.3f;
                                        Main.dust[num126].alpha = 100;
                                        Main.dust[num126].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
                                }
                                else
                                {
                                    for (int num127 = 0; num127 < 20; num127++)
                                    {
                                        Vector2 arg_885B_0 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
                                        int arg_885B_1 = this.width + 12;
                                        int arg_885B_2 = 24;
                                        int arg_885B_3 = 35;
                                        float arg_885B_4 = 0f;
                                        float arg_885B_5 = 0f;
                                        int arg_885B_6 = 0;
                                        Color newColor = default(Color);
                                        int num128 = Dust.NewDust(arg_885B_0, arg_885B_1, arg_885B_2, arg_885B_3, arg_885B_4, arg_885B_5, arg_885B_6, newColor, 1f);
                                        Dust expr_886F_cp_0 = Main.dust[num128];
                                        expr_886F_cp_0.velocity.Y = expr_886F_cp_0.velocity.Y - 1.5f;
                                        Dust expr_888D_cp_0 = Main.dust[num128];
                                        expr_888D_cp_0.velocity.X = expr_888D_cp_0.velocity.X * 2.5f;
                                        Main.dust[num128].scale = 1.3f;
                                        Main.dust[num128].alpha = 100;
                                        Main.dust[num128].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                }
                            }
                            this.wet = true;
                        }
                    }
                    else
                    {
                        if (this.wet)
                        {
                            this.wet = false;
                            if (this.jump > Player.jumpHeight / 5)
                            {
                                this.jump = Player.jumpHeight / 5;
                            }
                            if (this.wetCount == 0)
                            {
                                this.wetCount = 10;
                                if (!this.lavaWet)
                                {
                                    for (int num129 = 0; num129 < 50; num129++)
                                    {
                                        Vector2 arg_89AE_0 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2));
                                        int arg_89AE_1 = this.width + 12;
                                        int arg_89AE_2 = 24;
                                        int arg_89AE_3 = 33;
                                        float arg_89AE_4 = 0f;
                                        float arg_89AE_5 = 0f;
                                        int arg_89AE_6 = 0;
                                        Color newColor = default(Color);
                                        int num130 = Dust.NewDust(arg_89AE_0, arg_89AE_1, arg_89AE_2, arg_89AE_3, arg_89AE_4, arg_89AE_5, arg_89AE_6, newColor, 1f);
                                        Dust expr_89C2_cp_0 = Main.dust[num130];
                                        expr_89C2_cp_0.velocity.Y = expr_89C2_cp_0.velocity.Y - 4f;
                                        Dust expr_89E0_cp_0 = Main.dust[num130];
                                        expr_89E0_cp_0.velocity.X = expr_89E0_cp_0.velocity.X * 2.5f;
                                        Main.dust[num130].scale = 1.3f;
                                        Main.dust[num130].alpha = 100;
                                        Main.dust[num130].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 0);
                                }
                                else
                                {
                                    for (int num131 = 0; num131 < 20; num131++)
                                    {
                                        Vector2 arg_8AB4_0 = new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f);
                                        int arg_8AB4_1 = this.width + 12;
                                        int arg_8AB4_2 = 24;
                                        int arg_8AB4_3 = 35;
                                        float arg_8AB4_4 = 0f;
                                        float arg_8AB4_5 = 0f;
                                        int arg_8AB4_6 = 0;
                                        Color newColor = default(Color);
                                        int num132 = Dust.NewDust(arg_8AB4_0, arg_8AB4_1, arg_8AB4_2, arg_8AB4_3, arg_8AB4_4, arg_8AB4_5, arg_8AB4_6, newColor, 1f);
                                        Dust expr_8AC8_cp_0 = Main.dust[num132];
                                        expr_8AC8_cp_0.velocity.Y = expr_8AC8_cp_0.velocity.Y - 1.5f;
                                        Dust expr_8AE6_cp_0 = Main.dust[num132];
                                        expr_8AE6_cp_0.velocity.X = expr_8AE6_cp_0.velocity.X * 2.5f;
                                        Main.dust[num132].scale = 1.3f;
                                        Main.dust[num132].alpha = 100;
                                        Main.dust[num132].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                }
                            }
                        }
                    }
                    if (!this.wet)
                    {
                        this.lavaWet = false;
                    }
                    if (this.wetCount > 0)
                    {
                        this.wetCount -= 1;
                    }
                    this.oldPosition = this.position;
                    if (this.tongued)
                    {
                        this.position += this.velocity;
                    }
                    else
                    {
                        if (this.wet && !this.merman)
                        {
                            Vector2 vector6 = this.velocity;
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                            Vector2 value3 = this.velocity * 0.5f;
                            if (this.velocity.X != vector6.X)
                            {
                                value3.X = this.velocity.X;
                            }
                            if (this.velocity.Y != vector6.Y)
                            {
                                value3.Y = this.velocity.Y;
                            }
                            this.position += value3;
                        }
                        else
                        {
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                            if (this.waterWalk)
                            {
                                this.velocity = Collision.WaterCollision(this.position, this.velocity, this.width, this.height, this.controlDown, false);
                            }
                            this.position += this.velocity;
                        }
                    }
                    if (this.velocity.Y == 0f)
                    {
                        if (this.gravDir == 1f && Collision.up)
                        {
                            this.velocity.Y = 0.01f;
                            if (!this.merman)
                            {
                                this.jump = 0;
                            }
                        }
                        else
                        {
                            if (this.gravDir == -1f && Collision.down)
                            {
                                this.velocity.Y = -0.01f;
                                if (!this.merman)
                                {
                                    this.jump = 0;
                                }
                            }
                        }
                    }
                    if (this.whoAmi == Main.myPlayer)
                    {
                        Collision.SwitchTiles(this.position, this.width, this.height, this.oldPosition);
                    }
                    if (this.position.X < Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
                    {
                        this.position.X = Main.leftWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
                        this.velocity.X = 0f;
                    }
                    if (this.position.X + (float)this.width > Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f)
                    {
                        this.position.X = Main.rightWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.width;
                        this.velocity.X = 0f;
                    }
                    if (this.position.Y < Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f)
                    {
                        this.position.Y = Main.topWorld + (float)(Lighting.offScreenTiles * 16) + 16f;
                        if ((double)this.velocity.Y < 0.11)
                        {
                            this.velocity.Y = 0.11f;
                        }
                    }
                    if (this.position.Y > Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height)
                    {
                        this.position.Y = Main.bottomWorld - (float)(Lighting.offScreenTiles * 16) - 32f - (float)this.height;
                        this.velocity.Y = 0f;
                    }
                    if (Main.ignoreErrors)
                    {
                        try
                        {
                            this.ItemCheck(i);
                            goto IL_8F18;
                        }
                        catch
                        {
                            goto IL_8F18;
                        }
                        goto IL_8F11;
                    }
                    goto IL_8F11;
                IL_8F18:
                    this.PlayerFrame();
                    if (this.statLife > this.statLifeMax)
                    {
                        this.statLife = this.statLifeMax;
                    }
                    this.grappling[0] = -1;
                    this.grapCount = 0;
                    return;
                IL_8F11:
                    this.ItemCheck(i);
                    goto IL_8F18;
                }
                this.wings = 0;
                this.poisoned = false;
                this.onFire = false;
                this.onFire2 = false;
                this.blind = false;
                this.gravDir = 1f;
                for (int num133 = 0; num133 < 10; num133++)
                {
                    this.buffTime[num133] = 0;
                    this.buffType[num133] = 0;
                }
                if (i == Main.myPlayer)
                {
                    Main.npcChatText = "";
                    Main.editSign = false;
                }
                this.grappling[0] = -1;
                this.grappling[1] = -1;
                this.grappling[2] = -1;
                this.sign = -1;
                this.talkNPC = -1;
                this.statLife = 0;
                this.channel = false;
                this.potionDelay = 0;
                this.chest = -1;
                this.changeItem = -1;
                this.itemAnimation = 0;
                this.immuneAlpha += 2;
                if (this.immuneAlpha > 255)
                {
                    this.immuneAlpha = 255;
                }
                this.headPosition += this.headVelocity;
                this.bodyPosition += this.bodyVelocity;
                this.legPosition += this.legVelocity;
                this.headRotation += this.headVelocity.X * 0.1f;
                this.bodyRotation += this.bodyVelocity.X * 0.1f;
                this.legRotation += this.legVelocity.X * 0.1f;
                this.headVelocity.Y = this.headVelocity.Y + 0.1f;
                this.bodyVelocity.Y = this.bodyVelocity.Y + 0.1f;
                this.legVelocity.Y = this.legVelocity.Y + 0.1f;
                this.headVelocity.X = this.headVelocity.X * 0.99f;
                this.bodyVelocity.X = this.bodyVelocity.X * 0.99f;
                this.legVelocity.X = this.legVelocity.X * 0.99f;
                if (this.difficulty == 2)
                {
                    if (this.respawnTimer > 0)
                    {
                        this.respawnTimer--;
                        return;
                    }
                    if (this.whoAmi == Main.myPlayer || Main.netMode == 2)
                    {
                        this.ghost = true;
                        return;
                    }
                }
                else
                {
                    this.respawnTimer--;
                    if (this.respawnTimer <= 0 && Main.myPlayer == this.whoAmi)
                    {
                        if (Main.mouseItem.type > 0)
                        {
                            Main.playerInventory = true;
                        }
                        this.Spawn();
                        return;
                    }
                }
            }
        }
        public bool SellItem(int price, int stack)
        {
            if (price <= 0)
            {
                return false;
            }
            Item[] array = new Item[48];
            for (int i = 0; i < 48; i++)
            {
                array[i] = new Item();
                array[i] = (Item)this.inventory[i].Clone();
            }
            int j = price / 5;
            j *= stack;
            if (j < 1)
            {
                j = 1;
            }
            bool flag = false;
            while (j >= 1000000)
            {
                if (flag)
                {
                    break;
                }
                int num = -1;
                for (int k = 43; k >= 0; k--)
                {
                    if (num == -1 && (this.inventory[k].type == 0 || this.inventory[k].stack == 0))
                    {
                        num = k;
                    }
                    while (this.inventory[k].type == 74 && this.inventory[k].stack < this.inventory[k].maxStack && j >= 1000000)
                    {
                        this.inventory[k].stack++;
                        j -= 1000000;
                        this.DoCoins(k);
                        if (this.inventory[k].stack == 0 && num == -1)
                        {
                            num = k;
                        }
                    }
                }
                if (j >= 1000000)
                {
                    if (num == -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        this.inventory[num].SetDefaults(74, false);
                        j -= 1000000;
                    }
                }
            }
            while (j >= 10000)
            {
                if (flag)
                {
                    break;
                }
                int num2 = -1;
                for (int l = 43; l >= 0; l--)
                {
                    if (num2 == -1 && (this.inventory[l].type == 0 || this.inventory[l].stack == 0))
                    {
                        num2 = l;
                    }
                    while (this.inventory[l].type == 73 && this.inventory[l].stack < this.inventory[l].maxStack && j >= 10000)
                    {
                        this.inventory[l].stack++;
                        j -= 10000;
                        this.DoCoins(l);
                        if (this.inventory[l].stack == 0 && num2 == -1)
                        {
                            num2 = l;
                        }
                    }
                }
                if (j >= 10000)
                {
                    if (num2 == -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        this.inventory[num2].SetDefaults(73, false);
                        j -= 10000;
                    }
                }
            }
            while (j >= 100)
            {
                if (flag)
                {
                    break;
                }
                int num3 = -1;
                for (int m = 43; m >= 0; m--)
                {
                    if (num3 == -1 && (this.inventory[m].type == 0 || this.inventory[m].stack == 0))
                    {
                        num3 = m;
                    }
                    while (this.inventory[m].type == 72 && this.inventory[m].stack < this.inventory[m].maxStack && j >= 100)
                    {
                        this.inventory[m].stack++;
                        j -= 100;
                        this.DoCoins(m);
                        if (this.inventory[m].stack == 0 && num3 == -1)
                        {
                            num3 = m;
                        }
                    }
                }
                if (j >= 100)
                {
                    if (num3 == -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        this.inventory[num3].SetDefaults(72, false);
                        j -= 100;
                    }
                }
            }
            while (j >= 1 && !flag)
            {
                int num4 = -1;
                for (int n = 43; n >= 0; n--)
                {
                    if (num4 == -1 && (this.inventory[n].type == 0 || this.inventory[n].stack == 0))
                    {
                        num4 = n;
                    }
                    while (this.inventory[n].type == 71 && this.inventory[n].stack < this.inventory[n].maxStack && j >= 1)
                    {
                        this.inventory[n].stack++;
                        j--;
                        this.DoCoins(n);
                        if (this.inventory[n].stack == 0 && num4 == -1)
                        {
                            num4 = n;
                        }
                    }
                }
                if (j >= 1)
                {
                    if (num4 == -1)
                    {
                        flag = true;
                    }
                    else
                    {
                        this.inventory[num4].SetDefaults(71, false);
                        j--;
                    }
                }
            }
            if (flag)
            {
                for (int num5 = 0; num5 < 48; num5++)
                {
                    this.inventory[num5] = (Item)array[num5].Clone();
                }
                return false;
            }
            return true;
        }
        public bool BuyItem(int price)
        {
            if (price == 0)
            {
                return true;
            }
            int num = 0;
            int i = price;
            Item[] array = new Item[44];
            for (int j = 0; j < 44; j++)
            {
                array[j] = new Item();
                array[j] = (Item)this.inventory[j].Clone();
                if (this.inventory[j].type == 71)
                {
                    num += this.inventory[j].stack;
                }
                if (this.inventory[j].type == 72)
                {
                    num += this.inventory[j].stack * 100;
                }
                if (this.inventory[j].type == 73)
                {
                    num += this.inventory[j].stack * 10000;
                }
                if (this.inventory[j].type == 74)
                {
                    num += this.inventory[j].stack * 1000000;
                }
            }
            if (num >= price)
            {
                i = price;
                while (i > 0)
                {
                    if (i >= 1000000)
                    {
                        for (int k = 0; k < 44; k++)
                        {
                            if (this.inventory[k].type == 74)
                            {
                                while (this.inventory[k].stack > 0 && i >= 1000000)
                                {
                                    i -= 1000000;
                                    this.inventory[k].stack--;
                                    if (this.inventory[k].stack == 0)
                                    {
                                        this.inventory[k].type = 0;
                                    }
                                }
                            }
                        }
                    }
                    if (i >= 10000)
                    {
                        for (int l = 0; l < 44; l++)
                        {
                            if (this.inventory[l].type == 73)
                            {
                                while (this.inventory[l].stack > 0 && i >= 10000)
                                {
                                    i -= 10000;
                                    this.inventory[l].stack--;
                                    if (this.inventory[l].stack == 0)
                                    {
                                        this.inventory[l].type = 0;
                                    }
                                }
                            }
                        }
                    }
                    if (i >= 100)
                    {
                        for (int m = 0; m < 44; m++)
                        {
                            if (this.inventory[m].type == 72)
                            {
                                while (this.inventory[m].stack > 0 && i >= 100)
                                {
                                    i -= 100;
                                    this.inventory[m].stack--;
                                    if (this.inventory[m].stack == 0)
                                    {
                                        this.inventory[m].type = 0;
                                    }
                                }
                            }
                        }
                    }
                    if (i >= 1)
                    {
                        for (int n = 0; n < 44; n++)
                        {
                            if (this.inventory[n].type == 71)
                            {
                                while (this.inventory[n].stack > 0 && i >= 1)
                                {
                                    i--;
                                    this.inventory[n].stack--;
                                    if (this.inventory[n].stack == 0)
                                    {
                                        this.inventory[n].type = 0;
                                    }
                                }
                            }
                        }
                    }
                    if (i > 0)
                    {
                        int num2 = -1;
                        for (int num3 = 43; num3 >= 0; num3--)
                        {
                            if (this.inventory[num3].type == 0 || this.inventory[num3].stack == 0)
                            {
                                num2 = num3;
                                break;
                            }
                        }
                        if (num2 < 0)
                        {
                            for (int num4 = 0; num4 < 44; num4++)
                            {
                                this.inventory[num4] = (Item)array[num4].Clone();
                            }
                            return false;
                        }
                        bool flag = true;
                        if (i >= 10000)
                        {
                            for (int num5 = 0; num5 < 48; num5++)
                            {
                                if (this.inventory[num5].type == 74 && this.inventory[num5].stack >= 1)
                                {
                                    this.inventory[num5].stack--;
                                    if (this.inventory[num5].stack == 0)
                                    {
                                        this.inventory[num5].type = 0;
                                    }
                                    this.inventory[num2].SetDefaults(73, false);
                                    this.inventory[num2].stack = 100;
                                    flag = false;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            if (i >= 100)
                            {
                                for (int num6 = 0; num6 < 44; num6++)
                                {
                                    if (this.inventory[num6].type == 73 && this.inventory[num6].stack >= 1)
                                    {
                                        this.inventory[num6].stack--;
                                        if (this.inventory[num6].stack == 0)
                                        {
                                            this.inventory[num6].type = 0;
                                        }
                                        this.inventory[num2].SetDefaults(72, false);
                                        this.inventory[num2].stack = 100;
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                            else
                            {
                                if (i >= 1)
                                {
                                    for (int num7 = 0; num7 < 44; num7++)
                                    {
                                        if (this.inventory[num7].type == 72 && this.inventory[num7].stack >= 1)
                                        {
                                            this.inventory[num7].stack--;
                                            if (this.inventory[num7].stack == 0)
                                            {
                                                this.inventory[num7].type = 0;
                                            }
                                            this.inventory[num2].SetDefaults(71, false);
                                            this.inventory[num2].stack = 100;
                                            flag = false;
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (flag)
                        {
                            if (i < 10000)
                            {
                                for (int num8 = 0; num8 < 44; num8++)
                                {
                                    if (this.inventory[num8].type == 73 && this.inventory[num8].stack >= 1)
                                    {
                                        this.inventory[num8].stack--;
                                        if (this.inventory[num8].stack == 0)
                                        {
                                            this.inventory[num8].type = 0;
                                        }
                                        this.inventory[num2].SetDefaults(72, false);
                                        this.inventory[num2].stack = 100;
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                            if (flag && i < 1000000)
                            {
                                for (int num9 = 0; num9 < 44; num9++)
                                {
                                    if (this.inventory[num9].type == 74 && this.inventory[num9].stack >= 1)
                                    {
                                        this.inventory[num9].stack--;
                                        if (this.inventory[num9].stack == 0)
                                        {
                                            this.inventory[num9].type = 0;
                                        }
                                        this.inventory[num2].SetDefaults(73, false);
                                        this.inventory[num2].stack = 100;
                                        flag = false;
                                        break;
                                    }
                                }
                            }
                        }
                    }
                }
                return true;
            }
            return false;
        }
        public void AdjTiles()
        {
            int num = 4;
            int num2 = 3;
            for (int i = 0; i < 150; i++)
            {
                this.oldAdjTile[i] = this.adjTile[i];
                this.adjTile[i] = false;
            }
            this.oldAdjWater = this.adjWater;
            this.adjWater = false;
            int num3 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
            int num4 = (int)((this.position.Y + (float)this.height) / 16f);
            for (int j = num3 - num; j <= num3 + num; j++)
            {
                for (int k = num4 - num2; k < num4 + num2; k++)
                {
                    if (Main.tile[j, k].active)
                    {
                        this.adjTile[(int)Main.tile[j, k].type] = true;
                        if (Main.tile[j, k].type == 77)
                        {
                            this.adjTile[17] = true;
                        }
                        if (Main.tile[j, k].type == 133)
                        {
                            this.adjTile[17] = true;
                            this.adjTile[77] = true;
                        }
                        if (Main.tile[j, k].type == 134)
                        {
                            this.adjTile[16] = true;
                        }
                    }
                    if (Main.tile[j, k].liquid > 200 && !Main.tile[j, k].lava)
                    {
                        this.adjWater = true;
                    }
                }
            }
            if (Main.playerInventory)
            {
                bool flag = false;
                for (int l = 0; l < 150; l++)
                {
                    if (this.oldAdjTile[l] != this.adjTile[l])
                    {
                        flag = true;
                        break;
                    }
                }
                if (this.adjWater != this.oldAdjWater)
                {
                    flag = true;
                }
                if (flag)
                {
                    Recipe.FindRecipes();
                }
            }
        }
        public void PlayerFrame()
        {
            if (this.swimTime > 0)
            {
                this.swimTime--;
                if (!this.wet)
                {
                    this.swimTime = 0;
                }
            }
            this.head = this.armor[0].headSlot;
            this.body = this.armor[1].bodySlot;
            this.legs = this.armor[2].legSlot;
            if (this.armor[8].headSlot >= 0)
            {
                this.head = this.armor[8].headSlot;
            }
            if (this.armor[9].bodySlot >= 0)
            {
                this.body = this.armor[9].bodySlot;
            }
            if (this.armor[10].legSlot >= 0)
            {
                this.legs = this.armor[10].legSlot;
            }
            if (this.wereWolf)
            {
                this.legs = 20;
                this.body = 21;
                this.head = 38;
            }
            if (this.merman)
            {
                this.head = 39;
                this.legs = 21;
                this.body = 22;
            }
            this.socialShadow = false;
            if (this.head == 5 && this.body == 5 && this.legs == 5)
            {
                this.socialShadow = true;
            }
            if (this.head == 5 && this.body == 5 && this.legs == 5 && Main.rand.Next(10) == 0)
            {
                Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 200, default(Color), 1.2f);
            }
            if (this.head == 6 && this.body == 6 && this.legs == 6 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
            {
                for (int i = 0; i < 2; i++)
                {
                    int num = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num].noGravity = true;
                    Main.dust[num].noLight = true;
                    Dust expr_2A5_cp_0 = Main.dust[num];
                    expr_2A5_cp_0.velocity.X = expr_2A5_cp_0.velocity.X - this.velocity.X * 0.5f;
                    Dust expr_2CE_cp_0 = Main.dust[num];
                    expr_2CE_cp_0.velocity.Y = expr_2CE_cp_0.velocity.Y - this.velocity.Y * 0.5f;
                }
            }
            if (this.head == 7 && this.body == 7 && this.legs == 7)
            {
                this.boneArmor = true;
            }
            if (this.head == 8 && this.body == 8 && this.legs == 8 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f)
            {
                int num2 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 40, 0f, 0f, 50, default(Color), 1.4f);
                Main.dust[num2].noGravity = true;
                Main.dust[num2].velocity.X = this.velocity.X * 0.25f;
                Main.dust[num2].velocity.Y = this.velocity.Y * 0.25f;
            }
            if (this.head == 9 && this.body == 9 && this.legs == 9 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 1f && !this.rocketFrame)
            {
                for (int j = 0; j < 2; j++)
                {
                    int num3 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 6, 0f, 0f, 100, default(Color), 2f);
                    Main.dust[num3].noGravity = true;
                    Main.dust[num3].noLight = true;
                    Dust expr_52D_cp_0 = Main.dust[num3];
                    expr_52D_cp_0.velocity.X = expr_52D_cp_0.velocity.X - this.velocity.X * 0.5f;
                    Dust expr_557_cp_0 = Main.dust[num3];
                    expr_557_cp_0.velocity.Y = expr_557_cp_0.velocity.Y - this.velocity.Y * 0.5f;
                }
            }
            if (this.body == 18 && this.legs == 17 && (this.head == 32 || this.head == 33 || this.head == 34) && Main.rand.Next(10) == 0)
            {
                int num4 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
                Main.dust[num4].fadeIn = 0.8f;
                Dust expr_65A = Main.dust[num4];
                expr_65A.velocity *= 0f;
            }
            if (this.body == 24 && this.legs == 23 && (this.head == 42 || this.head == 43 || this.head == 41) && this.velocity.X != 0f && this.velocity.Y != 0f && Main.rand.Next(10) == 0)
            {
                int num5 = Dust.NewDust(new Vector2(this.position.X - this.velocity.X * 2f, this.position.Y - 2f - this.velocity.Y * 2f), this.width, this.height, 43, 0f, 0f, 100, default(Color), 0.3f);
                Main.dust[num5].fadeIn = 0.8f;
                Dust expr_774 = Main.dust[num5];
                expr_774.velocity *= 0f;
            }
            this.bodyFrame.Width = 40;
            this.bodyFrame.Height = 56;
            this.legFrame.Width = 40;
            this.legFrame.Height = 56;
            this.bodyFrame.X = 0;
            this.legFrame.X = 0;
            if (this.itemAnimation > 0 && this.inventory[this.selectedItem].useStyle != 10)
            {
                if (this.inventory[this.selectedItem].useStyle == 1 || this.inventory[this.selectedItem].type == 0)
                {
                    if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                    }
                    else
                    {
                        if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 2;
                        }
                        else
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height;
                        }
                    }
                }
                else
                {
                    if (this.inventory[this.selectedItem].useStyle == 2)
                    {
                        if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.5)
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 3;
                        }
                        else
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 2;
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].useStyle == 3)
                        {
                            if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
                            {
                                this.bodyFrame.Y = this.bodyFrame.Height * 3;
                            }
                            else
                            {
                                this.bodyFrame.Y = this.bodyFrame.Height * 3;
                            }
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].useStyle == 4)
                            {
                                this.bodyFrame.Y = this.bodyFrame.Height * 2;
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].useStyle == 5)
                                {
                                    if (this.inventory[this.selectedItem].type == 281)
                                    {
                                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                                    }
                                    else
                                    {
                                        float num6 = this.itemRotation * (float)this.direction;
                                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                                        if ((double)num6 < -0.75)
                                        {
                                            this.bodyFrame.Y = this.bodyFrame.Height * 2;
                                            if (this.gravDir == -1f)
                                            {
                                                this.bodyFrame.Y = this.bodyFrame.Height * 4;
                                            }
                                        }
                                        if ((double)num6 > 0.6)
                                        {
                                            this.bodyFrame.Y = this.bodyFrame.Height * 4;
                                            if (this.gravDir == -1f)
                                            {
                                                this.bodyFrame.Y = this.bodyFrame.Height * 2;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.inventory[this.selectedItem].holdStyle == 1 && (!this.wet || !this.inventory[this.selectedItem].noWet))
                {
                    this.bodyFrame.Y = this.bodyFrame.Height * 3;
                }
                else
                {
                    if (this.inventory[this.selectedItem].holdStyle == 2 && (!this.wet || !this.inventory[this.selectedItem].noWet))
                    {
                        this.bodyFrame.Y = this.bodyFrame.Height * 2;
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].holdStyle == 3)
                        {
                            this.bodyFrame.Y = this.bodyFrame.Height * 3;
                        }
                        else
                        {
                            if (this.grappling[0] >= 0)
                            {
                                Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                float num7 = 0f;
                                float num8 = 0f;
                                for (int k = 0; k < this.grapCount; k++)
                                {
                                    num7 += Main.projectile[this.grappling[k]].position.X + (float)(Main.projectile[this.grappling[k]].width / 2);
                                    num8 += Main.projectile[this.grappling[k]].position.Y + (float)(Main.projectile[this.grappling[k]].height / 2);
                                }
                                num7 /= (float)this.grapCount;
                                num8 /= (float)this.grapCount;
                                num7 -= vector.X;
                                num8 -= vector.Y;
                                if (num8 < 0f && Math.Abs(num8) > Math.Abs(num7))
                                {
                                    this.bodyFrame.Y = this.bodyFrame.Height * 2;
                                    if (this.gravDir == -1f)
                                    {
                                        this.bodyFrame.Y = this.bodyFrame.Height * 4;
                                    }
                                }
                                else
                                {
                                    if (num8 > 0f && Math.Abs(num8) > Math.Abs(num7))
                                    {
                                        this.bodyFrame.Y = this.bodyFrame.Height * 4;
                                        if (this.gravDir == -1f)
                                        {
                                            this.bodyFrame.Y = this.bodyFrame.Height * 2;
                                        }
                                    }
                                    else
                                    {
                                        this.bodyFrame.Y = this.bodyFrame.Height * 3;
                                    }
                                }
                            }
                            else
                            {
                                if (this.swimTime > 0)
                                {
                                    if (this.swimTime > 20)
                                    {
                                        this.bodyFrame.Y = 0;
                                    }
                                    else
                                    {
                                        if (this.swimTime > 10)
                                        {
                                            this.bodyFrame.Y = this.bodyFrame.Height * 5;
                                        }
                                        else
                                        {
                                            this.bodyFrame.Y = 0;
                                        }
                                    }
                                }
                                else
                                {
                                    if (this.velocity.Y != 0f)
                                    {
                                        if (this.wings > 0)
                                        {
                                            if (this.velocity.Y > 0f)
                                            {
                                                if (this.controlJump)
                                                {
                                                    this.bodyFrame.Y = this.bodyFrame.Height * 6;
                                                }
                                                else
                                                {
                                                    this.bodyFrame.Y = this.bodyFrame.Height * 5;
                                                }
                                            }
                                            else
                                            {
                                                this.bodyFrame.Y = this.bodyFrame.Height * 6;
                                            }
                                        }
                                        else
                                        {
                                            this.bodyFrame.Y = this.bodyFrame.Height * 5;
                                        }
                                        this.bodyFrameCounter = 0.0;
                                    }
                                    else
                                    {
                                        if (this.velocity.X != 0f)
                                        {
                                            this.bodyFrameCounter += (double)Math.Abs(this.velocity.X) * 1.5;
                                            this.bodyFrame.Y = this.legFrame.Y;
                                        }
                                        else
                                        {
                                            this.bodyFrameCounter = 0.0;
                                            this.bodyFrame.Y = 0;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.swimTime > 0)
            {
                this.legFrameCounter += 2.0;
                while (this.legFrameCounter > 8.0)
                {
                    this.legFrameCounter -= 8.0;
                    this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
                }
                if (this.legFrame.Y < this.legFrame.Height * 7)
                {
                    this.legFrame.Y = this.legFrame.Height * 19;
                    return;
                }
                if (this.legFrame.Y > this.legFrame.Height * 19)
                {
                    this.legFrame.Y = this.legFrame.Height * 7;
                    return;
                }
            }
            else
            {
                if (this.velocity.Y != 0f || this.grappling[0] > -1)
                {
                    this.legFrameCounter = 0.0;
                    this.legFrame.Y = this.legFrame.Height * 5;
                    return;
                }
                if (this.velocity.X != 0f)
                {
                    this.legFrameCounter += (double)Math.Abs(this.velocity.X) * 1.3;
                    while (this.legFrameCounter > 8.0)
                    {
                        this.legFrameCounter -= 8.0;
                        this.legFrame.Y = this.legFrame.Y + this.legFrame.Height;
                    }
                    if (this.legFrame.Y < this.legFrame.Height * 7)
                    {
                        this.legFrame.Y = this.legFrame.Height * 19;
                        return;
                    }
                    if (this.legFrame.Y > this.legFrame.Height * 19)
                    {
                        this.legFrame.Y = this.legFrame.Height * 7;
                        return;
                    }
                }
                else
                {
                    this.legFrameCounter = 0.0;
                    this.legFrame.Y = 0;
                }
            }
        }
        public void Spawn()
        {
            if (this.whoAmi == Main.myPlayer)
            {
                Main.quickBG = 10;
                this.FindSpawn();
                if (!Player.CheckSpawn(this.SpawnX, this.SpawnY))
                {
                    this.SpawnX = -1;
                    this.SpawnY = -1;
                }
                Main.maxQ = true;
            }
            if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
            {
                NetMessage.SendData(12, -1, -1, "", Main.myPlayer, 0f, 0f, 0f, 0);
                Main.gameMenu = false;
            }
            this.headPosition = default(Vector2);
            this.bodyPosition = default(Vector2);
            this.legPosition = default(Vector2);
            this.headRotation = 0f;
            this.bodyRotation = 0f;
            this.legRotation = 0f;
            if (this.statLife <= 0)
            {
                this.statLife = 100;
                this.breath = this.breathMax;
                if (this.spawnMax)
                {
                    this.statLife = this.statLifeMax;
                    this.statMana = this.statManaMax2;
                }
            }
            this.immune = true;
            this.dead = false;
            this.immuneTime = 0;
            this.active = true;
            if (this.SpawnX >= 0 && this.SpawnY >= 0)
            {
                this.position.X = (float)(this.SpawnX * 16 + 8 - this.width / 2);
                this.position.Y = (float)(this.SpawnY * 16 - this.height);
            }
            else
            {
                this.position.X = (float)(Main.spawnTileX * 16 + 8 - this.width / 2);
                this.position.Y = (float)(Main.spawnTileY * 16 - this.height);
                for (int i = Main.spawnTileX - 1; i < Main.spawnTileX + 2; i++)
                {
                    for (int j = Main.spawnTileY - 3; j < Main.spawnTileY; j++)
                    {
                        if (Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
                        {
                            WorldGen.KillTile(i, j, false, false, false);
                        }
                        if (Main.tile[i, j].liquid > 0)
                        {
                            Main.tile[i, j].lava = false;
                            Main.tile[i, j].liquid = 0;
                            WorldGen.SquareTileFrame(i, j, true);
                        }
                    }
                }
            }
            this.wet = false;
            this.wetCount = 0;
            this.lavaWet = false;
            this.fallStart = (int)(this.position.Y / 16f);
            this.velocity.X = 0f;
            this.velocity.Y = 0f;
            this.talkNPC = -1;
            if (this.pvpDeath)
            {
                this.pvpDeath = false;
                this.immuneTime = 300;
                this.statLife = this.statLifeMax;
            }
            else
            {
                this.immuneTime = 60;
            }
            if (this.whoAmi == Main.myPlayer)
            {
                Main.renderNow = true;
                if (Main.netMode == 1)
                {
                    Netplay.newRecent();
                }
                Main.screenPosition.X = this.position.X + (float)(this.width / 2) - (float)(Main.screenWidth / 2);
                Main.screenPosition.Y = this.position.Y + (float)(this.height / 2) - (float)(Main.screenHeight / 2);
            }
        }
        public double Hurt(int Damage, int hitDirection, bool pvp = false, bool quiet = false, string deathText = " was slain...", bool Crit = false)
        {
            if (!this.immune && !godMode)
            {
                int num = Damage;
                if (pvp)
                {
                    num *= 2;
                }
                double num2 = Main.CalculateDamage(num, this.statDefense);
                if (Crit)
                {
                    num *= 2;
                }
                if (num2 >= 1.0)
                {
                    if (Main.netMode == 1 && this.whoAmi == Main.myPlayer && !quiet)
                    {
                        int num3 = 0;
                        if (pvp)
                        {
                            num3 = 1;
                        }
                        NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        NetMessage.SendData(16, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        NetMessage.SendData(26, -1, -1, "", this.whoAmi, (float)hitDirection, (float)Damage, (float)num3, 0);
                    }
                    CombatText.NewText(new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height), new Color(255, 80, 90, 255), string.Concat((int)num2), Crit);
                    this.statLife -= (int)num2;
                    this.immune = true;
                    this.immuneTime = 40;
                    if (this.longInvince)
                    {
                        this.immuneTime += 40;
                    }
                    this.lifeRegenTime = 0;
                    if (pvp)
                    {
                        this.immuneTime = 8;
                    }
                    if (this.whoAmi == Main.myPlayer && this.starCloak)
                    {
                        for (int i = 0; i < 3; i++)
                        {
                            float x = this.position.X + (float)Main.rand.Next(-400, 400);
                            float y = this.position.Y - (float)Main.rand.Next(500, 800);
                            Vector2 vector = new Vector2(x, y);
                            float num4 = this.position.X + (float)(this.width / 2) - vector.X;
                            float num5 = this.position.Y + (float)(this.height / 2) - vector.Y;
                            num4 += (float)Main.rand.Next(-100, 101);
                            int num6 = 23;
                            float num7 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                            num7 = (float)num6 / num7;
                            num4 *= num7;
                            num5 *= num7;
                            int num8 = Projectile.NewProjectile(x, y, num4, num5, 92, 30, 5f, this.whoAmi);
                            Main.projectile[num8].ai[1] = this.position.Y;
                        }
                    }
                    if (!this.noKnockback && hitDirection != 0)
                    {
                        this.velocity.X = 4.5f * (float)hitDirection;
                        this.velocity.Y = -3.5f;
                    }
                    if (this.wereWolf)
                    {
                        Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 6);
                    }
                    else
                    {
                        if (this.boneArmor)
                        {
                            Main.PlaySound(3, (int)this.position.X, (int)this.position.Y, 2);
                        }
                        else
                        {
                            if (!this.male)
                            {
                                Main.PlaySound(20, (int)this.position.X, (int)this.position.Y, 1);
                            }
                            else
                            {
                                Main.PlaySound(1, (int)this.position.X, (int)this.position.Y, 1);
                            }
                        }
                    }
                    if (this.statLife > 0)
                    {
                        int num9 = 0;
                        while ((double)num9 < num2 / (double)this.statLifeMax * 100.0)
                        {
                            if (this.boneArmor)
                            {
                                Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
                            }
                            else
                            {
                                Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
                            }
                            num9++;
                        }
                    }
                    else
                    {
                        this.statLife = 0;
                        if (this.whoAmi == Main.myPlayer)
                        {
                            this.KillMe(num2, hitDirection, pvp, deathText);
                        }
                    }
                }
                if (pvp)
                {
                    num2 = Main.CalculateDamage(num, this.statDefense);
                }
                return num2;
            }
            return 0.0;
        }
        public void KillMeForGood()
        {
            if (File.Exists(Main.playerPathName))
            {
                File.Delete(Main.playerPathName);
            }
            if (File.Exists(Main.playerPathName + ".bak"))
            {
                File.Delete(Main.playerPathName + ".bak");
            }
            if (File.Exists(Main.playerPathName + ".dat"))
            {
                File.Delete(Main.playerPathName + ".dat");
            }
            Main.playerPathName = "";
        }
        public void KillMe(double dmg, int hitDirection, bool pvp = false, string deathText = " was slain...")
        {
            if (this.dead)
            {
                return;
            }
            if (pvp)
            {
                this.pvpDeath = true;
            }
            if (this.difficulty == 0)
            {
                if (Main.netMode != 1)
                {
                    float num = (float)Main.rand.Next(-35, 36) * 0.1f;
                    while (num < 2f && num > -2f)
                    {
                        num += (float)Main.rand.Next(-30, 31) * 0.1f;
                    }
                    int num2 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num, (float)Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0f, Main.myPlayer);
                    Main.projectile[num2].miscText = this.name + deathText;
                }
            }
            else
            {
                if (Main.netMode != 1)
                {
                    float num3 = (float)Main.rand.Next(-35, 36) * 0.1f;
                    while (num3 < 2f && num3 > -2f)
                    {
                        num3 += (float)Main.rand.Next(-30, 31) * 0.1f;
                    }
                    int num4 = Projectile.NewProjectile(this.position.X + (float)(this.width / 2), this.position.Y + (float)(this.head / 2), (float)Main.rand.Next(10, 30) * 0.1f * (float)hitDirection + num3, (float)Main.rand.Next(-40, -20) * 0.1f, 43, 0, 0f, Main.myPlayer);
                    Main.projectile[num4].miscText = this.name + deathText;
                }
                if (Main.myPlayer == this.whoAmi)
                {
                    Main.trashItem.SetDefaults(0, false);
                    if (this.difficulty == 1)
                    {
                        this.DropItems();
                    }
                    else
                    {
                        if (this.difficulty == 2)
                        {
                            this.DropItems();
                            this.KillMeForGood();
                        }
                    }
                }
            }
            Main.PlaySound(5, (int)this.position.X, (int)this.position.Y, 1);
            this.headVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            this.bodyVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            this.legVelocity.Y = (float)Main.rand.Next(-40, -10) * 0.1f;
            this.headVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
            this.bodyVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
            this.legVelocity.X = (float)Main.rand.Next(-20, 21) * 0.1f + (float)(2 * hitDirection);
            int num5 = 0;
            while ((double)num5 < 20.0 + dmg / (double)this.statLifeMax * 100.0)
            {
                if (this.boneArmor)
                {
                    Dust.NewDust(this.position, this.width, this.height, 26, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
                }
                else
                {
                    Dust.NewDust(this.position, this.width, this.height, 5, (float)(2 * hitDirection), -2f, 0, default(Color), 1f);
                }
                num5++;
            }
            this.dead = true;
            this.respawnTimer = 600;
            this.immuneAlpha = 0;
            if (Main.netMode == 2)
            {
                NetMessage.SendData(25, -1, -1, this.name + deathText, 255, 225f, 25f, 25f, 0);
            }
            else
            {
                if (Main.netMode == 0)
                {
                    Main.NewText(this.name + deathText, 225, 25, 25);
                }
            }
            if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
            {
                int num6 = 0;
                if (pvp)
                {
                    num6 = 1;
                }
                NetMessage.SendData(44, -1, -1, deathText, this.whoAmi, (float)hitDirection, (float)((int)dmg), (float)num6, 0);
            }
            if (!pvp && this.whoAmi == Main.myPlayer && this.difficulty == 0)
            {
                this.DropCoins();
            }
            if (this.whoAmi == Main.myPlayer)
            {
                try
                {
                    WorldGen.saveToonWhilePlaying();
                }
                catch
                {
                }
            }
        }
        public bool ItemSpace(Item newItem)
        {
            if (newItem.type == 58)
            {
                return true;
            }
            if (newItem.type == 184)
            {
                return true;
            }
            int num = 40;
            if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
            {
                num = 44;
            }
            for (int i = 0; i < num; i++)
            {
                if (this.inventory[i].type == 0)
                {
                    return true;
                }
            }
            for (int j = 0; j < num; j++)
            {
                if (this.inventory[j].type > 0 && this.inventory[j].stack < this.inventory[j].maxStack && newItem.IsTheSameAs(this.inventory[j]))
                {
                    return true;
                }
            }
            if (newItem.ammo > 0)
            {
                if (newItem.type != 75 && newItem.type != 169 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
                {
                    for (int k = 44; k < 48; k++)
                    {
                        if (this.inventory[k].type == 0)
                        {
                            return true;
                        }
                    }
                }
                for (int l = 44; l < 48; l++)
                {
                    if (this.inventory[l].type > 0 && this.inventory[l].stack < this.inventory[l].maxStack && newItem.IsTheSameAs(this.inventory[l]))
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        public void DoCoins(int i)
        {
            if (this.inventory[i].stack == 100 && (this.inventory[i].type == 71 || this.inventory[i].type == 72 || this.inventory[i].type == 73))
            {
                this.inventory[i].SetDefaults(this.inventory[i].type + 1, false);
                for (int j = 0; j < 44; j++)
                {
                    if (this.inventory[j].IsTheSameAs(this.inventory[i]) && j != i && this.inventory[j].stack < this.inventory[j].maxStack)
                    {
                        this.inventory[j].stack++;
                        this.inventory[i].SetDefaults(0, false);
                        this.inventory[i].active = false;
                        this.inventory[i].name = "";
                        this.inventory[i].type = 0;
                        this.inventory[i].stack = 0;
                        this.DoCoins(j);
                    }
                }
            }
        }
        public Item FillAmmo(int plr, Item newItem)
        {
            for (int i = 44; i < 48; i++)
            {
                if (this.inventory[i].type > 0 && this.inventory[i].stack < this.inventory[i].maxStack && newItem.IsTheSameAs(this.inventory[i]))
                {
                    Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                    if (newItem.stack + this.inventory[i].stack <= this.inventory[i].maxStack)
                    {
                        this.inventory[i].stack += newItem.stack;
                        ItemText.NewText(newItem, newItem.stack);
                        this.DoCoins(i);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                    newItem.stack -= this.inventory[i].maxStack - this.inventory[i].stack;
                    ItemText.NewText(newItem, this.inventory[i].maxStack - this.inventory[i].stack);
                    this.inventory[i].stack = this.inventory[i].maxStack;
                    this.DoCoins(i);
                    if (plr == Main.myPlayer)
                    {
                        Recipe.FindRecipes();
                    }
                }
            }
            if (newItem.type != 169 && newItem.type != 75 && newItem.type != 23 && newItem.type != 408 && newItem.type != 370)
            {
                for (int j = 44; j < 48; j++)
                {
                    if (this.inventory[j].type == 0)
                    {
                        this.inventory[j] = newItem;
                        ItemText.NewText(newItem, newItem.stack);
                        this.DoCoins(j);
                        Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                }
            }
            return newItem;
        }
        public Item GetItem(int plr, Item newItem)
        {
            Item item = newItem;
            int num = 40;
            if (newItem.noGrabDelay > 0)
            {
                return item;
            }
            int num2 = 0;
            if (newItem.type == 71 || newItem.type == 72 || newItem.type == 73 || newItem.type == 74)
            {
                num2 = -4;
                num = 44;
            }
            if (item.ammo > 0)
            {
                item = this.FillAmmo(plr, item);
                if (item.type == 0 || item.stack == 0)
                {
                    return new Item();
                }
            }
            for (int i = num2; i < 40; i++)
            {
                int num3 = i;
                if (num3 < 0)
                {
                    num3 = 44 + i;
                }
                if (this.inventory[num3].type > 0 && this.inventory[num3].stack < this.inventory[num3].maxStack && item.IsTheSameAs(this.inventory[num3]))
                {
                    Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                    if (item.stack + this.inventory[num3].stack <= this.inventory[num3].maxStack)
                    {
                        this.inventory[num3].stack += item.stack;
                        ItemText.NewText(newItem, item.stack);
                        this.DoCoins(num3);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                    item.stack -= this.inventory[num3].maxStack - this.inventory[num3].stack;
                    ItemText.NewText(newItem, this.inventory[num3].maxStack - this.inventory[num3].stack);
                    this.inventory[num3].stack = this.inventory[num3].maxStack;
                    this.DoCoins(num3);
                    if (plr == Main.myPlayer)
                    {
                        Recipe.FindRecipes();
                    }
                }
            }
            if (newItem.type != 71 && newItem.type != 72 && newItem.type != 73 && newItem.type != 74 && newItem.useStyle > 0)
            {
                for (int j = 0; j < 10; j++)
                {
                    if (this.inventory[j].type == 0)
                    {
                        this.inventory[j] = item;
                        ItemText.NewText(newItem, newItem.stack);
                        this.DoCoins(j);
                        Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                        if (plr == Main.myPlayer)
                        {
                            Recipe.FindRecipes();
                        }
                        return new Item();
                    }
                }
            }
            for (int k = num - 1; k >= 0; k--)
            {
                if (this.inventory[k].type == 0)
                {
                    this.inventory[k] = item;
                    ItemText.NewText(newItem, newItem.stack);
                    this.DoCoins(k);
                    Main.PlaySound(7, (int)this.position.X, (int)this.position.Y, 1);
                    if (plr == Main.myPlayer)
                    {
                        Recipe.FindRecipes();
                    }
                    return new Item();
                }
            }
            return item;
        }
        public void PlaceThing()
        {
            if (this.inventory[this.selectedItem].createTile >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
            {
                this.showItemIcon = true;
                bool flag = false;
                if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                {
                    if (Main.tileSolid[this.inventory[this.selectedItem].createTile])
                    {
                        flag = true;
                    }
                    else
                    {
                        if (Main.tileLavaDeath[this.inventory[this.selectedItem].createTile])
                        {
                            flag = true;
                        }
                    }
                }
                if (((!Main.tile[Player.tileTargetX, Player.tileTargetY].active && !flag) || Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109 || this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70) && this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
                {
                    bool flag2 = false;
                    if (this.inventory[this.selectedItem].createTile == 23 || this.inventory[this.selectedItem].createTile == 2 || this.inventory[this.selectedItem].createTile == 109)
                    {
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0)
                        {
                            flag2 = true;
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].createTile == 60 || this.inventory[this.selectedItem].createTile == 70)
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59)
                            {
                                flag2 = true;
                            }
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].createTile == 4 || this.inventory[this.selectedItem].createTile == 136)
                            {
                                int num = (int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type;
                                int num2 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type;
                                int num3 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type;
                                int num4 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
                                int num5 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].type;
                                int num6 = (int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].type;
                                int num7 = (int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].type;
                                if (!Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active)
                                {
                                    num = -1;
                                }
                                if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active)
                                {
                                    num2 = -1;
                                }
                                if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active)
                                {
                                    num3 = -1;
                                }
                                if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY - 1].active)
                                {
                                    num4 = -1;
                                }
                                if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY - 1].active)
                                {
                                    num5 = -1;
                                }
                                if (!Main.tile[Player.tileTargetX - 1, Player.tileTargetY + 1].active)
                                {
                                    num6 = -1;
                                }
                                if (!Main.tile[Player.tileTargetX + 1, Player.tileTargetY + 1].active)
                                {
                                    num7 = -1;
                                }
                                if (num >= 0 && Main.tileSolid[num] && !Main.tileNoAttach[num])
                                {
                                    flag2 = true;
                                }
                                else
                                {
                                    if ((num2 >= 0 && Main.tileSolid[num2] && !Main.tileNoAttach[num2]) || (num2 == 5 && num4 == 5 && num6 == 5) || num2 == 124)
                                    {
                                        flag2 = true;
                                    }
                                    else
                                    {
                                        if ((num3 >= 0 && Main.tileSolid[num3] && !Main.tileNoAttach[num3]) || (num3 == 5 && num5 == 5 && num7 == 5) || num3 == 124)
                                        {
                                            flag2 = true;
                                        }
                                    }
                                }
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].createTile == 78 || this.inventory[this.selectedItem].createTile == 98 || this.inventory[this.selectedItem].createTile == 100)
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type]))
                                    {
                                        flag2 = true;
                                    }
                                }
                                else
                                {
                                    if (this.inventory[this.selectedItem].createTile == 13 || this.inventory[this.selectedItem].createTile == 29 || this.inventory[this.selectedItem].createTile == 33 || this.inventory[this.selectedItem].createTile == 49 || this.inventory[this.selectedItem].createTile == 50 || this.inventory[this.selectedItem].createTile == 103)
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && Main.tileTable[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type])
                                        {
                                            flag2 = true;
                                        }
                                    }
                                    else
                                    {
                                        if (this.inventory[this.selectedItem].createTile == 51)
                                        {
                                            if (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
                                            {
                                                flag2 = true;
                                            }
                                        }
                                        else
                                        {
                                            if ((Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active && Main.tileSolid[(int)Main.tile[Player.tileTargetX + 1, Player.tileTargetY].type]) || (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active && Main.tileSolid[(int)Main.tile[Player.tileTargetX - 1, Player.tileTargetY].type])) || (Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type == 124))) || (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || (Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active && (Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type] || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].type == 124))) || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0)
                                            {
                                                flag2 = true;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (Main.tileAlch[this.inventory[this.selectedItem].createTile])
                    {
                        flag2 = true;
                    }
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.tileCut[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                    {
                        if (Main.tile[Player.tileTargetX, Player.tileTargetY + 1].type != 78)
                        {
                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                            if (!Main.tile[Player.tileTargetX, Player.tileTargetY].active && Main.netMode == 1)
                            {
                                NetMessage.SendData(17, -1, -1, "", 4, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                            }
                        }
                        else
                        {
                            flag2 = false;
                        }
                    }
                    if (flag2)
                    {
                        int num8 = this.inventory[this.selectedItem].placeStyle;
                        if (this.inventory[this.selectedItem].createTile == 141)
                        {
                            num8 = Main.rand.Next(2);
                        }
                        if (this.inventory[this.selectedItem].createTile == 128 || this.inventory[this.selectedItem].createTile == 137)
                        {
                            if (this.direction < 0)
                            {
                                num8 = -1;
                            }
                            else
                            {
                                num8 = 1;
                            }
                        }
                        if (WorldGen.PlaceTile(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createTile, false, false, this.whoAmi, num8))
                        {
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(17, -1, -1, "", 1, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createTile, num8);
                            }
                            if (this.inventory[this.selectedItem].createTile == 15)
                            {
                                if (this.direction == 1)
                                {
                                    Tile expr_C51 = Main.tile[Player.tileTargetX, Player.tileTargetY];
                                    expr_C51.frameX += 18;
                                    Tile expr_C76 = Main.tile[Player.tileTargetX, Player.tileTargetY - 1];
                                    expr_C76.frameX += 18;
                                }
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendTileSquare(-1, Player.tileTargetX - 1, Player.tileTargetY - 1, 3);
                                }
                            }
                            else
                            {
                                if ((this.inventory[this.selectedItem].createTile == 79 || this.inventory[this.selectedItem].createTile == 90) && Main.netMode == 1)
                                {
                                    NetMessage.SendTileSquare(-1, Player.tileTargetX, Player.tileTargetY, 5);
                                }
                            }
                        }
                    }
                }
            }
            if (this.inventory[this.selectedItem].createWall >= 0 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
            {
                this.showItemIcon = true;
                if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem && (Main.tile[Player.tileTargetX + 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX + 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].active || Main.tile[Player.tileTargetX - 1, Player.tileTargetY].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY + 1].wall > 0 || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].active || Main.tile[Player.tileTargetX, Player.tileTargetY - 1].wall > 0) && (int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall != this.inventory[this.selectedItem].createWall)
                {
                    WorldGen.PlaceWall(Player.tileTargetX, Player.tileTargetY, this.inventory[this.selectedItem].createWall, false);
                    if ((int)Main.tile[Player.tileTargetX, Player.tileTargetY].wall == this.inventory[this.selectedItem].createWall)
                    {
                        this.itemTime = this.inventory[this.selectedItem].useTime;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(17, -1, -1, "", 3, (float)Player.tileTargetX, (float)Player.tileTargetY, (float)this.inventory[this.selectedItem].createWall, 0);
                        }
                        if (this.inventory[this.selectedItem].stack > 1)
                        {
                            int createWall = this.inventory[this.selectedItem].createWall;
                            for (int i = 0; i < 4; i++)
                            {
                                int num9 = Player.tileTargetX;
                                int num10 = Player.tileTargetY;
                                if (i == 0)
                                {
                                    num9--;
                                }
                                if (i == 1)
                                {
                                    num9++;
                                }
                                if (i == 2)
                                {
                                    num10--;
                                }
                                if (i == 3)
                                {
                                    num10++;
                                }
                                if (Main.tile[num9, num10].wall == 0)
                                {
                                    int num11 = 0;
                                    for (int j = 0; j < 4; j++)
                                    {
                                        int num12 = num9;
                                        int num13 = num10;
                                        if (j == 0)
                                        {
                                            num12--;
                                        }
                                        if (j == 1)
                                        {
                                            num12++;
                                        }
                                        if (j == 2)
                                        {
                                            num13--;
                                        }
                                        if (j == 3)
                                        {
                                            num13++;
                                        }
                                        if ((int)Main.tile[num12, num13].wall == createWall)
                                        {
                                            num11++;
                                        }
                                    }
                                    if (num11 == 4)
                                    {
                                        WorldGen.PlaceWall(num9, num10, createWall, false);
                                        if ((int)Main.tile[num9, num10].wall == createWall)
                                        {
                                            this.inventory[this.selectedItem].stack--;
                                            if (this.inventory[this.selectedItem].stack == 0)
                                            {
                                                this.inventory[this.selectedItem].SetDefaults(0, false);
                                            }
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(17, -1, -1, "", 3, (float)num9, (float)num10, (float)createWall, 0);
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
        public void ItemCheck(int i)
        {
            int num = this.inventory[this.selectedItem].damage;
            if (num > 0)
            {
                if (this.inventory[this.selectedItem].melee)
                {
                    num = (int)((float)num * this.meleeDamage);
                }
                else
                {
                    if (this.inventory[this.selectedItem].ranged)
                    {
                        num = (int)((float)num * this.rangedDamage);
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].magic)
                        {
                            num = (int)((float)num * this.magicDamage);
                        }
                    }
                }
            }
            if (this.inventory[this.selectedItem].autoReuse && !this.noItems)
            {
                this.releaseUseItem = true;
                if (this.itemAnimation == 1 && this.inventory[this.selectedItem].stack > 0)
                {
                    if (this.inventory[this.selectedItem].shoot > 0 && this.whoAmi != Main.myPlayer && this.controlUseItem)
                    {
                        this.itemAnimation = 2;
                    }
                    else
                    {
                        this.itemAnimation = 0;
                    }
                }
            }
            if (this.itemAnimation == 0 && this.reuseDelay > 0)
            {
                this.itemAnimation = this.reuseDelay;
                this.itemTime = this.reuseDelay;
                this.reuseDelay = 0;
            }
            if (this.controlUseItem && this.releaseUseItem && (this.inventory[this.selectedItem].headSlot > 0 || this.inventory[this.selectedItem].bodySlot > 0 || this.inventory[this.selectedItem].legSlot > 0))
            {
                if (this.inventory[this.selectedItem].useStyle == 0)
                {
                    this.releaseUseItem = false;
                }
                if (this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
                {
                    int num2 = Player.tileTargetX;
                    int num3 = Player.tileTargetY;
                    if (Main.tile[num2, num3].active && Main.tile[num2, num3].type == 128)
                    {
                        int num4 = (int)Main.tile[num2, num3].frameY;
                        int j = 0;
                        if (this.inventory[this.selectedItem].bodySlot >= 0)
                        {
                            j = 1;
                        }
                        if (this.inventory[this.selectedItem].legSlot >= 0)
                        {
                            j = 2;
                        }
                        num4 /= 18;
                        while (j > num4)
                        {
                            num3++;
                            num4 = (int)Main.tile[num2, num3].frameY;
                            num4 /= 18;
                        }
                        while (j < num4)
                        {
                            num3--;
                            num4 = (int)Main.tile[num2, num3].frameY;
                            num4 /= 18;
                        }
                        int k;
                        for (k = (int)Main.tile[num2, num3].frameX; k >= 100; k -= 100)
                        {
                        }
                        if (k >= 36)
                        {
                            k -= 36;
                        }
                        num2 -= k / 18;
                        int l = (int)Main.tile[num2, num3].frameX;
                        WorldGen.KillTile(num2, num3, true, false, false);
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(17, -1, -1, "", 0, (float)num2, (float)num3, 1f, 0);
                        }
                        while (l >= 100)
                        {
                            l -= 100;
                        }
                        if (num4 == 0 && this.inventory[this.selectedItem].headSlot >= 0)
                        {
                            Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].headSlot * 100);
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendTileSquare(-1, num2, num3, 1);
                            }
                            this.inventory[this.selectedItem].SetDefaults(0, false);
                            Main.mouseItem.SetDefaults(0, false);
                            this.releaseUseItem = false;
                            this.mouseInterface = true;
                        }
                        else
                        {
                            if (num4 == 1 && this.inventory[this.selectedItem].bodySlot >= 0)
                            {
                                Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].bodySlot * 100);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendTileSquare(-1, num2, num3, 1);
                                }
                                this.inventory[this.selectedItem].SetDefaults(0, false);
                                Main.mouseItem.SetDefaults(0, false);
                                this.releaseUseItem = false;
                                this.mouseInterface = true;
                            }
                            else
                            {
                                if (num4 == 2 && this.inventory[this.selectedItem].legSlot >= 0)
                                {
                                    Main.tile[num2, num3].frameX = (short)(l + this.inventory[this.selectedItem].legSlot * 100);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendTileSquare(-1, num2, num3, 1);
                                    }
                                    this.inventory[this.selectedItem].SetDefaults(0, false);
                                    Main.mouseItem.SetDefaults(0, false);
                                    this.releaseUseItem = false;
                                    this.mouseInterface = true;
                                }
                            }
                        }
                    }
                }
            }
            if (this.controlUseItem && this.itemAnimation == 0 && this.releaseUseItem && this.inventory[this.selectedItem].useStyle > 0)
            {
                bool flag = true;
                if (this.inventory[this.selectedItem].shoot == 0)
                {
                    this.itemRotation = 0f;
                }
                if (this.wet && (this.inventory[this.selectedItem].shoot == 85 || this.inventory[this.selectedItem].shoot == 15 || this.inventory[this.selectedItem].shoot == 34))
                {
                    flag = false;
                }
                if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && !Main.cEd)
                {
                    flag = false;
                }
                if (this.noItems)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].shoot == 6 || this.inventory[this.selectedItem].shoot == 19 || this.inventory[this.selectedItem].shoot == 33 || this.inventory[this.selectedItem].shoot == 52)
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        if (Main.projectile[m].active && Main.projectile[m].owner == Main.myPlayer && Main.projectile[m].type == this.inventory[this.selectedItem].shoot)
                        {
                            flag = false;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].shoot == 106)
                {
                    int num5 = 0;
                    for (int n = 0; n < 1000; n++)
                    {
                        if (Main.projectile[n].active && Main.projectile[n].owner == Main.myPlayer && Main.projectile[n].type == this.inventory[this.selectedItem].shoot)
                        {
                            num5++;
                        }
                    }
                    if (num5 >= this.inventory[this.selectedItem].stack)
                    {
                        flag = false;
                    }
                }
                if (this.inventory[this.selectedItem].shoot == 13 || this.inventory[this.selectedItem].shoot == 32)
                {
                    for (int num6 = 0; num6 < 1000; num6++)
                    {
                        if (Main.projectile[num6].active && Main.projectile[num6].owner == Main.myPlayer && Main.projectile[num6].type == this.inventory[this.selectedItem].shoot && Main.projectile[num6].ai[0] != 2f)
                        {
                            flag = false;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].shoot == 73)
                {
                    for (int num7 = 0; num7 < 1000; num7++)
                    {
                        if (Main.projectile[num7].active && Main.projectile[num7].owner == Main.myPlayer && Main.projectile[num7].type == 74)
                        {
                            flag = false;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].potion && flag)
                {
                    if (this.potionDelay <= 0)
                    {
                        this.potionDelay = this.potionDelayTime;
                        this.AddBuff(21, this.potionDelay, true);
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (this.inventory[this.selectedItem].mana > 0 && this.silence)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].mana > 0 && flag)
                {
                    if (this.inventory[this.selectedItem].type != 127 || !this.spaceGun)
                    {
                        if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
                        {
                            this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
                        }
                        else
                        {
                            if (this.manaFlower)
                            {
                                this.QuickMana();
                                if (this.statMana >= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost))
                                {
                                    this.statMana -= (int)((float)this.inventory[this.selectedItem].mana * this.manaCost);
                                }
                                else
                                {
                                    flag = false;
                                }
                            }
                            else
                            {
                                flag = false;
                            }
                        }
                    }
                    if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].buffType != 0)
                    {
                        this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
                    }
                }
                if (this.whoAmi == Main.myPlayer && this.inventory[this.selectedItem].type == 603 && Main.cEd)
                {
                    this.AddBuff(this.inventory[this.selectedItem].buffType, 3600, true);
                }
                if (this.inventory[this.selectedItem].type == 43 && Main.dayTime)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].type == 544 && Main.dayTime)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].type == 556 && Main.dayTime)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].type == 557 && Main.dayTime)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].type == 70 && !this.zoneEvil)
                {
                    flag = false;
                }
                if (this.inventory[this.selectedItem].shoot == 17 && flag && i == Main.myPlayer)
                {
                    int num8 = (int)((float)Main.mouseX + Main.screenPosition.X) / 16;
                    int num9 = (int)((float)Main.mouseY + Main.screenPosition.Y) / 16;
                    if (Main.tile[num8, num9].active && (Main.tile[num8, num9].type == 0 || Main.tile[num8, num9].type == 2 || Main.tile[num8, num9].type == 23))
                    {
                        WorldGen.KillTile(num8, num9, false, false, true);
                        if (!Main.tile[num8, num9].active)
                        {
                            if (Main.netMode == 1)
                            {
                                NetMessage.SendData(17, -1, -1, "", 4, (float)num8, (float)num9, 0f, 0);
                            }
                        }
                        else
                        {
                            flag = false;
                        }
                    }
                    else
                    {
                        flag = false;
                    }
                }
                if (flag && this.inventory[this.selectedItem].useAmmo > 0)
                {
                    flag = false;
                    for (int num10 = 0; num10 < 48; num10++)
                    {
                        if (this.inventory[num10].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num10].stack > 0)
                        {
                            flag = true;
                            break;
                        }
                    }
                }
                if (flag)
                {
                    if (this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0)
                    {
                        this.toolTime = 1;
                    }
                    if (this.grappling[0] > -1)
                    {
                        if (this.controlRight)
                        {
                            this.direction = 1;
                        }
                        else
                        {
                            if (this.controlLeft)
                            {
                                this.direction = -1;
                            }
                        }
                    }
                    this.channel = this.inventory[this.selectedItem].channel;
                    this.attackCD = 0;
                    if (this.inventory[this.selectedItem].melee)
                    {
                        this.itemAnimation = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
                        this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
                    }
                    else
                    {
                        this.itemAnimation = this.inventory[this.selectedItem].useAnimation;
                        this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
                        this.reuseDelay = this.inventory[this.selectedItem].reuseDelay;
                    }
                    if (this.inventory[this.selectedItem].useSound > 0)
                    {
                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[this.selectedItem].useSound);
                    }
                }
                if (flag && (this.inventory[this.selectedItem].shoot == 18 || this.inventory[this.selectedItem].shoot == 72 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 86 || this.inventory[this.selectedItem].shoot == 111))
                {
                    for (int num11 = 0; num11 < 1000; num11++)
                    {
                        if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == this.inventory[this.selectedItem].shoot)
                        {
                            Main.projectile[num11].Kill();
                        }
                        if (this.inventory[this.selectedItem].shoot == 72)
                        {
                            if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == 86)
                            {
                                Main.projectile[num11].Kill();
                            }
                            if (Main.projectile[num11].active && Main.projectile[num11].owner == i && Main.projectile[num11].type == 87)
                            {
                                Main.projectile[num11].Kill();
                            }
                        }
                    }
                }
            }
            if (!this.controlUseItem)
            {
                bool arg_F86_0 = this.channel;
                this.channel = false;
            }
            if (this.itemAnimation > 0)
            {
                if (this.inventory[this.selectedItem].melee)
                {
                    this.itemAnimationMax = (int)((float)this.inventory[this.selectedItem].useAnimation * this.meleeSpeed);
                }
                else
                {
                    this.itemAnimationMax = this.inventory[this.selectedItem].useAnimation;
                }
                if (this.inventory[this.selectedItem].mana > 0)
                {
                    this.manaRegenDelay = (int)this.maxRegenDelay;
                }
                if (Main.dedServ)
                {
                    this.itemHeight = this.inventory[this.selectedItem].height;
                    this.itemWidth = this.inventory[this.selectedItem].width;
                }
                else
                {
                    this.itemHeight = Main.itemTexture[this.inventory[this.selectedItem].type].Height;
                    this.itemWidth = Main.itemTexture[this.inventory[this.selectedItem].type].Width;
                }
                this.itemAnimation--;
                if (!Main.dedServ)
                {
                    if (this.inventory[this.selectedItem].useStyle == 1)
                    {
                        if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
                        {
                            float num12 = 10f;
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                            {
                                num12 = 14f;
                            }
                            if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                            {
                                num12 = 28f;
                            }
                            this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num12) * (float)this.direction;
                            this.itemLocation.Y = this.position.Y + 24f;
                        }
                        else
                        {
                            if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.666)
                            {
                                float num13 = 10f;
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                                {
                                    num13 = 18f;
                                }
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                                {
                                    num13 = 28f;
                                }
                                this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num13) * (float)this.direction;
                                num13 = 10f;
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
                                {
                                    num13 = 8f;
                                }
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
                                {
                                    num13 = 14f;
                                }
                                this.itemLocation.Y = this.position.Y + num13;
                            }
                            else
                            {
                                float num14 = 6f;
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 32)
                                {
                                    num14 = 14f;
                                }
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Width > 64)
                                {
                                    num14 = 28f;
                                }
                                this.itemLocation.X = this.position.X + (float)this.width * 0.5f - ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - num14) * (float)this.direction;
                                num14 = 10f;
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 32)
                                {
                                    num14 = 10f;
                                }
                                if (Main.itemTexture[this.inventory[this.selectedItem].type].Height > 64)
                                {
                                    num14 = 14f;
                                }
                                this.itemLocation.Y = this.position.Y + num14;
                            }
                        }
                        this.itemRotation = ((float)this.itemAnimation / (float)this.itemAnimationMax - 0.5f) * (float)(-(float)this.direction) * 3.5f - (float)this.direction * 0.3f;
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].useStyle == 2)
                        {
                            this.itemRotation = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)this.direction * 2f + -1.4f * (float)this.direction;
                            if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.5)
                            {
                                this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 12f * (float)this.direction) * (float)this.direction;
                                this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction * 4f;
                            }
                            else
                            {
                                this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 16f * (float)this.direction) * (float)this.direction;
                                this.itemLocation.Y = this.position.Y + 38f + this.itemRotation * (float)this.direction;
                            }
                            if (this.gravDir == -1f)
                            {
                                this.itemRotation = -this.itemRotation;
                                this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                            }
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].useStyle == 3)
                            {
                                if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
                                {
                                    this.itemLocation.X = -1000f;
                                    this.itemLocation.Y = -1000f;
                                    this.itemRotation = -1.3f * (float)this.direction;
                                }
                                else
                                {
                                    this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 4f) * (float)this.direction;
                                    this.itemLocation.Y = this.position.Y + 24f;
                                    float num15 = (float)this.itemAnimation / (float)this.itemAnimationMax * (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * (float)this.direction * this.inventory[this.selectedItem].scale * 1.2f - (float)(10 * this.direction);
                                    if (num15 > -4f && this.direction == -1)
                                    {
                                        num15 = -8f;
                                    }
                                    if (num15 < 4f && this.direction == 1)
                                    {
                                        num15 = 8f;
                                    }
                                    this.itemLocation.X = this.itemLocation.X - num15;
                                    this.itemRotation = 0.8f * (float)this.direction;
                                }
                                if (this.gravDir == -1f)
                                {
                                    this.itemRotation = -this.itemRotation;
                                    this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                                }
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].useStyle == 4)
                                {
                                    this.itemRotation = 0f;
                                    this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - 9f - this.itemRotation * 14f * (float)this.direction - 4f) * (float)this.direction;
                                    this.itemLocation.Y = this.position.Y + (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f + 4f;
                                    if (this.gravDir == -1f)
                                    {
                                        this.itemRotation = -this.itemRotation;
                                        this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                                    }
                                }
                                else
                                {
                                    if (this.inventory[this.selectedItem].useStyle == 5)
                                    {
                                        this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
                                        this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            else
            {
                if (this.inventory[this.selectedItem].holdStyle == 1)
                {
                    if (Main.dedServ)
                    {
                        this.itemLocation.X = this.position.X + (float)this.width * 0.5f + 20f * (float)this.direction;
                    }
                    else
                    {
                        this.itemLocation.X = this.position.X + (float)this.width * 0.5f + ((float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f + 2f) * (float)this.direction;
                        if (this.inventory[this.selectedItem].type == 282 || this.inventory[this.selectedItem].type == 286)
                        {
                            this.itemLocation.X = this.itemLocation.X - (float)(this.direction * 2);
                            this.itemLocation.Y = this.itemLocation.Y + 4f;
                        }
                    }
                    this.itemLocation.Y = this.position.Y + 24f;
                    this.itemRotation = 0f;
                    if (this.gravDir == -1f)
                    {
                        this.itemRotation = -this.itemRotation;
                        this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                    }
                }
                else
                {
                    if (this.inventory[this.selectedItem].holdStyle == 2)
                    {
                        this.itemLocation.X = this.position.X + (float)this.width * 0.5f + (float)(6 * this.direction);
                        this.itemLocation.Y = this.position.Y + 16f;
                        this.itemRotation = 0.79f * (float)(-(float)this.direction);
                        if (this.gravDir == -1f)
                        {
                            this.itemRotation = -this.itemRotation;
                            this.itemLocation.Y = this.position.Y + (float)this.height + (this.position.Y - this.itemLocation.Y);
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].holdStyle == 3 && !Main.dedServ)
                        {
                            this.itemLocation.X = this.position.X + (float)this.width * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Width * 0.5f - (float)(this.direction * 2);
                            this.itemLocation.Y = this.position.Y + (float)this.height * 0.5f - (float)Main.itemTexture[this.inventory[this.selectedItem].type].Height * 0.5f;
                            this.itemRotation = 0f;
                        }
                    }
                }
            }
            if (((this.inventory[this.selectedItem].type == 8 || (this.inventory[this.selectedItem].type >= 427 && this.inventory[this.selectedItem].type <= 433)) && !this.wet) || this.inventory[this.selectedItem].type == 523)
            {
                float r = 1f;
                float g = 0.95f;
                float b = 0.8f;
                int num16 = 0;
                if (this.inventory[this.selectedItem].type == 523)
                {
                    num16 = 8;
                }
                else
                {
                    if (this.inventory[this.selectedItem].type >= 427)
                    {
                        num16 = this.inventory[this.selectedItem].type - 426;
                    }
                }
                if (num16 == 1)
                {
                    r = 0f;
                    g = 0.1f;
                    b = 1.3f;
                }
                else
                {
                    if (num16 == 2)
                    {
                        r = 1f;
                        g = 0.1f;
                        b = 0.1f;
                    }
                    else
                    {
                        if (num16 == 3)
                        {
                            r = 0f;
                            g = 1f;
                            b = 0.1f;
                        }
                        else
                        {
                            if (num16 == 4)
                            {
                                r = 0.9f;
                                g = 0f;
                                b = 0.9f;
                            }
                            else
                            {
                                if (num16 == 5)
                                {
                                    r = 1.3f;
                                    g = 1.3f;
                                    b = 1.3f;
                                }
                                else
                                {
                                    if (num16 == 6)
                                    {
                                        r = 0.9f;
                                        g = 0.9f;
                                        b = 0f;
                                    }
                                    else
                                    {
                                        if (num16 == 7)
                                        {
                                            r = 0.5f * Main.demonTorch + 1f * (1f - Main.demonTorch);
                                            g = 0.3f;
                                            b = 1f * Main.demonTorch + 0.5f * (1f - Main.demonTorch);
                                        }
                                        else
                                        {
                                            if (num16 == 8)
                                            {
                                                b = 0.7f;
                                                r = 0.85f;
                                                g = 1f;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                int num17 = num16;
                if (num17 == 0)
                {
                    num17 = 6;
                }
                else
                {
                    if (num17 == 8)
                    {
                        num17 = 75;
                    }
                    else
                    {
                        num17 = 58 + num17;
                    }
                }
                int maxValue = 20;
                if (this.itemAnimation > 0)
                {
                    maxValue = 7;
                }
                if (this.direction == -1)
                {
                    if (Main.rand.Next(maxValue) == 0)
                    {
                        Vector2 arg_2001_0 = new Vector2(this.itemLocation.X - 16f, this.itemLocation.Y - 14f * this.gravDir);
                        int arg_2001_1 = 4;
                        int arg_2001_2 = 4;
                        int arg_2001_3 = num17;
                        float arg_2001_4 = 0f;
                        float arg_2001_5 = 0f;
                        int arg_2001_6 = 100;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_2001_0, arg_2001_1, arg_2001_2, arg_2001_3, arg_2001_4, arg_2001_5, arg_2001_6, newColor, 1f);
                    }
                    Lighting.addLight((int)((this.itemLocation.X - 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
                }
                else
                {
                    if (Main.rand.Next(maxValue) == 0)
                    {
                        Vector2 arg_20BA_0 = new Vector2(this.itemLocation.X + 6f, this.itemLocation.Y - 14f * this.gravDir);
                        int arg_20BA_1 = 4;
                        int arg_20BA_2 = 4;
                        int arg_20BA_3 = num17;
                        float arg_20BA_4 = 0f;
                        float arg_20BA_5 = 0f;
                        int arg_20BA_6 = 100;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_20BA_0, arg_20BA_1, arg_20BA_2, arg_20BA_3, arg_20BA_4, arg_20BA_5, arg_20BA_6, newColor, 1f);
                    }
                    Lighting.addLight((int)((this.itemLocation.X + 12f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f + this.velocity.Y) / 16f), r, g, b);
                }
            }
            if (this.inventory[this.selectedItem].type == 105 && !this.wet)
            {
                int maxValue2 = 20;
                if (this.itemAnimation > 0)
                {
                    maxValue2 = 7;
                }
                if (this.direction == -1)
                {
                    if (Main.rand.Next(maxValue2) == 0)
                    {
                        Vector2 arg_21AD_0 = new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir);
                        int arg_21AD_1 = 4;
                        int arg_21AD_2 = 4;
                        int arg_21AD_3 = 6;
                        float arg_21AD_4 = 0f;
                        float arg_21AD_5 = 0f;
                        int arg_21AD_6 = 100;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_21AD_0, arg_21AD_1, arg_21AD_2, arg_21AD_3, arg_21AD_4, arg_21AD_5, arg_21AD_6, newColor, 1f);
                    }
                    Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
                }
                else
                {
                    if (Main.rand.Next(maxValue2) == 0)
                    {
                        Vector2 arg_2262_0 = new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir);
                        int arg_2262_1 = 4;
                        int arg_2262_2 = 4;
                        int arg_2262_3 = 6;
                        float arg_2262_4 = 0f;
                        float arg_2262_5 = 0f;
                        int arg_2262_6 = 100;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_2262_0, arg_2262_1, arg_2262_2, arg_2262_3, arg_2262_4, arg_2262_5, arg_2262_6, newColor, 1f);
                    }
                    Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 1f, 0.95f, 0.8f);
                }
            }
            else
            {
                if (this.inventory[this.selectedItem].type == 148 && !this.wet)
                {
                    int maxValue3 = 10;
                    if (this.itemAnimation > 0)
                    {
                        maxValue3 = 7;
                    }
                    if (this.direction == -1)
                    {
                        if (Main.rand.Next(maxValue3) == 0)
                        {
                            Vector2 arg_235B_0 = new Vector2(this.itemLocation.X - 12f, this.itemLocation.Y - 20f * this.gravDir);
                            int arg_235B_1 = 4;
                            int arg_235B_2 = 4;
                            int arg_235B_3 = 29;
                            float arg_235B_4 = 0f;
                            float arg_235B_5 = 0f;
                            int arg_235B_6 = 100;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_235B_0, arg_235B_1, arg_235B_2, arg_235B_3, arg_235B_4, arg_235B_5, arg_235B_6, newColor, 1f);
                        }
                        Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.3f, 0.3f, 0.75f);
                    }
                    else
                    {
                        if (Main.rand.Next(maxValue3) == 0)
                        {
                            Vector2 arg_2411_0 = new Vector2(this.itemLocation.X + 4f, this.itemLocation.Y - 20f * this.gravDir);
                            int arg_2411_1 = 4;
                            int arg_2411_2 = 4;
                            int arg_2411_3 = 29;
                            float arg_2411_4 = 0f;
                            float arg_2411_5 = 0f;
                            int arg_2411_6 = 100;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_2411_0, arg_2411_1, arg_2411_2, arg_2411_3, arg_2411_4, arg_2411_5, arg_2411_6, newColor, 1f);
                        }
                        Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.3f, 0.3f, 0.75f);
                    }
                }
            }
            if (this.inventory[this.selectedItem].type == 282)
            {
                if (this.direction == -1)
                {
                    Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
                }
                else
                {
                    Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 1f, 0.8f);
                }
            }
            if (this.inventory[this.selectedItem].type == 286)
            {
                if (this.direction == -1)
                {
                    Lighting.addLight((int)((this.itemLocation.X - 16f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
                }
                else
                {
                    Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), 0.7f, 0.8f, 1f);
                }
            }
            if (this.controlUseItem)
            {
                this.releaseUseItem = false;
            }
            else
            {
                this.releaseUseItem = true;
            }
            if (this.itemTime > 0)
            {
                this.itemTime--;
            }
            if (i == Main.myPlayer)
            {
                if (this.inventory[this.selectedItem].shoot > 0 && this.itemAnimation > 0 && this.itemTime == 0)
                {
                    int num18 = this.inventory[this.selectedItem].shoot;
                    float num19 = this.inventory[this.selectedItem].shootSpeed;
                    if (this.inventory[this.selectedItem].melee && num18 != 25 && num18 != 26 && num18 != 35)
                    {
                        num19 /= this.meleeSpeed;
                    }
                    bool flag2 = false;
                    int num20 = num;
                    float num21 = this.inventory[this.selectedItem].knockBack;
                    if (num18 == 13 || num18 == 32)
                    {
                        this.grappling[0] = -1;
                        this.grapCount = 0;
                        for (int num22 = 0; num22 < 1000; num22++)
                        {
                            if (Main.projectile[num22].active && Main.projectile[num22].owner == i && Main.projectile[num22].type == 13)
                            {
                                Main.projectile[num22].Kill();
                            }
                        }
                    }
                    if (this.inventory[this.selectedItem].useAmmo > 0)
                    {
                        Item item = new Item();
                        bool flag3 = false;
                        for (int num23 = 44; num23 < 48; num23++)
                        {
                            if (this.inventory[num23].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num23].stack > 0)
                            {
                                item = this.inventory[num23];
                                flag2 = true;
                                flag3 = true;
                                break;
                            }
                        }
                        if (!flag3)
                        {
                            for (int num24 = 0; num24 < 44; num24++)
                            {
                                if (this.inventory[num24].ammo == this.inventory[this.selectedItem].useAmmo && this.inventory[num24].stack > 0)
                                {
                                    item = this.inventory[num24];
                                    flag2 = true;
                                    break;
                                }
                            }
                        }
                        if (flag2)
                        {
                            if (item.shoot > 0)
                            {
                                num18 = item.shoot;
                            }
                            if (num18 == 42)
                            {
                                if (item.type == 370)
                                {
                                    num18 = 65;
                                    num20 += 5;
                                }
                                else
                                {
                                    if (item.type == 408)
                                    {
                                        num18 = 68;
                                        num20 += 5;
                                    }
                                }
                            }
                            num19 += item.shootSpeed;
                            if (item.ranged)
                            {
                                if (item.damage > 0)
                                {
                                    num20 += (int)((float)item.damage * this.rangedDamage);
                                }
                            }
                            else
                            {
                                num20 += item.damage;
                            }
                            if (this.inventory[this.selectedItem].useAmmo == 1 && this.archery)
                            {
                                if (num19 < 20f)
                                {
                                    num19 *= 1.2f;
                                    if (num19 > 20f)
                                    {
                                        num19 = 20f;
                                    }
                                }
                                num20 = (int)((double)((float)num20) * 1.2);
                            }
                            num21 += item.knockBack;
                            bool flag4 = false;
                            if (this.inventory[this.selectedItem].type == 98 && Main.rand.Next(3) == 0)
                            {
                                flag4 = true;
                            }
                            if (this.inventory[this.selectedItem].type == 533 && Main.rand.Next(2) == 0)
                            {
                                flag4 = true;
                            }
                            if (this.inventory[this.selectedItem].type == 434 && this.itemAnimation < this.inventory[this.selectedItem].useAnimation - 2)
                            {
                                flag4 = true;
                            }
                            if (this.ammoCost80 && Main.rand.Next(5) == 0)
                            {
                                flag4 = true;
                            }
                            if (this.ammoCost75 && Main.rand.Next(4) == 0)
                            {
                                flag4 = true;
                            }
                            if (num18 == 85 && this.itemAnimation < this.itemAnimationMax - 6)
                            {
                                flag4 = true;
                            }
                            if (!flag4 && !infAmmo)
                            {
                                item.stack--;
                                if (item.stack <= 0)
                                {
                                    item.active = false;
                                    item.name = "";
                                    item.type = 0;
                                }
                            }
                        }
                    }
                    else
                    {
                        flag2 = true;
                    }
                    if (num18 == 72)
                    {
                        int num25 = Main.rand.Next(3);
                        if (num25 == 0)
                        {
                            num18 = 72;
                        }
                        else
                        {
                            if (num25 == 1)
                            {
                                num18 = 86;
                            }
                            else
                            {
                                if (num25 == 2)
                                {
                                    num18 = 87;
                                }
                            }
                        }
                    }
                    if (num18 == 73)
                    {
                        for (int num26 = 0; num26 < 1000; num26++)
                        {
                            if (Main.projectile[num26].active && Main.projectile[num26].owner == i)
                            {
                                if (Main.projectile[num26].type == 73)
                                {
                                    num18 = 74;
                                }
                                if (Main.projectile[num26].type == 74)
                                {
                                    flag2 = false;
                                }
                            }
                        }
                    }
                    if (flag2)
                    {
                        if (this.inventory[this.selectedItem].mech && this.kbGlove)
                        {
                            num21 *= 1.7f;
                        }
                        if (num18 == 1 && this.inventory[this.selectedItem].type == 120)
                        {
                            num18 = 2;
                        }
                        this.itemTime = this.inventory[this.selectedItem].useTime;
                        if ((float)Main.mouseX + Main.screenPosition.X > this.position.X + (float)this.width * 0.5f)
                        {
                            this.direction = 1;
                        }
                        else
                        {
                            this.direction = -1;
                        }
                        Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                        if (num18 == 9)
                        {
                            vector = new Vector2(this.position.X + (float)this.width * 0.5f + (float)(Main.rand.Next(601) * -(float)this.direction), this.position.Y + (float)this.height * 0.5f - 300f - (float)Main.rand.Next(100));
                            num21 = 0f;
                        }
                        else
                        {
                            if (num18 == 51)
                            {
                                vector.Y -= 6f * this.gravDir;
                            }
                        }
                        float num27 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                        float num28 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                        float num29 = (float)Math.Sqrt((double)(num27 * num27 + num28 * num28));
                        float num30 = num29;
                        num29 = num19 / num29;
                        num27 *= num29;
                        num28 *= num29;
                        if (num18 == 12)
                        {
                            vector.X += num27 * 3f;
                            vector.Y += num28 * 3f;
                        }
                        if (this.inventory[this.selectedItem].useStyle == 5)
                        {
                            this.itemRotation = (float)Math.Atan2((double)(num28 * (float)this.direction), (double)(num27 * (float)this.direction));
                            NetMessage.SendData(13, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                            NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        }
                        if (num18 == 17)
                        {
                            vector.X = (float)Main.mouseX + Main.screenPosition.X;
                            vector.Y = (float)Main.mouseY + Main.screenPosition.Y;
                        }
                        if (num18 == 76)
                        {
                            num18 += Main.rand.Next(3);
                            num30 /= (float)(Main.screenHeight / 2);
                            if (num30 > 1f)
                            {
                                num30 = 1f;
                            }
                            float num31 = num27 + (float)Main.rand.Next(-40, 41) * 0.01f;
                            float num32 = num28 + (float)Main.rand.Next(-40, 41) * 0.01f;
                            num31 *= num30 + 0.25f;
                            num32 *= num30 + 0.25f;
                            int num33 = Projectile.NewProjectile(vector.X, vector.Y, num31, num32, num18, num20, num21, i);
                            Main.projectile[num33].ai[1] = 1f;
                            num30 = num30 * 2f - 1f;
                            if (num30 < -1f)
                            {
                                num30 = -1f;
                            }
                            if (num30 > 1f)
                            {
                                num30 = 1f;
                            }
                            Main.projectile[num33].ai[0] = num30;
                            NetMessage.SendData(27, -1, -1, "", num33, 0f, 0f, 0f, 0);
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].type == 98 || this.inventory[this.selectedItem].type == 533)
                            {
                                float speedX = num27 + (float)Main.rand.Next(-40, 41) * 0.01f;
                                float speedY = num28 + (float)Main.rand.Next(-40, 41) * 0.01f;
                                Projectile.NewProjectile(vector.X, vector.Y, speedX, speedY, num18, num20, num21, i);
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].type == 518)
                                {
                                    float num34 = num27;
                                    float num35 = num28;
                                    num34 += (float)Main.rand.Next(-40, 41) * 0.04f;
                                    num35 += (float)Main.rand.Next(-40, 41) * 0.04f;
                                    Projectile.NewProjectile(vector.X, vector.Y, num34, num35, num18, num20, num21, i);
                                }
                                else
                                {
                                    if (this.inventory[this.selectedItem].type == 534)
                                    {
                                        for (int num36 = 0; num36 < 4; num36++)
                                        {
                                            float num37 = num27;
                                            float num38 = num28;
                                            num37 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                            num38 += (float)Main.rand.Next(-40, 41) * 0.05f;
                                            Projectile.NewProjectile(vector.X, vector.Y, num37, num38, num18, num20, num21, i);
                                        }
                                    }
                                    else
                                    {
                                        if (this.inventory[this.selectedItem].type == 434)
                                        {
                                            float num39 = num27;
                                            float num40 = num28;
                                            if (this.itemAnimation < 5)
                                            {
                                                num39 += (float)Main.rand.Next(-40, 41) * 0.01f;
                                                num40 += (float)Main.rand.Next(-40, 41) * 0.01f;
                                                num39 *= 1.1f;
                                                num40 *= 1.1f;
                                            }
                                            else
                                            {
                                                if (this.itemAnimation < 10)
                                                {
                                                    num39 += (float)Main.rand.Next(-20, 21) * 0.01f;
                                                    num40 += (float)Main.rand.Next(-20, 21) * 0.01f;
                                                    num39 *= 1.05f;
                                                    num40 *= 1.05f;
                                                }
                                            }
                                            Projectile.NewProjectile(vector.X, vector.Y, num39, num40, num18, num20, num21, i);
                                        }
                                        else
                                        {
                                            int num41 = Projectile.NewProjectile(vector.X, vector.Y, num27, num28, num18, num20, num21, i);
                                            if (num18 == 80)
                                            {
                                                Main.projectile[num41].ai[0] = (float)Player.tileTargetX;
                                                Main.projectile[num41].ai[1] = (float)Player.tileTargetY;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].useStyle == 5)
                        {
                            this.itemRotation = 0f;
                            NetMessage.SendData(41, -1, -1, "", this.whoAmi, 0f, 0f, 0f, 0);
                        }
                    }
                }
                if (this.whoAmi == Main.myPlayer && (this.inventory[this.selectedItem].type == 509 || this.inventory[this.selectedItem].type == 510) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f + (float)this.blockRange >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost - (float)this.blockRange <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f + (float)this.blockRange >= (float)Player.tileTargetY)
                {
                    this.showItemIcon = true;
                    if (this.itemAnimation > 0 && this.itemTime == 0 && this.controlUseItem)
                    {
                        int i2 = Player.tileTargetX;
                        int j2 = Player.tileTargetY;
                        if (this.inventory[this.selectedItem].type == 509)
                        {
                            int num42 = -1;
                            for (int num43 = 0; num43 < 48; num43++)
                            {
                                if (this.inventory[num43].stack > 0 && this.inventory[num43].type == 530)
                                {
                                    num42 = num43;
                                    break;
                                }
                            }
                            if (num42 >= 0 && WorldGen.PlaceWire(i2, j2))
                            {
                                this.inventory[num42].stack--;
                                if (this.inventory[num42].stack <= 0)
                                {
                                    this.inventory[num42].SetDefaults(0, false);
                                }
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                NetMessage.SendData(17, -1, -1, "", 5, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                            }
                        }
                        else
                        {
                            if (WorldGen.KillWire(i2, j2))
                            {
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                NetMessage.SendData(17, -1, -1, "", 6, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                            }
                        }
                    }
                }
                if (this.itemAnimation > 0 && this.itemTime == 0 && (this.inventory[this.selectedItem].type == 507 || this.inventory[this.selectedItem].type == 508))
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    Vector2 vector2 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                    float num44 = (float)Main.mouseX + Main.screenPosition.X - vector2.X;
                    float num45 = (float)Main.mouseY + Main.screenPosition.Y - vector2.Y;
                    float num46 = (float)Math.Sqrt((double)(num44 * num44 + num45 * num45));
                    num46 /= (float)(Main.screenHeight / 2);
                    if (num46 > 1f)
                    {
                        num46 = 1f;
                    }
                    num46 = num46 * 2f - 1f;
                    if (num46 < -1f)
                    {
                        num46 = -1f;
                    }
                    if (num46 > 1f)
                    {
                        num46 = 1f;
                    }
                    Main.harpNote = num46;
                    int style = 26;
                    if (this.inventory[this.selectedItem].type == 507)
                    {
                        style = 35;
                    }
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, style);
                    NetMessage.SendData(58, -1, -1, "", this.whoAmi, num46, 0f, 0f, 0);
                }
                if (this.inventory[this.selectedItem].type >= 205 && this.inventory[this.selectedItem].type <= 207 && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
                {
                    this.showItemIcon = true;
                    if (this.itemTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
                    {
                        if (this.inventory[this.selectedItem].type == 205)
                        {
                            bool lava = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
                            int num47 = 0;
                            for (int num48 = Player.tileTargetX - 1; num48 <= Player.tileTargetX + 1; num48++)
                            {
                                for (int num49 = Player.tileTargetY - 1; num49 <= Player.tileTargetY + 1; num49++)
                                {
                                    if (Main.tile[num48, num49].lava == lava)
                                    {
                                        num47 += (int)Main.tile[num48, num49].liquid;
                                    }
                                }
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid > 0 && num47 > 100)
                            {
                                bool lava2 = Main.tile[Player.tileTargetX, Player.tileTargetY].lava;
                                if (!Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                                {
                                    this.inventory[this.selectedItem].SetDefaults(206, false);
                                }
                                else
                                {
                                    this.inventory[this.selectedItem].SetDefaults(207, false);
                                }
                                Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                int num50 = (int)Main.tile[Player.tileTargetX, Player.tileTargetY].liquid;
                                Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 0;
                                Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                                WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, false);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                }
                                else
                                {
                                    Liquid.AddWater(Player.tileTargetX, Player.tileTargetY);
                                }
                                for (int num51 = Player.tileTargetX - 1; num51 <= Player.tileTargetX + 1; num51++)
                                {
                                    for (int num52 = Player.tileTargetY - 1; num52 <= Player.tileTargetY + 1; num52++)
                                    {
                                        if (num50 < 256 && Main.tile[num51, num52].lava == lava)
                                        {
                                            int num53 = (int)Main.tile[num51, num52].liquid;
                                            if (num53 + num50 > 255)
                                            {
                                                num53 = 255 - num50;
                                            }
                                            num50 += num53;
                                            Tile expr_39AA = Main.tile[num51, num52];
                                            expr_39AA.liquid -= (byte)num53;
                                            Main.tile[num51, num52].lava = lava2;
                                            if (Main.tile[num51, num52].liquid == 0)
                                            {
                                                Main.tile[num51, num52].lava = false;
                                            }
                                            WorldGen.SquareTileFrame(num51, num52, false);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.sendWater(num51, num52);
                                            }
                                            else
                                            {
                                                Liquid.AddWater(num51, num52);
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid < 200 && (!Main.tile[Player.tileTargetX, Player.tileTargetY].active || !Main.tileSolid[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tileSolidTop[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
                            {
                                if (this.inventory[this.selectedItem].type == 207)
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                                    {
                                        Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                        Main.tile[Player.tileTargetX, Player.tileTargetY].lava = true;
                                        Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
                                        WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                        this.inventory[this.selectedItem].SetDefaults(205, false);
                                        this.itemTime = this.inventory[this.selectedItem].useTime;
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                        }
                                    }
                                }
                                else
                                {
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].liquid == 0 || !Main.tile[Player.tileTargetX, Player.tileTargetY].lava)
                                    {
                                        Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                        Main.tile[Player.tileTargetX, Player.tileTargetY].lava = false;
                                        Main.tile[Player.tileTargetX, Player.tileTargetY].liquid = 255;
                                        WorldGen.SquareTileFrame(Player.tileTargetX, Player.tileTargetY, true);
                                        this.inventory[this.selectedItem].SetDefaults(205, false);
                                        this.itemTime = this.inventory[this.selectedItem].useTime;
                                        if (Main.netMode == 1)
                                        {
                                            NetMessage.sendWater(Player.tileTargetX, Player.tileTargetY);
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (!this.channel)
                {
                    this.toolTime = this.itemTime;
                }
                else
                {
                    this.toolTime--;
                    if (this.toolTime < 0)
                    {
                        if (this.inventory[this.selectedItem].pick > 0)
                        {
                            this.toolTime = this.inventory[this.selectedItem].useTime;
                        }
                        else
                        {
                            this.toolTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
                        }
                    }
                }
                if ((this.inventory[this.selectedItem].pick > 0 || this.inventory[this.selectedItem].axe > 0 || this.inventory[this.selectedItem].hammer > 0) && this.position.X / 16f - (float)Player.tileRangeX - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetX && (this.position.X + (float)this.width) / 16f + (float)Player.tileRangeX + (float)this.inventory[this.selectedItem].tileBoost - 1f >= (float)Player.tileTargetX && this.position.Y / 16f - (float)Player.tileRangeY - (float)this.inventory[this.selectedItem].tileBoost <= (float)Player.tileTargetY && (this.position.Y + (float)this.height) / 16f + (float)Player.tileRangeY + (float)this.inventory[this.selectedItem].tileBoost - 2f >= (float)Player.tileTargetY)
                {
                    bool flag5 = true;
                    this.showItemIcon = true;
                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].active)
                    {
                        if ((this.inventory[this.selectedItem].pick > 0 && !Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && !Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].axe > 0 && Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]) || (this.inventory[this.selectedItem].hammer > 0 && Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type]))
                        {
                            flag5 = false;
                        }
                        if (this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem)
                        {
                            if (this.hitTileX != Player.tileTargetX || this.hitTileY != Player.tileTargetY)
                            {
                                this.hitTile = 0;
                                this.hitTileX = Player.tileTargetX;
                                this.hitTileY = Player.tileTargetY;
                            }
                            if (Main.tileNoFail[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                            {
                                this.hitTile = 100;
                            }
                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type != 27)
                            {
                                if (Main.tileHammer[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                                {
                                    flag5 = false;
                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 48)
                                    {
                                        this.hitTile += this.inventory[this.selectedItem].hammer / 2;
                                    }
                                    else
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 129)
                                        {
                                            this.hitTile += this.inventory[this.selectedItem].hammer * 2;
                                        }
                                        else
                                        {
                                            this.hitTile += this.inventory[this.selectedItem].hammer;
                                        }
                                    }
                                    if ((double)Player.tileTargetY > Main.rockLayer && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 77 && this.inventory[this.selectedItem].hammer < 60)
                                    {
                                        this.hitTile = 0;
                                    }
                                    if (this.inventory[this.selectedItem].hammer > 0)
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 26 && (this.inventory[this.selectedItem].hammer < 80 || !Main.hardMode))
                                        {
                                            this.hitTile = 0;
                                            this.Hurt(this.statLife / 2, -this.direction, false, false, Lang.deathMsg(-1, -1, -1, 4), false);
                                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
                                            }
                                        }
                                        if (this.hitTile >= 100)
                                        {
                                            if (Main.netMode == 1 && Main.tile[Player.tileTargetX, Player.tileTargetY].type == 21)
                                            {
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                                NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
                                                NetMessage.SendData(34, -1, -1, "", Player.tileTargetX, (float)Player.tileTargetY, 0f, 0f, 0);
                                            }
                                            else
                                            {
                                                this.hitTile = 0;
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                                if (Main.netMode == 1)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                            if (Main.netMode == 1)
                                            {
                                                NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
                                            }
                                        }
                                        this.itemTime = this.inventory[this.selectedItem].useTime;
                                    }
                                }
                                else
                                {
                                    if (Main.tileAxe[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type])
                                    {
                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 30 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 124)
                                        {
                                            this.hitTile += this.inventory[this.selectedItem].axe * 5;
                                        }
                                        else
                                        {
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 80)
                                            {
                                                this.hitTile += this.inventory[this.selectedItem].axe * 3;
                                            }
                                            else
                                            {
                                                this.hitTile += this.inventory[this.selectedItem].axe;
                                            }
                                        }
                                        if (this.inventory[this.selectedItem].axe > 0)
                                        {
                                            if (this.hitTile >= 100)
                                            {
                                                this.hitTile = 0;
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                                if (Main.netMode == 1)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                                                }
                                            }
                                            else
                                            {
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                                if (Main.netMode == 1)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
                                                }
                                            }
                                            this.itemTime = this.inventory[this.selectedItem].useTime;
                                        }
                                    }
                                    else
                                    {
                                        if (this.inventory[this.selectedItem].pick > 0)
                                        {
                                            if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117)
                                            {
                                                this.hitTile += this.inventory[this.selectedItem].pick / 2;
                                            }
                                            else
                                            {
                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107)
                                                {
                                                    this.hitTile += this.inventory[this.selectedItem].pick / 2;
                                                }
                                                else
                                                {
                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108)
                                                    {
                                                        this.hitTile += this.inventory[this.selectedItem].pick / 3;
                                                    }
                                                    else
                                                    {
                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111)
                                                        {
                                                            this.hitTile += this.inventory[this.selectedItem].pick / 4;
                                                        }
                                                        else
                                                        {
                                                            this.hitTile += this.inventory[this.selectedItem].pick;
                                                        }
                                                    }
                                                }
                                            }
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 25 && this.inventory[this.selectedItem].pick < 65)
                                            {
                                                this.hitTile = 0;
                                            }
                                            else
                                            {
                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 117 && this.inventory[this.selectedItem].pick < 65)
                                                {
                                                    this.hitTile = 0;
                                                }
                                                else
                                                {
                                                    if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 37 && this.inventory[this.selectedItem].pick < 55)
                                                    {
                                                        this.hitTile = 0;
                                                    }
                                                    else
                                                    {
                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 22 && (double)Player.tileTargetY > Main.worldSurface && this.inventory[this.selectedItem].pick < 55)
                                                        {
                                                            this.hitTile = 0;
                                                        }
                                                        else
                                                        {
                                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 56 && this.inventory[this.selectedItem].pick < 65)
                                                            {
                                                                this.hitTile = 0;
                                                            }
                                                            else
                                                            {
                                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 58 && this.inventory[this.selectedItem].pick < 65)
                                                                {
                                                                    this.hitTile = 0;
                                                                }
                                                                else
                                                                {
                                                                    if (Main.tileDungeon[(int)Main.tile[Player.tileTargetX, Player.tileTargetY].type] && this.inventory[this.selectedItem].pick < 65)
                                                                    {
                                                                        if ((double)Player.tileTargetX < (double)Main.maxTilesX * 0.25 || (double)Player.tileTargetX > (double)Main.maxTilesX * 0.75)
                                                                        {
                                                                            this.hitTile = 0;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 107 && this.inventory[this.selectedItem].pick < 100)
                                                                        {
                                                                            this.hitTile = 0;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 108 && this.inventory[this.selectedItem].pick < 110)
                                                                            {
                                                                                this.hitTile = 0;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 111 && this.inventory[this.selectedItem].pick < 120)
                                                                                {
                                                                                    this.hitTile = 0;
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
                                            if (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 0 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 40 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 53 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 57 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 59 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 123)
                                            {
                                                this.hitTile += this.inventory[this.selectedItem].pick;
                                            }
                                            if (this.hitTile >= 100 && (Main.tile[Player.tileTargetX, Player.tileTargetY].type == 2 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 23 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 60 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 70 || Main.tile[Player.tileTargetX, Player.tileTargetY].type == 109))
                                            {
                                                this.hitTile = 0;
                                            }
                                            if (this.hitTile >= 100)
                                            {
                                                this.hitTile = 0;
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, false, false, false);
                                                if (Main.netMode == 1)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 0f, 0);
                                                }
                                            }
                                            else
                                            {
                                                WorldGen.KillTile(Player.tileTargetX, Player.tileTargetY, true, false, false);
                                                if (Main.netMode == 1)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)Player.tileTargetX, (float)Player.tileTargetY, 1f, 0);
                                                }
                                            }
                                            this.itemTime = (int)((float)this.inventory[this.selectedItem].useTime * this.pickSpeed);
                                        }
                                    }
                                }
                            }
                        }
                    }
                    int num54 = Player.tileTargetX;
                    int num55 = Player.tileTargetY;
                    bool flag6 = true;
                    if (Main.tile[num54, num55].wall > 0)
                    {
                        if (!Main.wallHouse[(int)Main.tile[num54, num55].wall])
                        {
                            for (int num56 = num54 - 1; num56 < num54 + 2; num56++)
                            {
                                for (int num57 = num55 - 1; num57 < num55 + 2; num57++)
                                {
                                    if (Main.tile[num56, num57].wall != Main.tile[num54, num55].wall)
                                    {
                                        flag6 = false;
                                        break;
                                    }
                                }
                            }
                        }
                        else
                        {
                            flag6 = false;
                        }
                    }
                    if (flag6 && !Main.tile[num54, num55].active)
                    {
                        int num58 = -1;
                        if ((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f) < Math.Round((double)(((float)Main.mouseX + Main.screenPosition.X) / 16f)))
                        {
                            num58 = 0;
                        }
                        int num59 = -1;
                        if ((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f) < Math.Round((double)(((float)Main.mouseY + Main.screenPosition.Y) / 16f)))
                        {
                            num59 = 0;
                        }
                        for (int num60 = Player.tileTargetX + num58; num60 <= Player.tileTargetX + num58 + 1; num60++)
                        {
                            for (int num61 = Player.tileTargetY + num59; num61 <= Player.tileTargetY + num59 + 1; num61++)
                            {
                                if (flag6)
                                {
                                    num54 = num60;
                                    num55 = num61;
                                    if (Main.tile[num54, num55].wall > 0)
                                    {
                                        if (!Main.wallHouse[(int)Main.tile[num54, num55].wall])
                                        {
                                            for (int num62 = num54 - 1; num62 < num54 + 2; num62++)
                                            {
                                                for (int num63 = num55 - 1; num63 < num55 + 2; num63++)
                                                {
                                                    if (Main.tile[num62, num63].wall != Main.tile[num54, num55].wall)
                                                    {
                                                        flag6 = false;
                                                        break;
                                                    }
                                                }
                                            }
                                        }
                                        else
                                        {
                                            flag6 = false;
                                        }
                                    }
                                }
                            }
                        }
                    }
                    if (flag5 && Main.tile[num54, num55].wall > 0 && this.toolTime == 0 && this.itemAnimation > 0 && this.controlUseItem && this.inventory[this.selectedItem].hammer > 0)
                    {
                        bool flag7 = true;
                        if (!Main.wallHouse[(int)Main.tile[num54, num55].wall])
                        {
                            flag7 = false;
                            for (int num64 = num54 - 1; num64 < num54 + 2; num64++)
                            {
                                for (int num65 = num55 - 1; num65 < num55 + 2; num65++)
                                {
                                    if (Main.tile[num64, num65].wall != Main.tile[num54, num55].wall)
                                    {
                                        flag7 = true;
                                        break;
                                    }
                                }
                            }
                        }
                        if (flag7)
                        {
                            if (this.hitTileX != num54 || this.hitTileY != num55)
                            {
                                this.hitTile = 0;
                                this.hitTileX = num54;
                                this.hitTileY = num55;
                            }
                            this.hitTile += (int)((float)this.inventory[this.selectedItem].hammer * 1.5f);
                            if (this.hitTile >= 100)
                            {
                                this.hitTile = 0;
                                WorldGen.KillWall(num54, num55, false);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(17, -1, -1, "", 2, (float)num54, (float)num55, 0f, 0);
                                }
                            }
                            else
                            {
                                WorldGen.KillWall(num54, num55, true);
                                if (Main.netMode == 1)
                                {
                                    NetMessage.SendData(17, -1, -1, "", 2, (float)num54, (float)num55, 1f, 0);
                                }
                            }
                            this.itemTime = this.inventory[this.selectedItem].useTime / 2;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].type == 29 && this.itemAnimation > 0 && this.statLifeMax < 400 && this.itemTime == 0)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    this.statLifeMax += 20;
                    this.statLife += 20;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(20);
                    }
                }
                if (this.inventory[this.selectedItem].type == 109 && this.itemAnimation > 0 && this.statManaMax < 200 && this.itemTime == 0)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    this.statManaMax += 20;
                    this.statMana += 20;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(20);
                    }
                }
                this.PlaceThing();
            }
            if (this.inventory[this.selectedItem].damage >= 0 && this.inventory[this.selectedItem].type > 0 && !this.inventory[this.selectedItem].noMelee && this.itemAnimation > 0)
            {
                bool flag8 = false;
                Rectangle rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, 32, 32);
                if (!Main.dedServ)
                {
                    rectangle = new Rectangle((int)this.itemLocation.X, (int)this.itemLocation.Y, Main.itemTexture[this.inventory[this.selectedItem].type].Width, Main.itemTexture[this.inventory[this.selectedItem].type].Height);
                }
                rectangle.Width = (int)((float)rectangle.Width * this.inventory[this.selectedItem].scale);
                rectangle.Height = (int)((float)rectangle.Height * this.inventory[this.selectedItem].scale);
                if (this.direction == -1)
                {
                    rectangle.X -= rectangle.Width;
                }
                if (this.gravDir == 1f)
                {
                    rectangle.Y -= rectangle.Height;
                }
                if (this.inventory[this.selectedItem].useStyle == 1)
                {
                    if ((double)this.itemAnimation < (double)this.itemAnimationMax * 0.333)
                    {
                        if (this.direction == -1)
                        {
                            rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
                        }
                        rectangle.Width = (int)((double)rectangle.Width * 1.4);
                        rectangle.Y += (int)((double)rectangle.Height * 0.5 * (double)this.gravDir);
                        rectangle.Height = (int)((double)rectangle.Height * 1.1);
                    }
                    else
                    {
                        if ((double)this.itemAnimation >= (double)this.itemAnimationMax * 0.666)
                        {
                            if (this.direction == 1)
                            {
                                rectangle.X -= (int)((double)rectangle.Width * 1.2);
                            }
                            rectangle.Width *= 2;
                            rectangle.Y -= (int)(((double)rectangle.Height * 1.4 - (double)rectangle.Height) * (double)this.gravDir);
                            rectangle.Height = (int)((double)rectangle.Height * 1.4);
                        }
                    }
                }
                else
                {
                    if (this.inventory[this.selectedItem].useStyle == 3)
                    {
                        if ((double)this.itemAnimation > (double)this.itemAnimationMax * 0.666)
                        {
                            flag8 = true;
                        }
                        else
                        {
                            if (this.direction == -1)
                            {
                                rectangle.X -= (int)((double)rectangle.Width * 1.4 - (double)rectangle.Width);
                            }
                            rectangle.Width = (int)((double)rectangle.Width * 1.4);
                            rectangle.Y += (int)((double)rectangle.Height * 0.6);
                            rectangle.Height = (int)((double)rectangle.Height * 0.6);
                        }
                    }
                }
                float arg_5391_0 = this.gravDir;
                if (!flag8)
                {
                    if ((this.inventory[this.selectedItem].type == 44 || this.inventory[this.selectedItem].type == 45 || this.inventory[this.selectedItem].type == 46 || this.inventory[this.selectedItem].type == 103 || this.inventory[this.selectedItem].type == 104) && Main.rand.Next(15) == 0)
                    {
                        Vector2 arg_545C_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                        int arg_545C_1 = rectangle.Width;
                        int arg_545C_2 = rectangle.Height;
                        int arg_545C_3 = 14;
                        float arg_545C_4 = (float)(this.direction * 2);
                        float arg_545C_5 = 0f;
                        int arg_545C_6 = 150;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_545C_0, arg_545C_1, arg_545C_2, arg_545C_3, arg_545C_4, arg_545C_5, arg_545C_6, newColor, 1.3f);
                    }
                    if (this.inventory[this.selectedItem].type == 273)
                    {
                        Color newColor;
                        if (Main.rand.Next(5) == 0)
                        {
                            Vector2 arg_54D2_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                            int arg_54D2_1 = rectangle.Width;
                            int arg_54D2_2 = rectangle.Height;
                            int arg_54D2_3 = 14;
                            float arg_54D2_4 = (float)(this.direction * 2);
                            float arg_54D2_5 = 0f;
                            int arg_54D2_6 = 150;
                            newColor = default(Color);
                            Dust.NewDust(arg_54D2_0, arg_54D2_1, arg_54D2_2, arg_54D2_3, arg_54D2_4, arg_54D2_5, arg_54D2_6, newColor, 1.4f);
                        }
                        Vector2 arg_553A_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                        int arg_553A_1 = rectangle.Width;
                        int arg_553A_2 = rectangle.Height;
                        int arg_553A_3 = 27;
                        float arg_553A_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                        float arg_553A_5 = this.velocity.Y * 0.2f;
                        int arg_553A_6 = 100;
                        newColor = default(Color);
                        int num66 = Dust.NewDust(arg_553A_0, arg_553A_1, arg_553A_2, arg_553A_3, arg_553A_4, arg_553A_5, arg_553A_6, newColor, 1.2f);
                        Main.dust[num66].noGravity = true;
                        Dust expr_555C_cp_0 = Main.dust[num66];
                        expr_555C_cp_0.velocity.X = expr_555C_cp_0.velocity.X / 2f;
                        Dust expr_557A_cp_0 = Main.dust[num66];
                        expr_557A_cp_0.velocity.Y = expr_557A_cp_0.velocity.Y / 2f;
                    }
                    if (this.inventory[this.selectedItem].type == 65)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            Vector2 arg_55F4_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                            int arg_55F4_1 = rectangle.Width;
                            int arg_55F4_2 = rectangle.Height;
                            int arg_55F4_3 = 58;
                            float arg_55F4_4 = 0f;
                            float arg_55F4_5 = 0f;
                            int arg_55F4_6 = 150;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_55F4_0, arg_55F4_1, arg_55F4_2, arg_55F4_3, arg_55F4_4, arg_55F4_5, arg_55F4_6, newColor, 1.2f);
                        }
                        if (Main.rand.Next(10) == 0)
                        {
                            Gore.NewGore(new Vector2((float)rectangle.X, (float)rectangle.Y), default(Vector2), Main.rand.Next(16, 18), 1f);
                        }
                    }
                    if (this.inventory[this.selectedItem].type == 190 || this.inventory[this.selectedItem].type == 213)
                    {
                        Vector2 arg_56D3_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                        int arg_56D3_1 = rectangle.Width;
                        int arg_56D3_2 = rectangle.Height;
                        int arg_56D3_3 = 40;
                        float arg_56D3_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                        float arg_56D3_5 = this.velocity.Y * 0.2f;
                        int arg_56D3_6 = 0;
                        Color newColor = default(Color);
                        int num67 = Dust.NewDust(arg_56D3_0, arg_56D3_1, arg_56D3_2, arg_56D3_3, arg_56D3_4, arg_56D3_5, arg_56D3_6, newColor, 1.2f);
                        Main.dust[num67].noGravity = true;
                    }
                    if (this.inventory[this.selectedItem].type == 121)
                    {
                        for (int num68 = 0; num68 < 2; num68++)
                        {
                            Vector2 arg_576A_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                            int arg_576A_1 = rectangle.Width;
                            int arg_576A_2 = rectangle.Height;
                            int arg_576A_3 = 6;
                            float arg_576A_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                            float arg_576A_5 = this.velocity.Y * 0.2f;
                            int arg_576A_6 = 100;
                            Color newColor = default(Color);
                            int num69 = Dust.NewDust(arg_576A_0, arg_576A_1, arg_576A_2, arg_576A_3, arg_576A_4, arg_576A_5, arg_576A_6, newColor, 2.5f);
                            Main.dust[num69].noGravity = true;
                            Dust expr_578C_cp_0 = Main.dust[num69];
                            expr_578C_cp_0.velocity.X = expr_578C_cp_0.velocity.X * 2f;
                            Dust expr_57AA_cp_0 = Main.dust[num69];
                            expr_57AA_cp_0.velocity.Y = expr_57AA_cp_0.velocity.Y * 2f;
                        }
                    }
                    if (this.inventory[this.selectedItem].type == 122 || this.inventory[this.selectedItem].type == 217)
                    {
                        Vector2 arg_5859_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                        int arg_5859_1 = rectangle.Width;
                        int arg_5859_2 = rectangle.Height;
                        int arg_5859_3 = 6;
                        float arg_5859_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                        float arg_5859_5 = this.velocity.Y * 0.2f;
                        int arg_5859_6 = 100;
                        Color newColor = default(Color);
                        int num70 = Dust.NewDust(arg_5859_0, arg_5859_1, arg_5859_2, arg_5859_3, arg_5859_4, arg_5859_5, arg_5859_6, newColor, 1.9f);
                        Main.dust[num70].noGravity = true;
                    }
                    if (this.inventory[this.selectedItem].type == 155)
                    {
                        Vector2 arg_58EC_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                        int arg_58EC_1 = rectangle.Width;
                        int arg_58EC_2 = rectangle.Height;
                        int arg_58EC_3 = 29;
                        float arg_58EC_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                        float arg_58EC_5 = this.velocity.Y * 0.2f;
                        int arg_58EC_6 = 100;
                        Color newColor = default(Color);
                        int num71 = Dust.NewDust(arg_58EC_0, arg_58EC_1, arg_58EC_2, arg_58EC_3, arg_58EC_4, arg_58EC_5, arg_58EC_6, newColor, 2f);
                        Main.dust[num71].noGravity = true;
                        Dust expr_590E_cp_0 = Main.dust[num71];
                        expr_590E_cp_0.velocity.X = expr_590E_cp_0.velocity.X / 2f;
                        Dust expr_592C_cp_0 = Main.dust[num71];
                        expr_592C_cp_0.velocity.Y = expr_592C_cp_0.velocity.Y / 2f;
                    }
                    if (this.inventory[this.selectedItem].type == 367 || this.inventory[this.selectedItem].type == 368)
                    {
                        if (Main.rand.Next(3) == 0)
                        {
                            Vector2 arg_59E7_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                            int arg_59E7_1 = rectangle.Width;
                            int arg_59E7_2 = rectangle.Height;
                            int arg_59E7_3 = 57;
                            float arg_59E7_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                            float arg_59E7_5 = this.velocity.Y * 0.2f;
                            int arg_59E7_6 = 100;
                            Color newColor = default(Color);
                            int num72 = Dust.NewDust(arg_59E7_0, arg_59E7_1, arg_59E7_2, arg_59E7_3, arg_59E7_4, arg_59E7_5, arg_59E7_6, newColor, 1.1f);
                            Main.dust[num72].noGravity = true;
                            Dust expr_5A09_cp_0 = Main.dust[num72];
                            expr_5A09_cp_0.velocity.X = expr_5A09_cp_0.velocity.X / 2f;
                            Dust expr_5A27_cp_0 = Main.dust[num72];
                            expr_5A27_cp_0.velocity.Y = expr_5A27_cp_0.velocity.Y / 2f;
                            Dust expr_5A45_cp_0 = Main.dust[num72];
                            expr_5A45_cp_0.velocity.X = expr_5A45_cp_0.velocity.X + (float)(this.direction * 2);
                        }
                        if (Main.rand.Next(4) == 0)
                        {
                            Vector2 arg_5AAA_0 = new Vector2((float)rectangle.X, (float)rectangle.Y);
                            int arg_5AAA_1 = rectangle.Width;
                            int arg_5AAA_2 = rectangle.Height;
                            int arg_5AAA_3 = 43;
                            float arg_5AAA_4 = 0f;
                            float arg_5AAA_5 = 0f;
                            int arg_5AAA_6 = 254;
                            Color newColor = default(Color);
                            int num72 = Dust.NewDust(arg_5AAA_0, arg_5AAA_1, arg_5AAA_2, arg_5AAA_3, arg_5AAA_4, arg_5AAA_5, arg_5AAA_6, newColor, 0.3f);
                            Dust expr_5AB9 = Main.dust[num72];
                            expr_5AB9.velocity *= 0f;
                        }
                    }
                    if (this.inventory[this.selectedItem].type >= 198 && this.inventory[this.selectedItem].type <= 203)
                    {
                        float num73 = 0.5f;
                        float num74 = 0.5f;
                        float num75 = 0.5f;
                        if (this.inventory[this.selectedItem].type == 198)
                        {
                            num73 *= 0.1f;
                            num74 *= 0.5f;
                            num75 *= 1.2f;
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].type == 199)
                            {
                                num73 *= 1f;
                                num74 *= 0.2f;
                                num75 *= 0.1f;
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].type == 200)
                                {
                                    num73 *= 0.1f;
                                    num74 *= 1f;
                                    num75 *= 0.2f;
                                }
                                else
                                {
                                    if (this.inventory[this.selectedItem].type == 201)
                                    {
                                        num73 *= 0.8f;
                                        num74 *= 0.1f;
                                        num75 *= 1f;
                                    }
                                    else
                                    {
                                        if (this.inventory[this.selectedItem].type == 202)
                                        {
                                            num73 *= 0.8f;
                                            num74 *= 0.9f;
                                            num75 *= 1f;
                                        }
                                        else
                                        {
                                            if (this.inventory[this.selectedItem].type == 203)
                                            {
                                                num73 *= 0.9f;
                                                num74 *= 0.9f;
                                                num75 *= 0.1f;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                        Lighting.addLight((int)((this.itemLocation.X + 6f + this.velocity.X) / 16f), (int)((this.itemLocation.Y - 14f) / 16f), num73, num74, num75);
                    }
                    if (Main.myPlayer == i)
                    {
                        int num76 = (int)((float)this.inventory[this.selectedItem].damage * this.meleeDamage);
                        float num77 = this.inventory[this.selectedItem].knockBack;
                        if (this.kbGlove)
                        {
                            num77 *= 2f;
                        }
                        int num78 = rectangle.X / 16;
                        int num79 = (rectangle.X + rectangle.Width) / 16 + 1;
                        int num80 = rectangle.Y / 16;
                        int num81 = (rectangle.Y + rectangle.Height) / 16 + 1;
                        for (int num82 = num78; num82 < num79; num82++)
                        {
                            for (int num83 = num80; num83 < num81; num83++)
                            {
                                if (Main.tile[num82, num83] != null && Main.tileCut[(int)Main.tile[num82, num83].type] && Main.tile[num82, num83 + 1] != null && Main.tile[num82, num83 + 1].type != 78)
                                {
                                    WorldGen.KillTile(num82, num83, false, false, false);
                                    if (Main.netMode == 1)
                                    {
                                        NetMessage.SendData(17, -1, -1, "", 0, (float)num82, (float)num83, 0f, 0);
                                    }
                                }
                            }
                        }
                        for (int num84 = 0; num84 < 200; num84++)
                        {
                            if (Main.npc[num84].active && Main.npc[num84].immune[i] == 0 && this.attackCD == 0 && !Main.npc[num84].dontTakeDamage && (!Main.npc[num84].friendly || (Main.npc[num84].type == 22 && this.killGuide)))
                            {
                                Rectangle value = new Rectangle((int)Main.npc[num84].position.X, (int)Main.npc[num84].position.Y, Main.npc[num84].width, Main.npc[num84].height);
                                if (rectangle.Intersects(value) && (Main.npc[num84].noTileCollide || Collision.CanHit(this.position, this.width, this.height, Main.npc[num84].position, Main.npc[num84].width, Main.npc[num84].height)))
                                {
                                    bool flag9 = false;
                                    if (Main.rand.Next(1, 101) <= this.meleeCrit)
                                    {
                                        flag9 = true;
                                    }
                                    int num85 = Main.DamageVar((float)num76);
                                    this.StatusNPC(this.inventory[this.selectedItem].type, num84);
                                    Main.npc[num84].StrikeNPC(num85, num77, this.direction, flag9, false);
                                    if (Main.netMode != 0)
                                    {
                                        if (flag9)
                                        {
                                            NetMessage.SendData(28, -1, -1, "", num84, (float)num85, num77, (float)this.direction, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(28, -1, -1, "", num84, (float)num85, num77, (float)this.direction, 0);
                                        }
                                    }
                                    Main.npc[num84].immune[i] = this.itemAnimation;
                                    this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
                                }
                            }
                        }
                        if (this.hostile)
                        {
                            for (int num86 = 0; num86 < 255; num86++)
                            {
                                if (num86 != i && Main.player[num86].active && Main.player[num86].hostile && !Main.player[num86].immune && !Main.player[num86].dead && (Main.player[i].team == 0 || Main.player[i].team != Main.player[num86].team))
                                {
                                    Rectangle value2 = new Rectangle((int)Main.player[num86].position.X, (int)Main.player[num86].position.Y, Main.player[num86].width, Main.player[num86].height);
                                    if (rectangle.Intersects(value2) && Collision.CanHit(this.position, this.width, this.height, Main.player[num86].position, Main.player[num86].width, Main.player[num86].height))
                                    {
                                        bool flag10 = false;
                                        if (Main.rand.Next(1, 101) <= 10)
                                        {
                                            flag10 = true;
                                        }
                                        int num87 = Main.DamageVar((float)num76);
                                        this.StatusPvP(this.inventory[this.selectedItem].type, num86);
                                        Main.player[num86].Hurt(num87, this.direction, true, false, "", flag10);
                                        if (Main.netMode != 0)
                                        {
                                            if (flag10)
                                            {
                                                NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num86, (float)this.direction, (float)num87, 1f, 1);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.whoAmi, -1, -1, -1), num86, (float)this.direction, (float)num87, 1f, 0);
                                            }
                                        }
                                        this.attackCD = (int)((double)this.itemAnimationMax * 0.33);
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.itemTime == 0 && this.itemAnimation > 0)
            {
                if (this.inventory[this.selectedItem].healLife > 0)
                {
                    this.statLife += this.inventory[this.selectedItem].healLife;
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.HealEffect(this.inventory[this.selectedItem].healLife);
                    }
                }
                if (this.inventory[this.selectedItem].healMana > 0)
                {
                    this.statMana += this.inventory[this.selectedItem].healMana;
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    if (Main.myPlayer == this.whoAmi)
                    {
                        this.ManaEffect(this.inventory[this.selectedItem].healMana);
                    }
                }
                if (this.inventory[this.selectedItem].buffType > 0)
                {
                    if (this.whoAmi == Main.myPlayer)
                    {
                        this.AddBuff(this.inventory[this.selectedItem].buffType, this.inventory[this.selectedItem].buffTime, true);
                    }
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                }
            }
            if (this.whoAmi == Main.myPlayer)
            {
                if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 361)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                    if (Main.netMode != 1)
                    {
                        if (Main.invasionType == 0)
                        {
                            Main.invasionDelay = 0;
                            Main.StartInvasion(1);
                        }
                    }
                    else
                    {
                        NetMessage.SendData(61, -1, -1, "", this.whoAmi, -1f, 0f, 0f, 0);
                    }
                }
                if (this.itemTime == 0 && this.itemAnimation > 0 && this.inventory[this.selectedItem].type == 602)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                    Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                    if (Main.netMode != 1)
                    {
                        if (Main.invasionType == 0)
                        {
                            Main.invasionDelay = 0;
                            Main.StartInvasion(2);
                        }
                    }
                    else
                    {
                        NetMessage.SendData(61, -1, -1, "", this.whoAmi, -2f, 0f, 0f, 0);
                    }
                }
                if (this.itemTime == 0 && this.itemAnimation > 0 && (this.inventory[this.selectedItem].type == 43 || this.inventory[this.selectedItem].type == 70 || this.inventory[this.selectedItem].type == 544 || this.inventory[this.selectedItem].type == 556 || this.inventory[this.selectedItem].type == 557 || this.inventory[this.selectedItem].type == 560))
                {
                    bool flag11 = false;
                    for (int num88 = 0; num88 < 200; num88++)
                    {
                        if (Main.npc[num88].active && ((this.inventory[this.selectedItem].type == 43 && Main.npc[num88].type == 4) || (this.inventory[this.selectedItem].type == 70 && Main.npc[num88].type == 13) || ((this.inventory[this.selectedItem].type == 560 & Main.npc[num88].type == 50) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num88].type == 125)) || (this.inventory[this.selectedItem].type == 544 && Main.npc[num88].type == 126) || (this.inventory[this.selectedItem].type == 556 && Main.npc[num88].type == 134) || (this.inventory[this.selectedItem].type == 557 && Main.npc[num88].type == 128)))
                        {
                            flag11 = true;
                            break;
                        }
                    }
                    if (flag11)
                    {
                        this.itemTime = this.inventory[this.selectedItem].useTime;
                        if (Main.myPlayer == this.whoAmi)
                        {
                        }
                    }
                    else
                    {
                        if (this.inventory[this.selectedItem].type == 560)
                        {
                            this.itemTime = this.inventory[this.selectedItem].useTime;
                            Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                            if (Main.netMode != 1)
                            {
                                NPC.SpawnOnPlayer(i, 50);
                            }
                            else
                            {
                                NetMessage.SendData(61, -1, -1, "", this.whoAmi, 50f, 0f, 0f, 0);
                            }
                        }
                        else
                        {
                            if (this.inventory[this.selectedItem].type == 43)
                            {
                                if (!Main.dayTime)
                                {
                                    this.itemTime = this.inventory[this.selectedItem].useTime;
                                    Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                                    if (Main.netMode != 1)
                                    {
                                        NPC.SpawnOnPlayer(i, 4);
                                    }
                                    else
                                    {
                                        NetMessage.SendData(61, -1, -1, "", this.whoAmi, 4f, 0f, 0f, 0);
                                    }
                                }
                            }
                            else
                            {
                                if (this.inventory[this.selectedItem].type == 70)
                                {
                                    if (this.zoneEvil)
                                    {
                                        this.itemTime = this.inventory[this.selectedItem].useTime;
                                        Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                                        if (Main.netMode != 1)
                                        {
                                            NPC.SpawnOnPlayer(i, 13);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(61, -1, -1, "", this.whoAmi, 13f, 0f, 0f, 0);
                                        }
                                    }
                                }
                                else
                                {
                                    if (this.inventory[this.selectedItem].type == 544)
                                    {
                                        if (!Main.dayTime)
                                        {
                                            this.itemTime = this.inventory[this.selectedItem].useTime;
                                            Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                                            if (Main.netMode != 1)
                                            {
                                                NPC.SpawnOnPlayer(i, 125);
                                                NPC.SpawnOnPlayer(i, 126);
                                            }
                                            else
                                            {
                                                NetMessage.SendData(61, -1, -1, "", this.whoAmi, 125f, 0f, 0f, 0);
                                                NetMessage.SendData(61, -1, -1, "", this.whoAmi, 126f, 0f, 0f, 0);
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this.inventory[this.selectedItem].type == 556)
                                        {
                                            if (!Main.dayTime)
                                            {
                                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                                Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                                                if (Main.netMode != 1)
                                                {
                                                    NPC.SpawnOnPlayer(i, 134);
                                                }
                                                else
                                                {
                                                    NetMessage.SendData(61, -1, -1, "", this.whoAmi, 134f, 0f, 0f, 0);
                                                }
                                            }
                                        }
                                        else
                                        {
                                            if (this.inventory[this.selectedItem].type == 557 && !Main.dayTime)
                                            {
                                                this.itemTime = this.inventory[this.selectedItem].useTime;
                                                Main.PlaySound(15, (int)this.position.X, (int)this.position.Y, 0);
                                                if (Main.netMode != 1)
                                                {
                                                    NPC.SpawnOnPlayer(i, 127);
                                                }
                                                else
                                                {
                                                    NetMessage.SendData(61, -1, -1, "", this.whoAmi, 127f, 0f, 0f, 0);
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
            if (this.inventory[this.selectedItem].type == 50 && this.itemAnimation > 0)
            {
                if (Main.rand.Next(2) == 0)
                {
                    Vector2 arg_6B2A_0 = this.position;
                    int arg_6B2A_1 = this.width;
                    int arg_6B2A_2 = this.height;
                    int arg_6B2A_3 = 15;
                    float arg_6B2A_4 = 0f;
                    float arg_6B2A_5 = 0f;
                    int arg_6B2A_6 = 150;
                    Color newColor = default(Color);
                    Dust.NewDust(arg_6B2A_0, arg_6B2A_1, arg_6B2A_2, arg_6B2A_3, arg_6B2A_4, arg_6B2A_5, arg_6B2A_6, newColor, 1.1f);
                }
                if (this.itemTime == 0)
                {
                    this.itemTime = this.inventory[this.selectedItem].useTime;
                }
                else
                {
                    if (this.itemTime == this.inventory[this.selectedItem].useTime / 2)
                    {
                        for (int num89 = 0; num89 < 70; num89++)
                        {
                            Vector2 arg_6BC3_0 = this.position;
                            int arg_6BC3_1 = this.width;
                            int arg_6BC3_2 = this.height;
                            int arg_6BC3_3 = 15;
                            float arg_6BC3_4 = this.velocity.X * 0.5f;
                            float arg_6BC3_5 = this.velocity.Y * 0.5f;
                            int arg_6BC3_6 = 150;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_6BC3_0, arg_6BC3_1, arg_6BC3_2, arg_6BC3_3, arg_6BC3_4, arg_6BC3_5, arg_6BC3_6, newColor, 1.5f);
                        }
                        this.grappling[0] = -1;
                        this.grapCount = 0;
                        for (int num90 = 0; num90 < 1000; num90++)
                        {
                            if (Main.projectile[num90].active && Main.projectile[num90].owner == i && Main.projectile[num90].aiStyle == 7)
                            {
                                Main.projectile[num90].Kill();
                            }
                        }
                        this.Spawn();
                        for (int num91 = 0; num91 < 70; num91++)
                        {
                            Vector2 arg_6C72_0 = this.position;
                            int arg_6C72_1 = this.width;
                            int arg_6C72_2 = this.height;
                            int arg_6C72_3 = 15;
                            float arg_6C72_4 = 0f;
                            float arg_6C72_5 = 0f;
                            int arg_6C72_6 = 150;
                            Color newColor = default(Color);
                            Dust.NewDust(arg_6C72_0, arg_6C72_1, arg_6C72_2, arg_6C72_3, arg_6C72_4, arg_6C72_5, arg_6C72_6, newColor, 1.5f);
                        }
                    }
                }
            }
            if (i == Main.myPlayer)
            {
                if (this.itemTime == this.inventory[this.selectedItem].useTime && this.inventory[this.selectedItem].consumable)
                {
                    bool flag12 = true;
                    if (this.inventory[this.selectedItem].ranged)
                    {
                        if (this.ammoCost80 && Main.rand.Next(5) == 0)
                        {
                            flag12 = false;
                        }
                        if (this.ammoCost75 && Main.rand.Next(4) == 0)
                        {
                            flag12 = false;
                        }
                    }
                    if (flag12)
                    {
                        if (this.inventory[this.selectedItem].stack > 0)
                        {
                            this.inventory[this.selectedItem].stack--;
                        }
                        if (this.inventory[this.selectedItem].stack <= 0)
                        {
                            this.itemTime = this.itemAnimation;
                        }
                    }
                }
                if (this.inventory[this.selectedItem].stack <= 0 && this.itemAnimation == 0)
                {
                    this.inventory[this.selectedItem] = new Item();
                }
                if (this.selectedItem == 48)
                {
                    if (this.itemAnimation == 0)
                    {
                        return;
                    }
                    Main.mouseItem = (Item)this.inventory[this.selectedItem].Clone();
                }
            }
        }
        public Color GetImmuneAlpha(Color newColor)
        {
            float num = (float)(255 - this.immuneAlpha) / 255f;
            if (this.shadow > 0f)
            {
                num *= 1f - this.shadow;
            }
            if (this.immuneAlpha > 125)
            {
                return new Color(0, 0, 0, 0);
            }
            int r = (int)((float)newColor.R * num);
            int g = (int)((float)newColor.G * num);
            int b = (int)((float)newColor.B * num);
            int num2 = (int)((float)newColor.A * num);
            if (num2 < 0)
            {
                num2 = 0;
            }
            if (num2 > 255)
            {
                num2 = 255;
            }
            return new Color(r, g, b, num2);
        }
        public Color GetImmuneAlpha2(Color newColor)
        {
            float num = (float)(255 - this.immuneAlpha) / 255f;
            if (this.shadow > 0f)
            {
                num *= 1f - this.shadow;
            }
            int r = (int)((float)newColor.R * num);
            int g = (int)((float)newColor.G * num);
            int b = (int)((float)newColor.B * num);
            int num2 = (int)((float)newColor.A * num);
            if (num2 < 0)
            {
                num2 = 0;
            }
            if (num2 > 255)
            {
                num2 = 255;
            }
            return new Color(r, g, b, num2);
        }
        public Color GetDeathAlpha(Color newColor)
        {
            int r = (int)newColor.R + (int)((double)this.immuneAlpha * 0.9);
            int g = (int)newColor.G + (int)((double)this.immuneAlpha * 0.5);
            int b = (int)newColor.B + (int)((double)this.immuneAlpha * 0.5);
            int num = (int)newColor.A + (int)((double)this.immuneAlpha * 0.4);
            if (num < 0)
            {
                num = 0;
            }
            if (num > 255)
            {
                num = 255;
            }
            return new Color(r, g, b, num);
        }
        public void DropCoins()
        {
            for (int i = 0; i < 49; i++)
            {
                if (this.inventory[i].type >= 71 && this.inventory[i].type <= 74)
                {
                    int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0);
                    int num2 = this.inventory[i].stack / 2;
                    num2 = this.inventory[i].stack - num2;
                    this.inventory[i].stack -= num2;
                    if (this.inventory[i].stack <= 0)
                    {
                        this.inventory[i] = new Item();
                    }
                    Main.item[num].stack = num2;
                    Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                    Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                    Main.item[num].noGrabDelay = 100;
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
                    }
                    if (i == 48)
                    {
                        Main.mouseItem = (Item)this.inventory[i].Clone();
                    }
                }
            }
        }
        public void DropItems()
        {
            for (int i = 0; i < 49; i++)
            {
                if (this.inventory[i].stack > 0 && this.inventory[i].name != "Copper Pickaxe" && this.inventory[i].name != "Copper Axe" && this.inventory[i].name != "Copper Shortsword")
                {
                    int num = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.inventory[i].type, 1, false, 0);
                    Main.item[num].SetDefaults(this.inventory[i].name);
                    Main.item[num].Prefix((int)this.inventory[i].prefix);
                    Main.item[num].stack = this.inventory[i].stack;
                    Main.item[num].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                    Main.item[num].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                    Main.item[num].noGrabDelay = 100;
                    if (Main.netMode == 1)
                    {
                        NetMessage.SendData(21, -1, -1, "", num, 0f, 0f, 0f, 0);
                    }
                }
                this.inventory[i] = new Item();
                if (i < 11)
                {
                    if (this.armor[i].stack > 0)
                    {
                        int num2 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, this.armor[i].type, 1, false, 0);
                        Main.item[num2].SetDefaults(this.armor[i].name);
                        Main.item[num2].Prefix((int)this.armor[i].prefix);
                        Main.item[num2].stack = this.armor[i].stack;
                        Main.item[num2].velocity.Y = (float)Main.rand.Next(-20, 1) * 0.2f;
                        Main.item[num2].velocity.X = (float)Main.rand.Next(-20, 21) * 0.2f;
                        Main.item[num2].noGrabDelay = 100;
                        if (Main.netMode == 1)
                        {
                            NetMessage.SendData(21, -1, -1, "", num2, 0f, 0f, 0f, 0);
                        }
                    }
                    this.armor[i] = new Item();
                }
            }
            this.inventory[0].SetDefaults("Copper Shortsword");
            this.inventory[0].Prefix(-1);
            this.inventory[1].SetDefaults("Copper Pickaxe");
            this.inventory[1].Prefix(-1);
            this.inventory[2].SetDefaults("Copper Axe");
            this.inventory[2].Prefix(-1);
            Main.mouseItem = new Item();
        }
        public object Clone()
        {
            return base.MemberwiseClone();
        }
        public object clientClone()
        {
            Player player = new Player();
            player.zoneEvil = this.zoneEvil;
            player.zoneMeteor = this.zoneMeteor;
            player.zoneDungeon = this.zoneDungeon;
            player.zoneJungle = this.zoneJungle;
            player.zoneHoly = this.zoneHoly;
            player.direction = this.direction;
            player.selectedItem = this.selectedItem;
            player.controlUp = this.controlUp;
            player.controlDown = this.controlDown;
            player.controlLeft = this.controlLeft;
            player.controlRight = this.controlRight;
            player.controlJump = this.controlJump;
            player.controlUseItem = this.controlUseItem;
            player.statLife = this.statLife;
            player.statLifeMax = this.statLifeMax;
            player.statMana = this.statMana;
            player.statManaMax = this.statManaMax;
            player.position.X = this.position.X;
            player.chest = this.chest;
            player.talkNPC = this.talkNPC;
            for (int i = 0; i < 49; i++)
            {
                player.inventory[i] = (Item)this.inventory[i].Clone();
                if (i < 11)
                {
                    player.armor[i] = (Item)this.armor[i].Clone();
                }
            }
            for (int j = 0; j < 10; j++)
            {
                player.buffType[j] = this.buffType[j];
                player.buffTime[j] = this.buffTime[j];
            }
            return player;
        }
        private static void EncryptFile(string inputFile, string outputFile)
        {
            string s = "h3y_gUyZ";
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] bytes = unicodeEncoding.GetBytes(s);
            FileStream fileStream = new FileStream(outputFile, FileMode.Create);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateEncryptor(bytes, bytes), CryptoStreamMode.Write);
            FileStream fileStream2 = new FileStream(inputFile, FileMode.Open);
            int num;
            while ((num = fileStream2.ReadByte()) != -1)
            {
                cryptoStream.WriteByte((byte)num);
            }
            fileStream2.Close();
            cryptoStream.Close();
            fileStream.Close();
        }
        private static bool DecryptFile(string inputFile, string outputFile)
        {
            string s = "h3y_gUyZ";
            UnicodeEncoding unicodeEncoding = new UnicodeEncoding();
            byte[] bytes = unicodeEncoding.GetBytes(s);
            FileStream fileStream = new FileStream(inputFile, FileMode.Open);
            RijndaelManaged rijndaelManaged = new RijndaelManaged();
            CryptoStream cryptoStream = new CryptoStream(fileStream, rijndaelManaged.CreateDecryptor(bytes, bytes), CryptoStreamMode.Read);
            FileStream fileStream2 = new FileStream(outputFile, FileMode.Create);
            try
            {
                int num;
                while ((num = cryptoStream.ReadByte()) != -1)
                {
                    fileStream2.WriteByte((byte)num);
                }
                fileStream2.Close();
                cryptoStream.Close();
                fileStream.Close();
            }
            catch
            {
                fileStream2.Close();
                fileStream.Close();
                File.Delete(outputFile);
                return true;
            }
            return false;
        }
        public static bool CheckSpawn(int x, int y)
        {
            if (x < 10 || x > Main.maxTilesX - 10 || y < 10 || y > Main.maxTilesX - 10)
            {
                return false;
            }
            if (Main.tile[x, y - 1] == null)
            {
                return false;
            }
            if (!Main.tile[x, y - 1].active || Main.tile[x, y - 1].type != 79)
            {
                return false;
            }
            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 3; j < y; j++)
                {
                    if (Main.tile[i, j] == null)
                    {
                        return false;
                    }
                    if (Main.tile[i, j].active && Main.tileSolid[(int)Main.tile[i, j].type] && !Main.tileSolidTop[(int)Main.tile[i, j].type])
                    {
                        return false;
                    }
                }
            }
            return WorldGen.StartRoomCheck(x, y - 1);
        }
        public void FindSpawn()
        {
            for (int i = 0; i < 200; i++)
            {
                if (this.spN[i] == null)
                {
                    this.SpawnX = -1;
                    this.SpawnY = -1;
                    return;
                }
                if (this.spN[i] == Main.worldName && this.spI[i] == Main.worldID)
                {
                    this.SpawnX = this.spX[i];
                    this.SpawnY = this.spY[i];
                    return;
                }
            }
        }
        public void ChangeSpawn(int x, int y)
        {
            int num = 0;
            while (num < 200 && this.spN[num] != null)
            {
                if (this.spN[num] == Main.worldName && this.spI[num] == Main.worldID)
                {
                    for (int i = num; i > 0; i--)
                    {
                        this.spN[i] = this.spN[i - 1];
                        this.spI[i] = this.spI[i - 1];
                        this.spX[i] = this.spX[i - 1];
                        this.spY[i] = this.spY[i - 1];
                    }
                    this.spN[0] = Main.worldName;
                    this.spI[0] = Main.worldID;
                    this.spX[0] = x;
                    this.spY[0] = y;
                    return;
                }
                num++;
            }
            for (int j = 199; j > 0; j--)
            {
                if (this.spN[j - 1] != null)
                {
                    this.spN[j] = this.spN[j - 1];
                    this.spI[j] = this.spI[j - 1];
                    this.spX[j] = this.spX[j - 1];
                    this.spY[j] = this.spY[j - 1];
                }
            }
            this.spN[0] = Main.worldName;
            this.spI[0] = Main.worldID;
            this.spX[0] = x;
            this.spY[0] = y;
        }
        public static void SavePlayer(Player newPlayer, string playerPath)
        {
            try
            {
                Directory.CreateDirectory(Main.PlayerPath);
            }
            catch
            {
            }
            if (playerPath == null || playerPath == "")
            {
                return;
            }
            string destFileName = playerPath + ".bak";
            if (File.Exists(playerPath))
            {
                File.Copy(playerPath, destFileName, true);
            }
            string text = playerPath + ".dat";
            using (FileStream fileStream = new FileStream(text, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(Main.curRelease);
                    binaryWriter.Write(newPlayer.name);
                    binaryWriter.Write(newPlayer.difficulty);
                    binaryWriter.Write(newPlayer.hair);
                    binaryWriter.Write(newPlayer.male);
                    binaryWriter.Write(newPlayer.statLife);
                    binaryWriter.Write(newPlayer.statLifeMax);
                    binaryWriter.Write(newPlayer.statMana);
                    binaryWriter.Write(newPlayer.statManaMax);
                    binaryWriter.Write(newPlayer.hairColor.R);
                    binaryWriter.Write(newPlayer.hairColor.G);
                    binaryWriter.Write(newPlayer.hairColor.B);
                    binaryWriter.Write(newPlayer.skinColor.R);
                    binaryWriter.Write(newPlayer.skinColor.G);
                    binaryWriter.Write(newPlayer.skinColor.B);
                    binaryWriter.Write(newPlayer.eyeColor.R);
                    binaryWriter.Write(newPlayer.eyeColor.G);
                    binaryWriter.Write(newPlayer.eyeColor.B);
                    binaryWriter.Write(newPlayer.shirtColor.R);
                    binaryWriter.Write(newPlayer.shirtColor.G);
                    binaryWriter.Write(newPlayer.shirtColor.B);
                    binaryWriter.Write(newPlayer.underShirtColor.R);
                    binaryWriter.Write(newPlayer.underShirtColor.G);
                    binaryWriter.Write(newPlayer.underShirtColor.B);
                    binaryWriter.Write(newPlayer.pantsColor.R);
                    binaryWriter.Write(newPlayer.pantsColor.G);
                    binaryWriter.Write(newPlayer.pantsColor.B);
                    binaryWriter.Write(newPlayer.shoeColor.R);
                    binaryWriter.Write(newPlayer.shoeColor.G);
                    binaryWriter.Write(newPlayer.shoeColor.B);
                    for (int i = 0; i < 11; i++)
                    {
                        if (newPlayer.armor[i].name == null)
                        {
                            newPlayer.armor[i].name = "";
                        }
                        binaryWriter.Write(newPlayer.armor[i].netID);
                        binaryWriter.Write(newPlayer.armor[i].prefix);
                    }
                    for (int j = 0; j < 48; j++)
                    {
                        if (newPlayer.inventory[j].name == null)
                        {
                            newPlayer.inventory[j].name = "";
                        }
                        binaryWriter.Write(newPlayer.inventory[j].netID);
                        binaryWriter.Write(newPlayer.inventory[j].stack);
                        binaryWriter.Write(newPlayer.inventory[j].prefix);
                    }
                    for (int k = 0; k < Chest.maxItems; k++)
                    {
                        if (newPlayer.bank[k].name == null)
                        {
                            newPlayer.bank[k].name = "";
                        }
                        binaryWriter.Write(newPlayer.bank[k].netID);
                        binaryWriter.Write(newPlayer.bank[k].stack);
                        binaryWriter.Write(newPlayer.bank[k].prefix);
                    }
                    for (int l = 0; l < Chest.maxItems; l++)
                    {
                        if (newPlayer.bank2[l].name == null)
                        {
                            newPlayer.bank2[l].name = "";
                        }
                        binaryWriter.Write(newPlayer.bank2[l].netID);
                        binaryWriter.Write(newPlayer.bank2[l].stack);
                        binaryWriter.Write(newPlayer.bank2[l].prefix);
                    }
                    for (int m = 0; m < 10; m++)
                    {
                        binaryWriter.Write(newPlayer.buffType[m]);
                        binaryWriter.Write(newPlayer.buffTime[m]);
                    }
                    for (int n = 0; n < 200; n++)
                    {
                        if (newPlayer.spN[n] == null)
                        {
                            binaryWriter.Write(-1);
                            break;
                        }
                        binaryWriter.Write(newPlayer.spX[n]);
                        binaryWriter.Write(newPlayer.spY[n]);
                        binaryWriter.Write(newPlayer.spI[n]);
                        binaryWriter.Write(newPlayer.spN[n]);
                    }
                    binaryWriter.Write(newPlayer.hbLocked);
                    binaryWriter.Close();
                }
            }
            Player.EncryptFile(text, playerPath);
            File.Delete(text);
        }
        public static Player LoadPlayer(string playerPath)
        {
            bool flag = false;
            if (Main.rand == null)
            {
                Main.rand = new Random((int)DateTime.Now.Ticks);
            }
            Player player = new Player();
            try
            {
                string text = playerPath + ".dat";
                flag = Player.DecryptFile(playerPath, text);
                if (!flag)
                {
                    using (FileStream fileStream = new FileStream(text, FileMode.Open))
                    {
                        using (BinaryReader binaryReader = new BinaryReader(fileStream))
                        {
                            int num = binaryReader.ReadInt32();
                            player.name = binaryReader.ReadString();
                            if (num >= 10)
                            {
                                if (num >= 17)
                                {
                                    player.difficulty = binaryReader.ReadByte();
                                }
                                else
                                {
                                    bool flag2 = binaryReader.ReadBoolean();
                                    if (flag2)
                                    {
                                        player.difficulty = 2;
                                    }
                                }
                            }
                            player.hair = binaryReader.ReadInt32();
                            if (num <= 17)
                            {
                                if (player.hair == 5 || player.hair == 6 || player.hair == 9 || player.hair == 11)
                                {
                                    player.male = false;
                                }
                                else
                                {
                                    player.male = true;
                                }
                            }
                            else
                            {
                                player.male = binaryReader.ReadBoolean();
                            }
                            player.statLife = binaryReader.ReadInt32();
                            player.statLifeMax = binaryReader.ReadInt32();
                            if (player.statLifeMax > 400)
                            {
                                player.statLifeMax = 400;
                            }
                            if (player.statLife > player.statLifeMax)
                            {
                                player.statLife = player.statLifeMax;
                            }
                            player.statMana = binaryReader.ReadInt32();
                            player.statManaMax = binaryReader.ReadInt32();
                            if (player.statManaMax > 200)
                            {
                                player.statManaMax = 200;
                            }
                            if (player.statMana > 400)
                            {
                                player.statMana = 400;
                            }
                            player.hairColor.R = binaryReader.ReadByte();
                            player.hairColor.G = binaryReader.ReadByte();
                            player.hairColor.B = binaryReader.ReadByte();
                            player.skinColor.R = binaryReader.ReadByte();
                            player.skinColor.G = binaryReader.ReadByte();
                            player.skinColor.B = binaryReader.ReadByte();
                            player.eyeColor.R = binaryReader.ReadByte();
                            player.eyeColor.G = binaryReader.ReadByte();
                            player.eyeColor.B = binaryReader.ReadByte();
                            player.shirtColor.R = binaryReader.ReadByte();
                            player.shirtColor.G = binaryReader.ReadByte();
                            player.shirtColor.B = binaryReader.ReadByte();
                            player.underShirtColor.R = binaryReader.ReadByte();
                            player.underShirtColor.G = binaryReader.ReadByte();
                            player.underShirtColor.B = binaryReader.ReadByte();
                            player.pantsColor.R = binaryReader.ReadByte();
                            player.pantsColor.G = binaryReader.ReadByte();
                            player.pantsColor.B = binaryReader.ReadByte();
                            player.shoeColor.R = binaryReader.ReadByte();
                            player.shoeColor.G = binaryReader.ReadByte();
                            player.shoeColor.B = binaryReader.ReadByte();
                            Main.player[Main.myPlayer].shirtColor = player.shirtColor;
                            Main.player[Main.myPlayer].pantsColor = player.pantsColor;
                            Main.player[Main.myPlayer].hairColor = player.hairColor;
                            if (num >= 38)
                            {
                                for (int i = 0; i < 11; i++)
                                {
                                    player.armor[i].netDefaults(binaryReader.ReadInt32());
                                    player.armor[i].Prefix((int)binaryReader.ReadByte());
                                }
                                for (int j = 0; j < 48; j++)
                                {
                                    player.inventory[j].netDefaults(binaryReader.ReadInt32());
                                    player.inventory[j].stack = binaryReader.ReadInt32();
                                    player.inventory[j].Prefix((int)binaryReader.ReadByte());
                                }
                                for (int k = 0; k < Chest.maxItems; k++)
                                {
                                    player.bank[k].netDefaults(binaryReader.ReadInt32());
                                    player.bank[k].stack = binaryReader.ReadInt32();
                                    player.bank[k].Prefix((int)binaryReader.ReadByte());
                                }
                                for (int l = 0; l < Chest.maxItems; l++)
                                {
                                    player.bank2[l].netDefaults(binaryReader.ReadInt32());
                                    player.bank2[l].stack = binaryReader.ReadInt32();
                                    player.bank2[l].Prefix((int)binaryReader.ReadByte());
                                }
                            }
                            else
                            {
                                for (int m = 0; m < 8; m++)
                                {
                                    player.armor[m].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                    if (num >= 36)
                                    {
                                        player.armor[m].Prefix((int)binaryReader.ReadByte());
                                    }
                                }
                                if (num >= 6)
                                {
                                    for (int n = 8; n < 11; n++)
                                    {
                                        player.armor[n].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                        if (num >= 36)
                                        {
                                            player.armor[n].Prefix((int)binaryReader.ReadByte());
                                        }
                                    }
                                }
                                for (int num2 = 0; num2 < 44; num2++)
                                {
                                    player.inventory[num2].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                    player.inventory[num2].stack = binaryReader.ReadInt32();
                                    if (num >= 36)
                                    {
                                        player.inventory[num2].Prefix((int)binaryReader.ReadByte());
                                    }
                                }
                                if (num >= 15)
                                {
                                    for (int num3 = 44; num3 < 48; num3++)
                                    {
                                        player.inventory[num3].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                        player.inventory[num3].stack = binaryReader.ReadInt32();
                                        if (num >= 36)
                                        {
                                            player.inventory[num3].Prefix((int)binaryReader.ReadByte());
                                        }
                                    }
                                }
                                for (int num4 = 0; num4 < Chest.maxItems; num4++)
                                {
                                    player.bank[num4].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                    player.bank[num4].stack = binaryReader.ReadInt32();
                                    if (num >= 36)
                                    {
                                        player.bank[num4].Prefix((int)binaryReader.ReadByte());
                                    }
                                }
                                if (num >= 20)
                                {
                                    for (int num5 = 0; num5 < Chest.maxItems; num5++)
                                    {
                                        player.bank2[num5].SetDefaults(Item.VersionName(binaryReader.ReadString(), num));
                                        player.bank2[num5].stack = binaryReader.ReadInt32();
                                        if (num >= 36)
                                        {
                                            player.bank2[num5].Prefix((int)binaryReader.ReadByte());
                                        }
                                    }
                                }
                            }
                            if (num >= 11)
                            {
                                for (int num6 = 0; num6 < 10; num6++)
                                {
                                    player.buffType[num6] = binaryReader.ReadInt32();
                                    player.buffTime[num6] = binaryReader.ReadInt32();
                                }
                            }
                            for (int num7 = 0; num7 < 200; num7++)
                            {
                                int num8 = binaryReader.ReadInt32();
                                if (num8 == -1)
                                {
                                    break;
                                }
                                player.spX[num7] = num8;
                                player.spY[num7] = binaryReader.ReadInt32();
                                player.spI[num7] = binaryReader.ReadInt32();
                                player.spN[num7] = binaryReader.ReadString();
                            }
                            if (num >= 16)
                            {
                                player.hbLocked = binaryReader.ReadBoolean();
                            }
                            binaryReader.Close();
                        }
                    }
                    player.PlayerFrame();
                    File.Delete(text);
                    Player result = player;
                    return result;
                }
            }
            catch
            {
                flag = true;
            }
            if (flag)
            {
                try
                {
                    string text2 = playerPath + ".bak";
                    Player result;
                    if (File.Exists(text2))
                    {
                        File.Delete(playerPath);
                        File.Move(text2, playerPath);
                        result = Player.LoadPlayer(playerPath);
                        return result;
                    }
                    result = new Player();
                    return result;
                }
                catch
                {
                    Player result = new Player();
                    return result;
                }
            }
            return new Player();
        }
        public bool HasItem(int type)
        {
            for (int i = 0; i < 48; i++)
            {
                if (type == this.inventory[i].type)
                {
                    return true;
                }
            }
            return false;
        }
        public void QuickGrapple()
        {
            if (this.noItems)
            {
                return;
            }
            int num = -1;
            for (int i = 0; i < 48; i++)
            {
                if (this.inventory[i].shoot == 13 || this.inventory[i].shoot == 32 || this.inventory[i].shoot == 73)
                {
                    num = i;
                    break;
                }
            }
            if (num < 0)
            {
                return;
            }
            if (this.inventory[num].shoot == 73)
            {
                int num2 = 0;
                if (num >= 0)
                {
                    for (int j = 0; j < 1000; j++)
                    {
                        if (Main.projectile[j].active && Main.projectile[j].owner == Main.myPlayer && (Main.projectile[j].type == 73 || Main.projectile[j].type == 74))
                        {
                            num2++;
                        }
                    }
                }
                if (num2 > 1)
                {
                    num = -1;
                }
            }
            else
            {
                if (num >= 0)
                {
                    for (int k = 0; k < 1000; k++)
                    {
                        if (Main.projectile[k].active && Main.projectile[k].owner == Main.myPlayer && Main.projectile[k].type == this.inventory[num].shoot && Main.projectile[k].ai[0] != 2f)
                        {
                            num = -1;
                            break;
                        }
                    }
                }
            }
            if (num >= 0)
            {
                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, this.inventory[num].useSound);
                if (Main.netMode == 1 && this.whoAmi == Main.myPlayer)
                {
                    NetMessage.SendData(51, -1, -1, "", this.whoAmi, 2f, 0f, 0f, 0);
                }
                int num3 = this.inventory[num].shoot;
                float shootSpeed = this.inventory[num].shootSpeed;
                int damage = this.inventory[num].damage;
                float knockBack = this.inventory[num].knockBack;
                if (num3 == 13 || num3 == 32)
                {
                    this.grappling[0] = -1;
                    this.grapCount = 0;
                    for (int l = 0; l < 1000; l++)
                    {
                        if (Main.projectile[l].active && Main.projectile[l].owner == this.whoAmi && Main.projectile[l].type == 13)
                        {
                            Main.projectile[l].Kill();
                        }
                    }
                }
                if (num3 == 73)
                {
                    for (int m = 0; m < 1000; m++)
                    {
                        if (Main.projectile[m].active && Main.projectile[m].owner == this.whoAmi && Main.projectile[m].type == 73)
                        {
                            num3 = 74;
                        }
                    }
                }
                Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                float num4 = (float)Main.mouseX + Main.screenPosition.X - vector.X;
                float num5 = (float)Main.mouseY + Main.screenPosition.Y - vector.Y;
                float num6 = (float)Math.Sqrt((double)(num4 * num4 + num5 * num5));
                num6 = shootSpeed / num6;
                num4 *= num6;
                num5 *= num6;
                Projectile.NewProjectile(vector.X, vector.Y, num4, num5, num3, damage, knockBack, this.whoAmi);
            }
        }
        public Player()
        {
            for (int i = 0; i < 49; i++)
            {
                if (i < 11)
                {
                    this.armor[i] = new Item();
                    this.armor[i].name = "";
                }
                this.inventory[i] = new Item();
                this.inventory[i].name = "";
            }
            for (int j = 0; j < Chest.maxItems; j++)
            {
                this.bank[j] = new Item();
                this.bank[j].name = "";
                this.bank2[j] = new Item();
                this.bank2[j].name = "";
            }
            this.grappling[0] = -1;
            this.inventory[0].SetDefaults("Copper Shortsword");
            this.inventory[1].SetDefaults("Copper Pickaxe");
            this.inventory[2].SetDefaults("Copper Axe");
            if (Main.cEd)
            {
                this.inventory[3].SetDefaults(603, false);
            }
            for (int k = 0; k < 150; k++)
            {
                this.adjTile[k] = false;
                this.oldAdjTile[k] = false;
            }
        }
    }
}
