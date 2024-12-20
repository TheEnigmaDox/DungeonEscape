﻿using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace DungeonEscape
{
    internal class Map
    {
        private int[,] m_Cells;
        private int m_width;
        private int m_height;

        public Vector2 MapSize
        {
            get
            {
                return new Vector2(m_width, m_height);
            }
        }

        public Map(int[,] floorPlan) 
        { 
            m_width = floorPlan.GetLength(0);
            m_height = floorPlan.GetLength(1);

            m_Cells = new int[m_width, m_height];
            for (int x = 0; x < m_width; x++)
            { 
                for (int y = 0; y < m_height; y++)
                {
                    m_Cells[x, y] = floorPlan[y, x];
                }
            }
        }

        public Vector2 UpdateMe(Vector2 canvasPos, Vector2 minClamp, Vector2 maxClamp)
        {
            // 16, 16 -> 2, 6 (x32) -> 64, 192  -> -48 (3/4), -192
            // 24, 24 -> 3, 9 (x32) -> 96, 224

            canvasPos.X = MathHelper.Clamp(canvasPos.X, minClamp.X, maxClamp.X);
            canvasPos.Y = MathHelper.Clamp(canvasPos.Y, minClamp.Y, maxClamp.Y);

            return canvasPos;
        }

        public void DrawMe(SpriteBatch sBatch, List<Texture2D> tiles)
        {
            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    sBatch.Draw(tiles[m_Cells[x, y]],
                        new Vector2(x * (tiles[0].Width), y * (tiles[0].Height)),
                        null,
                        Color.White,
                        0f,
                        Vector2.Zero,
                        1f,
                        SpriteEffects.None,
                        0f);

                    //sBatch.DrawString(Game1.debugFont,
                    //    m_Cells[x, y].ToString(),
                    //    new Vector2(x * 16, y * 16),
                    //    Color.White);
                }
            }
        }

        public bool IsWalkable(Point idx, bool isPlayer)
        {
            switch(m_Cells[idx.X, idx.Y])
            {
                case 1:
                case 3:
                    return true;
                case 4:
                    if (isPlayer)
                    {
                        Game1.gameState = Game1.gameState + 1;
                    }
                    return true;
                default:
                    return false;
            }
        }
    }
}
