using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task_1
{

    class Program
    {
        static void Main(string[] args)
        {
            Thread[] threads = new Thread[3];
            
            for (int i = 0; i < 3; i++)
            {
                string name = string.Format("Thread {0}", (i+1));
                threads[i] = new Thread(Method);
                threads[i].Name = name;
                threads[i].Start();
                Thread.Sleep(1000);
            }
        }

        static void Method()
        {
            Console.WriteLine(Thread.CurrentThread.Name);
        }

        static void StartMethod()
        {
            for(int i=0; i<3; i++)
            {
                Console.WriteLine(Thread.CurrentThread.Name);
            }
        }
    }
}