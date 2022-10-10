class Program
{


    static void Main(string[] args)
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


