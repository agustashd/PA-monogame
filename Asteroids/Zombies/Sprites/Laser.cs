using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Asteroids.Sprites
{
    public class Laser : Sprite
    {
        public int Speed { get; set; }
        Ship ship;
        int energy;

        public Laser(Ship owner, int energy = 15)
        {
            ship = owner;
            Rectangle = new Rectangle(ship.Rectangle.Center - new Point(7, 55) , new Point(14, 55));
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/laser");
            Color = Color.White;
            Speed = 5;
            this.energy = energy;
        }

        bool firstRun = true;

        public override void Update(GameTime gametime)
        {
            if (firstRun)
            {
                SoundEffect sonido = Game1.TheGame.Sounds[Game1.Soundfx.Laser];
                sonido.CreateInstance();
                sonido.Play();
                firstRun = false;
            }

            Rectangle = new Rectangle(Rectangle.X, Rectangle.Y - Speed, Rectangle.Width, Rectangle.Height);

            if (Rectangle.Y > Game1.TheGame.GraphicsDevice.Viewport.Height || Rectangle.Y < 0)
            {
                Game1.TheGame.actualizaciones.Add(this);
            }

            foreach (var sprite in Game1.TheGame.sprites)
            {
                Alien alien = sprite as Alien;
                if (alien != null)
                {
                    if (alien.Rectangle.Intersects(Rectangle))
                    {
                        alien.Health -= energy;
                        ship.Score += 1;
                        Game1.TheGame.actualizaciones.Add(this);
                        break;
                    }
                }

            }
        }
    }
}
