using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 7: Program To Calculate the Simple Interest in C#

/// rate : 과세, 등급, 견적
/// interest : 

namespace Basic_CSharp_Examples
{
    internal class Class07_rate_interest
    {
        static void Main1(string[] args)
        {
            int amount, time;
            float rate, interest;
            Console.Write("Enter Amount :");
            amount = Convert.ToInt32(Console.ReadLine());       ///string형으로 입력된 data를 int형으로 변환

            Console.Write("Enter Rate :");
            rate = Convert.ToSingle(Console.ReadLine());        ///string형으로 입력된 data를 부동소수점으로 변환

            Console.Write("Enter Time :");
            time = Convert.ToInt32(Console.ReadLine());

            interest = amount * rate * time / 100;
            Console.WriteLine("Interest is : {0}", interest);
            Console.ReadKey();

            Console.ReadLine();



        }
    }
}
