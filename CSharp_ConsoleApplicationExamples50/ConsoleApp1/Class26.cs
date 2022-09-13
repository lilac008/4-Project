using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 26: C# program to find min and max in an array

namespace Basic_CSharp_Examples
{
    internal class Class26
    {
        static void Main1(string[] args)
        {
            ///www.csharp-console-examples.com
            int[] numbers = new int[10];
            Random random = new Random();
            int min, max;

            for (int i=0; i < numbers.Length; i++) 
            {
                numbers[i] = random.Next(1,100);
                Console.WriteLine(numbers[i]);
            }
            min = numbers[0];
            max = numbers[0];
            for (int i=1; i < numbers.Length; i++) 
            {
                if (min > numbers[i])
                    min = numbers[i];
                if(max < numbers[i])
                    max = numbers[i];
            }
            Console.WriteLine();
            Console.WriteLine("The highest number in the array: " + max);
            Console.WriteLine("The lowest number in the array: " + min);
            Console.ReadKey();


        }

    }
}
