using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Asteroids.Sprites
{
    public class AlienFactory : FabricBase
    {
        TimeSpan frameTime;

        public override void Update(GameTime gametime)
        {
            if (gametime.TotalGameTime.Subtract(frameTime).Milliseconds > 600)
            {
                frameTime = gametime.TotalGameTime;
                Game1.TheGame.actualizaciones.Add(new Alien());
            }
        }
    }
}
