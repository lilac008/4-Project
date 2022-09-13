﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 12: C# Math.Pow Example


namespace Basic_CSharp_Examples
{
    internal class Class12
    {
        static void Main1(string[] args)
        {
            double baseNumber, powerNumber;

            Console.Write("Enter base number :");
            baseNumber = Convert.ToDouble(Console.ReadLine());
            Console.Write("Enter exponent number :");
            powerNumber = Convert.ToDouble(Console.ReadLine());

            double returnNumber = Math.Pow(baseNumber, powerNumber);
            Console.WriteLine("{0}^{1}={2}", baseNumber, powerNumber, returnNumber);

            Console.WriteLine();

        }
    }
}