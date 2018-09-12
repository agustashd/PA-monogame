using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies.Sprites
{
    public class Zombie : Sprite
    {
        public Zombie()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/male");
            Rectangle = new Rectangle(
                Game1.TheGame.GraphicsDevice.Viewport.Width,
                random.Next(Game1.TheGame.GraphicsDevice.Viewport.Height - 100), 
                100, 100);
            Color = Color.White;
        }

        // Para completar el codigo que le falta al metodo Update de la clase abstracta Sprite
        // tenemos que volver a escribir el metodo y completar con lo que queremos que haga
        public override void Update(GameTime gametime)
        {
            int x;
            x = Rectangle.X;
            x -= 2;

            Rectangle = new Rectangle(x, Rectangle.Y, Rectangle.Width, Rectangle.Height);

            if (Rectangle.X < -100)
            {
                Game1.TheGame.actualizaciones.Add(this);
            }
        }
    }
}
