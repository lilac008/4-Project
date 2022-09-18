using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 18: Find Numbers Above and Below the Average in C#
 
/// dataType.Parse   : null이 입력될 경우 ArgumentNullException(매개변수 예외처리) -> java 예외처리 찾아볼것
/// Convert.dataType : null이 입력될 경우 0을 반환


namespace Basic_CSharp_Examples
{
    internal class Class18
    {
        static void Main1(string[] args)
        {
            int counter = 0;
            int[] intArray = new int[10];
            int sum = 0, avg = 0, low = 0, high = 0;

            for (int i=0; i<10; i++) 
            {
                Console.WriteLine("Number {0}:", (i+1));
                intArray[i] = Convert.ToInt32(Console.ReadLine());  ///
                sum += intArray[i];
            }

            avg = sum / 10; 
            // avg = sum / numbers.Length;

            for (int i=0; i<10; i++) 
            {
                if (intArray[i] < avg)
                {   low++;   }
                else 
                {   high++;  }

                Console.WriteLine("The average is : {0}", avg);
                Console.WriteLine("The numbers above the average are : {0}", high);
                Console.WriteLine("The numbers below the average are : {0}", low );
                Console.WriteLine();
            }




        }
    }
}
