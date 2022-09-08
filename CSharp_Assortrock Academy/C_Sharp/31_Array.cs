using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







///30 - Array(배열) :   - 일반 자료형       :  int[] variable = new int[]
///                     - 사용자정의 자료형 :  ClassName[] variable = new ClassName[]

namespace C_Sharp
{

    internal class _31_Array
    {

        class Item 
        {
            public string name;
            public int AP;
            public int DF;
        }



        static void Main(string[] args)
        {
            ///int형(일반자료형) 배열 : 10개의 공간생성
            int[] intArray = new int[10];

            for (int i = 0; i < intArray.Length - 1; i++)
            {
                Console.WriteLine(intArray[i]);
            }



            ///class형(사용자정의자료형) 배열 : 10개의 공간 생성
            Item[] ArrayItem = new Item[10];                            ///담을 수 있는 10개의 공간만 생성

            for (int i = 0; i < ArrayItem.Length - 1; i++)
            {
                ArrayItem[i] = new Item();                             /// 공간 배열에 아이템 생성
            }
            /// Item Item = new Item();                                  //아이템 생성 (설계도 상으로 미구현된 Item class를 instance로 생성)


            ArrayItem[0].name = "녹슨검";
            ArrayItem[1].name = "철검";
            ArrayItem[2].name = "녹슨갑옷";
            ArrayItem[3].name = "멋진갑옷";
            ArrayItem[4].name = "포션";

            for (int i = 0; i < ArrayItem.Length; i++)
            {
                Console.WriteLine(ArrayItem[i].name);                              /// 공간 배열에 아이템 생성
            }

        }



    }
}
