using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player32
{
    private int AT;

    public int AT                        //생성자
    {
        get 
        { return AT; }
        set 
        { AT = value; }
    }
}



class Program 
{
    static void Main(string[] args)
    {
        Player32 newPlayer = new Player32();

        Player32 newPlayer2 = null; ///reference형 객체에 아무것도 가르키는 것 없이 비워놓겠다.

        Console.WriteLine(newPlayer.AT);
        Console.WriteLine(newPlayer2.AT);


        /// ***** - 눈으로 보고 판단해야지 머리로 이해하려고 하면 안 된다
        /// *****
        /// *****
        Inven newInven = new Inven(5, 3);
        Inven newItem = new Inven("철검", 100);


        while (true) 
        {
            Console.Clear();
            newInven.Render();
            Console.ReadKey();
        }



    }
}






namespace C_Sharp
{
    internal class _32_Program
    {
    }
}
