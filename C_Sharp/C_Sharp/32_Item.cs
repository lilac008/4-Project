using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Item32
{
    string name;
    int gold;


    public string Name              ///return값에 맞는 자료형
    {
        get
        {
            return name;
        }
        set
        {
            name = value;
        }
    }


    public int Gold                 ///return값에 맞는 자료형
    {
        get
        {
            return gold;
        }
        set
        {
            gold = value;
        }
    }

    public Item(string _Name, int _Gold) 
    {
        Name = _Name;
        
    }

}




namespace C_Sharp
{
    internal class _32_Item
    {
    }
}
