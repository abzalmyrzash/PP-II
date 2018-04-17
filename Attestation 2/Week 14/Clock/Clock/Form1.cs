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

namespace Clock
{
    public partial class Form1 : Form
    {
        Hand s, m, h;
        Point center = new Point(200, 200);
        int r = 100;
        Graphics g;
        PictureBox pb;
        const double rad = 0.01745329251994329576923690768489;

        public Form1()
        {
            InitializeComponent();

            Bitmap btm = new Bitmap(Width, Height);
            Width = Height = 500;
            pb = new PictureBox();
            pb.Image = btm;
            pb.Size = new Size(Width, Height);

            g = Graphics.FromImage(btm);
            g.DrawEllipse(new Pen(Color.Black, 5), new Rectangle(center.X - r, center.Y - r, 2 * r, 2 * r));

            s = new Hand(80, Color.Green, 2);
            m = new Hand(70, Color.Blue, 3);
            h = new Hand(50, Color.Red, 5);

            DateTime dt = DateTime.Now;
            s.Angle = dt.Second * 6;
            m.Angle = dt.Minute * 6;
            h.Angle = dt.Hour * 6;
            pb.Refresh();
        }
    }
}
