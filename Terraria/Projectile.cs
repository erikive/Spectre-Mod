using Microsoft.Xna.Framework;
using System;
namespace Terraria
{
    public class Projectile
    {
        public bool wet;
        public byte wetCount;
        public bool lavaWet;
        public int whoAmI;
        public static int maxAI = 2;
        public Vector2 position;
        public Vector2 lastPosition;
        public Vector2 velocity;
        public int width;
        public int height;
        public float scale = 1f;
        public float rotation;
        public int type;
        public int alpha;
        public int owner = 255;
        public bool active;
        public string name = "";
        public float[] ai = new float[Projectile.maxAI];
        public float[] localAI = new float[Projectile.maxAI];
        public int aiStyle;
        public int timeLeft;
        public int soundDelay;
        public int damage;
        public int direction;
        public int spriteDirection = 1;
        public bool hostile;
        public float knockBack;
        public bool friendly;
        public int penetrate = 1;
        public int identity;
        public float light;
        public bool netUpdate;
        public bool netUpdate2;
        public int netSpam;
        public Vector2[] oldPos = new Vector2[10];
        public int restrikeDelay;
        public bool tileCollide;
        public int maxUpdates;
        public int numUpdates;
        public bool ignoreWater;
        public bool hide;
        public bool ownerHitCheck;
        public int[] playerImmune = new int[255];
        public string miscText = "";
        public bool melee;
        public bool ranged;
        public bool magic;
        public int frameCounter;
        public int frame;
        public void SetDefaults(int Type)
        {
            for (int i = 0; i < this.oldPos.Length; i++)
            {
                this.oldPos[i].X = 0f;
                this.oldPos[i].Y = 0f;
            }
            for (int j = 0; j < Projectile.maxAI; j++)
            {
                this.ai[j] = 0f;
                this.localAI[j] = 0f;
            }
            for (int k = 0; k < 255; k++)
            {
                this.playerImmune[k] = 0;
            }
            this.soundDelay = 0;
            this.spriteDirection = 1;
            this.melee = false;
            this.ranged = false;
            this.magic = false;
            this.ownerHitCheck = false;
            this.hide = false;
            this.lavaWet = false;
            this.wetCount = 0;
            this.wet = false;
            this.ignoreWater = false;
            this.hostile = false;
            this.netUpdate = false;
            this.netUpdate2 = false;
            this.netSpam = 0;
            this.numUpdates = 0;
            this.maxUpdates = 0;
            this.identity = 0;
            this.restrikeDelay = 0;
            this.light = 0f;
            this.penetrate = 1;
            this.tileCollide = true;
            this.position = default(Vector2);
            this.velocity = default(Vector2);
            this.aiStyle = 0;
            this.alpha = 0;
            this.type = Type;
            this.active = true;
            this.rotation = 0f;
            this.scale = 1f;
            this.owner = 255;
            this.timeLeft = 3600;
            this.name = "";
            this.friendly = false;
            this.damage = 0;
            this.knockBack = 0f;
            this.miscText = "";
            if (this.type == 1)
            {
                this.name = "Wooden Arrow";
                this.width = 10;
                this.height = 10;
                this.aiStyle = 1;
                this.friendly = true;
                this.ranged = true;
            }
            else
            {
                if (this.type == 2)
                {
                    this.name = "Fire Arrow";
                    this.width = 10;
                    this.height = 10;
                    this.aiStyle = 1;
                    this.friendly = true;
                    this.light = 1f;
                    this.ranged = true;
                }
                else
                {
                    if (this.type == 3)
                    {
                        this.name = "Shuriken";
                        this.width = 22;
                        this.height = 22;
                        this.aiStyle = 2;
                        this.friendly = true;
                        this.penetrate = 4;
                        this.ranged = true;
                    }
                    else
                    {
                        if (this.type == 4)
                        {
                            this.name = "Unholy Arrow";
                            this.width = 10;
                            this.height = 10;
                            this.aiStyle = 1;
                            this.friendly = true;
                            this.light = 0.35f;
                            this.penetrate = 5;
                            this.ranged = true;
                        }
                        else
                        {
                            if (this.type == 5)
                            {
                                this.name = "Jester's Arrow";
                                this.width = 10;
                                this.height = 10;
                                this.aiStyle = 1;
                                this.friendly = true;
                                this.light = 0.4f;
                                this.penetrate = -1;
                                this.timeLeft = 40;
                                this.alpha = 100;
                                this.ignoreWater = true;
                                this.ranged = true;
                            }
                            else
                            {
                                if (this.type == 6)
                                {
                                    this.name = "Enchanted Boomerang";
                                    this.width = 22;
                                    this.height = 22;
                                    this.aiStyle = 3;
                                    this.friendly = true;
                                    this.penetrate = -1;
                                    this.melee = true;
                                    this.light = 0.4f;
                                }
                                else
                                {
                                    if (this.type == 7 || this.type == 8)
                                    {
                                        this.name = "Vilethorn";
                                        this.width = 28;
                                        this.height = 28;
                                        this.aiStyle = 4;
                                        this.friendly = true;
                                        this.penetrate = -1;
                                        this.tileCollide = false;
                                        this.alpha = 255;
                                        this.ignoreWater = true;
                                        this.magic = true;
                                    }
                                    else
                                    {
                                        if (this.type == 9)
                                        {
                                            this.name = "Starfury";
                                            this.width = 24;
                                            this.height = 24;
                                            this.aiStyle = 5;
                                            this.friendly = true;
                                            this.penetrate = 2;
                                            this.alpha = 50;
                                            this.scale = 0.8f;
                                            this.tileCollide = false;
                                            this.magic = true;
                                        }
                                        else
                                        {
                                            if (this.type == 10)
                                            {
                                                this.name = "Purification Powder";
                                                this.width = 64;
                                                this.height = 64;
                                                this.aiStyle = 6;
                                                this.friendly = true;
                                                this.tileCollide = false;
                                                this.penetrate = -1;
                                                this.alpha = 255;
                                                this.ignoreWater = true;
                                            }
                                            else
                                            {
                                                if (this.type == 11)
                                                {
                                                    this.name = "Vile Powder";
                                                    this.width = 48;
                                                    this.height = 48;
                                                    this.aiStyle = 6;
                                                    this.friendly = true;
                                                    this.tileCollide = false;
                                                    this.penetrate = -1;
                                                    this.alpha = 255;
                                                    this.ignoreWater = true;
                                                }
                                                else
                                                {
                                                    if (this.type == 12)
                                                    {
                                                        this.name = "Falling Star";
                                                        this.width = 16;
                                                        this.height = 16;
                                                        this.aiStyle = 5;
                                                        this.friendly = true;
                                                        this.penetrate = -1;
                                                        this.alpha = 50;
                                                        this.light = 1f;
                                                    }
                                                    else
                                                    {
                                                        if (this.type == 13)
                                                        {
                                                            this.name = "Hook";
                                                            this.width = 18;
                                                            this.height = 18;
                                                            this.aiStyle = 7;
                                                            this.friendly = true;
                                                            this.penetrate = -1;
                                                            this.tileCollide = false;
                                                            this.timeLeft *= 10;
                                                        }
                                                        else
                                                        {
                                                            if (this.type == 14)
                                                            {
                                                                this.name = "Bullet";
                                                                this.width = 4;
                                                                this.height = 4;
                                                                this.aiStyle = 1;
                                                                this.friendly = true;
                                                                this.penetrate = 1;
                                                                this.light = 0.5f;
                                                                this.alpha = 255;
                                                                this.maxUpdates = 1;
                                                                this.scale = 1.2f;
                                                                this.timeLeft = 600;
                                                                this.ranged = true;
                                                            }
                                                            else
                                                            {
                                                                if (this.type == 15)
                                                                {
                                                                    this.name = "Ball of Fire";
                                                                    this.width = 16;
                                                                    this.height = 16;
                                                                    this.aiStyle = 8;
                                                                    this.friendly = true;
                                                                    this.light = 0.8f;
                                                                    this.alpha = 100;
                                                                    this.magic = true;
                                                                }
                                                                else
                                                                {
                                                                    if (this.type == 16)
                                                                    {
                                                                        this.name = "Magic Missile";
                                                                        this.width = 10;
                                                                        this.height = 10;
                                                                        this.aiStyle = 9;
                                                                        this.friendly = true;
                                                                        this.light = 0.8f;
                                                                        this.alpha = 100;
                                                                        this.magic = true;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.type == 17)
                                                                        {
                                                                            this.name = "Dirt Ball";
                                                                            this.width = 10;
                                                                            this.height = 10;
                                                                            this.aiStyle = 10;
                                                                            this.friendly = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type == 18)
                                                                            {
                                                                                this.name = "Orb of Light";
                                                                                this.width = 32;
                                                                                this.height = 32;
                                                                                this.aiStyle = 11;
                                                                                this.friendly = true;
                                                                                this.light = 0.45f;
                                                                                this.alpha = 150;
                                                                                this.tileCollide = false;
                                                                                this.penetrate = -1;
                                                                                this.timeLeft *= 5;
                                                                                this.ignoreWater = true;
                                                                                this.scale = 0.8f;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type == 19)
                                                                                {
                                                                                    this.name = "Flamarang";
                                                                                    this.width = 22;
                                                                                    this.height = 22;
                                                                                    this.aiStyle = 3;
                                                                                    this.friendly = true;
                                                                                    this.penetrate = -1;
                                                                                    this.light = 1f;
                                                                                    this.melee = true;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.type == 20)
                                                                                    {
                                                                                        this.name = "Green Laser";
                                                                                        this.width = 4;
                                                                                        this.height = 4;
                                                                                        this.aiStyle = 1;
                                                                                        this.friendly = true;
                                                                                        this.penetrate = 3;
                                                                                        this.light = 0.75f;
                                                                                        this.alpha = 255;
                                                                                        this.maxUpdates = 2;
                                                                                        this.scale = 1.4f;
                                                                                        this.timeLeft = 600;
                                                                                        this.magic = true;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.type == 21)
                                                                                        {
                                                                                            this.name = "Bone";
                                                                                            this.width = 16;
                                                                                            this.height = 16;
                                                                                            this.aiStyle = 2;
                                                                                            this.scale = 1.2f;
                                                                                            this.friendly = true;
                                                                                            this.ranged = true;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.type == 22)
                                                                                            {
                                                                                                this.name = "Water Stream";
                                                                                                this.width = 18;
                                                                                                this.height = 18;
                                                                                                this.aiStyle = 12;
                                                                                                this.friendly = true;
                                                                                                this.alpha = 255;
                                                                                                this.penetrate = -1;
                                                                                                this.maxUpdates = 2;
                                                                                                this.ignoreWater = true;
                                                                                                this.magic = true;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (this.type == 23)
                                                                                                {
                                                                                                    this.name = "Harpoon";
                                                                                                    this.width = 4;
                                                                                                    this.height = 4;
                                                                                                    this.aiStyle = 13;
                                                                                                    this.friendly = true;
                                                                                                    this.penetrate = -1;
                                                                                                    this.alpha = 255;
                                                                                                    this.ranged = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.type == 24)
                                                                                                    {
                                                                                                        this.name = "Spiky Ball";
                                                                                                        this.width = 14;
                                                                                                        this.height = 14;
                                                                                                        this.aiStyle = 14;
                                                                                                        this.friendly = true;
                                                                                                        this.penetrate = 6;
                                                                                                        this.ranged = true;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.type == 25)
                                                                                                        {
                                                                                                            this.name = "Ball 'O Hurt";
                                                                                                            this.width = 22;
                                                                                                            this.height = 22;
                                                                                                            this.aiStyle = 15;
                                                                                                            this.friendly = true;
                                                                                                            this.penetrate = -1;
                                                                                                            this.melee = true;
                                                                                                            this.scale = 0.8f;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (this.type == 26)
                                                                                                            {
                                                                                                                this.name = "Blue Moon";
                                                                                                                this.width = 22;
                                                                                                                this.height = 22;
                                                                                                                this.aiStyle = 15;
                                                                                                                this.friendly = true;
                                                                                                                this.penetrate = -1;
                                                                                                                this.melee = true;
                                                                                                                this.scale = 0.8f;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (this.type == 27)
                                                                                                                {
                                                                                                                    this.name = "Water Bolt";
                                                                                                                    this.width = 16;
                                                                                                                    this.height = 16;
                                                                                                                    this.aiStyle = 8;
                                                                                                                    this.friendly = true;
                                                                                                                    this.light = 0.8f;
                                                                                                                    this.alpha = 200;
                                                                                                                    this.timeLeft /= 2;
                                                                                                                    this.penetrate = 10;
                                                                                                                    this.magic = true;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (this.type == 28)
                                                                                                                    {
                                                                                                                        this.name = "Bomb";
                                                                                                                        this.width = 22;
                                                                                                                        this.height = 22;
                                                                                                                        this.aiStyle = 16;
                                                                                                                        this.friendly = true;
                                                                                                                        this.penetrate = -1;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (this.type == 29)
                                                                                                                        {
                                                                                                                            this.name = "Dynamite";
                                                                                                                            this.width = 10;
                                                                                                                            this.height = 10;
                                                                                                                            this.aiStyle = 16;
                                                                                                                            this.friendly = true;
                                                                                                                            this.penetrate = -1;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (this.type == 30)
                                                                                                                            {
                                                                                                                                this.name = "Grenade";
                                                                                                                                this.width = 14;
                                                                                                                                this.height = 14;
                                                                                                                                this.aiStyle = 16;
                                                                                                                                this.friendly = true;
                                                                                                                                this.penetrate = -1;
                                                                                                                                this.ranged = true;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (this.type == 31)
                                                                                                                                {
                                                                                                                                    this.name = "Sand Ball";
                                                                                                                                    this.knockBack = 6f;
                                                                                                                                    this.width = 10;
                                                                                                                                    this.height = 10;
                                                                                                                                    this.aiStyle = 10;
                                                                                                                                    this.friendly = true;
                                                                                                                                    this.hostile = true;
                                                                                                                                    this.penetrate = -1;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (this.type == 32)
                                                                                                                                    {
                                                                                                                                        this.name = "Ivy Whip";
                                                                                                                                        this.width = 18;
                                                                                                                                        this.height = 18;
                                                                                                                                        this.aiStyle = 7;
                                                                                                                                        this.friendly = true;
                                                                                                                                        this.penetrate = -1;
                                                                                                                                        this.tileCollide = false;
                                                                                                                                        this.timeLeft *= 10;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (this.type == 33)
                                                                                                                                        {
                                                                                                                                            this.name = "Thorn Chakrum";
                                                                                                                                            this.width = 28;
                                                                                                                                            this.height = 28;
                                                                                                                                            this.aiStyle = 3;
                                                                                                                                            this.friendly = true;
                                                                                                                                            this.scale = 0.9f;
                                                                                                                                            this.penetrate = -1;
                                                                                                                                            this.melee = true;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (this.type == 34)
                                                                                                                                            {
                                                                                                                                                this.name = "Flamelash";
                                                                                                                                                this.width = 14;
                                                                                                                                                this.height = 14;
                                                                                                                                                this.aiStyle = 9;
                                                                                                                                                this.friendly = true;
                                                                                                                                                this.light = 0.8f;
                                                                                                                                                this.alpha = 100;
                                                                                                                                                this.penetrate = 1;
                                                                                                                                                this.magic = true;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (this.type == 35)
                                                                                                                                                {
                                                                                                                                                    this.name = "Sunfury";
                                                                                                                                                    this.width = 22;
                                                                                                                                                    this.height = 22;
                                                                                                                                                    this.aiStyle = 15;
                                                                                                                                                    this.friendly = true;
                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                    this.melee = true;
                                                                                                                                                    this.scale = 0.8f;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (this.type == 36)
                                                                                                                                                    {
                                                                                                                                                        this.name = "Meteor Shot";
                                                                                                                                                        this.width = 4;
                                                                                                                                                        this.height = 4;
                                                                                                                                                        this.aiStyle = 1;
                                                                                                                                                        this.friendly = true;
                                                                                                                                                        this.penetrate = 2;
                                                                                                                                                        this.light = 0.6f;
                                                                                                                                                        this.alpha = 255;
                                                                                                                                                        this.maxUpdates = 1;
                                                                                                                                                        this.scale = 1.4f;
                                                                                                                                                        this.timeLeft = 600;
                                                                                                                                                        this.ranged = true;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (this.type == 37)
                                                                                                                                                        {
                                                                                                                                                            this.name = "Sticky Bomb";
                                                                                                                                                            this.width = 22;
                                                                                                                                                            this.height = 22;
                                                                                                                                                            this.aiStyle = 16;
                                                                                                                                                            this.friendly = true;
                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (this.type == 38)
                                                                                                                                                            {
                                                                                                                                                                this.name = "Harpy Feather";
                                                                                                                                                                this.width = 14;
                                                                                                                                                                this.height = 14;
                                                                                                                                                                this.aiStyle = 0;
                                                                                                                                                                this.hostile = true;
                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                this.aiStyle = 1;
                                                                                                                                                                this.tileCollide = true;
                                                                                                                                                            }
                                                                                                                                                            else
                                                                                                                                                            {
                                                                                                                                                                if (this.type == 39)
                                                                                                                                                                {
                                                                                                                                                                    this.name = "Mud Ball";
                                                                                                                                                                    this.knockBack = 6f;
                                                                                                                                                                    this.width = 10;
                                                                                                                                                                    this.height = 10;
                                                                                                                                                                    this.aiStyle = 10;
                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                }
                                                                                                                                                                else
                                                                                                                                                                {
                                                                                                                                                                    if (this.type == 40)
                                                                                                                                                                    {
                                                                                                                                                                        this.name = "Ash Ball";
                                                                                                                                                                        this.knockBack = 6f;
                                                                                                                                                                        this.width = 10;
                                                                                                                                                                        this.height = 10;
                                                                                                                                                                        this.aiStyle = 10;
                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                        this.hostile = true;
                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                    }
                                                                                                                                                                    else
                                                                                                                                                                    {
                                                                                                                                                                        if (this.type == 41)
                                                                                                                                                                        {
                                                                                                                                                                            this.name = "Hellfire Arrow";
                                                                                                                                                                            this.width = 10;
                                                                                                                                                                            this.height = 10;
                                                                                                                                                                            this.aiStyle = 1;
                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                            this.ranged = true;
                                                                                                                                                                            this.light = 0.3f;
                                                                                                                                                                        }
                                                                                                                                                                        else
                                                                                                                                                                        {
                                                                                                                                                                            if (this.type == 42)
                                                                                                                                                                            {
                                                                                                                                                                                this.name = "Sand Ball";
                                                                                                                                                                                this.knockBack = 8f;
                                                                                                                                                                                this.width = 10;
                                                                                                                                                                                this.height = 10;
                                                                                                                                                                                this.aiStyle = 10;
                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                this.maxUpdates = 1;
                                                                                                                                                                            }
                                                                                                                                                                            else
                                                                                                                                                                            {
                                                                                                                                                                                if (this.type == 43)
                                                                                                                                                                                {
                                                                                                                                                                                    this.name = "Tombstone";
                                                                                                                                                                                    this.knockBack = 12f;
                                                                                                                                                                                    this.width = 24;
                                                                                                                                                                                    this.height = 24;
                                                                                                                                                                                    this.aiStyle = 17;
                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                }
                                                                                                                                                                                else
                                                                                                                                                                                {
                                                                                                                                                                                    if (this.type == 44)
                                                                                                                                                                                    {
                                                                                                                                                                                        this.name = "Demon Sickle";
                                                                                                                                                                                        this.width = 48;
                                                                                                                                                                                        this.height = 48;
                                                                                                                                                                                        this.alpha = 100;
                                                                                                                                                                                        this.light = 0.2f;
                                                                                                                                                                                        this.aiStyle = 18;
                                                                                                                                                                                        this.hostile = true;
                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                        this.tileCollide = true;
                                                                                                                                                                                        this.scale = 0.9f;
                                                                                                                                                                                    }
                                                                                                                                                                                    else
                                                                                                                                                                                    {
                                                                                                                                                                                        if (this.type == 45)
                                                                                                                                                                                        {
                                                                                                                                                                                            this.name = "Demon Scythe";
                                                                                                                                                                                            this.width = 48;
                                                                                                                                                                                            this.height = 48;
                                                                                                                                                                                            this.alpha = 100;
                                                                                                                                                                                            this.light = 0.2f;
                                                                                                                                                                                            this.aiStyle = 18;
                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                            this.penetrate = 5;
                                                                                                                                                                                            this.tileCollide = true;
                                                                                                                                                                                            this.scale = 0.9f;
                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                        }
                                                                                                                                                                                        else
                                                                                                                                                                                        {
                                                                                                                                                                                            if (this.type == 46)
                                                                                                                                                                                            {
                                                                                                                                                                                                this.name = "Dark Lance";
                                                                                                                                                                                                this.width = 20;
                                                                                                                                                                                                this.height = 20;
                                                                                                                                                                                                this.aiStyle = 19;
                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                this.scale = 1.1f;
                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                            }
                                                                                                                                                                                            else
                                                                                                                                                                                            {
                                                                                                                                                                                                if (this.type == 47)
                                                                                                                                                                                                {
                                                                                                                                                                                                    this.name = "Trident";
                                                                                                                                                                                                    this.width = 18;
                                                                                                                                                                                                    this.height = 18;
                                                                                                                                                                                                    this.aiStyle = 19;
                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                    this.tileCollide = false;
                                                                                                                                                                                                    this.scale = 1.1f;
                                                                                                                                                                                                    this.hide = true;
                                                                                                                                                                                                    this.ownerHitCheck = true;
                                                                                                                                                                                                    this.melee = true;
                                                                                                                                                                                                }
                                                                                                                                                                                                else
                                                                                                                                                                                                {
                                                                                                                                                                                                    if (this.type == 48)
                                                                                                                                                                                                    {
                                                                                                                                                                                                        this.name = "Throwing Knife";
                                                                                                                                                                                                        this.width = 12;
                                                                                                                                                                                                        this.height = 12;
                                                                                                                                                                                                        this.aiStyle = 2;
                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                        this.penetrate = 2;
                                                                                                                                                                                                        this.ranged = true;
                                                                                                                                                                                                    }
                                                                                                                                                                                                    else
                                                                                                                                                                                                    {
                                                                                                                                                                                                        if (this.type == 49)
                                                                                                                                                                                                        {
                                                                                                                                                                                                            this.name = "Spear";
                                                                                                                                                                                                            this.width = 18;
                                                                                                                                                                                                            this.height = 18;
                                                                                                                                                                                                            this.aiStyle = 19;
                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                            this.scale = 1.2f;
                                                                                                                                                                                                            this.hide = true;
                                                                                                                                                                                                            this.ownerHitCheck = true;
                                                                                                                                                                                                            this.melee = true;
                                                                                                                                                                                                        }
                                                                                                                                                                                                        else
                                                                                                                                                                                                        {
                                                                                                                                                                                                            if (this.type == 50)
                                                                                                                                                                                                            {
                                                                                                                                                                                                                this.name = "Glowstick";
                                                                                                                                                                                                                this.width = 6;
                                                                                                                                                                                                                this.height = 6;
                                                                                                                                                                                                                this.aiStyle = 14;
                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                this.alpha = 75;
                                                                                                                                                                                                                this.light = 1f;
                                                                                                                                                                                                                this.timeLeft *= 5;
                                                                                                                                                                                                            }
                                                                                                                                                                                                            else
                                                                                                                                                                                                            {
                                                                                                                                                                                                                if (this.type == 51)
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    this.name = "Seed";
                                                                                                                                                                                                                    this.width = 8;
                                                                                                                                                                                                                    this.height = 8;
                                                                                                                                                                                                                    this.aiStyle = 1;
                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                }
                                                                                                                                                                                                                else
                                                                                                                                                                                                                {
                                                                                                                                                                                                                    if (this.type == 52)
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        this.name = "Wooden Boomerang";
                                                                                                                                                                                                                        this.width = 22;
                                                                                                                                                                                                                        this.height = 22;
                                                                                                                                                                                                                        this.aiStyle = 3;
                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                        this.melee = true;
                                                                                                                                                                                                                    }
                                                                                                                                                                                                                    else
                                                                                                                                                                                                                    {
                                                                                                                                                                                                                        if (this.type == 53)
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            this.name = "Sticky Glowstick";
                                                                                                                                                                                                                            this.width = 6;
                                                                                                                                                                                                                            this.height = 6;
                                                                                                                                                                                                                            this.aiStyle = 14;
                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                            this.alpha = 75;
                                                                                                                                                                                                                            this.light = 1f;
                                                                                                                                                                                                                            this.timeLeft *= 5;
                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                        }
                                                                                                                                                                                                                        else
                                                                                                                                                                                                                        {
                                                                                                                                                                                                                            if (this.type == 54)
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                this.name = "Poisoned Knife";
                                                                                                                                                                                                                                this.width = 12;
                                                                                                                                                                                                                                this.height = 12;
                                                                                                                                                                                                                                this.aiStyle = 2;
                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                this.penetrate = 2;
                                                                                                                                                                                                                                this.ranged = true;
                                                                                                                                                                                                                            }
                                                                                                                                                                                                                            else
                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                if (this.type == 55)
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    this.name = "Stinger";
                                                                                                                                                                                                                                    this.width = 10;
                                                                                                                                                                                                                                    this.height = 10;
                                                                                                                                                                                                                                    this.aiStyle = 0;
                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                    this.aiStyle = 1;
                                                                                                                                                                                                                                    this.tileCollide = true;
                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                    if (this.type == 56)
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        this.name = "Ebonsand Ball";
                                                                                                                                                                                                                                        this.knockBack = 6f;
                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                        this.height = 10;
                                                                                                                                                                                                                                        this.aiStyle = 10;
                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                        this.hostile = true;
                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                        if (this.type == 57)
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            this.name = "Cobalt Chainsaw";
                                                                                                                                                                                                                                            this.width = 18;
                                                                                                                                                                                                                                            this.height = 18;
                                                                                                                                                                                                                                            this.aiStyle = 20;
                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                            this.hide = true;
                                                                                                                                                                                                                                            this.ownerHitCheck = true;
                                                                                                                                                                                                                                            this.melee = true;
                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                            if (this.type == 58)
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                this.name = "Mythril Chainsaw";
                                                                                                                                                                                                                                                this.width = 18;
                                                                                                                                                                                                                                                this.height = 18;
                                                                                                                                                                                                                                                this.aiStyle = 20;
                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                                                                                this.scale = 1.08f;
                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                if (this.type == 59)
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    this.name = "Cobalt Drill";
                                                                                                                                                                                                                                                    this.width = 22;
                                                                                                                                                                                                                                                    this.height = 22;
                                                                                                                                                                                                                                                    this.aiStyle = 20;
                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                    this.tileCollide = false;
                                                                                                                                                                                                                                                    this.hide = true;
                                                                                                                                                                                                                                                    this.ownerHitCheck = true;
                                                                                                                                                                                                                                                    this.melee = true;
                                                                                                                                                                                                                                                    this.scale = 0.9f;
                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                    if (this.type == 60)
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        this.name = "Mythril Drill";
                                                                                                                                                                                                                                                        this.width = 22;
                                                                                                                                                                                                                                                        this.height = 22;
                                                                                                                                                                                                                                                        this.aiStyle = 20;
                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                        this.tileCollide = false;
                                                                                                                                                                                                                                                        this.hide = true;
                                                                                                                                                                                                                                                        this.ownerHitCheck = true;
                                                                                                                                                                                                                                                        this.melee = true;
                                                                                                                                                                                                                                                        this.scale = 0.9f;
                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                        if (this.type == 61)
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            this.name = "Adamantite Chainsaw";
                                                                                                                                                                                                                                                            this.width = 18;
                                                                                                                                                                                                                                                            this.height = 18;
                                                                                                                                                                                                                                                            this.aiStyle = 20;
                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                                            this.hide = true;
                                                                                                                                                                                                                                                            this.ownerHitCheck = true;
                                                                                                                                                                                                                                                            this.melee = true;
                                                                                                                                                                                                                                                            this.scale = 1.16f;
                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                            if (this.type == 62)
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                this.name = "Adamantite Drill";
                                                                                                                                                                                                                                                                this.width = 22;
                                                                                                                                                                                                                                                                this.height = 22;
                                                                                                                                                                                                                                                                this.aiStyle = 20;
                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                                                                                                this.scale = 0.9f;
                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                if (this.type == 63)
                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                    this.name = "The Dao of Pow";
                                                                                                                                                                                                                                                                    this.width = 22;
                                                                                                                                                                                                                                                                    this.height = 22;
                                                                                                                                                                                                                                                                    this.aiStyle = 15;
                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                    this.melee = true;
                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                    if (this.type == 64)
                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                        this.name = "Mythril Halberd";
                                                                                                                                                                                                                                                                        this.width = 18;
                                                                                                                                                                                                                                                                        this.height = 18;
                                                                                                                                                                                                                                                                        this.aiStyle = 19;
                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                        this.tileCollide = false;
                                                                                                                                                                                                                                                                        this.scale = 1.25f;
                                                                                                                                                                                                                                                                        this.hide = true;
                                                                                                                                                                                                                                                                        this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                        this.melee = true;
                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                        if (this.type == 65)
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            this.name = "Ebonsand Ball";
                                                                                                                                                                                                                                                                            this.knockBack = 6f;
                                                                                                                                                                                                                                                                            this.width = 10;
                                                                                                                                                                                                                                                                            this.height = 10;
                                                                                                                                                                                                                                                                            this.aiStyle = 10;
                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                                                            this.maxUpdates = 1;
                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                            if (this.type == 66)
                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                this.name = "Adamantite Glaive";
                                                                                                                                                                                                                                                                                this.width = 18;
                                                                                                                                                                                                                                                                                this.height = 18;
                                                                                                                                                                                                                                                                                this.aiStyle = 19;
                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                                                                                                this.scale = 1.27f;
                                                                                                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                if (this.type == 67)
                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                    this.name = "Pearl Sand Ball";
                                                                                                                                                                                                                                                                                    this.knockBack = 6f;
                                                                                                                                                                                                                                                                                    this.width = 10;
                                                                                                                                                                                                                                                                                    this.height = 10;
                                                                                                                                                                                                                                                                                    this.aiStyle = 10;
                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                    if (this.type == 68)
                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                        this.name = "Pearl Sand Ball";
                                                                                                                                                                                                                                                                                        this.knockBack = 6f;
                                                                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                                                                        this.height = 10;
                                                                                                                                                                                                                                                                                        this.aiStyle = 10;
                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                        this.maxUpdates = 1;
                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                        if (this.type == 69)
                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                            this.name = "Holy Water";
                                                                                                                                                                                                                                                                                            this.width = 14;
                                                                                                                                                                                                                                                                                            this.height = 14;
                                                                                                                                                                                                                                                                                            this.aiStyle = 2;
                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                            this.penetrate = 1;
                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                            if (this.type == 70)
                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                this.name = "Unholy Water";
                                                                                                                                                                                                                                                                                                this.width = 14;
                                                                                                                                                                                                                                                                                                this.height = 14;
                                                                                                                                                                                                                                                                                                this.aiStyle = 2;
                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                this.penetrate = 1;
                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                if (this.type == 71)
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                    this.name = "Gravel Ball";
                                                                                                                                                                                                                                                                                                    this.knockBack = 6f;
                                                                                                                                                                                                                                                                                                    this.width = 10;
                                                                                                                                                                                                                                                                                                    this.height = 10;
                                                                                                                                                                                                                                                                                                    this.aiStyle = 10;
                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                    if (this.type == 72)
                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                        this.name = "Blue Fairy";
                                                                                                                                                                                                                                                                                                        this.width = 18;
                                                                                                                                                                                                                                                                                                        this.height = 18;
                                                                                                                                                                                                                                                                                                        this.aiStyle = 11;
                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                        this.light = 0.9f;
                                                                                                                                                                                                                                                                                                        this.tileCollide = false;
                                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                                        this.timeLeft *= 5;
                                                                                                                                                                                                                                                                                                        this.ignoreWater = true;
                                                                                                                                                                                                                                                                                                        this.scale = 0.8f;
                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                        if (this.type == 73 || this.type == 74)
                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                            this.name = "Hook";
                                                                                                                                                                                                                                                                                                            this.width = 18;
                                                                                                                                                                                                                                                                                                            this.height = 18;
                                                                                                                                                                                                                                                                                                            this.aiStyle = 7;
                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                                                                                            this.timeLeft *= 10;
                                                                                                                                                                                                                                                                                                            this.light = 0.4f;
                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                            if (this.type == 75)
                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                this.name = "Happy Bomb";
                                                                                                                                                                                                                                                                                                                this.width = 22;
                                                                                                                                                                                                                                                                                                                this.height = 22;
                                                                                                                                                                                                                                                                                                                this.aiStyle = 16;
                                                                                                                                                                                                                                                                                                                this.hostile = true;
                                                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                if (this.type == 76 || this.type == 77 || this.type == 78)
                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                    if (this.type == 76)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                                                                                                        this.height = 22;
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        if (this.type == 77)
                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                            this.width = 18;
                                                                                                                                                                                                                                                                                                                            this.height = 24;
                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                            this.width = 22;
                                                                                                                                                                                                                                                                                                                            this.height = 24;
                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    this.name = "Note";
                                                                                                                                                                                                                                                                                                                    this.aiStyle = 21;
                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                    this.alpha = 100;
                                                                                                                                                                                                                                                                                                                    this.light = 0.3f;
                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                    this.timeLeft = 180;
                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                    if (this.type == 79)
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        this.name = "Rainbow";
                                                                                                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                                                                                                        this.height = 10;
                                                                                                                                                                                                                                                                                                                        this.aiStyle = 9;
                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                        this.light = 0.8f;
                                                                                                                                                                                                                                                                                                                        this.alpha = 255;
                                                                                                                                                                                                                                                                                                                        this.magic = true;
                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                        if (this.type == 80)
                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                            this.name = "Ice Block";
                                                                                                                                                                                                                                                                                                                            this.width = 16;
                                                                                                                                                                                                                                                                                                                            this.height = 16;
                                                                                                                                                                                                                                                                                                                            this.aiStyle = 22;
                                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                            this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                            if (this.type == 81)
                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                this.name = "Wooden Arrow";
                                                                                                                                                                                                                                                                                                                                this.width = 10;
                                                                                                                                                                                                                                                                                                                                this.height = 10;
                                                                                                                                                                                                                                                                                                                                this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                this.hostile = true;
                                                                                                                                                                                                                                                                                                                                this.ranged = true;
                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                if (this.type == 82)
                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                    this.name = "Flaming Arrow";
                                                                                                                                                                                                                                                                                                                                    this.width = 10;
                                                                                                                                                                                                                                                                                                                                    this.height = 10;
                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                    if (this.type == 83)
                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                        this.name = "Eye Laser";
                                                                                                                                                                                                                                                                                                                                        this.width = 4;
                                                                                                                                                                                                                                                                                                                                        this.height = 4;
                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                        this.hostile = true;
                                                                                                                                                                                                                                                                                                                                        this.penetrate = 3;
                                                                                                                                                                                                                                                                                                                                        this.light = 0.75f;
                                                                                                                                                                                                                                                                                                                                        this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                        this.maxUpdates = 2;
                                                                                                                                                                                                                                                                                                                                        this.scale = 1.7f;
                                                                                                                                                                                                                                                                                                                                        this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                        this.magic = true;
                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                        if (this.type == 84)
                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                            this.name = "Pink Laser";
                                                                                                                                                                                                                                                                                                                                            this.width = 4;
                                                                                                                                                                                                                                                                                                                                            this.height = 4;
                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                            this.hostile = true;
                                                                                                                                                                                                                                                                                                                                            this.penetrate = 3;
                                                                                                                                                                                                                                                                                                                                            this.light = 0.75f;
                                                                                                                                                                                                                                                                                                                                            this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                            this.maxUpdates = 2;
                                                                                                                                                                                                                                                                                                                                            this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                            this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                            if (this.type == 85)
                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                this.name = "Flames";
                                                                                                                                                                                                                                                                                                                                                this.width = 6;
                                                                                                                                                                                                                                                                                                                                                this.height = 6;
                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 23;
                                                                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                this.penetrate = 3;
                                                                                                                                                                                                                                                                                                                                                this.maxUpdates = 2;
                                                                                                                                                                                                                                                                                                                                                this.magic = true;
                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                if (this.type == 86)
                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                    this.name = "Pink Fairy";
                                                                                                                                                                                                                                                                                                                                                    this.width = 18;
                                                                                                                                                                                                                                                                                                                                                    this.height = 18;
                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 11;
                                                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                    this.light = 0.9f;
                                                                                                                                                                                                                                                                                                                                                    this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                    this.timeLeft *= 5;
                                                                                                                                                                                                                                                                                                                                                    this.ignoreWater = true;
                                                                                                                                                                                                                                                                                                                                                    this.scale = 0.8f;
                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                    if (this.type == 87)
                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                        this.name = "Pink Fairy";
                                                                                                                                                                                                                                                                                                                                                        this.width = 18;
                                                                                                                                                                                                                                                                                                                                                        this.height = 18;
                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 11;
                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                        this.light = 0.9f;
                                                                                                                                                                                                                                                                                                                                                        this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                        this.timeLeft *= 5;
                                                                                                                                                                                                                                                                                                                                                        this.ignoreWater = true;
                                                                                                                                                                                                                                                                                                                                                        this.scale = 0.8f;
                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                        if (this.type == 88)
                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                            this.name = "Purple Laser";
                                                                                                                                                                                                                                                                                                                                                            this.width = 6;
                                                                                                                                                                                                                                                                                                                                                            this.height = 6;
                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                            this.penetrate = 3;
                                                                                                                                                                                                                                                                                                                                                            this.light = 0.75f;
                                                                                                                                                                                                                                                                                                                                                            this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                            this.maxUpdates = 4;
                                                                                                                                                                                                                                                                                                                                                            this.scale = 1.4f;
                                                                                                                                                                                                                                                                                                                                                            this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                            if (this.type == 89)
                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                this.name = "Crystal Bullet";
                                                                                                                                                                                                                                                                                                                                                                this.width = 4;
                                                                                                                                                                                                                                                                                                                                                                this.height = 4;
                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                this.penetrate = 1;
                                                                                                                                                                                                                                                                                                                                                                this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                                                                this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                this.maxUpdates = 1;
                                                                                                                                                                                                                                                                                                                                                                this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                                                this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                                this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                if (this.type == 90)
                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                    this.name = "Crystal Shard";
                                                                                                                                                                                                                                                                                                                                                                    this.width = 6;
                                                                                                                                                                                                                                                                                                                                                                    this.height = 6;
                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 24;
                                                                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = 1;
                                                                                                                                                                                                                                                                                                                                                                    this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                                                                    this.alpha = 50;
                                                                                                                                                                                                                                                                                                                                                                    this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                                                    this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                    this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 91)
                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                        this.name = "Holy Arrow";
                                                                                                                                                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                                                                                                                                                        this.height = 10;
                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                        this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                        if (this.type == 92)
                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                            this.name = "Hallow Star";
                                                                                                                                                                                                                                                                                                                                                                            this.width = 24;
                                                                                                                                                                                                                                                                                                                                                                            this.height = 24;
                                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 5;
                                                                                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                            this.penetrate = 2;
                                                                                                                                                                                                                                                                                                                                                                            this.alpha = 50;
                                                                                                                                                                                                                                                                                                                                                                            this.scale = 0.8f;
                                                                                                                                                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                            if (this.type == 93)
                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                this.light = 0.15f;
                                                                                                                                                                                                                                                                                                                                                                                this.name = "Magic Dagger";
                                                                                                                                                                                                                                                                                                                                                                                this.width = 12;
                                                                                                                                                                                                                                                                                                                                                                                this.height = 12;
                                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 2;
                                                                                                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                this.penetrate = 2;
                                                                                                                                                                                                                                                                                                                                                                                this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                if (this.type == 94)
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    this.ignoreWater = true;
                                                                                                                                                                                                                                                                                                                                                                                    this.name = "Crystal Storm";
                                                                                                                                                                                                                                                                                                                                                                                    this.width = 8;
                                                                                                                                                                                                                                                                                                                                                                                    this.height = 8;
                                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 24;
                                                                                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                    this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                                                                                    this.alpha = 50;
                                                                                                                                                                                                                                                                                                                                                                                    this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                                                                    this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                                                    this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                                    this.tileCollide = true;
                                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = 1;
                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 95)
                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                        this.name = "Cursed Flame";
                                                                                                                                                                                                                                                                                                                                                                                        this.width = 16;
                                                                                                                                                                                                                                                                                                                                                                                        this.height = 16;
                                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 8;
                                                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                        this.light = 0.8f;
                                                                                                                                                                                                                                                                                                                                                                                        this.alpha = 100;
                                                                                                                                                                                                                                                                                                                                                                                        this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                                        this.penetrate = 2;
                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                        if (this.type == 96)
                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                            this.name = "Cursed Flame";
                                                                                                                                                                                                                                                                                                                                                                                            this.width = 16;
                                                                                                                                                                                                                                                                                                                                                                                            this.height = 16;
                                                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 8;
                                                                                                                                                                                                                                                                                                                                                                                            this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                            this.light = 0.8f;
                                                                                                                                                                                                                                                                                                                                                                                            this.alpha = 100;
                                                                                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                            this.scale = 0.9f;
                                                                                                                                                                                                                                                                                                                                                                                            this.scale = 1.3f;
                                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                            if (this.type == 97)
                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                this.name = "Cobalt Naginata";
                                                                                                                                                                                                                                                                                                                                                                                                this.width = 18;
                                                                                                                                                                                                                                                                                                                                                                                                this.height = 18;
                                                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 19;
                                                                                                                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                                                this.scale = 1.1f;
                                                                                                                                                                                                                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                if (this.type == 98)
                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                    this.name = "Poison Dart";
                                                                                                                                                                                                                                                                                                                                                                                                    this.width = 10;
                                                                                                                                                                                                                                                                                                                                                                                                    this.height = 10;
                                                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 99)
                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                        this.name = "Boulder";
                                                                                                                                                                                                                                                                                                                                                                                                        this.width = 31;
                                                                                                                                                                                                                                                                                                                                                                                                        this.height = 31;
                                                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 25;
                                                                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                        this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                        this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                        if (this.type == 100)
                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                            this.name = "Death Laser";
                                                                                                                                                                                                                                                                                                                                                                                                            this.width = 4;
                                                                                                                                                                                                                                                                                                                                                                                                            this.height = 4;
                                                                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                                                            this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                            this.penetrate = 3;
                                                                                                                                                                                                                                                                                                                                                                                                            this.light = 0.75f;
                                                                                                                                                                                                                                                                                                                                                                                                            this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                                                            this.maxUpdates = 2;
                                                                                                                                                                                                                                                                                                                                                                                                            this.scale = 1.8f;
                                                                                                                                                                                                                                                                                                                                                                                                            this.timeLeft = 1200;
                                                                                                                                                                                                                                                                                                                                                                                                            this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                            if (this.type == 101)
                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                this.name = "Eye Fire";
                                                                                                                                                                                                                                                                                                                                                                                                                this.width = 6;
                                                                                                                                                                                                                                                                                                                                                                                                                this.height = 6;
                                                                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 23;
                                                                                                                                                                                                                                                                                                                                                                                                                this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                                this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                this.maxUpdates = 3;
                                                                                                                                                                                                                                                                                                                                                                                                                this.magic = true;
                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                if (this.type == 102)
                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                    this.name = "Bomb";
                                                                                                                                                                                                                                                                                                                                                                                                                    this.width = 22;
                                                                                                                                                                                                                                                                                                                                                                                                                    this.height = 22;
                                                                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 16;
                                                                                                                                                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 103)
                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                        this.name = "Cursed Arrow";
                                                                                                                                                                                                                                                                                                                                                                                                                        this.width = 10;
                                                                                                                                                                                                                                                                                                                                                                                                                        this.height = 10;
                                                                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                        this.light = 1f;
                                                                                                                                                                                                                                                                                                                                                                                                                        this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                        if (this.type == 104)
                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                            this.name = "Cursed Bullet";
                                                                                                                                                                                                                                                                                                                                                                                                                            this.width = 4;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.height = 4;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.penetrate = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.maxUpdates = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                                                                                            this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                            if (this.type == 105)
                                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                                this.name = "Gungnir";
                                                                                                                                                                                                                                                                                                                                                                                                                                this.width = 18;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.height = 18;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 19;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.scale = 1.3f;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.hide = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                this.melee = true;
                                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                                if (this.type == 106)
                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.name = "Light Disc";
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.width = 32;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.height = 32;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 3;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.melee = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                    this.light = 0.4f;
                                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 107)
                                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.name = "Hamdrax";
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.width = 22;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.height = 22;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 20;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.hide = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.ownerHitCheck = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.melee = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                        this.scale = 1.1f;
                                                                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                                        if (this.type == 108)
                                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.name = "Explosives";
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.width = 260;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.height = 260;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.aiStyle = 16;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.friendly = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.tileCollide = false;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                                                                                            this.timeLeft = 2;
                                                                                                                                                                                                                                                                                                                                                                                                                                        }
                                                                                                                                                                                                                                                                                                                                                                                                                                        else
                                                                                                                                                                                                                                                                                                                                                                                                                                        {
                                                                                                                                                                                                                                                                                                                                                                                                                                            if (this.type == 109)
                                                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.name = "Snow Ball";
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.knockBack = 6f;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.width = 10;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.height = 10;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.aiStyle = 10;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.scale = 0.9f;
                                                                                                                                                                                                                                                                                                                                                                                                                                                this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                            }
                                                                                                                                                                                                                                                                                                                                                                                                                                            else
                                                                                                                                                                                                                                                                                                                                                                                                                                            {
                                                                                                                                                                                                                                                                                                                                                                                                                                                if (this.type == 110)
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.name = "Bullet";
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.width = 4;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.height = 4;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.aiStyle = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.hostile = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.light = 0.5f;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.alpha = 255;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.maxUpdates = 1;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.scale = 1.2f;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.timeLeft = 600;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    this.ranged = true;
                                                                                                                                                                                                                                                                                                                                                                                                                                                }
                                                                                                                                                                                                                                                                                                                                                                                                                                                else
                                                                                                                                                                                                                                                                                                                                                                                                                                                {
                                                                                                                                                                                                                                                                                                                                                                                                                                                    if (this.type == 111)
                                                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.name = "Bunny";
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.width = 18;
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.height = 18;
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.aiStyle = 26;
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.friendly = false;
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.penetrate = -1;
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.timeLeft *= 5;
                                                                                                                                                                                                                                                                                                                                                                                                                                                    }
                                                                                                                                                                                                                                                                                                                                                                                                                                                    else
                                                                                                                                                                                                                                                                                                                                                                                                                                                    {
                                                                                                                                                                                                                                                                                                                                                                                                                                                        this.active = false;
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
            this.width = (int)((float)this.width * this.scale);
            this.height = (int)((float)this.height * this.scale);
        }
        public static int NewProjectile(float X, float Y, float SpeedX, float SpeedY, int Type, int Damage, float KnockBack, int Owner = 255)
        {
            int num = 1000;
            for (int i = 0; i < 1000; i++)
            {
                if (!Main.projectile[i].active)
                {
                    num = i;
                    break;
                }
            }
            if (num == 1000)
            {
                return num;
            }
            Main.projectile[num].SetDefaults(Type);
            Main.projectile[num].position.X = X - (float)Main.projectile[num].width * 0.5f;
            Main.projectile[num].position.Y = Y - (float)Main.projectile[num].height * 0.5f;
            Main.projectile[num].owner = Owner;
            Main.projectile[num].velocity.X = SpeedX;
            Main.projectile[num].velocity.Y = SpeedY;
            Main.projectile[num].damage = Damage;
            Main.projectile[num].knockBack = KnockBack;
            Main.projectile[num].identity = num;
            Main.projectile[num].wet = Collision.WetCollision(Main.projectile[num].position, Main.projectile[num].width, Main.projectile[num].height);
            if (Main.netMode != 0 && Owner == Main.myPlayer)
            {
                NetMessage.SendData(27, -1, -1, "", num, 0f, 0f, 0f, 0);
            }
            if (Owner == Main.myPlayer)
            {
                if (Type == 28)
                {
                    Main.projectile[num].timeLeft = 180;
                }
                if (Type == 29)
                {
                    Main.projectile[num].timeLeft = 300;
                }
                if (Type == 30)
                {
                    Main.projectile[num].timeLeft = 180;
                }
                if (Type == 37)
                {
                    Main.projectile[num].timeLeft = 180;
                }
                if (Type == 75)
                {
                    Main.projectile[num].timeLeft = 180;
                }
            }
            return num;
        }
        public void StatusNPC(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.npc[i].AddBuff(24, 180, false);
                    return;
                }
            }
            else
            {
                if (this.type == 15)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.npc[i].AddBuff(24, 300, false);
                        return;
                    }
                }
                else
                {
                    if (this.type == 19)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            Main.npc[i].AddBuff(24, 180, false);
                            return;
                        }
                    }
                    else
                    {
                        if (this.type == 33)
                        {
                            if (Main.rand.Next(5) == 0)
                            {
                                Main.npc[i].AddBuff(20, 420, false);
                                return;
                            }
                        }
                        else
                        {
                            if (this.type == 34)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    Main.npc[i].AddBuff(24, 240, false);
                                    return;
                                }
                            }
                            else
                            {
                                if (this.type == 35)
                                {
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.npc[i].AddBuff(24, 180, false);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (this.type == 54)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.npc[i].AddBuff(20, 600, false);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (this.type == 63)
                                        {
                                            if (Main.rand.Next(3) != 0)
                                            {
                                                Main.npc[i].AddBuff(31, 120, false);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (this.type == 85)
                                            {
                                                Main.npc[i].AddBuff(24, 1200, false);
                                                return;
                                            }
                                            if (this.type == 95 || this.type == 103 || this.type == 104)
                                            {
                                                Main.npc[i].AddBuff(39, 420, false);
                                                return;
                                            }
                                            if (this.type == 98)
                                            {
                                                Main.npc[i].AddBuff(20, 600, false);
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
        public void StatusPvP(int i)
        {
            if (this.type == 2)
            {
                if (Main.rand.Next(3) == 0)
                {
                    Main.player[i].AddBuff(24, 180, false);
                    return;
                }
            }
            else
            {
                if (this.type == 15)
                {
                    if (Main.rand.Next(2) == 0)
                    {
                        Main.player[i].AddBuff(24, 300, false);
                        return;
                    }
                }
                else
                {
                    if (this.type == 19)
                    {
                        if (Main.rand.Next(5) == 0)
                        {
                            Main.player[i].AddBuff(24, 180, false);
                            return;
                        }
                    }
                    else
                    {
                        if (this.type == 33)
                        {
                            if (Main.rand.Next(5) == 0)
                            {
                                Main.player[i].AddBuff(20, 420, false);
                                return;
                            }
                        }
                        else
                        {
                            if (this.type == 34)
                            {
                                if (Main.rand.Next(2) == 0)
                                {
                                    Main.player[i].AddBuff(24, 240, false);
                                    return;
                                }
                            }
                            else
                            {
                                if (this.type == 35)
                                {
                                    if (Main.rand.Next(4) == 0)
                                    {
                                        Main.player[i].AddBuff(24, 180, false);
                                        return;
                                    }
                                }
                                else
                                {
                                    if (this.type == 54)
                                    {
                                        if (Main.rand.Next(2) == 0)
                                        {
                                            Main.player[i].AddBuff(20, 600, false);
                                            return;
                                        }
                                    }
                                    else
                                    {
                                        if (this.type == 63)
                                        {
                                            if (Main.rand.Next(3) != 0)
                                            {
                                                Main.player[i].AddBuff(31, 120, true);
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (this.type == 85)
                                            {
                                                Main.player[i].AddBuff(24, 1200, false);
                                                return;
                                            }
                                            if (this.type == 95 || this.type == 103 || this.type == 104)
                                            {
                                                Main.player[i].AddBuff(39, 420, true);
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
        public void StatusPlayer(int i)
        {
            if (this.type == 55 && Main.rand.Next(3) == 0)
            {
                Main.player[i].AddBuff(20, 600, true);
            }
            if (this.type == 44 && Main.rand.Next(3) == 0)
            {
                Main.player[i].AddBuff(22, 900, true);
            }
            if (this.type == 82 && Main.rand.Next(3) == 0)
            {
                Main.player[i].AddBuff(24, 420, true);
            }
            if ((this.type == 96 || this.type == 101) && Main.rand.Next(3) == 0)
            {
                Main.player[i].AddBuff(39, 480, true);
            }
            if (this.type == 98)
            {
                Main.player[i].AddBuff(20, 600, true);
            }
        }
        public void Damage()
        {
            if (this.type == 18 || this.type == 72 || this.type == 86 || this.type == 87 || this.type == 111)
            {
                return;
            }
            Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
            if (this.type == 85 || this.type == 101)
            {
                int num = 30;
                rectangle.X -= num;
                rectangle.Y -= num;
                rectangle.Width += num * 2;
                rectangle.Height += num * 2;
            }
            if (this.friendly && this.owner == Main.myPlayer)
            {
                if ((this.aiStyle == 16 || this.type == 41) && (this.timeLeft <= 1 || this.type == 108))
                {
                    int myPlayer = Main.myPlayer;
                    if (Main.player[myPlayer].active && !Main.player[myPlayer].dead && !Main.player[myPlayer].immune && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[myPlayer].position, Main.player[myPlayer].width, Main.player[myPlayer].height)))
                    {
                        Rectangle value = new Rectangle((int)Main.player[myPlayer].position.X, (int)Main.player[myPlayer].position.Y, Main.player[myPlayer].width, Main.player[myPlayer].height);
                        if (rectangle.Intersects(value))
                        {
                            if (Main.player[myPlayer].position.X + (float)(Main.player[myPlayer].width / 2) < this.position.X + (float)(this.width / 2))
                            {
                                this.direction = -1;
                            }
                            else
                            {
                                this.direction = 1;
                            }
                            int num2 = Main.DamageVar((float)this.damage);
                            this.StatusPlayer(myPlayer);
                            Main.player[myPlayer].Hurt(num2, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), false);
                            if (Main.netMode != 0)
                            {
                                NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), myPlayer, (float)this.direction, (float)num2, 1f, 0);
                            }
                        }
                    }
                }
                if (this.type != 69 && this.type != 70 && this.type != 10 && this.type != 11)
                {
                    int num3 = (int)(this.position.X / 16f);
                    int num4 = (int)((this.position.X + (float)this.width) / 16f) + 1;
                    int num5 = (int)(this.position.Y / 16f);
                    int num6 = (int)((this.position.Y + (float)this.height) / 16f) + 1;
                    if (num3 < 0)
                    {
                        num3 = 0;
                    }
                    if (num4 > Main.maxTilesX)
                    {
                        num4 = Main.maxTilesX;
                    }
                    if (num5 < 0)
                    {
                        num5 = 0;
                    }
                    if (num6 > Main.maxTilesY)
                    {
                        num6 = Main.maxTilesY;
                    }
                    for (int i = num3; i < num4; i++)
                    {
                        for (int j = num5; j < num6; j++)
                        {
                            if (Main.tile[i, j] != null && Main.tileCut[(int)Main.tile[i, j].type] && Main.tile[i, j + 1] != null && Main.tile[i, j + 1].type != 78)
                            {
                                WorldGen.KillTile(i, j, false, false, false);
                                if (Main.netMode != 0)
                                {
                                    NetMessage.SendData(17, -1, -1, "", 0, (float)i, (float)j, 0f, 0);
                                }
                            }
                        }
                    }
                }
            }
            if (this.owner == Main.myPlayer)
            {
                if (this.damage > 0)
                {
                    for (int k = 0; k < 200; k++)
                    {
                        if (Main.npc[k].active && !Main.npc[k].dontTakeDamage && (((!Main.npc[k].friendly || (Main.npc[k].type == 22 && this.owner < 255 && Main.player[this.owner].killGuide)) && this.friendly) || (Main.npc[k].friendly && this.hostile)) && (this.owner < 0 || Main.npc[k].immune[this.owner] == 0))
                        {
                            bool flag = false;
                            if (this.type == 11 && (Main.npc[k].type == 47 || Main.npc[k].type == 57))
                            {
                                flag = true;
                            }
                            else
                            {
                                if (this.type == 31 && Main.npc[k].type == 69)
                                {
                                    flag = true;
                                }
                            }
                            if (!flag && (Main.npc[k].noTileCollide || !this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.npc[k].position, Main.npc[k].width, Main.npc[k].height)))
                            {
                                Rectangle value2 = new Rectangle((int)Main.npc[k].position.X, (int)Main.npc[k].position.Y, Main.npc[k].width, Main.npc[k].height);
                                if (rectangle.Intersects(value2))
                                {
                                    if (this.aiStyle == 3)
                                    {
                                        if (this.ai[0] == 0f)
                                        {
                                            this.velocity.X = -this.velocity.X;
                                            this.velocity.Y = -this.velocity.Y;
                                            this.netUpdate = true;
                                        }
                                        this.ai[0] = 1f;
                                    }
                                    else
                                    {
                                        if (this.aiStyle == 16)
                                        {
                                            if (this.timeLeft > 3)
                                            {
                                                this.timeLeft = 3;
                                            }
                                            if (Main.npc[k].position.X + (float)(Main.npc[k].width / 2) < this.position.X + (float)(this.width / 2))
                                            {
                                                this.direction = -1;
                                            }
                                            else
                                            {
                                                this.direction = 1;
                                            }
                                        }
                                    }
                                    if (this.type == 41 && this.timeLeft > 1)
                                    {
                                        this.timeLeft = 1;
                                    }
                                    bool flag2 = false;
                                    if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
                                    {
                                        flag2 = true;
                                    }
                                    if (this.ranged && Main.rand.Next(1, 101) <= Main.player[this.owner].rangedCrit)
                                    {
                                        flag2 = true;
                                    }
                                    if (this.magic && Main.rand.Next(1, 101) <= Main.player[this.owner].magicCrit)
                                    {
                                        flag2 = true;
                                    }
                                    int num7 = Main.DamageVar((float)this.damage);
                                    this.StatusNPC(k);
                                    Main.npc[k].StrikeNPC(num7, this.knockBack, this.direction, flag2, false);
                                    if (Main.netMode != 0)
                                    {
                                        if (flag2)
                                        {
                                            NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 1);
                                        }
                                        else
                                        {
                                            NetMessage.SendData(28, -1, -1, "", k, (float)num7, this.knockBack, (float)this.direction, 0);
                                        }
                                    }
                                    if (this.penetrate != 1)
                                    {
                                        Main.npc[k].immune[this.owner] = 10;
                                    }
                                    if (this.penetrate > 0)
                                    {
                                        this.penetrate--;
                                        if (this.penetrate == 0)
                                        {
                                            break;
                                        }
                                    }
                                    if (this.aiStyle == 7)
                                    {
                                        this.ai[0] = 1f;
                                        this.damage = 0;
                                        this.netUpdate = true;
                                    }
                                    else
                                    {
                                        if (this.aiStyle == 13)
                                        {
                                            this.ai[0] = 1f;
                                            this.netUpdate = true;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (this.damage > 0 && Main.player[Main.myPlayer].hostile)
                {
                    for (int l = 0; l < 255; l++)
                    {
                        if (l != this.owner && Main.player[l].active && !Main.player[l].dead && !Main.player[l].immune && Main.player[l].hostile && this.playerImmune[l] <= 0 && (Main.player[Main.myPlayer].team == 0 || Main.player[Main.myPlayer].team != Main.player[l].team) && (!this.ownerHitCheck || Collision.CanHit(Main.player[this.owner].position, Main.player[this.owner].width, Main.player[this.owner].height, Main.player[l].position, Main.player[l].width, Main.player[l].height)))
                        {
                            Rectangle value3 = new Rectangle((int)Main.player[l].position.X, (int)Main.player[l].position.Y, Main.player[l].width, Main.player[l].height);
                            if (rectangle.Intersects(value3))
                            {
                                if (this.aiStyle == 3)
                                {
                                    if (this.ai[0] == 0f)
                                    {
                                        this.velocity.X = -this.velocity.X;
                                        this.velocity.Y = -this.velocity.Y;
                                        this.netUpdate = true;
                                    }
                                    this.ai[0] = 1f;
                                }
                                else
                                {
                                    if (this.aiStyle == 16)
                                    {
                                        if (this.timeLeft > 3)
                                        {
                                            this.timeLeft = 3;
                                        }
                                        if (Main.player[l].position.X + (float)(Main.player[l].width / 2) < this.position.X + (float)(this.width / 2))
                                        {
                                            this.direction = -1;
                                        }
                                        else
                                        {
                                            this.direction = 1;
                                        }
                                    }
                                }
                                if (this.type == 41 && this.timeLeft > 1)
                                {
                                    this.timeLeft = 1;
                                }
                                bool flag3 = false;
                                if (this.melee && Main.rand.Next(1, 101) <= Main.player[this.owner].meleeCrit)
                                {
                                    flag3 = true;
                                }
                                int num8 = Main.DamageVar((float)this.damage);
                                if (!Main.player[l].immune)
                                {
                                    this.StatusPvP(l);
                                }
                                Main.player[l].Hurt(num8, this.direction, true, false, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), flag3);
                                if (Main.netMode != 0)
                                {
                                    if (flag3)
                                    {
                                        NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 1);
                                    }
                                    else
                                    {
                                        NetMessage.SendData(26, -1, -1, Lang.deathMsg(this.owner, -1, this.whoAmI, -1), l, (float)this.direction, (float)num8, 1f, 0);
                                    }
                                }
                                this.playerImmune[l] = 40;
                                if (this.penetrate > 0)
                                {
                                    this.penetrate--;
                                    if (this.penetrate == 0)
                                    {
                                        break;
                                    }
                                }
                                if (this.aiStyle == 7)
                                {
                                    this.ai[0] = 1f;
                                    this.damage = 0;
                                    this.netUpdate = true;
                                }
                                else
                                {
                                    if (this.aiStyle == 13)
                                    {
                                        this.ai[0] = 1f;
                                        this.netUpdate = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (this.type == 11 && Main.netMode != 1)
            {
                for (int m = 0; m < 200; m++)
                {
                    if (Main.npc[m].active)
                    {
                        if (Main.npc[m].type == 46)
                        {
                            Rectangle value4 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
                            if (rectangle.Intersects(value4))
                            {
                                Main.npc[m].Transform(47);
                            }
                        }
                        else
                        {
                            if (Main.npc[m].type == 55)
                            {
                                Rectangle value5 = new Rectangle((int)Main.npc[m].position.X, (int)Main.npc[m].position.Y, Main.npc[m].width, Main.npc[m].height);
                                if (rectangle.Intersects(value5))
                                {
                                    Main.npc[m].Transform(57);
                                }
                            }
                        }
                    }
                }
            }
            if (Main.netMode != 2 && this.hostile && Main.myPlayer < 255 && this.damage > 0)
            {
                int myPlayer2 = Main.myPlayer;
                if (Main.player[myPlayer2].active && !Main.player[myPlayer2].dead && !Main.player[myPlayer2].immune)
                {
                    Rectangle value6 = new Rectangle((int)Main.player[myPlayer2].position.X, (int)Main.player[myPlayer2].position.Y, Main.player[myPlayer2].width, Main.player[myPlayer2].height);
                    if (rectangle.Intersects(value6))
                    {
                        int hitDirection = this.direction;
                        if (Main.player[myPlayer2].position.X + (float)(Main.player[myPlayer2].width / 2) < this.position.X + (float)(this.width / 2))
                        {
                            hitDirection = -1;
                        }
                        else
                        {
                            hitDirection = 1;
                        }
                        int num9 = Main.DamageVar((float)this.damage);
                        if (!Main.player[myPlayer2].immune)
                        {
                            this.StatusPlayer(myPlayer2);
                        }
                        Main.player[myPlayer2].Hurt(num9 * 2, hitDirection, false, false, Lang.deathMsg(-1, -1, this.whoAmI, -1), false);
                    }
                }
            }
        }
        public void Update(int i)
        {
            if (this.active)
            {
                Vector2 value = this.velocity;
                if (this.position.X <= Main.leftWorld || this.position.X + (float)this.width >= Main.rightWorld || this.position.Y <= Main.topWorld || this.position.Y + (float)this.height >= Main.bottomWorld)
                {
                    this.active = false;
                    return;
                }
                this.whoAmI = i;
                if (this.soundDelay > 0)
                {
                    this.soundDelay--;
                }
                this.netUpdate = false;
                for (int j = 0; j < 255; j++)
                {
                    if (this.playerImmune[j] > 0)
                    {
                        this.playerImmune[j]--;
                    }
                }
                this.AI();
                if (this.owner < 255 && !Main.player[this.owner].active)
                {
                    this.Kill();
                }
                if (!this.ignoreWater)
                {
                    bool flag;
                    bool flag2;
                    try
                    {
                        flag = Collision.LavaCollision(this.position, this.width, this.height);
                        flag2 = Collision.WetCollision(this.position, this.width, this.height);
                        if (flag)
                        {
                            this.lavaWet = true;
                        }
                    }
                    catch
                    {
                        this.active = false;
                        return;
                    }
                    if (this.wet && !this.lavaWet)
                    {
                        if (this.type == 85 || this.type == 15 || this.type == 34)
                        {
                            this.Kill();
                        }
                        if (this.type == 2)
                        {
                            this.type = 1;
                            this.light = 0f;
                        }
                    }
                    if (this.type == 80)
                    {
                        flag2 = false;
                        this.wet = false;
                        if (flag && this.ai[0] >= 0f)
                        {
                            this.Kill();
                        }
                    }
                    if (flag2)
                    {
                        if (this.wetCount == 0)
                        {
                            this.wetCount = 10;
                            if (!this.wet)
                            {
                                if (!flag)
                                {
                                    for (int k = 0; k < 10; k++)
                                    {
                                        int num = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
                                        Dust expr_263_cp_0 = Main.dust[num];
                                        expr_263_cp_0.velocity.Y = expr_263_cp_0.velocity.Y - 4f;
                                        Dust expr_281_cp_0 = Main.dust[num];
                                        expr_281_cp_0.velocity.X = expr_281_cp_0.velocity.X * 2.5f;
                                        Main.dust[num].scale = 1.3f;
                                        Main.dust[num].alpha = 100;
                                        Main.dust[num].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                }
                                else
                                {
                                    for (int l = 0; l < 10; l++)
                                    {
                                        int num2 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
                                        Dust expr_369_cp_0 = Main.dust[num2];
                                        expr_369_cp_0.velocity.Y = expr_369_cp_0.velocity.Y - 1.5f;
                                        Dust expr_387_cp_0 = Main.dust[num2];
                                        expr_387_cp_0.velocity.X = expr_387_cp_0.velocity.X * 2.5f;
                                        Main.dust[num2].scale = 1.3f;
                                        Main.dust[num2].alpha = 100;
                                        Main.dust[num2].noGravity = true;
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
                            if (this.wetCount == 0)
                            {
                                this.wetCount = 10;
                                if (!this.lavaWet)
                                {
                                    for (int m = 0; m < 10; m++)
                                    {
                                        int num3 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2)), this.width + 12, 24, 33, 0f, 0f, 0, default(Color), 1f);
                                        Dust expr_4A0_cp_0 = Main.dust[num3];
                                        expr_4A0_cp_0.velocity.Y = expr_4A0_cp_0.velocity.Y - 4f;
                                        Dust expr_4BE_cp_0 = Main.dust[num3];
                                        expr_4BE_cp_0.velocity.X = expr_4BE_cp_0.velocity.X * 2.5f;
                                        Main.dust[num3].scale = 1.3f;
                                        Main.dust[num3].alpha = 100;
                                        Main.dust[num3].noGravity = true;
                                    }
                                    Main.PlaySound(19, (int)this.position.X, (int)this.position.Y, 1);
                                }
                                else
                                {
                                    for (int n = 0; n < 10; n++)
                                    {
                                        int num4 = Dust.NewDust(new Vector2(this.position.X - 6f, this.position.Y + (float)(this.height / 2) - 8f), this.width + 12, 24, 35, 0f, 0f, 0, default(Color), 1f);
                                        Dust expr_5A6_cp_0 = Main.dust[num4];
                                        expr_5A6_cp_0.velocity.Y = expr_5A6_cp_0.velocity.Y - 1.5f;
                                        Dust expr_5C4_cp_0 = Main.dust[num4];
                                        expr_5C4_cp_0.velocity.X = expr_5C4_cp_0.velocity.X * 2.5f;
                                        Main.dust[num4].scale = 1.3f;
                                        Main.dust[num4].alpha = 100;
                                        Main.dust[num4].noGravity = true;
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
                }
                this.lastPosition = this.position;
                if (this.tileCollide)
                {
                    Vector2 value2 = this.velocity;
                    bool flag3 = true;
                    if (this.type == 9 || this.type == 12 || this.type == 15 || this.type == 13 || this.type == 31 || this.type == 39 || this.type == 40)
                    {
                        flag3 = false;
                    }
                    if (this.aiStyle == 10)
                    {
                        if (this.type == 42 || this.type == 65 || this.type == 68 || (this.type == 31 && this.ai[0] == 2f))
                        {
                            this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
                        }
                        else
                        {
                            this.velocity = Collision.AnyCollision(this.position, this.velocity, this.width, this.height);
                        }
                    }
                    else
                    {
                        if (this.aiStyle == 18)
                        {
                            int num5 = this.width - 36;
                            int num6 = this.height - 36;
                            Vector2 vector = new Vector2(this.position.X + (float)(this.width / 2) - (float)(num5 / 2), this.position.Y + (float)(this.height / 2) - (float)(num6 / 2));
                            this.velocity = Collision.TileCollision(vector, this.velocity, num5, num6, flag3, flag3);
                        }
                        else
                        {
                            if (this.wet)
                            {
                                Vector2 vector2 = this.velocity;
                                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
                                value = this.velocity * 0.5f;
                                if (this.velocity.X != vector2.X)
                                {
                                    value.X = this.velocity.X;
                                }
                                if (this.velocity.Y != vector2.Y)
                                {
                                    value.Y = this.velocity.Y;
                                }
                            }
                            else
                            {
                                this.velocity = Collision.TileCollision(this.position, this.velocity, this.width, this.height, flag3, flag3);
                            }
                        }
                    }
                    if (value2 != this.velocity && this.type != 111)
                    {
                        if (this.type == 94)
                        {
                            if (this.velocity.X != value2.X)
                            {
                                this.velocity.X = -value2.X;
                            }
                            if (this.velocity.Y != value2.Y)
                            {
                                this.velocity.Y = -value2.Y;
                            }
                        }
                        else
                        {
                            if (this.type == 99)
                            {
                                if (this.velocity.Y != value2.Y && value2.Y > 5f)
                                {
                                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                    this.velocity.Y = -value2.Y * 0.2f;
                                }
                                if (this.velocity.X != value2.X)
                                {
                                    this.Kill();
                                }
                            }
                            else
                            {
                                if (this.type == 36)
                                {
                                    if (this.penetrate > 1)
                                    {
                                        Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                        this.penetrate--;
                                        if (this.velocity.X != value2.X)
                                        {
                                            this.velocity.X = -value2.X;
                                        }
                                        if (this.velocity.Y != value2.Y)
                                        {
                                            this.velocity.Y = -value2.Y;
                                        }
                                    }
                                    else
                                    {
                                        this.Kill();
                                    }
                                }
                                else
                                {
                                    if (this.aiStyle == 21)
                                    {
                                        if (this.velocity.X != value2.X)
                                        {
                                            this.velocity.X = -value2.X;
                                        }
                                        if (this.velocity.Y != value2.Y)
                                        {
                                            this.velocity.Y = -value2.Y;
                                        }
                                    }
                                    else
                                    {
                                        if (this.aiStyle == 17)
                                        {
                                            if (this.velocity.X != value2.X)
                                            {
                                                this.velocity.X = value2.X * -0.75f;
                                            }
                                            if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
                                            {
                                                this.velocity.Y = value2.Y * -0.7f;
                                            }
                                        }
                                        else
                                        {
                                            if (this.aiStyle == 15)
                                            {
                                                bool flag4 = false;
                                                if (value2.X != this.velocity.X)
                                                {
                                                    if (Math.Abs(value2.X) > 4f)
                                                    {
                                                        flag4 = true;
                                                    }
                                                    this.position.X = this.position.X + this.velocity.X;
                                                    this.velocity.X = -value2.X * 0.2f;
                                                }
                                                if (value2.Y != this.velocity.Y)
                                                {
                                                    if (Math.Abs(value2.Y) > 4f)
                                                    {
                                                        flag4 = true;
                                                    }
                                                    this.position.Y = this.position.Y + this.velocity.Y;
                                                    this.velocity.Y = -value2.Y * 0.2f;
                                                }
                                                this.ai[0] = 1f;
                                                if (flag4)
                                                {
                                                    this.netUpdate = true;
                                                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                }
                                            }
                                            else
                                            {
                                                if (this.aiStyle == 3 || this.aiStyle == 13)
                                                {
                                                    Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                                    if (this.type == 33 || this.type == 106)
                                                    {
                                                        if (this.velocity.X != value2.X)
                                                        {
                                                            this.velocity.X = -value2.X;
                                                        }
                                                        if (this.velocity.Y != value2.Y)
                                                        {
                                                            this.velocity.Y = -value2.Y;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        this.ai[0] = 1f;
                                                        if (this.aiStyle == 3)
                                                        {
                                                            this.velocity.X = -value2.X;
                                                            this.velocity.Y = -value2.Y;
                                                        }
                                                    }
                                                    this.netUpdate = true;
                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                }
                                                else
                                                {
                                                    if (this.aiStyle == 8 && this.type != 96)
                                                    {
                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                        this.ai[0] += 1f;
                                                        if (this.ai[0] >= 5f)
                                                        {
                                                            this.position += this.velocity;
                                                            this.Kill();
                                                        }
                                                        else
                                                        {
                                                            if (this.type == 15 && this.velocity.Y > 4f)
                                                            {
                                                                if (this.velocity.Y != value2.Y)
                                                                {
                                                                    this.velocity.Y = -value2.Y * 0.8f;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.velocity.Y != value2.Y)
                                                                {
                                                                    this.velocity.Y = -value2.Y;
                                                                }
                                                            }
                                                            if (this.velocity.X != value2.X)
                                                            {
                                                                this.velocity.X = -value2.X;
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.aiStyle == 14)
                                                        {
                                                            if (this.type == 50)
                                                            {
                                                                if (this.velocity.X != value2.X)
                                                                {
                                                                    this.velocity.X = value2.X * -0.2f;
                                                                }
                                                                if (this.velocity.Y != value2.Y && (double)value2.Y > 1.5)
                                                                {
                                                                    this.velocity.Y = value2.Y * -0.2f;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.velocity.X != value2.X)
                                                                {
                                                                    this.velocity.X = value2.X * -0.5f;
                                                                }
                                                                if (this.velocity.Y != value2.Y && value2.Y > 1f)
                                                                {
                                                                    this.velocity.Y = value2.Y * -0.5f;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (this.aiStyle == 16)
                                                            {
                                                                if (this.velocity.X != value2.X)
                                                                {
                                                                    this.velocity.X = value2.X * -0.4f;
                                                                    if (this.type == 29)
                                                                    {
                                                                        this.velocity.X = this.velocity.X * 0.8f;
                                                                    }
                                                                }
                                                                if (this.velocity.Y != value2.Y && (double)value2.Y > 0.7 && this.type != 102)
                                                                {
                                                                    this.velocity.Y = value2.Y * -0.4f;
                                                                    if (this.type == 29)
                                                                    {
                                                                        this.velocity.Y = this.velocity.Y * 0.8f;
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.aiStyle != 9 || this.owner == Main.myPlayer)
                                                                {
                                                                    this.position += this.velocity;
                                                                    this.Kill();
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
                if (this.type == 7 || this.type == 8)
                {
                    goto IL_1100;
                }
                if (this.wet)
                {
                    this.position += value;
                    goto IL_1100;
                }
                this.position += this.velocity;
            IL_1100:
                if ((this.aiStyle != 3 || this.ai[0] != 1f) && (this.aiStyle != 7 || this.ai[0] != 1f) && (this.aiStyle != 13 || this.ai[0] != 1f) && (this.aiStyle != 15 || this.ai[0] != 1f) && this.aiStyle != 15 && this.aiStyle != 26)
                {
                    if (this.velocity.X < 0f)
                    {
                        this.direction = -1;
                    }
                    else
                    {
                        this.direction = 1;
                    }
                }
                if (!this.active)
                {
                    return;
                }
                if (this.light > 0f)
                {
                    float num7 = this.light;
                    float num8 = this.light;
                    float num9 = this.light;
                    if (this.type == 2 || this.type == 82)
                    {
                        num8 *= 0.75f;
                        num9 *= 0.55f;
                    }
                    else
                    {
                        if (this.type == 94)
                        {
                            num7 *= 0.5f;
                            num8 *= 0f;
                        }
                        else
                        {
                            if (this.type == 95 || this.type == 96 || this.type == 103 || this.type == 104)
                            {
                                num7 *= 0.35f;
                                num8 *= 1f;
                                num9 *= 0f;
                            }
                            else
                            {
                                if (this.type == 4)
                                {
                                    num8 *= 0.1f;
                                    num7 *= 0.5f;
                                }
                                else
                                {
                                    if (this.type == 9)
                                    {
                                        num8 *= 0.1f;
                                        num9 *= 0.6f;
                                    }
                                    else
                                    {
                                        if (this.type == 92)
                                        {
                                            num8 *= 0.6f;
                                            num7 *= 0.8f;
                                        }
                                        else
                                        {
                                            if (this.type == 93)
                                            {
                                                num8 *= 1f;
                                                num7 *= 1f;
                                                num9 *= 0.01f;
                                            }
                                            else
                                            {
                                                if (this.type == 12)
                                                {
                                                    num7 *= 0.9f;
                                                    num8 *= 0.8f;
                                                    num9 *= 0.1f;
                                                }
                                                else
                                                {
                                                    if (this.type == 14 || this.type == 110)
                                                    {
                                                        num8 *= 0.7f;
                                                        num9 *= 0.1f;
                                                    }
                                                    else
                                                    {
                                                        if (this.type == 15)
                                                        {
                                                            num8 *= 0.4f;
                                                            num9 *= 0.1f;
                                                            num7 = 1f;
                                                        }
                                                        else
                                                        {
                                                            if (this.type == 16)
                                                            {
                                                                num7 *= 0.1f;
                                                                num8 *= 0.4f;
                                                                num9 = 1f;
                                                            }
                                                            else
                                                            {
                                                                if (this.type == 18)
                                                                {
                                                                    num8 *= 0.7f;
                                                                    num9 *= 0.3f;
                                                                }
                                                                else
                                                                {
                                                                    if (this.type == 19)
                                                                    {
                                                                        num8 *= 0.5f;
                                                                        num9 *= 0.1f;
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.type == 20)
                                                                        {
                                                                            num7 *= 0.1f;
                                                                            num9 *= 0.3f;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type == 22)
                                                                            {
                                                                                num7 = 0f;
                                                                                num8 = 0f;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type == 27)
                                                                                {
                                                                                    num7 *= 0f;
                                                                                    num8 *= 0.3f;
                                                                                    num9 = 1f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.type == 34)
                                                                                    {
                                                                                        num8 *= 0.1f;
                                                                                        num9 *= 0.1f;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.type == 36)
                                                                                        {
                                                                                            num7 = 0.8f;
                                                                                            num8 *= 0.2f;
                                                                                            num9 *= 0.6f;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.type == 41)
                                                                                            {
                                                                                                num8 *= 0.8f;
                                                                                                num9 *= 0.6f;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (this.type == 44 || this.type == 45)
                                                                                                {
                                                                                                    num9 = 1f;
                                                                                                    num7 *= 0.6f;
                                                                                                    num8 *= 0.1f;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.type == 50)
                                                                                                    {
                                                                                                        num7 *= 0.7f;
                                                                                                        num9 *= 0.8f;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.type == 53)
                                                                                                        {
                                                                                                            num7 *= 0.7f;
                                                                                                            num8 *= 0.8f;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (this.type == 72)
                                                                                                            {
                                                                                                                num7 *= 0.45f;
                                                                                                                num8 *= 0.75f;
                                                                                                                num9 = 1f;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (this.type == 86)
                                                                                                                {
                                                                                                                    num7 *= 1f;
                                                                                                                    num8 *= 0.45f;
                                                                                                                    num9 = 0.75f;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (this.type == 87)
                                                                                                                    {
                                                                                                                        num7 *= 0.45f;
                                                                                                                        num8 = 1f;
                                                                                                                        num9 *= 0.75f;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (this.type == 73)
                                                                                                                        {
                                                                                                                            num7 *= 0.4f;
                                                                                                                            num8 *= 0.6f;
                                                                                                                            num9 *= 1f;
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (this.type == 74)
                                                                                                                            {
                                                                                                                                num7 *= 1f;
                                                                                                                                num8 *= 0.4f;
                                                                                                                                num9 *= 0.6f;
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (this.type == 76 || this.type == 77 || this.type == 78)
                                                                                                                                {
                                                                                                                                    num7 *= 1f;
                                                                                                                                    num8 *= 0.3f;
                                                                                                                                    num9 *= 0.6f;
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (this.type == 79)
                                                                                                                                    {
                                                                                                                                        num7 = (float)Main.DiscoR / 255f;
                                                                                                                                        num8 = (float)Main.DiscoG / 255f;
                                                                                                                                        num9 = (float)Main.DiscoB / 255f;
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (this.type == 80)
                                                                                                                                        {
                                                                                                                                            num7 *= 0f;
                                                                                                                                            num8 *= 0.8f;
                                                                                                                                            num9 *= 1f;
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (this.type == 83 || this.type == 88)
                                                                                                                                            {
                                                                                                                                                num7 *= 0.7f;
                                                                                                                                                num8 *= 0f;
                                                                                                                                                num9 *= 1f;
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (this.type == 100)
                                                                                                                                                {
                                                                                                                                                    num7 *= 1f;
                                                                                                                                                    num8 *= 0.5f;
                                                                                                                                                    num9 *= 0f;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (this.type == 84)
                                                                                                                                                    {
                                                                                                                                                        num7 *= 0.8f;
                                                                                                                                                        num8 *= 0f;
                                                                                                                                                        num9 *= 0.5f;
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (this.type == 89 || this.type == 90)
                                                                                                                                                        {
                                                                                                                                                            num8 *= 0.2f;
                                                                                                                                                            num9 *= 1f;
                                                                                                                                                            num7 *= 0.05f;
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (this.type == 106)
                                                                                                                                                            {
                                                                                                                                                                num7 *= 0f;
                                                                                                                                                                num8 *= 0.5f;
                                                                                                                                                                num9 *= 1f;
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
                    Lighting.addLight((int)((this.position.X + (float)(this.width / 2)) / 16f), (int)((this.position.Y + (float)(this.height / 2)) / 16f), num7, num8, num9);
                }
                if (this.type == 2 || this.type == 82)
                {
                    Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 6, 0f, 0f, 100, default(Color), 1f);
                }
                else
                {
                    if (this.type == 103)
                    {
                        int num10 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 75, 0f, 0f, 100, default(Color), 1f);
                        if (Main.rand.Next(2) == 0)
                        {
                            Main.dust[num10].noGravity = true;
                            Main.dust[num10].scale *= 2f;
                        }
                    }
                    else
                    {
                        if (this.type == 4)
                        {
                            if (Main.rand.Next(5) == 0)
                            {
                                Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 14, 0f, 0f, 150, default(Color), 1.1f);
                            }
                        }
                        else
                        {
                            if (this.type == 5)
                            {
                                int num11 = Main.rand.Next(3);
                                if (num11 == 0)
                                {
                                    num11 = 15;
                                }
                                else
                                {
                                    if (num11 == 1)
                                    {
                                        num11 = 57;
                                    }
                                    else
                                    {
                                        num11 = 58;
                                    }
                                }
                                Dust.NewDust(this.position, this.width, this.height, num11, this.velocity.X * 0.5f, this.velocity.Y * 0.5f, 150, default(Color), 1.2f);
                            }
                        }
                    }
                }
                this.Damage();
                if (Main.netMode != 1 && this.type == 99)
                {
                    Collision.SwitchTiles(this.position, this.width, this.height, this.lastPosition);
                }
                if (this.type == 94)
                {
                    for (int num12 = this.oldPos.Length - 1; num12 > 0; num12--)
                    {
                        this.oldPos[num12] = this.oldPos[num12 - 1];
                    }
                    this.oldPos[0] = this.position;
                }
                this.timeLeft--;
                if (this.timeLeft <= 0)
                {
                    this.Kill();
                }
                if (this.penetrate == 0)
                {
                    this.Kill();
                }
                if (this.active && this.owner == Main.myPlayer)
                {
                    if (this.netUpdate2)
                    {
                        this.netUpdate = true;
                    }
                    if (!this.active)
                    {
                        this.netSpam = 0;
                    }
                    if (this.netUpdate)
                    {
                        if (this.netSpam < 60)
                        {
                            this.netSpam += 5;
                            NetMessage.SendData(27, -1, -1, "", i, 0f, 0f, 0f, 0);
                            this.netUpdate2 = false;
                        }
                        else
                        {
                            this.netUpdate2 = true;
                        }
                    }
                    if (this.netSpam > 0)
                    {
                        this.netSpam--;
                    }
                }
                if (this.active && this.maxUpdates > 0)
                {
                    this.numUpdates--;
                    if (this.numUpdates >= 0)
                    {
                        this.Update(i);
                    }
                    else
                    {
                        this.numUpdates = this.maxUpdates;
                    }
                }
                this.netUpdate = false;
            }
        }
        public void AI()
        {
            if (this.aiStyle == 1)
            {
                if (this.type == 83 && this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
                }
                if (this.type == 110 && this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 11);
                }
                if (this.type == 84 && this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 12);
                }
                if (this.type == 100 && this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 33);
                }
                if (this.type == 98 && this.ai[1] == 0f)
                {
                    this.ai[1] = 1f;
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 17);
                }
                if ((this.type == 81 || this.type == 82) && this.ai[1] == 0f)
                {
                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 5);
                    this.ai[1] = 1f;
                }
                if (this.type == 41)
                {
                    Vector2 arg_20A_0 = new Vector2(this.position.X, this.position.Y);
                    int arg_20A_1 = this.width;
                    int arg_20A_2 = this.height;
                    int arg_20A_3 = 31;
                    float arg_20A_4 = 0f;
                    float arg_20A_5 = 0f;
                    int arg_20A_6 = 100;
                    Color newColor = default(Color);
                    int num = Dust.NewDust(arg_20A_0, arg_20A_1, arg_20A_2, arg_20A_3, arg_20A_4, arg_20A_5, arg_20A_6, newColor, 1.6f);
                    Main.dust[num].noGravity = true;
                    Vector2 arg_260_0 = new Vector2(this.position.X, this.position.Y);
                    int arg_260_1 = this.width;
                    int arg_260_2 = this.height;
                    int arg_260_3 = 6;
                    float arg_260_4 = 0f;
                    float arg_260_5 = 0f;
                    int arg_260_6 = 100;
                    newColor = default(Color);
                    num = Dust.NewDust(arg_260_0, arg_260_1, arg_260_2, arg_260_3, arg_260_4, arg_260_5, arg_260_6, newColor, 2f);
                    Main.dust[num].noGravity = true;
                }
                else
                {
                    if (this.type == 55)
                    {
                        Vector2 arg_2C5_0 = new Vector2(this.position.X, this.position.Y);
                        int arg_2C5_1 = this.width;
                        int arg_2C5_2 = this.height;
                        int arg_2C5_3 = 18;
                        float arg_2C5_4 = 0f;
                        float arg_2C5_5 = 0f;
                        int arg_2C5_6 = 0;
                        Color newColor = default(Color);
                        int num2 = Dust.NewDust(arg_2C5_0, arg_2C5_1, arg_2C5_2, arg_2C5_3, arg_2C5_4, arg_2C5_5, arg_2C5_6, newColor, 0.9f);
                        Main.dust[num2].noGravity = true;
                    }
                    else
                    {
                        if (this.type == 91 && Main.rand.Next(2) == 0)
                        {
                            int num3 = Main.rand.Next(2);
                            if (num3 == 0)
                            {
                                num3 = 15;
                            }
                            else
                            {
                                num3 = 58;
                            }
                            Vector2 arg_35A_0 = this.position;
                            int arg_35A_1 = this.width;
                            int arg_35A_2 = this.height;
                            int arg_35A_3 = num3;
                            float arg_35A_4 = this.velocity.X * 0.25f;
                            float arg_35A_5 = this.velocity.Y * 0.25f;
                            int arg_35A_6 = 150;
                            Color newColor = default(Color);
                            int num4 = Dust.NewDust(arg_35A_0, arg_35A_1, arg_35A_2, arg_35A_3, arg_35A_4, arg_35A_5, arg_35A_6, newColor, 0.9f);
                            Dust expr_367 = Main.dust[num4];
                            expr_367.velocity *= 0.25f;
                        }
                    }
                }
                if (this.type == 20 || this.type == 14 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 89 || this.type == 100 || this.type == 104 || this.type == 110)
                {
                    if (this.alpha > 0)
                    {
                        this.alpha -= 15;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                    }
                }
                if (this.type == 88)
                {
                    if (this.alpha > 0)
                    {
                        this.alpha -= 10;
                    }
                    if (this.alpha < 0)
                    {
                        this.alpha = 0;
                    }
                }
                if (this.type != 5 && this.type != 14 && this.type != 20 && this.type != 36 && this.type != 38 && this.type != 55 && this.type != 83 && this.type != 84 && this.type != 88 && this.type != 89 && this.type != 98 && this.type != 100 && this.type != 104 && this.type != 110)
                {
                    this.ai[0] += 1f;
                }
                if (this.type == 81 || this.type == 91)
                {
                    if (this.ai[0] >= 20f)
                    {
                        this.ai[0] = 20f;
                        this.velocity.Y = this.velocity.Y + 0.07f;
                    }
                }
                else
                {
                    if (this.ai[0] >= 15f)
                    {
                        this.ai[0] = 15f;
                        this.velocity.Y = this.velocity.Y + 0.1f;
                    }
                }
                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                if (this.velocity.Y > 16f)
                {
                    this.velocity.Y = 16f;
                    return;
                }
            }
            else
            {
                if (this.aiStyle == 2)
                {
                    if (this.type == 93 && Main.rand.Next(5) == 0)
                    {
                        Vector2 arg_62A_0 = this.position;
                        int arg_62A_1 = this.width;
                        int arg_62A_2 = this.height;
                        int arg_62A_3 = 57;
                        float arg_62A_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                        float arg_62A_5 = this.velocity.Y * 0.2f;
                        int arg_62A_6 = 100;
                        Color newColor = default(Color);
                        int num5 = Dust.NewDust(arg_62A_0, arg_62A_1, arg_62A_2, arg_62A_3, arg_62A_4, arg_62A_5, arg_62A_6, newColor, 0.3f);
                        Dust expr_63E_cp_0 = Main.dust[num5];
                        expr_63E_cp_0.velocity.X = expr_63E_cp_0.velocity.X * 0.3f;
                        Dust expr_65C_cp_0 = Main.dust[num5];
                        expr_65C_cp_0.velocity.Y = expr_65C_cp_0.velocity.Y * 0.3f;
                    }
                    this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.03f * (float)this.direction;
                    if (this.type == 69 || this.type == 70)
                    {
                        this.ai[0] += 1f;
                        if (this.ai[0] >= 10f)
                        {
                            this.velocity.Y = this.velocity.Y + 0.25f;
                            this.velocity.X = this.velocity.X * 0.99f;
                        }
                    }
                    else
                    {
                        this.ai[0] += 1f;
                        if (this.ai[0] >= 20f)
                        {
                            this.velocity.Y = this.velocity.Y + 0.4f;
                            this.velocity.X = this.velocity.X * 0.97f;
                        }
                        else
                        {
                            if (this.type == 48 || this.type == 54 || this.type == 93)
                            {
                                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                            }
                        }
                    }
                    if (this.velocity.Y > 16f)
                    {
                        this.velocity.Y = 16f;
                    }
                    if (this.type == 54 && Main.rand.Next(20) == 0)
                    {
                        Vector2 arg_85E_0 = new Vector2(this.position.X, this.position.Y);
                        int arg_85E_1 = this.width;
                        int arg_85E_2 = this.height;
                        int arg_85E_3 = 40;
                        float arg_85E_4 = this.velocity.X * 0.1f;
                        float arg_85E_5 = this.velocity.Y * 0.1f;
                        int arg_85E_6 = 0;
                        Color newColor = default(Color);
                        Dust.NewDust(arg_85E_0, arg_85E_1, arg_85E_2, arg_85E_3, arg_85E_4, arg_85E_5, arg_85E_6, newColor, 0.75f);
                        return;
                    }
                }
                else
                {
                    if (this.aiStyle == 3)
                    {
                        if (this.soundDelay == 0)
                        {
                            this.soundDelay = 8;
                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 7);
                        }
                        if (this.type == 19)
                        {
                            for (int i = 0; i < 2; i++)
                            {
                                Vector2 arg_90F_0 = new Vector2(this.position.X, this.position.Y);
                                int arg_90F_1 = this.width;
                                int arg_90F_2 = this.height;
                                int arg_90F_3 = 6;
                                float arg_90F_4 = this.velocity.X * 0.2f;
                                float arg_90F_5 = this.velocity.Y * 0.2f;
                                int arg_90F_6 = 100;
                                Color newColor = default(Color);
                                int num6 = Dust.NewDust(arg_90F_0, arg_90F_1, arg_90F_2, arg_90F_3, arg_90F_4, arg_90F_5, arg_90F_6, newColor, 2f);
                                Main.dust[num6].noGravity = true;
                                Dust expr_931_cp_0 = Main.dust[num6];
                                expr_931_cp_0.velocity.X = expr_931_cp_0.velocity.X * 0.3f;
                                Dust expr_94F_cp_0 = Main.dust[num6];
                                expr_94F_cp_0.velocity.Y = expr_94F_cp_0.velocity.Y * 0.3f;
                            }
                        }
                        else
                        {
                            if (this.type == 33)
                            {
                                if (Main.rand.Next(1) == 0)
                                {
                                    Vector2 arg_9D3_0 = this.position;
                                    int arg_9D3_1 = this.width;
                                    int arg_9D3_2 = this.height;
                                    int arg_9D3_3 = 40;
                                    float arg_9D3_4 = this.velocity.X * 0.25f;
                                    float arg_9D3_5 = this.velocity.Y * 0.25f;
                                    int arg_9D3_6 = 0;
                                    Color newColor = default(Color);
                                    int num7 = Dust.NewDust(arg_9D3_0, arg_9D3_1, arg_9D3_2, arg_9D3_3, arg_9D3_4, arg_9D3_5, arg_9D3_6, newColor, 1.4f);
                                    Main.dust[num7].noGravity = true;
                                }
                            }
                            else
                            {
                                if (this.type == 6 && Main.rand.Next(5) == 0)
                                {
                                    int num8 = Main.rand.Next(3);
                                    if (num8 == 0)
                                    {
                                        num8 = 15;
                                    }
                                    else
                                    {
                                        if (num8 == 1)
                                        {
                                            num8 = 57;
                                        }
                                        else
                                        {
                                            num8 = 58;
                                        }
                                    }
                                    Vector2 arg_A76_0 = this.position;
                                    int arg_A76_1 = this.width;
                                    int arg_A76_2 = this.height;
                                    int arg_A76_3 = num8;
                                    float arg_A76_4 = this.velocity.X * 0.25f;
                                    float arg_A76_5 = this.velocity.Y * 0.25f;
                                    int arg_A76_6 = 150;
                                    Color newColor = default(Color);
                                    Dust.NewDust(arg_A76_0, arg_A76_1, arg_A76_2, arg_A76_3, arg_A76_4, arg_A76_5, arg_A76_6, newColor, 0.7f);
                                }
                            }
                        }
                        if (this.ai[0] == 0f)
                        {
                            this.ai[1] += 1f;
                            if (this.type == 106)
                            {
                                if (this.ai[1] >= 45f)
                                {
                                    this.ai[0] = 1f;
                                    this.ai[1] = 0f;
                                    this.netUpdate = true;
                                }
                            }
                            else
                            {
                                if (this.ai[1] >= 30f)
                                {
                                    this.ai[0] = 1f;
                                    this.ai[1] = 0f;
                                    this.netUpdate = true;
                                }
                            }
                        }
                        else
                        {
                            this.tileCollide = false;
                            float num9 = 9f;
                            float num10 = 0.4f;
                            if (this.type == 19)
                            {
                                num9 = 13f;
                                num10 = 0.6f;
                            }
                            else
                            {
                                if (this.type == 33)
                                {
                                    num9 = 15f;
                                    num10 = 0.8f;
                                }
                                else
                                {
                                    if (this.type == 106)
                                    {
                                        num9 = 16f;
                                        num10 = 1.2f;
                                    }
                                }
                            }
                            Vector2 vector = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                            float num11 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector.X;
                            float num12 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector.Y;
                            float num13 = (float)Math.Sqrt((double)(num11 * num11 + num12 * num12));
                            if (num13 > 3000f)
                            {
                                this.Kill();
                            }
                            num13 = num9 / num13;
                            num11 *= num13;
                            num12 *= num13;
                            if (this.velocity.X < num11)
                            {
                                this.velocity.X = this.velocity.X + num10;
                                if (this.velocity.X < 0f && num11 > 0f)
                                {
                                    this.velocity.X = this.velocity.X + num10;
                                }
                            }
                            else
                            {
                                if (this.velocity.X > num11)
                                {
                                    this.velocity.X = this.velocity.X - num10;
                                    if (this.velocity.X > 0f && num11 < 0f)
                                    {
                                        this.velocity.X = this.velocity.X - num10;
                                    }
                                }
                            }
                            if (this.velocity.Y < num12)
                            {
                                this.velocity.Y = this.velocity.Y + num10;
                                if (this.velocity.Y < 0f && num12 > 0f)
                                {
                                    this.velocity.Y = this.velocity.Y + num10;
                                }
                            }
                            else
                            {
                                if (this.velocity.Y > num12)
                                {
                                    this.velocity.Y = this.velocity.Y - num10;
                                    if (this.velocity.Y > 0f && num12 < 0f)
                                    {
                                        this.velocity.Y = this.velocity.Y - num10;
                                    }
                                }
                            }
                            if (Main.myPlayer == this.owner)
                            {
                                Rectangle rectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.width, this.height);
                                Rectangle value = new Rectangle((int)Main.player[this.owner].position.X, (int)Main.player[this.owner].position.Y, Main.player[this.owner].width, Main.player[this.owner].height);
                                if (rectangle.Intersects(value))
                                {
                                    this.Kill();
                                }
                            }
                        }
                        if (this.type == 106)
                        {
                            this.rotation += 0.3f * (float)this.direction;
                            return;
                        }
                        this.rotation += 0.4f * (float)this.direction;
                        return;
                    }
                    else
                    {
                        if (this.aiStyle == 4)
                        {
                            this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                            if (this.ai[0] == 0f)
                            {
                                this.alpha -= 50;
                                if (this.alpha <= 0)
                                {
                                    this.alpha = 0;
                                    this.ai[0] = 1f;
                                    if (this.ai[1] == 0f)
                                    {
                                        this.ai[1] += 1f;
                                        this.position += this.velocity * 1f;
                                    }
                                    if (this.type == 7 && Main.myPlayer == this.owner)
                                    {
                                        int num14 = this.type;
                                        if (this.ai[1] >= 6f)
                                        {
                                            num14++;
                                        }
                                        int num15 = Projectile.NewProjectile(this.position.X + this.velocity.X + (float)(this.width / 2), this.position.Y + this.velocity.Y + (float)(this.height / 2), this.velocity.X, this.velocity.Y, num14, this.damage, this.knockBack, this.owner);
                                        Main.projectile[num15].damage = this.damage;
                                        Main.projectile[num15].ai[1] = this.ai[1] + 1f;
                                        NetMessage.SendData(27, -1, -1, "", num15, 0f, 0f, 0f, 0);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (this.alpha < 170 && this.alpha + 5 >= 170)
                                {
                                    Color newColor;
                                    for (int j = 0; j < 3; j++)
                                    {
                                        Vector2 arg_10C2_0 = this.position;
                                        int arg_10C2_1 = this.width;
                                        int arg_10C2_2 = this.height;
                                        int arg_10C2_3 = 18;
                                        float arg_10C2_4 = this.velocity.X * 0.025f;
                                        float arg_10C2_5 = this.velocity.Y * 0.025f;
                                        int arg_10C2_6 = 170;
                                        newColor = default(Color);
                                        Dust.NewDust(arg_10C2_0, arg_10C2_1, arg_10C2_2, arg_10C2_3, arg_10C2_4, arg_10C2_5, arg_10C2_6, newColor, 1.2f);
                                    }
                                    Vector2 arg_1105_0 = this.position;
                                    int arg_1105_1 = this.width;
                                    int arg_1105_2 = this.height;
                                    int arg_1105_3 = 14;
                                    float arg_1105_4 = 0f;
                                    float arg_1105_5 = 0f;
                                    int arg_1105_6 = 170;
                                    newColor = default(Color);
                                    Dust.NewDust(arg_1105_0, arg_1105_1, arg_1105_2, arg_1105_3, arg_1105_4, arg_1105_5, arg_1105_6, newColor, 1.1f);
                                }
                                this.alpha += 5;
                                if (this.alpha >= 255)
                                {
                                    this.Kill();
                                    return;
                                }
                            }
                        }
                        else
                        {
                            if (this.aiStyle == 5)
                            {
                                if (this.type == 92)
                                {
                                    if (this.position.Y > this.ai[1])
                                    {
                                        this.tileCollide = true;
                                    }
                                }
                                else
                                {
                                    if (this.ai[1] == 0f && !Collision.SolidCollision(this.position, this.width, this.height))
                                    {
                                        this.ai[1] = 1f;
                                        this.netUpdate = true;
                                    }
                                    if (this.ai[1] != 0f)
                                    {
                                        this.tileCollide = true;
                                    }
                                }
                                if (this.soundDelay == 0)
                                {
                                    this.soundDelay = 20 + Main.rand.Next(40);
                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                                }
                                if (this.localAI[0] == 0f)
                                {
                                    this.localAI[0] = 1f;
                                }
                                this.alpha += (int)(25f * this.localAI[0]);
                                if (this.alpha > 200)
                                {
                                    this.alpha = 200;
                                    this.localAI[0] = -1f;
                                }
                                if (this.alpha < 0)
                                {
                                    this.alpha = 0;
                                    this.localAI[0] = 1f;
                                }
                                this.rotation += (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y)) * 0.01f * (float)this.direction;
                                if (this.ai[1] == 1f || this.type == 92)
                                {
                                    this.light = 0.9f;
                                    if (Main.rand.Next(10) == 0)
                                    {
                                        Vector2 arg_1328_0 = this.position;
                                        int arg_1328_1 = this.width;
                                        int arg_1328_2 = this.height;
                                        int arg_1328_3 = 58;
                                        float arg_1328_4 = this.velocity.X * 0.5f;
                                        float arg_1328_5 = this.velocity.Y * 0.5f;
                                        int arg_1328_6 = 150;
                                        Color newColor = default(Color);
                                        Dust.NewDust(arg_1328_0, arg_1328_1, arg_1328_2, arg_1328_3, arg_1328_4, arg_1328_5, arg_1328_6, newColor, 1.2f);
                                    }
                                    if (Main.rand.Next(20) == 0)
                                    {
                                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.2f, this.velocity.Y * 0.2f), Main.rand.Next(16, 18), 1f);
                                        return;
                                    }
                                }
                            }
                            else
                            {
                                if (this.aiStyle == 6)
                                {
                                    this.velocity *= 0.95f;
                                    this.ai[0] += 1f;
                                    if (this.ai[0] == 180f)
                                    {
                                        this.Kill();
                                    }
                                    if (this.ai[1] == 0f)
                                    {
                                        this.ai[1] = 1f;
                                        for (int k = 0; k < 30; k++)
                                        {
                                            Vector2 arg_143D_0 = this.position;
                                            int arg_143D_1 = this.width;
                                            int arg_143D_2 = this.height;
                                            int arg_143D_3 = 10 + this.type;
                                            float arg_143D_4 = this.velocity.X;
                                            float arg_143D_5 = this.velocity.Y;
                                            int arg_143D_6 = 50;
                                            Color newColor = default(Color);
                                            Dust.NewDust(arg_143D_0, arg_143D_1, arg_143D_2, arg_143D_3, arg_143D_4, arg_143D_5, arg_143D_6, newColor, 1f);
                                        }
                                    }
                                    if (this.type == 10 || this.type == 11)
                                    {
                                        int num16 = (int)(this.position.X / 16f) - 1;
                                        int num17 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                        int num18 = (int)(this.position.Y / 16f) - 1;
                                        int num19 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                        if (num16 < 0)
                                        {
                                            num16 = 0;
                                        }
                                        if (num17 > Main.maxTilesX)
                                        {
                                            num17 = Main.maxTilesX;
                                        }
                                        if (num18 < 0)
                                        {
                                            num18 = 0;
                                        }
                                        if (num19 > Main.maxTilesY)
                                        {
                                            num19 = Main.maxTilesY;
                                        }
                                        for (int l = num16; l < num17; l++)
                                        {
                                            for (int m = num18; m < num19; m++)
                                            {
                                                Vector2 vector2;
                                                vector2.X = (float)(l * 16);
                                                vector2.Y = (float)(m * 16);
                                                if (this.position.X + (float)this.width > vector2.X && this.position.X < vector2.X + 16f && this.position.Y + (float)this.height > vector2.Y && this.position.Y < vector2.Y + 16f && Main.myPlayer == this.owner && Main.tile[l, m].active)
                                                {
                                                    if (this.type == 10)
                                                    {
                                                        if (Main.tile[l, m].type == 23)
                                                        {
                                                            Main.tile[l, m].type = 2;
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                        if (Main.tile[l, m].type == 25)
                                                        {
                                                            Main.tile[l, m].type = 1;
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                        if (Main.tile[l, m].type == 112)
                                                        {
                                                            Main.tile[l, m].type = 53;
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                        if (Main.tile[l, m].type == 113)
                                                        {
                                                            //Main.tile[l, m].type = 0;
                                                            WorldGen.KillTile(l, m, false, false, false);
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                        if (Main.tile[l, m].type == 32)
                                                        {
                                                            //Main.tile[l, m].type = 2;
                                                            WorldGen.KillTile(l, m, false, false, false);
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                        if (Main.tile[l, m].type == 24)
                                                        {
                                                            //Main.tile[l, m].type = 0;
                                                            WorldGen.KillTile(l, m, false, false, false);
                                                            WorldGen.SquareTileFrame(l, m, true);
                                                            if (Main.netMode == 1)
                                                            {
                                                                NetMessage.SendTileSquare(-1, l, m, 1);
                                                            }
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.type == 11)
                                                        {
                                                            if (Main.tile[l, m].type == 109)
                                                            {
                                                                Main.tile[l, m].type = 2;
                                                                WorldGen.SquareTileFrame(l, m, true);
                                                                if (Main.netMode == 1)
                                                                {
                                                                    NetMessage.SendTileSquare(-1, l, m, 1);
                                                                }
                                                            }
                                                            if (Main.tile[l, m].type == 116)
                                                            {
                                                                Main.tile[l, m].type = 53;
                                                                WorldGen.SquareTileFrame(l, m, true);
                                                                if (Main.netMode == 1)
                                                                {
                                                                    NetMessage.SendTileSquare(-1, l, m, 1);
                                                                }
                                                            }
                                                            if (Main.tile[l, m].type == 117)
                                                            {
                                                                Main.tile[l, m].type = 1;
                                                                WorldGen.SquareTileFrame(l, m, true);
                                                                if (Main.netMode == 1)
                                                                {
                                                                    NetMessage.SendTileSquare(-1, l, m, 1);
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                        return;
                                    }
                                }
                                else
                                {
                                    if (this.aiStyle == 7)
                                    {
                                        if (Main.player[this.owner].dead)
                                        {
                                            this.Kill();
                                            return;
                                        }
                                        Vector2 vector3 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                        float num20 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector3.X;
                                        float num21 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector3.Y;
                                        float num22 = (float)Math.Sqrt((double)(num20 * num20 + num21 * num21));
                                        this.rotation = (float)Math.Atan2((double)num21, (double)num20) - 1.57f;
                                        if (this.ai[0] == 0f)
                                        {
                                            if ((num22 > 300f && this.type == 13) || (num22 > 400f && this.type == 32) || (num22 > 440f && this.type == 73) || (num22 > 440f && this.type == 74))
                                            {
                                                this.ai[0] = 1f;
                                            }
                                            int num23 = (int)(this.position.X / 16f) - 1;
                                            int num24 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                            int num25 = (int)(this.position.Y / 16f) - 1;
                                            int num26 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                            if (num23 < 0)
                                            {
                                                num23 = 0;
                                            }
                                            if (num24 > Main.maxTilesX)
                                            {
                                                num24 = Main.maxTilesX;
                                            }
                                            if (num25 < 0)
                                            {
                                                num25 = 0;
                                            }
                                            if (num26 > Main.maxTilesY)
                                            {
                                                num26 = Main.maxTilesY;
                                            }
                                            for (int n = num23; n < num24; n++)
                                            {
                                                int num27 = num25;
                                                while (num27 < num26)
                                                {
                                                    if (Main.tile[n, num27] == null)
                                                    {
                                                        Main.tile[n, num27] = new Tile();
                                                    }
                                                    Vector2 vector4;
                                                    vector4.X = (float)(n * 16);
                                                    vector4.Y = (float)(num27 * 16);
                                                    if (this.position.X + (float)this.width > vector4.X && this.position.X < vector4.X + 16f && this.position.Y + (float)this.height > vector4.Y && this.position.Y < vector4.Y + 16f && Main.tile[n, num27].active && Main.tileSolid[(int)Main.tile[n, num27].type])
                                                    {
                                                        if (Main.player[this.owner].grapCount < 10)
                                                        {
                                                            Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                                            Main.player[this.owner].grapCount++;
                                                        }
                                                        if (Main.myPlayer == this.owner)
                                                        {
                                                            int num28 = 0;
                                                            int num29 = -1;
                                                            int num30 = 100000;
                                                            if (this.type == 73 || this.type == 74)
                                                            {
                                                                for (int num31 = 0; num31 < 1000; num31++)
                                                                {
                                                                    if (num31 != this.whoAmI && Main.projectile[num31].active && Main.projectile[num31].owner == this.owner && Main.projectile[num31].aiStyle == 7 && Main.projectile[num31].ai[0] == 2f)
                                                                    {
                                                                        Main.projectile[num31].Kill();
                                                                    }
                                                                }
                                                            }
                                                            else
                                                            {
                                                                for (int num32 = 0; num32 < 1000; num32++)
                                                                {
                                                                    if (Main.projectile[num32].active && Main.projectile[num32].owner == this.owner && Main.projectile[num32].aiStyle == 7)
                                                                    {
                                                                        if (Main.projectile[num32].timeLeft < num30)
                                                                        {
                                                                            num29 = num32;
                                                                            num30 = Main.projectile[num32].timeLeft;
                                                                        }
                                                                        num28++;
                                                                    }
                                                                }
                                                                if (num28 > 3)
                                                                {
                                                                    Main.projectile[num29].Kill();
                                                                }
                                                            }
                                                        }
                                                        WorldGen.KillTile(n, num27, true, true, false);
                                                        Main.PlaySound(0, n * 16, num27 * 16, 1);
                                                        this.velocity.X = 0f;
                                                        this.velocity.Y = 0f;
                                                        this.ai[0] = 2f;
                                                        this.position.X = (float)(n * 16 + 8 - this.width / 2);
                                                        this.position.Y = (float)(num27 * 16 + 8 - this.height / 2);
                                                        this.damage = 0;
                                                        this.netUpdate = true;
                                                        if (Main.myPlayer == this.owner)
                                                        {
                                                            NetMessage.SendData(13, -1, -1, "", this.owner, 0f, 0f, 0f, 0);
                                                            break;
                                                        }
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        num27++;
                                                    }
                                                }
                                                if (this.ai[0] == 2f)
                                                {
                                                    return;
                                                }
                                            }
                                            return;
                                        }
                                        if (this.ai[0] == 1f)
                                        {
                                            float num33 = 11f;
                                            if (this.type == 32)
                                            {
                                                num33 = 15f;
                                            }
                                            if (this.type == 73 || this.type == 74)
                                            {
                                                num33 = 17f;
                                            }
                                            if (num22 < 24f)
                                            {
                                                this.Kill();
                                            }
                                            num22 = num33 / num22;
                                            num20 *= num22;
                                            num21 *= num22;
                                            this.velocity.X = num20;
                                            this.velocity.Y = num21;
                                            return;
                                        }
                                        if (this.ai[0] == 2f)
                                        {
                                            int num34 = (int)(this.position.X / 16f) - 1;
                                            int num35 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                            int num36 = (int)(this.position.Y / 16f) - 1;
                                            int num37 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                            if (num34 < 0)
                                            {
                                                num34 = 0;
                                            }
                                            if (num35 > Main.maxTilesX)
                                            {
                                                num35 = Main.maxTilesX;
                                            }
                                            if (num36 < 0)
                                            {
                                                num36 = 0;
                                            }
                                            if (num37 > Main.maxTilesY)
                                            {
                                                num37 = Main.maxTilesY;
                                            }
                                            bool flag = true;
                                            for (int num38 = num34; num38 < num35; num38++)
                                            {
                                                for (int num39 = num36; num39 < num37; num39++)
                                                {
                                                    if (Main.tile[num38, num39] == null)
                                                    {
                                                        Main.tile[num38, num39] = new Tile();
                                                    }
                                                    Vector2 vector5;
                                                    vector5.X = (float)(num38 * 16);
                                                    vector5.Y = (float)(num39 * 16);
                                                    if (this.position.X + (float)(this.width / 2) > vector5.X && this.position.X + (float)(this.width / 2) < vector5.X + 16f && this.position.Y + (float)(this.height / 2) > vector5.Y && this.position.Y + (float)(this.height / 2) < vector5.Y + 16f && Main.tile[num38, num39].active && Main.tileSolid[(int)Main.tile[num38, num39].type])
                                                    {
                                                        flag = false;
                                                    }
                                                }
                                            }
                                            if (flag)
                                            {
                                                this.ai[0] = 1f;
                                                return;
                                            }
                                            if (Main.player[this.owner].grapCount < 10)
                                            {
                                                Main.player[this.owner].grappling[Main.player[this.owner].grapCount] = this.whoAmI;
                                                Main.player[this.owner].grapCount++;
                                                return;
                                            }
                                        }
                                    }
                                    else
                                    {
                                        if (this.aiStyle == 8)
                                        {
                                            if (this.type == 96 && this.localAI[0] == 0f)
                                            {
                                                this.localAI[0] = 1f;
                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 20);
                                            }
                                            if (this.type == 27)
                                            {
                                                Vector2 arg_20B6_0 = new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
                                                int arg_20B6_1 = this.width;
                                                int arg_20B6_2 = this.height;
                                                int arg_20B6_3 = 29;
                                                float arg_20B6_4 = this.velocity.X;
                                                float arg_20B6_5 = this.velocity.Y;
                                                int arg_20B6_6 = 100;
                                                Color newColor = default(Color);
                                                int num40 = Dust.NewDust(arg_20B6_0, arg_20B6_1, arg_20B6_2, arg_20B6_3, arg_20B6_4, arg_20B6_5, arg_20B6_6, newColor, 3f);
                                                Main.dust[num40].noGravity = true;
                                                if (Main.rand.Next(10) == 0)
                                                {
                                                    Vector2 arg_212C_0 = new Vector2(this.position.X, this.position.Y);
                                                    int arg_212C_1 = this.width;
                                                    int arg_212C_2 = this.height;
                                                    int arg_212C_3 = 29;
                                                    float arg_212C_4 = this.velocity.X;
                                                    float arg_212C_5 = this.velocity.Y;
                                                    int arg_212C_6 = 100;
                                                    newColor = default(Color);
                                                    num40 = Dust.NewDust(arg_212C_0, arg_212C_1, arg_212C_2, arg_212C_3, arg_212C_4, arg_212C_5, arg_212C_6, newColor, 1.4f);
                                                }
                                            }
                                            else
                                            {
                                                if (this.type == 95 || this.type == 96)
                                                {
                                                    Vector2 arg_21BE_0 = new Vector2(this.position.X + this.velocity.X, this.position.Y + this.velocity.Y);
                                                    int arg_21BE_1 = this.width;
                                                    int arg_21BE_2 = this.height;
                                                    int arg_21BE_3 = 75;
                                                    float arg_21BE_4 = this.velocity.X;
                                                    float arg_21BE_5 = this.velocity.Y;
                                                    int arg_21BE_6 = 100;
                                                    Color newColor = default(Color);
                                                    int num41 = Dust.NewDust(arg_21BE_0, arg_21BE_1, arg_21BE_2, arg_21BE_3, arg_21BE_4, arg_21BE_5, arg_21BE_6, newColor, 3f * this.scale);
                                                    Main.dust[num41].noGravity = true;
                                                }
                                                else
                                                {
                                                    for (int num42 = 0; num42 < 2; num42++)
                                                    {
                                                        Vector2 arg_223B_0 = new Vector2(this.position.X, this.position.Y);
                                                        int arg_223B_1 = this.width;
                                                        int arg_223B_2 = this.height;
                                                        int arg_223B_3 = 6;
                                                        float arg_223B_4 = this.velocity.X * 0.2f;
                                                        float arg_223B_5 = this.velocity.Y * 0.2f;
                                                        int arg_223B_6 = 100;
                                                        Color newColor = default(Color);
                                                        int num43 = Dust.NewDust(arg_223B_0, arg_223B_1, arg_223B_2, arg_223B_3, arg_223B_4, arg_223B_5, arg_223B_6, newColor, 2f);
                                                        Main.dust[num43].noGravity = true;
                                                        Dust expr_225D_cp_0 = Main.dust[num43];
                                                        expr_225D_cp_0.velocity.X = expr_225D_cp_0.velocity.X * 0.3f;
                                                        Dust expr_227B_cp_0 = Main.dust[num43];
                                                        expr_227B_cp_0.velocity.Y = expr_227B_cp_0.velocity.Y * 0.3f;
                                                    }
                                                }
                                            }
                                            if (this.type != 27 && this.type != 96)
                                            {
                                                this.ai[1] += 1f;
                                            }
                                            if (this.ai[1] >= 20f)
                                            {
                                                this.velocity.Y = this.velocity.Y + 0.2f;
                                            }
                                            this.rotation += 0.3f * (float)this.direction;
                                            if (this.velocity.Y > 16f)
                                            {
                                                this.velocity.Y = 16f;
                                                return;
                                            }
                                        }
                                        else
                                        {
                                            if (this.aiStyle == 9)
                                            {
                                                if (this.type == 34)
                                                {
                                                    Vector2 arg_23A6_0 = new Vector2(this.position.X, this.position.Y);
                                                    int arg_23A6_1 = this.width;
                                                    int arg_23A6_2 = this.height;
                                                    int arg_23A6_3 = 6;
                                                    float arg_23A6_4 = this.velocity.X * 0.2f;
                                                    float arg_23A6_5 = this.velocity.Y * 0.2f;
                                                    int arg_23A6_6 = 100;
                                                    Color newColor = default(Color);
                                                    int num44 = Dust.NewDust(arg_23A6_0, arg_23A6_1, arg_23A6_2, arg_23A6_3, arg_23A6_4, arg_23A6_5, arg_23A6_6, newColor, 3.5f);
                                                    Main.dust[num44].noGravity = true;
                                                    Dust expr_23C3 = Main.dust[num44];
                                                    expr_23C3.velocity *= 1.4f;
                                                    Vector2 arg_2433_0 = new Vector2(this.position.X, this.position.Y);
                                                    int arg_2433_1 = this.width;
                                                    int arg_2433_2 = this.height;
                                                    int arg_2433_3 = 6;
                                                    float arg_2433_4 = this.velocity.X * 0.2f;
                                                    float arg_2433_5 = this.velocity.Y * 0.2f;
                                                    int arg_2433_6 = 100;
                                                    newColor = default(Color);
                                                    num44 = Dust.NewDust(arg_2433_0, arg_2433_1, arg_2433_2, arg_2433_3, arg_2433_4, arg_2433_5, arg_2433_6, newColor, 1.5f);
                                                }
                                                else
                                                {
                                                    if (this.type == 79)
                                                    {
                                                        if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
                                                        {
                                                            this.soundDelay = 10;
                                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                                                        }
                                                        for (int num45 = 0; num45 < 1; num45++)
                                                        {
                                                            int num46 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2.5f);
                                                            Dust expr_2509 = Main.dust[num46];
                                                            expr_2509.velocity *= 0.1f;
                                                            Dust expr_2526 = Main.dust[num46];
                                                            expr_2526.velocity += this.velocity * 0.2f;
                                                            Main.dust[num46].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-2, 3);
                                                            Main.dust[num46].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-2, 3);
                                                            Main.dust[num46].noGravity = true;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.soundDelay == 0 && Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) > 2f)
                                                        {
                                                            this.soundDelay = 10;
                                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 9);
                                                        }
                                                        Vector2 arg_2675_0 = new Vector2(this.position.X, this.position.Y);
                                                        int arg_2675_1 = this.width;
                                                        int arg_2675_2 = this.height;
                                                        int arg_2675_3 = 15;
                                                        float arg_2675_4 = 0f;
                                                        float arg_2675_5 = 0f;
                                                        int arg_2675_6 = 100;
                                                        Color newColor = default(Color);
                                                        int num47 = Dust.NewDust(arg_2675_0, arg_2675_1, arg_2675_2, arg_2675_3, arg_2675_4, arg_2675_5, arg_2675_6, newColor, 2f);
                                                        Dust expr_2684 = Main.dust[num47];
                                                        expr_2684.velocity *= 0.3f;
                                                        Main.dust[num47].position.X = this.position.X + (float)(this.width / 2) + 4f + (float)Main.rand.Next(-4, 5);
                                                        Main.dust[num47].position.Y = this.position.Y + (float)(this.height / 2) + (float)Main.rand.Next(-4, 5);
                                                        Main.dust[num47].noGravity = true;
                                                    }
                                                }
                                                if (Main.myPlayer == this.owner && this.ai[0] == 0f)
                                                {
                                                    if (Main.player[this.owner].channel)
                                                    {
                                                        float num48 = 12f;
                                                        if (this.type == 16)
                                                        {
                                                            num48 = 15f;
                                                        }
                                                        Vector2 vector6 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                        float num49 = (float)Main.mouseX + Main.screenPosition.X - vector6.X;
                                                        float num50 = (float)Main.mouseY + Main.screenPosition.Y - vector6.Y;
                                                        float num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
                                                        num51 = (float)Math.Sqrt((double)(num49 * num49 + num50 * num50));
                                                        if (num51 > num48)
                                                        {
                                                            num51 = num48 / num51;
                                                            num49 *= num51;
                                                            num50 *= num51;
                                                            int num52 = (int)(num49 * 1000f);
                                                            int num53 = (int)(this.velocity.X * 1000f);
                                                            int num54 = (int)(num50 * 1000f);
                                                            int num55 = (int)(this.velocity.Y * 1000f);
                                                            if (num52 != num53 || num54 != num55)
                                                            {
                                                                this.netUpdate = true;
                                                            }
                                                            this.velocity.X = num49;
                                                            this.velocity.Y = num50;
                                                        }
                                                        else
                                                        {
                                                            int num56 = (int)(num49 * 1000f);
                                                            int num57 = (int)(this.velocity.X * 1000f);
                                                            int num58 = (int)(num50 * 1000f);
                                                            int num59 = (int)(this.velocity.Y * 1000f);
                                                            if (num56 != num57 || num58 != num59)
                                                            {
                                                                this.netUpdate = true;
                                                            }
                                                            this.velocity.X = num49;
                                                            this.velocity.Y = num50;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.ai[0] == 0f)
                                                        {
                                                            this.ai[0] = 1f;
                                                            this.netUpdate = true;
                                                            float num60 = 12f;
                                                            Vector2 vector7 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                            float num61 = (float)Main.mouseX + Main.screenPosition.X - vector7.X;
                                                            float num62 = (float)Main.mouseY + Main.screenPosition.Y - vector7.Y;
                                                            float num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
                                                            if (num63 == 0f)
                                                            {
                                                                vector7 = new Vector2(Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2), Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2));
                                                                num61 = this.position.X + (float)this.width * 0.5f - vector7.X;
                                                                num62 = this.position.Y + (float)this.height * 0.5f - vector7.Y;
                                                                num63 = (float)Math.Sqrt((double)(num61 * num61 + num62 * num62));
                                                            }
                                                            num63 = num60 / num63;
                                                            num61 *= num63;
                                                            num62 *= num63;
                                                            this.velocity.X = num61;
                                                            this.velocity.Y = num62;
                                                            if (this.velocity.X == 0f && this.velocity.Y == 0f)
                                                            {
                                                                this.Kill();
                                                            }
                                                        }
                                                    }
                                                }
                                                if (this.type == 34)
                                                {
                                                    this.rotation += 0.3f * (float)this.direction;
                                                }
                                                else
                                                {
                                                    if (this.velocity.X != 0f || this.velocity.Y != 0f)
                                                    {
                                                        this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) - 2.355f;
                                                    }
                                                }
                                                if (this.velocity.Y > 16f)
                                                {
                                                    this.velocity.Y = 16f;
                                                    return;
                                                }
                                            }
                                            else
                                            {
                                                if (this.aiStyle == 10)
                                                {
                                                    if (this.type == 31 && this.ai[0] != 2f)
                                                    {
                                                        if (Main.rand.Next(2) == 0)
                                                        {
                                                            Vector2 arg_2BEF_0 = new Vector2(this.position.X, this.position.Y);
                                                            int arg_2BEF_1 = this.width;
                                                            int arg_2BEF_2 = this.height;
                                                            int arg_2BEF_3 = 32;
                                                            float arg_2BEF_4 = 0f;
                                                            float arg_2BEF_5 = this.velocity.Y / 2f;
                                                            int arg_2BEF_6 = 0;
                                                            Color newColor = default(Color);
                                                            int num64 = Dust.NewDust(arg_2BEF_0, arg_2BEF_1, arg_2BEF_2, arg_2BEF_3, arg_2BEF_4, arg_2BEF_5, arg_2BEF_6, newColor, 1f);
                                                            Dust expr_2C03_cp_0 = Main.dust[num64];
                                                            expr_2C03_cp_0.velocity.X = expr_2C03_cp_0.velocity.X * 0.4f;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.type == 39)
                                                        {
                                                            if (Main.rand.Next(2) == 0)
                                                            {
                                                                Vector2 arg_2C85_0 = new Vector2(this.position.X, this.position.Y);
                                                                int arg_2C85_1 = this.width;
                                                                int arg_2C85_2 = this.height;
                                                                int arg_2C85_3 = 38;
                                                                float arg_2C85_4 = 0f;
                                                                float arg_2C85_5 = this.velocity.Y / 2f;
                                                                int arg_2C85_6 = 0;
                                                                Color newColor = default(Color);
                                                                int num65 = Dust.NewDust(arg_2C85_0, arg_2C85_1, arg_2C85_2, arg_2C85_3, arg_2C85_4, arg_2C85_5, arg_2C85_6, newColor, 1f);
                                                                Dust expr_2C99_cp_0 = Main.dust[num65];
                                                                expr_2C99_cp_0.velocity.X = expr_2C99_cp_0.velocity.X * 0.4f;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (this.type == 40)
                                                            {
                                                                if (Main.rand.Next(2) == 0)
                                                                {
                                                                    Vector2 arg_2D1B_0 = new Vector2(this.position.X, this.position.Y);
                                                                    int arg_2D1B_1 = this.width;
                                                                    int arg_2D1B_2 = this.height;
                                                                    int arg_2D1B_3 = 36;
                                                                    float arg_2D1B_4 = 0f;
                                                                    float arg_2D1B_5 = this.velocity.Y / 2f;
                                                                    int arg_2D1B_6 = 0;
                                                                    Color newColor = default(Color);
                                                                    int num66 = Dust.NewDust(arg_2D1B_0, arg_2D1B_1, arg_2D1B_2, arg_2D1B_3, arg_2D1B_4, arg_2D1B_5, arg_2D1B_6, newColor, 1f);
                                                                    Dust expr_2D2A = Main.dust[num66];
                                                                    expr_2D2A.velocity *= 0.4f;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.type == 42 || this.type == 31)
                                                                {
                                                                    if (Main.rand.Next(2) == 0)
                                                                    {
                                                                        Vector2 arg_2DAB_0 = new Vector2(this.position.X, this.position.Y);
                                                                        int arg_2DAB_1 = this.width;
                                                                        int arg_2DAB_2 = this.height;
                                                                        int arg_2DAB_3 = 32;
                                                                        float arg_2DAB_4 = 0f;
                                                                        float arg_2DAB_5 = 0f;
                                                                        int arg_2DAB_6 = 0;
                                                                        Color newColor = default(Color);
                                                                        int num67 = Dust.NewDust(arg_2DAB_0, arg_2DAB_1, arg_2DAB_2, arg_2DAB_3, arg_2DAB_4, arg_2DAB_5, arg_2DAB_6, newColor, 1f);
                                                                        Dust expr_2DBF_cp_0 = Main.dust[num67];
                                                                        expr_2DBF_cp_0.velocity.X = expr_2DBF_cp_0.velocity.X * 0.4f;
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (this.type == 56 || this.type == 65)
                                                                    {
                                                                        if (Main.rand.Next(2) == 0)
                                                                        {
                                                                            Vector2 arg_2E3C_0 = new Vector2(this.position.X, this.position.Y);
                                                                            int arg_2E3C_1 = this.width;
                                                                            int arg_2E3C_2 = this.height;
                                                                            int arg_2E3C_3 = 14;
                                                                            float arg_2E3C_4 = 0f;
                                                                            float arg_2E3C_5 = 0f;
                                                                            int arg_2E3C_6 = 0;
                                                                            Color newColor = default(Color);
                                                                            int num68 = Dust.NewDust(arg_2E3C_0, arg_2E3C_1, arg_2E3C_2, arg_2E3C_3, arg_2E3C_4, arg_2E3C_5, arg_2E3C_6, newColor, 1f);
                                                                            Dust expr_2E50_cp_0 = Main.dust[num68];
                                                                            expr_2E50_cp_0.velocity.X = expr_2E50_cp_0.velocity.X * 0.4f;
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.type == 67 || this.type == 68)
                                                                        {
                                                                            if (Main.rand.Next(2) == 0)
                                                                            {
                                                                                Vector2 arg_2ECD_0 = new Vector2(this.position.X, this.position.Y);
                                                                                int arg_2ECD_1 = this.width;
                                                                                int arg_2ECD_2 = this.height;
                                                                                int arg_2ECD_3 = 51;
                                                                                float arg_2ECD_4 = 0f;
                                                                                float arg_2ECD_5 = 0f;
                                                                                int arg_2ECD_6 = 0;
                                                                                Color newColor = default(Color);
                                                                                int num69 = Dust.NewDust(arg_2ECD_0, arg_2ECD_1, arg_2ECD_2, arg_2ECD_3, arg_2ECD_4, arg_2ECD_5, arg_2ECD_6, newColor, 1f);
                                                                                Dust expr_2EE1_cp_0 = Main.dust[num69];
                                                                                expr_2EE1_cp_0.velocity.X = expr_2EE1_cp_0.velocity.X * 0.4f;
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type == 71)
                                                                            {
                                                                                if (Main.rand.Next(2) == 0)
                                                                                {
                                                                                    Vector2 arg_2F54_0 = new Vector2(this.position.X, this.position.Y);
                                                                                    int arg_2F54_1 = this.width;
                                                                                    int arg_2F54_2 = this.height;
                                                                                    int arg_2F54_3 = 53;
                                                                                    float arg_2F54_4 = 0f;
                                                                                    float arg_2F54_5 = 0f;
                                                                                    int arg_2F54_6 = 0;
                                                                                    Color newColor = default(Color);
                                                                                    int num70 = Dust.NewDust(arg_2F54_0, arg_2F54_1, arg_2F54_2, arg_2F54_3, arg_2F54_4, arg_2F54_5, arg_2F54_6, newColor, 1f);
                                                                                    Dust expr_2F68_cp_0 = Main.dust[num70];
                                                                                    expr_2F68_cp_0.velocity.X = expr_2F68_cp_0.velocity.X * 0.4f;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type != 109 && Main.rand.Next(20) == 0)
                                                                                {
                                                                                    Vector2 arg_2FD5_0 = new Vector2(this.position.X, this.position.Y);
                                                                                    int arg_2FD5_1 = this.width;
                                                                                    int arg_2FD5_2 = this.height;
                                                                                    int arg_2FD5_3 = 0;
                                                                                    float arg_2FD5_4 = 0f;
                                                                                    float arg_2FD5_5 = 0f;
                                                                                    int arg_2FD5_6 = 0;
                                                                                    Color newColor = default(Color);
                                                                                    Dust.NewDust(arg_2FD5_0, arg_2FD5_1, arg_2FD5_2, arg_2FD5_3, arg_2FD5_4, arg_2FD5_5, arg_2FD5_6, newColor, 1f);
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                }
                                                            }
                                                        }
                                                    }
                                                    if (Main.myPlayer == this.owner && this.ai[0] == 0f)
                                                    {
                                                        if (Main.player[this.owner].channel)
                                                        {
                                                            float num71 = 12f;
                                                            Vector2 vector8 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                            float num72 = (float)Main.mouseX + Main.screenPosition.X - vector8.X;
                                                            float num73 = (float)Main.mouseY + Main.screenPosition.Y - vector8.Y;
                                                            float num74 = (float)Math.Sqrt((double)(num72 * num72 + num73 * num73));
                                                            num74 = (float)Math.Sqrt((double)(num72 * num72 + num73 * num73));
                                                            if (num74 > num71)
                                                            {
                                                                num74 = num71 / num74;
                                                                num72 *= num74;
                                                                num73 *= num74;
                                                                if (num72 != this.velocity.X || num73 != this.velocity.Y)
                                                                {
                                                                    this.netUpdate = true;
                                                                }
                                                                this.velocity.X = num72;
                                                                this.velocity.Y = num73;
                                                            }
                                                            else
                                                            {
                                                                if (num72 != this.velocity.X || num73 != this.velocity.Y)
                                                                {
                                                                    this.netUpdate = true;
                                                                }
                                                                this.velocity.X = num72;
                                                                this.velocity.Y = num73;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.ai[0] = 1f;
                                                            this.netUpdate = true;
                                                        }
                                                    }
                                                    if (this.ai[0] == 1f && this.type != 109)
                                                    {
                                                        if (this.type == 42 || this.type == 65 || this.type == 68)
                                                        {
                                                            this.ai[1] += 1f;
                                                            if (this.ai[1] >= 60f)
                                                            {
                                                                this.ai[1] = 60f;
                                                                this.velocity.Y = this.velocity.Y + 0.2f;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.velocity.Y = this.velocity.Y + 0.41f;
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.ai[0] == 2f && this.type != 109)
                                                        {
                                                            this.velocity.Y = this.velocity.Y + 0.2f;
                                                            if ((double)this.velocity.X < -0.04)
                                                            {
                                                                this.velocity.X = this.velocity.X + 0.04f;
                                                            }
                                                            else
                                                            {
                                                                if ((double)this.velocity.X > 0.04)
                                                                {
                                                                    this.velocity.X = this.velocity.X - 0.04f;
                                                                }
                                                                else
                                                                {
                                                                    this.velocity.X = 0f;
                                                                }
                                                            }
                                                        }
                                                    }
                                                    this.rotation += 0.1f;
                                                    if (this.velocity.Y > 10f)
                                                    {
                                                        this.velocity.Y = 10f;
                                                        return;
                                                    }
                                                }
                                                else
                                                {
                                                    if (this.aiStyle == 11)
                                                    {
                                                        if (this.type == 72 || this.type == 86 || this.type == 87)
                                                        {
                                                            if (this.velocity.X > 0f)
                                                            {
                                                                this.spriteDirection = -1;
                                                            }
                                                            else
                                                            {
                                                                if (this.velocity.X < 0f)
                                                                {
                                                                    this.spriteDirection = 1;
                                                                }
                                                            }
                                                            this.rotation = this.velocity.X * 0.1f;
                                                            this.frameCounter++;
                                                            if (this.frameCounter >= 4)
                                                            {
                                                                this.frame++;
                                                                this.frameCounter = 0;
                                                            }
                                                            if (this.frame >= 4)
                                                            {
                                                                this.frame = 0;
                                                            }
                                                            if (Main.rand.Next(6) == 0)
                                                            {
                                                                int num75 = 56;
                                                                if (this.type == 86)
                                                                {
                                                                    num75 = 73;
                                                                }
                                                                else
                                                                {
                                                                    if (this.type == 87)
                                                                    {
                                                                        num75 = 74;
                                                                    }
                                                                }
                                                                Vector2 arg_340A_0 = this.position;
                                                                int arg_340A_1 = this.width;
                                                                int arg_340A_2 = this.height;
                                                                int arg_340A_3 = num75;
                                                                float arg_340A_4 = 0f;
                                                                float arg_340A_5 = 0f;
                                                                int arg_340A_6 = 200;
                                                                Color newColor = default(Color);
                                                                int num76 = Dust.NewDust(arg_340A_0, arg_340A_1, arg_340A_2, arg_340A_3, arg_340A_4, arg_340A_5, arg_340A_6, newColor, 0.8f);
                                                                Dust expr_3419 = Main.dust[num76];
                                                                expr_3419.velocity *= 0.3f;
                                                            }
                                                        }
                                                        else
                                                        {
                                                            this.rotation += 0.02f;
                                                        }
                                                        if (Main.myPlayer == this.owner)
                                                        {
                                                            if (this.type == 72 || this.type == 86 || this.type == 87)
                                                            {
                                                                if (Main.player[Main.myPlayer].fairy)
                                                                {
                                                                    this.timeLeft = 2;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (Main.player[Main.myPlayer].lightOrb)
                                                                {
                                                                    this.timeLeft = 2;
                                                                }
                                                            }
                                                        }
                                                        if (Main.player[this.owner].dead)
                                                        {
                                                            this.Kill();
                                                            return;
                                                        }
                                                        float num77 = 2.5f;
                                                        if (this.type == 72 || this.type == 86 || this.type == 87)
                                                        {
                                                            num77 = 3.5f;
                                                        }
                                                        Vector2 vector9 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                        float num78 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector9.X;
                                                        float num79 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector9.Y;
                                                        float num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
                                                        num80 = (float)Math.Sqrt((double)(num78 * num78 + num79 * num79));
                                                        int num81 = 70;
                                                        if (this.type == 72 || this.type == 86 || this.type == 87)
                                                        {
                                                            num81 = 40;
                                                        }
                                                        if (num80 > 800f)
                                                        {
                                                            this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                                                            this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                                                            return;
                                                        }
                                                        if (num80 > (float)num81)
                                                        {
                                                            num80 = num77 / num80;
                                                            num78 *= num80;
                                                            num79 *= num80;
                                                            this.velocity.X = num78;
                                                            this.velocity.Y = num79;
                                                            return;
                                                        }
                                                        this.velocity.X = 0f;
                                                        this.velocity.Y = 0f;
                                                        return;
                                                    }
                                                    else
                                                    {
                                                        if (this.aiStyle == 12)
                                                        {
                                                            this.scale -= 0.04f;
                                                            if (this.scale <= 0f)
                                                            {
                                                                this.Kill();
                                                            }
                                                            if (this.ai[0] > 4f)
                                                            {
                                                                this.alpha = 150;
                                                                this.light = 0.8f;
                                                                Vector2 arg_376A_0 = new Vector2(this.position.X, this.position.Y);
                                                                int arg_376A_1 = this.width;
                                                                int arg_376A_2 = this.height;
                                                                int arg_376A_3 = 29;
                                                                float arg_376A_4 = this.velocity.X;
                                                                float arg_376A_5 = this.velocity.Y;
                                                                int arg_376A_6 = 100;
                                                                Color newColor = default(Color);
                                                                int num82 = Dust.NewDust(arg_376A_0, arg_376A_1, arg_376A_2, arg_376A_3, arg_376A_4, arg_376A_5, arg_376A_6, newColor, 2.5f);
                                                                Main.dust[num82].noGravity = true;
                                                                Vector2 arg_37CF_0 = new Vector2(this.position.X, this.position.Y);
                                                                int arg_37CF_1 = this.width;
                                                                int arg_37CF_2 = this.height;
                                                                int arg_37CF_3 = 29;
                                                                float arg_37CF_4 = this.velocity.X;
                                                                float arg_37CF_5 = this.velocity.Y;
                                                                int arg_37CF_6 = 100;
                                                                newColor = default(Color);
                                                                Dust.NewDust(arg_37CF_0, arg_37CF_1, arg_37CF_2, arg_37CF_3, arg_37CF_4, arg_37CF_5, arg_37CF_6, newColor, 1.5f);
                                                            }
                                                            else
                                                            {
                                                                this.ai[0] += 1f;
                                                            }
                                                            this.rotation += 0.3f * (float)this.direction;
                                                            return;
                                                        }
                                                        if (this.aiStyle == 13)
                                                        {
                                                            if (Main.player[this.owner].dead)
                                                            {
                                                                this.Kill();
                                                                return;
                                                            }
                                                            Main.player[this.owner].itemAnimation = 5;
                                                            Main.player[this.owner].itemTime = 5;
                                                            if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
                                                            {
                                                                Main.player[this.owner].direction = 1;
                                                            }
                                                            else
                                                            {
                                                                Main.player[this.owner].direction = -1;
                                                            }
                                                            Vector2 vector10 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                            float num83 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector10.X;
                                                            float num84 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector10.Y;
                                                            float num85 = (float)Math.Sqrt((double)(num83 * num83 + num84 * num84));
                                                            if (this.ai[0] == 0f)
                                                            {
                                                                if (num85 > 700f)
                                                                {
                                                                    this.ai[0] = 1f;
                                                                }
                                                                this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.57f;
                                                                this.ai[1] += 1f;
                                                                if (this.ai[1] > 2f)
                                                                {
                                                                    this.alpha = 0;
                                                                }
                                                                if (this.ai[1] >= 10f)
                                                                {
                                                                    this.ai[1] = 15f;
                                                                    this.velocity.Y = this.velocity.Y + 0.3f;
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.ai[0] == 1f)
                                                                {
                                                                    this.tileCollide = false;
                                                                    this.rotation = (float)Math.Atan2((double)num84, (double)num83) - 1.57f;
                                                                    float num86 = 20f;
                                                                    if (num85 < 50f)
                                                                    {
                                                                        this.Kill();
                                                                    }
                                                                    num85 = num86 / num85;
                                                                    num83 *= num85;
                                                                    num84 *= num85;
                                                                    this.velocity.X = num83;
                                                                    this.velocity.Y = num84;
                                                                    return;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (this.aiStyle == 14)
                                                            {
                                                                if (this.type == 53)
                                                                {
                                                                    try
                                                                    {
                                                                        Vector2 value2 = Collision.TileCollision(this.position, this.velocity, this.width, this.height, false, false);
                                                                        int num87 = (int)(this.position.X / 16f) - 1;
                                                                        int num88 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                                                        int num89 = (int)(this.position.Y / 16f) - 1;
                                                                        int num90 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                                                        if (num87 < 0)
                                                                        {
                                                                            num87 = 0;
                                                                        }
                                                                        if (num88 > Main.maxTilesX)
                                                                        {
                                                                            num88 = Main.maxTilesX;
                                                                        }
                                                                        if (num89 < 0)
                                                                        {
                                                                            num89 = 0;
                                                                        }
                                                                        if (num90 > Main.maxTilesY)
                                                                        {
                                                                            num90 = Main.maxTilesY;
                                                                        }
                                                                        for (int num91 = num87; num91 < num88; num91++)
                                                                        {
                                                                            for (int num92 = num89; num92 < num90; num92++)
                                                                            {
                                                                                if (Main.tile[num91, num92] != null && Main.tile[num91, num92].active && (Main.tileSolid[(int)Main.tile[num91, num92].type] || (Main.tileSolidTop[(int)Main.tile[num91, num92].type] && Main.tile[num91, num92].frameY == 0)))
                                                                                {
                                                                                    Vector2 vector11;
                                                                                    vector11.X = (float)(num91 * 16);
                                                                                    vector11.Y = (float)(num92 * 16);
                                                                                    if (this.position.X + (float)this.width > vector11.X && this.position.X < vector11.X + 16f && this.position.Y + (float)this.height > vector11.Y && this.position.Y < vector11.Y + 16f)
                                                                                    {
                                                                                        this.velocity.X = 0f;
                                                                                        this.velocity.Y = -0.2f;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    catch
                                                                    {
                                                                    }
                                                                }
                                                                this.ai[0] += 1f;
                                                                if (this.ai[0] > 5f)
                                                                {
                                                                    this.ai[0] = 5f;
                                                                    if (this.velocity.Y == 0f && this.velocity.X != 0f)
                                                                    {
                                                                        this.velocity.X = this.velocity.X * 0.97f;
                                                                        if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
                                                                        {
                                                                            this.velocity.X = 0f;
                                                                            this.netUpdate = true;
                                                                        }
                                                                    }
                                                                    this.velocity.Y = this.velocity.Y + 0.2f;
                                                                }
                                                                this.rotation += this.velocity.X * 0.1f;
                                                                if (this.velocity.Y > 16f)
                                                                {
                                                                    this.velocity.Y = 16f;
                                                                    return;
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.aiStyle == 15)
                                                                {
                                                                    if (this.type == 25)
                                                                    {
                                                                        if (Main.rand.Next(15) == 0)
                                                                        {
                                                                            Vector2 arg_3E55_0 = this.position;
                                                                            int arg_3E55_1 = this.width;
                                                                            int arg_3E55_2 = this.height;
                                                                            int arg_3E55_3 = 14;
                                                                            float arg_3E55_4 = 0f;
                                                                            float arg_3E55_5 = 0f;
                                                                            int arg_3E55_6 = 150;
                                                                            Color newColor = default(Color);
                                                                            Dust.NewDust(arg_3E55_0, arg_3E55_1, arg_3E55_2, arg_3E55_3, arg_3E55_4, arg_3E55_5, arg_3E55_6, newColor, 1.3f);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.type == 26)
                                                                        {
                                                                            Vector2 arg_3EB4_0 = this.position;
                                                                            int arg_3EB4_1 = this.width;
                                                                            int arg_3EB4_2 = this.height;
                                                                            int arg_3EB4_3 = 29;
                                                                            float arg_3EB4_4 = this.velocity.X * 0.4f;
                                                                            float arg_3EB4_5 = this.velocity.Y * 0.4f;
                                                                            int arg_3EB4_6 = 100;
                                                                            Color newColor = default(Color);
                                                                            int num93 = Dust.NewDust(arg_3EB4_0, arg_3EB4_1, arg_3EB4_2, arg_3EB4_3, arg_3EB4_4, arg_3EB4_5, arg_3EB4_6, newColor, 2.5f);
                                                                            Main.dust[num93].noGravity = true;
                                                                            Dust expr_3ED6_cp_0 = Main.dust[num93];
                                                                            expr_3ED6_cp_0.velocity.X = expr_3ED6_cp_0.velocity.X / 2f;
                                                                            Dust expr_3EF4_cp_0 = Main.dust[num93];
                                                                            expr_3EF4_cp_0.velocity.Y = expr_3EF4_cp_0.velocity.Y / 2f;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type == 35)
                                                                            {
                                                                                Vector2 arg_3F5D_0 = this.position;
                                                                                int arg_3F5D_1 = this.width;
                                                                                int arg_3F5D_2 = this.height;
                                                                                int arg_3F5D_3 = 6;
                                                                                float arg_3F5D_4 = this.velocity.X * 0.4f;
                                                                                float arg_3F5D_5 = this.velocity.Y * 0.4f;
                                                                                int arg_3F5D_6 = 100;
                                                                                Color newColor = default(Color);
                                                                                int num94 = Dust.NewDust(arg_3F5D_0, arg_3F5D_1, arg_3F5D_2, arg_3F5D_3, arg_3F5D_4, arg_3F5D_5, arg_3F5D_6, newColor, 3f);
                                                                                Main.dust[num94].noGravity = true;
                                                                                Dust expr_3F7F_cp_0 = Main.dust[num94];
                                                                                expr_3F7F_cp_0.velocity.X = expr_3F7F_cp_0.velocity.X * 2f;
                                                                                Dust expr_3F9D_cp_0 = Main.dust[num94];
                                                                                expr_3F9D_cp_0.velocity.Y = expr_3F9D_cp_0.velocity.Y * 2f;
                                                                            }
                                                                        }
                                                                    }
                                                                    if (Main.player[this.owner].dead)
                                                                    {
                                                                        this.Kill();
                                                                        return;
                                                                    }
                                                                    Main.player[this.owner].itemAnimation = 10;
                                                                    Main.player[this.owner].itemTime = 10;
                                                                    if (this.position.X + (float)(this.width / 2) > Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2))
                                                                    {
                                                                        Main.player[this.owner].direction = 1;
                                                                        this.direction = 1;
                                                                    }
                                                                    else
                                                                    {
                                                                        Main.player[this.owner].direction = -1;
                                                                        this.direction = -1;
                                                                    }
                                                                    Vector2 vector12 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                                    float num95 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector12.X;
                                                                    float num96 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector12.Y;
                                                                    float num97 = (float)Math.Sqrt((double)(num95 * num95 + num96 * num96));
                                                                    if (this.ai[0] == 0f)
                                                                    {
                                                                        float num98 = 160f;
                                                                        if (this.type == 63)
                                                                        {
                                                                            num98 *= 1.5f;
                                                                        }
                                                                        this.tileCollide = true;
                                                                        if (num97 > num98)
                                                                        {
                                                                            this.ai[0] = 1f;
                                                                            this.netUpdate = true;
                                                                        }
                                                                        else
                                                                        {
                                                                            if (!Main.player[this.owner].channel)
                                                                            {
                                                                                if (this.velocity.Y < 0f)
                                                                                {
                                                                                    this.velocity.Y = this.velocity.Y * 0.9f;
                                                                                }
                                                                                this.velocity.Y = this.velocity.Y + 1f;
                                                                                this.velocity.X = this.velocity.X * 0.9f;
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.ai[0] == 1f)
                                                                        {
                                                                            float num99 = 14f / Main.player[this.owner].meleeSpeed;
                                                                            float num100 = 0.9f / Main.player[this.owner].meleeSpeed;
                                                                            float num101 = 300f;
                                                                            if (this.type == 63)
                                                                            {
                                                                                num101 *= 1.5f;
                                                                                num99 *= 1.5f;
                                                                                num100 *= 1.5f;
                                                                            }
                                                                            Math.Abs(num95);
                                                                            Math.Abs(num96);
                                                                            if (this.ai[1] == 1f)
                                                                            {
                                                                                this.tileCollide = false;
                                                                            }
                                                                            if (!Main.player[this.owner].channel || num97 > num101 || !this.tileCollide)
                                                                            {
                                                                                this.ai[1] = 1f;
                                                                                if (this.tileCollide)
                                                                                {
                                                                                    this.netUpdate = true;
                                                                                }
                                                                                this.tileCollide = false;
                                                                                if (num97 < 20f)
                                                                                {
                                                                                    this.Kill();
                                                                                }
                                                                            }
                                                                            if (!this.tileCollide)
                                                                            {
                                                                                num100 *= 2f;
                                                                            }
                                                                            if (num97 > 60f || !this.tileCollide)
                                                                            {
                                                                                num97 = num99 / num97;
                                                                                num95 *= num97;
                                                                                num96 *= num97;
                                                                                new Vector2(this.velocity.X, this.velocity.Y);
                                                                                float num102 = num95 - this.velocity.X;
                                                                                float num103 = num96 - this.velocity.Y;
                                                                                float num104 = (float)Math.Sqrt((double)(num102 * num102 + num103 * num103));
                                                                                num104 = num100 / num104;
                                                                                num102 *= num104;
                                                                                num103 *= num104;
                                                                                this.velocity.X = this.velocity.X * 0.98f;
                                                                                this.velocity.Y = this.velocity.Y * 0.98f;
                                                                                this.velocity.X = this.velocity.X + num102;
                                                                                this.velocity.Y = this.velocity.Y + num103;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (Math.Abs(this.velocity.X) + Math.Abs(this.velocity.Y) < 6f)
                                                                                {
                                                                                    this.velocity.X = this.velocity.X * 0.96f;
                                                                                    this.velocity.Y = this.velocity.Y + 0.2f;
                                                                                }
                                                                                if (Main.player[this.owner].velocity.X == 0f)
                                                                                {
                                                                                    this.velocity.X = this.velocity.X * 0.96f;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    this.rotation = (float)Math.Atan2((double)num96, (double)num95) - this.velocity.X * 0.1f;
                                                                    return;
                                                                }
                                                                else
                                                                {
                                                                    if (this.aiStyle == 16)
                                                                    {
                                                                        if (this.type == 108)
                                                                        {
                                                                            this.ai[0] += 1f;
                                                                            if (this.ai[0] > 3f)
                                                                            {
                                                                                this.Kill();
                                                                            }
                                                                        }
                                                                        if (this.type == 37)
                                                                        {
                                                                            try
                                                                            {
                                                                                int num105 = (int)(this.position.X / 16f) - 1;
                                                                                int num106 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                                                                int num107 = (int)(this.position.Y / 16f) - 1;
                                                                                int num108 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                                                                if (num105 < 0)
                                                                                {
                                                                                    num105 = 0;
                                                                                }
                                                                                if (num106 > Main.maxTilesX)
                                                                                {
                                                                                    num106 = Main.maxTilesX;
                                                                                }
                                                                                if (num107 < 0)
                                                                                {
                                                                                    num107 = 0;
                                                                                }
                                                                                if (num108 > Main.maxTilesY)
                                                                                {
                                                                                    num108 = Main.maxTilesY;
                                                                                }
                                                                                for (int num109 = num105; num109 < num106; num109++)
                                                                                {
                                                                                    for (int num110 = num107; num110 < num108; num110++)
                                                                                    {
                                                                                        if (Main.tile[num109, num110] != null && Main.tile[num109, num110].active && (Main.tileSolid[(int)Main.tile[num109, num110].type] || (Main.tileSolidTop[(int)Main.tile[num109, num110].type] && Main.tile[num109, num110].frameY == 0)))
                                                                                        {
                                                                                            Vector2 vector13;
                                                                                            vector13.X = (float)(num109 * 16);
                                                                                            vector13.Y = (float)(num110 * 16);
                                                                                            if (this.position.X + (float)this.width - 4f > vector13.X && this.position.X + 4f < vector13.X + 16f && this.position.Y + (float)this.height - 4f > vector13.Y && this.position.Y + 4f < vector13.Y + 16f)
                                                                                            {
                                                                                                this.velocity.X = 0f;
                                                                                                this.velocity.Y = -0.2f;
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            catch
                                                                            {
                                                                            }
                                                                        }
                                                                        if (this.type == 102)
                                                                        {
                                                                            if (this.velocity.Y > 10f)
                                                                            {
                                                                                this.velocity.Y = 10f;
                                                                            }
                                                                            if (this.localAI[0] == 0f)
                                                                            {
                                                                                this.localAI[0] = 1f;
                                                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                            }
                                                                            this.frameCounter++;
                                                                            if (this.frameCounter > 3)
                                                                            {
                                                                                this.frame++;
                                                                                this.frameCounter = 0;
                                                                            }
                                                                            if (this.frame > 1)
                                                                            {
                                                                                this.frame = 0;
                                                                            }
                                                                            if (this.velocity.Y == 0f)
                                                                            {
                                                                                this.position.X = this.position.X + (float)(this.width / 2);
                                                                                this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                this.width = 128;
                                                                                this.height = 128;
                                                                                this.position.X = this.position.X - (float)(this.width / 2);
                                                                                this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                this.damage = 40;
                                                                                this.knockBack = 8f;
                                                                                this.timeLeft = 3;
                                                                                this.netUpdate = true;
                                                                            }
                                                                        }
                                                                        if (this.owner == Main.myPlayer && this.timeLeft <= 3)
                                                                        {
                                                                            this.ai[1] = 0f;
                                                                            this.alpha = 255;
                                                                            if (this.type == 28 || this.type == 37 || this.type == 75)
                                                                            {
                                                                                this.position.X = this.position.X + (float)(this.width / 2);
                                                                                this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                this.width = 128;
                                                                                this.height = 128;
                                                                                this.position.X = this.position.X - (float)(this.width / 2);
                                                                                this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                this.damage = 100;
                                                                                this.knockBack = 8f;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type == 29)
                                                                                {
                                                                                    this.position.X = this.position.X + (float)(this.width / 2);
                                                                                    this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                    this.width = 250;
                                                                                    this.height = 250;
                                                                                    this.position.X = this.position.X - (float)(this.width / 2);
                                                                                    this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                    this.damage = 250;
                                                                                    this.knockBack = 10f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.type == 30)
                                                                                    {
                                                                                        this.position.X = this.position.X + (float)(this.width / 2);
                                                                                        this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                        this.width = 128;
                                                                                        this.height = 128;
                                                                                        this.position.X = this.position.X - (float)(this.width / 2);
                                                                                        this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                        this.knockBack = 8f;
                                                                                    }
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type != 30 && this.type != 108)
                                                                            {
                                                                                this.damage = 0;
                                                                            }
                                                                            if (this.type != 30 && Main.rand.Next(4) == 0)
                                                                            {
                                                                                Vector2 arg_4ADF_0 = new Vector2(this.position.X, this.position.Y);
                                                                                int arg_4ADF_1 = this.width;
                                                                                int arg_4ADF_2 = this.height;
                                                                                int arg_4ADF_3 = 6;
                                                                                float arg_4ADF_4 = 0f;
                                                                                float arg_4ADF_5 = 0f;
                                                                                int arg_4ADF_6 = 100;
                                                                                Color newColor = default(Color);
                                                                                Dust.NewDust(arg_4ADF_0, arg_4ADF_1, arg_4ADF_2, arg_4ADF_3, arg_4ADF_4, arg_4ADF_5, arg_4ADF_6, newColor, 1f);
                                                                            }
                                                                        }
                                                                        this.ai[0] += 1f;
                                                                        if ((this.type == 30 && this.ai[0] > 10f) || (this.type != 30 && this.ai[0] > 5f))
                                                                        {
                                                                            this.ai[0] = 10f;
                                                                            if (this.velocity.Y == 0f && this.velocity.X != 0f)
                                                                            {
                                                                                this.velocity.X = this.velocity.X * 0.97f;
                                                                                if (this.type == 29)
                                                                                {
                                                                                    this.velocity.X = this.velocity.X * 0.99f;
                                                                                }
                                                                                if ((double)this.velocity.X > -0.01 && (double)this.velocity.X < 0.01)
                                                                                {
                                                                                    this.velocity.X = 0f;
                                                                                    this.netUpdate = true;
                                                                                }
                                                                            }
                                                                            this.velocity.Y = this.velocity.Y + 0.2f;
                                                                        }
                                                                        this.rotation += this.velocity.X * 0.1f;
                                                                        return;
                                                                    }
                                                                    if (this.aiStyle == 17)
                                                                    {
                                                                        if (this.velocity.Y == 0f)
                                                                        {
                                                                            this.velocity.X = this.velocity.X * 0.98f;
                                                                        }
                                                                        this.rotation += this.velocity.X * 0.1f;
                                                                        this.velocity.Y = this.velocity.Y + 0.2f;
                                                                        if (this.owner == Main.myPlayer)
                                                                        {
                                                                            int num111 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
                                                                            int num112 = (int)((this.position.Y + (float)this.height - 4f) / 16f);
                                                                            if (Main.tile[num111, num112] != null && !Main.tile[num111, num112].active)
                                                                            {
                                                                                WorldGen.PlaceTile(num111, num112, 85, false, false, -1, 0);
                                                                                if (Main.tile[num111, num112].active)
                                                                                {
                                                                                    if (Main.netMode != 0)
                                                                                    {
                                                                                        NetMessage.SendData(17, -1, -1, "", 1, (float)num111, (float)num112, 85f, 0);
                                                                                    }
                                                                                    int num113 = Sign.ReadSign(num111, num112);
                                                                                    if (num113 >= 0)
                                                                                    {
                                                                                        Sign.TextSign(num113, this.miscText);
                                                                                    }
                                                                                    this.Kill();
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.aiStyle == 18)
                                                                        {
                                                                            if (this.ai[1] == 0f && this.type == 44)
                                                                            {
                                                                                this.ai[1] = 1f;
                                                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 8);
                                                                            }
                                                                            this.rotation += (float)this.direction * 0.8f;
                                                                            this.ai[0] += 1f;
                                                                            if (this.ai[0] >= 30f)
                                                                            {
                                                                                if (this.ai[0] < 100f)
                                                                                {
                                                                                    this.velocity *= 1.06f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    this.ai[0] = 200f;
                                                                                }
                                                                            }
                                                                            for (int num114 = 0; num114 < 2; num114++)
                                                                            {
                                                                                Vector2 arg_4E8A_0 = new Vector2(this.position.X, this.position.Y);
                                                                                int arg_4E8A_1 = this.width;
                                                                                int arg_4E8A_2 = this.height;
                                                                                int arg_4E8A_3 = 27;
                                                                                float arg_4E8A_4 = 0f;
                                                                                float arg_4E8A_5 = 0f;
                                                                                int arg_4E8A_6 = 100;
                                                                                Color newColor = default(Color);
                                                                                int num115 = Dust.NewDust(arg_4E8A_0, arg_4E8A_1, arg_4E8A_2, arg_4E8A_3, arg_4E8A_4, arg_4E8A_5, arg_4E8A_6, newColor, 1f);
                                                                                Main.dust[num115].noGravity = true;
                                                                            }
                                                                            return;
                                                                        }
                                                                        if (this.aiStyle == 19)
                                                                        {
                                                                            this.direction = Main.player[this.owner].direction;
                                                                            Main.player[this.owner].heldProj = this.whoAmI;
                                                                            Main.player[this.owner].itemTime = Main.player[this.owner].itemAnimation;
                                                                            this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                                                                            this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                                                                            if (this.type == 46)
                                                                            {
                                                                                if (this.ai[0] == 0f)
                                                                                {
                                                                                    this.ai[0] = 3f;
                                                                                    this.netUpdate = true;
                                                                                }
                                                                                if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                {
                                                                                    this.ai[0] -= 1.6f;
                                                                                }
                                                                                else
                                                                                {
                                                                                    this.ai[0] += 1.4f;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type == 105)
                                                                                {
                                                                                    if (this.ai[0] == 0f)
                                                                                    {
                                                                                        this.ai[0] = 3f;
                                                                                        this.netUpdate = true;
                                                                                    }
                                                                                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                    {
                                                                                        this.ai[0] -= 2.4f;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        this.ai[0] += 2.1f;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.type == 47)
                                                                                    {
                                                                                        if (this.ai[0] == 0f)
                                                                                        {
                                                                                            this.ai[0] = 4f;
                                                                                            this.netUpdate = true;
                                                                                        }
                                                                                        if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                        {
                                                                                            this.ai[0] -= 1.2f;
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            this.ai[0] += 0.9f;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.type == 49)
                                                                                        {
                                                                                            if (this.ai[0] == 0f)
                                                                                            {
                                                                                                this.ai[0] = 4f;
                                                                                                this.netUpdate = true;
                                                                                            }
                                                                                            if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                            {
                                                                                                this.ai[0] -= 1.1f;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.ai[0] += 0.85f;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.type == 64)
                                                                                            {
                                                                                                this.spriteDirection = -this.direction;
                                                                                                if (this.ai[0] == 0f)
                                                                                                {
                                                                                                    this.ai[0] = 3f;
                                                                                                    this.netUpdate = true;
                                                                                                }
                                                                                                if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                                {
                                                                                                    this.ai[0] -= 1.9f;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    this.ai[0] += 1.7f;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (this.type == 66 || this.type == 97)
                                                                                                {
                                                                                                    this.spriteDirection = -this.direction;
                                                                                                    if (this.ai[0] == 0f)
                                                                                                    {
                                                                                                        this.ai[0] = 3f;
                                                                                                        this.netUpdate = true;
                                                                                                    }
                                                                                                    if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                                    {
                                                                                                        this.ai[0] -= 2.1f;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.ai[0] += 1.9f;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.type == 97)
                                                                                                    {
                                                                                                        this.spriteDirection = -this.direction;
                                                                                                        if (this.ai[0] == 0f)
                                                                                                        {
                                                                                                            this.ai[0] = 3f;
                                                                                                            this.netUpdate = true;
                                                                                                        }
                                                                                                        if (Main.player[this.owner].itemAnimation < Main.player[this.owner].itemAnimationMax / 3)
                                                                                                        {
                                                                                                            this.ai[0] -= 1.6f;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            this.ai[0] += 1.4f;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                }
                                                                            }
                                                                            this.position += this.velocity * this.ai[0];
                                                                            if (Main.player[this.owner].itemAnimation == 0)
                                                                            {
                                                                                this.Kill();
                                                                            }
                                                                            this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 2.355f;
                                                                            if (this.spriteDirection == -1)
                                                                            {
                                                                                this.rotation -= 1.57f;
                                                                            }
                                                                            if (this.type == 46)
                                                                            {
                                                                                Color newColor;
                                                                                if (Main.rand.Next(5) == 0)
                                                                                {
                                                                                    Vector2 arg_54B5_0 = this.position;
                                                                                    int arg_54B5_1 = this.width;
                                                                                    int arg_54B5_2 = this.height;
                                                                                    int arg_54B5_3 = 14;
                                                                                    float arg_54B5_4 = 0f;
                                                                                    float arg_54B5_5 = 0f;
                                                                                    int arg_54B5_6 = 150;
                                                                                    newColor = default(Color);
                                                                                    Dust.NewDust(arg_54B5_0, arg_54B5_1, arg_54B5_2, arg_54B5_3, arg_54B5_4, arg_54B5_5, arg_54B5_6, newColor, 1.4f);
                                                                                }
                                                                                Vector2 arg_550C_0 = this.position;
                                                                                int arg_550C_1 = this.width;
                                                                                int arg_550C_2 = this.height;
                                                                                int arg_550C_3 = 27;
                                                                                float arg_550C_4 = this.velocity.X * 0.2f + (float)(this.direction * 3);
                                                                                float arg_550C_5 = this.velocity.Y * 0.2f;
                                                                                int arg_550C_6 = 100;
                                                                                newColor = default(Color);
                                                                                int num116 = Dust.NewDust(arg_550C_0, arg_550C_1, arg_550C_2, arg_550C_3, arg_550C_4, arg_550C_5, arg_550C_6, newColor, 1.2f);
                                                                                Main.dust[num116].noGravity = true;
                                                                                Dust expr_552E_cp_0 = Main.dust[num116];
                                                                                expr_552E_cp_0.velocity.X = expr_552E_cp_0.velocity.X / 2f;
                                                                                Dust expr_554C_cp_0 = Main.dust[num116];
                                                                                expr_554C_cp_0.velocity.Y = expr_554C_cp_0.velocity.Y / 2f;
                                                                                Vector2 arg_55A4_0 = this.position - this.velocity * 2f;
                                                                                int arg_55A4_1 = this.width;
                                                                                int arg_55A4_2 = this.height;
                                                                                int arg_55A4_3 = 27;
                                                                                float arg_55A4_4 = 0f;
                                                                                float arg_55A4_5 = 0f;
                                                                                int arg_55A4_6 = 150;
                                                                                newColor = default(Color);
                                                                                num116 = Dust.NewDust(arg_55A4_0, arg_55A4_1, arg_55A4_2, arg_55A4_3, arg_55A4_4, arg_55A4_5, arg_55A4_6, newColor, 1.4f);
                                                                                Dust expr_55B8_cp_0 = Main.dust[num116];
                                                                                expr_55B8_cp_0.velocity.X = expr_55B8_cp_0.velocity.X / 5f;
                                                                                Dust expr_55D6_cp_0 = Main.dust[num116];
                                                                                expr_55D6_cp_0.velocity.Y = expr_55D6_cp_0.velocity.Y / 5f;
                                                                                return;
                                                                            }
                                                                            if (this.type == 105)
                                                                            {
                                                                                if (Main.rand.Next(3) == 0)
                                                                                {
                                                                                    Vector2 arg_5664_0 = new Vector2(this.position.X, this.position.Y);
                                                                                    int arg_5664_1 = this.width;
                                                                                    int arg_5664_2 = this.height;
                                                                                    int arg_5664_3 = 57;
                                                                                    float arg_5664_4 = this.velocity.X * 0.2f;
                                                                                    float arg_5664_5 = this.velocity.Y * 0.2f;
                                                                                    int arg_5664_6 = 200;
                                                                                    Color newColor = default(Color);
                                                                                    int num117 = Dust.NewDust(arg_5664_0, arg_5664_1, arg_5664_2, arg_5664_3, arg_5664_4, arg_5664_5, arg_5664_6, newColor, 1.2f);
                                                                                    Dust expr_5673 = Main.dust[num117];
                                                                                    expr_5673.velocity += this.velocity * 0.3f;
                                                                                    Dust expr_569B = Main.dust[num117];
                                                                                    expr_569B.velocity *= 0.2f;
                                                                                }
                                                                                if (Main.rand.Next(4) == 0)
                                                                                {
                                                                                    Vector2 arg_5707_0 = new Vector2(this.position.X, this.position.Y);
                                                                                    int arg_5707_1 = this.width;
                                                                                    int arg_5707_2 = this.height;
                                                                                    int arg_5707_3 = 43;
                                                                                    float arg_5707_4 = 0f;
                                                                                    float arg_5707_5 = 0f;
                                                                                    int arg_5707_6 = 254;
                                                                                    Color newColor = default(Color);
                                                                                    int num118 = Dust.NewDust(arg_5707_0, arg_5707_1, arg_5707_2, arg_5707_3, arg_5707_4, arg_5707_5, arg_5707_6, newColor, 0.3f);
                                                                                    Dust expr_5716 = Main.dust[num118];
                                                                                    expr_5716.velocity += this.velocity * 0.5f;
                                                                                    Dust expr_573E = Main.dust[num118];
                                                                                    expr_573E.velocity *= 0.5f;
                                                                                    return;
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.aiStyle == 20)
                                                                            {
                                                                                if (this.soundDelay <= 0)
                                                                                {
                                                                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 22);
                                                                                    this.soundDelay = 30;
                                                                                }
                                                                                if (Main.myPlayer == this.owner)
                                                                                {
                                                                                    if (Main.player[this.owner].channel)
                                                                                    {
                                                                                        float num119 = Main.player[this.owner].inventory[Main.player[this.owner].selectedItem].shootSpeed * this.scale;
                                                                                        Vector2 vector14 = new Vector2(Main.player[this.owner].position.X + (float)Main.player[this.owner].width * 0.5f, Main.player[this.owner].position.Y + (float)Main.player[this.owner].height * 0.5f);
                                                                                        float num120 = (float)Main.mouseX + Main.screenPosition.X - vector14.X;
                                                                                        float num121 = (float)Main.mouseY + Main.screenPosition.Y - vector14.Y;
                                                                                        float num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
                                                                                        num122 = (float)Math.Sqrt((double)(num120 * num120 + num121 * num121));
                                                                                        num122 = num119 / num122;
                                                                                        num120 *= num122;
                                                                                        num121 *= num122;
                                                                                        if (num120 != this.velocity.X || num121 != this.velocity.Y)
                                                                                        {
                                                                                            this.netUpdate = true;
                                                                                        }
                                                                                        this.velocity.X = num120;
                                                                                        this.velocity.Y = num121;
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        this.Kill();
                                                                                    }
                                                                                }
                                                                                if (this.velocity.X > 0f)
                                                                                {
                                                                                    Main.player[this.owner].direction = 1;
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.velocity.X < 0f)
                                                                                    {
                                                                                        Main.player[this.owner].direction = -1;
                                                                                    }
                                                                                }
                                                                                this.spriteDirection = this.direction;
                                                                                Main.player[this.owner].direction = this.direction;
                                                                                Main.player[this.owner].heldProj = this.whoAmI;
                                                                                Main.player[this.owner].itemTime = 2;
                                                                                Main.player[this.owner].itemAnimation = 2;
                                                                                this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                                                                                this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                                                                                this.rotation = (float)(Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 1.5700000524520874);
                                                                                if (Main.player[this.owner].direction == 1)
                                                                                {
                                                                                    Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
                                                                                }
                                                                                else
                                                                                {
                                                                                    Main.player[this.owner].itemRotation = (float)Math.Atan2((double)(this.velocity.Y * (float)this.direction), (double)(this.velocity.X * (float)this.direction));
                                                                                }
                                                                                this.velocity.X = this.velocity.X * (1f + (float)Main.rand.Next(-3, 4) * 0.01f);
                                                                                if (Main.rand.Next(6) == 0)
                                                                                {
                                                                                    Vector2 arg_5B85_0 = this.position + this.velocity * (float)Main.rand.Next(6, 10) * 0.1f;
                                                                                    int arg_5B85_1 = this.width;
                                                                                    int arg_5B85_2 = this.height;
                                                                                    int arg_5B85_3 = 31;
                                                                                    float arg_5B85_4 = 0f;
                                                                                    float arg_5B85_5 = 0f;
                                                                                    int arg_5B85_6 = 80;
                                                                                    Color newColor = default(Color);
                                                                                    int num123 = Dust.NewDust(arg_5B85_0, arg_5B85_1, arg_5B85_2, arg_5B85_3, arg_5B85_4, arg_5B85_5, arg_5B85_6, newColor, 1.4f);
                                                                                    Dust expr_5B99_cp_0 = Main.dust[num123];
                                                                                    expr_5B99_cp_0.position.X = expr_5B99_cp_0.position.X - 4f;
                                                                                    Main.dust[num123].noGravity = true;
                                                                                    Dust expr_5BC0 = Main.dust[num123];
                                                                                    expr_5BC0.velocity *= 0.2f;
                                                                                    Main.dust[num123].velocity.Y = (float)(-(float)Main.rand.Next(7, 13)) * 0.15f;
                                                                                    return;
                                                                                }
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.aiStyle == 21)
                                                                                {
                                                                                    this.rotation = this.velocity.X * 0.1f;
                                                                                    this.spriteDirection = -this.direction;
                                                                                    if (Main.rand.Next(3) == 0)
                                                                                    {
                                                                                        Vector2 arg_5C6A_0 = this.position;
                                                                                        int arg_5C6A_1 = this.width;
                                                                                        int arg_5C6A_2 = this.height;
                                                                                        int arg_5C6A_3 = 27;
                                                                                        float arg_5C6A_4 = 0f;
                                                                                        float arg_5C6A_5 = 0f;
                                                                                        int arg_5C6A_6 = 80;
                                                                                        Color newColor = default(Color);
                                                                                        int num124 = Dust.NewDust(arg_5C6A_0, arg_5C6A_1, arg_5C6A_2, arg_5C6A_3, arg_5C6A_4, arg_5C6A_5, arg_5C6A_6, newColor, 1f);
                                                                                        Main.dust[num124].noGravity = true;
                                                                                        Dust expr_5C87 = Main.dust[num124];
                                                                                        expr_5C87.velocity *= 0.2f;
                                                                                    }
                                                                                    if (this.ai[1] == 1f)
                                                                                    {
                                                                                        this.ai[1] = 0f;
                                                                                        Main.harpNote = this.ai[0];
                                                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 26);
                                                                                        return;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.aiStyle == 22)
                                                                                    {
                                                                                        if (this.velocity.X == 0f && this.velocity.Y == 0f)
                                                                                        {
                                                                                            this.alpha = 255;
                                                                                        }
                                                                                        if (this.ai[1] < 0f)
                                                                                        {
                                                                                            if (this.velocity.X > 0f)
                                                                                            {
                                                                                                this.rotation += 0.3f;
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.rotation -= 0.3f;
                                                                                            }
                                                                                            int num125 = (int)(this.position.X / 16f) - 1;
                                                                                            int num126 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                                                                            int num127 = (int)(this.position.Y / 16f) - 1;
                                                                                            int num128 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                                                                            if (num125 < 0)
                                                                                            {
                                                                                                num125 = 0;
                                                                                            }
                                                                                            if (num126 > Main.maxTilesX)
                                                                                            {
                                                                                                num126 = Main.maxTilesX;
                                                                                            }
                                                                                            if (num127 < 0)
                                                                                            {
                                                                                                num127 = 0;
                                                                                            }
                                                                                            if (num128 > Main.maxTilesY)
                                                                                            {
                                                                                                num128 = Main.maxTilesY;
                                                                                            }
                                                                                            int num129 = (int)this.position.X + 4;
                                                                                            int num130 = (int)this.position.Y + 4;
                                                                                            for (int num131 = num125; num131 < num126; num131++)
                                                                                            {
                                                                                                for (int num132 = num127; num132 < num128; num132++)
                                                                                                {
                                                                                                    if (Main.tile[num131, num132] != null && Main.tile[num131, num132].active && Main.tile[num131, num132].type != 127 && Main.tileSolid[(int)Main.tile[num131, num132].type] && !Main.tileSolidTop[(int)Main.tile[num131, num132].type])
                                                                                                    {
                                                                                                        Vector2 vector15;
                                                                                                        vector15.X = (float)(num131 * 16);
                                                                                                        vector15.Y = (float)(num132 * 16);
                                                                                                        if ((float)(num129 + 8) > vector15.X && (float)num129 < vector15.X + 16f && (float)(num130 + 8) > vector15.Y && (float)num130 < vector15.Y + 16f)
                                                                                                        {
                                                                                                            this.Kill();
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            Vector2 arg_5F75_0 = new Vector2(this.position.X, this.position.Y);
                                                                                            int arg_5F75_1 = this.width;
                                                                                            int arg_5F75_2 = this.height;
                                                                                            int arg_5F75_3 = 67;
                                                                                            float arg_5F75_4 = 0f;
                                                                                            float arg_5F75_5 = 0f;
                                                                                            int arg_5F75_6 = 0;
                                                                                            Color newColor = default(Color);
                                                                                            int num133 = Dust.NewDust(arg_5F75_0, arg_5F75_1, arg_5F75_2, arg_5F75_3, arg_5F75_4, arg_5F75_5, arg_5F75_6, newColor, 1f);
                                                                                            Main.dust[num133].noGravity = true;
                                                                                            Dust expr_5F92 = Main.dust[num133];
                                                                                            expr_5F92.velocity *= 0.3f;
                                                                                            return;
                                                                                        }
                                                                                        if (this.ai[0] < 0f)
                                                                                        {
                                                                                            if (this.ai[0] == -1f)
                                                                                            {
                                                                                                for (int num134 = 0; num134 < 10; num134++)
                                                                                                {
                                                                                                    Vector2 arg_6014_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                    int arg_6014_1 = this.width;
                                                                                                    int arg_6014_2 = this.height;
                                                                                                    int arg_6014_3 = 67;
                                                                                                    float arg_6014_4 = 0f;
                                                                                                    float arg_6014_5 = 0f;
                                                                                                    int arg_6014_6 = 0;
                                                                                                    Color newColor = default(Color);
                                                                                                    int num135 = Dust.NewDust(arg_6014_0, arg_6014_1, arg_6014_2, arg_6014_3, arg_6014_4, arg_6014_5, arg_6014_6, newColor, 1.1f);
                                                                                                    Main.dust[num135].noGravity = true;
                                                                                                    Dust expr_6031 = Main.dust[num135];
                                                                                                    expr_6031.velocity *= 1.3f;
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (Main.rand.Next(30) == 0)
                                                                                                {
                                                                                                    Vector2 arg_60A9_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                    int arg_60A9_1 = this.width;
                                                                                                    int arg_60A9_2 = this.height;
                                                                                                    int arg_60A9_3 = 67;
                                                                                                    float arg_60A9_4 = 0f;
                                                                                                    float arg_60A9_5 = 0f;
                                                                                                    int arg_60A9_6 = 100;
                                                                                                    Color newColor = default(Color);
                                                                                                    int num136 = Dust.NewDust(arg_60A9_0, arg_60A9_1, arg_60A9_2, arg_60A9_3, arg_60A9_4, arg_60A9_5, arg_60A9_6, newColor, 1f);
                                                                                                    Dust expr_60B8 = Main.dust[num136];
                                                                                                    expr_60B8.velocity *= 0.2f;
                                                                                                }
                                                                                            }
                                                                                            int num137 = (int)this.position.X / 16;
                                                                                            int num138 = (int)this.position.Y / 16;
                                                                                            if (Main.tile[num137, num138] == null || !Main.tile[num137, num138].active)
                                                                                            {
                                                                                                this.Kill();
                                                                                            }
                                                                                            this.ai[0] -= 1f;
                                                                                            if (this.ai[0] <= -300f && (Main.myPlayer == this.owner || Main.netMode == 2) && Main.tile[num137, num138].active && Main.tile[num137, num138].type == 127)
                                                                                            {
                                                                                                WorldGen.KillTile(num137, num138, false, false, false);
                                                                                                if (Main.netMode == 1)
                                                                                                {
                                                                                                    NetMessage.SendData(17, -1, -1, "", 0, (float)num137, (float)num138, 0f, 0);
                                                                                                }
                                                                                                this.Kill();
                                                                                                return;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            int num139 = (int)(this.position.X / 16f) - 1;
                                                                                            int num140 = (int)((this.position.X + (float)this.width) / 16f) + 2;
                                                                                            int num141 = (int)(this.position.Y / 16f) - 1;
                                                                                            int num142 = (int)((this.position.Y + (float)this.height) / 16f) + 2;
                                                                                            if (num139 < 0)
                                                                                            {
                                                                                                num139 = 0;
                                                                                            }
                                                                                            if (num140 > Main.maxTilesX)
                                                                                            {
                                                                                                num140 = Main.maxTilesX;
                                                                                            }
                                                                                            if (num141 < 0)
                                                                                            {
                                                                                                num141 = 0;
                                                                                            }
                                                                                            if (num142 > Main.maxTilesY)
                                                                                            {
                                                                                                num142 = Main.maxTilesY;
                                                                                            }
                                                                                            int num143 = (int)this.position.X + 4;
                                                                                            int num144 = (int)this.position.Y + 4;
                                                                                            for (int num145 = num139; num145 < num140; num145++)
                                                                                            {
                                                                                                for (int num146 = num141; num146 < num142; num146++)
                                                                                                {
                                                                                                    if (Main.tile[num145, num146] != null && Main.tile[num145, num146].active && Main.tile[num145, num146].type != 127 && Main.tileSolid[(int)Main.tile[num145, num146].type] && !Main.tileSolidTop[(int)Main.tile[num145, num146].type])
                                                                                                    {
                                                                                                        Vector2 vector16;
                                                                                                        vector16.X = (float)(num145 * 16);
                                                                                                        vector16.Y = (float)(num146 * 16);
                                                                                                        if ((float)(num143 + 8) > vector16.X && (float)num143 < vector16.X + 16f && (float)(num144 + 8) > vector16.Y && (float)num144 < vector16.Y + 16f)
                                                                                                        {
                                                                                                            this.Kill();
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            if (this.lavaWet)
                                                                                            {
                                                                                                this.Kill();
                                                                                            }
                                                                                            if (this.active)
                                                                                            {
                                                                                                Vector2 arg_63E8_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                int arg_63E8_1 = this.width;
                                                                                                int arg_63E8_2 = this.height;
                                                                                                int arg_63E8_3 = 67;
                                                                                                float arg_63E8_4 = 0f;
                                                                                                float arg_63E8_5 = 0f;
                                                                                                int arg_63E8_6 = 0;
                                                                                                Color newColor = default(Color);
                                                                                                int num147 = Dust.NewDust(arg_63E8_0, arg_63E8_1, arg_63E8_2, arg_63E8_3, arg_63E8_4, arg_63E8_5, arg_63E8_6, newColor, 1f);
                                                                                                Main.dust[num147].noGravity = true;
                                                                                                Dust expr_6405 = Main.dust[num147];
                                                                                                expr_6405.velocity *= 0.3f;
                                                                                                int num148 = (int)this.ai[0];
                                                                                                int num149 = (int)this.ai[1];
                                                                                                if (this.velocity.X > 0f)
                                                                                                {
                                                                                                    this.rotation += 0.3f;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    this.rotation -= 0.3f;
                                                                                                }
                                                                                                if (Main.myPlayer == this.owner)
                                                                                                {
                                                                                                    int num150 = (int)((this.position.X + (float)(this.width / 2)) / 16f);
                                                                                                    int num151 = (int)((this.position.Y + (float)(this.height / 2)) / 16f);
                                                                                                    bool flag2 = false;
                                                                                                    if (num150 == num148 && num151 == num149)
                                                                                                    {
                                                                                                        flag2 = true;
                                                                                                    }
                                                                                                    if (((this.velocity.X <= 0f && num150 <= num148) || (this.velocity.X >= 0f && num150 >= num148)) && ((this.velocity.Y <= 0f && num151 <= num149) || (this.velocity.Y >= 0f && num151 >= num149)))
                                                                                                    {
                                                                                                        flag2 = true;
                                                                                                    }
                                                                                                    if (flag2)
                                                                                                    {
                                                                                                        if (WorldGen.PlaceTile(num148, num149, 127, false, false, this.owner, 0))
                                                                                                        {
                                                                                                            if (Main.netMode == 1)
                                                                                                            {
                                                                                                                NetMessage.SendData(17, -1, -1, "", 1, (float)((int)this.ai[0]), (float)((int)this.ai[1]), 127f, 0);
                                                                                                            }
                                                                                                            this.damage = 0;
                                                                                                            this.ai[0] = -1f;
                                                                                                            this.velocity *= 0f;
                                                                                                            this.alpha = 255;
                                                                                                            this.position.X = (float)(num148 * 16);
                                                                                                            this.position.Y = (float)(num149 * 16);
                                                                                                            this.netUpdate = true;
                                                                                                            return;
                                                                                                        }
                                                                                                        this.ai[1] = -1f;
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.aiStyle == 23)
                                                                                        {
                                                                                            if (this.timeLeft > 60)
                                                                                            {
                                                                                                this.timeLeft = 60;
                                                                                            }
                                                                                            if (this.ai[0] > 7f)
                                                                                            {
                                                                                                float num152 = 1f;
                                                                                                if (this.ai[0] == 8f)
                                                                                                {
                                                                                                    num152 = 0.25f;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.ai[0] == 9f)
                                                                                                    {
                                                                                                        num152 = 0.5f;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.ai[0] == 10f)
                                                                                                        {
                                                                                                            num152 = 0.75f;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                this.ai[0] += 1f;
                                                                                                int num153 = 6;
                                                                                                if (this.type == 101)
                                                                                                {
                                                                                                    num153 = 75;
                                                                                                }
                                                                                                if (num153 == 6 || Main.rand.Next(2) == 0)
                                                                                                {
                                                                                                    for (int num154 = 0; num154 < 1; num154++)
                                                                                                    {
                                                                                                        Vector2 arg_670C_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                        int arg_670C_1 = this.width;
                                                                                                        int arg_670C_2 = this.height;
                                                                                                        int arg_670C_3 = num153;
                                                                                                        float arg_670C_4 = this.velocity.X * 0.2f;
                                                                                                        float arg_670C_5 = this.velocity.Y * 0.2f;
                                                                                                        int arg_670C_6 = 100;
                                                                                                        Color newColor = default(Color);
                                                                                                        int num155 = Dust.NewDust(arg_670C_0, arg_670C_1, arg_670C_2, arg_670C_3, arg_670C_4, arg_670C_5, arg_670C_6, newColor, 1f);
                                                                                                        if (Main.rand.Next(3) != 0 || (num153 == 75 && Main.rand.Next(3) == 0))
                                                                                                        {
                                                                                                            Main.dust[num155].noGravity = true;
                                                                                                            Main.dust[num155].scale *= 3f;
                                                                                                            Dust expr_6767_cp_0 = Main.dust[num155];
                                                                                                            expr_6767_cp_0.velocity.X = expr_6767_cp_0.velocity.X * 2f;
                                                                                                            Dust expr_6785_cp_0 = Main.dust[num155];
                                                                                                            expr_6785_cp_0.velocity.Y = expr_6785_cp_0.velocity.Y * 2f;
                                                                                                        }
                                                                                                        Main.dust[num155].scale *= 1.5f;
                                                                                                        Dust expr_67BC_cp_0 = Main.dust[num155];
                                                                                                        expr_67BC_cp_0.velocity.X = expr_67BC_cp_0.velocity.X * 1.2f;
                                                                                                        Dust expr_67DA_cp_0 = Main.dust[num155];
                                                                                                        expr_67DA_cp_0.velocity.Y = expr_67DA_cp_0.velocity.Y * 1.2f;
                                                                                                        Main.dust[num155].scale *= num152;
                                                                                                        if (num153 == 75)
                                                                                                        {
                                                                                                            Dust expr_680F = Main.dust[num155];
                                                                                                            expr_680F.velocity += this.velocity;
                                                                                                            if (!Main.dust[num155].noGravity)
                                                                                                            {
                                                                                                                Dust expr_683C = Main.dust[num155];
                                                                                                                expr_683C.velocity *= 0.5f;
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.ai[0] += 1f;
                                                                                            }
                                                                                            this.rotation += 0.3f * (float)this.direction;
                                                                                            return;
                                                                                        }
                                                                                        if (this.aiStyle == 24)
                                                                                        {
                                                                                            this.light = this.scale * 0.5f;
                                                                                            this.rotation += this.velocity.X * 0.2f;
                                                                                            this.ai[1] += 1f;
                                                                                            if (this.type == 94)
                                                                                            {
                                                                                                if (Main.rand.Next(4) == 0)
                                                                                                {
                                                                                                    Vector2 arg_6953_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                    int arg_6953_1 = this.width;
                                                                                                    int arg_6953_2 = this.height;
                                                                                                    int arg_6953_3 = 70;
                                                                                                    float arg_6953_4 = 0f;
                                                                                                    float arg_6953_5 = 0f;
                                                                                                    int arg_6953_6 = 0;
                                                                                                    Color newColor = default(Color);
                                                                                                    int num156 = Dust.NewDust(arg_6953_0, arg_6953_1, arg_6953_2, arg_6953_3, arg_6953_4, arg_6953_5, arg_6953_6, newColor, 1f);
                                                                                                    Main.dust[num156].noGravity = true;
                                                                                                    Dust expr_6970 = Main.dust[num156];
                                                                                                    expr_6970.velocity *= 0.5f;
                                                                                                    Main.dust[num156].scale *= 0.9f;
                                                                                                }
                                                                                                this.velocity *= 0.985f;
                                                                                                if (this.ai[1] > 130f)
                                                                                                {
                                                                                                    this.scale -= 0.05f;
                                                                                                    if ((double)this.scale <= 0.2)
                                                                                                    {
                                                                                                        this.scale = 0.2f;
                                                                                                        this.Kill();
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                this.velocity *= 0.96f;
                                                                                                if (this.ai[1] > 15f)
                                                                                                {
                                                                                                    this.scale -= 0.05f;
                                                                                                    if ((double)this.scale <= 0.2)
                                                                                                    {
                                                                                                        this.scale = 0.2f;
                                                                                                        this.Kill();
                                                                                                        return;
                                                                                                    }
                                                                                                }
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.aiStyle == 25)
                                                                                            {
                                                                                                if (this.ai[0] != 0f && this.velocity.Y <= 0f && this.velocity.X == 0f)
                                                                                                {
                                                                                                    float num157 = 0.5f;
                                                                                                    int i2 = (int)((this.position.X - 8f) / 16f);
                                                                                                    int num158 = (int)(this.position.Y / 16f);
                                                                                                    bool flag3 = false;
                                                                                                    bool flag4 = false;
                                                                                                    if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
                                                                                                    {
                                                                                                        flag3 = true;
                                                                                                    }
                                                                                                    i2 = (int)((this.position.X + (float)this.width + 8f) / 16f);
                                                                                                    if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
                                                                                                    {
                                                                                                        flag4 = true;
                                                                                                    }
                                                                                                    if (flag3)
                                                                                                    {
                                                                                                        this.velocity.X = num157;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (flag4)
                                                                                                        {
                                                                                                            this.velocity.X = -num157;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            i2 = (int)((this.position.X - 8f - 16f) / 16f);
                                                                                                            num158 = (int)(this.position.Y / 16f);
                                                                                                            flag3 = false;
                                                                                                            flag4 = false;
                                                                                                            if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
                                                                                                            {
                                                                                                                flag3 = true;
                                                                                                            }
                                                                                                            i2 = (int)((this.position.X + (float)this.width + 8f + 16f) / 16f);
                                                                                                            if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
                                                                                                            {
                                                                                                                flag4 = true;
                                                                                                            }
                                                                                                            if (flag3)
                                                                                                            {
                                                                                                                this.velocity.X = num157;
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (flag4)
                                                                                                                {
                                                                                                                    this.velocity.X = -num157;
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    i2 = (int)((this.position.X + 4f) / 16f);
                                                                                                                    num158 = (int)((this.position.Y + (float)this.height + 8f) / 16f);
                                                                                                                    if (WorldGen.SolidTile(i2, num158) || WorldGen.SolidTile(i2, num158 + 1))
                                                                                                                    {
                                                                                                                        flag3 = true;
                                                                                                                    }
                                                                                                                    if (!flag3)
                                                                                                                    {
                                                                                                                        this.velocity.X = num157;
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        this.velocity.X = -num157;
                                                                                                                    }
                                                                                                                }
                                                                                                            }
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                this.rotation += this.velocity.X * 0.06f;
                                                                                                this.ai[0] = 1f;
                                                                                                if (this.velocity.Y > 16f)
                                                                                                {
                                                                                                    this.velocity.Y = 16f;
                                                                                                }
                                                                                                if (this.velocity.Y <= 6f)
                                                                                                {
                                                                                                    if (this.velocity.X > 0f && this.velocity.X < 7f)
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X + 0.05f;
                                                                                                    }
                                                                                                    if (this.velocity.X < 0f && this.velocity.X > -7f)
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X - 0.05f;
                                                                                                    }
                                                                                                }
                                                                                                this.velocity.Y = this.velocity.Y + 0.3f;
                                                                                                return;
                                                                                            }
                                                                                            if (this.aiStyle == 26)
                                                                                            {
                                                                                                bool flag5 = false;
                                                                                                bool flag6 = false;
                                                                                                bool flag7 = false;
                                                                                                bool flag8 = false;
                                                                                                int num159 = 60;
                                                                                                if (Main.myPlayer == this.owner)
                                                                                                {
                                                                                                    if (Main.player[Main.myPlayer].dead)
                                                                                                    {
                                                                                                        Main.player[Main.myPlayer].bunny = false;
                                                                                                    }
                                                                                                    if (Main.player[Main.myPlayer].bunny)
                                                                                                    {
                                                                                                        this.timeLeft = 2;
                                                                                                    }
                                                                                                }
                                                                                                if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) < this.position.X + (float)(this.width / 2) - (float)num159)
                                                                                                {
                                                                                                    flag5 = true;
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) > this.position.X + (float)(this.width / 2) + (float)num159)
                                                                                                    {
                                                                                                        flag6 = true;
                                                                                                    }
                                                                                                }
                                                                                                if (Main.player[this.owner].rocketDelay2 > 0)
                                                                                                {
                                                                                                    this.ai[0] = 1f;
                                                                                                }
                                                                                                Vector2 vector17 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                                                                float num160 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector17.X;
                                                                                                float num161 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector17.Y;
                                                                                                float num162 = (float)Math.Sqrt((double)(num160 * num160 + num161 * num161));
                                                                                                if (num162 > 2000f)
                                                                                                {
                                                                                                    this.position.X = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - (float)(this.width / 2);
                                                                                                    this.position.Y = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - (float)(this.height / 2);
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (num162 > 500f || Math.Abs(num161) > 300f)
                                                                                                    {
                                                                                                        this.ai[0] = 1f;
                                                                                                        if (num161 > 0f && this.velocity.Y < 0f)
                                                                                                        {
                                                                                                            this.velocity.Y = 0f;
                                                                                                        }
                                                                                                        if (num161 < 0f && this.velocity.Y > 0f)
                                                                                                        {
                                                                                                            this.velocity.Y = 0f;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                if (this.ai[0] != 0f)
                                                                                                {
                                                                                                    this.tileCollide = false;
                                                                                                    Vector2 vector18 = new Vector2(this.position.X + (float)this.width * 0.5f, this.position.Y + (float)this.height * 0.5f);
                                                                                                    float num163 = Main.player[this.owner].position.X + (float)(Main.player[this.owner].width / 2) - vector18.X;
                                                                                                    float num164 = Main.player[this.owner].position.Y + (float)(Main.player[this.owner].height / 2) - vector18.Y;
                                                                                                    float num165 = (float)Math.Sqrt((double)(num163 * num163 + num164 * num164));
                                                                                                    float num166 = 10f;
                                                                                                    //if (num165 < 200f && Main.player[this.owner].velocity.Y == 0f && this.position.Y + (float)this.height <= Main.player[this.owner].position.Y + (float)Main.player[this.owner].height && !Collision.SolidCollision(this.position, this.width, this.height))
                                                                                                    //{
                                                                                                    //    this.ai[0] = 0f;
                                                                                                    //    if (this.velocity.Y < -6f)
                                                                                                    //    {
                                                                                                    //        this.velocity.Y = -6f;
                                                                                                    //    }
                                                                                                    //}
                                                                                                    if (num165 < 60f)
                                                                                                    {
                                                                                                        num163 = this.velocity.X;
                                                                                                        num164 = this.velocity.Y;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        num165 = num166 / num165;
                                                                                                        num163 *= num165;
                                                                                                        num164 *= num165;
                                                                                                    }
                                                                                                    if (this.velocity.X < num163)
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X + 0.2f;
                                                                                                        if (this.velocity.X < 0f)
                                                                                                        {
                                                                                                            this.velocity.X = this.velocity.X + 0.3f;
                                                                                                        }
                                                                                                    }
                                                                                                    if (this.velocity.X > num163)
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X - 0.2f;
                                                                                                        if (this.velocity.X > 0f)
                                                                                                        {
                                                                                                            this.velocity.X = this.velocity.X - 0.3f;
                                                                                                        }
                                                                                                    }
                                                                                                    if (this.velocity.Y < num164)
                                                                                                    {
                                                                                                        this.velocity.Y = this.velocity.Y + 0.2f;
                                                                                                        if (this.velocity.Y < 0f)
                                                                                                        {
                                                                                                            this.velocity.Y = this.velocity.Y + 0.3f;
                                                                                                        }
                                                                                                    }
                                                                                                    if (this.velocity.Y > num164)
                                                                                                    {
                                                                                                        this.velocity.Y = this.velocity.Y - 0.2f;
                                                                                                        if (this.velocity.Y > 0f)
                                                                                                        {
                                                                                                            this.velocity.Y = this.velocity.Y - 0.3f;
                                                                                                        }
                                                                                                    }
                                                                                                    this.frame = 7;
                                                                                                    if ((double)this.velocity.X > 0.5)
                                                                                                    {
                                                                                                        this.spriteDirection = -1;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if ((double)this.velocity.X < -0.5)
                                                                                                        {
                                                                                                            this.spriteDirection = 1;
                                                                                                        }
                                                                                                    }
                                                                                                    if (this.spriteDirection == -1)
                                                                                                    {
                                                                                                        this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X);
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.rotation = (float)Math.Atan2((double)this.velocity.Y, (double)this.velocity.X) + 3.14f;
                                                                                                    }
                                                                                                    Vector2 arg_7485_0 = new Vector2(this.position.X + (float)(this.width / 2) - 4f, this.position.Y + (float)(this.height / 2) - 4f) - this.velocity;
                                                                                                    int arg_7485_1 = 8;
                                                                                                    int arg_7485_2 = 8;
                                                                                                    int arg_7485_3 = 16;
                                                                                                    float arg_7485_4 = -this.velocity.X * 0.5f;
                                                                                                    float arg_7485_5 = this.velocity.Y * 0.5f;
                                                                                                    int arg_7485_6 = 50;
                                                                                                    Color newColor = default(Color);
                                                                                                    int num167 = Dust.NewDust(arg_7485_0, arg_7485_1, arg_7485_2, arg_7485_3, arg_7485_4, arg_7485_5, arg_7485_6, newColor, 1.7f);
                                                                                                    Main.dust[num167].velocity.X = Main.dust[num167].velocity.X * 0.2f;
                                                                                                    Main.dust[num167].velocity.Y = Main.dust[num167].velocity.Y * 0.2f;
                                                                                                    Main.dust[num167].noGravity = true;
                                                                                                    return;
                                                                                                }
                                                                                                this.rotation = 0f;
                                                                                                this.tileCollide = true;
                                                                                                if (flag5)
                                                                                                {
                                                                                                    if ((double)this.velocity.X > -3.5)
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X - 0.08f;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X - 0.02f;
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (flag6)
                                                                                                    {
                                                                                                        if ((double)this.velocity.X < 3.5)
                                                                                                        {
                                                                                                            this.velocity.X = this.velocity.X + 0.08f;
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            this.velocity.X = this.velocity.X + 0.02f;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        this.velocity.X = this.velocity.X * 0.9f;
                                                                                                        if ((double)this.velocity.X >= -0.08 && (double)this.velocity.X <= 0.08)
                                                                                                        {
                                                                                                            this.velocity.X = 0f;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                if (flag5 || flag6)
                                                                                                {
                                                                                                    int num168 = (int)(this.position.X + (float)(this.width / 2)) / 16;
                                                                                                    int j2 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
                                                                                                    if (flag5)
                                                                                                    {
                                                                                                        num168--;
                                                                                                    }
                                                                                                    if (flag6)
                                                                                                    {
                                                                                                        num168++;
                                                                                                    }
                                                                                                    num168 += (int)this.velocity.X;
                                                                                                    if (WorldGen.SolidTile(num168, j2))
                                                                                                    {
                                                                                                        flag8 = true;
                                                                                                    }
                                                                                                }
                                                                                                if (Main.player[this.owner].position.Y + (float)Main.player[this.owner].height > this.position.Y + (float)this.height)
                                                                                                {
                                                                                                    flag7 = true;
                                                                                                }
                                                                                                if (this.velocity.Y == 0f)
                                                                                                {
                                                                                                    if (!flag7 && (this.velocity.X < 0f || this.velocity.X > 0f))
                                                                                                    {
                                                                                                        int num169 = (int)(this.position.X + (float)(this.width / 2)) / 16;
                                                                                                        int j3 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
                                                                                                        if (flag5)
                                                                                                        {
                                                                                                            num169--;
                                                                                                        }
                                                                                                        if (flag6)
                                                                                                        {
                                                                                                            num169++;
                                                                                                        }
                                                                                                        if (!WorldGen.SolidTile(num169, j3))
                                                                                                        {
                                                                                                            flag8 = true;
                                                                                                        }
                                                                                                    }
                                                                                                    if (flag8)
                                                                                                    {
                                                                                                        int i3 = (int)(this.position.X + (float)(this.width / 2)) / 16;
                                                                                                        int j4 = (int)(this.position.Y + (float)(this.height / 2)) / 16 + 1;
                                                                                                        if (WorldGen.SolidTile(i3, j4))
                                                                                                        {
                                                                                                            this.velocity.Y = -9.1f;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                if (this.velocity.X > 6.5f)
                                                                                                {
                                                                                                    this.velocity.X = 6.5f;
                                                                                                }
                                                                                                if (this.velocity.X < -6.5f)
                                                                                                {
                                                                                                    this.velocity.X = -6.5f;
                                                                                                }
                                                                                                if ((double)this.velocity.X > 0.07 && flag6)
                                                                                                {
                                                                                                    this.direction = 1;
                                                                                                }
                                                                                                if ((double)this.velocity.X < -0.07 && flag5)
                                                                                                {
                                                                                                    this.direction = -1;
                                                                                                }
                                                                                                if (this.direction == -1)
                                                                                                {
                                                                                                    this.spriteDirection = 1;
                                                                                                }
                                                                                                if (this.direction == 1)
                                                                                                {
                                                                                                    this.spriteDirection = -1;
                                                                                                }
                                                                                                if (this.velocity.Y == 0f)
                                                                                                {
                                                                                                    if (this.velocity.X == 0f)
                                                                                                    {
                                                                                                        this.frame = 0;
                                                                                                        this.frameCounter = 0;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if ((double)this.velocity.X < -0.8 || (double)this.velocity.X > 0.8)
                                                                                                        {
                                                                                                            this.frameCounter += (int)Math.Abs(this.velocity.X);
                                                                                                            this.frameCounter++;
                                                                                                            if (this.frameCounter > 6)
                                                                                                            {
                                                                                                                this.frame++;
                                                                                                                this.frameCounter = 0;
                                                                                                            }
                                                                                                            if (this.frame >= 7)
                                                                                                            {
                                                                                                                this.frame = 0;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            this.frame = 0;
                                                                                                            this.frameCounter = 0;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.velocity.Y < 0f)
                                                                                                    {
                                                                                                        this.frameCounter = 0;
                                                                                                        this.frame = 4;
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.velocity.Y > 0f)
                                                                                                        {
                                                                                                            this.frameCounter = 0;
                                                                                                            this.frame = 6;
                                                                                                        }
                                                                                                    }
                                                                                                }
                                                                                                this.velocity.Y = this.velocity.Y + 0.4f;
                                                                                                if (this.velocity.Y > 10f)
                                                                                                {
                                                                                                    this.velocity.Y = 10f;
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
        public void Kill()
        {
            if (!this.active)
            {
                return;
            }
            this.timeLeft = 0;
            if (this.type == 1 || this.type == 81 || this.type == 98)
            {
                Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                for (int i = 0; i < 10; i++)
                {
                    Vector2 arg_92_0 = new Vector2(this.position.X, this.position.Y);
                    int arg_92_1 = this.width;
                    int arg_92_2 = this.height;
                    int arg_92_3 = 7;
                    float arg_92_4 = 0f;
                    float arg_92_5 = 0f;
                    int arg_92_6 = 0;
                    Color newColor = default(Color);
                    Dust.NewDust(arg_92_0, arg_92_1, arg_92_2, arg_92_3, arg_92_4, arg_92_5, arg_92_6, newColor, 1f);
                }
            }
            else
            {
                if (this.type == 111)
                {
                    int num = Gore.NewGore(new Vector2(this.position.X - (float)(this.width / 2), this.position.Y - (float)(this.height / 2)), new Vector2(0f, 0f), Main.rand.Next(11, 14), this.scale);
                    Gore expr_10F = Main.gore[num];
                    expr_10F.velocity *= 0.1f;
                }
                else
                {
                    if (this.type == 93)
                    {
                        Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                        for (int j = 0; j < 10; j++)
                        {
                            Vector2 arg_188_0 = this.position;
                            int arg_188_1 = this.width;
                            int arg_188_2 = this.height;
                            int arg_188_3 = 57;
                            float arg_188_4 = 0f;
                            float arg_188_5 = 0f;
                            int arg_188_6 = 100;
                            Color newColor = default(Color);
                            int num2 = Dust.NewDust(arg_188_0, arg_188_1, arg_188_2, arg_188_3, arg_188_4, arg_188_5, arg_188_6, newColor, 0.5f);
                            Dust expr_19A_cp_0 = Main.dust[num2];
                            expr_19A_cp_0.velocity.X = expr_19A_cp_0.velocity.X * 2f;
                            Dust expr_1B7_cp_0 = Main.dust[num2];
                            expr_1B7_cp_0.velocity.Y = expr_1B7_cp_0.velocity.Y * 2f;
                        }
                    }
                    else
                    {
                        if (this.type == 99)
                        {
                            Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                            for (int k = 0; k < 30; k++)
                            {
                                Vector2 arg_234_0 = this.position;
                                int arg_234_1 = this.width;
                                int arg_234_2 = this.height;
                                int arg_234_3 = 1;
                                float arg_234_4 = 0f;
                                float arg_234_5 = 0f;
                                int arg_234_6 = 0;
                                Color newColor = default(Color);
                                int num3 = Dust.NewDust(arg_234_0, arg_234_1, arg_234_2, arg_234_3, arg_234_4, arg_234_5, arg_234_6, newColor, 1f);
                                if (Main.rand.Next(2) == 0)
                                {
                                    Main.dust[num3].scale *= 1.4f;
                                }
                                this.velocity *= 1.9f;
                            }
                        }
                        else
                        {
                            if (this.type == 91 || this.type == 92)
                            {
                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                for (int l = 0; l < 10; l++)
                                {
                                    Vector2 arg_30E_0 = this.position;
                                    int arg_30E_1 = this.width;
                                    int arg_30E_2 = this.height;
                                    int arg_30E_3 = 58;
                                    float arg_30E_4 = this.velocity.X * 0.1f;
                                    float arg_30E_5 = this.velocity.Y * 0.1f;
                                    int arg_30E_6 = 150;
                                    Color newColor = default(Color);
                                    Dust.NewDust(arg_30E_0, arg_30E_1, arg_30E_2, arg_30E_3, arg_30E_4, arg_30E_5, arg_30E_6, newColor, 1.2f);
                                }
                                for (int m = 0; m < 3; m++)
                                {
                                    Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
                                }
                                if (this.type == 12 && this.damage < 500)
                                {
                                    for (int n = 0; n < 10; n++)
                                    {
                                        Vector2 arg_3E2_0 = this.position;
                                        int arg_3E2_1 = this.width;
                                        int arg_3E2_2 = this.height;
                                        int arg_3E2_3 = 57;
                                        float arg_3E2_4 = this.velocity.X * 0.1f;
                                        float arg_3E2_5 = this.velocity.Y * 0.1f;
                                        int arg_3E2_6 = 150;
                                        Color newColor = default(Color);
                                        Dust.NewDust(arg_3E2_0, arg_3E2_1, arg_3E2_2, arg_3E2_3, arg_3E2_4, arg_3E2_5, arg_3E2_6, newColor, 1.2f);
                                    }
                                    for (int num4 = 0; num4 < 3; num4++)
                                    {
                                        Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
                                    }
                                }
                                if ((this.type == 91 || (this.type == 92 && this.ai[0] > 0f)) && this.owner == Main.myPlayer)
                                {
                                    float x = this.position.X + (float)Main.rand.Next(-400, 400);
                                    float y = this.position.Y - (float)Main.rand.Next(600, 900);
                                    Vector2 vector = new Vector2(x, y);
                                    float num5 = this.position.X + (float)(this.width / 2) - vector.X;
                                    float num6 = this.position.Y + (float)(this.height / 2) - vector.Y;
                                    int num7 = 22;
                                    float num8 = (float)Math.Sqrt((double)(num5 * num5 + num6 * num6));
                                    num8 = (float)num7 / num8;
                                    num5 *= num8;
                                    num6 *= num8;
                                    int num9 = this.damage;
                                    if (this.type == 91)
                                    {
                                        num9 = (int)((float)num9 * 0.5f);
                                    }
                                    int num10 = Projectile.NewProjectile(x, y, num5, num6, 92, num9, this.knockBack, this.owner);
                                    if (this.type == 91)
                                    {
                                        Main.projectile[num10].ai[1] = this.position.Y;
                                        Main.projectile[num10].ai[0] = 1f;
                                    }
                                    else
                                    {
                                        Main.projectile[num10].ai[1] = this.position.Y;
                                    }
                                }
                            }
                            else
                            {
                                if (this.type == 89)
                                {
                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                    for (int num11 = 0; num11 < 5; num11++)
                                    {
                                        Vector2 arg_650_0 = new Vector2(this.position.X, this.position.Y);
                                        int arg_650_1 = this.width;
                                        int arg_650_2 = this.height;
                                        int arg_650_3 = 68;
                                        float arg_650_4 = 0f;
                                        float arg_650_5 = 0f;
                                        int arg_650_6 = 0;
                                        Color newColor = default(Color);
                                        int num12 = Dust.NewDust(arg_650_0, arg_650_1, arg_650_2, arg_650_3, arg_650_4, arg_650_5, arg_650_6, newColor, 1f);
                                        Main.dust[num12].noGravity = true;
                                        Dust expr_66D = Main.dust[num12];
                                        expr_66D.velocity *= 1.5f;
                                        Main.dust[num12].scale *= 0.9f;
                                    }
                                    if (this.type == 89 && this.owner == Main.myPlayer)
                                    {
                                        for (int num13 = 0; num13 < 3; num13++)
                                        {
                                            float num14 = -this.velocity.X * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                                            float num15 = -this.velocity.Y * (float)Main.rand.Next(40, 70) * 0.01f + (float)Main.rand.Next(-20, 21) * 0.4f;
                                            Projectile.NewProjectile(this.position.X + num14, this.position.Y + num15, num14, num15, 90, (int)((double)this.damage * 0.6), 0f, this.owner);
                                        }
                                    }
                                }
                                else
                                {
                                    if (this.type == 80)
                                    {
                                        if (this.ai[0] >= 0f)
                                        {
                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 27);
                                            for (int num16 = 0; num16 < 10; num16++)
                                            {
                                                Vector2 arg_81E_0 = new Vector2(this.position.X, this.position.Y);
                                                int arg_81E_1 = this.width;
                                                int arg_81E_2 = this.height;
                                                int arg_81E_3 = 67;
                                                float arg_81E_4 = 0f;
                                                float arg_81E_5 = 0f;
                                                int arg_81E_6 = 0;
                                                Color newColor = default(Color);
                                                Dust.NewDust(arg_81E_0, arg_81E_1, arg_81E_2, arg_81E_3, arg_81E_4, arg_81E_5, arg_81E_6, newColor, 1f);
                                            }
                                        }
                                        int num17 = (int)this.position.X / 16;
                                        int num18 = (int)this.position.Y / 16;
                                        if (Main.tile[num17, num18] == null)
                                        {
                                            Main.tile[num17, num18] = new Tile();
                                        }
                                        if (Main.tile[num17, num18].type == 127 && Main.tile[num17, num18].active)
                                        {
                                            WorldGen.KillTile(num17, num18, false, false, false);
                                        }
                                    }
                                    else
                                    {
                                        if (this.type == 76 || this.type == 77 || this.type == 78)
                                        {
                                            for (int num19 = 0; num19 < 5; num19++)
                                            {
                                                Vector2 arg_90A_0 = this.position;
                                                int arg_90A_1 = this.width;
                                                int arg_90A_2 = this.height;
                                                int arg_90A_3 = 27;
                                                float arg_90A_4 = 0f;
                                                float arg_90A_5 = 0f;
                                                int arg_90A_6 = 80;
                                                Color newColor = default(Color);
                                                int num20 = Dust.NewDust(arg_90A_0, arg_90A_1, arg_90A_2, arg_90A_3, arg_90A_4, arg_90A_5, arg_90A_6, newColor, 1.5f);
                                                Main.dust[num20].noGravity = true;
                                            }
                                        }
                                        else
                                        {
                                            if (this.type == 55)
                                            {
                                                for (int num21 = 0; num21 < 5; num21++)
                                                {
                                                    Vector2 arg_981_0 = new Vector2(this.position.X, this.position.Y);
                                                    int arg_981_1 = this.width;
                                                    int arg_981_2 = this.height;
                                                    int arg_981_3 = 18;
                                                    float arg_981_4 = 0f;
                                                    float arg_981_5 = 0f;
                                                    int arg_981_6 = 0;
                                                    Color newColor = default(Color);
                                                    int num22 = Dust.NewDust(arg_981_0, arg_981_1, arg_981_2, arg_981_3, arg_981_4, arg_981_5, arg_981_6, newColor, 1.5f);
                                                    Main.dust[num22].noGravity = true;
                                                }
                                            }
                                            else
                                            {
                                                if (this.type == 51)
                                                {
                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                    for (int num23 = 0; num23 < 5; num23++)
                                                    {
                                                        Vector2 arg_A16_0 = new Vector2(this.position.X, this.position.Y);
                                                        int arg_A16_1 = this.width;
                                                        int arg_A16_2 = this.height;
                                                        int arg_A16_3 = 0;
                                                        float arg_A16_4 = 0f;
                                                        float arg_A16_5 = 0f;
                                                        int arg_A16_6 = 0;
                                                        Color newColor = default(Color);
                                                        Dust.NewDust(arg_A16_0, arg_A16_1, arg_A16_2, arg_A16_3, arg_A16_4, arg_A16_5, arg_A16_6, newColor, 0.7f);
                                                    }
                                                }
                                                else
                                                {
                                                    if (this.type == 2 || this.type == 82)
                                                    {
                                                        Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                        for (int num24 = 0; num24 < 20; num24++)
                                                        {
                                                            Vector2 arg_AA6_0 = new Vector2(this.position.X, this.position.Y);
                                                            int arg_AA6_1 = this.width;
                                                            int arg_AA6_2 = this.height;
                                                            int arg_AA6_3 = 6;
                                                            float arg_AA6_4 = 0f;
                                                            float arg_AA6_5 = 0f;
                                                            int arg_AA6_6 = 100;
                                                            Color newColor = default(Color);
                                                            Dust.NewDust(arg_AA6_0, arg_AA6_1, arg_AA6_2, arg_AA6_3, arg_AA6_4, arg_AA6_5, arg_AA6_6, newColor, 1f);
                                                        }
                                                    }
                                                    else
                                                    {
                                                        if (this.type == 103)
                                                        {
                                                            Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                            for (int num25 = 0; num25 < 20; num25++)
                                                            {
                                                                Vector2 arg_B35_0 = new Vector2(this.position.X, this.position.Y);
                                                                int arg_B35_1 = this.width;
                                                                int arg_B35_2 = this.height;
                                                                int arg_B35_3 = 75;
                                                                float arg_B35_4 = 0f;
                                                                float arg_B35_5 = 0f;
                                                                int arg_B35_6 = 100;
                                                                Color newColor = default(Color);
                                                                int num26 = Dust.NewDust(arg_B35_0, arg_B35_1, arg_B35_2, arg_B35_3, arg_B35_4, arg_B35_5, arg_B35_6, newColor, 1f);
                                                                if (Main.rand.Next(2) == 0)
                                                                {
                                                                    Main.dust[num26].scale *= 2.5f;
                                                                    Main.dust[num26].noGravity = true;
                                                                    Dust expr_B78 = Main.dust[num26];
                                                                    expr_B78.velocity *= 5f;
                                                                }
                                                            }
                                                        }
                                                        else
                                                        {
                                                            if (this.type == 3 || this.type == 48 || this.type == 54)
                                                            {
                                                                Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                for (int num27 = 0; num27 < 10; num27++)
                                                                {
                                                                    Vector2 arg_C3F_0 = new Vector2(this.position.X, this.position.Y);
                                                                    int arg_C3F_1 = this.width;
                                                                    int arg_C3F_2 = this.height;
                                                                    int arg_C3F_3 = 1;
                                                                    float arg_C3F_4 = this.velocity.X * 0.1f;
                                                                    float arg_C3F_5 = this.velocity.Y * 0.1f;
                                                                    int arg_C3F_6 = 0;
                                                                    Color newColor = default(Color);
                                                                    Dust.NewDust(arg_C3F_0, arg_C3F_1, arg_C3F_2, arg_C3F_3, arg_C3F_4, arg_C3F_5, arg_C3F_6, newColor, 0.75f);
                                                                }
                                                            }
                                                            else
                                                            {
                                                                if (this.type == 4)
                                                                {
                                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                    for (int num28 = 0; num28 < 10; num28++)
                                                                    {
                                                                        Vector2 arg_CCD_0 = new Vector2(this.position.X, this.position.Y);
                                                                        int arg_CCD_1 = this.width;
                                                                        int arg_CCD_2 = this.height;
                                                                        int arg_CCD_3 = 14;
                                                                        float arg_CCD_4 = 0f;
                                                                        float arg_CCD_5 = 0f;
                                                                        int arg_CCD_6 = 150;
                                                                        Color newColor = default(Color);
                                                                        Dust.NewDust(arg_CCD_0, arg_CCD_1, arg_CCD_2, arg_CCD_3, arg_CCD_4, arg_CCD_5, arg_CCD_6, newColor, 1.1f);
                                                                    }
                                                                }
                                                                else
                                                                {
                                                                    if (this.type == 5)
                                                                    {
                                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                        for (int num29 = 0; num29 < 60; num29++)
                                                                        {
                                                                            int num30 = Main.rand.Next(3);
                                                                            if (num30 == 0)
                                                                            {
                                                                                num30 = 15;
                                                                            }
                                                                            else
                                                                            {
                                                                                if (num30 == 1)
                                                                                {
                                                                                    num30 = 57;
                                                                                }
                                                                                else
                                                                                {
                                                                                    num30 = 58;
                                                                                }
                                                                            }
                                                                            Vector2 arg_D85_0 = this.position;
                                                                            int arg_D85_1 = this.width;
                                                                            int arg_D85_2 = this.height;
                                                                            int arg_D85_3 = num30;
                                                                            float arg_D85_4 = this.velocity.X * 0.5f;
                                                                            float arg_D85_5 = this.velocity.Y * 0.5f;
                                                                            int arg_D85_6 = 150;
                                                                            Color newColor = default(Color);
                                                                            Dust.NewDust(arg_D85_0, arg_D85_1, arg_D85_2, arg_D85_3, arg_D85_4, arg_D85_5, arg_D85_6, newColor, 1.5f);
                                                                        }
                                                                    }
                                                                    else
                                                                    {
                                                                        if (this.type == 9 || this.type == 12)
                                                                        {
                                                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                            for (int num31 = 0; num31 < 10; num31++)
                                                                            {
                                                                                Vector2 arg_E25_0 = this.position;
                                                                                int arg_E25_1 = this.width;
                                                                                int arg_E25_2 = this.height;
                                                                                int arg_E25_3 = 58;
                                                                                float arg_E25_4 = this.velocity.X * 0.1f;
                                                                                float arg_E25_5 = this.velocity.Y * 0.1f;
                                                                                int arg_E25_6 = 150;
                                                                                Color newColor = default(Color);
                                                                                Dust.NewDust(arg_E25_0, arg_E25_1, arg_E25_2, arg_E25_3, arg_E25_4, arg_E25_5, arg_E25_6, newColor, 1.2f);
                                                                            }
                                                                            for (int num32 = 0; num32 < 3; num32++)
                                                                            {
                                                                                Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
                                                                            }
                                                                            if (this.type == 12 && this.damage < 100)
                                                                            {
                                                                                for (int num33 = 0; num33 < 10; num33++)
                                                                                {
                                                                                    Vector2 arg_EF6_0 = this.position;
                                                                                    int arg_EF6_1 = this.width;
                                                                                    int arg_EF6_2 = this.height;
                                                                                    int arg_EF6_3 = 57;
                                                                                    float arg_EF6_4 = this.velocity.X * 0.1f;
                                                                                    float arg_EF6_5 = this.velocity.Y * 0.1f;
                                                                                    int arg_EF6_6 = 150;
                                                                                    Color newColor = default(Color);
                                                                                    Dust.NewDust(arg_EF6_0, arg_EF6_1, arg_EF6_2, arg_EF6_3, arg_EF6_4, arg_EF6_5, arg_EF6_6, newColor, 1.2f);
                                                                                }
                                                                                for (int num34 = 0; num34 < 3; num34++)
                                                                                {
                                                                                    Gore.NewGore(this.position, new Vector2(this.velocity.X * 0.05f, this.velocity.Y * 0.05f), Main.rand.Next(16, 18), 1f);
                                                                                }
                                                                            }
                                                                        }
                                                                        else
                                                                        {
                                                                            if (this.type == 14 || this.type == 20 || this.type == 36 || this.type == 83 || this.type == 84 || this.type == 100 || this.type == 110)
                                                                            {
                                                                                Collision.HitTiles(this.position, this.velocity, this.width, this.height);
                                                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                            }
                                                                            else
                                                                            {
                                                                                if (this.type == 15 || this.type == 34)
                                                                                {
                                                                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                    for (int num35 = 0; num35 < 20; num35++)
                                                                                    {
                                                                                        Vector2 arg_1087_0 = new Vector2(this.position.X, this.position.Y);
                                                                                        int arg_1087_1 = this.width;
                                                                                        int arg_1087_2 = this.height;
                                                                                        int arg_1087_3 = 6;
                                                                                        float arg_1087_4 = -this.velocity.X * 0.2f;
                                                                                        float arg_1087_5 = -this.velocity.Y * 0.2f;
                                                                                        int arg_1087_6 = 100;
                                                                                        Color newColor = default(Color);
                                                                                        int num36 = Dust.NewDust(arg_1087_0, arg_1087_1, arg_1087_2, arg_1087_3, arg_1087_4, arg_1087_5, arg_1087_6, newColor, 2f);
                                                                                        Main.dust[num36].noGravity = true;
                                                                                        Dust expr_10A4 = Main.dust[num36];
                                                                                        expr_10A4.velocity *= 2f;
                                                                                        Vector2 arg_1116_0 = new Vector2(this.position.X, this.position.Y);
                                                                                        int arg_1116_1 = this.width;
                                                                                        int arg_1116_2 = this.height;
                                                                                        int arg_1116_3 = 6;
                                                                                        float arg_1116_4 = -this.velocity.X * 0.2f;
                                                                                        float arg_1116_5 = -this.velocity.Y * 0.2f;
                                                                                        int arg_1116_6 = 100;
                                                                                        newColor = default(Color);
                                                                                        num36 = Dust.NewDust(arg_1116_0, arg_1116_1, arg_1116_2, arg_1116_3, arg_1116_4, arg_1116_5, arg_1116_6, newColor, 1f);
                                                                                        Dust expr_1125 = Main.dust[num36];
                                                                                        expr_1125.velocity *= 2f;
                                                                                    }
                                                                                }
                                                                                else
                                                                                {
                                                                                    if (this.type == 95 || this.type == 96)
                                                                                    {
                                                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                        for (int num37 = 0; num37 < 20; num37++)
                                                                                        {
                                                                                            Vector2 arg_11F2_0 = new Vector2(this.position.X, this.position.Y);
                                                                                            int arg_11F2_1 = this.width;
                                                                                            int arg_11F2_2 = this.height;
                                                                                            int arg_11F2_3 = 75;
                                                                                            float arg_11F2_4 = -this.velocity.X * 0.2f;
                                                                                            float arg_11F2_5 = -this.velocity.Y * 0.2f;
                                                                                            int arg_11F2_6 = 100;
                                                                                            Color newColor = default(Color);
                                                                                            int num38 = Dust.NewDust(arg_11F2_0, arg_11F2_1, arg_11F2_2, arg_11F2_3, arg_11F2_4, arg_11F2_5, arg_11F2_6, newColor, 2f * this.scale);
                                                                                            Main.dust[num38].noGravity = true;
                                                                                            Dust expr_120F = Main.dust[num38];
                                                                                            expr_120F.velocity *= 2f;
                                                                                            Vector2 arg_1289_0 = new Vector2(this.position.X, this.position.Y);
                                                                                            int arg_1289_1 = this.width;
                                                                                            int arg_1289_2 = this.height;
                                                                                            int arg_1289_3 = 75;
                                                                                            float arg_1289_4 = -this.velocity.X * 0.2f;
                                                                                            float arg_1289_5 = -this.velocity.Y * 0.2f;
                                                                                            int arg_1289_6 = 100;
                                                                                            newColor = default(Color);
                                                                                            num38 = Dust.NewDust(arg_1289_0, arg_1289_1, arg_1289_2, arg_1289_3, arg_1289_4, arg_1289_5, arg_1289_6, newColor, 1f * this.scale);
                                                                                            Dust expr_1298 = Main.dust[num38];
                                                                                            expr_1298.velocity *= 2f;
                                                                                        }
                                                                                    }
                                                                                    else
                                                                                    {
                                                                                        if (this.type == 79)
                                                                                        {
                                                                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                            for (int num39 = 0; num39 < 20; num39++)
                                                                                            {
                                                                                                int num40 = Dust.NewDust(new Vector2(this.position.X, this.position.Y), this.width, this.height, 66, 0f, 0f, 100, new Color(Main.DiscoR, Main.DiscoG, Main.DiscoB), 2f);
                                                                                                Main.dust[num40].noGravity = true;
                                                                                                Dust expr_1361 = Main.dust[num40];
                                                                                                expr_1361.velocity *= 4f;
                                                                                            }
                                                                                        }
                                                                                        else
                                                                                        {
                                                                                            if (this.type == 16)
                                                                                            {
                                                                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                                for (int num41 = 0; num41 < 20; num41++)
                                                                                                {
                                                                                                    Vector2 arg_141B_0 = new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
                                                                                                    int arg_141B_1 = this.width;
                                                                                                    int arg_141B_2 = this.height;
                                                                                                    int arg_141B_3 = 15;
                                                                                                    float arg_141B_4 = 0f;
                                                                                                    float arg_141B_5 = 0f;
                                                                                                    int arg_141B_6 = 100;
                                                                                                    Color newColor = default(Color);
                                                                                                    int num42 = Dust.NewDust(arg_141B_0, arg_141B_1, arg_141B_2, arg_141B_3, arg_141B_4, arg_141B_5, arg_141B_6, newColor, 2f);
                                                                                                    Main.dust[num42].noGravity = true;
                                                                                                    Dust expr_1438 = Main.dust[num42];
                                                                                                    expr_1438.velocity *= 2f;
                                                                                                    Vector2 arg_14A9_0 = new Vector2(this.position.X - this.velocity.X, this.position.Y - this.velocity.Y);
                                                                                                    int arg_14A9_1 = this.width;
                                                                                                    int arg_14A9_2 = this.height;
                                                                                                    int arg_14A9_3 = 15;
                                                                                                    float arg_14A9_4 = 0f;
                                                                                                    float arg_14A9_5 = 0f;
                                                                                                    int arg_14A9_6 = 100;
                                                                                                    newColor = default(Color);
                                                                                                    num42 = Dust.NewDust(arg_14A9_0, arg_14A9_1, arg_14A9_2, arg_14A9_3, arg_14A9_4, arg_14A9_5, arg_14A9_6, newColor, 1f);
                                                                                                }
                                                                                            }
                                                                                            else
                                                                                            {
                                                                                                if (this.type == 17)
                                                                                                {
                                                                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                    for (int num43 = 0; num43 < 5; num43++)
                                                                                                    {
                                                                                                        Vector2 arg_1534_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                        int arg_1534_1 = this.width;
                                                                                                        int arg_1534_2 = this.height;
                                                                                                        int arg_1534_3 = 0;
                                                                                                        float arg_1534_4 = 0f;
                                                                                                        float arg_1534_5 = 0f;
                                                                                                        int arg_1534_6 = 0;
                                                                                                        Color newColor = default(Color);
                                                                                                        Dust.NewDust(arg_1534_0, arg_1534_1, arg_1534_2, arg_1534_3, arg_1534_4, arg_1534_5, arg_1534_6, newColor, 1f);
                                                                                                    }
                                                                                                }
                                                                                                else
                                                                                                {
                                                                                                    if (this.type == 31 || this.type == 42)
                                                                                                    {
                                                                                                        Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                        for (int num44 = 0; num44 < 5; num44++)
                                                                                                        {
                                                                                                            Vector2 arg_15C8_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                            int arg_15C8_1 = this.width;
                                                                                                            int arg_15C8_2 = this.height;
                                                                                                            int arg_15C8_3 = 32;
                                                                                                            float arg_15C8_4 = 0f;
                                                                                                            float arg_15C8_5 = 0f;
                                                                                                            int arg_15C8_6 = 0;
                                                                                                            Color newColor = default(Color);
                                                                                                            int num45 = Dust.NewDust(arg_15C8_0, arg_15C8_1, arg_15C8_2, arg_15C8_3, arg_15C8_4, arg_15C8_5, arg_15C8_6, newColor, 1f);
                                                                                                            Dust expr_15D7 = Main.dust[num45];
                                                                                                            expr_15D7.velocity *= 0.6f;
                                                                                                        }
                                                                                                    }
                                                                                                    else
                                                                                                    {
                                                                                                        if (this.type == 109)
                                                                                                        {
                                                                                                            Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                            for (int num46 = 0; num46 < 5; num46++)
                                                                                                            {
                                                                                                                Vector2 arg_1670_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                int arg_1670_1 = this.width;
                                                                                                                int arg_1670_2 = this.height;
                                                                                                                int arg_1670_3 = 51;
                                                                                                                float arg_1670_4 = 0f;
                                                                                                                float arg_1670_5 = 0f;
                                                                                                                int arg_1670_6 = 0;
                                                                                                                Color newColor = default(Color);
                                                                                                                int num47 = Dust.NewDust(arg_1670_0, arg_1670_1, arg_1670_2, arg_1670_3, arg_1670_4, arg_1670_5, arg_1670_6, newColor, 0.6f);
                                                                                                                Dust expr_167F = Main.dust[num47];
                                                                                                                expr_167F.velocity *= 0.6f;
                                                                                                            }
                                                                                                        }
                                                                                                        else
                                                                                                        {
                                                                                                            if (this.type == 39)
                                                                                                            {
                                                                                                                Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                for (int num48 = 0; num48 < 5; num48++)
                                                                                                                {
                                                                                                                    Vector2 arg_1718_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                    int arg_1718_1 = this.width;
                                                                                                                    int arg_1718_2 = this.height;
                                                                                                                    int arg_1718_3 = 38;
                                                                                                                    float arg_1718_4 = 0f;
                                                                                                                    float arg_1718_5 = 0f;
                                                                                                                    int arg_1718_6 = 0;
                                                                                                                    Color newColor = default(Color);
                                                                                                                    int num49 = Dust.NewDust(arg_1718_0, arg_1718_1, arg_1718_2, arg_1718_3, arg_1718_4, arg_1718_5, arg_1718_6, newColor, 1f);
                                                                                                                    Dust expr_1727 = Main.dust[num49];
                                                                                                                    expr_1727.velocity *= 0.6f;
                                                                                                                }
                                                                                                            }
                                                                                                            else
                                                                                                            {
                                                                                                                if (this.type == 71)
                                                                                                                {
                                                                                                                    Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                    for (int num50 = 0; num50 < 5; num50++)
                                                                                                                    {
                                                                                                                        Vector2 arg_17C0_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                        int arg_17C0_1 = this.width;
                                                                                                                        int arg_17C0_2 = this.height;
                                                                                                                        int arg_17C0_3 = 53;
                                                                                                                        float arg_17C0_4 = 0f;
                                                                                                                        float arg_17C0_5 = 0f;
                                                                                                                        int arg_17C0_6 = 0;
                                                                                                                        Color newColor = default(Color);
                                                                                                                        int num51 = Dust.NewDust(arg_17C0_0, arg_17C0_1, arg_17C0_2, arg_17C0_3, arg_17C0_4, arg_17C0_5, arg_17C0_6, newColor, 1f);
                                                                                                                        Dust expr_17CF = Main.dust[num51];
                                                                                                                        expr_17CF.velocity *= 0.6f;
                                                                                                                    }
                                                                                                                }
                                                                                                                else
                                                                                                                {
                                                                                                                    if (this.type == 40)
                                                                                                                    {
                                                                                                                        Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                        for (int num52 = 0; num52 < 5; num52++)
                                                                                                                        {
                                                                                                                            Vector2 arg_1868_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                            int arg_1868_1 = this.width;
                                                                                                                            int arg_1868_2 = this.height;
                                                                                                                            int arg_1868_3 = 36;
                                                                                                                            float arg_1868_4 = 0f;
                                                                                                                            float arg_1868_5 = 0f;
                                                                                                                            int arg_1868_6 = 0;
                                                                                                                            Color newColor = default(Color);
                                                                                                                            int num53 = Dust.NewDust(arg_1868_0, arg_1868_1, arg_1868_2, arg_1868_3, arg_1868_4, arg_1868_5, arg_1868_6, newColor, 1f);
                                                                                                                            Dust expr_1877 = Main.dust[num53];
                                                                                                                            expr_1877.velocity *= 0.6f;
                                                                                                                        }
                                                                                                                    }
                                                                                                                    else
                                                                                                                    {
                                                                                                                        if (this.type == 21)
                                                                                                                        {
                                                                                                                            Main.PlaySound(0, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                            for (int num54 = 0; num54 < 10; num54++)
                                                                                                                            {
                                                                                                                                Vector2 arg_190D_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                int arg_190D_1 = this.width;
                                                                                                                                int arg_190D_2 = this.height;
                                                                                                                                int arg_190D_3 = 26;
                                                                                                                                float arg_190D_4 = 0f;
                                                                                                                                float arg_190D_5 = 0f;
                                                                                                                                int arg_190D_6 = 0;
                                                                                                                                Color newColor = default(Color);
                                                                                                                                Dust.NewDust(arg_190D_0, arg_190D_1, arg_190D_2, arg_190D_3, arg_190D_4, arg_190D_5, arg_190D_6, newColor, 0.8f);
                                                                                                                            }
                                                                                                                        }
                                                                                                                        else
                                                                                                                        {
                                                                                                                            if (this.type == 24)
                                                                                                                            {
                                                                                                                                for (int num55 = 0; num55 < 10; num55++)
                                                                                                                                {
                                                                                                                                    Vector2 arg_198D_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                    int arg_198D_1 = this.width;
                                                                                                                                    int arg_198D_2 = this.height;
                                                                                                                                    int arg_198D_3 = 1;
                                                                                                                                    float arg_198D_4 = this.velocity.X * 0.1f;
                                                                                                                                    float arg_198D_5 = this.velocity.Y * 0.1f;
                                                                                                                                    int arg_198D_6 = 0;
                                                                                                                                    Color newColor = default(Color);
                                                                                                                                    Dust.NewDust(arg_198D_0, arg_198D_1, arg_198D_2, arg_198D_3, arg_198D_4, arg_198D_5, arg_198D_6, newColor, 0.75f);
                                                                                                                                }
                                                                                                                            }
                                                                                                                            else
                                                                                                                            {
                                                                                                                                if (this.type == 27)
                                                                                                                                {
                                                                                                                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                                                                    for (int num56 = 0; num56 < 30; num56++)
                                                                                                                                    {
                                                                                                                                        Vector2 arg_1A35_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                        int arg_1A35_1 = this.width;
                                                                                                                                        int arg_1A35_2 = this.height;
                                                                                                                                        int arg_1A35_3 = 29;
                                                                                                                                        float arg_1A35_4 = this.velocity.X * 0.1f;
                                                                                                                                        float arg_1A35_5 = this.velocity.Y * 0.1f;
                                                                                                                                        int arg_1A35_6 = 100;
                                                                                                                                        Color newColor = default(Color);
                                                                                                                                        int num57 = Dust.NewDust(arg_1A35_0, arg_1A35_1, arg_1A35_2, arg_1A35_3, arg_1A35_4, arg_1A35_5, arg_1A35_6, newColor, 3f);
                                                                                                                                        Main.dust[num57].noGravity = true;
                                                                                                                                        Vector2 arg_1AA6_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                        int arg_1AA6_1 = this.width;
                                                                                                                                        int arg_1AA6_2 = this.height;
                                                                                                                                        int arg_1AA6_3 = 29;
                                                                                                                                        float arg_1AA6_4 = this.velocity.X * 0.1f;
                                                                                                                                        float arg_1AA6_5 = this.velocity.Y * 0.1f;
                                                                                                                                        int arg_1AA6_6 = 100;
                                                                                                                                        newColor = default(Color);
                                                                                                                                        Dust.NewDust(arg_1AA6_0, arg_1AA6_1, arg_1AA6_2, arg_1AA6_3, arg_1AA6_4, arg_1AA6_5, arg_1AA6_6, newColor, 2f);
                                                                                                                                    }
                                                                                                                                }
                                                                                                                                else
                                                                                                                                {
                                                                                                                                    if (this.type == 38)
                                                                                                                                    {
                                                                                                                                        for (int num58 = 0; num58 < 10; num58++)
                                                                                                                                        {
                                                                                                                                            Vector2 arg_1B2A_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                            int arg_1B2A_1 = this.width;
                                                                                                                                            int arg_1B2A_2 = this.height;
                                                                                                                                            int arg_1B2A_3 = 42;
                                                                                                                                            float arg_1B2A_4 = this.velocity.X * 0.1f;
                                                                                                                                            float arg_1B2A_5 = this.velocity.Y * 0.1f;
                                                                                                                                            int arg_1B2A_6 = 0;
                                                                                                                                            Color newColor = default(Color);
                                                                                                                                            Dust.NewDust(arg_1B2A_0, arg_1B2A_1, arg_1B2A_2, arg_1B2A_3, arg_1B2A_4, arg_1B2A_5, arg_1B2A_6, newColor, 1f);
                                                                                                                                        }
                                                                                                                                    }
                                                                                                                                    else
                                                                                                                                    {
                                                                                                                                        if (this.type == 44 || this.type == 45)
                                                                                                                                        {
                                                                                                                                            Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 10);
                                                                                                                                            for (int num59 = 0; num59 < 30; num59++)
                                                                                                                                            {
                                                                                                                                                Vector2 arg_1BD0_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                int arg_1BD0_1 = this.width;
                                                                                                                                                int arg_1BD0_2 = this.height;
                                                                                                                                                int arg_1BD0_3 = 27;
                                                                                                                                                float arg_1BD0_4 = this.velocity.X;
                                                                                                                                                float arg_1BD0_5 = this.velocity.Y;
                                                                                                                                                int arg_1BD0_6 = 100;
                                                                                                                                                Color newColor = default(Color);
                                                                                                                                                int num60 = Dust.NewDust(arg_1BD0_0, arg_1BD0_1, arg_1BD0_2, arg_1BD0_3, arg_1BD0_4, arg_1BD0_5, arg_1BD0_6, newColor, 1.7f);
                                                                                                                                                Main.dust[num60].noGravity = true;
                                                                                                                                                Vector2 arg_1C35_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                int arg_1C35_1 = this.width;
                                                                                                                                                int arg_1C35_2 = this.height;
                                                                                                                                                int arg_1C35_3 = 27;
                                                                                                                                                float arg_1C35_4 = this.velocity.X;
                                                                                                                                                float arg_1C35_5 = this.velocity.Y;
                                                                                                                                                int arg_1C35_6 = 100;
                                                                                                                                                newColor = default(Color);
                                                                                                                                                Dust.NewDust(arg_1C35_0, arg_1C35_1, arg_1C35_2, arg_1C35_3, arg_1C35_4, arg_1C35_5, arg_1C35_6, newColor, 1f);
                                                                                                                                            }
                                                                                                                                        }
                                                                                                                                        else
                                                                                                                                        {
                                                                                                                                            if (this.type == 41)
                                                                                                                                            {
                                                                                                                                                Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
                                                                                                                                                for (int num61 = 0; num61 < 10; num61++)
                                                                                                                                                {
                                                                                                                                                    Vector2 arg_1CC5_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    int arg_1CC5_1 = this.width;
                                                                                                                                                    int arg_1CC5_2 = this.height;
                                                                                                                                                    int arg_1CC5_3 = 31;
                                                                                                                                                    float arg_1CC5_4 = 0f;
                                                                                                                                                    float arg_1CC5_5 = 0f;
                                                                                                                                                    int arg_1CC5_6 = 100;
                                                                                                                                                    Color newColor = default(Color);
                                                                                                                                                    Dust.NewDust(arg_1CC5_0, arg_1CC5_1, arg_1CC5_2, arg_1CC5_3, arg_1CC5_4, arg_1CC5_5, arg_1CC5_6, newColor, 1.5f);
                                                                                                                                                }
                                                                                                                                                for (int num62 = 0; num62 < 5; num62++)
                                                                                                                                                {
                                                                                                                                                    Vector2 arg_1D22_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    int arg_1D22_1 = this.width;
                                                                                                                                                    int arg_1D22_2 = this.height;
                                                                                                                                                    int arg_1D22_3 = 6;
                                                                                                                                                    float arg_1D22_4 = 0f;
                                                                                                                                                    float arg_1D22_5 = 0f;
                                                                                                                                                    int arg_1D22_6 = 100;
                                                                                                                                                    Color newColor = default(Color);
                                                                                                                                                    int num63 = Dust.NewDust(arg_1D22_0, arg_1D22_1, arg_1D22_2, arg_1D22_3, arg_1D22_4, arg_1D22_5, arg_1D22_6, newColor, 2.5f);
                                                                                                                                                    Main.dust[num63].noGravity = true;
                                                                                                                                                    Dust expr_1D3F = Main.dust[num63];
                                                                                                                                                    expr_1D3F.velocity *= 3f;
                                                                                                                                                    Vector2 arg_1D97_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    int arg_1D97_1 = this.width;
                                                                                                                                                    int arg_1D97_2 = this.height;
                                                                                                                                                    int arg_1D97_3 = 6;
                                                                                                                                                    float arg_1D97_4 = 0f;
                                                                                                                                                    float arg_1D97_5 = 0f;
                                                                                                                                                    int arg_1D97_6 = 100;
                                                                                                                                                    newColor = default(Color);
                                                                                                                                                    num63 = Dust.NewDust(arg_1D97_0, arg_1D97_1, arg_1D97_2, arg_1D97_3, arg_1D97_4, arg_1D97_5, arg_1D97_6, newColor, 1.5f);
                                                                                                                                                    Dust expr_1DA6 = Main.dust[num63];
                                                                                                                                                    expr_1DA6.velocity *= 2f;
                                                                                                                                                }
                                                                                                                                                Vector2 arg_1E01_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                Vector2 vector2 = default(Vector2);
                                                                                                                                                int num64 = Gore.NewGore(arg_1E01_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                Gore expr_1E10 = Main.gore[num64];
                                                                                                                                                expr_1E10.velocity *= 0.4f;
                                                                                                                                                Gore expr_1E32_cp_0 = Main.gore[num64];
                                                                                                                                                expr_1E32_cp_0.velocity.X = expr_1E32_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
                                                                                                                                                Gore expr_1E60_cp_0 = Main.gore[num64];
                                                                                                                                                expr_1E60_cp_0.velocity.Y = expr_1E60_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
                                                                                                                                                Vector2 arg_1EB9_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                vector2 = default(Vector2);
                                                                                                                                                num64 = Gore.NewGore(arg_1EB9_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                Gore expr_1EC8 = Main.gore[num64];
                                                                                                                                                expr_1EC8.velocity *= 0.4f;
                                                                                                                                                Gore expr_1EEA_cp_0 = Main.gore[num64];
                                                                                                                                                expr_1EEA_cp_0.velocity.X = expr_1EEA_cp_0.velocity.X + (float)Main.rand.Next(-10, 11) * 0.1f;
                                                                                                                                                Gore expr_1F18_cp_0 = Main.gore[num64];
                                                                                                                                                expr_1F18_cp_0.velocity.Y = expr_1F18_cp_0.velocity.Y + (float)Main.rand.Next(-10, 11) * 0.1f;
                                                                                                                                                if (this.owner == Main.myPlayer)
                                                                                                                                                {
                                                                                                                                                    this.penetrate = -1;
                                                                                                                                                    this.position.X = this.position.X + (float)(this.width / 2);
                                                                                                                                                    this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                                                                                    this.width = 64;
                                                                                                                                                    this.height = 64;
                                                                                                                                                    this.position.X = this.position.X - (float)(this.width / 2);
                                                                                                                                                    this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                                                                                    this.Damage();
                                                                                                                                                }
                                                                                                                                            }
                                                                                                                                            else
                                                                                                                                            {
                                                                                                                                                if (this.type == 28 || this.type == 30 || this.type == 37 || this.type == 75 || this.type == 102)
                                                                                                                                                {
                                                                                                                                                    Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
                                                                                                                                                    this.position.X = this.position.X + (float)(this.width / 2);
                                                                                                                                                    this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                                                                                    this.width = 22;
                                                                                                                                                    this.height = 22;
                                                                                                                                                    this.position.X = this.position.X - (float)(this.width / 2);
                                                                                                                                                    this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                                                                                    for (int num65 = 0; num65 < 20; num65++)
                                                                                                                                                    {
                                                                                                                                                        Vector2 arg_20F1_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                        int arg_20F1_1 = this.width;
                                                                                                                                                        int arg_20F1_2 = this.height;
                                                                                                                                                        int arg_20F1_3 = 31;
                                                                                                                                                        float arg_20F1_4 = 0f;
                                                                                                                                                        float arg_20F1_5 = 0f;
                                                                                                                                                        int arg_20F1_6 = 100;
                                                                                                                                                        Color newColor = default(Color);
                                                                                                                                                        int num66 = Dust.NewDust(arg_20F1_0, arg_20F1_1, arg_20F1_2, arg_20F1_3, arg_20F1_4, arg_20F1_5, arg_20F1_6, newColor, 1.5f);
                                                                                                                                                        Dust expr_2100 = Main.dust[num66];
                                                                                                                                                        expr_2100.velocity *= 1.4f;
                                                                                                                                                    }
                                                                                                                                                    for (int num67 = 0; num67 < 10; num67++)
                                                                                                                                                    {
                                                                                                                                                        Vector2 arg_216C_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                        int arg_216C_1 = this.width;
                                                                                                                                                        int arg_216C_2 = this.height;
                                                                                                                                                        int arg_216C_3 = 6;
                                                                                                                                                        float arg_216C_4 = 0f;
                                                                                                                                                        float arg_216C_5 = 0f;
                                                                                                                                                        int arg_216C_6 = 100;
                                                                                                                                                        Color newColor = default(Color);
                                                                                                                                                        int num68 = Dust.NewDust(arg_216C_0, arg_216C_1, arg_216C_2, arg_216C_3, arg_216C_4, arg_216C_5, arg_216C_6, newColor, 2.5f);
                                                                                                                                                        Main.dust[num68].noGravity = true;
                                                                                                                                                        Dust expr_2189 = Main.dust[num68];
                                                                                                                                                        expr_2189.velocity *= 5f;
                                                                                                                                                        Vector2 arg_21E1_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                        int arg_21E1_1 = this.width;
                                                                                                                                                        int arg_21E1_2 = this.height;
                                                                                                                                                        int arg_21E1_3 = 6;
                                                                                                                                                        float arg_21E1_4 = 0f;
                                                                                                                                                        float arg_21E1_5 = 0f;
                                                                                                                                                        int arg_21E1_6 = 100;
                                                                                                                                                        newColor = default(Color);
                                                                                                                                                        num68 = Dust.NewDust(arg_21E1_0, arg_21E1_1, arg_21E1_2, arg_21E1_3, arg_21E1_4, arg_21E1_5, arg_21E1_6, newColor, 1.5f);
                                                                                                                                                        Dust expr_21F0 = Main.dust[num68];
                                                                                                                                                        expr_21F0.velocity *= 3f;
                                                                                                                                                    }
                                                                                                                                                    Vector2 arg_224C_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    Vector2 vector2 = default(Vector2);
                                                                                                                                                    int num69 = Gore.NewGore(arg_224C_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                    Gore expr_225B = Main.gore[num69];
                                                                                                                                                    expr_225B.velocity *= 0.4f;
                                                                                                                                                    Gore expr_227D_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_227D_cp_0.velocity.X = expr_227D_cp_0.velocity.X + 1f;
                                                                                                                                                    Gore expr_229B_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_229B_cp_0.velocity.Y = expr_229B_cp_0.velocity.Y + 1f;
                                                                                                                                                    Vector2 arg_22E4_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    vector2 = default(Vector2);
                                                                                                                                                    num69 = Gore.NewGore(arg_22E4_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                    Gore expr_22F3 = Main.gore[num69];
                                                                                                                                                    expr_22F3.velocity *= 0.4f;
                                                                                                                                                    Gore expr_2315_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_2315_cp_0.velocity.X = expr_2315_cp_0.velocity.X - 1f;
                                                                                                                                                    Gore expr_2333_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_2333_cp_0.velocity.Y = expr_2333_cp_0.velocity.Y + 1f;
                                                                                                                                                    Vector2 arg_237C_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    vector2 = default(Vector2);
                                                                                                                                                    num69 = Gore.NewGore(arg_237C_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                    Gore expr_238B = Main.gore[num69];
                                                                                                                                                    expr_238B.velocity *= 0.4f;
                                                                                                                                                    Gore expr_23AD_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_23AD_cp_0.velocity.X = expr_23AD_cp_0.velocity.X + 1f;
                                                                                                                                                    Gore expr_23CB_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_23CB_cp_0.velocity.Y = expr_23CB_cp_0.velocity.Y - 1f;
                                                                                                                                                    Vector2 arg_2414_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                    vector2 = default(Vector2);
                                                                                                                                                    num69 = Gore.NewGore(arg_2414_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                    Gore expr_2423 = Main.gore[num69];
                                                                                                                                                    expr_2423.velocity *= 0.4f;
                                                                                                                                                    Gore expr_2445_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_2445_cp_0.velocity.X = expr_2445_cp_0.velocity.X - 1f;
                                                                                                                                                    Gore expr_2463_cp_0 = Main.gore[num69];
                                                                                                                                                    expr_2463_cp_0.velocity.Y = expr_2463_cp_0.velocity.Y - 1f;
                                                                                                                                                }
                                                                                                                                                else
                                                                                                                                                {
                                                                                                                                                    if (this.type == 29 || this.type == 108)
                                                                                                                                                    {
                                                                                                                                                        Main.PlaySound(2, (int)this.position.X, (int)this.position.Y, 14);
                                                                                                                                                        if (this.type == 29)
                                                                                                                                                        {
                                                                                                                                                            this.position.X = this.position.X + (float)(this.width / 2);
                                                                                                                                                            this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                                                                                            this.width = 200;
                                                                                                                                                            this.height = 200;
                                                                                                                                                            this.position.X = this.position.X - (float)(this.width / 2);
                                                                                                                                                            this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                                                                                        }
                                                                                                                                                        for (int num70 = 0; num70 < 50; num70++)
                                                                                                                                                        {
                                                                                                                                                            Vector2 arg_2588_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                            int arg_2588_1 = this.width;
                                                                                                                                                            int arg_2588_2 = this.height;
                                                                                                                                                            int arg_2588_3 = 31;
                                                                                                                                                            float arg_2588_4 = 0f;
                                                                                                                                                            float arg_2588_5 = 0f;
                                                                                                                                                            int arg_2588_6 = 100;
                                                                                                                                                            Color newColor = default(Color);
                                                                                                                                                            int num71 = Dust.NewDust(arg_2588_0, arg_2588_1, arg_2588_2, arg_2588_3, arg_2588_4, arg_2588_5, arg_2588_6, newColor, 2f);
                                                                                                                                                            Dust expr_2597 = Main.dust[num71];
                                                                                                                                                            expr_2597.velocity *= 1.4f;
                                                                                                                                                        }
                                                                                                                                                        for (int num72 = 0; num72 < 80; num72++)
                                                                                                                                                        {
                                                                                                                                                            Vector2 arg_2603_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                            int arg_2603_1 = this.width;
                                                                                                                                                            int arg_2603_2 = this.height;
                                                                                                                                                            int arg_2603_3 = 6;
                                                                                                                                                            float arg_2603_4 = 0f;
                                                                                                                                                            float arg_2603_5 = 0f;
                                                                                                                                                            int arg_2603_6 = 100;
                                                                                                                                                            Color newColor = default(Color);
                                                                                                                                                            int num73 = Dust.NewDust(arg_2603_0, arg_2603_1, arg_2603_2, arg_2603_3, arg_2603_4, arg_2603_5, arg_2603_6, newColor, 3f);
                                                                                                                                                            Main.dust[num73].noGravity = true;
                                                                                                                                                            Dust expr_2620 = Main.dust[num73];
                                                                                                                                                            expr_2620.velocity *= 5f;
                                                                                                                                                            Vector2 arg_2678_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                            int arg_2678_1 = this.width;
                                                                                                                                                            int arg_2678_2 = this.height;
                                                                                                                                                            int arg_2678_3 = 6;
                                                                                                                                                            float arg_2678_4 = 0f;
                                                                                                                                                            float arg_2678_5 = 0f;
                                                                                                                                                            int arg_2678_6 = 100;
                                                                                                                                                            newColor = default(Color);
                                                                                                                                                            num73 = Dust.NewDust(arg_2678_0, arg_2678_1, arg_2678_2, arg_2678_3, arg_2678_4, arg_2678_5, arg_2678_6, newColor, 2f);
                                                                                                                                                            Dust expr_2687 = Main.dust[num73];
                                                                                                                                                            expr_2687.velocity *= 3f;
                                                                                                                                                        }
                                                                                                                                                        for (int num74 = 0; num74 < 2; num74++)
                                                                                                                                                        {
                                                                                                                                                            Vector2 arg_270B_0 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
                                                                                                                                                            Vector2 vector2 = default(Vector2);
                                                                                                                                                            int num75 = Gore.NewGore(arg_270B_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                            Main.gore[num75].scale = 1.5f;
                                                                                                                                                            Gore expr_2731_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_2731_cp_0.velocity.X = expr_2731_cp_0.velocity.X + 1.5f;
                                                                                                                                                            Gore expr_274F_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_274F_cp_0.velocity.Y = expr_274F_cp_0.velocity.Y + 1.5f;
                                                                                                                                                            Vector2 arg_27B8_0 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
                                                                                                                                                            vector2 = default(Vector2);
                                                                                                                                                            num75 = Gore.NewGore(arg_27B8_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                            Main.gore[num75].scale = 1.5f;
                                                                                                                                                            Gore expr_27DE_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_27DE_cp_0.velocity.X = expr_27DE_cp_0.velocity.X - 1.5f;
                                                                                                                                                            Gore expr_27FC_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_27FC_cp_0.velocity.Y = expr_27FC_cp_0.velocity.Y + 1.5f;
                                                                                                                                                            Vector2 arg_2865_0 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
                                                                                                                                                            vector2 = default(Vector2);
                                                                                                                                                            num75 = Gore.NewGore(arg_2865_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                            Main.gore[num75].scale = 1.5f;
                                                                                                                                                            Gore expr_288B_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_288B_cp_0.velocity.X = expr_288B_cp_0.velocity.X + 1.5f;
                                                                                                                                                            Gore expr_28A9_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_28A9_cp_0.velocity.Y = expr_28A9_cp_0.velocity.Y - 1.5f;
                                                                                                                                                            Vector2 arg_2912_0 = new Vector2(this.position.X + (float)(this.width / 2) - 24f, this.position.Y + (float)(this.height / 2) - 24f);
                                                                                                                                                            vector2 = default(Vector2);
                                                                                                                                                            num75 = Gore.NewGore(arg_2912_0, vector2, Main.rand.Next(61, 64), 1f);
                                                                                                                                                            Main.gore[num75].scale = 1.5f;
                                                                                                                                                            Gore expr_2938_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_2938_cp_0.velocity.X = expr_2938_cp_0.velocity.X - 1.5f;
                                                                                                                                                            Gore expr_2956_cp_0 = Main.gore[num75];
                                                                                                                                                            expr_2956_cp_0.velocity.Y = expr_2956_cp_0.velocity.Y - 1.5f;
                                                                                                                                                        }
                                                                                                                                                        this.position.X = this.position.X + (float)(this.width / 2);
                                                                                                                                                        this.position.Y = this.position.Y + (float)(this.height / 2);
                                                                                                                                                        this.width = 10;
                                                                                                                                                        this.height = 10;
                                                                                                                                                        this.position.X = this.position.X - (float)(this.width / 2);
                                                                                                                                                        this.position.Y = this.position.Y - (float)(this.height / 2);
                                                                                                                                                    }
                                                                                                                                                    else
                                                                                                                                                    {
                                                                                                                                                        if (this.type == 69)
                                                                                                                                                        {
                                                                                                                                                            Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                                                            for (int num76 = 0; num76 < 5; num76++)
                                                                                                                                                            {
                                                                                                                                                                Vector2 arg_2A6B_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                                int arg_2A6B_1 = this.width;
                                                                                                                                                                int arg_2A6B_2 = this.height;
                                                                                                                                                                int arg_2A6B_3 = 13;
                                                                                                                                                                float arg_2A6B_4 = 0f;
                                                                                                                                                                float arg_2A6B_5 = 0f;
                                                                                                                                                                int arg_2A6B_6 = 0;
                                                                                                                                                                Color newColor = default(Color);
                                                                                                                                                                Dust.NewDust(arg_2A6B_0, arg_2A6B_1, arg_2A6B_2, arg_2A6B_3, arg_2A6B_4, arg_2A6B_5, arg_2A6B_6, newColor, 1f);
                                                                                                                                                            }
                                                                                                                                                            for (int num77 = 0; num77 < 30; num77++)
                                                                                                                                                            {
                                                                                                                                                                Vector2 arg_2AC7_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                                int arg_2AC7_1 = this.width;
                                                                                                                                                                int arg_2AC7_2 = this.height;
                                                                                                                                                                int arg_2AC7_3 = 33;
                                                                                                                                                                float arg_2AC7_4 = 0f;
                                                                                                                                                                float arg_2AC7_5 = -2f;
                                                                                                                                                                int arg_2AC7_6 = 0;
                                                                                                                                                                Color newColor = default(Color);
                                                                                                                                                                int num78 = Dust.NewDust(arg_2AC7_0, arg_2AC7_1, arg_2AC7_2, arg_2AC7_3, arg_2AC7_4, arg_2AC7_5, arg_2AC7_6, newColor, 1.1f);
                                                                                                                                                                Main.dust[num78].alpha = 100;
                                                                                                                                                                Dust expr_2AEA_cp_0 = Main.dust[num78];
                                                                                                                                                                expr_2AEA_cp_0.velocity.X = expr_2AEA_cp_0.velocity.X * 1.5f;
                                                                                                                                                                Dust expr_2B03 = Main.dust[num78];
                                                                                                                                                                expr_2B03.velocity *= 3f;
                                                                                                                                                            }
                                                                                                                                                        }
                                                                                                                                                        else
                                                                                                                                                        {
                                                                                                                                                            if (this.type == 70)
                                                                                                                                                            {
                                                                                                                                                                Main.PlaySound(13, (int)this.position.X, (int)this.position.Y, 1);
                                                                                                                                                                for (int num79 = 0; num79 < 5; num79++)
                                                                                                                                                                {
                                                                                                                                                                    Vector2 arg_2BA1_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                                    int arg_2BA1_1 = this.width;
                                                                                                                                                                    int arg_2BA1_2 = this.height;
                                                                                                                                                                    int arg_2BA1_3 = 13;
                                                                                                                                                                    float arg_2BA1_4 = 0f;
                                                                                                                                                                    float arg_2BA1_5 = 0f;
                                                                                                                                                                    int arg_2BA1_6 = 0;
                                                                                                                                                                    Color newColor = default(Color);
                                                                                                                                                                    Dust.NewDust(arg_2BA1_0, arg_2BA1_1, arg_2BA1_2, arg_2BA1_3, arg_2BA1_4, arg_2BA1_5, arg_2BA1_6, newColor, 1f);
                                                                                                                                                                }
                                                                                                                                                                for (int num80 = 0; num80 < 30; num80++)
                                                                                                                                                                {
                                                                                                                                                                    Vector2 arg_2BFD_0 = new Vector2(this.position.X, this.position.Y);
                                                                                                                                                                    int arg_2BFD_1 = this.width;
                                                                                                                                                                    int arg_2BFD_2 = this.height;
                                                                                                                                                                    int arg_2BFD_3 = 52;
                                                                                                                                                                    float arg_2BFD_4 = 0f;
                                                                                                                                                                    float arg_2BFD_5 = -2f;
                                                                                                                                                                    int arg_2BFD_6 = 0;
                                                                                                                                                                    Color newColor = default(Color);
                                                                                                                                                                    int num81 = Dust.NewDust(arg_2BFD_0, arg_2BFD_1, arg_2BFD_2, arg_2BFD_3, arg_2BFD_4, arg_2BFD_5, arg_2BFD_6, newColor, 1.1f);
                                                                                                                                                                    Main.dust[num81].alpha = 100;
                                                                                                                                                                    Dust expr_2C20_cp_0 = Main.dust[num81];
                                                                                                                                                                    expr_2C20_cp_0.velocity.X = expr_2C20_cp_0.velocity.X * 1.5f;
                                                                                                                                                                    Dust expr_2C39 = Main.dust[num81];
                                                                                                                                                                    expr_2C39.velocity *= 3f;
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
            if (this.owner == Main.myPlayer)
            {
                if (this.type == 28 || this.type == 29 || this.type == 37 || this.type == 75 || this.type == 108)
                {
                    int num82 = 3;
                    if (this.type == 29)
                    {
                        num82 = 7;
                    }
                    if (this.type == 108)
                    {
                        num82 = 10;
                    }
                    int num83 = (int)(this.position.X / 16f - (float)num82);
                    int num84 = (int)(this.position.X / 16f + (float)num82);
                    int num85 = (int)(this.position.Y / 16f - (float)num82);
                    int num86 = (int)(this.position.Y / 16f + (float)num82);
                    if (num83 < 0)
                    {
                        num83 = 0;
                    }
                    if (num84 > Main.maxTilesX)
                    {
                        num84 = Main.maxTilesX;
                    }
                    if (num85 < 0)
                    {
                        num85 = 0;
                    }
                    if (num86 > Main.maxTilesY)
                    {
                        num86 = Main.maxTilesY;
                    }
                    bool flag = false;
                    for (int num87 = num83; num87 <= num84; num87++)
                    {
                        for (int num88 = num85; num88 <= num86; num88++)
                        {
                            float num89 = Math.Abs((float)num87 - this.position.X / 16f);
                            float num90 = Math.Abs((float)num88 - this.position.Y / 16f);
                            double num91 = Math.Sqrt((double)(num89 * num89 + num90 * num90));
                            if (num91 < (double)num82 && Main.tile[num87, num88] != null && Main.tile[num87, num88].wall == 0)
                            {
                                flag = true;
                                break;
                            }
                        }
                    }
                    for (int num92 = num83; num92 <= num84; num92++)
                    {
                        for (int num93 = num85; num93 <= num86; num93++)
                        {
                            float num94 = Math.Abs((float)num92 - this.position.X / 16f);
                            float num95 = Math.Abs((float)num93 - this.position.Y / 16f);
                            double num96 = Math.Sqrt((double)(num94 * num94 + num95 * num95));
                            if (num96 < (double)num82)
                            {
                                bool flag2 = true;
                                if (Main.tile[num92, num93] != null && Main.tile[num92, num93].active)
                                {
                                    flag2 = true;
                                    if (Main.tileDungeon[(int)Main.tile[num92, num93].type] || Main.tile[num92, num93].type == 21 || Main.tile[num92, num93].type == 26 || Main.tile[num92, num93].type == 107 || Main.tile[num92, num93].type == 108 || Main.tile[num92, num93].type == 111)
                                    {
                                        flag2 = false;
                                    }
                                    if (!Main.hardMode && Main.tile[num92, num93].type == 58)
                                    {
                                        flag2 = false;
                                    }
                                    if (flag2)
                                    {
                                        WorldGen.KillTile(num92, num93, false, false, false);
                                        if (!Main.tile[num92, num93].active && Main.netMode != 0)
                                        {
                                            NetMessage.SendData(17, -1, -1, "", 0, (float)num92, (float)num93, 0f, 0);
                                        }
                                    }
                                }
                                if (flag2)
                                {
                                    for (int num97 = num92 - 1; num97 <= num92 + 1; num97++)
                                    {
                                        for (int num98 = num93 - 1; num98 <= num93 + 1; num98++)
                                        {
                                            if (Main.tile[num97, num98] != null && Main.tile[num97, num98].wall > 0 && flag)
                                            {
                                                WorldGen.KillWall(num97, num98, false);
                                                if (Main.tile[num97, num98].wall == 0 && Main.netMode != 0)
                                                {
                                                    NetMessage.SendData(17, -1, -1, "", 2, (float)num97, (float)num98, 0f, 0);
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (Main.netMode != 0)
                {
                    NetMessage.SendData(29, -1, -1, "", this.identity, (float)this.owner, 0f, 0f, 0);
                }
                int num99 = -1;
                if (this.aiStyle == 10)
                {
                    int num100 = (int)(this.position.X + (float)(this.width / 2)) / 16;
                    int num101 = (int)(this.position.Y + (float)(this.width / 2)) / 16;
                    int num102 = 0;
                    int num103 = 2;
                    if (this.type == 109)
                    {
                        num102 = 147;
                        num103 = 0;
                    }
                    if (this.type == 31)
                    {
                        num102 = 53;
                        num103 = 0;
                    }
                    if (this.type == 42)
                    {
                        num102 = 53;
                        num103 = 0;
                    }
                    if (this.type == 56)
                    {
                        num102 = 112;
                        num103 = 0;
                    }
                    if (this.type == 65)
                    {
                        num102 = 112;
                        num103 = 0;
                    }
                    if (this.type == 67)
                    {
                        num102 = 116;
                        num103 = 0;
                    }
                    if (this.type == 68)
                    {
                        num102 = 116;
                        num103 = 0;
                    }
                    if (this.type == 71)
                    {
                        num102 = 123;
                        num103 = 0;
                    }
                    if (this.type == 39)
                    {
                        num102 = 59;
                        num103 = 176;
                    }
                    if (this.type == 40)
                    {
                        num102 = 57;
                        num103 = 172;
                    }
                    if (!Main.tile[num100, num101].active)
                    {
                        WorldGen.PlaceTile(num100, num101, num102, false, true, -1, 0);
                        if (Main.tile[num100, num101].active && (int)Main.tile[num100, num101].type == num102)
                        {
                            NetMessage.SendData(17, -1, -1, "", 1, (float)num100, (float)num101, (float)num102, 0);
                        }
                        else
                        {
                            if (num103 > 0)
                            {
                                num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num103, 1, false, 0);
                            }
                        }
                    }
                    else
                    {
                        if (num103 > 0)
                        {
                            num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, num103, 1, false, 0);
                        }
                    }
                }
                if (this.type == 1 && Main.rand.Next(3) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
                }
                if (this.type == 103 && Main.rand.Next(6) == 0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 545, 1, false, 0);
                    }
                    else
                    {
                        num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
                    }
                }
                if (this.type == 2 && Main.rand.Next(3) == 0)
                {
                    if (Main.rand.Next(3) == 0)
                    {
                        num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 41, 1, false, 0);
                    }
                    else
                    {
                        num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 40, 1, false, 0);
                    }
                }
                if (this.type == 91 && Main.rand.Next(6) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 516, 1, false, 0);
                }
                if (this.type == 50 && Main.rand.Next(3) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 282, 1, false, 0);
                }
                if (this.type == 53 && Main.rand.Next(3) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 286, 1, false, 0);
                }
                if (this.type == 48 && Main.rand.Next(2) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 279, 1, false, 0);
                }
                if (this.type == 54 && Main.rand.Next(2) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 287, 1, false, 0);
                }
                if (this.type == 3 && Main.rand.Next(2) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 42, 1, false, 0);
                }
                if (this.type == 4 && Main.rand.Next(4) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 47, 1, false, 0);
                }
                if (this.type == 12 && this.damage > 100)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 75, 1, false, 0);
                }
                if (this.type == 69 || this.type == 70)
                {
                    int num104 = (int)(this.position.X + (float)(this.width / 2)) / 16;
                    int num105 = (int)(this.position.Y + (float)(this.height / 2)) / 16;
                    for (int num106 = num104 - 4; num106 <= num104 + 4; num106++)
                    {
                        for (int num107 = num105 - 4; num107 <= num105 + 4; num107++)
                        {
                            if (Math.Abs(num106 - num104) + Math.Abs(num107 - num105) < 6)
                            {
                                if (this.type == 69)
                                {
                                    if (Main.tile[num106, num107].type == 2)
                                    {
                                        Main.tile[num106, num107].type = 109;
                                        WorldGen.SquareTileFrame(num106, num107, true);
                                        NetMessage.SendTileSquare(-1, num106, num107, 1);
                                    }
                                    else
                                    {
                                        if (Main.tile[num106, num107].type == 1)
                                        {
                                            Main.tile[num106, num107].type = 117;
                                            WorldGen.SquareTileFrame(num106, num107, true);
                                            NetMessage.SendTileSquare(-1, num106, num107, 1);
                                        }
                                        else
                                        {
                                            if (Main.tile[num106, num107].type == 53)
                                            {
                                                Main.tile[num106, num107].type = 116;
                                                WorldGen.SquareTileFrame(num106, num107, true);
                                                NetMessage.SendTileSquare(-1, num106, num107, 1);
                                            }
                                            else
                                            {
                                                if (Main.tile[num106, num107].type == 23)
                                                {
                                                    Main.tile[num106, num107].type = 109;
                                                    WorldGen.SquareTileFrame(num106, num107, true);
                                                    NetMessage.SendTileSquare(-1, num106, num107, 1);
                                                }
                                                else
                                                {
                                                    if (Main.tile[num106, num107].type == 25)
                                                    {
                                                        Main.tile[num106, num107].type = 117;
                                                        WorldGen.SquareTileFrame(num106, num107, true);
                                                        NetMessage.SendTileSquare(-1, num106, num107, 1);
                                                    }
                                                    else
                                                    {
                                                        if (Main.tile[num106, num107].type == 112)
                                                        {
                                                            Main.tile[num106, num107].type = 116;
                                                            WorldGen.SquareTileFrame(num106, num107, true);
                                                            NetMessage.SendTileSquare(-1, num106, num107, 1);
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (Main.tile[num106, num107].type == 2)
                                    {
                                        Main.tile[num106, num107].type = 23;
                                        WorldGen.SquareTileFrame(num106, num107, true);
                                        NetMessage.SendTileSquare(-1, num106, num107, 1);
                                    }
                                    else
                                    {
                                        if (Main.tile[num106, num107].type == 1)
                                        {
                                            Main.tile[num106, num107].type = 25;
                                            WorldGen.SquareTileFrame(num106, num107, true);
                                            NetMessage.SendTileSquare(-1, num106, num107, 1);
                                        }
                                        else
                                        {
                                            if (Main.tile[num106, num107].type == 53)
                                            {
                                                Main.tile[num106, num107].type = 112;
                                                WorldGen.SquareTileFrame(num106, num107, true);
                                                NetMessage.SendTileSquare(-1, num106, num107, 1);
                                            }
                                            else
                                            {
                                                if (Main.tile[num106, num107].type == 109)
                                                {
                                                    Main.tile[num106, num107].type = 23;
                                                    WorldGen.SquareTileFrame(num106, num107, true);
                                                    NetMessage.SendTileSquare(-1, num106, num107, 1);
                                                }
                                                else
                                                {
                                                    if (Main.tile[num106, num107].type == 117)
                                                    {
                                                        Main.tile[num106, num107].type = 25;
                                                        WorldGen.SquareTileFrame(num106, num107, true);
                                                        NetMessage.SendTileSquare(-1, num106, num107, 1);
                                                    }
                                                    else
                                                    {
                                                        if (Main.tile[num106, num107].type == 116)
                                                        {
                                                            Main.tile[num106, num107].type = 112;
                                                            WorldGen.SquareTileFrame(num106, num107, true);
                                                            NetMessage.SendTileSquare(-1, num106, num107, 1);
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
                if (this.type == 21 && Main.rand.Next(2) == 0)
                {
                    num99 = Item.NewItem((int)this.position.X, (int)this.position.Y, this.width, this.height, 154, 1, false, 0);
                }
                if (Main.netMode == 1 && num99 >= 0)
                {
                    NetMessage.SendData(21, -1, -1, "", num99, 0f, 0f, 0f, 0);
                }
            }
            this.active = false;
        }
        public Color GetAlpha(Color newColor)
        {
            if (this.type == 34 || this.type == 15 || this.type == 93 || this.type == 94 || this.type == 95 || this.type == 96 || (this.type == 102 && this.alpha < 255))
            {
                return new Color(200, 200, 200, 25);
            }
            if (this.type == 83 || this.type == 88 || this.type == 89 || this.type == 90 || this.type == 100 || this.type == 104)
            {
                if (this.alpha < 200)
                {
                    return new Color(255 - this.alpha, 255 - this.alpha, 255 - this.alpha, 0);
                }
                return new Color(0, 0, 0, 0);
            }
            else
            {
                if (this.type == 34 || this.type == 35 || this.type == 15 || this.type == 19 || this.type == 44 || this.type == 45)
                {
                    return Color.White;
                }
                int r;
                int g;
                int b;
                if (this.type == 79)
                {
                    r = Main.DiscoR;
                    g = Main.DiscoG;
                    b = Main.DiscoB;
                    return default(Color);
                }
                if (this.type == 9 || this.type == 15 || this.type == 34 || this.type == 50 || this.type == 53 || this.type == 76 || this.type == 77 || this.type == 78 || this.type == 92 || this.type == 91)
                {
                    r = (int)newColor.R - this.alpha / 3;
                    g = (int)newColor.G - this.alpha / 3;
                    b = (int)newColor.B - this.alpha / 3;
                }
                else
                {
                    if (this.type == 16 || this.type == 18 || this.type == 44 || this.type == 45)
                    {
                        r = (int)newColor.R;
                        g = (int)newColor.G;
                        b = (int)newColor.B;
                    }
                    else
                    {
                        if (this.type == 12 || this.type == 72 || this.type == 86 || this.type == 87)
                        {
                            return new Color(255, 255, 255, (int)newColor.A - this.alpha);
                        }
                        r = (int)newColor.R - this.alpha;
                        g = (int)newColor.G - this.alpha;
                        b = (int)newColor.B - this.alpha;
                    }
                }
                int num = (int)newColor.A - this.alpha;
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
        }
    }
}
