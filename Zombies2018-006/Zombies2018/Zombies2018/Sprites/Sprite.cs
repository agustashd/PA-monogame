using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies2018.Sprites
{
    public abstract class Sprite: Updateable
    {
        protected static Random random;

        public Texture2D Image { get; protected set; }
        public Rectangle Rectangle { get; protected set; }
        public Color Color { get; protected set; }

        public Sprite()
        {
            if (random == null)
                random = new Random();
            Color = Color.White;
        }


        public virtual void Draw(GameTime gameTime)
        {
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
        }

        public abstract void Update(GameTime gameTime);

    }
}
