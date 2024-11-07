using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Diagnostics;
using System;

namespace DungeonEscape
{
    enum GoblinState
    {
        Normal,
        Alert,
    }

    internal class Goblin : GameActor
    {
        private Point m_startPoint;

        private float m_moveTrigger;
        private float m_moveCounter;

        private GoblinState m_state;

        Direction moveDir;
        bool legalMove;

        public Goblin(Point startPos, Texture2D txr, int frameCount, int fps)
            : base(startPos, txr, frameCount, fps)
        {
            m_startPoint = startPos;
            m_moveTrigger = 3f;
            m_moveCounter = 0;

            m_state = GoblinState.Normal;
        }

        public void UpdateMe(GameTime gt, Map currentMap, PlayerClass player)
        {
            //m_position = m_startPoint;

            m_moveCounter += (float)gt.ElapsedGameTime.TotalSeconds;

            if(m_moveCounter >= m_moveTrigger)
            {
                m_moveCounter = 0;

                moveDir = (Direction)Game1.RNG.Next(0, 4);

                switch (moveDir)
                {
                    case Direction.North:
                        legalMove = currentMap.IsWalkable(new Point(Position.X, Position.Y - 1), false);
                        break;
                    case Direction.South:
                        legalMove = currentMap.IsWalkable(new Point(Position.X, Position.Y + 1), false);
                        break;
                    case Direction.West:
                        legalMove = currentMap.IsWalkable(new Point(Position.X - 1, Position.Y), false);
                        break;
                    case Direction.East:
                        legalMove = currentMap.IsWalkable(new Point(Position.X + 1, Position.Y), false);
                        break;
                }

                if (legalMove)
                {
                    MoveMe(moveDir);    
                }
            }

            CheckLOS(player, currentMap);

            // Debug.WriteLine(moveDir);
        }

        void CheckLOS(PlayerClass player, Map currentMap)
        {
            var distance = (player.Position - Position).ToVector2().Length();

            Debug.WriteLine(distance);

            m_state = GoblinState.Normal;

            if (moveDir == Direction.North && player.Position.Y < m_position.Y)
            {
                if (LOS(player.Position, currentMap) && distance < 4)
                {
                    m_state = GoblinState.Alert;
                    //Game1.gameState = GameState.GameOver;

                    player.HasBeenSpotted = true;
                }
            }

            if(moveDir == Direction.South && player.Position.Y > m_position.Y)
            {
                if(LOS(player.Position, currentMap) && distance < 4)
                {
                    m_state = GoblinState.Alert;
                    //Game1.gameState = GameState.GameOver;

                    player.HasBeenSpotted = true;
                }
            }

            if(moveDir == Direction.West && player.Position.X < m_position.X)
            {
                if(LOS(player.Position, currentMap) && distance < 4)
                {
                    m_state = GoblinState.Alert;
                    //Game1.gameState = GameState.GameOver;

                    player.HasBeenSpotted = true;
                }
            }

            if(moveDir == Direction.East && player.Position.X > m_position.X)
            {
                if(LOS(player.Position, currentMap) && distance < 4)
                {
                    m_state = GoblinState.Alert;
                    //Game1.gameState = GameState.GameOver;

                    player.HasBeenSpotted = true;
                }
            }

            //Debug.WriteLineIf(m_state == GoblinState.Normal, $"Cannot see player at {playerPos} from {Position}");
        }

        public override void DrawMe(SpriteBatch sBatch, GameTime gt, int tileWidth, int tileHeight)
        {
            switch (m_state)
            {
                case GoblinState.Normal:
                    Tint = Color.White;
                    break;
                case GoblinState.Alert:
                    Tint = Color.Red;
                    break;
            }
            base.DrawMe(sBatch, gt, tileWidth, tileHeight);
        }
    }
}
