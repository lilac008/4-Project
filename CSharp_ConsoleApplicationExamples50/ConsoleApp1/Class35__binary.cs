using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 35: Converting Algorithm of Decimal to Binary in C#

/// Decimal : 십진법,  Binary ; 이진법  
/// 

/// 10 = 2^3 + 2^1 = 2^3  ...1
///                = 2^2  ...0
///                = 2^1  ...1
///                = 2^0  ...0 
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

            int quotient;
            string remainder = "";                    
            int _input = input;
            while (_input >= 1)                            /// 입력값이 1 이상이면 무한반복
            {
                quotient = _input / 2;                     /// 입력값을 2로 나눠서 
                remainder += (_input % 2).ToString();      /// string형으로 변환해서 이진법을 나열
                _input = quotient;
            }

            string binary = "";
            for (int i = remainder.Length - 1; i >= 0; i--)
            {
                binary = binary + remainder[i];
            }
            Console.WriteLine("The Binary format for {0} is {1}", input, binary);
            Console.ReadLine();

        }
    }
}
