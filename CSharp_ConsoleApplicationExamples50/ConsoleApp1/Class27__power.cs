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
    internal class Class27__power
    {
        static void Main1(string[] args)
        {
            int baseN, exponentN;
            double powerResult = 1;
            Console.Write("Base Number : ");
            baseN = Convert.ToInt32(Console.ReadLine());
            Console.Write("exponent Number : ");
            exponentN = Convert.ToInt32(Console.ReadLine());         

            bool sing = false;
            if (exponentN > 0) sing = true;
            exponentN = Math.Abs(exponentN);

            for (int i = 1; i <= exponentN; i++) 
            {
                if (sing)
                    powerResult = powerResult * baseN;
                else
                    powerResult /= baseN;
            }

            Console.WriteLine("Base {0} and exponent {1} Result = {2}", baseN, exponentN, powerResult);
            Console.ReadLine();
        }

    }
}
