using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Media;

namespace GameLib //TO DO: CHANGE THE NAMESPACE TO MATCH YOUR PROJECT
{
    class Game
    {

        public const int Width = 800;
        public const int Height = 500;

        
        protected List<GameObject> objects = new List<GameObject>();
 

      
 
        

        public Game()
        {
           

        }

        /*This Draw function is called by the 
         * form when the timer ticks.  This function redraws
         * the background, then tell everything in the game to draw
         */
        public virtual void Draw(Graphics g)
        {
            //draw the background 
            DrawBackground(g);

            //tell everything in the game to draw
            foreach (GameObject go in objects)
            {
                go.Draw(g);
            }
        }

        /*This function is called by the game when the timer
         * ticks.  This function will then tell everything in the 
         * game to update
         */
        public virtual void Update()
        {
            foreach (GameObject go in objects)
            {
                go.Update();
            }
            
            DeleteFlagged();
        }

        /*
        * PLAYER CONTROL FUNCTIONS
        *The form should call these when keys
        *or the gamepad are pressed. These functions
        *should then notify the players.
        */
        public virtual void Player1Up()
        {
            
        }


        public virtual void Player1Down()
        {

        }
        
        public virtual void Player1Left()
        {

        }

        public virtual void Player1Right()
        {

        }

        public virtual void Player1Fire()
        {

        }

        public virtual void Player1Jump()
        {

        }

        public virtual void Player2Up()
        {

        }

        public virtual void Player2Down()
        {

        }

        public virtual void Player2Left()
        {

        }

        public virtual void Player2Right()
        {

        }

        public virtual void Player2Fire()
        {

        }

        public virtual void Player2Jump()
        {

        }

        public virtual void Reset()
        {

        }

        /*
         * Deletes any objects that have been tagged for destruction 
         */
        protected void DeleteFlagged()
        {
            for (int i = 0; i < objects.Count; i++)
            {
                if (objects[i].Destroy)
                {
                    objects.RemoveAt(i);
                    i--;
                }
            }
        }

        /*
         * Subclasses need to overide this to 
         * draw the specific background
         */
        public virtual void DrawBackground(Graphics g)
        {

        }
    }
}
