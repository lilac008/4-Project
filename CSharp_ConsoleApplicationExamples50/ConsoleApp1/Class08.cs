using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 8: C# Calculate Rectangle Area

namespace Basic_CSharp_Examples
{
    internal class Class08
    {
        static void Main1(string[] args)
        {
            int area, length, width;
            Console.Write("Please write the length of your rectangle:");
            length = Convert.ToInt32(Console.ReadLine());
            Console.Write("Please write the width of your rectangle:");
            width = Convert.ToInt32(Console.ReadLine());
            area = length*width;
            Console.WriteLine("The area of rectangle : {0}", area);
            Console.WriteLine();
 
        }
    }
}
