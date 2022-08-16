using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






namespace C_sharp_2
{
    internal class Class15
    {

        class Player
        {
            private int hp;                    ///class 멤버변수
            private static int sp;             ///static 멤버변수


            public static void PVP(Player _One, Player _Two)
            {
                ///hp = 1000;        //static멤버함수는 객체의 영향을 받지 않으므로 일반 멤버변수는 쓸 수 없고 static멤버변수만 가능
                sp = 50;
            }

            public void Damage(int _Dmg)
            {
                sp -= _Dmg;
            }

            public static void Damage2(Player _One, int _Dmg)
            {
                _One.hp -= _Dmg;
            }

            public void Heal(int _Heal) 
            {
                hp += _Heal;                            ///1-3 눈에 보이지 않아도 this가 생략된 것.
                this.hp += _Heal;                       ///1-2 Heal2 함수의 매개변수 방식 대신 사용하는 방식, 단 static함수에서는 객체를 만들지 않고 쓸수 있으므로 this가 필요없다.
               
            }

            public void Heal2(Player _One, int _Heal)   ///1-1 잘 사용하지 않는다.
            {
                _One.hp += _Heal;
            }

        }




        static void Main(string[] args)
        {

            Player newPlayer1 = new Player();
            Player newPlayer2 = new Player();
            Player newPlayer3 = new Player();

            Player.PVP(newPlayer1, newPlayer2);

            newPlayer2.Damage(100);


            Player.Damage2(newPlayer1,100);


            newPlayer2.Heal2(newPlayer2, 100);  //조금 불편하므로 잘 사용하진 않는다.
        }


    }
}
