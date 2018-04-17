using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Form1 : Form
    {
        Bitmap btm;
        Point cur, prev;
        Graphics g;
        Pen pen = new Pen(Color.Green, 5);

        public Form1()
        {
            InitializeComponent();
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            pictureBox1.Refresh();
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            prev = e.Location;
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                cur = e.Location;
                Rectangle r = new Rectangle();
                r.Location = new Point(Math.Min(cur.X, prev.X), Math.Min(cur.Y, prev.Y));
                r.Width = Math.Abs(cur.X - prev.X);
                r.Height = Math.Abs(cur.Y - prev.Y);
                g.Clear(Color.White);
                DrawArrow(r);
            }
        }

        private void DrawArrow(Rectangle r)
        {
            Point[] points =
            {
                new Point(r.X, r.Y + r.Height / 4),
                new Point(r.X + r.Width / 2, r.Y + r.Height / 4),
                new Point(r.X + r.Width / 2, r.Y),
                new Point(r.X + r.Width, r.Y + r.Height / 2),
                new Point(r.X + r.Width / 2, r.Y + r.Height),
                new Point(r.X + r.Width / 2, r.Y + r.Height * 3 / 4),
                new Point(r.X, r.Y + r.Height * 3 / 4)
            };
            
            g.DrawPolygon(pen, points);
            pictureBox1.Refresh();
        }
    }
}


/*
                  |\  
     _____________  \
    |                >                   
    |_____________  /
                  |/
 */