using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 31: C# Program to Print all Prime Numbers in an Interval
/// Prime Number : 1과 자기자신으로만 나누어지는 수, 가장 큰 자연수로 나누었을 때 나머지가 0


namespace Basic_CSharp_Examples
{
    internal class Class31__prime
    {
        static void Main1(string[] args)
        {
            int inputL, inputU, flag = 0;
            Console.Write("Enter lower range :");
            inputL = Convert.ToInt32(Console.ReadLine());

            Console.Write("Enter upper range : ");
            inputU = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Prime numbers between {0} and {1} are :", inputL, inputU);

            for (int i = inputL; i <= inputU; i++)   /// 최저입력값 ~ 최고입력값 사이에서 반복하라. 
            {
                flag = 0;
                if (i > 1)                          /// 1 이상인 수 중에 (소수는 1과 자기자신으로만 나누어져야함)
                {
                    for (int j = 2; j < i; j++)     /// 입력값보다 j가 작으면 반복하라. - inputL~U : 2*, 3*, 4, 5*, 6, 7*, 8, 9, 10, 11* 
                    {
                        if (i % j == 0)             /// 입력값을 j로 나누었을 때 나머지가 0이면 
                        {
                            flag = 1;               ///flag == 1이되고
                            break;                  ///for (int j = 2; j < i; j++) 문 중단
                        }
                    }
                    if (flag == 0) { Console.WriteLine(i); }    /// flag == 0일경우 i 그대로 출력 -> 소수
                }
            }
            Console.WriteLine();
        }
    }
}
