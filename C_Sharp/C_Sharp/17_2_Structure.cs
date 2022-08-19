﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







///17 - enum : 

/// 자료형 - 기본형 (정의됨) : int, float 등   
///          사용자정의형 (재정의 가능) :  1) class  (reference형)
///                                        2) struct (value형) 
///                                        3) enum   (value형,  ex) ConsoleKey )
///                                        4) interface



///아래와 같이 일일이 script를 만들면 너무 많아진다
class EquipItem               
{ }
class PotionItem 
{ }
class QuestItem 
{ }


///대신, 
enum EnumType
{
    EQUIP,
    POTION,
    QUEST,
    NONESELECT
}

class Item
{
    ///public ItemType IT_Equip = ItemType.EQUIP;
    /// public ItemType IT_Equip = ItemType.EQUIP;
    ///public ItemType IT_Quest = ItemType.QUEST;
    public EnumType IT_None = EnumType.NONESELECT;


    public void PotionTypeSetting() 
    {
        IT_None = EnumType.POTION;
    }

}



namespace C_sharp_2
{
    internal class _17_2_Structure
    {

        static void Main(string[] args)
        {
            Item newItem = new Item();
            newItem.IT_None = EnumType.POTION;

            newItem.PotionTypeSetting();



            Console.WriteLine(EnumType.POTION);        ///POTION이라고 출력된다.



            EnumType Type = EnumType.POTION;
            switch (Type)
            {
                case EnumType.EQUIP:
                    break;
                case EnumType.POTION:
                    break;
                case EnumType.QUEST:
                    break;
                default:
                    break;
            }
        }




    }
}