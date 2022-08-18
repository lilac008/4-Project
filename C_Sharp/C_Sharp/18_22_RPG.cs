using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;





/// 20 의문, 22화 19분보다 말음


/// break는 switch문을 벗어나고, return은 전체조건문 자체를 벗어난다.








class FightUnit18   ///class 상속은 C#에서 1개만 가능하다
{
    protected string Name = "None";
    protected int HP = 50;
    protected int MaxHP = 100;
    protected int AP = 10;

    public void StatusRender()
    {
        Console.WriteLine("의 능력치-----------------");
        Console.Write("공격력 : ");
        Console.WriteLine(AP);
        Console.Write("체력 : ");
        Console.Write(HP);
        Console.Write("/");
        Console.WriteLine(MaxHP);
        Console.WriteLine("-----------------");
    }

    public void SetName(string _name)
    {
        Name = _name;
    }

    public bool IsDeath() 
    {
        bool boolDeath = HP <= 0;
        ///return boolDeath;
        return HP <= 0;                                              ///연산자에도 함수처럼 return값이 있다.
    }

    void Damage(FightUnit18, _fightUnit)
    {
        Console.Write(Name);
        Console.Write("가");
        Console.Write(_fightUnit.AP);
        Console.Write("의 데미지를 입었습니다.");
        Console.ReadKey();
        HP -= _fightUnit.AP;
    }
}



class Player18 : FightUnit18                                              //3
{


    public void /* int */ MaxHeal(/*Player this*/)                      //3-2            
    {
        ///int HP; 가 있을 경우 어떤 HP를 가르키는지 모르므로 this(player18 script의 HP)로 구분한다.
        
        if (HP >= MaxHP)
        {
            Console.WriteLine("");
            Console.WriteLine("체력이 모두 회복되어있어서 회복할 필요가 없습니다");
            Console.ReadKey();
        }
        else 
        {
            this.HP = MaxHP;                    
            PrintHP();
            ///return HP;                          //함수 외부로 HP를 return할 경우엔 함수에 int 추가
            return;
        }
    }
    public int PrintHP()                                                 //3-3
    {
        Console.WriteLine("");
        Console.Write("현재 플레이어의 HP는");
        Console.Write(HP);
        Console.WriteLine("입니다.");
        Console.ReadKey();                  
    }




    public Player18()                               ///생성자
    {
        Name = "플레이어";
    }
}

class Monster18 : FightUnit18
{

    public Monster18(string _name)                               ///생성자
    {
        Name = _name;
        ///Name = "몬스터";
    }
}

enum EnumStartSelect                                                     //1
{
    Town,
    BattleField,
    NoneSelect                                                           ///error나 잘못된 선택지를 눌렀을 때
}


namespace C_sharp_2
{
    internal class _18_22_RPG
    {

        static EnumStartSelect StartSelect()                            //1
        {
            Console.Clear();                                            ///반복시 기존 출력화면 지움
            Console.WriteLine("");
            Console.WriteLine("1. 마을");
            Console.WriteLine("2. 싸움 지역");
            Console.WriteLine("어디로 가시겠습니까?");

            ConsoleKeyInfo consoleKey = Console.ReadKey();              
            Console.WriteLine("");
            switch (consoleKey.Key)                                    ///키 입력할 경우(대기하는 동안 while무한반복 막음) 나눠서 선택 
            {
                case ConsoleKey.D1:
                    Console.WriteLine("마을로 이동합니다");
                    Console.ReadKey();                                  ///Console.Clear()로 지워지므로 입력키를 누를 때까지 기다리도록
                    return EnumStartSelect.Town;
                case ConsoleKey.D2:
                    Console.WriteLine("싸움 지역으로 이동합니다");
                    Console.ReadKey();
                    return EnumStartSelect.BattleField;
                default:
                    Console.WriteLine("잘못된 선택입니다.");
                    Console.ReadKey();
                    return EnumStartSelect.NoneSelect;
            }
            return EnumStartSelect.Town;                          ///return시 반환되고 종료되므로 아래에 얼마나 있든 실행되지 않는다 
            return EnumStartSelect.BattleField;
        }


        static void Town(Player18 _Player)                               //2, 3
        {
            while (true)
            {
                Console.Clear();                                         ///반복시 기존 출력화면 지움
                _Player.StatusRender();
                Console.WriteLine("마을에서 무슨 일을 하시겠습니까?");
                Console.WriteLine("1.(여관에서) 체력 회복");
                Console.WriteLine("2.(대장간에서) 무기 강화");
                Console.WriteLine("3.마을을 나간다");

                /// ConsoleKeyInfo consoleKey = Console.ReadKey();       //방법1 switch (consoleKey.Key) { }
                /// ConsoleKey consoleKey = Console.ReadKey().Key;       //방법2 switch (consoleKey) { }
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.D1:
                        //if (hp가 풀이 아닐경우)
                        //{
                            _Player .MaxHeal();                           //3-2
                        //}
                        //else { 경고! hp가 가득찼습니다. }
                        break;                                            ///break는 switch문을 벗어난다.
                    case ConsoleKey.D2:
                        break;
                    case ConsoleKey.D3:
                        return;                                           ///return은 while문을 벗어난다. 
                }
                Console.ReadKey();
            }
        }   

        static void Battle(Player18 _Player)                              //2, 4
        {
            Monster18 newMonster = new Monster18("오크");
            ///Player18 newPlayer = new Player18();

            while (true == newMonster.IsDeath() || _Player.IsDeath() )   
            {
                Console.Clear();
                _Player.StatusRender();
                newMonster.StatusRender();
                Console.ReadKey();
            }
            Console.WriteLine("싸움이 결판났습니다.");
            Console.ReadKey();
        }

        





        static void Main(string[] args)                                    ///메인함수 내의 지역변수는 메인함수 내에서만 사용가능
        {
            Player18 newPlayer = new Player18();                           //3 

            while (true)                                                   //1
            {
                ///StartSelect();    
                
                EnumStartSelect select = StartSelect();                    ///StartSelect()에서 return하는 것을 받아야 함.  
                switch (select)
                {
                    case EnumStartSelect.Town:
                        Town(newPlayer);
                        break;                                              
                    case EnumStartSelect.BattleField:
                        Battle();
                        break;
                }
            }


        }
    }
}
