using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


//struct, enum, property, (overriding), 생성자-배열, 


namespace C_Sharp
{
    internal class Class30
    {

        interface QuestNPC 
        {
            
        }

        class Item 
        {
            string Name;
            int AP;
            int DF;
        }

        static void Main(string[] args)
        {
            ///     기본 자료형[]      int[] 변수 = new float[]
            ///사용자정의 자료형[]     ClassName[] 변수 = new float[]

            new Item();     ///아이템 생성
            new Item[100]   ///아이템 100개를 담을 수 있는 공간 생성


            Item[] arrItem = new Item[10];              ///공간생성
            
            for (int i = 0; i < arrItem.Length - 1; i++)
            {
                arrItem[i] = new Item();                ///item 생성
            }

        }

    }
}
