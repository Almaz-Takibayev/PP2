using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task01
{
    class Program
    {
        static bool IsPrime(int n)
        {
            if(n==2 || n == 3)
            {
                return true;
            }
            if(n%2==0 || n%3==0 || n == 1)
            {
                return false;
            }

            for(int i=2; i*i<=n; i++)
            {
                if (n % i == 0)
                {
                    return false;
                }
            }
            return true;
        }


        static void Main(string[] args)
        {
            int n= 
        }
    }
}
