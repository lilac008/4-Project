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
        static long[] numbers;

        static long Fib(int n) 
        {
            if (0 == numbers[n]) 
            {
                numbers[n] = Fib(n - 1) + Fib(n - 2);
            }
            return numbers[n];
        }


        static void Main1(string[] args)
        {
            Console.WriteLine("n=");
            int n = int.Parse(Console.ReadLine());
            numbers = new long[n + 2];
            numbers[1] = 1;
            numbers[2] = 1;
            long result = Fib(n);
            Console.WriteLine("fib({0})={1}", n, result);
            Console.ReadKey();
        }


                
    }
}
