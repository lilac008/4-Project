using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// enum : 

class Inven35 
{
    private int SelectIndex = 0;


    public class InvenSlot
    {
        int Index;

        public void Select(Inven35 _inven) 
        {
            _inven.SelectIndex = 100;   ///1-2 ?
            /// SelectIndex = 100;      ///1-1 class 내부에 있어도 private 선언된 변수를 마음대로 쓸 수 없다.
        
        }
    }

    public enum InvenDirection    ///클래스 지역 내부에서만 사용할경우 독립적 사용 (이름겹침x, 책임 적어짐)
    {
        Left,
        Right,
        Up,
        Down
    }

    public void InnerClassTest() 
    {
        InvenSlot newInvenSlot = new InvenSlot();

        newInvenSlot.Select(this);
    }



}



class Player35 
{
    public enum PlayerJob       ///클래스 지역 내부
    {
        Novice,
        Knight,
        Fighter,
        Berserker,
        Firemage,
    }
}




namespace C_Sharp
{
    internal class _34_Enum
    {
        static void Main(string[] args)
        {
            Player35 newPlayer = new Player35();
            Player35.PlayerJob job = Player35.PlayerJob.Novice;


            Inven35 newInven = new Inven35();
            Inven35.InvenDirection invenDirection = Inven35.InvenDirection.Left;


            newInven.InnerClassTest();
        }
    }
}
