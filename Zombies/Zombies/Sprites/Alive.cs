using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombies.Sprites
{
    public class Alive : Sprite, Mortable
    {
        public virtual int Health { get; set; }

        protected Texture2D vida;

        //public Alive()
        //{

        //}

        public override void Update(GameTime gametime)
        {

        }

        public override void Draw(GameTime gametime)
        {
            DrawHealth(gametime);

            base.Draw(gametime);
        }

        protected void DrawHealth(GameTime gametime)
        {
            if (Health > 0)
            {
                vida = new Texture2D(Game1.TheGame.GraphicsDevice, Health, 5);
                Color[] data = new Color[Health * 5];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = Color.Red;
                }

                vida.SetData(data);
                Game1.TheGame.spriteBatch.Draw(vida, new Vector2(Rectangle.X, Rectangle.Y - 5), Color.Red);
            }
        }
    }
}
