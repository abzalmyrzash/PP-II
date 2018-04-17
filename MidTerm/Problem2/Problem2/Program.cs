using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2
{
    class Program
    {
        static bool isUnique(int n, List<int> v)
        {
            for(int i = 0; i < v.Count; i++)
            {
                if (v[i] == n) return false;
            }
            return true;
        }

        static void Main(string[] args)
        {
            string path1 = "input.txt";
            string path2 = "output.txt";

            FileStream fs = new FileStream(path1, FileMode.Open);
            StreamReader sr = new StreamReader(fs);

            string line = sr.ReadLine();
            fs.Close();
            string[] array = line.Split(' ');
            List<int> arr = new List<int>();

            for(int i = 0; i < array.Length; i++)
            {
                int n = int.Parse(array[i]);
                if(isUnique(n, arr)) arr.Add(n);
            }

            for(int i = 0; i < arr.Count; i++)
            {
                for(int j = i + 1; j < arr.Count; j++)
                {
                    if(arr[j] > arr[i])
                    {
                        int b = arr[j];
                        arr[j] = arr[i];
                        arr[i] = b;
                    }
                }
            }

            fs = new FileStream(path2, FileMode.OpenOrCreate);
            StreamWriter sw = new StreamWriter(fs);

            if (arr.Count > 1) sw.WriteLine(arr[1]);
            sw.Close();
            fs.Close();
        }
    }
}
