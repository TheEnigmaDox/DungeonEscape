using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace DungeonEscape
{
    internal class Goblin : GameActor
    {
        private float m_moveTrigger;
        private float m_moveCounter;

        Direction moveDir;
        bool legalMove;

        public Goblin(Point startPos, Texture2D txr, int frameCount, int fps)
            : base(startPos, txr, frameCount, fps)
        {
            m_moveTrigger = 0.5f;
            m_moveCounter = 0;
        }

        public void UpdateMe(GameTime gt, Map currentMap)
        {
            m_moveCounter += (float)gt.ElapsedGameTime.TotalSeconds;

            if(m_moveCounter >= m_moveTrigger)
            {
                m_moveCounter = 0;

                moveDir = (Direction)Game1.RNG.Next(0, 3);

                switch (moveDir)
                {
                    case Direction.North:
                        legalMove = currentMap.IsWalkable(new Point(Position.X, Position.Y - 1));
                        break;
                    case Direction.South:
                        legalMove = currentMap.IsWalkable(new Point(Position.X, Position.Y + 1));
                        break;
                    case Direction.West:
                        legalMove = currentMap.IsWalkable(new Point(Position.X - 1, Position.Y));
                        break;
                    case Direction.East:
                        legalMove = currentMap.IsWalkable(new Point(Position.X + 1, Position.Y));
                        break;
                }

                if (legalMove)
                {
                    MoveMe(moveDir);    
                }
            }
        }
    }
}
