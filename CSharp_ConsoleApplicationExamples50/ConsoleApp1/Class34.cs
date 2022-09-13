using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 34: Checking for Palindrome Strings or Numbers in C#
/// 회문(palindrome)은 거꾸로 읽어도 제대로 읽는 것과 같은 문장, 낱말, 숫자, 문자열이다. 보통 낱말 사이에 있는 띄어쓰기나 문장 부호는 무시한다.



namespace Basic_CSharp_Examples
{
    internal class Class34
    {
        static void Main(string[] args)
        {
            Console.Write("Enter something for to check that is it palindrome :");
            string text = Console.ReadLine();
            int textlength = text.Length;
            bool flag = true;


            for (int i=0; i<textlength/2; i++)             //check palindrome
            {
                if ( text[i] != text[ textlength-(i+1) ] ) 
                {
                    flag = false;
                    break;
                }
            }


            if (flag)                                             //if flag true, text is palindrome
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
