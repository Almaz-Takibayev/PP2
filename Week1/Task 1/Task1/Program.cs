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
            List<int> list = new List<int>();
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            string s = Console.ReadLine();
            string[] b = s.Split();
            for (int i=0; i<b.Length; i++)
            {
                arr[i] = int.Parse(b[i]);
            }

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

            Console.WriteLine(list.Count);
            for(int a = 0; a < list.Count; a++)
            {
                Console.Write(list[a] + " ");
            }
            Console.ReadKey();
        }

    }
}
