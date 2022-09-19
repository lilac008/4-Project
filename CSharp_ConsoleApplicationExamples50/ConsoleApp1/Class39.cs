using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 39: Calculate Sum and Average of an Array in C#


namespace Basic_CSharp_Examples
{
    internal class Class39
    {
        static void Main(string[] args)
        {
            double sum = 0, avg = 0;
            double[] numArr = { 10, 20, 50, 40 };

            for (int i = 0; i < numArr.Length; i++) 
            {
                sum += numArr[i];
            }
            avg = sum / numArr.Length;
            Console.WriteLine("The Sum is : " + sum);
            Console.WriteLine("The Average is : " + avg);

            Console.ReadKey();


        }
    }
}
