using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// 30 - interface : 멤버변수는 구현할 수 없고(실체가 없다 = new로 사용불가/여러명에게 상속 가능), 함수의 형식을 상속받는 자식함수에게 강제 
interface IQuestUnit
{
    /// int variable = 0;                     ///1 interface 내에서 멤버변수 불가 

    void Talk(IQuestUnit _QuestUnit);         ///2 자식에게 interface 내의 함수 구현을 강제함
    void Event(IQuestUnit _QuestUnit);     
}

class FightUnit
{
    int AP;  
    int DMG;

    public void Damage() { }
}


class Player30 : FightUnit, IQuestUnit
{
    public void Talk(IQuestUnit _QuestUnit) 
    {        
    }

    public void Event(IQuestUnit _QuestUnit) 
    { 
    }
}

class NPC30 : FightUnit, IQuestUnit
{
    public void Talk(IQuestUnit _QuestUnit)
    {
    }

    public void Event(IQuestUnit _QuestUnit)
    {
    }
} 



namespace C_Sharp
{
    internal class _30_Interface
    {
        static void Main(string[] args)
        {
            Player30 newPlayer = new Player30();
            NPC30 newNPC = new NPC30();

            newPlayer.Talk(newNPC);
            newNPC.Talk(newPlayer);

            


        }

    }
}
