using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



/// Generic : 어떤 자료형의 값이 들어오든 처리해내기 위해 일반적인 자료형으로 대신함
///            1.T는 Type, E는 Element, K는 Key, V는 Value, N은 Number




public static class GenericTest       /// static : static 변수/함수만을 내부에
{
    ///public GTest()              ///static : 생성자를 만들 수 없다.
    ///{   }


    ///1 자료형마다 함수를 매번 만드는 것을 방지하기 위해 
    public static void ConsolePrint(int _int) 
    {
        Console.WriteLine(_int);
    }

    public static void ConsolePrint(string _string)
    {
        Console.WriteLine(_string);
    }

    ///2 Generic : 어떤 유형의 값이 들어오든 처리해내는 함수
    public static T ConsolePrint<T>(T _T) 
    {
        Console.WriteLine(_T);

        return _T; 
    }

    public static T ConsolePrint<T, U>(T _T, U _U)
    {
        Console.WriteLine(_T);
        Console.WriteLine(_U);

        return _T;
    }
}

//36강 15분, inventory만든 후에 확인할것
/// Generic : class를 generic으로 가져올 때 
class CashItem 
{

}

class GameItem 
{
    
}

class Inven<T> 
{
    T[] arrInvenItem;

    public void ItemIn(T _T) 
    {
        
    }

    Inven<GameItem> newGameItemInven = new Inven<GameItem >();
}



namespace C_Sharp
{
    internal class _36_Genericcs
    {
        static void Main(string[] args)
        {
            GenericTest.ConsolePrint(1000);

            ///Generic 지정 이후 : ConsolePrint에 커서두기
            GenericTest.ConsolePrint(1.3213123f);
            GenericTest.ConsolePrint("안녕하세요");
            GenericTest.ConsolePrint("안녕", 'A');

            GenericTest.ConsolePrint<int>(1000);
            GenericTest.ConsolePrint<string, char>("안녕", 'A');
        }
    }
}
