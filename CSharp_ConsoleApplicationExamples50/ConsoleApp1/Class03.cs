using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 3: C# Program to Add Two Integers

namespace Basic_CSharp_Examples
{
    internal class Class03
    {
        static void Main1(string[] args)
        {
            int num1, num2, sum;
            Console.WriteLine("Calculate the sum of two numbers:");
            Console.Write("Input number1:");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input number2:");
            num2 = Convert.ToInt32(Console.ReadLine());
            sum = num1 + num2;
            Console.Write("Result:"+sum);

            Console.WriteLine();



        }
    }
}
