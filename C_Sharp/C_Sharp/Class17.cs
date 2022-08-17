using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



///ctrl + shift + U : 대문자


///17 - Structure(구조체) : class와 유사하지만 constructor(생성자)에서만 초기화 가능, 
struct Struct17
{
    public int a;
    public int b;
    ///public int a = 0;              //structure는 literal에서 초기화 불가능 (= 0이 기본값) 

    public void Func()               ///structure는 constructor(생성자)에서만 초기화 가능
    {
        a = 100;
        b = 100;
    }
}


namespace C_sharp_2
{

    internal class Class17
    {

        static void Test(Struct17 _sturuct17)          ///stack
        {
            _sturuct17.a = 9999;
        }

        static void Test2(int _int)                   ///stack
        {
            _int = 100;
        }



        static void Main(string[] args)
        {
            int variable = 100;                        ///1 value형                : stack 
            
            Player13 newPlayer = new Player13();       ///2 reference형            : 본체는 hip, instance 객체는 stack 

            Struct17 newStruct1 = new Struct17();      ///3 structure(구조체)


            newStruct1.a = 10;
            newStruct1.b = 10;
            Test(newStruct1);                          ///value형 : 저장된 값 그대로 바뀌지 않음


            int variable2 = 100;                       
            Test2(variable2);                          ///value형 : 저장된 값 그대로 바뀌지 않음


        }
    }
}
