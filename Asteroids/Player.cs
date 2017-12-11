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
    class Player : GameObject
    {
        int spriteDirection=0;
        const int THRUST = 2;
        const int MAX_SPEED = 4;
        SoundPlayer sound = new SoundPlayer(Properties.Resources.snd_fire);

        public Player()
        {
            x = 300;
            y = 400;
            Direction = 0;
            Wrap = true;
            image = Properties.Resources.spr_player_strip72;
        }


        public void RotateLeft()
        {
            SpriteDirection -= 10;
        }

        public void RotateRight()
        {
            SpriteDirection += 10;
        }

        public void Thrust()
        {

            float dx = (float)Math.Sin(Direction / 57.3f) * Speed;
            float dy = (float)Math.Cos(Direction / 57.3f) * Speed;

 
            float tx = (float)Math.Sin(SpriteDirection / 57.3f) * THRUST;
            float ty = (float)Math.Cos(SpriteDirection / 57.3f) * THRUST;

            float newX = dx + tx;
            float newY = dy + ty;

            float angle = (float)Math.Atan2((double)newX, (double)newY);

            Direction = (int)(angle *57.3);

            Speed = (int) Math.Sqrt(newX*newX + newY*newY);

            if (Speed > MAX_SPEED)
                Speed = MAX_SPEED;

        }


        public void Fire()
        {
            sound.Play();
        }

        public override void Draw(Graphics g)
        {
            Rectangle srcRct = new Rectangle
            {
                X = image.Width/72 * spriteDirection/5,
                Y = 0,
                Width = image.Width / 72,
                Height = image.Height
            };

            g.DrawImage(image, x - srcRct.Width/2, y - srcRct.Width / 2, srcRct, GraphicsUnit.Pixel);
        }

        public int SpriteDirection
        {
            set
            {
                spriteDirection = value;
                if (spriteDirection < 0)
                {
                    spriteDirection += 360;
                }
                else if (spriteDirection >= 360)
                {
                    spriteDirection -= 360;
                }
            }

            get
            {
                return spriteDirection;
            }
        }


    }
}
