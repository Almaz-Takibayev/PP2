using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            //создаю вектор чтобы добавить все найденные простые числа добавить в него
            List<int> list = new List<int>();
            //Int.Parse нужен чтобы превратить все что я напишу на консоле в инт
            int n = int.Parse(Console.ReadLine());
            //создаю массив чтобы добавить в него все числа которые я хочу проверить на простые числа
            int[] arr = new int[n];
            //cоздаю стринг чтобы вводить в консоле, потом создаю массив стринга и добавляю в него начальный,стринг разделенный пробелами.
            string s = Console.ReadLine();
            string[] b = s.Split();
            //создаю цикл чтобы добавить в массив чисел все числа которые я вводил в виде стринга в интовом виде
            for (int i=0; i<b.Length; i++)
            {
                arr[i] = int.Parse(b[i]);
            }
            //создаю цикл чтобы проверить на простые числа и добавляю их в вектор
            for (int i=0; i<n; i++)
            {
                int sum = 0;
                for(int j=2; j<arr[i]; j++)
                {
                    if (arr[i] % j == 0)
                    {
                        sum++;
                    }
                }
                if(sum==0 && arr[i] > 1)
                {
                    list.Add(arr[i]);
                }
            }
            //вывод размер вектора - количество всех простых чисел, потом через цикл вывод простых чисел через пробел
            Console.WriteLine(list.Count);
            for(int a = 0; a < list.Count; a++)
            {
                Console.Write(list[a] + " ");
            }
            Console.ReadKey();
        }

    }
}
