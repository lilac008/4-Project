using System;   ///누군가 만들어 정의해놓은 코드를 쓰겠다.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp ///namespace : 구상한 개념이 겹칠 때 개념을 분류하는 용도
{


    internal class Class1
    {

        /// - IDE(Integrated Development Environment) :  프로그램 제작을 도와주는 프로그램, 한줄한줄 읽는 걸 도와준다.
        /// - 한글처리가 미흡하므로 유니티 폴더도 영어로 만들어야. 
        /// 
        /// 
        /// - literal값 : ?
        /// 



        /// Object Oriented(객체지향) : class 안의 obj를 만들고, 그 obj를 기반으로 모든 걸 해결하기 때문에 객체지향이라고 함. 단 obj를 만들기 전에 class부터 먼저 설계해야 한다.
        ///
        /// ex) 구상한 개념1 : 상하좌우로 움직이는 Player를 만들고 싶다 
        ///                    class Player()
        ///                    { 상하좌우로 움직이는 코드 }  
        ///                    Player라는 class(설계도)를 만들어서 Player obj에 연결시켜 프로그램 실행.
        ///
        /// 
        ///


        /// Value형
        /// 
        /// 변수선언 : 무언가 만든다는 것은 메모리를 할당한다는 것
        ///
      

        int hp; /// 주소값 할당, 똑같은 번지에 할당할 수 없으므로 중복시 빗금으로 처리된다.
        int hp; 
        int mp = 100; ///주소값 n번째에 4byte(int형)만큼 공간을 만들고 mp라 이름짓고 100이라는 값을 채워넣어라.




        class Player                                        ///class           : 설계도
        {
            int lv = 1;                                     ///class 멤버 변수
            int hp = 100;
            int mp = 100;
            int attackPoints = 10;


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
                attackPoints = attackPoints + (_num * 3);     
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



        class Program
        {

            static void Main()                                ///메인함수
            {
                int Attack2 = count;                          ///지역 변수        : 일회용, 선언되는 순간 메모리 할당되고 함수가 끝나는 순간 사라짐
                Player player = new Player();                 ///object화(객체화) : player설계도대로 player를 생성해내라  (obj를 만들었다는 것은 메모리를 지불했다는 것)


                /// A
                player.SetStatus(10, 10);                     ///(매개변수에 얼마가 들어갔는지 디버깅으로 확인가능)   
                                                              /// A-2
                player.Hp = player.Hp + 1;                    ///(값을 확인하기 힘듬, 바뀌는 곳마다 값을 재설정해야 함)
                player.Mp = player.Mp + 1;

                /// B
                player.LevelUP(1);

                /// C
                player.Damage(10, 1);

                /// D
                player.DamageToHPReturn(50);
            }
        }


        ///code (상수형, 수정이 불가능함, 함수 그 자체가 수정이 불가)
        ///data 
        ///hip			
        ///stack (메모리 차지 후 사라짐) 
        ///





    }
}
