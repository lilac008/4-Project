using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;






///24강 - Property : get(읽기), set(쓰기) 문법이 따로 있는 것이 아니라 워낙 많이 사용해서 유명해진 것 
class Player24 
{
    public int HP = 20;
    int AP = 10;
    int staticValue = 100;


    /// Static + Property
    public static int StaticProperty
    {
        get 
        {
            return staticValue; 
        }
        set 
        {
            staticValue = value; 
        }
    }





    /// 방법2 (축약형)
    public int Property24                                       ///return값의 자료형과 일치해야 함
    {
        get                                                     ///get()은 무조건 자료형을 return
        {
            if (999 < AP)                                       
            {  Console.WriteLine("최대 수정치를 넘겼습니다.");  }
            return AP; 
        }
        set                                                     ///set()은 무조건 자료형 하나가 들어오는데 property에서는 value라고 기호로 정의해놓음 
        { 
            AP = value; 
        }
    }


    ///방법1
    public int Get24()                                           ///return값의 자료형과 일치해야 함
    {
        if (999 < AP)                            
        {
            Console.WriteLine("최대 수정치를 넘겼습니다.");
            while (true) { Console.ReadKey(); }                  ///멈춤, error 알려줄 용도
        }
        return AP;                                              
    }
    public void Set24(int _value)                 
    {
        if (999 < _value)                                        
        {
            Console.WriteLine("최대 수정치를 넘겼습니다.");
            while (true) { Console.ReadKey(); }                  ///멈춤, error 알려줄 용도

            AP = _value;                                         ///공격력 수정
        }

    }
}



namespace C_sharp_2
{
    internal class _24_Property
    {
        static void Main(string[] args)
        {
            Player24 newPlayer = new Player24();

            newPlayer.Set24(999999);                             ///공격력 입력 초과



            ///방법2 
            ///newPlayer.methodName(); 와 달리 property에서는 아래와 같은 형식으로 나타난다.
            newPlayer.Property24 = 100;                             
            ///int PlayerAP = newPlayer.Property24;



            ///방법3
            Player24.staticValue = 200;
            newPlayer.HP = 80;


        }


    }
}
