using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Player18
{
    int HP = 50;
    int MaxHP = 100;
    int AP = 10;

    public void StatusRender() 
    {
        Console.WriteLine("-----------------");
        Console.Write("공격력 : ");
        Console.WriteLine(AP);
        Console.Write("체력 : ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MaxHP);
        Console.WriteLine("-----------------");
    }

    public void /* int */ MaxHeal(/*Player this*/)              
    {
        if (HP >= MaxHP)
        {

        }
        else 
        {
            this.HP = MaxHP;
            PrintHP();
        }
        return;
        ///return HP;                          //HP를 반환할 경우엔 함수에 int

    }

    public int PrintHP() 
    {
        Console.WriteLine();
        Console.Write("현재 플레이어의 HP는");
        Console.Write(HP);
        Console.WriteLine("입니다.");
        Console.ReadKey();                  ///?????????????
    }

}

class Monster18
{ }

enum EnumStartSelect
{
    SelectTown,
    SelectBattleField,
    NoneSelect                   ///error나 잘못된 선택에 관한 것도 만든다
}


namespace C_sharp_2
{
    internal class Class18
    {

        static EnumStartSelect StartSelect() /// 마을에서 시작시 선택
        {
            Console.Clear();                                            ///반복시 기존 출력화면 지움
            Console.WriteLine("");
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 싸움 지역");
            Console.WriteLine("어디로 가시겠습니까?");

            ///키 입력할 경우 나눠서 선택 
            ConsoleKeyInfo consoleKey = Console.ReadKey();
            Console.WriteLine("");
            switch (consoleKey.Key)
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 이동합니다");
                    Console.ReadKey();                                  ///한번 더 눌러야 다음내용 실행
                    return EnumStartSelect.SelectTown;
                case ConsoleKey.D2:
                    Console.WriteLine("싸움 지역으로 이동합니다");
                    Console.ReadKey();
                    return EnumStartSelect.SelectBattleField;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.ReadKey();
                    return EnumStartSelect.NoneSelect;
            }
            return EnumStartSelect.SelectTown;         ///return시 반환되고 종료되므로 아래에 얼마나 있든 실행되지 않는다 
            return EnumStartSelect.SelectBattleField;
        }

        static void Town(Player18 _Player)
        {
            while (true)
            {
                Console.Clear();                                            ///반복시 기존 출력화면 지움
                _Player.StatusRender();
                Console.WriteLine("마을에서 무슨 일을 하시겠습니까?");
                Console.WriteLine("1.여관에서 체력 회복");
                Console.WriteLine("2.대장간에서 무기 강화");
                Console.WriteLine("3.마을을 나간다");

                // 방법1 : ConsoleKeyInfo consoleKey = Console.ReadKey();
                // 방법2 : ConsoleKey consoleKey2 = Console.ReadKey().Key;
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        //if ()
                        //{
                            _Player.MaxHeal();
                        //}
                        //else { }
                        break;
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return;                         ///마을을 나가므로 return 
                }
                Console.ReadKey();
            }
        }

        static void Battle()
        {
            Console.WriteLine("아직 개장하지 않았습니다.");
            Console.ReadKey();
        }

        





        static void Main(string[] args)
        {
            Player18 newPlayer = new Player18();                ///주실행함수 내의 지역변수라는 의미 

            while (true) 
            {
                //StartSelect();
                EnumStartSelect selectCheck = StartSelect();    ///EnumStartSelect return하는 것을 받아야 함.  

                switch (selectCheck)
                {
                    case EnumStartSelect.SelectTown:
                        Town(newPlayer);
                        break;
                    case EnumStartSelect.SelectBattleField:
                        Battle();
                        break;
                }
            }


        }
    }
}
