using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 2: C# Program to Print an Integer Entered by User

/// integer : 정수

namespace Basic_CSharp_Examples
{
    internal class Class02
    {

        static void Main1(string[] args)
        {
            int num;
            Console.WriteLine("Enter a number:");
            num = Convert.ToInt32(Console.ReadLine());      ///int형으로 변환

            Console.WriteLine("You entered : {0}", num);
            Console.WriteLine();
        }
    }
}
