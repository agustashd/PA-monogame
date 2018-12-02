using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Sprites
{
    public class Boss : Alive
    {
        public Boss()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/ufo");
            Rectangle = new Rectangle(Game1.TheGame.GraphicsDevice.Viewport.Width / 2, 20, 90, 90);
            Health = 300;
        }

        protected override void DrawHealth(GameTime gametime)
        {
            if (Health > 0)
            {
                vida = new Texture2D(Game1.TheGame.GraphicsDevice, Health, 5);
                Color[] data = new Color[Health * 5];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = Color.Red;
                }

                vida.SetData(data);
                Game1.TheGame.spriteBatch.Draw(vida, new Vector2(0, 15), Color.Red);
            }
        }

        TimeSpan frameTime;
        TimeSpan lastTime;
        bool goLeft = false;
        public override void Update(GameTime gametime)
        {
            int x;
            x = Rectangle.X;
            if (!goLeft)
            {
                x += 2;
            }
            else
            {
                x -= 2;
            }

            if (x > Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width)
            {
                x = Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width;
                goLeft = true;
            }
            else if (x < 0)
            {
                x = 0;
                goLeft = false;
            }

            Rectangle = new Rectangle(x, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            // Boos diaspara minas
            if (gametime.TotalGameTime.Subtract(frameTime).Milliseconds > 800)
            {
                frameTime = gametime.TotalGameTime;
                Game1.TheGame.actualizaciones.Add(new Mine(this));
            }

            if (gametime.TotalGameTime.Subtract(lastTime).Milliseconds > 100)
            {
                // Busco el ship entre los sprites que hay
                Ship ship = null;
                foreach (var sprite in Game1.TheGame.sprites)
                {
                    if (sprite is Ship)
                    {
                        ship = sprite as Ship;
                        break;
                    }
                }

                if (Health <= 0)
                {
                    ship.Score += 100;
                }
            }

            if (this.Health <= 0)
            {
                Game1.TheGame.actualizaciones.Add(this);
                Game1.TheGame.IsBossDead = true;
            }
        }
    }
}
