using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using System.Drawing;
using System.Media;

namespace Asteroids
{
    class LargeAsteroid : Asteroid
    {
        static Image largeAsteroidImg = Properties.Resources.spr_asteroid_large;
        const int LARGE_ASTEROID_SPEED = 2;

        public LargeAsteroid(int x, int y) : base(x,y,largeAsteroidImg)
        {
            Speed = LARGE_ASTEROID_SPEED; 

        }

        public override void Hit(List<GameObject> objects)
        {
            base.Hit(objects); //Play sound

            //Create 2 medium frags
            MediumAsteroid m = new MediumAsteroid(x, y);
            objects.Add(m);
            m = new MediumAsteroid(x, y);
            objects.Add(m);

            Destroy = true; //destroy the large asteroid 

        }

    }
}
