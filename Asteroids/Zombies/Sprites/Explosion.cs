using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Sprites
{
    public class Explosion : Sprite
    {
        protected List<Rectangle> rectangulos_explosion;
        protected int selectedRectangle_explosion;

        public Explosion(Rectangle rectangle)
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/ship_explosion");
            Rectangle = rectangle;
            rectangulos_explosion = new List<Rectangle>();
            var exp = Image.Width / 6;
            for (int i = 0; i< 6; i++)
            {
                rectangulos_explosion.Add(new Rectangle(exp* i, 0, exp, Image.Height));
            }

        }
        TimeSpan frameTime;

        public override void Draw(GameTime gametime)
        {
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, rectangulos_explosion[selectedRectangle_explosion], Color);
        }

        bool firstRun = true;

        public override void Update(GameTime gametime)
        {
            if (firstRun)
            {
                SoundEffect sonido = Game1.TheGame.Sounds[Game1.Soundfx.Explosion];
                sonido.CreateInstance();
                sonido.Play();
                firstRun = false;
            }

            if (gametime.TotalGameTime.Subtract(frameTime).Milliseconds > 200)
            {
                frameTime = gametime.TotalGameTime;
                selectedRectangle_explosion++;
                if (selectedRectangle_explosion > 5)
                    Game1.TheGame.actualizaciones.Add(this);
            }
        }
    }
}
