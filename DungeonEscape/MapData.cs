﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System.Net.Mime;

namespace DungeonEscape
{
    internal static class MapData
    {
        public static bool testFloorLoaded = false;

        public static int[,] testFloor = new int[16, 16]
        {
            { 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 4, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 7, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 2, 8 }
        };

        public static bool levelOneLoaded = false;

        public static int[,] levelOne = new int[16, 16]
        {
            { 0, 0, 0, 7, 2, 2, 2, 8, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 7, 2, 2, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 1, 2, 2, 2, 8, 0, 7, 2, 2, 8 },
            { 0, 5, 1, 6, 1, 1, 1, 1, 1, 1, 6, 0, 5, 3, 1, 6 },
            { 0, 5, 1, 6, 1, 1, 1, 7, 8, 1, 6, 0, 5, 1, 1, 6 },
            { 0, 5, 1, 8, 2, 2, 2, 5, 6, 1, 6, 0, 2, 7, 1, 6 },
            { 7, 2, 1, 2, 2, 8, 0, 7, 2, 1, 2, 8, 0, 5, 1, 6 },
            { 5, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 6, 0, 5, 1, 6 },
            { 5, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 2, 2, 2, 1, 6 },
            { 5, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 1, 1, 1, 1, 6 },
            { 5, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 8, 2, 2, 2, 2 },
            { 5, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 6, 0, 0, 0, 0 },
            { 2, 7, 2, 2, 1, 6, 0, 5, 1, 1, 1, 6, 0, 0, 0, 0 },
            { 0, 5, 4, 1, 1, 6, 0, 2, 2, 2, 2, 2, 0, 0, 0, 0 },
            { 0, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public static bool levelTwoLoaded = false;

        public static int[,] levelTwo = new int[24, 24]
        {
            { 0, 0, 7, 2, 2, 2, 2, 2, 2, 2, 2, 8, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 7, 2, 2, 2, 2, 8, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 5, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 5, 1, 1, 4, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 5, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 2, 2, 2, 2, 2, 2, 8, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 6, 1, 1, 2, 7, 2, 2, 1, 7, 2, 2, 8, 2, 2, 2, 2, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 2, 2, 2, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 2, 2, 2, 8, 0, 0 },
            { 0, 0, 7, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1, 1, 5, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 7, 2, 2, 2, 8, 1, 1, 1, 1, 1, 1, 2, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 9, 0, 0, 0, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 7, 2, 2, 2, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 7, 2, 2, 1, 2, 8, 2, 2, 2, 2, 2, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 5, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 5, 1, 3, 1, 1, 6, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 5, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0 },
            { 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0 }
        };

        public static bool levelThreeLoaded = false;

        public static int[,] levelThree = new int[30, 30]
        {
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 7, 2, 2, 2, 2, 8, 0 },
            { 0, 7, 2, 2, 2, 2, 2, 2, 2, 2, 8, 0, 7, 2, 2, 2, 2, 2, 2, 8, 0, 0, 0, 5, 1, 1, 1, 1, 6, 0 },
            { 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 5, 1, 1, 1, 1, 6, 0 },
            { 0, 5, 1, 1, 1, 4, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 5, 1, 1, 1, 1, 6, 0 },
            { 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 0 },
            { 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 2, 2, 2, 2, 2, 2, 1, 2, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 1, 1, 6, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 6, 1, 1, 1, 1, 1, 1, 1, 6, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 7, 2, 2, 5, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 2, 2, 1, 2, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 5, 1, 1, 2, 2, 2, 2, 2, 2, 8, 2, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 5, 1, 1, 1, 6, 1, 1, 2, 7, 2, 2, 1, 7, 2, 2, 8, 2, 2, 2, 2, 2, 2, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 5, 1, 1, 1, 6, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 2, 8, 1, 2, 2, 2, 2, 1, 2, 2, 2, 1, 1, 5, 1, 1, 1, 5, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 5, 1, 1, 2, 2, 2, 2, 2, 8, 0, 0, 0},
            { 0, 0, 7, 2, 1, 1, 1, 2, 2, 1, 2, 2, 2, 2, 2, 2, 2, 1, 5, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 5, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 7, 2, 2, 2, 8, 1, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 6, 0, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 9, 0, 0, 0, 10, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 2, 2, 2, 8, 0, 0},
            { 0, 0, 5, 1, 1, 1, 1, 2, 2, 2, 2, 2, 1, 1, 1, 1, 1, 2, 2, 2, 2, 2, 8, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 0, 5, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 7, 2, 8, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 7, 2, 2, 1, 1, 1, 1, 1, 8, 2, 2, 2, 2, 0, 10, 1, 1, 1, 2, 2, 8, 1, 1, 1, 3, 1, 6, 0, 0},
            { 0, 5, 1, 1, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 2, 2, 2, 1, 1, 1, 6, 1, 1, 1, 1, 1, 6, 0, 0 },
            { 0, 7, 2, 2, 1, 2, 8, 2, 2, 2, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 2, 2, 2, 2, 2, 2, 2, 0 },
            { 0, 5, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 5, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0, 5, 1, 1, 1, 1, 1, 6, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0, 2, 2, 2, 2, 2, 2, 2, 0, 0, 0, 0, 0, 0, 0, 0 },
            { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 }
        };

        public static Vector2 levelOneMinClamp = new Vector2(-32, -196);
        public static Vector2 levelOneMaxClamp = new Vector2(0, 0);

        public static Vector2 levelTwoMinClamp = new Vector2(-272, -448);
        public static Vector2 levelTwoMaxClamp = new Vector2(0, 0);

        public static Vector2 levelThreeMinClamp = new Vector2(-464, -640);
        public static Vector2 levelThreeMaxClamp = new Vector2(0, 0);

        public static bool playerStartOne = false;
        public static bool playerStartTwo = false;
        public static bool playerStartThree = false;

        public static bool guardsOne = false;
        public static bool guardsTwo = false;
        public static bool guardsThree = false;

        static int levelOneGuards = 2;
        static int levelTwoGuards = 5;
        static int levelThreeGuards = 7;

        public static List<Goblin> LevelOneGuardsData(List<Goblin> guardList, Texture2D goblinTxr)
        {
            guardList.Clear();

            guardList = new List<Goblin>();

            if(guardList.Count != levelOneGuards)
            {
                guardList.Add(new Goblin(new Point(5, 2), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(9, 12), goblinTxr, 3, 8));
            }

            return guardList;
        }

        public static List<Goblin> LevelTwoGuardsData(List<Goblin> guardList, Texture2D goblinTxr)
        {
            guardList.Clear();

            guardList = new List<Goblin>();

            if (guardList.Count != levelTwoGuards)
            {
                guardList.Add(new Goblin(new Point(9, 12), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(17, 14), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(15, 21), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(5, 9), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(13, 10), goblinTxr, 3, 8));
            }

            return guardList;
        }

        public static List<Goblin> LevelThreeGuardsData(List<Goblin> guardList, Texture2D goblinTxr)
        {
            guardList.Clear();

            guardList = new List<Goblin>();

            if (guardList.Count != levelThreeGuards)
            {
                guardList.Add(new Goblin(new Point(3, 3), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(3, 12), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(15, 3), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(24, 7), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(18, 27), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(4, 26), goblinTxr, 3, 8));
                guardList.Add(new Goblin(new Point(19, 25), goblinTxr, 3, 8));
            }

            return guardList;
        }

        public static void ResetGame()
        {
            levelOneLoaded = false;
            levelTwoLoaded = false;
            levelThreeLoaded = false;

            playerStartOne = false;
            playerStartTwo = false;
            playerStartThree = false;

            guardsOne = false;
            guardsTwo = false;
            guardsThree = false;
        }
    }
}
