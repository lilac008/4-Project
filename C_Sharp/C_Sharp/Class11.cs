using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player
{
    public int AP = 10;
    public int HP = 100;

    public void Test(int _Dmg)            ///int _Dmg (지역변수):  stack에 위치 
    {
        _Dmg = 1000;

    }
}


namespace C_Sharp
{
    internal class Class11
    {



        static void Main(string[] args) 
        {

            Player newPlayer = new Player();

            newPlayer.Test(100);

            int value = 0;                  ///stack에 위치 
            newPlayer.Test(value);

            Console.WriteLine(value);


        }

    }
}
