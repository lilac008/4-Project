using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 28: C# Program to Find the Factorial of a Number

namespace Basic_CSharp_Examples
{
    internal class Class28__
    {
        static void Main1(string[] args)
        {
            int i, number, fact;
            Console.WriteLine("Enter the Number");
            number = int.Parse(Console.ReadLine());
            fact = number;
            for (i = number - 1; i >= 1; i--) 
            { 
                fact = fact * 1;
            }
            Console.WriteLine("\n Factorial of Given Number is: " + fact);
            Console.ReadLine();
        }

    }
}
