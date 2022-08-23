using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// code  (실행 중 유지, 수정x) :  text 영역 (상수, code들, method, class 그 자체)  / class
/// data  (실행 중 유지)        :  global 변수, static 변수 
/// hip   (계속 변화)           :  동적(dynamic), reference형                       /  new ClassName()의 본체
/// stack (계속 변화, 휘발성)   :  local 변수, parameter(매개변수), value형         /  new ClassName()의 instance 객체 




///11강 - Value형
class Player11                             
{
    public int HP = 100;
    public int AP = 10;                      

    public void Test(int _Dmg)                          ///1-2          
    {
        _Dmg = 1000;

    }

    public int Test2(int _Dmg)                          ///2-2          
    {
        _Dmg = 1000;

        return _Dmg;
    }
}


namespace C_Sharp
{
    internal class _11_Value
    {



        static void Main(string[] args)                
        {
            int value = 0;                              ///value형 : stack

            Player11 newPlayer = new Player11();        ///reference (크기, 값을 본체에서 빌려오기 전까지 미정) : stack 



            newPlayer.Test(value);                      ///1-1 value에 저장된 건 그대로고 _Dmg에 값만 넘긴다.  : stack


            ///value = newPlayer.Test2(value);             ///2-2   



        }

    }
}
