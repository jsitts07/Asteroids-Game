using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Templates
{
    class SpriteSequence
    {
        int yOffset = 0;
        int xOffset = 0;
        int numFrames;
        int curFrame = 0;
        Image image;
        int frameHeight = 0;
        int frameWidth = 0;
        int ticksPerFrame = 1;
        int tickCounter = 0;
        bool loop = true;
        bool done = false;

        Rectangle srcRect = new Rectangle();
        Rectangle destRect = new Rectangle();


        /*This class is used to create an animation from a sprite sheet.
         * The parameter are as follows:
         * spriteSheetImage - the image with the frames on it
         *  int xOffset - the x coordinate the frames start at (usually 0)
         *  int yOffset - the y coordinate the frames start at 
         *  int height - the height of each frame on the sprite sheet
         *  int width  - the width of each frame on the sprite sheet
         *  int numFrames - how many frames there are in the sequence
         */
        public SpriteSequence(Image spriteSheetImage,  int xOffset, int yOffset, int width, int height, int numFrames)
        {
            image = spriteSheetImage;
            frameHeight = height;
            frameWidth = width;
            this.numFrames = numFrames;
            this.xOffset = xOffset;
            this.yOffset = yOffset;
        }

        //draw currrent frame centered on x, y on graphics c
        public void Draw(Graphics g, int x, int y)
        {
            //src drawing destination rectangle
            srcRect.X = xOffset + curFrame * frameWidth;
            srcRect.Y = yOffset;
            srcRect.Width = frameWidth;
            srcRect.Height = frameHeight;
                        
            //create drawing destination rectangle
            destRect.X = x - frameWidth / 2;
            destRect.Y = y - frameHeight/2;
            destRect.Width = frameWidth;
            destRect.Height = frameHeight;

            g.DrawImage(image, destRect, srcRect, GraphicsUnit.Pixel);
        }

        /*Update the frame counter
         */
        public void NextFrame()
        {
            tickCounter++;

            if (tickCounter == ticksPerFrame)
            {
                tickCounter = 0;
                curFrame++;
                if (curFrame == numFrames)
                {
                    if (loop)
                    {
                        curFrame = 0;
                    }
                    else
                    {
                        done = true;
                        curFrame--; //undo the ++
                    }
                }
            }
        }

        public void SetTicksPerFrame(int ticks) { ticksPerFrame = ticks; }
        public void SetLooping(bool flag) { loop = flag; }
        public bool IsDone() { return done; }
        public void SetFrame(int f) { curFrame = f; tickCounter = 0; done = false; }
    }
}
 