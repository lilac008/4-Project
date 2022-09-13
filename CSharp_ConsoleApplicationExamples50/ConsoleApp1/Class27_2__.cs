using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 27: C# Program to Calculate the Power of a Number Without Using Math.Pow


namespace Basic_CSharp_Examples
{
    internal class Class27_2__
    {
        static void Main1(string[] args)
        {
            int baseNumber, expNumber, result = 1;
            Console.Write("Base Number : ");
            baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("Exponent Number : ");
            expNumber = Convert.ToInt32(Console.ReadLine());

            while (expNumber != 0) 
            {
                result += baseNumber;
                --expNumber;
            }
            Console.WriteLine("Result={0}", result);
            Console.ReadLine();
        }


    }
}
