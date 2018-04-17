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
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Width = Game.width + 20; Height = Game.height + 40;
            BackColor = Color.Black;
            MaximizeBox = false;
        }

        
        private void Form1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) Game.player.up = true;
            if (e.KeyCode == Keys.S) Game.player.down = true;
            if (e.KeyCode == Keys.A) Game.player.left = true;
            if (e.KeyCode == Keys.D) Game.player.right = true;
            if (e.KeyCode == Keys.Space) Game.player.shoot = true;
        }

        private void Form1_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.W) Game.player.up = false;
            if (e.KeyCode == Keys.S) Game.player.down = false;
            if (e.KeyCode == Keys.A) Game.player.left = false;
            if (e.KeyCode == Keys.D) Game.player.right = false;
            if (e.KeyCode == Keys.Space) Game.player.shoot = false;
        }
        
        public void Add(PictureBox pb)
        {
            Controls.Add(pb);
        }
    }
}
