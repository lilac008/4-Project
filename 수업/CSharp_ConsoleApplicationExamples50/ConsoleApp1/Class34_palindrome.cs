using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;


/// Example 34: Checking for Palindrome Strings or Numbers in C#
/// 
/// Palindrome : 회문, 거꾸로 읽어도 제대로 읽는 것과 같은 문장, 낱말, 숫자, 문자열.
/// ex) Level 





namespace Basic_CSharp_Examples
{
    internal class Class34_palindrome
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter something for to check that is it palindrome :");
            string text = Console.ReadLine();
            int textlength = text.Length;
            bool isPalindrome = true;

            for (int r = 0;  r < textlength/2;  r++)       
            {
                if ( text[r] !=  text[ textlength - (r+1) ] )   /// index : 0 - 4,  1 - 3,  2 - 2     
                {
                    isPalindrome = false;
                    break;
                }
            }

            if (isPalindrome)
            {
                Console.WriteLine("{0} is palindrome", text);
            }
            else
            {
                Console.WriteLine("{0} is not palindrome", text);
            }
            Console.ReadLine();
        }
    }
}
