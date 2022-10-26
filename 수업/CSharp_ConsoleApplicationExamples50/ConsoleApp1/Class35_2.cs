using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 35: Converting Algorithm of Decimal to Binary in C#
/// Other way:  You can convert decimal to number, If you want to without think any algorithm

namespace Basic_CSharp_Examples
{
    internal class Class35_2
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter a number : ");
            int number = Convert.ToInt32(Console.ReadLine());

            string binary = Convert.ToString(number,2);
            Console.WriteLine("The Binary format for {0} is {1}", number, binary);
            Console.ReadLine();
        }
    }
}
