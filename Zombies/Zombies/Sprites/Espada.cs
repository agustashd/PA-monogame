using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombies.Sprites
{
    public class Espada : Sprite
    {
        public int Speed { get; set; }
        Xena xena;
        int energy;

        public Espada(Xena owner, int energy = 10)
        {
            xena = owner;
            Rectangle = new Rectangle(owner.Rectangle.Center, new Point(50, 25));
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/bala");
            Color = Color.White;
            Speed = 5;
            this.energy = energy;
        }

        public override void Update(GameTime gametime)
        {
            Rectangle = new Rectangle(Rectangle.X + Speed, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            if (Rectangle.X > Game1.TheGame.GraphicsDevice.Viewport.Width || Rectangle.X < 0)
            {
                Game1.TheGame.actualizaciones.Add(this);
            }

            foreach (var item in Game1.TheGame.sprites)
            {
                Zombie zmb = item as Zombie;
                if (zmb != null)
                {
                    if (zmb.Rectangle.Intersects(Rectangle))
                    {
                        zmb.Health -= energy;
                        xena.Score += 10;
                        Game1.TheGame.actualizaciones.Add(this);
                        break;
                    }
                }

            }
        }
    }
}
