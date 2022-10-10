using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 17: Find Number is Even or Odd using if else Statement in C#
/// Code 2 (with static method)


namespace Basic_CSharp_Examples
{
    internal class Class17_2
    {
        static bool IsEvenNumber(int num) 
        {
            if (num % 2 == 0)
            {
                return true;                        /// 1
            }
            else 
            {
                return false;                       /// 0
            }
        }

        static void Main1(string[] args)
        {
            int n;
            Console.Write("Enter an integer :");
            n = Int32.Parse(Console.ReadLine());   ///string 형을 integer형으로 변환

            if (IsEvenNumber(n)) 
            { Console.WriteLine("{0} is even", n); }
            else 
            { Console.WriteLine("{0} is odd", n); }
            Console.WriteLine();


        }
    }
}
