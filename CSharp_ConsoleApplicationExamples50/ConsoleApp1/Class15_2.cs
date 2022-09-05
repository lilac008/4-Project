using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 15: Convert Dollars to Cents in C#
/// Solution 2: Calculate with Custom Method


namespace Basic_CSharp_Examples
{
    internal class Class15_2
    {
        static void Main1(string[] args)
        {
            double dollar;
            int cents;
            //int compute_cents;

            Console.Write("Enter dollar amount : ");
            dollar = Convert.ToDouble(Console.ReadLine());

            cents = compute_cents(dollar);
            Console.WriteLine("{0}$ = {1}¢", dollar, cents);
            Console.WriteLine();
        }

        static int compute_cents(double dollar) 
        {
            return (int)(dollar * 100);
        }



    }
}
