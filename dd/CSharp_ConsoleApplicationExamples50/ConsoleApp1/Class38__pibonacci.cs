using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 38: Fibonacci Series in C# with Method
///fibonacci numbers : 첫째, 둘째 항이 1이며 그 뒤의 모든 항은 바로 앞의 두 항의 합인 수열 ex) 1, 1, 3, 5, 8, 13, 21, 34, 55 .... 


namespace Basic_CSharp_Examples
{
    internal class Class38__pibonacci
    {
        static long[] fibArray;

        static long Fib(int _n)
        {
            if (0 == fibArray[_n])                              /// fibArray[_n]이 0이면   (<-> 0이 아닌 것은 fibArray[1]=1, fibArray[2]=1 뿐이다.)
            {
                fibArray[_n] = Fib(_n - 1) + Fib(_n - 2);       /// 바로 전 앞 두 항의 합을 fibArray[_n]에 저장
            }
            return fibArray[_n];
        }

        static void Main1(string[] args)
        {
            Console.WriteLine("Fibonacci numbers below N =");
            int index = int.Parse(Console.ReadLine());           ///string형으로 입력된 data를 int형으로 변환

            fibArray = new long[index + 2];                      /// fibArray : long형으로 설정 
            fibArray[1] = 1;                                     /// fibArray = {0, 1, 1, 0, 0, 0 ... };
            fibArray[2] = 1;

            long result = Fib(index);
            Console.WriteLine("fib({0})={1}", index, result);
            Console.ReadKey();
        }

        /// Fib(4);
        /// = fibArray(4) = Fib(3) + Fib(2);
        ///               = fibArray[3] + 1;
        ///               = Fid(2) + Fib(1) + 1;
        ///               =    1   +   1    + 1;


        /// Fib(0) - x
        /// Fib(1) - 1
        /// Fib(2) - 1
        /// Fib(3) - 2
        /// Fib(4) - 3
        /// Fib(5) - 5
        /// Fib(6) - 8
        /// Fib(7) - 13



    }
}
