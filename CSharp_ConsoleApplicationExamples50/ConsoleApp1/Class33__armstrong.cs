using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 33: Display Armstrong Number Between Two Intervals in C#

/// Armstrong : 각 자리의 세제곱이 자기 자신과 같은 수  (abc = a^3 + b^3 + c^3 = a*a*a + b*b*b + c*c*c)
/// 
/// ex) -1  = (-1)^3 = -1
/// ex) 0   =   0^3  = 0
/// ex) 1   =   1^3  = 1
/// ex) 153 = 1^3 + 5^3 + 3^3 = (1 + 125 + 27) = 153   -->  153 % 10 = 3,  153 / 10 = 15(몫),  
///                                                          15 % 10 = 5,   15 / 10 = 1,
///                                                           1 % 10 = 1,    1 / 10 = 0,
/// ex) 370 = 3^3 + 7^3 + 0^3 = (27 + 343 + 0) = 370
/// ex) 371 = 3^3 + 7^3 + 1^3 = (27 + 343 + 1) = 371   -->  371 % 10 = 1,  371 / 10 = 37(몫),  
///                                                          37 % 10 = 7,   37 / 10 = 3,
///                                                           3 % 10 = 3,    3 / 10 = 0,
/// ex) 407 = 4^3 + 0^3 + 7^3 = (64 + 0 + 343) = 407


namespace Basic_CSharp_Examples
{
    internal class Class33__armstrong
    {

        static void Main1(string[] args)
        {
            int min, max, num, sum, remainder;
            Console.Write("Enter positive number1 :");
            min = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter positive number2 :");
            max = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Armstrong Number from {0} to {1}", min, max);
            for (int i = min; i <= max; i++)                              ///최저 ~ 최대값 범위까지 무한반복
            {
                sum = 0;
                num = i;
                while (num != 0)                                          ///들어온 수가 0이 아닐 때 다음 코드를 무한반복
                {
                    remainder = num % 10;                                 ///1의 자리 = 들어온 수를 10으로 나눈 나머지 
                    sum = sum + (remainder * remainder * remainder);      ///합계 = 0 + 세제곱
                    num = num / 10;                                       ///몫(num) = 들어온 수를 10으로 나눠 몫을 저장 
                }
                if (i == sum)                                             ///들어온 수 == 합계이면 해당 수를 출력
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
