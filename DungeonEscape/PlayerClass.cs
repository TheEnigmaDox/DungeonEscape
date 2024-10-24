using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;


namespace DungeonEscape
{
    internal class PlayerClass : GameActor
    {
        public Point PlayerPos
        {
            get
            {
                return m_position;
            }
        }

        public PlayerClass(Point startPos, Texture2D txr, int frameCount, int fps)
            : base(startPos, txr, frameCount, fps)
        { 
        
        }

        public void UpdateMe(GameTime gt,
            Map currentMap,
            KeyboardState kb_curr,
            KeyboardState kb_old)
        {
            if (kb_curr.IsKeyDown(Keys.W) && kb_old.IsKeyUp(Keys.W))
            {
                if (currentMap.IsWalkable(new Point(Position.X, Position.Y - 1)))
                {
                    MoveMe(Direction.North);
                }
            }
            if (kb_curr.IsKeyDown(Keys.S) && kb_old.IsKeyUp(Keys.S))
            {
                if (currentMap.IsWalkable(new Point(Position.X, Position.Y + 1)))
                {
                    MoveMe(Direction.South); 
                }
            }
            if (kb_curr.IsKeyDown(Keys.A) && kb_old.IsKeyUp(Keys.A))
            {
                if (currentMap.IsWalkable(new Point(Position.X - 1, Position.Y)))
                {
                    MoveMe(Direction.West);
                }
            }
            if (kb_curr.IsKeyDown(Keys.D) && kb_old.IsKeyUp(Keys.D))
            {
                if (currentMap.IsWalkable(new Point(Position.X + 1, Position.Y)))
                {
                    MoveMe(Direction.East);
                }
            }
        }
    }
}
