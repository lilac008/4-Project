using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





/// 21 - 생성자(return값이 없다) 

class FightUnit 
{
    protected string Name = "None";
    protected int AP = 10;
    protected int HP = 50;
    protected int MaxHP = 100;

    public void StatusRender() 
    {
        
    }

    public FightUnit() 
    {
        int a = 0;
    }
}




class Player21 
{

    public Player21()             ///생성자 : 1.클래스 명과 함수명이 같음.   2. 만들지 않아도 이 함수는 만들어짐.  3. 상속됨  4. 무조건 자신의 클래스의 메모리를 리턴
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
