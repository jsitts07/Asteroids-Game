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
    class MediumAsteroid : Asteroid
    { 
    
        static Image mediumAsteroidImg = Properties.Resources.spr_asteroid_medium;
        const int MEDIUM_ASTEROID_SPEED = 3;

        public MediumAsteroid(int x, int y) : base(x,y,mediumAsteroidImg)
        {
            Speed = MEDIUM_ASTEROID_SPEED;

        }

        public override void Hit(List<GameObject> objects)
        {
            base.Hit(objects); //Play sound

            //Create 2 medium frags
            SmallAsteroid m = new SmallAsteroid(x, y);
            objects.Add(m);
            m = new SmallAsteroid(x, y);
            objects.Add(m);

            Destroy = true; //destroy the medium asteroid 

        }

    }
}
