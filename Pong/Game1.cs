using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Pong.GameObjects;

namespace Pong
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Paddle _paddle1;
        private AIPaddle _paddle2;
        private Ball _ball;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            _paddle1 = new Paddle(Content.Load<Texture2D>("paddle"));
            _paddle1.Reset();

            _paddle2 = new AIPaddle(Content.Load<Texture2D>("paddle"));
            _paddle2.Reset();

            _ball = new Ball(Content.Load<Texture2D>("ball"));
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            _paddle1.Direction = new Point();

            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                _paddle1.Direction = new Point(0, -1);
            }
            else if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                _paddle1.Direction = new Point(0, 1);
            }

            _paddle1.Update(gameTime, _ball);
            _paddle2.Update(gameTime, _ball);
            _ball.Update(gameTime);

            if (_ball.OffPlayer())
            {
                _ball.Position = new Point(21, (600 - _paddle1.Texture.Height) / 2);
                _ball.Direction = new Vector2(1, 1);
                _paddle1.Reset();
                _paddle2.Reset();
            }

            if (_ball.OffAIPlayer())
            {
                _ball.Position = new Point(800 - _ball.Texture.Width, (600 - _paddle2.Texture.Height) / 2);
                _ball.Direction = new Vector2(-1, 1);
                _paddle1.Reset();
                _paddle2.Reset();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            _paddle1.Draw(_spriteBatch);
            _paddle2.Draw(_spriteBatch);
            _ball.Draw(_spriteBatch);
            base.Draw(gameTime);
            _spriteBatch.End();
        }
    }
}
