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
    public class Background : Sprite, Updateable
    {
        public Background()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/BG");
            Rectangle = new Rectangle(0, 0, Game1.TheGame.GraphicsDevice.Viewport.Width, Game1.TheGame.GraphicsDevice.Viewport.Height);
            Color = Color.White;
        }

        public override void Update(GameTime gametime)
        {
            
        }
    }
}
