using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 14: C# Program to Count Number of Words in a String


/// 부분문자열 : https://learn.microsoft.com/ko-kr/dotnet/csharp/how-to/parse-strings-using-split

namespace Basic_CSharp_Examples
{
    internal class Class14
    {
        static void Main1(string[] args)
        {
            string input;

            Console.Write("Enter String :");
            input = Console.ReadLine();

            string[] splitSentenceArray = input.Split(' ');         ///부분문자열 배열, 
            Console.WriteLine("Count of words : " + splitSentenceArray.Length);
            Console.WriteLine();

        }



    }
}     
