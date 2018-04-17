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
        PictureBox pb = new PictureBox();
        Bitmap btm;
        int radius;
        Graphics g;
        bool ok = false;
        Point center = new Point(200, 200);
        Pen p = new Pen(Color.Blue, 3);

        public Form1()
        {
            InitializeComponent();
            pb.Location = new Point(0, 70);
            Controls.Add(pb);
            pb.Size = new Size(500, 500);
            btm = new Bitmap(pb.Width, pb.Height);
            pb.Image = btm;
            textBox1.Text = "0";
            g = Graphics.FromImage(btm);
            g.Clear(Color.White);
            ok = true;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            radius = trackBar1.Value;
            textBox1.Text = radius + "";
            if (ok)
            {
                g.Clear(Color.White);
                g.DrawEllipse(p, new Rectangle(center.X - radius, center.Y - radius, 2 * radius, 2 * radius));
                pb.Refresh();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int val = 0;
            if (isNum(textBox1.Text)) val = int.Parse(textBox1.Text);
            else textBox1.Text = "0";
            if (val > 20)
            {
                val = 20;
                textBox1.Text = "20";
            }
            trackBar1.Value = val;
            radius = val;
            if (ok)
            {
                g.Clear(Color.White);
                g.DrawEllipse(p, new Rectangle(center.X - radius, center.Y - radius, 2 * radius, 2 * radius));
                pb.Refresh();
            }
        }

        private bool isNum(string s)
        {
            if (s.Length == 0) return false;
            foreach (char c in s)
            {
                if (c < '0' || c > '9') return false;
            }
            if(int.Parse(s) >= 0) return true;
            return false;
        }
    }
}
