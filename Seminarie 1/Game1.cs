using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Windows.Forms;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;
using Keys = Microsoft.Xna.Framework.Input.Keys;

namespace Seminarie_1
{
    public class Game1 : Game
    {
        // Int
        int ScreenHeight = 700;
        int ScreenWidth = 700;

        // Vector2 | Ball one
        Vector2 BallOnePos;
        Vector2 BallOneVel;
        // Vector2 | Ball two
        Vector2 BallTwoPos;
        Vector2 BallTwoVel;

        // Float 
        float BallOneRadius;
        float BallTwoRadius;

        // Ball
        Ball BallOne;
        Ball BallTwo;

        List<Vector2> BallOneCollisionPositions;
        List<Vector2> BallTwoCollisionPositions;
        List<string> TimeOfCollisions;

        // Other
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        Color BackGroundColor = Color.Green;
        Texture2D BallTex;
        Stopwatch timer;
        SpriteFont font;
        string elapsedTime;

        Vector2 Temp = Vector2.Zero;

        public Game1()
        {
            Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            SpriteBatch = new SpriteBatch(GraphicsDevice);
            BallTex = Content.Load<Texture2D>("Pool ball");

            Graphics.PreferredBackBufferHeight = ScreenHeight;
            Graphics.PreferredBackBufferWidth = ScreenWidth;
            Graphics.ApplyChanges();


            BallOne = new(BallTex, BallOneRadius, BallOnePos, BallOneVel);
            BallTwo = new(BallTex, BallTwoRadius, BallTwoPos, BallTwoVel);

            font = Content.Load<SpriteFont>("File");

            //Timer stuff
            timer = new Stopwatch();
            timer.Start();

            BallOneCollisionPositions = new List<Vector2>();
            BallTwoCollisionPositions = new List<Vector2>();
            TimeOfCollisions = new List<string>();
        }

        protected override void Update(GameTime gameTime)
        {

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            UpdateBalls();

            // Fun stuff is written here ↓

            // Gets the elapsed time and then formats and displays the elapsed time
            TimeSpan timeSpan = timer.Elapsed;
            elapsedTime = String.Format("{0:00}:{1:00}.{2:000}", timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

            // TODO: Replace once balls are working
            if (Keyboard.GetState().IsKeyDown(Keys.S))
                SavePositions();


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackGroundColor);

            SpriteBatch.Begin();

            DrawBalls();

            SpriteBatch.DrawString(font, elapsedTime, Vector2.Zero, Color.White);

            for(int i = 0; i < TimeOfCollisions.Count; i++)
                SpriteBatch.DrawString(font, TimeOfCollisions[i], new Vector2(ScreenWidth - font.MeasureString(TimeOfCollisions[i]).X, 20 * i), Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        bool AreBallsColliding(Ball ball1, Ball ball2)
        {
            // Fun stuff is written here ↓

            return false;
        }

        void CalculateCollision()
        {
            // Fun stuff is written here ↓

        }

        private void SavePositions()
        {
            // TODO: Add back once balls are working
            //BallOneCollisionPositions.Add(BallOne.Pos);
            //BallOneCollisionPositions.Add(BallTwo.Pos);
            
            // Temp is for testing purposes
            TimeOfCollisions.Add(elapsedTime + " : BALL ONE" + Temp + " : BALL TWO" + Temp);
        }

        void DrawBalls()
        {
            BallOne.Draw(SpriteBatch);
            BallTwo.Draw(SpriteBatch);
        }

        void UpdateBalls()
        {
            BallOne.Update();
            BallTwo.Update();
        }
    }
}