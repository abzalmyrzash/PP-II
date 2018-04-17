using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculator
{
    public partial class Form1 : Form
    {
        Calculator calc = new Calculator();
        public Form1()
        {
            InitializeComponent();
        }

        private void NumPressed(object sender, EventArgs e)
        {
            string text = (sender as Button).Text;
            if (Calculator.changeNum)
            {
                if (text == ".") tb.Text = "0.";
            }
            else
            {
                if (tb.Text == "0" && text != ".")
                {
                    if (!(text == "0" || text == ".")) tb.Text = text;
                }
                else if(!(tb.Text.Contains('.') && text == ".")) tb.Text += text;

            }

            if (text == "CE") tb.Text = "0";
        }

        private void Radian(object sender, EventArgs e)
        {
            Calculator.rad = !Calculator.rad;
            if (Calculator.rad) rad.BackColor = Color.Blue;
            else rad.BackColor = SystemColors.Control;
        }

        private void C_pressed(object sender, EventArgs e)
        {
            calc = new Calculator();
            tb.Text = "0";
        }

        private void TwoArgFunc(object sender, EventArgs e)
        {
            Calculator.changeNum = true;
            if (calc.operation == "")
            {
                calc.firstNum = int.Parse(tb.Text);
                calc.operation = (sender as Button).Text;
            }
            else
            {
                calc.secondNum = int.Parse(tb.Text);
                calc.Calculate(true);
                calc.firstNum = calc.result;
                calc.operation = (sender as Button).Text;
            }
        }
        
    }
}