using System;   
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp 
{



    class Player                                        ///class           : 설계도
    {

        public static int playerCount = 0;              ///static 멤버 변수 : class에 귀속, data 영역에 메모리차지
        int lv = 1;                                     ///class  멤버 변수
        int hp = 100;
        int mp = 100;
        int ap = 10;                                    /// attack point

        public void Setting(int _ap, int _hp)
        {
            playerCount = 100;
            ap = _ap;
            hp = _hp;
        }


        void Fight()
        {
            int damage = 0;
        }


        /// A
        void SetStatus(int _Hp, int _Mp)                ///class 멤버 함수 : 외부에서 매개변수를 받아들여 내부 변수를 변화시키는 용도 (변화시켜 플레이어에게 전달)
        {
            hp = _Hp;                                   ///지역 변수       : 일회용, 선언되는 순간 메모리 할당되고 함수가 끝나는 순간 사라짐
            mp = _Mp;
        }

        /// B
        void LevelUP(int _num)
        {
            ap = ap + (_num * 3);
        }

        /// C 
        void Damage(int _dam, int _subDam)
        {
            hp = hp - _dam;
            hp = hp - _subDam;
        }

        /// D
        public int LevelUP(int _num)                      ///class 멤버 함수 : return해주려는 자료형과 동일한 자료형이어야 함.     	  
        {
            return lv;                                    ///지역 변수       : return값은 object가 자신의 상태를 외부에 알려주는 용도로, 외부에 알려주는 순간 얼마나 많은 코드가 return아래에 있든 함수는 끝난다.
        }

        public int DamageToHPReturn(int _dam)
        {
            Hp = Hp - _dam;
            return Hp;
        }
    }

    /// code  :  상수형, 수정이 불가능함, 함수 그 자체가 수정이 불가
    /// data  :  static 멤버변수 (모든것을 공유할때 사용)
    /// hip   :  new Class명();해서 만들어진 객체들의 본체
    /// stack :  함수 안에 들어있는 지역변수        (메모리를 차지 후 사라짐) 



    class Program
    {

        static void Main()                                ///static 메인함수
        {
            Player newPlayer1 = new Player();
            Player newPlayer2 = new Player();
            Player newPlayer3 = new Player();

            newPlayer1.Setting(10, 100);
            newPlayer2.Setting(20, 50);
            newPlayer3.Setting(100, 500);

            Player.playerCount = 1;                     ///static은 instance 필요없음,data 영역
            Player.playerCount = 1;
            Player.playerCount = 1;

            ///newPlayer1.playerCount();                 ///객체는 static 변수를 쓸 수 없다.









            int attack = count;                          ///지역 변수        : 일회용, 선언되는 순간 메모리 할당되고 함수가 끝나는 순간 사라짐
            Player newPlayer = new Player();                 ///object화(객체화) : player설계도대로 player를 생성해내라  (obj를 만들었다는 것은 메모리를 지불했다는 것)


            /// A
            newPlayer.SetStatus(10, 10);                     ///(매개변수에 얼마가 들어갔는지 디버깅으로 확인가능)   
                                                             /// A-2
            newPlayer.Hp = newPlayer.Hp + 1;                    ///(값을 확인하기 힘듬, 바뀌는 곳마다 값을 재설정해야 함)
            newPlayer.Mp = newPlayer.Mp + 1;

            /// B
            newPlayer.LevelUP(1);

            /// C
            newPlayer.Damage(10, 1);

            /// D
            newPlayer.DamageToHPReturn(50);
        }
    }






    internal class Class13
    {


    }


}
