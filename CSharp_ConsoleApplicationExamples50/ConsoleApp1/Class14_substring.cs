using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 14: C# Program to Count Number of Words in a String


/// 부분문자열 : https://learn.microsoft.com/ko-kr/dotnet/csharp/how-to/parse-strings-using-split

namespace Basic_CSharp_Examples
{
    internal class Class14_substring
    {
        static void Main1(string[] args)
        {
            string phrase;
            Console.Write("Enter String :");
            phrase = Console.ReadLine();

            string[] substringArray = phrase.Split(' ');         ///부분문자열 배열, 
            Console.WriteLine("Count of words : " + substringArray.Length);
            Console.WriteLine();

        }



    }
}     
