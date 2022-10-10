using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 35: Converting Algorithm of Decimal to Binary in C#

/// Decimal : 십진법,  Binary ; 이진법  
/// 




namespace Basic_CSharp_Examples
{
    internal class Class35__binary
    {
        static void Main1(string[] args)
        {
            int input;
            Console.Write("Enter a Number : ");
            input = int.Parse(Console.ReadLine());

            int q;
            string rem = "";                    /// remainder
            int r = input;
            while (r >= 1)                      /// 입력값이 1 이상이면 무한반복
            {
                q = r / 2;                      /// 입력값을 2로 나눠서 
                rem += (r % 2).ToString();      ///
                r = q;
            }

            string binary = "";
            for (int i = rem.Length - 1; i >= 0; i--)
            {
                binary = binary + rem[i];
            }
            Console.WriteLine("The Binary format for {0} is {1}", input, binary);
            Console.ReadLine();

        }
    }
}
