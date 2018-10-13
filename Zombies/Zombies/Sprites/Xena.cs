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
    public class Xena : RectangleAnimate
    {
        public int Score { get; internal set; }

        public Xena()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/RUNRUN");
            Rectangle = new Rectangle(50, 50, 80, 80);
            Health = 100;
            var w = Image.Width / 8;
            for (int i = 0; i < 8; i++)
            {
                rectangulos.Add(new Rectangle(w * i, 0, w, Image.Height));
            }
        }

        TimeSpan lastTime, powerTime, frameTime;
        bool power;
        int daño;
        Rectangle rectBack;


        // Para completar el codigo que le falta al metodo Update de la clase abstracta Sprite
        // tenemos que volver a escribir el metodo y completar con lo que queremos que haga
        public override void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime.Subtract(frameTime).Milliseconds > 200)
            {
                frameTime = gametime.TotalGameTime;
                selectedRectangle++;
                if (selectedRectangle > 7) selectedRectangle = 0;
            }

            int x, y;
            x = Rectangle.X;
            y = Rectangle.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                x -= 2;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                x += 2;
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
                y -= 2;
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
                y += 2;

            if (x > Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width)
                x = Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width;
            else if (x < 0)
                x = 0;

            if (y > Game1.TheGame.GraphicsDevice.Viewport.Height - Rectangle.Height)
                y = Game1.TheGame.GraphicsDevice.Viewport.Height - Rectangle.Height;
            else if (y < 0)
                y = 0;

            Rectangle = new Rectangle(x, y, Rectangle.Width, Rectangle.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.C) && !power)
            {
                power = true;
                powerTime = gametime.TotalGameTime;
                rectBack = Rectangle;
            }

            if (power)
            {
                this.daño = gametime.TotalGameTime.Subtract(powerTime).Seconds;
                Rectangle = new Rectangle(
                    Rectangle.X,
                    Rectangle.Y,
                    (int)(rectBack.Width * (1 + (float)daño / 4)),
                    (int)(rectBack.Height * (1 + (float)daño / 4))
                    );
            }

            if (Keyboard.GetState().IsKeyUp(Keys.C) && power)
            {
                Espada espada = new Espada(this, 20 * this.daño);
                Game1.TheGame.actualizaciones.Add(espada);
                power = false;
                Rectangle = rectBack;
            }

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && gametime.TotalGameTime.Subtract(lastTime).Milliseconds > 200)
            {
                lastTime = gametime.TotalGameTime;
                Espada espada = new Espada(this);
                Game1.TheGame.actualizaciones.Add(espada);
            }
        }
    }
}
