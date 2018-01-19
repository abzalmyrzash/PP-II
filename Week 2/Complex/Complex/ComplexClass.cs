using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Complex
{
    class Complex
    {
        public int a, b;

        public Complex(int x, int y)
        {
            a = x;
            b = y;
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex c = new Complex(c1.a + c2.a, c1.b + c2.b);
            return c;
        }

        public override string ToString()
        {
            return a + " " + b;
        }
    }
}
