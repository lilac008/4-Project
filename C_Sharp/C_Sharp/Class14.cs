using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




///14강 - Static (class에 속하고 class명으로 바로 호출, data영역에서 값 공유)



static class StaticClass 
{
    ///int a = 0;        //static 멤버변수, static 멤버 함수만 가능하다.

}
    

public class Player14 
{
    private int HP = 100;
    private int AP = 10;


    public static void PVP(Player14 _One, Player14 _Two)     ///static PVP()함수 : 
    {
        _One.HP -= _Two.AP;                                  ///Player instance 끼리 서로 싸움
        _Two.HP -= _One.AP; 
    }

    public void Damage(int _Damage)               
    {
        HP -= 10;
    }

    public void Damage(Player14 _Damage)                    ///Monster14(내부 변수가 private이므로)를 넣을 수 없다    
    {
        HP -= 10;
    }


}


public class Monster14
{
    private int HP = 100;
    private int AP = 10;

}



namespace C_sharp_2
{

 




    internal class Class14
    {

        static void Main(string[] args)                             ///static 주실행함수 -> C# 프로그램은 static멤버함수로부터 시작한다는 것을 알 수 있다.
        {
            Player14 newPlayer1 = new Player14(); 
            Player14 newPlayer2 = new Player14(); 
            Player14 newPlayer3 = new Player14();

            newPlayer1.Damage(100);
            ///Player14.Damage(100);                                ///static일 경우에 가능


            Player14.PVP(newPlayer1, newPlayer2);                   ///static PVP() 함수는 class 그 자체를 받음


            Console.WriteLine("안녕하세요");                        ///F12 - console도 static으로 선언되어 있다.

        }
    }
}
