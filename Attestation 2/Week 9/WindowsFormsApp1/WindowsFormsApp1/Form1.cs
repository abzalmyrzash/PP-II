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
        int cnt = 0;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Text = "Blue";
            btn.BackColor = Color.Blue;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch (cnt)
            {
                case 0:
                    btn.BackColor = Color.Blue;
                    break;
                case 1:
                    btn.BackColor = Color.Red;
                    break;
                case 2:
                    btn.BackColor = Color.Green;
                    break;
            }
            btn.Text = btn.BackColor.Name;

            cnt = (cnt + 1) % 3;
        }
    }
}
