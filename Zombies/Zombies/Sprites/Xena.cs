﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies.Sprites
{
    public class Xena : Alive
    {
        public Xena()
        {
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/nave");
            Rectangle = new Rectangle(50, 50, 80, 80);
            Health = 100;
        }

        TimeSpan lastTime, powerTime;
        bool power;
        // Para completar el codigo que le falta al metodo Update de la clase abstracta Sprite
        // tenemos que volver a escribir el metodo y completar con lo que queremos que haga
        public override void Update(GameTime gametime)
        {
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

            if (Keyboard.GetState().IsKeyDown(Keys.C))
            {
                power = true;
                powerTime = gametime.TotalGameTime;
            }

            if (Keyboard.GetState().IsKeyUp(Keys.C) && power)
            {
                Espada espada = new Espada(this, 10 * gametime.TotalGameTime.Subtract(powerTime).Seconds);
                Game1.TheGame.actualizaciones.Add(espada);
                power = false;
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
