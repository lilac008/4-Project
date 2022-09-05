using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 4: C# Program to Multiply two Floating Point Numbers Entered by User

namespace Basic_CSharp_Examples
{
    internal class Class04
    {
        static void Main1(string[] args)
        {
            float num1, num2, product;

            Console.WriteLine("Enter a number1 :");
            num1 = Convert.ToSingle(Console.ReadLine());         ///
            Console.WriteLine("Enter a number2 :");
            num2 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine();

            product = num1 * num2;
            Console.WriteLine("{0}*{1}={2}", num1,num2,product);
            Console.WriteLine();




        }
    }
}
