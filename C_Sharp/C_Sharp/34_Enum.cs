using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Inven34 
{

    private int SelectIndex = 0;

    public void InnerClassTest() 
    {
        newInvenSlot.Select(this);
    }
    
    public class InvenSlot 
    {
        int index;

        void Select(Inven _inven) 
        {
            _inven.SelectIndex = 100;

            SelectIndex = 100;
        }
    }


    public enum EnumInvenDir 
    {
        ID_Left,
        ID_Right,
        ID_Up,
        ID_Down
    }

    void ClassChange() 
    {
    }


}



class Player34 
{

    public enum EnumPlayerJob
    {
        Novice,
        Knight,
        Fighter,
        Berserker,
        Firemage,
    }

    void ClassChange() 
    {
    }
}


namespace C_Sharp
{
    internal class _34_Enum
    {
        static void Main(string[] args)
        {
            Player34 newPlayer = new Player34();
            Inven34 newInven = new Inven34();

            Inven34.EnumInvenDir IDIR = Inven34.EnumInvenDir.ID_Left;

            
        }

    }
}
