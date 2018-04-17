using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Media;
using System.Windows.Input;

namespace SpaceDodge
{
    public class Object
    {
        public float x, y;
        protected float dx, dy;
        public PictureBox pb;
        public bool alive;
        

        public Object() { alive = true; }

        public void Update()
        {
            x += dx * Game.time; y += dy * Game.time;
            pb.Location = new Point((int)x, (int)y);
        }

        public void Add()
        {
            if (Thread.CurrentThread == Program.thr)
            {
                Game.f.Invoke(new MethodInvoker(() => { Game.f.Controls.Add(pb); }));
            }
            else Game.f.Controls.Add(pb);
        }
    }

    
}
