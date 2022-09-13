using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 35: Converting Algorithm of Decimal to Binary in C#

namespace Basic_CSharp_Examples
{
    internal class Class35
    {
        static void Main(string[] args)
        {
            int number;
            Console.Write("Enter a Number : ");
            number = int.Parse(Console.ReadLine());

            int q;
            string rem = "";
            while (number >= 1) 
            {
                q = number / 2;
                rem += (number % 2).ToString();
                number = q;
            }

            string binary = "";
            for (int i = rem.Length - 1; i >= 0; i--) 
            {
                binary = binary + rem[i];
            }
            Console.WriteLine("The Binary format for {0} is {1}", number, binary);
            Console.ReadLine();
        }
    }
}
