using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


///Ctrl + space : 자동완성



///24강 - Property : get(읽기), set(쓰기) 문법이 따로 있는 것이 아니라 워낙 많이 사용해서 유명해진 것 
class Player24 
{
    int AP = 10;

    int m_StaticValue = 100;

    public static int StaticValue 
    {
        get 
        {
            int a = 0;
            return m_StaticValue; 
        }
        set 
        {
            ///int a = value; 
            m_StaticValue = value; 
        }
    }



    // 방법2
    public int ProAP                                            ///int와 관련된 함수
    { 
        get                                                     ///get() 함수는 무조건 자료형을 return한다고 봄
        {
            if (999 < AP)                                       ///비정상적인 공격력이 입력될 경우, 멈춰버리도록 코드 작성
            {
                Console.WriteLine("최대 수정치를 넘겼습니다.");
            }
            return AP; 
        }
        set                                                     ///set() 무조건 자료형 하나가 들어온다고 생각 
        { 
            AP = value; 
        }
    }


    //방법1
    public void GetAP()             
    {
        if (999 < AP)                             ///비정상적인 공격력이 입력될 경우, 멈춰버리도록 코드 작성
        {
            Console.WriteLine("최대 수정치를 넘겼습니다.");
            while (true) { Console.ReadKey(); }
        }

        return AP;
    }

    public void SetAP(int _value)                 ///비정상적인 공격력이 입력될 경우, 멈춰버리도록 코드 작성
    {
        if (999 < _value) 
        {
            Console.WriteLine("최대 수정치를 넘겼습니다.");
            while (true) { Console.ReadKey(); }
        }

        AP = _value;
    }
}



namespace C_sharp_2
{
    internal class Class24
    {
        static void Main(string[] args)
        {
            Player24 newPlayer = new Player24();

            
            newPlayer.SetAP(999999);            ///공격력 입력 초과

            newPlayer.ProAP = 100;
            int PlayerAP = newPlayer.ProAP = 100;

        }


    }
}
