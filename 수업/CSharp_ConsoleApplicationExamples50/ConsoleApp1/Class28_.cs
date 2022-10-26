using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 28: C# Program to Find the Factorial of a Number

namespace Basic_CSharp_Examples
{
    internal class Class28_
    {
        static void Main1(string[] args)
        {
            int i, input, factorial;
            Console.WriteLine("Enter the Number");
            input = int.Parse(Console.ReadLine());

            factorial = input;
            for (i = input - 1; i >= 1; i--) 
            { 
                factorial = factorial * i;
            }
            Console.WriteLine("\n Factorial of Given Number is: " + factorial);
            Console.ReadLine();
        }

    }
}
