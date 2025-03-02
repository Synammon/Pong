using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Pong.GameObjects
{
    public class Ball
    {
        public Point Position { get; set; }
        public Vector2 Direction { get; set; }
        public float Speed { get; set; }    
        public Texture2D Texture { get; private set; }

        public Ball(Texture2D texture)
        {
            Texture = texture;
            Speed = 5;
            Direction = new Vector2(1, 1);
            Position = new Point(21, (600-Texture.Height) / 2);
        }

        public bool OffPlayer()
        {
            return Position.X < 0 - Texture.Width;
        }

        public bool OffAIPlayer()
        {
            return Position.X > 799;
        }

        public virtual void Update(GameTime gameTime)
        {
            Position = new Point((int)(Position.X + Direction.X * Speed), (int)(Position.Y + Direction.Y * Speed));
            if (Position.Y < 0)
            {
                Position = new Point(Position.X, 0);
                Direction = new Vector2(Direction.X, -Direction.Y);
            }
            else if (Position.Y > 600 - Texture.Height)
            {
                Position = new Point(Position.X, 600 - Texture.Height);
                Direction = new Vector2(Direction.X, -Direction.Y);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(Texture, new Rectangle(Position, new Point(Texture.Width, Texture.Height)), Color.White);
        }
    }
}
