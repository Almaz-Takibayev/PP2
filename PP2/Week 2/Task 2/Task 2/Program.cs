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
            //создаю массив простых чисел
            int[] PrimeNumbers;

            //считываю данные из файла
            using (FileStream fs = new FileStream(@"C:\Week2\Input.txt", FileMode.Open, FileAccess.Read))
            {
                using (StreamReader sr = new StreamReader(fs))
                {
                    //фильтр чисел
                    string text = sr.ReadLine();
                    int[] numbers = Numbers(text);
                    PrimeNumbers = IsPrime(numbers);
                }
            }
            //записали результат на другой файл
            using (FileStream fs2 = new FileStream(@"C:\Week2\Output", FileMode.OpenOrCreate, FileAccess.Write))
            {
                using (StreamWriter sw = new StreamWriter(fs2))
                {
                    //запись простых чисел через пробел
                    foreach (var x in PrimeNumbers)
                    {
                        sw.Write(x + " ");
                    }
                }
            }
        }


        /// <summary>
        /// проверка на простые числа
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
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

        /// <summary>
        /// превращение входных данных в массив чисел
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
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
