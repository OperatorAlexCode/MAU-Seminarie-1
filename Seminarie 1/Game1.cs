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
        int BackInveral = 100;

        // Vector2 | Ball one
        Vector2 BallOnePos = new(100, 100);
        Vector2 BallOneVel = new(10, 5);
        // Vector2 | Ball two
        Vector2 BallTwoPos = new(500,100);
        Vector2 BallTwoVel = new(-10, 10);
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

        // Color
        Color BallOneColor = Color.White;
        Color BallTwoColor = Color.White;
        Color CollisionColor = Color.Red;
        Color BackGroundColor = Color.Green;

        // Ball
        Ball BallOne;
        Ball BallTwo;

        // Other
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        Texture2D BallTex;
        SpriteFont font;
        bool BreakAfterCollisions = true;

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

            BallOne.SetColor(BallOneColor);
            BallTwo.SetColor(BallTwoColor);

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

            if (!BreakAfterCollisions || TotalCollisions < TotalCollisionsMax)
            {
                UpdateBalls();

                if (IsBallOutOfBounds(BallOne, 0))
                    BallOne.vel.Y *= -1;

                if (IsBallOutOfBounds(BallOne, 1))
                    BallOne.vel.X *= -1;

                if (IsBallOutOfBounds(BallTwo, 0))
                    BallTwo.vel.Y *= -1;

                if (IsBallOutOfBounds(BallTwo, 1))
                    BallTwo.vel.X *= -1;

                if (AreBallsColliding(BallOne, BallTwo))
                    CalculateCollision(BallOne, BallTwo);

                if (CollisionVisualzationTimer.IsRunning && CollisionVisualzationTimer.Elapsed.TotalSeconds >= CollisionVisualzationDuration)
                {
                    BallOne.SetColor(BallOneColor);
                    BallTwo.SetColor(BallTwoColor);
                    CollisionVisualzationTimer.Stop();
                    CollisionVisualzationTimer.Reset();
                }

                // Gets the elapsed time and then formats and displays the elapsed time
                TimeSpan timeSpan = timer.Elapsed;
                elapsedTime = String.Format(TimeFormat, timeSpan.Minutes, timeSpan.Seconds, timeSpan.Milliseconds);

                // TODO: Replace once balls are working
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                    SavePositions(BallOne,BallTwo);
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackGroundColor);

            SpriteBatch.Begin();

            DrawBalls();

            //SpriteBatch.DrawString(font, elapsedTime, Vector2.Zero, Color.White);

            //for (int i = 0; i < TimeOfCollisions.Count; i++)
            //    SpriteBatch.DrawString(font, TimeOfCollisions[i], new Vector2(ScreenWidth - font.MeasureString(TimeOfCollisions[i]).X, 20 * i), Color.White);

            //if (TimeOfCollisions.Count == 1)
            //    SpriteBatch.DrawString(font, TimeOfCollisions[0], new Vector2(ScreenWidth - font.MeasureString(TimeOfCollisions[0]).X, 0), Color.White);
            if (TimeOfCollisions.Count >= 1)
                SpriteBatch.DrawString(font, TimeOfCollisions[TimeOfCollisions.Count-1], new Vector2(ScreenWidth - font.MeasureString(TimeOfCollisions[TimeOfCollisions.Count - 1]).X, 0), Color.White);

            SpriteBatch.End();

            base.Draw(gameTime);
        }

        bool AreBallsColliding(Ball ball1, Ball ball2)
        {
            // Fun stuff is written here ↓

            float distance = Vector2.Distance(ball1.pos, ball2.pos);

            return distance <= ball1.Radius+ball2.Radius;
        }

        void CalculateCollision(Ball ball1, Ball ball2)
        {
            // Fun stuff is written here ↓

            timer.Stop();

            do
            {
                ball1.pos = new(ball1.pos.X- (ball1.vel.X/ BackInveral), ball1.pos.Y - (ball1.vel.Y / BackInveral));
                ball2.pos = new(ball2.pos.X - (ball2.vel.X / BackInveral), ball2.pos.Y - (ball2.vel.Y / BackInveral));
            } while (AreBallsColliding(BallOne, BallTwo));

            ball1.UpdateDestRec();
            ball2.UpdateDestRec();

            SavePositions(ball1, ball2);

            TotalCollisions++;

            ball1.SetColor(CollisionColor);
            ball2.SetColor(CollisionColor);

            CollisionVisualzationTimer.Start();
            timer.Start();
        }

        private void SavePositions(Ball ball1, Ball ball2)
        {
            // TODO: Add back once balls are working
            //BallOneCollisionPositions.Add(BallOne.Pos);
            //BallOneCollisionPositions.Add(BallTwo.Pos);

            // Temp is for testing purposes
            TimeOfCollisions.Add(elapsedTime + " : BALL ONE" + ball1.pos + " : BALL TWO" + ball2.pos);
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

        bool IsBallOutOfBounds(Ball ball, int sides)
        {
            bool output = false;
            switch (sides)
            {
                case 0:
                    output = ball.DestRec.Top <= 0 || ball.DestRec.Bottom >= ScreenHeight;
                    break;
                case 1:
                    output = ball.DestRec.Left <= 0 || ball.DestRec.Right >= ScreenWidth;
                    break;
            }
            return output;
        }
    }
}