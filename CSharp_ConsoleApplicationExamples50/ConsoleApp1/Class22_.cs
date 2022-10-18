using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 22: Counting program the total letter in text in C# Console
/// code 1:

///char.IsWhiteSpace(); 문자가 공백인지 여부를 나타내는 함수

namespace Basic_CSharp_Examples
{
    internal class Class22_
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter string : ");
            string input = Console.ReadLine();   
            int tot_letter = 0;


            for (int i = 0; i < input.Length; i++) 
            {
                if (!char.IsWhiteSpace(input[i]))    ///If char is not whitespace, increase the tot_letter variable.
                { tot_letter++;  }
            }

            Console.WriteLine("Total letters : " + tot_letter);
            Console.ReadLine();
        }
    }
}
