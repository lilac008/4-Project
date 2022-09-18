using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 16: Fibonacci Series in C# with Method

namespace Basic_CSharp_Examples
{
    internal class Class16__
    {
        static long[] numArray;

        static long Fib(int n) 
        {
            if (0 == numArray[n]) 
            {
                numArray[n] = Fib(n - 1) + Fib(n - 2);   ///numarray[4] = fib(3) + fib(2)
                                                         ///               
            }
            return numArray[n];
        }


        static void Main1(string[] args)
        {
            Console.WriteLine("n=");
            int n = int.Parse(Console.ReadLine());          ///입력된 string형을 int형으로 변환
            
            numArray = new long[n + 2];                     ///numArray = {null, 1, 1, null, null ... };
            numArray[1] = 1;
            numArray[2] = 1;

            long result = Fib(n);
            Console.WriteLine("fib({0})={1}", n, result);
            Console.ReadKey();
        }


                
    }
}
