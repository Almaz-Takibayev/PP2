using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    class Program
    {
        //функция которая выводит число массива 2 раза через пробел
        static void Print(int n)
        {
            for(int i=0; i<2; i++)
            {
                Console.Write(n + " ");
            }
        }

        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            //cоздаю стринг чтобы вводить в консоле, потом создаю массив стринга и добавляю в него начальный,стринг разделенный пробелами.
            string s = Console.ReadLine();
            string[] b = s.Split();
            //создаю цикл чтобы добавить в массив чисел все числа которые я вводил в виде стринга в интовом виде
            for (int i = 0; i < b.Length; i++)
            {
                arr[i] = int.Parse(b[i]);
            }

            for (int i = 0; i < n; i++)
                {
                    Print(arr[i]);
                }
                Console.ReadKey();
        }
    }
}
