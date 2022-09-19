using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 35: Converting Algorithm of Decimal to Binary in C#

/// Decimal : 십진법,  Binary ; 이진법  


namespace Basic_CSharp_Examples
{
    internal class Class35__
    {
        static void Main1(string[] args)
        {
            int num;
            Console.Write("Enter a Number : ");
            num = int.Parse(Console.ReadLine());

            int q;
            string rem = "";
            while (num >= 1)
            {
                q = num / 2;
                rem += (num % 2).ToString();
                num = q;
            }
            string binary = "";
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                binary = binary + rem[i];
            }
            Console.WriteLine("The Binary format for {0} is {1}", num, binary);
            Console.ReadLine();
        }
    }
}
