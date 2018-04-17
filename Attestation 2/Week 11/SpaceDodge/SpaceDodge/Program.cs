using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SpaceDodge
{
    static class Program
    {
        public static Thread thr;
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Game.Init();
            thr = new Thread(Game.Play);
            thr.SetApartmentState(ApartmentState.STA);
            thr.Start();
            Application.Run(Game.f);

            /*
            Thread AppThr = new Thread(() => Application.Run(Game.f));
            AppThr.Start();

            while (AppThr.IsAlive)
            {
                bool suspend = false;
                foreach (Bullet b in Game.bullets)
                {
                    if (!b.pbAdded)
                    {
                        thr.Suspend();
                        suspend = true;
                        Game.f.Controls.Add(b.pb);
                    }
                }

                foreach(Asteroid a in Game.asteroids)
                {
                    if(!a.pbAdded)
                    {
                        thr.Suspend();
                        suspend = true;
                        Game.f.Controls.Add(a.pb);
                    }
                }
                if(suspend) thr.Resume();
            }*/

            thr.Abort();
        }
    }
}
