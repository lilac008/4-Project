using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;







///17 - enum : 호출시 코드 가독성 떨어지는 것 방지하기 위해 목록으로 지정 및 호출

/// 자료형 - 기본형       (이미 정의됨) : int, float 등   
///          사용자정의형 (재정의 가능) : 1) class      (reference형)
///                                       2) struct     (value형) 
///                                       3) enum       (value형,  ex) ConsoleKey도 enum으로 지정되어 있다)
///                                       4) interface  



///아래와 같이 일일이 script를 만들면 너무 많아진다
class EquipItem               
{ }
class PotionItem 
{ }
class QuestItem 
{ }

class Item1 
{
    ///주실행함수에서 Item1(1,2); 호출시, item1()에 들어가 1번 아이템을 2개 호출하라는 뜻으로 가독성이 떨어진다.
    
}


///대신, 
enum EnumItemType
{
    EQUIP,
    POTION,
    QUEST,
    NONESELECT
}

class Item
{
    public EnumItemType itemType = EnumItemType.NONESELECT;     ///itemType 초기값으로 타입미지정일 경우를 저장

    public void PotionType() 
    {
        itemType = EnumItemType.POTION;
    }
}



namespace C_sharp_2
{
    internal class _17_2_Structure
    {

        static void Main(string[] args)
        {
            Item newItem = new Item();

            ///방법1 : 인스턴스 변수에 값 저장
            newItem.itemType = EnumItemType.POTION;      

            ///방법2 : 인스턴스 함수를 호출해 값 저장
            newItem.PotionType();                           

            ///방법3 : 클래스 변수에 값 저장
            EnumItemType Type = EnumItemType.POTION;
            switch (Type)
            {
                case EnumItemType.EQUIP:
                    break;
                case EnumItemType.POTION:
                    break;
                case EnumItemType.QUEST:
                    break;
                default:
                    break;
            }


        }




    }
}
