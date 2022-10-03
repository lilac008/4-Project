using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 40: Find Numbers Above and Below the Average in C#

/// Above the Average 
/// Below the Average



namespace Basic_CSharp_Examples
{
    internal class Class40__above_below_average
    {
        static void Main1(string[] args)
        {
            int counter = 0;
            int[] intArr = new int[10];
            int sum = 0, avg = 0, low = 0, high = 0;

            Console.WriteLine("Enter 10 random numbers : ");
            for (int i = 0; i < 10; i++) 
            {
                Console.Write("Number {0} :", (i+1));
                intArr[i] = Convert.ToInt32(Console.ReadLine());
                sum += intArr[i];    
            }
            avg = sum / 10;          ///avg = sum / numbers.Length;


            for (int i = 0; i < 10; i++) 
            {
                if (intArr[i] < avg)        ///임의의 숫자가 평균보다 작으면
                { 
                    low++; 
                }
                else                        ///그렇지 않으면
                { 
                    high++; 
                }
            }

            Console.WriteLine();
            Console.WriteLine("The average is : {0}", avg);
            Console.WriteLine("The numbers above the average are: {0}", high);
            Console.WriteLine("The numbers below the average are: {0}", low);
            Console.ReadKey();
        }
    }
}
