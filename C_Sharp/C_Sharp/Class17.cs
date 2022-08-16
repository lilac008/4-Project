using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



//ctrl + shift + U : 대문자






namespace C_sharp_2
{

    struct Struct1
    {
        ///int a = 0;            //구조체는 literal 초기화가 안 된다. =0이 기본 값이라고 생각하면 편하다.
        public int a;
        public int b;

        public void Func()
        {
            a = 100;
            b = 100;

        }

    }







    internal class Class17
    {
        void Player() { }




        static void Test(Struct1 _var1) //1-1 값형
        {
            _var1.a = 100;
            
        }

        static void TestNumber(int _var2) //1-2 값형:직접데이터 보관, _v ar2 자체는 바뀌지 않는다.
        {
            _var2 = 100;

        }



        static void Main(string[] args)
        {
            int Number = 100;                   ///값형, stack에서 사라지면 전부 사라진다.
            Player13 newPlayer = new Player13();    ///참조형(위치만 저장하고 있다가 필요할때 위치에 가서 데이터값를 얻어오는 자료형), stack영역에서 인스턴스는 사라져도 hip영역의 본체는 남아있다.
            
            
            Struct1 newStruct1 = new Struct1(); 

            newStruct1.a = 10;
            newStruct1.b = 10;

            Test(newStruct1);          //1-1 값형 : 구조체는 함수에 들어가도 값이 변하지 않음

            TestNumber(){ }


        }
    }
}
