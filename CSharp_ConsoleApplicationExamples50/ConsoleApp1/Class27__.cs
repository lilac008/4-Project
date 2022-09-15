using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 27: C# Program to Calculate the Power of a Number Without Using Math.Pow


namespace Basic_CSharp_Examples
{
    internal class Class27__
    {
        static void Main1(string[] args)
        {
            int baseNumber, expNumber;
            double result = 1;
            Console.Write("Base Number : ");
            baseNumber = Convert.ToInt32(Console.ReadLine());
            Console.Write("exponent Number : ");
            expNumber = Convert.ToInt32(Console.ReadLine());        ///exponent : 거듭제곱한 횟수 

            bool sing = false;
            if (expNumber > 0) sing = true;
            expNumber = Math.Abs(expNumber);

            for (int i = 1; i <= expNumber; i++) 
            {
                if (sing)
                    result = result * baseNumber;
                else
                    result /= baseNumber;
            }

            Console.WriteLine("Base {0} and exponent {1} Result = {2}", baseNumber, expNumber, result);
            Console.ReadLine();




        }

    }
}
