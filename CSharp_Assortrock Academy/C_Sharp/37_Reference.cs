using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 





class Player
{
    public int HP = 100;
    public int AP = 10;

    public bool IsDeath() 
    {
        Console.WriteLine("이 함수는 플레이어가 죽었는지 살았는지 체크하는 함수이며, 플레이어의 HP가 0보다 작으면 죽습니다.");
        return HP <= 0;
    }
}



namespace C_Sharp
{


    internal class _37_Reference
    {
        static int Number = 100;

        static void PlayerTest(Player _player) 
        {
            _player.AP = 1000;
        }

        static void ArrTest(int[] _int) ///배열형
        {
            _int[0] = 999;
        }

        static void ClassTest(Player _player) 
        {
            _player.AP = 1000;
        }


        /*
        static void AtTest(Player _player)
        {
            Console.WriteLine("공격력을 테스트 해볼까요?");
            Console.WriteLine("그냥 해보는 겁니다");
            _player.AP = 1000;
        }
        */

        public void TestFunc(Player _player) { }


        static void Main(string[] args)
        {


            Player newPlayer = new Player();
            newPlayer.AP = 50;              ///1-1

            newPlayer = new Player();       ///1-2 : 1-1과 1-2의 인스턴스 변수는 서로 다른 Player


            PlayerTest(newPlayer);         ///reference형, 10000이 되어 나온다.




            ///배열 생성 및 초기화
            int[] newIntArr = new int[10] { 0,1,2,3,4,5,6,7,8,9 };
            ArrTest(newIntArr); /// { 999,1,2,3,4,5,6,7,8,9 } -> Reference형




            //ArrTest(null);

            Player newPlayer2 = null;

            //37화 - 19분
            newPlayer2.IsDeath();

        }
    }
}
