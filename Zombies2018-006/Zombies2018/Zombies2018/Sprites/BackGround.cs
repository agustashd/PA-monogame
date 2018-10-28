using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Zombies2018.Sprites
{
    public class BackGround : BackGroundBase
    {
        public BackGround()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/BG");
            Rectangle = Game1.TheGame.GraphicsDevice.Viewport.Bounds;
            //Color = Color.White;
        }

        public override void Draw(GameTime gameTime)
        {
            Game1.TheGame.spriteBatch.Draw(Image, Rectangle, Color);
            Rectangle rec2 = Rectangle;
            rec2.X += Rectangle.Width;
            Game1.TheGame.spriteBatch.Draw(Image, rec2, Color);
        }

        public override void Update(GameTime gameTime)
        {
            //Rectangle.X += -1;
            if (Rectangle.X <= -Rectangle.Width)
                Rectangle = new Rectangle(0,
                                            Rectangle.Y,
                                            Rectangle.Width,
                                            Rectangle.Height);

            else
                Rectangle = new Rectangle(Rectangle.X - 1, 
                                        Rectangle.Y,
                                        Rectangle.Width, 
                                        Rectangle.Height);
        }
    }
}
