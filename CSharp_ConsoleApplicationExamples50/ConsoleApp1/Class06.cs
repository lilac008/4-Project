using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 6:  C# Program to Compute Quotient and Remainder

namespace Basic_CSharp_Examples
{
    internal class Class06
    {
        static void Main1(string[] args)
        {
            int dividend = 50, divisor = 8;

            int quotient = dividend / divisor;
            int remainder = dividend % divisor;

            Console.WriteLine("Dividend:{0},Divisor:{1}", dividend, divisor);
            Console.WriteLine("Quotient = " + quotient);
            Console.WriteLine("Remainder = " + remainder);
            Console.WriteLine();

        }
    }
}
