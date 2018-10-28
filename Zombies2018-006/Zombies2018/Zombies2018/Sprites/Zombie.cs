using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombies2018.Sprites
{
    public class Zombie : Alive
    {

        public Zombie()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/male");
            Rectangle = new Rectangle(
                Game1.TheGame.GraphicsDevice.Viewport.Width,
                random.Next(Game1.TheGame.GraphicsDevice.Viewport.Height - 80),
                80, 80);
            //Color = Color.White;
            Health = random.Next(50, 100);
        }

        TimeSpan lasttime;
        public override void Update(GameTime gameTime)
        {
            #region coordenadas

            int x = Rectangle.X;
            x -= 2;

            Rectangle = new Rectangle(x, Rectangle.Y,
                Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -100)
            {
                Game1.TheGame.Actualizaciones.Add(this);
            }

            #endregion

            #region Colision

            if (gameTime.TotalGameTime.Subtract(lasttime).Milliseconds > 500)
            {
                lasttime = gameTime.TotalGameTime;
                Xena laHeroina = null;
                foreach (var item in Game1.TheGame.sprites)
                {
                    if (item is Xena)
                    {
                        laHeroina = item as Xena;
                        break;
                    }
                }
                if (laHeroina == null)
                {
                    throw new NullReferenceException("No esta Xena???");
                }
                if (Rectangle.Intersects(laHeroina.Rectangle))
                {
                    laHeroina.Health -= 10;
                }
            }
            #endregion

            if (Health <= 0)
            {
                Game1.TheGame.Actualizaciones.Add(this);
            }


        }
    }
}
