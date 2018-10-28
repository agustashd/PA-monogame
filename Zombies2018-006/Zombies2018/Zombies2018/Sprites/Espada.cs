using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace Zombies2018.Sprites
{
    public class Espada : Sprite
    {
        public int Speed { get; set; }
        Xena xena;
        int Energy;

        public Espada(Xena owner, int Energy = 10)
        {
            xena = owner;
            Rectangle = new Rectangle(
                                    owner.Rectangle.Center,
                                    new Point(70, 30)
                                    );
            Image = Game1.TheGame.Content.Load<Texture2D>("Images/Bala");
            Speed = 10;
            this.Energy = Energy; 
        }

        bool firstRun = true;

        public override void Update(GameTime gameTime)
        {
            if (firstRun)
            {
                SoundEffect sonido = Game1.TheGame.Sounds[Game1.Sonidos.Disparo];
                sonido.CreateInstance();
                sonido.Play();
                firstRun = false;
            }

            #region coordenadas

            Rectangle = new Rectangle(Rectangle.X + Speed,
                                        Rectangle.Y, 
                                        Rectangle.Width, 
                                        Rectangle.Height);

            if (Rectangle.X > Game1.TheGame.GraphicsDevice.Viewport.Width
                || Rectangle.X < 0)
                Game1.TheGame.Actualizaciones.Add(this);

            #endregion

            foreach (var item in Game1.TheGame.sprites)
            {
                Zombie zom = item as Zombie;
                if (zom != null /*item is Zombie*/)
                {
                    if (zom.Rectangle.Intersects(Rectangle))
                    {
                        zom.Health -= Energy;
                        xena.Score += 10;
                        Game1.TheGame.Actualizaciones.Add(this);
                        break;
                    }
                }
            }


        }
    }
}
