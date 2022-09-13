using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 18: Find Numbers Above and Below the Average in C#

namespace Basic_CSharp_Examples
{
    internal class Class18
    {
        static void Main1(string[] args)
        {
            int counter = 0;
            int[] numbers = new int[10];
            int sum = 0, avg = 0, low = 0, high = 0;

            for (int i=0; i<10; i++) 
            {
                Console.WriteLine("Number {0}:", (i+1));
                numbers[i] = Convert.ToInt32(Console.ReadLine());
                sum += numbers[i];
            }

            avg = sum / 10; 
            // avg = sum / numbers.Length;

            for (int i=0; i<10; i++) 
            {
                if (numbers[i] < avg)
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
