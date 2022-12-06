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
        int TotalCollisionsMax = 1;
        int TotalCollisions;

        // Vector2 | Ball one
        Vector2 BallOnePos = new(100, 100);
        Vector2 BallOneVel;
        // Vector2 | Ball two
        Vector2 BallTwoPos = new(500,100);
        Vector2 BallTwoVel;
        // Vector2 | Misc
        Vector2 Temp = Vector2.Zero;
        List<Vector2> BallOneCollisionPositions;
        List<Vector2> BallTwoCollisionPositions;

        // Float | Ball one
        float BallOneRadius = 25.0f;
        float BallOneMass = 1.0f;
        // Float | Ball Two
        float BallTwoRadius = 25.0f;
        float BallTwoMass = 1.0f;
        // Float | Misc
        float CollisionVisualzationDuration = 0.5f;

        // String
        string TimeFormat = "{0:00}:{1:00}.{2:000}";
        List<string> TimeOfCollisions;
        string elapsedTime;

        // StopWatch
        Stopwatch timer;
        Stopwatch CollisionVisualzationTimer;

        // Ball
        Ball BallOne;
        Ball BallTwo;

        // Other
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        Color BackGroundColor = Color.Green;
        Texture2D BallTex;
        SpriteFont font;
        bool BreakAfterCollisions = false;
        Color CollisionColor = Color.Red;

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

            BallOne = new(BallTex, BallOneRadius, BallOneMass, BallOnePos, BallOneVel);
            BallTwo = new(BallTex, BallTwoRadius, BallTwoMass, BallTwoPos, BallTwoVel);

            font = Content.Load<SpriteFont>("File");

            //Timer stuff
            timer = new Stopwatch();
            timer.Start();
            CollisionVisualzationTimer = new();

            BallOneCollisionPositions = new List<Vector2>();
            BallTwoCollisionPositions = new List<Vector2>();
            TimeOfCollisions = new List<string>();
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Fun stuff is written here ↓

            if (!BreakAfterCollisions && TotalCollisions < TotalCollisionsMax)
            {
                UpdateBalls();

                if (AreBallsColliding(BallOne, BallTwo))
                    CalculateCollision();

                if (CollisionVisualzationTimer.IsRunning && CollisionVisualzationTimer.Elapsed.TotalSeconds >= CollisionVisualzationDuration)
                {
                    BallOne.SetColor(Color.White);
                    BallOne.SetColor(Color.White);
                    CollisionVisualzationTimer.Stop();
                    CollisionVisualzationTimer.Reset();
                }

                // Gets the elapsed time and then formats and displays the elapsed time
                TimeSpan timeSpan = timer.Elapsed;
                elapsedTime = String.Format(TimeFormat, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                // TODO: Replace once balls are working
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                    SavePositions();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackGroundColor);

            SpriteBatch.Begin();

            DrawBalls();

            SpriteBatch.DrawString(font, elapsedTime, Vector2.Zero, Color.White);

            for (int i = 0; i < TimeOfCollisions.Count; i++)
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


            TotalCollisions++;

            BallOne.SetColor(CollisionColor);
            BallOne.SetColor(CollisionColor);
            CollisionVisualzationTimer.Start();
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