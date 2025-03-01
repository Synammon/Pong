using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pong.GameObjects
{
    public class AIPaddle : Paddle
    {
        public AIPaddle(Texture2D texture) : base(texture)
        {
        }

        public override void Update(GameTime gameTime, Ball ball)
        {
            if (ball.Position.Y < Position.Y)
            {
                Direction = new Point(0, -1);
            }
            else if (ball.Position.Y > Position.Y + 150)
            {
                Direction = new Point(0, 1);
            }
            else
            {
                Direction = new Point(0, 0);
            }

            Position = new Point(Position.X, ball.Position.Y + Direction.Y * Speed);

            if (Position.Y < 0)
            {
                Position = new Point(Position.X, 0);
            }
            else if (Position.Y > 600 - 150)
            {
                Position = new Point(Position.X, 600 - 150);
            }

            Rectangle paddleRectangle = new Rectangle(Position, new Point(20, 150));
            Rectangle ballRectangle = new Rectangle(ball.Position, new Point(ball.Texture.Width, ball.Texture.Height));

            if (paddleRectangle.Intersects(ballRectangle))
            {
                ball.Direction = new Vector2(-ball.Direction.X, ball.Direction.Y);
            }
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            base.Draw(spriteBatch);
        }
    }
}
