using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Sprites
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
            // Busco el ship entre los sprites que hay y dibujo
            // la vida de la nave de otra forma para diferenciarla
            foreach (var sprite in Game1.TheGame.sprites)
            {
                if (sprite is Ship)
                {
                    this.DrawHealth(gametime);
                    break;
                }
            }
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, rectangulos[selectedRectangle], Color);
        }

        protected override void DrawHealth(GameTime gametime)
        {
            if (Health > 0)
            {
                vida = new Texture2D(Game1.TheGame.GraphicsDevice, Health, 15);
                Color[] data = new Color[Health * 15];
                for (int i = 0; i < data.Length; i++)
                {
                    data[i] = Color.ForestGreen;
                }

                vida.SetData(data);
                Game1.TheGame.spriteBatch.Draw(vida, new Vector2(0, 0), Color.GreenYellow);
            }
        }
    }
}
