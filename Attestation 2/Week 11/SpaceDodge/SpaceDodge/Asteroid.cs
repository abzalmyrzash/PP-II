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
    class Asteroid : Object
    {
        Bitmap btm = new Bitmap("asteroids.png");

        Image CutFromBitmap(int type)
        {
            Rectangle section = new Rectangle(128 * (type % 8) + 16, 128 * (type / 8) + 16, 128 - 32, 128 - 32);
            Bitmap bmp = new Bitmap(section.Width, section.Height);

           /* Graphics g = Graphics.FromImage(bmp);
            
            g.DrawImage(btm, 0, 0, section, GraphicsUnit.Pixel);
            return bmp;*/
            return btm.Clone(section, btm.PixelFormat);
        }

        public Asteroid()
        {
            Random r = new Random();
            alive = true;

            pb = new PictureBox();
            pb.SizeMode = PictureBoxSizeMode.StretchImage;
            pb.Image = CutFromBitmap(new Random().Next(0, 63));
            pb.Width = r.Next(20, 40);
            pb.Height = pb.Width;

            
            int side = r.Next(1, 3);
            switch (side)
            {
                case 1:
                    y = 0; x = r.Next(0, Game.width);
                    break;
                case 2:
                    x = 0; y = r.Next(0, Game.height / 2);
                    break;
                case 3:
                    x = Game.width; y = r.Next(0, Game.height / 2);
                    break;
            }

            pb.Location = new Point((int)x, (int)y);

            do
            {
                dx = r.Next(-200, 200) / (float)500;
            } while (dx == 0);

            do
            {
                dy = r.Next(-200, 200) / (float)500;
            } while (dy == 0);
            
            Add();
        }

        public void checkDestroyed(int n)
        {
            foreach (Bullet b in Game.bullets)
            {
                if (Game.Collision(this, b))
                {
                    Game.player.score.Text = (int.Parse(Game.player.score.Text) + 1).ToString();
                    Game.f.Controls.Remove(pb);
                    Game.asteroids.Remove(this);
                    Game.asteroids.Add(new Asteroid());
                    b.alive = false;
                    return;
                }
            }

            for(int i = 0; i < Game.asteroids.Count; )
            {
                if (Game.Collision(this, Game.asteroids[i]) && i != n)
                {
                    Game.f.Controls.Remove(Game.asteroids[i].pb);
                    Game.asteroids.Remove(Game.asteroids[i]);
                    Game.f.Controls.Remove(pb);
                    Game.asteroids.Remove(this);
                    break;
                }
                else i++;
            }
            if (x + pb.Width <= -50) x = Game.width - 20;
            if (x >= Game.width + 50) x = -pb.Width + 20;
            if (y + pb.Height <= -50) y = Game.height - 20;
            if (y >= Game.height + 50) y = -pb.Width + 20;
        }

        
    }


    /*                       side 1
            +------------------------------------+
            |       o                           o|
            |              o          o          |
     side 2 |          o                o        | side 3
            |o                                   |
            |____________________________________|
            |                                    |
            |           asteroids can't          |
            |  A          spawn here             |
            |                                    |
            |                                    |
            +------------------------------------+

    A - spaceship
    o - asteroids

   Asteroids will spawn only at the window's border and only on the upper half
    */
}
