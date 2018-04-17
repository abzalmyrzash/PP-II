using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Button btn; int width, height;
        public Form1()
        {
            InitializeComponent();
            btn = new Button();
            btn.Size = new Size(50, 50);
            btn.Location = new Point(0, 0);
            btn.BackColor = Color.White;
            Controls.Add(btn);
            Width = 500;
            Height = 500;
            timer1.Start();
            width = Width; height = Height;
        }

        int[] dirX = { 0, 1, 0, -1 };
        int[] dirY = { 1, 0, -1, 0 };
        int dx = 10, dy = 10;
        int i = 0, k = 0;

        Color[] color = { Color.Red, Color.Blue, Color.Green, Color.Yellow };

        private void timer1_Tick(object sender, EventArgs e)
        {
            BackColor = color[i];
            label2.Text = Width + " " + Height;
            int dX = dx * dirX[i];
            int dY = dy * dirY[i];
            int x = btn.Location.X, y = btn.Location.Y;
            
            btn.Location = new Point(x + dX, y + dY);

            x = btn.Location.X; y = btn.Location.Y;
            if ((x + btn.Width + 20 >= width && i == 1) ||
                (x <= Width - width && i == 3) ||
                (y + btn.Height + 40 >= height && i == 0) ||
                (y <= Height - height && i == 2))
            {
                i = (i + 1) % 4;
                k = (k + 1) % 3;
                if(k == 0)
                {
                    width -= btn.Width;
                    height -= btn.Height;
                }
            }
            label1.Text = (x + btn.Width) + "; " + (y + btn.Height);
        }
    }
}
