
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GameLib;
using System.Drawing;
using System.Media;
//this object is the generic 
namespace Asteroids
{
    abstract class Asteroid : GameObject
    {
        static Random r = new Random();
        public SoundPlayer hitSound;

        public Asteroid(int x, int y, Image image) : base(x, y, image)
        {
            Direction = r.Next(360);
            Wrap = true;
        }

        public int Radius
        {
            get
            {
                return image.Width / 2;
            }
        }

        void PlayHitSound()
        {
            if (hitSound != null) { hitSound.Play();  }
        }

        //the list is is for the asteroid that was hit to put its fragments in
        public virtual void Hit(List<GameObject> objects)
        {
            PlayHitSound();
        }
    }
}
