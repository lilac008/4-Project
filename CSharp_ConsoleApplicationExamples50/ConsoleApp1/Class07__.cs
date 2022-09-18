using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 7: Program To Calculate the Simple Interest in C#

/// rate : 세금, 과세, 등급, 견적

namespace Basic_CSharp_Examples
{
    internal class Class07__
    {
        static void Main1(string[] args)
        {
            int amount, time;
            float rate, interest;
            Console.Write("Enter Amount :");
            amount = Convert.ToInt32(Console.ReadLine());       ///입력된 string형을 int형으로 변환

            Console.Write("Enter Rate :");
            rate = Convert.ToSingle(Console.ReadLine());        ///입력된 string형을 부동소수점으로 변환

            Console.Write("Enter Time :");
            time = Convert.ToInt32(Console.ReadLine());

            interest = amount * rate * time / 100;
            Console.WriteLine("Interest is : {0}", interest);
            Console.ReadKey();

            Console.ReadLine();



        }
    }
}
