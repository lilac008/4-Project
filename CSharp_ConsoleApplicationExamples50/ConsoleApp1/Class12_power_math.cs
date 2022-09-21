using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 12: C# Math.Pow Example    (vs Example 27)



namespace Basic_CSharp_Examples
{
    internal class Class12_power_math
    {
        static void Main1(string[] args)
        {
            double baseN, exponentN;

            Console.Write("Enter base number :");
            baseN = Convert.ToDouble(Console.ReadLine());              ///string형으로 입력된 data를 double형으로 변환

            Console.Write("Enter exponent number :");
            exponentN = Convert.ToDouble(Console.ReadLine());           

            double powerN = Math.Pow(baseN, exponentN);                 ///Math.Pow()는 double형 매개변수만 받는다.
            Console.WriteLine("{0}^{1}={2}", baseN, exponentN, powerN);

            Console.WriteLine();

        }
    }
}
