using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



///code (상수형, 수정이 불가능함, 함수 그 자체가 수정이 불가)
///data 
///hip			
///stack (메모리 차지 후 사라짐) 



class Player                               
{
    public int AP = 10;                    
    public int HP = 100;

    public void Attack(Monster _Monster)   
    {
        //HP -= _Monster.AP;
        
    }
}

class Monster
{
    public int AP = 10;
    public int HP = 100;

    public void Attack(Player _Player) 
    {
        _Player.HP -= AP;
    }


    /// 
    public void Test(int _Test) 
    {
        _Test = 1000;
    }
}




namespace C_Sharp
{
    internal class Class12
    {
        /// value 형     : 값이 담김    
        /// reference 형 : 위치 주소값이 담김, new Class명();하면 객체들으 본체는 hip에 위치하고, 객체들은 

        ///code  :  상수형, 수정이 불가능함, 함수 그 자체가 수정이 불가
        ///data 
        ///hip   :  new Class명();해서 만들어진 객체들의 본체는 hip에 위치	
        ///stack :  함수 안에 들어있는 지역변수 (메모리 영역을 차지 후 사라짐) 




        static void Main(string[] args)
        {
                                                 ///new Monster();   :  본체는 hip에 위치
            Monster newMonster = new Monster();  ///newMonster       :  객체는 stack에 위치

            Player newPlayer = new Player();      


            newMonster.Attack(newPlayer);        ///class가 객체화되면 Reference형이 된다.

            ///
            int value = 0;
            newMonster.Test(value);






        }
    }
}
