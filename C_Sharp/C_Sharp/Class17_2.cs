using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//17화 기준


// code  (실행 중 유지)  :  상수, 코드들  
// data  (실행 중 유지)  :  정적
// hip   (계속 변화)     :  동적
// stack (계속 변화)     :  지역변수와 실행될 함수 영역


void Player()   // 본체는 hip 영역
{
    
}





namespace C_sharp_2
{
    internal class Class17_2
    {
        void Func()                             //stack 영역 
        { 
        }

        static void Main(string[] args)         // stack 영역
        {
            Player newPlayer1 = new Player();
            Player newPlayer2 = new Player();
            Player newPlayer3 = new Player();



        }
    }
}
