using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
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

        // Ball
        Ball BallOne;
        Ball BallTwo;

        // Other
        private GraphicsDeviceManager Graphics;
        private SpriteBatch SpriteBatch;
        Color BackGroundColor = Color.Green;
        float ElapsedTime;

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

            Graphics.PreferredBackBufferHeight = ScreenHeight;
            Graphics.PreferredBackBufferWidth = ScreenWidth;
            Graphics.ApplyChanges();

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            ElapsedTime += (float)gameTime.TotalGameTime.TotalSeconds;

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Fun stuff is written here ↓


            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(BackGroundColor);

            SpriteBatch.Begin();

            BallOne.Draw(SpriteBatch);
            BallTwo.Draw(SpriteBatch);

            SpriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }

        public bool AreBallsColliding(Ball ball1, Ball Ball2)
        {
            // Fun stuff is written here ↓

            return false;
        }

        public void CalculateCollision()
        {
            // Fun stuff is written here ↓

        }
    }
}