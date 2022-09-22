using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 33: Display Armstrong Number Between Two Intervals in C#

/// Armstrong : 각 자리의 세제곱이 자기 자신과 같은 수
/// ex) 1   = 1^3 = 1
/// ex) 153 = 1^3 + 5^3 + 3^3 = (1 + 125 + 27) = 153 
/// ex) 370 = 3^3 + 7^3 + 0^3 = (27 + 343 + 0) = 370


namespace Basic_CSharp_Examples
{
    internal class Class33__armstrong
    {

        static void Main1(string[] args)
        {
            int inputL, inputU, num, sum, remainder;
            Console.Write("Enter positive number1 :");
            inputL = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter positive number2 :");
            inputU = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Armstrong Number from {0} to {1}", inputL, inputU);
            for (int i = inputL; i <= inputU; i++)
            {
                sum = 0;
                num = i;
                while (num != 0)
                {
                    remainder = num % 10;                                 ///10으로 나눠 1의 자리 수부터 계산
                    sum = sum + (remainder * remainder * remainder);      ///세제곱
                    num = num / 10;                                       ///10으로 나눠 몫만 n에 넣어 끝 자리 수를 버림
                }
                if (i == sum)
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
