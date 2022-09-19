using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 34: Checking for Palindrome Strings or Numbers in C#
0/// Palindrome : 회문, 거꾸로 읽어도 제대로 읽는 것과 같은 문장, 낱말, 숫자, 문자열.



namespace Basic_CSharp_Examples
{
    internal class Class34__
    {
        static void Main1(string[] args)
        {
            Console.Write("Enter something for to check that is it palindrome :");
            string text = Console.ReadLine();
            int len = text.Length;
            bool flag = true;

            for (int i = 0; i < len / 2; i++)       ///회문확인
            {
                if (text[i] != text[len - (i + 1)])
                {
                    flag = false;
                    break;
                }
            }

            if (flag)///if flag true, text is palindrome
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
