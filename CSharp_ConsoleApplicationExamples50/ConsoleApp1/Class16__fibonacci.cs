using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 16: Fibonacci Series in C# with Method
/// vs Example 16, 38


///fibonacci numbers : 첫째, 둘째 항이 1이며 그 뒤의 모든 항은 바로 앞의 두 항의 합인 수열 ex) 1, 1, 3, 5, 8, 13, 21, 34, 55 .... 

namespace Basic_CSharp_Examples
{
    internal class Class16__fibonacci
    {
        static long[] fiboArray;

        static long Fib(int _int) 
        {
            if (0 == fiboArray[_int]) 
            {
                fiboArray[_int] = Fib(_int - 1) + Fib(_int - 2);   ///피보나치 수 = 바로 앞 두 항의 합
            }
            return fiboArray[_int];
        }


        static void Main1(string[] args)
        {
            Console.WriteLine("n=");
            int n = int.Parse(Console.ReadLine());           ///string형으로 입력된 data를 int형으로 변환
            
            fiboArray = new long[n + 2];                     ///fiboArray = {null, 1, 1, null, null ... };
            fiboArray[1] = 1;
            fiboArray[2] = 1;

            long result = Fib(n);
            Console.WriteLine("fib({0})={1}", n, result);
            Console.ReadKey();
        }


                
    }
}
