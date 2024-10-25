using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace DungeonEscape
{
    enum Direction
    {
        North,
        East,
        South,
        West
    }

    internal class GameActor
    {
        protected Point m_position;
        private Texture2D m_texture;

        private int m_frameCount;
        private int m_animeFrame;
        private Rectangle m_sourceRect;

        private float m_updateTrigger;
        private int m_fps;

        private Direction m_facing;

        public Direction Facing
        {
            set
            {
                m_facing = value;
            }
        }

        public Point Position
        {
            get
            {
                return m_position;
            }
        }

        public GameActor(Point startPos, Texture2D txr, int frameCount, int fps)
        {
            m_position = startPos;
            m_texture = txr;

            m_frameCount = frameCount;
            m_animeFrame = 0;
            m_sourceRect = new Rectangle(0, 0, txr.Width / m_frameCount, txr.Height / 4);

            m_updateTrigger = 0;
            m_fps = fps;

            m_facing = Direction.North;
        }

        public void MoveMe(Direction moveDir)
        {
            Facing = moveDir;

            switch (moveDir)
            {
                case Direction.North:
                    m_position.Y--;
                    break;
                case Direction.South:
                    m_position.Y++;
                    break;
                case Direction.West:
                    m_position.X--;
                    break;
                case Direction.East:
                    m_position.X++;
                    break;
            }
        }

        public bool LOS(Point target, Map currMap)
        {
            Point delta, abs, sign, curr;
            int t;

            delta.X = target.X - Position.X;
            delta.Y = target.Y - Position.Y;

            abs.X = Math.Abs(delta.X) * 2;
            abs.Y = Math.Abs(delta.Y) * 2;

            sign.X = Math.Sign(delta.X);
            sign.Y = Math.Sign(delta.Y);

            curr = Position;

            if (abs.X > abs.Y)
            { 
                t = abs.Y - (abs.X >> 1);
                do
                {
                    if (t >= 0)
                    {
                        curr.Y += sign.Y;
                        t -= abs.X;   
                    }

                    curr.X += sign.X;
                    t += abs.Y;

                    if (curr.X == target.X && curr.Y == target.Y)
                    {
                        return true;
                    }
                }
                while (currMap.IsWalkable(curr));

                return false;
            }
            else
            {
                t = abs.X - (abs.Y >> 1);
                do
                {
                    if (t > 0)
                    {
                        curr.X += sign.X;
                        t -= abs.Y;
                    }

                    curr.Y += sign.Y;
                    t -= abs.Y;

                    if (curr.X == target.X && curr.Y == target.Y)
                    {
                        return true;
                    }
                }
                while(currMap.IsWalkable(curr));

                return false;
            }
        }

        public void DrawMe(SpriteBatch sBatch, GameTime gt, int tileWidth, int tileHeight)
        {
            m_updateTrigger += (float)gt.ElapsedGameTime.TotalSeconds * m_fps;

            if(m_updateTrigger >= 1)
            {
                m_updateTrigger = 0;

                m_animeFrame = (m_animeFrame + 1) % m_frameCount;
                m_sourceRect.X = m_animeFrame * m_sourceRect.Width;
            }

            m_sourceRect.Y = (int)m_facing * m_sourceRect.Height;

            sBatch.Draw(m_texture,
                new Vector2(m_position.X * tileWidth, m_position.Y * tileHeight - 4),
                m_sourceRect,
                Color.White,
                0f,
                Vector2.Zero,
                2f,
                SpriteEffects.None,
                0f);
        }
    }
}
