using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 36: Enter Only Numbers in C# Console Application using do-while loop


namespace Basic_CSharp_Examples
{
    internal class Class36_2__
    {
        static void Main1(string[] args)
        {
            double val = 0;
            string num = "";
            Console.Write("Enter Number: ");
            ConsoleKeyInfo chr;
            do
            {
                chr = Console.ReadKey(true);
                if (chr.Key != ConsoleKey.Backspace)
                {
                    bool control = double.TryParse(chr.KeyChar.ToString(), out val);
                    if (control)
                    {
                        num += chr.KeyChar;
                        Console.Write(chr.KeyChar);
                    }
                }
                else
                {
                    if (chr.Key == ConsoleKey.Backspace && num.Length > 0)
                    {
                        num = num.Substring(0, (num.Length - 1));
                        Console.Write("\b \b");
                    }
                }
            }
            while (chr.Key != ConsoleKey.Enter);
            Console.ReadKey();
        }
    }
}
