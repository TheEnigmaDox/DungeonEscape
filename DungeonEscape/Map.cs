using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonEscape
{
    internal class Map
    {
        private int[,] m_Cells;
        private int m_width;
        private int m_height;

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

        public void DrawMe(SpriteBatch sBatch, List<Texture2D> tiles)
        {
            for (int x = 0; x < m_width; x++)
            {
                for (int y = 0; y < m_height; y++)
                {
                    sBatch.Draw(tiles[m_Cells[x, y]],
                        new Vector2(x * tiles[0].Width, y * tiles[0].Height),
                        Color.White);

                    //sBatch.DrawString(Game1.debugFont,
                    //    m_Cells[x, y].ToString(),
                    //    new Vector2(x * 16, y * 16),
                    //    Color.White);
                }
            }
        }

        public bool IsWalkable(Point idx)
        {
            switch(m_Cells[idx.X, idx.Y])
            {
                case 1:
                case 3:
                case 4:
                    return true;
                default:
                    return false;
            }
        }
    }
}
