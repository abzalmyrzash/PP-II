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
    class Player : Object
    {
        DateTime dtStart = DateTime.Now;
        Bitmap btm = new Bitmap("spaceship.png");
        public bool up, down, left, right, shoot;
        const float dX = (float)0.3, dY = (float)0.3;
        public Label score = new Label();

        public Player()
        {
            up = down = left = right = shoot = false;

            btm.MakeTransparent();
            x = 275; y = 500;
            pb = new PictureBox
            {
                Width = 50,
                Height = 70,
                Location = new Point((int)x, (int)y),
                SizeMode = PictureBoxSizeMode.StretchImage,
                Image = btm
            };

            score.ForeColor = Color.White;
            Game.f.Controls.Add(score);
            score.Text = "0";
        }

        public void Move()
        {
            dx = dy = 0;
            if (up) dy = -dY;
            if (down) dy = dY;
            if (left) dx = -dX;
            if (right) dx = dX;

            if (shoot && (DateTime.Now - dtStart).TotalMilliseconds >= 250)
            {
                dtStart = DateTime.Now;
                Bullet b = new Bullet();
            }
        }

        public void Check()
        {
            foreach(Asteroid a in Game.asteroids)
            {
                if(Game.Collision(this, a))
                {
                    MessageBox.Show("GAME OVER!\nYour score: " + score.Text);
                    Application.Exit();
                    Program.thr.Abort();
                    break;
                }
            }
        }
    }
}