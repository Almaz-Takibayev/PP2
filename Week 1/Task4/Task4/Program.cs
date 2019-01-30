using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task4
{
    class Program
    {
        static void Main(string[] args)
        {
            //вводим число
            int n = int.Parse(Console.ReadLine());
            //создаем 2 цикла, где итератор второго цикла не может превышать итератора первго цикла.
            for (int i=0; i<n; i++)
            {
                for(int j=0; j<=i; j++)
                {
                    //пока второй цикл работает мы выводим звездочку в один ряд
                    Console.Write("[*]");
                }
                //когда второй цикл заканчивается мы переносим следующую звездочку на следующую строку
                Console.WriteLine();
            }
            Console.ReadKey();
        }

    }
}
