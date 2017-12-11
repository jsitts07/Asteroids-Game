using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Asteroids
{
    class SpriteSheet
    {
        int frames;
        Image image;
        int curFrame = 0;
        bool cycle = true;
        public int frameWidth;
        public int x, y;
        public int TicksPerUpdate { get; set; }

        public bool Done
        {
            get
            {
                return (curFrame == frames);
            }
        }
        public SpriteSheet(Image image, int numFrames)
        {
            frames = numFrames;
            this.image = image;
            frameWidth = image.Width / numFrames;
        }


        public void Draw(Graphics g)
        {
            Rectangle srcRect = new Rectangle(curFrame * frameWidth, 0, frameWidth, image.Height);

            g.DrawImage(image, 
                x - frameWidth/2,
                y - frameWidth/2,
                srcRect,
                GraphicsUnit.Pixel
                );

            if (cycle)
            {
                curFrame++;
                if (curFrame > frames) curFrame = 0;
            }
        }
    }
}
