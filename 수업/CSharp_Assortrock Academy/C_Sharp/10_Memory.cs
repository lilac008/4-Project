using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//  Process 

// code		    data		heap

// thread1		thread2		thread3
// stack         stack		stack


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// heap   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




class Player10                                           ///설계도 본체 (객체 생성 전) : code 
{
    public int AP = 10;
    public int HP = 100;

    public void Damage(int _Dmg)                       
    {
        _Dmg = 1000;

    }
}





namespace C_Sharp
{

    internal class _10_Memory
    {




        static void Main(string[] args)                 ///주실행함수(main함수 내의 지역변수는 main함수 내에서만 사용가능) : stack
        {

            Console.WriteLine("안녕하세요");            ///WriteLine()함수 : stack (에 위치해있다가 "안녕하세요" 출력 즉시 사라짐) 

            int a = 0;                                  ///local변수, value형 : stack

            Player10 newPlayer = new Player10();        ///reference로 크기, 값을 본체에서 빌려오기 전까지 미정 : stack 

            newPlayer.Damage(100);                      ///객체로 복사된 내부함수, 내부 지역 변수 : stack (에 있다가 출력 즉시 사라짐) 



        }///주실행함수가 끝나면 모든 메모리가 사라진다. (프로그램 종료)
    }
}
