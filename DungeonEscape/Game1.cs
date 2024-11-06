using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using EnigmaUtils;

namespace DungeonEscape
{
    public enum GameState
    {
        Title,
        LevelOne,
        LevelTwo,
        LevelThree,
        GameWin,
        GameOver
    }

    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();
        public static readonly Point windowSize = new Point(480, 320);

        Vector2 screenCenter;

        RenderTarget2D drawCanvas;

        PlayerClass player1;
        List<Goblin> guards;

        List<Texture2D> tiles;
        
        Map currentMap;

        KeyboardState kb_curr;
        KeyboardState kb_old;

        Vector2 canvasPos;

        public static GameState gameState = GameState.Title;

        EnigmaTextUtil titleText;
        EnigmaTextUtil tooltip;

        //Matrix translation;

#if DEBUG
        public static SpriteFont debugFont;
#endif

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            Window.Title = "Dungeon Escape!";
            _graphics.PreferredBackBufferWidth = windowSize.X;
            _graphics.PreferredBackBufferHeight = windowSize.Y;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            drawCanvas = new RenderTarget2D(_graphics.GraphicsDevice, 480, 480);

            screenCenter = new Vector2(windowSize.X / 2, windowSize.Y / 2);

            guards = new List<Goblin>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

#if DEBUG
            debugFont = Content.Load<SpriteFont>("Fonts/Arial07");
#endif

            // TODO: use this.Content to load your game content here

            titleText = new EnigmaTextUtil(Content.Load<SpriteFont>("Fonts/TitleFont"), windowSize.ToVector2() / 2);
            tooltip = new EnigmaTextUtil(Content.Load<SpriteFont>("Fonts/ToolTip"), new Vector2(windowSize.X / 2,
                windowSize.Y - Content.Load<SpriteFont>("Fonts/ToolTip").MeasureString("A").Y - 10));

            player1 = new PlayerClass(new Point(5, 4), Content.Load<Texture2D>("Characters/pc"), 3, 8);
            guards = MapData.LevelOneGuardsData(guards, Content.Load<Texture2D>("Characters/goblin"));

            tiles = new List<Texture2D>();
            tiles.Add(Content.Load<Texture2D>("Tiles/void"));       //0
            tiles.Add(Content.Load<Texture2D>("Tiles/floor"));      //1
            tiles.Add(Content.Load<Texture2D>("Tiles/wall"));       //2
            tiles.Add(Content.Load<Texture2D>("Tiles/stairup"));    //3
            tiles.Add(Content.Load<Texture2D>("Tiles/stairdown"));  //4
            tiles.Add(Content.Load<Texture2D>("Tiles/wallL"));      //5
            tiles.Add(Content.Load<Texture2D>("Tiles/wallR"));      //6
            tiles.Add(Content.Load<Texture2D>("Tiles/wallTL"));     //7
            tiles.Add(Content.Load<Texture2D>("Tiles/wallTR"));     //8
            tiles.Add(Content.Load<Texture2D>("Tiles/voidwallL"));  //9
            tiles.Add(Content.Load<Texture2D>("Tiles/voidwallR"));  //10
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            kb_curr = Keyboard.GetState();

            if(kb_curr.IsKeyDown(Keys.Escape))
                this.Exit();

            switch (gameState)
            {
                case GameState.Title:
                    UpdateTitle(gameTime, kb_curr, kb_old);
                    break;
                case GameState.LevelOne:
                    if(!MapData.levelOneLoaded)
                    {
                        currentMap = new Map(MapData.levelOne);
                        MapData.levelOneLoaded = true;

                        if (!MapData.playerStartOne)
                        {
                            player1.Position = new Point(13, 4);
                            MapData.playerStartOne = true;
                        }
                    }
                    UpdateLevelOne(gameTime, kb_curr, kb_old);
                    break;
                case GameState.LevelTwo:
                    if (!MapData.levelTwoLoaded)
                    {
                        currentMap = new Map(MapData.levelTwo);
                        MapData.levelTwoLoaded = true;

                        if (!MapData.playerStartTwo)
                        {
                            player1.Position = new Point(2, 21);
                            MapData.playerStartTwo = true;
                        }

                        if (!MapData.guardsTwo)
                        {
                            guards = MapData.LevelTwoGuardsData(guards, Content.Load<Texture2D>("Characters/goblin"));
                            MapData.guardsTwo = true;
                        }
                    }
                    UpdateLevelTwo(gameTime);
                    break;
                case GameState.LevelThree:
                    if (!MapData.levelThreeLoaded)
                    {
                        currentMap = new Map(MapData.levelThree);
                        MapData.levelThreeLoaded = true;

                        if (!MapData.playerStartThree)
                        {
                            player1.Position = new Point(25, 23);
                            MapData.playerStartThree = true;
                        }

                        //if (!MapData.guardsTwo)
                        //{
                        //    guards = MapData.LevelTwoGuardsData(guards, Content.Load<Texture2D>("Characters/goblin"));
                        //    MapData.guardsTwo = true;
                        //}
                    }
                    UpdateLevelThree(gameTime);
                    break;
                case GameState.GameWin:
                    UpdateGameWin();
                    break;
                case GameState.GameOver:
                    UpdateGameOver();
                    break;
            }

            //Debug.WriteLine(gameState);

            kb_old = kb_curr;

            base.Update(gameTime);
        }

        void UpdateTitle(GameTime gt, KeyboardState kb_curr, KeyboardState kb_old)
        {
            tooltip.UpdateMe(gt);

            if(kb_curr.IsKeyDown(Keys.Enter) && kb_old.IsKeyUp(Keys.Enter))
            {
                gameState = GameState.LevelOne;
            }
        }

        void UpdateLevelOne(GameTime gt, KeyboardState kb_curr, KeyboardState kb_old)
        {
            player1.UpdateMe(gt, currentMap, kb_curr, kb_old);
            //foreach(Goblin eachGuard in guards)
            //{
            //    eachGuard.UpdateMe(gt, currentMap, player1.Position);
            //}

            MoveCanvas(MapData.levelOneMinClamp, MapData.levelOneMaxClamp);

            if(kb_curr.IsKeyDown(Keys.Space) && kb_old.IsKeyUp(Keys.Space))
            {
                gameState = GameState.LevelTwo;
            }

            Debug.WriteLine(canvasPos);
        }

        void UpdateLevelTwo(GameTime gt)
        {
            player1.UpdateMe(gt, currentMap, kb_curr, kb_old);

            //foreach (Goblin eachGuard in guards)
            //{
            //    eachGuard.UpdateMe(gt, currentMap, player1.Position);
            //}

            MoveCanvas(MapData.levelTwoMinClamp, MapData.levelTwoMaxClamp);

            if (kb_curr.IsKeyDown(Keys.Space) && kb_old.IsKeyUp(Keys.Space))
            {
                gameState = GameState.LevelThree;
            }

            
        }

        void UpdateLevelThree(GameTime gt)
        {
            player1.UpdateMe(gt, currentMap, kb_curr, kb_old);

            MoveCanvas(MapData.levelThreeMinClamp, MapData.levelThreeMaxClamp);
        }

        void UpdateGameWin()
        {
            
        }

        void UpdateGameOver()
        {
            
        }

        void MoveCanvas(Vector2 minClamp, Vector2 maxClamp)
        {
            canvasPos = screenCenter - player1.PlayerPos.ToVector2() * 32;

            canvasPos = currentMap.UpdateMe(canvasPos, minClamp, maxClamp);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            
            _spriteBatch.Begin();

            switch (gameState)
            {
                case GameState.Title:
                    DrawTitle(_spriteBatch);
                    break;
                case GameState.LevelOne:
                    DrawLevelOne(gameTime);
                    break;
                case GameState.LevelTwo:
                    DrawLevelTwo(gameTime);
                    break;
                case GameState.LevelThree:
                    DrawLevelThree(gameTime);
                    break;
                case GameState.GameWin:
                    DrawGameWin(_spriteBatch);
                    break;
                case GameState.GameOver:
                    DrawGameOver(_spriteBatch);
                    break;
            }

#if DEBUG
            _spriteBatch.DrawString(debugFont,
                _graphics.PreferredBackBufferWidth + "X" + _graphics.PreferredBackBufferHeight
                + "\nFPS : " + (int)(1 / gameTime.ElapsedGameTime.TotalSeconds) + "ish",
                new Vector2(270, 10), Color.White);
#endif

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        void DrawTitle(SpriteBatch sBatch)
        {
            titleText.DrawString(sBatch, "Dungeon Escape");
            tooltip.DrawString(sBatch, "Press Enter to start!");
        }

        void DrawLevelOne(GameTime gt)
        {
            GraphicsDevice.SetRenderTarget(drawCanvas);
            if (MapData.levelOneLoaded)
            {
                currentMap.DrawMe(_spriteBatch, tiles); 
            }

            player1.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);

            foreach (Goblin eachGuard in guards)
            {
                eachGuard.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);
            }

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(drawCanvas,
                canvasPos,
                null,
                Color.White,
                0,
                Vector2.Zero,
                2,
                SpriteEffects.None,
                1);
        }

        void DrawLevelTwo(GameTime gt)
        {
            GraphicsDevice.SetRenderTarget(drawCanvas);
            if (MapData.levelTwoLoaded)
            {
                currentMap.DrawMe(_spriteBatch, tiles);
            }

            player1.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);

            foreach(Goblin eachGuard in guards)
            {
                eachGuard.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);
            }

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(drawCanvas,
                canvasPos,
                null,
                Color.White,
                0,
                Vector2.Zero,
                2,
                SpriteEffects.None,
                1);
        }

        void DrawLevelThree(GameTime gt)
        {
            GraphicsDevice.SetRenderTarget(drawCanvas);
            if (MapData.levelThreeLoaded)
            {
                currentMap.DrawMe(_spriteBatch, tiles);
            }

            player1.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);

            //foreach (Goblin eachGuard in guards)
            //{
            //    eachGuard.DrawMe(_spriteBatch, gt, tiles[0].Width, tiles[0].Height);
            //}

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(drawCanvas,
                canvasPos,
                null,
                Color.White,
                0,
                Vector2.Zero,
                2,
                SpriteEffects.None,
                1);
        }

        void DrawGameWin(SpriteBatch sBatch)
        {
            tooltip.DrawString(sBatch, "GAME WIN!");
        }

        void DrawGameOver(SpriteBatch sBatch)
        {
            tooltip.DrawString(sBatch, "GAME OVER!");
        }
    }
}
