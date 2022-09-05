using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 14: C# Program to Count Number of Words in a String

namespace Basic_CSharp_Examples
{
    internal class Class14
    {
        static void Main1(string[] args)
        {
            string sentence;
            Console.Write("Enter String :");
            sentence = Console.ReadLine();
            string[] words = sentence.Split(' ');
            Console.WriteLine("Count of words : " + words.Length);
            Console.WriteLine();



        }
    }
}
