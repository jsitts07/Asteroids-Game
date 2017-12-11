using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using GameLib;


namespace Asteroids
{
    class Explosion : GameObject
    {
        SpriteSheet sheet;
        SoundPlayer sound;

        public Explosion(int x, int y) : base(x,y)
        {
            sheet = new SpriteSheet(Properties.Resources.spr_explosion_strip9, 9);
            sheet.x = x;
            sheet.y = y;

            sound = new SoundPlayer(Properties.Resources.snd_explosion3);
        }

        public override void Update()
        {
            if(sheet.Done)
            {
                Destroy = true; 
            }
        }

        public override void Draw(Graphics g)
        {
            sheet.Draw(g); 
        }

    }
}
