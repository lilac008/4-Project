using System;                       
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


// code  (실행 중 유지)  :  상수, 코드들, class 선언 그 자체, method 선언 그 자체  (수정불가, 한번 실행시 멤버변수 추가 x)  
// data  (실행 중 유지)  :  정적
// hip   (계속 변화)     :  동적
// stack (계속 변화)     :  지역변수와 실행될 함수 영역



class Player10
{

    int HP = 100;
    int AP = 10;

    public void Damage(int _Dmg)
    {
        
    }



}



namespace C_Sharp                   
{

    internal class Class10
    {



        static void Main(string[] args)             ///실행함수 : stack 영역
        {

            Player10 newPlayer = new Player10();

            newPlayer.Damage(10);                  ///인스턴스 매개함수 : stack 영역

        }









    }
}
