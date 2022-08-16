using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// 기본자료형        : 이미 있는 자료형
/// 사용자정의 자료형 :

enum EItemType    ///열겨헝
{
    Equip,
    Potion,
    QuestItem,
    NoneSelect
}

///1-1 아래와 같이 일일이하면 너무 많아진다
class EquipItem 
{ }
class PotionItem 
{ }
class BookIem 
{ }


///1-2 대신,
class Item
{
    public EItemType itemType = EItemType.NoneSelect;

    public void PotionTypeSetting() 
    {
        itemType = EItemType.Potion;
    }

}



namespace C_sharp_2
{
    internal class Class17_3
    {
        static void Main(string[] args)
        {
            Item newItem = new Item();
            newItem.itemType = EItemType.Potion;
            newItem.PotionTypeSetting();

            //enum 값형

            Console.WriteLine(EItemType.Potion);
            EItemType Type = EItemType.Potion;

            switch (Type)
            {
                case EItemType.Equip:
                    break;
                case EItemType.Potion:
                    break;
                case EItemType.QuestItem:
                    break;
                default:
                    break;

            }



        }




    }
}
