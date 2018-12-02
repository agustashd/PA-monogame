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
    public class Mine : Sprite
    {
        public int Speed { get; set; }
        Boss boss;
        int energy;

        public Mine(Boss owner, int energy = 15)
        {
            boss = owner;
            Rectangle = new Rectangle(boss.Rectangle.Center - new Point(0, -10) , new Point(50, 48));
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/mine");
            Color = Color.White;
            Speed = 5;
            this.energy = energy;
        }

        bool firstRun = true;

        public override void Update(GameTime gametime)
        {
            if (firstRun)
            {
                SoundEffect sonido = Game1.TheGame.Sounds[Game1.Soundfx.Mine];
                sonido.CreateInstance();
                sonido.Play();
                firstRun = false;
            }

            Rectangle = new Rectangle(Rectangle.X, Rectangle.Y + Speed, Rectangle.Width, Rectangle.Height);

            if (Rectangle.Y > Game1.TheGame.GraphicsDevice.Viewport.Height)
            {
                Game1.TheGame.actualizaciones.Add(this);
            }

            foreach (var sprite in Game1.TheGame.sprites)
            {
                Ship ship = sprite as Ship;
                if (ship != null)
                {
                    if (ship.Rectangle.Intersects(Rectangle))
                    {
                        ship.Health -= energy;
                        Game1.TheGame.actualizaciones.Add(this);
                        Game1.TheGame.actualizaciones.Add(new Explosion(Rectangle));
                        break;
                    }
                }
            }
        }
    }
}
