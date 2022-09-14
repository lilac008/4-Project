using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/// Example 20: Finding the biggest of three numbers in C#


namespace Basic_CSharp_Examples 
{
    internal class Class20 
    {
        static void Main1(string[] args)
        {
            int number1, number2, number3;
            string result;

            Console.WriteLine("Input the first number :");
            number1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the second number :");
            number2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the third number :");
            number3 = Convert.ToInt32(Console.ReadLine());


            if (number1 > number2 && number1 > number3)
            {
                result = "The 1st Number is the greatest among three. |n";
            }
            else if (number2 > number1 && number2 > number3)
            {
                result = "The 2nd Number is the greatest among three. |n";
            }
            else 
            {
                result = "The 3rd Number is the greatest among three. |n";
            }

            Console.WriteLine(result);
            Console.ReadLine();





        }

    }
    
}