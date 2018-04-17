using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Paint_Fill
{
    enum Tool { Pen, Fill}
    public partial class Form1 : Form
    {
        Graphics g;
        Point prev, cur;
        GraphicsPath path = new GraphicsPath();
        Pen pen;
        Bitmap btm;
        Tool tool;
        

        public Form1()
        {
            InitializeComponent();
            pen = new Pen(colorDialog1.Color, 3);
            path = new GraphicsPath();
            tool = Tool.Pen;
            // Main graphics
            btm = new Bitmap(pictureBox1.Width, pictureBox1.Height);
            pictureBox1.Image = btm;

            // Create graphics from Bitmap
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            // save clicked position of mouse
            prev = e.Location;
            if(tool == Tool.Fill)
            {
                Queue<Point> q = new Queue<Point>();
                cur = e.Location;
                q.Enqueue(cur);
                Color initColor = btm.GetPixel(e.X, e.Y);
                if (initColor.ToArgb() != pen.Color.ToArgb())
                {
                    while (q.Count > 0)
                    {
                        cur = q.Dequeue();
                        Point[] points = {
                            new Point(cur.X - 1, cur.Y),
                            new Point(cur.X + 1, cur.Y),
                            new Point(cur.X, cur.Y - 1),
                            new Point(cur.X, cur.Y + 1)
                            };

                        foreach (Point p in points)
                        {
                            if (p.X >= 0 && p.X < btm.Width && p.Y >= 0 && p.Y < btm.Height)
                                if (btm.GetPixel(p.X, p.Y) == initColor)
                                {
                                    btm.SetPixel(p.X, p.Y, pen.Color);
                                    q.Enqueue(p);
                                }
                        }
                    }
                    pictureBox1.Refresh();
                }
            }
        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                cur = new Point(e.X, e.Y);
                switch (tool)
                {
                    case Tool.Pen:
                        g.DrawLine(pen, prev, cur);
                        prev = cur;
                        break;
                        
                }
                pictureBox1.Refresh();
            }
        }

        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            tool = Tool.Pen;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            tool = Tool.Fill;
        }

        private void color_Click(object sender, EventArgs e)
        {
            if(colorDialog1.ShowDialog() == DialogResult.OK)
            {
                pen.Color = color.BackColor = colorDialog1.Color;
            }
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
