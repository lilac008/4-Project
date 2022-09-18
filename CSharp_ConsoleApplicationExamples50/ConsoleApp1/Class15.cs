using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 15: Convert Dollars to Cents in C#
/// Solution 1: Calculate in Main Method

namespace Basic_CSharp_Examples
{
    internal class Class15
    {
        static void Main1(string[] args)
        {
            double dollar;
            int cents;

            Console.Write("Enter dollar amount :");
            dollar = Convert.ToDouble(Console.ReadLine());      ///입력된 string형을 double형으로 변환

            cents = (int)(dollar * 100);                        ///string형 dollar변수를 int형으로 강제변환

            Console.WriteLine("{0} $ = {1} ¢", dollar, cents);  
        }
    }
}
