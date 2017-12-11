using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Asteroids
{
    public partial class Form1 : Form
    {
        AsteroidGame game = new AsteroidGame();

        public Form1()
        {
            InitializeComponent();
            game.Reset();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            game.Update();

            pictureBox1.Invalidate();
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            game.Draw(e.Graphics);
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {//repeats
            //left and right
            
 
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {//single presses

            //handle file and thrust
            if (e.KeyCode.Equals(Keys.Space))
            {
                game.Player1Fire();
            }
            else if (e.KeyCode.Equals(Keys.Up))
            {
                game.Player1Up();
            }
            else if (e.KeyCode.Equals(Keys.Down))
            {
                game.Player1Down();
            }
            else if (e.KeyCode.Equals(Keys.Left))
            {
                game.Player1Left();
            }
            else if (e.KeyCode.Equals(Keys.Right))
            {
                game.Player1Right();
            }
        }
    }
}
