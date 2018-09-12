using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Zombies.Sprites
{
    public class ZombieFactory : FabricBase
    {
        public override void Update(GameTime gametime)
        {
            if (Game1.TheGame.sprites.Count() < 10)
            {
                Game1.TheGame.actualizaciones.Add(new Zombie());
            }
        }
    }
}
