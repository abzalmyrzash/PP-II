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
    static class Game
    {
        public static Player player;
        public static List<Bullet> bullets = new List<Bullet>();
        public static List<Asteroid> asteroids = new List<Asteroid>();
        public static Keys keyUp, keyDown, keyLeft, keyRight, keyShoot;
        public static int width = 800, height = 600;
        private static DateTime dtStart = DateTime.Now;
        public static float time;
        private static DateTime dtAsteroid;

        public static Form1 f;


        public static bool Collision(Object a, Object b)
        {
            return (a.pb.Bounds.IntersectsWith(b.pb.Bounds));
        }

        public static void Init()
        {
            Game.f = new Form1();
            keyUp = Keys.W; keyDown = Keys.S;
            keyLeft = Keys.A; keyRight = Keys.D;
            keyShoot = Keys.Space;
            player = new Player();
            f.Controls.Add(player.pb);

            for (int i = 0; i < 10; i++)
            {
                asteroids.Add(new Asteroid());
            }
            dtAsteroid = DateTime.Now;
        }

        public static void Play()
        {
            while (true)
            {
                dtStart = DateTime.Now;
                player.Move();
                player.Update();
                player.Check();
                int i = 0;
                while (i < bullets.Count())
                {
                    bullets[i].Update();
                    if (bullets[i].WentOutside())
                    {
                        bullets.RemoveAt(i);
                    }
                    else i++;
                }
                i = 0;
                while(i < asteroids.Count())
                {
                    asteroids[i].Update();
                    asteroids[i].checkDestroyed(i);
                    i++;
                }
                time = (float)(DateTime.Now - dtStart).TotalMilliseconds;
                dtStart = DateTime.Now;
                SpawnAsteroids();
            }
        }

        private static void SpawnAsteroids()
        {
            if((DateTime.Now - dtAsteroid).Seconds > 1.5)
            {
                dtAsteroid = DateTime.Now;
                asteroids.Add(new Asteroid());
            }
        }
    }
}
