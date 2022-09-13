using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 32: Nested For Loop in C# (Multiplication Table)

namespace Basic_CSharp_Examples
{
    internal class Class32_2
    {
        static void Main1(string[] args)
        {
            for (int j=1; j<=10; j++)
            {
                for (int i=1; i<=10; i++)
                {
                    Console.Write("{0}*{1}={2}\t", i, j, (i * j));
                }
                Console.WriteLine();
            }
            Console.ReadKey();


        }
    }
}
