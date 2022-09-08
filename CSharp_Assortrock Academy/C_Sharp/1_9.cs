using System;                        //유니티에서 정의해놓은 코드를 쓰겠다.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;




namespace C_Sharp                   ///namespace : 구상한 개념이 겹칠 때 개념을 분류하는 용도
{

    internal class _1_9
    {


        /// - IDE(Integrated Development Environment) :  프로그램 제작을 도와주는 프로그램, 한줄한줄 읽는 걸 도와준다.
        /// - 한글처리가 미흡하므로 유니티 폴더도 영어로 만들어야. 
        /// - literal값 : ?



        /// Object Oriented(객체지향) : class 안의 obj를 만들고, 그 obj를 기반으로 모든 걸 해결하기 때문에 객체지향이라고 함. 단 obj를 만들기 전에 class부터 먼저 설계해야 한다.
        ///
        /// ex) 상하좌우로 움직이는 Player를 만들고 싶다 
        ///     class Player()                   => Player라는 class(설계도)를 만들어서 Player obj에 연결시켜 프로그램 실행.
        ///     { 상하좌우로 움직이는 코드 }  



        int hp;          /// 주소값 할당, 똑같은 번지에 할당할 수 없으므로 중복시 빗금으로 처리된다.
        //int hp;
        int mp = 100;    ///주소값 x번째에 4byte(int)만큼 공간을 만들고 mp라 이름짓고 100이라는 값을 채워넣어라.



        // 단축키 모음
        ///ctrl + shift + U : 대문자로 변경
        ///ctrl + rr : 동일한 키워드 동시에 변경
        ///ctrl + space : 잘못친 부분 자동 수정
        ///
        /// 
        /// 
        /// 코드 머리로 넘겨짚지 말고 디버깅 실행해서 눈으로 확인할것
        /// 내가 원하는 코드를 몇일 시간을 들여 구상하기 전에, 이미 인터넷에 널려있는 함수를 찾아서 써라.


    }
}
