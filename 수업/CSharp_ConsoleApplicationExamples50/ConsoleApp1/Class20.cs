using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

/// Example 20: Finding the biggest of three numbers in C#

/// data Type.Parse   : null이 입력될 경우 ArgumentNullException(매개변수 예외처리) -> java 예외처리 찾아볼것
/// Convert.data Type : null이 입력될 경우 0을 반환


namespace Basic_CSharp_Examples 
{
    internal class Class20 
    {
        static void Main1(string[] args)
        {
            int num1, num2, num3;
            string result;

            Console.WriteLine("Input the first number :");
            num1 = Convert.ToInt32(Console.ReadLine());             ///입력된 string형을 int형으로 변환
            Console.WriteLine("Input the second number :");
            num2 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input the third number :");
            num3 = Convert.ToInt32(Console.ReadLine());


            if (num1 > num2 && num1 > num3)
            {
                result = "The 1st Number is the greatest among three. \n";
            }
            else if (num2 > num1 && num2 > num3)
            {
                result = "The 2nd Number is the greatest among three \n";
            }
            else
            {
                result = "The 3rd Number is the greatest among three \n";
            }

            Console.WriteLine(result);
            Console.ReadLine();





        }

    }
    
}