using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






///17 - Structure(구조체) : 1. class와 유사하지만 literal에서 초기화 불가, constructor(생성자)에서만 초기화 가능 
///                         2. value형


struct Struct17
{
    public int a;
    public int b;
    ///public int a = 0;                                  //1 structure는 literal에서 초기화 불가능 (= 0이 기본값) 

    public void Struct17_()                             ///1 structure는 constructor(생성자)에서만 초기화 가능
    {
        a = 100;
        b = 100;
    }
}


class Player17 
{
    
}


namespace C_sharp_2
{
    internal class _17_1_Structure
    {

        static void Test(Struct17 _sturuct17)          ///stack
        {
            _sturuct17.a = 300;
        }

        static void Test(int _int)                    ///stack 
        {
            _int = 400;
        }


        static void Main(string[] args)
        {
            int variable = 100;                           ///2-1 일반 변수 : value형(저장된 값 그대로)  : stack 
            Test(variable);                               
            Console.WriteLine(variable);                  ///value형 

            Player17 newPlayer = new Player17();          ///2-2 new 인스턴스 변수 : reference형(본체의 위치를 가르키며 객체가 사라져도 본체는 남음) : 본체는 hip, 인스턴스 객체는 stack 


            Struct17 newStruct = new Struct17();          ///2-3 구조체 변수 : value형(저장된 값 그대로) 
            newStruct.a = 200;
            newStruct.b = 200;
            Test(newStruct);                              
            Console.WriteLine(newStruct);                 ///value형  



        }
    }
}
