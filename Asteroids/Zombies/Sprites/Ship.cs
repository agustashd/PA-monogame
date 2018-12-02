using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asteroids.Sprites
{
    public class Ship : RectangleAnimate
    {
        public int Score { get; internal set; } = 0;

        public Ship()
        {
            Rectangle = new Rectangle(125, 460, 40, 40);
            Health = 100;
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/ship");
            var img = Image.Width / 4;
            for (int i = 0; i < 4; i++)
            {
                rectangulos.Add(new Rectangle(img * i, 0, img, Image.Height));
            }
        }

        public override void Draw(GameTime gametime)
        {
            Game1.TheGame.spriteBatch.DrawString(Game1.TheGame.Fonts[Game1.Font.HUD],
                                                 "HP                 SCORE " + Score.ToString(),
                                                 new Vector2(2, 0),
                                                 Color.Thistle);
            if (Health <= 0 || Game1.TheGame.IsBossDead)
            {
                Game1.TheGame.spriteBatch.DrawString(Game1.TheGame.Fonts[Game1.Font.GameOver],
                                                     "GAME OVER", new Vector2(20, 50), Color.AntiqueWhite);
                Game1.TheGame.spriteBatch.DrawString(Game1.TheGame.Fonts[Game1.Font.Restart],
                                                     "Press ENTER to restart", new Vector2(40, 100), Color.Yellow);

                // Guarda el puntaje en el archivo Scores
                if (!Game1.TheGame.IsGameOver)
                {
                    FileStream fs = null;
                    fs = new FileStream("Scores.txt", FileMode.Append);
                    using (StreamWriter writer = new StreamWriter(fs))
                    {
                        writer.WriteLine(Score);
                    }
                }

                // Leo el archivo y saco los 5 primeros puntajes para mostrarlos
                string[] readScores = File.ReadAllLines("Scores.txt");
                var topScores = readScores.OrderByDescending(x => int.Parse(x)).Take(5).ToList();
                var position = 125;

                for (int i = 1; i <= topScores.Count(); i++)
                {
                    var text = i.ToString() + ".  " + topScores[i - 1];
                    position += 50;
                    Game1.TheGame.spriteBatch.DrawString(Game1.TheGame.Fonts[Game1.Font.Score],
                                                     text, new Vector2(70, position), Color.Red);
                }
                //position = 125;
                Game1.TheGame.IsGameOver = true;
            }
            base.Draw(gametime);
        }

        TimeSpan lastTime, frameTime;

        // Para completar el codigo que le falta al metodo Update de la clase abstracta Sprite
        // tenemos que volver a escribir el metodo y completar con lo que queremos que haga
        public override void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime.Subtract(frameTime).Milliseconds > 200)
            {
                frameTime = gametime.TotalGameTime;
                selectedRectangle++;
                if (selectedRectangle > 3)
                    selectedRectangle = 0;
            }

            int x, y;
            x = Rectangle.X;
            y = Rectangle.Y;
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
                x -= 2;
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
                x += 2;

            if (x > Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width)
                x = Game1.TheGame.GraphicsDevice.Viewport.Width - Rectangle.Width;
            else if (x < 0)
                x = 0;

            Rectangle = new Rectangle(x, y, Rectangle.Width, Rectangle.Height);

            if (Keyboard.GetState().IsKeyDown(Keys.Space) && gametime.TotalGameTime.Subtract(lastTime).Milliseconds > 200)
            {
                lastTime = gametime.TotalGameTime;
                Laser laser = new Laser(this);
                Game1.TheGame.actualizaciones.Add(laser);
            }

            if (Score > 50 && !Game1.TheGame.BossTime)
            {
                Boss boss = new Boss();
                Game1.TheGame.actualizaciones.Add(boss);
                Game1.TheGame.BossTime = true;
            }
        }
    }
}
