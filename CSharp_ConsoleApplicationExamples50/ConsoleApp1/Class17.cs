﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 17: Find Number is Even or Odd using if else Statement in C#

namespace Basic_CSharp_Examples
{
    internal class Class17
    {
        static void Main1(string[] args)
        {
            int num;
            Console.WriteLine("Enter an integer :");
            num = Int32.Parse(Console.ReadLine());

            if (num % 2 == 0) 
            { Console.WriteLine("{0} is even", num); }
            else 
            { Console.WriteLine("{0} is odd", num); }
            Console.WriteLine();
        }
    }
}