using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Sprites
{
    public class Alien : Alive
    {
        public Alien()
        {
            Health = random.Next(20, 100);
            if (Health > 70)
            {
                Rectangle = new Rectangle(random.Next(Game1.TheGame.GraphicsDevice.Viewport.Width - 50), 10, 50, 50);
                Image = Game1.TheGame.Content.Load<Texture2D>("Images/alien");
            }
            else
            {
                Health -= 10;
                Rectangle = new Rectangle(random.Next(Game1.TheGame.GraphicsDevice.Viewport.Width - 50), 10, 35, 35);
                Image = Game1.TheGame.Content.Load<Texture2D>("Images/asteroid");
            }
        }

        // Para completar el codigo que le falta al metodo Update de la clase abstracta Sprite
        // tenemos que volver a escribir el metodo y completar con lo que queremos que haga
        TimeSpan lastTime;
        public override void Update(GameTime gametime)
        {
            int y;
            y = Rectangle.Y;
            y += 1;

            Rectangle = new Rectangle(Rectangle.X, y, Rectangle.Width, Rectangle.Height);

            if (Rectangle.Y > 600)
            {
                Game1.TheGame.actualizaciones.Add(this);
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

                if (Rectangle.Intersects(ship.Rectangle))
                {
                    ship.Health -= 1;
                }

                if (Health <= 0)
                {
                    ship.Score += 10;
                }
            }

            if (this.Health <= 0)
            {

                Game1.TheGame.actualizaciones.Add(this);
                Game1.TheGame.actualizaciones.Add(new Explosion(Rectangle));
            }
        }
    }
}
