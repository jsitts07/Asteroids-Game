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
    class SmallAsteroid : Asteroid
    {
        const int SMALL_ASTEROID_SPEED = 5;
        static Image smallAsteroidImg = Properties.Resources.spr_asteroid_small;

        public SmallAsteroid(int x, int y) : base(x,y,smallAsteroidImg)
        {
            Speed = SMALL_ASTEROID_SPEED;
            hitSound = new SoundPlayer(Properties.Resources.snd_explosion1);
        }

        public override void Hit(List<GameObject> objects)
        {
            base.Hit(objects); //Play sound

            Destroy = true; //destroy the small asteroid 

        }
    }


}
