using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace GameLib  
{
    class GameObject  
    {
        protected int x;
        protected int y;
        protected int width;
        protected int height;

        protected Rectangle bounds = new Rectangle();
        protected Image image;
        protected bool visible = true;
        protected float hSpeed = 0;
        protected float vSpeed = 0;
        protected bool destroy = false;


        private bool wrap = false;
        private int speed = 0;
        private int direction = -1;
        

        public GameObject() //change this to be your class's name
        {

        }

        public GameObject(int x, int y, Image i) //change this to be your class's name
        {
            SetImage(i);
            SetPosition(x, y);
        }

        public GameObject(int x, int y) //change this to be your class's name
        {
            SetPosition(x, y);
        }
         
        public void SetPosition(int x, int y)
        {
            this.x=x; 
            this.y=y;
        }

        public int GetX() { return x;  }
        public int GetY() { return y; }
        public virtual int GetLeft() { return x - width / 2; }
        public virtual int GetRight() { return x + width / 2; }
        public virtual int GetBottom() { return y + height / 2; }
        public virtual int GetTop() { return y - height / 2; }

        /*The following functions are for
         * player characters
         */
          
        public int Speed
        {
            set
            {
                this.speed = value;
                hSpeed =  (float)Math.Sin(Direction / 57.3f) * speed;
                vSpeed = (float)Math.Cos(Direction / 57.3f) * speed;
            }

            get
            {
                return speed;
            }
        }

         

        public virtual void MoveUp()
        {
            y -= speed;
        }
       
        public virtual void MoveDown()
        {
            y += speed;
        }

        public virtual void MoveLeft()
        {
            x -= speed; 
        }

        public virtual void MoveRight()
        {
            x += speed;
        }

        public virtual void Draw(Graphics g)
        {
            //add your code here
            if (image != null && visible)
            {
                g.DrawImage(image, x - image.Width / 2, y - image.Height / 2);
            }
        }

        //forces the object to be drawn the supplied coordinates
        public virtual void DrawAt(Graphics g, int x, int y)
        {
            //add your code here
            if (image != null && visible)
            {
                g.DrawImage(image, x - image.Width / 2, y - image.Height / 2);
            }
        }

        public virtual void SetVisible(bool yesNo)
        {
            this.visible = yesNo;
        }

        public virtual bool IsVisible()
        {
            return visible;
        }

        public virtual void Update()
        {
            //add your code here
            if (direction != -1)
            {
                x = (int)(x + hSpeed);
                y = (int)(y - vSpeed);
            }

            if (Wrap)
            {
                if (x > Game.Width)
                    x = 0;
                else if (x < 0)
                    x = Game.Width;
                if (y < 0)
                    y = Game.Height;
                else if (y >= Game.Height)
                    y = 0;
            }
        }

        public virtual void SetImage(Image i)
        {
            image = i;
            width = image.Width;
            height = image.Height;
        }

        public Rectangle GetBounds()
        {
            bounds.X = x - width / 2;
            bounds.Y = y - height / 2;
            bounds.Width = width;
            bounds.Height = height;
            return bounds;   
        }

        public bool IsTouching(GameObject go)
        {
            return GetBounds().IntersectsWith(go.GetBounds());
        }

        public bool IsTouching(Rectangle r)
        {
            return GetBounds().IntersectsWith(r);
        }

        public virtual int GetHeight() { return height; }
        public virtual int GetWidth() { return width; }

        public static int GetAngle(int x1, int y1, int x2, int y2)
        {
            //compute the angle between the  current location and the new destination
            double angle = Math.Atan2((double)(x2- x1), (double)(y1 - y2));

            if (angle < 0)
            {
                angle += 2 * Math.PI;
            }
            angle *= 57.3;
            
           return (int)angle;
        }

        public void SetDirectionAndSpeed(int angle, int speed)
        {
            hSpeed = (float)Math.Sin(angle/57.3) * speed;
            vSpeed = (float)Math.Cos(angle/57.3) * speed;
            direction = angle;  
        }
  
        public double GetDistance(Point p)
        {
            return GetDistance((double)p.X, (double)p.Y);
        }

        public double GetDistance(double x, double y)
        {
            double dx = (x-this.x);
            double dy = (y-this.y);
            return Math.Sqrt(dx * dx + dy * dy);
            
        }
        
        public int GetAngleTo(int x, int y)
        {
            return GetAngle(this.x, this.y, x, y);
        }
        
        public double GetDistance(int x, int y)
        {
            return GetDistance((double)x, (double)y);
        }

        public double GetDistance(GameObject obj)
        {
            return GetDistance(obj.GetX(), obj.GetY());
        }

        public int Direction
        {
            set
            {
                if (value >= 360)
                {
                    direction = value % 360;
                }
                else if (value < 0)
                {
                    direction = (360 - (value * -1) % 360);
                }
                else
                {
                    direction = value;
                }

                hSpeed = (float)Math.Sin(direction / 57.3) * speed;
                vSpeed = (float)Math.Cos(direction / 57.3) * speed;

            }

            get
            {
                return direction;
            }
        }
        

        public int X { get { return x; }  set { x = value; } }
        public int Y { get { return y; }  set { y = value; } }
        public bool Destroy { get; set; }
        public bool Wrap { get; set; }

        
    }
}
