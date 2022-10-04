using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 13: C# Math.Pow Negative Exponent Example


namespace Basic_CSharp_Examples
{
    internal class Class13_power
    {
        static void Main1(string[] args)
        {
            double baseN, exponent;
            Console.Write("Enter base number :");
            baseN = Convert.ToDouble(Console.ReadLine());             ///입력된 string형을 double형으로 변환

            Console.Write("Enter exponent number :");
            exponent = Convert.ToDouble(Console.ReadLine());          

            double power = Math.Pow(baseN, exponent);               ///Math.Pow()는 double형 매개변수만 받는다.
            Console.WriteLine("{0}^{1}={2}", baseN, exponent, power);

            Console.WriteLine();
        }
    }
}
