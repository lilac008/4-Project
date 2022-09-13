using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 22: Counting program the total letter in text in C# Console

namespace Basic_CSharp_Examples
{
    internal class Class22_2
    {
        static void Main1(string[] args)
        {

            Console.Write("Enter string : ");
            string myString = Console.ReadLine();
            int count = 0;

            foreach (char data in myString) 
            {
                if (!char.IsWhiteSpace(data))    //check the char for whitespace. If char is not whitespace, increase the count variable.
                {  count++;  }
            }

            Console.WriteLine("Total letters : " + count);
            Console.ReadLine();
        }
    }
}
