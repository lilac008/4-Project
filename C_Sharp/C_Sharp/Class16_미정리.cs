using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




///정리 안했음
namespace C_sharp_2
{
    internal class Class16_미정리
    {
        static void Main(string[] args)         ///주실행함수 안에서만 조건문을 사용할 수 있다.
        {
            ///for ( 초기화문; 조건문; 증감문  ){}

            /// 초기화문 - (조건문 - 코드실행 - 증감문) - (조건문 - 코드실행 - 증감문) - 반복 
            for (int i = 0; i < 100; i++) 
            { Console.WriteLine(i); }


            // 이 부분은 한번 더 보기
            // ctrl + rr :  참조되는 모든 변수 변경 가능
            int test = 0;
            if (test == 100) 
            { }
            if (test == 10) 
            { }

            if (test == 100) 
            { }
            else if(test == 10) 
            { }


            // sw + tab 2번
            int aa = 1;
            switch (aa)
            {
                case 0:         ///상수만 가능하며 변수 aa를 넣을 수 없다.
                    break;
                case 1:
                    break;
                default:       ///else의 역할
                    break;
            }

        }



    }
}
