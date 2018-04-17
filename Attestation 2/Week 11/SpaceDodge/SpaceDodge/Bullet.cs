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
    class Bullet : Object
    {
        Bitmap btm = new Bitmap("laser.png");
        public Bullet()
        {
            pb = new PictureBox();
            pb.Image = btm;
            pb.Height = btm.Height / 5 * 2;
            pb.Width = btm.Width / 2;
            x = Game.player.x + Game.player.pb.Width / 2 - pb.Width / 2;
            y = Game.player.y - pb.Height;
            dx = 0; dy = (float)-1.2;
            Add();
            Game.bullets.Add(this);
        }

        public bool WentOutside()
        {
            if (y <= -pb.Height || !alive)
            {
                //Game.bullets.Remove(this);
                Game.f.Controls.Remove(this.pb);
                return true;
            }
            return false;
        }
    }
}
