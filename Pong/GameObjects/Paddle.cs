using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.GameObjects
{
    public class Paddle
    {
        public Point Position { get; set; }
        public int Speed { get; set; }
        public Point Direction { get; set; }
        public Texture2D Texture { get; private set; }

        public Paddle(Texture2D texture)
        {
            Texture = texture;
            Speed = 10;
            Position = new Point(0, (600 - 150) / 2);
            Direction = new Point(0, 0);
        }

        public virtual void Reset()
        {
            Position = new Point(0, (600 - 150) / 2);
            Direction = new Point(0, 0);
        }

        public virtual void Update(GameTime gameTime, Ball ball)
        {
            Position = new(Position.X, Position.Y + Direction.Y * Speed);

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

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position, new Point(20, 150)), Color.White);
        }
    }
}
