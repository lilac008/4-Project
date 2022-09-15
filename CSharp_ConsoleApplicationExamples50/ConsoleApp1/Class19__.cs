using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 19: C# Program to Print all Prime Numbers in an Interval

/// 소수의 정의 : 1과 자기자신으로만 나누어지는 수, 가장 큰 자연수로 나누었을 때 나머지가 0

namespace Basic_CSharp_Examples
{
    internal class Class19__
    {
        static void Main1(string[] args)
        {
            int num1, num2, sayac = 0;
            Console.Write("Enter lower range :");
            num1 = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter upper range : ");
            num2 = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Prime numbers between {0} and {1} are :", num1, num2);

            for ( int i=num1;  i<num2;  i++ ) 
            {
                sayac = 0;  
                if (i > 1) 
                {
                    for (int j = 2; j < i; j++) 
                    {
                        if (i % j == 0)     ///자기 자신으로 나누었을 때 
                        {
                            sayac = 1;
                            break;
                        }
                    }
                    if (sayac == 0) { Console.WriteLine(i); }
                }
            }
            Console.WriteLine();


        }
    }
}
