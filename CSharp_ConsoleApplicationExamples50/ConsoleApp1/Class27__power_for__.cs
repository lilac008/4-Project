using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 27: C# Program to Calculate the Power of a Number Without Using Math.Pow     (vs Example 12)
/// code : (with For Loop)


///base : 밑,  exponent : 지수,  power : 거듭제곱


namespace Basic_CSharp_Examples
{
    internal class Class27__power_for__
    {
        static void Main1(string[] args)
        {
            int baseN, exponentN;
            double result = 1;
            Console.Write("Base Number : ");
            baseN = Convert.ToInt32(Console.ReadLine());
            Console.Write("exponent Number : ");
            exponentN = Convert.ToInt32(Console.ReadLine());         

            bool sing = false;
            if (exponentN > 0)                      ///지수가 0보다 크면 
                sing = true;

            exponentN = Math.Abs(exponentN);        ///Math.Abs() : 절대값 반환 -> 지수를 양수로

            for (int i = 1; i <= exponentN; i++) 
            {
                if (sing)
                    result = result * baseN;       /// 결과 * 밑을 저장
                else
                    result /= baseN;               /// 결과를 밑으로 나눔
            }

            Console.WriteLine("Base {0} and exponent {1} Result = {2}", baseN, exponentN, result);
            Console.ReadLine();
        }

    }
}
