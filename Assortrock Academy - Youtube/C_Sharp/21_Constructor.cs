using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





/// 21 - constructor(생성자) :  1. class명 = constructor명 
///                             2. class의 메모리가 만들어질 때 생성자가 실행되어진다. 즉, 생성자를 만들지 않아도 자동으로 생성된다. 
///                             3. 무조건 자신의 class명을 return해야 하므로 그 외의 return값은 없다.
///                             4. 상속됨 



class FightUnit21 
{
    protected int AP = 10;

    public FightUnit21()              ///constructor
    {
        int a = 0;
    }
}




class Player21 : FightUnit21
{

    public  Player21()               ///constructor
    {
        AP = 100;
        int a = 0;
    }
}



namespace C_Sharp
{
    internal class Class21
    {

        static void Main(string[] args)
        {

            Player21 newPlayer = new Player21();





        }
    }
}
