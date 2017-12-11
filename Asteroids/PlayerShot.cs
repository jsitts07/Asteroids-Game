using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;
using GameLib;

namespace Asteroids
{
    class PlayerShot : GameObject
    {

        int ticks=0;
        const int MAX_TICKS = 100;

        public PlayerShot(int x, int y, int direction) : 
            base(x,y, Properties.Resources.spr_shot)
        {
            Wrap = true;
            Speed = 10;
            Direction = direction;
        }

        public override void Update()
        {
            base.Update();

            ticks++;
            if (ticks == MAX_TICKS)
                Destroy = true; 

        }

    }
}
