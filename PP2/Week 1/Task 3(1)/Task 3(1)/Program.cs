using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_3_1_
{
    class Program
    {
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

            int[] res = new int[2 * arr.Length];

            for(int i=0; i<res.Length; i++)
            {
                res[i] = arr[i / 2];
            }
            
            for(int i=0; i<res.Length; i++)
            {
                Console.Write(res[i] + " ");
            }
            Console.ReadKey();
        }
    }
}
