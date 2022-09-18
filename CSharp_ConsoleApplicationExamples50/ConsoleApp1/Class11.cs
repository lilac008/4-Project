using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 11: Program to finds the average of 3 numbers in C#

namespace Basic_CSharp_Examples
{
    internal class Class11
    {
        static void Main1(string[] args)
        {
            int num1, num2, num3, average;

            Console.Write("Enter 1st number :");
            num1 = Convert.ToInt32(Console.ReadLine());             ///입력된 string형을 int형으로 변환

            Console.Write("Enter 2nd number :");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter 3rd number :");
            num3 = Convert.ToInt32(Console.ReadLine());

            average = (num1+num2+num3) / 3;
            Console.Write("Average of three number is {0}", average);
            Console.WriteLine();




        }
    }
}
