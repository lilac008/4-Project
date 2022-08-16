using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




///13강 - Static (class에 속하고 class명으로 바로 호출, data영역에서 값 공유)
class Player13                                        ///class : 설계도
{

    public static int playerCount = 0;                /// static멤버 변수 : data 

    int LV = 1;                                       /// class멤버 변수
    int HP = 100;
    int MP = 100;
    int AP = 10;                                      

    public void Setting(int _ap, int _hp)
    {
        playerCount = 100;                            
        AP = _ap;
        HP = _hp;
    }
}


class Monster13 
{
    static int monsterDeathCount;                     ///1-2  static 아님(개별로) : hip영역에서 instance 각각 개별로 1 증가,   static(값공유) : data영역에서 1씩 계속 누적

    public void Death()
    {
        monsterDeathCount += 1;
    }
}





namespace C_Sharp 
{

    internal class Class13
    {

        static void Main()                                  ///static 주실행함수
        {
            Player13 newPlayer1 = new Player13();
            Player13 newPlayer2 = new Player13();
            Player13 newPlayer3 = new Player13();

            newPlayer1.Setting(10, 100);
            newPlayer2.Setting(20, 50);
            newPlayer3.Setting(100, 500);



            newPlayer1.HP = 200;                            ///Referance : instance 호출

            Player13.playerCount = 1;                       ///static : class로 바로 호출 : data
            Player13.playerCount = 2;
            Player13.playerCount = 3;
            ///newPlayer1.playerCount();                    ///static : instance 사용불가




            Monster13 newMonster1 = new Monster13();        ///몹 instance 생성
            Monster13 newMonster2 = new Monster13();
            Monster13 newMonster3 = new Monster13();

            newMonster1.Death();                            ///몹 instance 죽음, 1-1 변수 monsterDeathCount가 static 아님 : hip영역에서 instance 각각 개별로 1 증가,   static (값공유) : data영역에서 1씩 계속 누적.
            newMonster2.Death();
            newMonster3.Death();



        }
    }









}
