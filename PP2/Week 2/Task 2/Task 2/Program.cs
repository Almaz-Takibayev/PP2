using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_2
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] PrimeNumbers;

            using (FileStream fs = new FileStream(@"C:\Week2\Input.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    string text = sr.ReadLine();
                    int[] numbers = Numbers(text);
                    PrimeNumbers = IsPrime(numbers);
                }
            }

            using (FileStream fs2 = new FileStream(@"C:\Week2\Output", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs2))
                {
                    foreach (var x in PrimeNumbers)
                    {
                        sw.Write(x + " ");
                    }
                }
            }
        }



        private static int[] IsPrime(int[] num)
        {
            List<int> res = new List<int>();

            foreach (var x in num)
            {
                int y = 0;
                for (int i = 2; i * i <= x; i++)
                {
                    if (x % i == 0)
                    {
                        y++;
                    }
                }
                if (y == 0)
                {
                    res.Add(x);
                }
            }
            return res.ToArray();
        }

        private static int[] Numbers(string text)
        {
            string[] parts = text.Split();
            int[] res = new int[parts.Length];
            for (int i = 0; i < parts.Length; ++i)
            {
                res[i] = int.Parse(parts[i]);
            }
            return res;
        }
    }
}
