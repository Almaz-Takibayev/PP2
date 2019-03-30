using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex3
{
    class Program
    {
        static string s;

        static void Main(string[] args)
        {
            Thread th1 = new Thread(Substr);
            Thread th2 = new Thread(Time);
            s = Console.ReadLine();
            th1.Start();
            th2.Start();
        }

        static void Substr()
        {
            //string s = Console.ReadLine();
            Console.WriteLine(s);
            int cnt = 1;
            for (int i = 0; i < s.Length; i++)
            {
                for (int j = i; j < s.Length; j++)
                {
                    Console.WriteLine((cnt) + ")" + s.Substring(i, j - i + 1));
                    cnt++;
                    Thread.Sleep(1000);
                }
            }
            Console.WriteLine("End.");
            Environment.Exit(0);
        }

        static void Time()
        {
            for (int i = 0; i < 1000; i++)
            {
                string curTimeLong = DateTime.Now.ToLongTimeString();
                Console.WriteLine(curTimeLong);
                Thread.Sleep(1000);
            }
            Environment.Exit(0);
        }
    }
}
