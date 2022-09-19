using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 33: Display Armstrong Number Between Two Intervals in C#

/// Armstrong : 각 자리의 세제곱이 자기 자신과 같은 수
/// ex) 370 =  3^3 + 7^3 + 0^3 = 370   (27 + 343 + 0 = 370)


namespace Basic_CSharp_Examples
{
    internal class Class33__armstrong
    {

        static void Main1(string[] args)
        {
            int num1, num2, n, sum, r;
            Console.Write("Enter positive number1 :");
            num1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("Enter positive number2 :");
            num2 = Convert.ToInt32(Console.ReadLine());


            Console.WriteLine("Armstrong Number from {0} to {1}", num1, num2);
            for (int i = num1; i <= num2; i++)
            {
                sum = 0;
                n = i;
                while (n != 0)
                {
                    r = n % 10;
                    sum = sum + (r * r * r);
                    n = n / 10;
                }
                if (i == sum)
                    Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
