using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 21: Generates the Sum of N Numbers in C#

namespace Basic_CSharp_Examples
{
    internal class Class21
    {
        static void Main1(string[] args)
        {
            int number, sum = 0;

            Console.WriteLine("Enter a Number : ");
            number = Convert.ToInt32(Console.ReadLine());

            if (number < 0)
            {
                Console.WriteLine("Please Enter Positive Number");
            }
            else
            {
                while (number > 0) 
                { 
                    sum += number; 
                    number -= 1;
                }
            }

            Console.WriteLine("The sum is" +sum);
            Console.ReadKey();



        }


    }
}
