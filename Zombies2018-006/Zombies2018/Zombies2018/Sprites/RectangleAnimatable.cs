using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies2018.Sprites
{
    public abstract class RectangleAnimatable:Alive
    {
        protected List<Rectangle> rectangulos;
        protected int selectedRectangle;

        public RectangleAnimatable()
        {
            rectangulos = new List<Rectangle>();
        }

        public override void Draw(GameTime gameTime)
        {
            base.DrawHealth(gameTime);
            Game1.TheGame.spriteBatch.Draw(Image,
                                            Rectangle,
                                            rectangulos[selectedRectangle],
                                            Color);
        }

    }
}
