using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        static List<Ball> balls = new List<Ball>();
        public Form1()
        {
            InitializeComponent();
            timer1.Start();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Ball b = new Ball();
            b.l.Location = new Point(e.X, e.Y);
            balls.Add(b);
            Controls.Add(b.l);
        }
        

        private void Fall(object sender, EventArgs e)
        {
            for (int i = 0; i < balls.Count(); i++)
            {
                balls[i].Update();
            }
        }
    }
}
