using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 32: Nested For Loop in C# (Multiplication Table)

namespace Basic_CSharp_Examples
{
    internal class Class32
    {
        static void Main1(string[] args)
        {
            for (int i=1; i<=10; i++) 
            {
                for (int j=0; j<=10; j++) 
                {
                    Console.WriteLine("{0}x{1} = {2}", i, j, i * j);
                }
                Console.WriteLine();
            }
            Console.ReadKey();


        }
    }
}
