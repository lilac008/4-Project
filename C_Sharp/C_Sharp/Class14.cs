using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static class StClass 
{
    ///int a = 0;        //static 멤버변수, static 멤버 함수만 가능하다.
    
}

    
public class Player 
{
    private int hp = 100;

    public static void PVP(Player _One, Player _Two) ///Player instance
    {
        _One.hp -= _Two.hp;                          ///Player instance 끼리 서로 싸움
        _Two.hp -= _One.hp; 
    }

    public void Damage(int _Damage)               ///Monster instance
    {
        hp -= 10;
    }
}

public class Monster
{
    private int ap = 100;                            ///attack point

    public void Damage2(int _Damage)              
    {
        //hp -= 10;
    }

    public void Damage3(Player _Damage) // 자신의 reference는 자기 내부에서 모두 public 상태?     
    {
        //hp -= 10;
    }


}



namespace C_sharp_2
{

 




    internal class Class14
    {

        static void Main(string[] args) ///메인실행함수도 class에 속한 static함수, 즉 C# 프로그램은 정적멤버함수로부터 시작한다.
        {
            //F12 - console도 static으로 선언되어 있다.
            Console.WriteLine(); 


            Player newPlayer1 = new Player(); 
            Player newPlayer2 = new Player(); 
            Player newPlayer3 = new Player();

            newPlayer1.Damage(100);

            //Player.Damage(100);

            Player.PVP(newPlayer1, newPlayer2);         ///static은 객체화없이 class를 받아쓴다.


        }
    }
}
