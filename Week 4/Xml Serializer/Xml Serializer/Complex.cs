using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Xml_Serializer
{
    [Serializable]
    public class Complex
    {
        public int a, b;

        public Complex(int x, int y)
        {
            a = x;
            if (y != 0) b = y;
            else b = 1;
        }

        public Complex()
        {
            a = 0;
            b = 1;
        }

        static int gcd(int x, int y)
        {
            if (y == 0) return x;
            return gcd(y, x % y);
        }

        static int lcm(int x, int y)
        {
            return x * y / gcd(x, y);
        }

        public static Complex operator +(Complex c1, Complex c2)
        {
            int cb = lcm(c1.b, c2.b);
            Complex c = new Complex((c1.a * cb / c1.b) + (c2.a * cb / c2.b), cb);
            return c;
        }

        public string GetString()
        {
            double c = a / Convert.ToDouble(b);
            return a + "/" + b + " = " + c;
        }

        public override string ToString()
        {
            return GetString();
        }

        /*public int A
        {
            get { return a; }
            set { a = value; }
        }

        public int B
        {
            get { return b; }
            set { b = value == 0 ? 1 : value; }
        }*/
    }
}
