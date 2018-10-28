using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zombies2018.Sprites
{
    public abstract class FabricBase: Updateable
    {
        protected static Random random;

        public FabricBase()
        {
            if (random == null)
                random = new Random();
        }

        public abstract void Update(GameTime gameTime);

    }
}
