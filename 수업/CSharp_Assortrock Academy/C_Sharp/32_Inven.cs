using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



///32 - inventory : 





class Inven
{

    Item[] ArrItem;


    public Inven(int _X, int _Y)             ///생성자
    {
        if (1 > _X)                          ///방어코드 : 프로그램이 error가 없도록 들어오는 값들을 체크해서 문제가 없게 만드는 
        {
            _X = 1;
        }
        if (1 > _Y) 
        {
            _Y = 1;
        }

        ArrItem = new Item[(_X * _Y)];       /// 담을 수 있는 아이템의 총 개수 : X * Y
    }
}








namespace C_Sharp
{
    internal class _32_Inven
    {

        static void Main(string[] args)
        {
            Player32 newPlayer = new Player32();
            Player32 newPlayer2 = null;

            Console.WriteLine(newPlayer2.AT);


            public void Render()
            {
                for (int i = 0; i < ArrItem.Length; i++) 
                {

                    if (0 != i && 0 == i % ItemX) 
                    {
                        Console.WriteLine("");
                    }

                    if (null == ArrItem[i])
                    {
                        Console.WriteLine("□");
                    }
                    else 
                    {
                        Console.WriteLine("■");
                    }

                }
            }







        }

    }
}
