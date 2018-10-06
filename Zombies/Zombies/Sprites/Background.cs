using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Zombies.Sprites
{
    public class Background : BackgroundBase
    {
        public Background()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/BG");
            // Es lo mismo usar Bounds o la linea de abajo
            //Rectangle = new Rectangle(0, 0, Game1.TheGame.GraphicsDevice.Viewport.Width, Game1.TheGame.GraphicsDevice.Viewport.Height);
            Rectangle = Game1.TheGame.GraphicsDevice.Viewport.Bounds;
        }

        public override void Draw(GameTime gametime)
        {
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
            Rectangle rectangle2 = Rectangle;
            rectangle2.X += Rectangle.Width;
            Game1.TheGame.spriteBatch.Draw(Image, rectangle2, Color);
        }

        public override void Update(GameTime gametime)
        {
            if (Rectangle.X <= -Rectangle.Width)
            {
                Rectangle = new Rectangle(0,
                                        Rectangle.Y,
                                        Rectangle.Width,
                                        Rectangle.Height);
            } else
            {
                Rectangle = new Rectangle(Rectangle.X - 1,
                                        Rectangle.Y,
                                        Rectangle.Width,
                                        Rectangle.Height);
            }
        }
    }
}
