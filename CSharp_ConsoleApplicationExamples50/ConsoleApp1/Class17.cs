using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 17: Find Number is Even or Odd using if else Statement in C#


/// 자료형 변환하는 함수
/// 1) 자료형.Parse   : null이 입력될 경우 ArgumentNullException(매개변수 예외처리) -> java 예외처리 찾아볼것
/// 2) Convert.자료형 : null이 입력될 경우 0을 반환


namespace Basic_CSharp_Examples
{
    internal class Class17
    {
        static void Main1(string[] args)
        {
            int num;
            Console.WriteLine("Enter an integer :");
            num = Int32.Parse(Console.ReadLine());           ///string형을 integer형으로 변환

            if (num % 2 == 0) 
            { Console.WriteLine("{0} is even", num); }
            else 
            { Console.WriteLine("{0} is odd", num); }
            Console.WriteLine();
        }
    }
}
