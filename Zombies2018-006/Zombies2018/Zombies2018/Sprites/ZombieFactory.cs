using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Zombies2018.Sprites
{
    public class ZombieFactory : FabricBase
    {
        public override void Update(GameTime gameTime)
        {
            if (Game1.TheGame.sprites.Count < 7)
                Game1.TheGame.Actualizaciones.Add(new Zombie());
        }
    }
}
