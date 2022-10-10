using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 4: C# Program to Multiply two Floating Point Numbers Entered by User

/// Floating Point Numbers : 부동소수점 (ex  1.2345(가수) X 10(밑)^-4(지수) 
/// - float범위를 floating point numbers(부동소수점)으로 표현 범위를 늘림 
/// - 부동소수는 정확하지 않고 오차가 있다.

namespace Basic_CSharp_Examples
{
    internal class Class04
    {
        static void Main1(string[] args)
        {
            float num1, num2, product;

            Console.WriteLine("Enter a number1 :");
            num1 = Convert.ToSingle(Console.ReadLine());         ///입력된 string형을 부동소수점으로 변환

            Console.WriteLine("Enter a number2 :");
            num2 = Convert.ToSingle(Console.ReadLine());
            Console.WriteLine();

            product = num1 * num2;
            Console.WriteLine("{0}*{1}={2}", num1,num2,product);
            Console.WriteLine();




        }
    }
}
