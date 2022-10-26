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


            bool flag = false;                      /// flag 비활성화
            if (exponentN > 0)                      /// 지수가 0보다 클때만 flag 활성화
                flag = true;
            
            exponentN = Math.Abs(exponentN);        /// 지수를 양수로 만듬   / Math.Abs() : 절대값 반환 함수


            for (int i = 1; i <= exponentN; i++)    /// i가 1~N이면
            {
                if (flag)                           /// 지수가 0보다 클경우 true
                    result = result * baseN;        /// 결과 = 결과 * 밑
                else
                    result /= baseN;                /// (지수가 0보다 작을경우) 결과 = 결과 / baseN;   
            }

            Console.WriteLine("Base {0} and exponent {1} Result = {2}", baseN, exponentN, result);
            Console.ReadLine();
        }

    }
}
