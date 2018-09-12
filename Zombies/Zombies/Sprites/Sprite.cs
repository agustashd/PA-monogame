using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies.Sprites
{
    // Abstract: clases que no puedo instanciar
    public abstract class Sprite : Updateable
    {
        protected static Random random;

        public Texture2D Image { get; protected set; }
        public Rectangle Rectangle { get; protected set; }
        public Color Color { get; protected set; }

        public Sprite()
        {
            if (random == null)
                random = new Random();
        }

        public void Draw(GameTime gametime)
        {
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
        }

        public abstract void Update(GameTime gametime);

    }
}
