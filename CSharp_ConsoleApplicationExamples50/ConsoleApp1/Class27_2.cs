using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 27: C# Program to Calculate the Power of a Number Without Using Math.Pow
/// code : (with While Loop)


namespace Basic_CSharp_Examples
{
    internal class Class27_2
    {
        static void Main1(string[] args)
        {
            int baseN, exponentN, powerResult = 1;
            Console.Write("Base Number : ");
            baseN = Convert.ToInt32(Console.ReadLine());
            Console.Write("Exponent Number : ");
            exponentN = Convert.ToInt32(Console.ReadLine());

            while (exponentN != 0) 
            {
                powerResult *= baseN;
                --exponentN;
            }
            Console.WriteLine("Result={0}", powerResult);
            Console.ReadLine();
        }


    }
}
