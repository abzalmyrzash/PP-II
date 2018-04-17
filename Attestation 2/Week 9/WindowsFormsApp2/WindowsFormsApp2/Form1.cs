using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Label l;

        bool isPrime(long n)
        {
            if (n < 2) return false;
            for(long i = 2; i * i <= n; i++)
            {
                if (n % i == 0) return false;
            }
            return true;
        }

        public Form1()
        {
            InitializeComponent();
            l = label1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (isPrime(long.Parse(textBox1.Text))) l.Text = "YES!";
                else l.Text = "NO!";
            }
            catch(Exception exc)
            {
                l.Text = exc.ToString();
            }
        }
    }
}
