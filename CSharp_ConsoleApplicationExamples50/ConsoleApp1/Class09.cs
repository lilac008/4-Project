using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 9: C# Square Area and Perimeter Calculator

/// square : 정사각형, perimeter : 둘레

namespace Basic_CSharp_Examples
{
    internal class Class09
    {
        static void Main1(string[] args)
        {
            int squareheight, squareArea, perimeter;

            Console.Write("What is the height of your square? :");
            squareheight = Convert.ToInt32(Console.ReadLine());                 ///입력된 string형을 int형으로 변환

            squareArea = squareheight * squareheight;
            perimeter = 4 * squareheight;
            Console.WriteLine("Area : {0}\nPerimeter : {1}", squareArea, perimeter);         ///"\n"--> new line
            Console.ReadKey();
        }


    }
}
