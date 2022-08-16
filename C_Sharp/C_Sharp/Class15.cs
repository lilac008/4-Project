﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




///15강 - 
class Player15
{
    private int HP;                                          ///class 멤버변수
    private static int SP;                                   ///static 멤버변수



    public static void PVP(Player15 _One, Player15 _Two)
    {
        ///HP = 1000;                                        //static class는 static멤버변수만 가능
        SP = 50;
    }

    public void Damage(int _Dmg)
    {
        HP -= _Dmg;
        ///this.HP -= _Dmg;
    }

    public static void Damage(Player15 _One, int _Dmg)
    {
        _One.HP -= _Dmg;
        ///this.HP -= _Dmg;
    }


    public void Heal(int _Heal)
    {
        HP += _Heal;                                             ///1-3 눈에 보이지 않아도 this가 생략된 것.
        this.HP += _Heal;                                        ///1-2 Heal2 함수의 매개변수 방식 대신 사용하는 방식, 단 static함수에서는 객체를 만들지 않고 쓸수 있으므로 this가 필요없다.

    }

    public void Heal(Player15 _One, int _Heal)                   ///1-1 잘 사용하지 않는다.
    {
        _One.HP += _Heal;
    }

}


namespace C_sharp_2
{


    internal class Class15
    {
        static void Main(string[] args)
        {

            Player15 newPlayer1 = new Player15();
            Player15 newPlayer2 = new Player15();
            Player15 newPlayer3 = new Player15();

            Player15.PVP(newPlayer1, newPlayer2);


            newPlayer2.Damage(100);


            ///둘다 똑같다
            newPlayer1.Damage(100);
            Player15.Damage(newPlayer1,100);


            newPlayer2.Heal(newPlayer2, 100);                   ///조금 불편하므로 잘 사용하진 않는다.
        }


    }
}
