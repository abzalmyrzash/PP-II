using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using Xml_Serializer;

namespace Binary_Formatter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            string path1 = "data1.ser",
                   path2 = "data2.ser";

            FileStream fs1 = new FileStream(path1, FileMode.OpenOrCreate),
                       fs2 = new FileStream(path2, FileMode.OpenOrCreate);

            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(fs1, new Complex(78, 32));
            bf.Serialize(fs2, new Complex(32, 31));
            fs1.Close();
            fs2.Close();
            
            Complex c1 = (Complex)bf.Deserialize(new FileStream(path1, FileMode.Open));
            Complex c2 = (Complex)bf.Deserialize(new FileStream(path2, FileMode.Open));

            Complex cSum = c1 + c2;

            int best, l1 = best = c1.GetString().Length, l2 = c2.GetString().Length, l3 = cSum.GetString().Length;
            if (l2 > l1 && l2 > l3) best = l2;
            else if (l3 > l2 && l3 > l1) best = l3;

            Console.WriteLine(" " + c1 + "\n+\n " + c2);
            for(int i = 0; i <= best; i++)
            {
                Console.Write('_');
            }
            Console.WriteLine("\n " + cSum);

            Console.Write("\n\nPress any button to close the program...");
            Console.ReadKey(true);
        }
    }
}
