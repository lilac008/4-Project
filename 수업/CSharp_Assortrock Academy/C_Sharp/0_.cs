using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_Sharp
{
    internal class Class1
    {


        void Fight()
        {
            int damage = 0;
        }


        /// A
        void SetStatus(int _hp, int _mp)                  ///class멤버 함수 : 외부에서 매개변수를 받아들여 내부 변수를 변화시키는 용도 (변화시켜 플레이어에게 전달)
        {
            HP = _hp;                                     ///local 변수     : 일회용, 선언되는 순간 메모리 할당되고 함수가 끝나는 순간 사라짐
            MP = _mp;
        }

        /// B
        void LevelUP(int _num)
        {
            AP = AP + (_num * 3);
        }

        /// C 
        void Damage(int _damage, int _subDamage)
        {
            HP = HP - _damage;
            HP = HP - _subDamage;
        }

        /// D
        public int LevelUP(int _num)                       ///class멤버 함수 : return해주려는 자료형과 동일한 자료형이어야 함.     	  
        {
            return LV;                                     ///local 변수     : return값은 object가 자신의 상태를 외부에 알려주는 용도로, 외부에 알려주는 순간 얼마나 많은 코드가 return아래에 있든 함수는 끝난다.
        }

        public int DamageToHPReturn(int _dam)
        {
            Hp = Hp - _dam;
            return Hp;
        }


        static void Main(string[] args)
        {

            int attack = count;                          ///지역 변수        : 일회용, 선언되는 순간 메모리 할당되고 함수가 끝나는 순간 사라짐
            Player13 newPlayer = new Player13();                 ///object화(객체화) : player설계도대로 player를 생성해내라  (obj를 만들었다는 것은 메모리를 지불했다는 것)


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









        1

    }
}
