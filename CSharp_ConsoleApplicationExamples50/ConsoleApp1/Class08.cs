using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 8: C# Calculate Rectangle Area

///rectangle : 직사각형

namespace Basic_CSharp_Examples
{
    internal class Class08
    {
        static void Main1(string[] args)
        {
            int rectArea, rectLength, rectWidth;

            Console.Write("Please write the length of your rectangle:");        
            rectLength = Convert.ToInt32(Console.ReadLine());     ///입력된 string형을 int형으로 변환

            Console.Write("Please write the width of your rectangle:");
            rectWidth = Convert.ToInt32(Console.ReadLine());
            
            rectArea = rectLength*rectWidth;
            Console.WriteLine("The area of rectangle : {0}", rectArea);
            Console.WriteLine();
 
        }
    }
}
