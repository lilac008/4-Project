using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 29: Display Numbers Between 1 to N Using For Loop

namespace Basic_CSharp_Examples
{
    internal class Class29
    {
        static void Main1(string[] args)
        {
            int n;
            Console.Write("Number :");
            n = Convert.ToInt32(Console.ReadLine());

            for (int i =1;  i<= n;  i++) 
            {
                Console.WriteLine(i);
            }
            Console.ReadKey();
        }
    }
}
