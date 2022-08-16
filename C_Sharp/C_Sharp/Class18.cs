using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///내가 원하는 코드를 몇일 시간을 들여 구상하기 전에, 이미 인터넷에 널려있는 함수를 찾아서 써라.

/// 상속 : 공통되는 부분을 상속해 중복으로 쓰는 것 방지 (공통되는 코드 재활용), 내려준다 = 상속받는다.

class FightUnit
{
    protected string Name = "None";
    protected int AP = 10;
    protected int HP = 50;
    protected int MaxHP = 100;


    public void StatusRender()
    {
        Console.WriteLine(Name);
        Console.WriteLine("의 능력치--------");
        Console.Write("공격력 : ");
        Console.WriteLine(AP);

        //체력
        Console.Write("체력 : ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MaxHP);
        Console.WriteLine("-----------------");
    }

    public void MaxHeal() 
    {
        if (HP >= MaxHP)
        {
            Console.WriteLine("");
            Console.WriteLine("체력이 모두 회복되어있습니다.");
            Console.ReadKey();
        }
        else 
        {
            this.HP = MaxHP;
            PrintHp();
        }
        return;
    }

}


class Player   
{


}
class Monster
{ }


enum EStartSelect
{
    SelectTown,
    SelectBattleField,
    NoneSelect                   ///error나 잘못된 선택에 관한 것도 만든다
}




namespace C_sharp_2
{
    internal class Class18
    {
        static void StartSelect() /// 마을에서 시작시 선택
        {

        }

        static EStartSelect StartSelect2()          /// 마을에서 시작시 선택
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 싸움 지역");
            Console.WriteLine("어디로 가시겠습니까?");
            



            ConsoleKeyInfo CKI = Console.ReadKey();

            switch (CkI.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 이동합니다");
                    Console.ReadKey();
                    //break;
                    return EStartSelect.SelectTown;
                case ConsoleKey.D2:
                    Console.WriteLine("싸움 지역으로 이동합니다");
                    Console.ReadKey();
                    //break;
                    return EStartSelect.SelectBattleField;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.ReadKey();
                    return EStartSelect.NoneSelect;
            }

            return EStartSelect.SelectTown;         /// return되는 순간 return 아래 함수 종료
            return EStartSelect.SelectBattleField;

        }


        static void Town()
        {
            while (true)
            {
                Console.WriteLine("마을에서 무슨 일을 하시겠습니까?");
                Console.WriteLine("1.여관에서 체력 회복");
                Console.WriteLine("2.대장간에서 무기 강화");
                Console.WriteLine("3.마을을 나간다");

                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return;             ///
                    default:
                        break;
                }
                Console.ReadKey();   
            }


        }

        static void BatteField()
        {
            Console.WriteLine("아직 개장하지 않았습니다.");
            Console.ReadKey();
        }


        static void Main(string[] args)
        {

            ///StartSelect(); 


            while (true)
            {
                EStartSelect selectCheck = StartSelect2();

                switch (SelectCheck)
                {
                    case EStartSelect.SelectTown:
                        break;
                    case EStartSelect.SelectBattleField:
                        break;
                    case EStartSelect.NoneSelect:
                        break;
                    default:
                        break;
                }
            }







        }


    }
}
