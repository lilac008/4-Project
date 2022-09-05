using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 5: Multiply Two Floating Point Numbers in C# Console

namespace Basic_CSharp_Examples
{
    internal class Class05
    {
        static void Main1(string[] args)
        {
            float num1, num2, product;
            num1 = 12.45f;
            num2 = 10.74f;
            
            product = num1 * num2;

            Console.WriteLine("{0}*{1}={2}",num1,num2, product);
            Console.WriteLine();
        }
    }
}
