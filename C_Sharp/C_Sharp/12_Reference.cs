using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




///12강 - Reference형
class Player12                               
{
    public int HP = 100;
    public int AP = 10;

    public void BeAttacked(Monster12 _Monster)
    {
        HP -= _Monster.AP;
    }

    public void Attack(Monster12 _Monster)   
    {
        _Monster.HP -= AP;
    }
}


class Monster12
{
    public int HP = 100;
    public int AP = 10;

    public void BeAttacked(Player12 _Player) 
    {
        HP -= _Player.AP;
    }

    public void Attack(Player12 _Player)
    {
        _Player.HP -= AP;           
    }

    public void Test(int _Test) 
    {
        _Test = 1000;
    }
}  




namespace C_Sharp
{
    internal class _12_Reference
    {

        static void Main(string[] args)
        {

            Monster12 newMonster = new Monster12();          ///reference형(본체(hip 영역)에서 크기, 값을 빌려오기 전까지 미정) : stack 

            Player12 newPlayer = new Player12();      


            newMonster.BeAttacked(newPlayer);                ///Reference형(본체(hip 영역)의 주소를 가리켜 값을 변환) : stack 

            newMonster.Attack(newPlayer);                 



            int a = 0;                                       ///Value형에 0 저장
            newMonster.Test(a);                              ///변수 a 값은 저장된 값 그대로





        }
    }
}
