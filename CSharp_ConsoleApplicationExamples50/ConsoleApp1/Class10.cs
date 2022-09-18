using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 10: Area and Perimeter of Circle in C# Console Application

///Math.Pow(double x,double y); x^y   
///= Math.Power

namespace Basic_CSharp_Examples
{
    internal class Class10
    {
        static void Main1(string[] args)
        {
            double radius, perimeter, area;
            Console.Write("Please write the radius of your cirlce :");
            radius = Convert.ToDouble(Console.ReadLine());                  ///입력된 string형을 double형으로 변환

            perimeter = 2 * 3.14 * radius;
            area = 3.14 * Math.Pow(radius,2);      ///circle area = 3.14 * r * r
            Console.WriteLine("==============================");
            Console.WriteLine("The perimeter of your circle : {0}", perimeter);
            Console.WriteLine("The area of your circle : {0}", area);
            Console.WriteLine();

        }

    }
}
