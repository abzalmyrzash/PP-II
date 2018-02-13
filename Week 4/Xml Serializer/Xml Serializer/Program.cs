using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Xml_Serializer
{
    class Program
    {
        static void Serialize(object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write);
            Type type = obj.GetType();
            try
            {
                XmlSerializer xs = new XmlSerializer(type);
                xs.Serialize(fs, obj);
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }
        }

        static Object Deserialize(object obj, string path)
        {
            FileStream fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read);
            Type type = obj.GetType();
            Object obj2 = new object();
            try
            {
                XmlSerializer xs = new XmlSerializer(type);
                obj2 = xs.Deserialize(fs);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            finally
            {
                fs.Close();
            }

            return obj2;
        }

        static void Main(string[] args)
        {
            string path1 = "data1.xml";
            string path2 = "data2.xml";
            Complex c1 = new Complex(31, 87);
            /*Console.WriteLine(" " + c1);
            Console.WriteLine('+');*/
            Complex c2 = new Complex(43, 12);
            //Console.WriteLine(c2);
            Complex cSum;
            Serialize(c1, path1);
            Serialize(c2, path2);
            Console.WriteLine(c1 + "\n" + c2);
            Console.WriteLine();
            cSum = (Deserialize(c1, path1) as Complex) + (Deserialize(c2, path2) as Complex);
            Console.WriteLine(cSum);
            Console.ReadKey();
        }
    }
}
