using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace DungeonEscape
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public static readonly Random RNG = new Random();
        public static readonly Point windowSize = new Point(960, 640);

        RenderTarget2D drawCanvas;


        PlayerClass player1;
        Goblin guard;

        List<Texture2D> tiles;
        int[,] testFloor;

        Map currentMap;

        KeyboardState kb_curr;
        KeyboardState kb_old;

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

            testFloor = new int[16, 16]
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

            currentMap = new Map(testFloor);

            drawCanvas = new RenderTarget2D(_graphics.GraphicsDevice, 480, 320);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

#if DEBUG
            debugFont = Content.Load<SpriteFont>("Fonts/Arial07");
#endif

            // TODO: use this.Content to load your game content here

            player1 = new PlayerClass(new Point(14, 4), Content.Load<Texture2D>("Characters/pc"), 3, 8);
            guard = new Goblin(new Point(5, 4), Content.Load<Texture2D>("Characters/goblin"), 3, 8);

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
        }

        protected override void Update(GameTime gameTime)
        {
            // TODO: Add your update logic here

            kb_curr = Keyboard.GetState();

            if(kb_curr.IsKeyDown(Keys.Escape))
                this.Exit();

            //if(player1.LOS(guard.Position, currentMap))
            //{
            //    Debug.WriteLine("Spotted!");
            //    this.Exit();
            //}

            Debug.WriteLine(guard.Position.ToString()); 

            player1.UpdateMe(gameTime, currentMap, kb_curr, kb_old);
            //guard.UpdateMe(gameTime, currentMap);

            kb_old = kb_curr;

            //CalculateTranslation();

            base.Update(gameTime);
        }

        void CalculateTranslation()
        {
            var dx = currentMap.MapSize.X - player1.PlayerPos.X;
            dx = MathHelper.Clamp(dx, -500, 500);

            var dy = currentMap.MapSize.Y - player1.PlayerPos.Y;
            dy = MathHelper.Clamp(dy, -500, 500);

            //translation = Matrix.CreateTranslation(dx, dy, 0f);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            GraphicsDevice.SetRenderTarget(drawCanvas);
            _spriteBatch.Begin();

            currentMap.DrawMe(_spriteBatch, tiles);

            player1.DrawMe(_spriteBatch, gameTime, tiles[0].Width, tiles[0].Height);
            //guard.DrawMe(_spriteBatch, gameTime, tiles[0].Width, tiles[0].Height);

            _spriteBatch.End();

            GraphicsDevice.SetRenderTarget(null);
            _spriteBatch.Begin(samplerState: SamplerState.PointClamp);
            _spriteBatch.Draw(drawCanvas, (new Vector2(480, 320)-(player1.PlayerPos * tiles[0].Bounds.Size).ToVector2())/2, null, Color.White, 0, Vector2.Zero, 2, SpriteEffects.None, 0);


#if DEBUG
            _spriteBatch.DrawString(debugFont,
                _graphics.PreferredBackBufferWidth + "X" + _graphics.PreferredBackBufferHeight
                + "\nFPS : " + (int)(1 / gameTime.ElapsedGameTime.TotalSeconds) + "ish",
                new Vector2(270, 10), Color.White);
#endif

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
