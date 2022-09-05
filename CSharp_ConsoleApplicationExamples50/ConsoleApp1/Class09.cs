using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 9: C# Square Area and Perimeter Calculator

namespace Basic_CSharp_Examples
{
    internal class Class09
    {
        static void Main1(string[] args)
        {
            int squareheight, area, perimeter;
            Console.Write("What is the height of your square? :");
            squareheight = Convert.ToInt32(Console.ReadLine());
            area = squareheight * squareheight;
            perimeter = 4 * squareheight;
            Console.WriteLine("Area: {0}|nPerimeter : {1}", area,perimeter);
            Console.ReadKey();
        }


    }
}
