using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 10: Area and Perimeter of Circle in C# Console Application


namespace Basic_CSharp_Examples
{
    internal class Class10
    {
        static void Main1(string[] args)
        {
            double r, perimeter, area;
            Console.Write("Please write the radius of your cirlce :");
            r = Convert.ToDouble(Console.ReadLine());
            perimeter = 2 * 3.14 * r;
            area = 3.14 * Math.Pow(r,2);    //area = 3.14 * r * r;
            Console.WriteLine("==============================");
            Console.WriteLine("The perimeter of your circle : {0}", perimeter);
            Console.WriteLine("The area of your circle : {0}", area);
            Console.WriteLine();

        }

    }
}
