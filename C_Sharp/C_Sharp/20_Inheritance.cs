using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



class FightUnit20 ///class 상속은 C#에서 1개만 가능하다
{
    protected int HP = 50;
    protected int AP = 50;

    public void Damage(/* int */FightUnit20 _fightUnit20) 
    {
        this.HP -= _fightUnit20.AP;
    }
}

class Player20 : FightUnit20
{
    int LV = 1;

    void Heal() 
    {
        HP = 100;
        ///this.HP = 100;
    }
}

class Monster20 : FightUnit20
{
    int Exp = 10;
}



namespace C_Sharp
{
    internal class _20_Inheritance
    {

        static void Main(string[] args)
        {
            Player20 newPlayer = new Player20();
            Monster20 newMonster = new Monster20();

            ///1. 매개변수가 int형일 경우
            ///newPlayer.Damage(10);

            
            ///2. 매개변수가 FightUnit20일경우
            newPlayer.Damage(newMonster);

            FightUnit20 fightUnit = newPlayer;                      ///업캐스팅 : 자식이 부모형이 되면서 자식의 부분을 모두 버린다.  <-> 다운캐스팅 : Player20 otherPlayer = _fightUnit20; 최대한 지양하는 것이 좋다.
            newPlayer.Damage(fightUnit);

            newPlayer.Damage(newPlayer);


            newMonster.Damage(newPlayer);




        }


    }
}
