using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies.Sprites
{
    public abstract class RectangleAnimate : Alive
    {
        protected List<Rectangle> rectangulos;
        protected int selectedRectangle;

        public RectangleAnimate()
        {
            rectangulos = new List<Rectangle>();
        }

        public override void Draw(GameTime gametime)
        {
            base.DrawHealth(gametime);
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, rectangulos[selectedRectangle], Color);
        }
    }
}
