using System.Collections;
using System.Collections.Generic;
using UnityEngine;



/// 다음 색상과 문자를 기억하시고 정답을 고르세요.
/// 
/// 
/// 
/// 빛의 구체 7가지 
/// 문자열 4가지 
/// 선택옵션1(무조건 정답),  선택옵션2(무조건 오답)





class QuizOption()    ///문제단위
{
    int color;
    int letter;

    public QuizOption()                                   ///생성자 : 객체생성시 딱 한번 호출(변수 초기화)
    {
        Random random = new Random();                     ///랜덤함수 객체생성
        this.color = random.Range(1,7);                   ///구체 1~7
        this.letter = random.Range(1,4);                  ///문자열 A,B,C,D
        ///string[] abc = { "안녕하세요", "감사합니다" };
        ///abc[letter]
    }

    public bool IsEqual(QuizOption _quizOption)               ///비교함수
    {
        if (this.color == _quizOption.color   &&   this.letter == _quizOption.letter)
            return true;
        
        return false;
    }

    public void Init(int _int1, int _int2)               ///초기화함수(초기값 변경)
    {
        this.color = _int1;
        this.letter = _int2;
    }



    ////////////////////////////////////////////////////////////////
    QuizOption right = "정답";
    do
    {
        QuizOption wrong = random(); //랜덤에서 정답과 같지않은 숫자가 나올때까지 무한반복
    }
    while(right == wrong)

    bool answer = random(1, 2) == 1;

    if (answer)
    {
        option1 = right;
        option2 = wrong;
    }
    else
    {
        option1 = wrong;
        option2 = right; 
    }


}


class Quiz  ///문제풀이
{
    public void Play()
    {
        QuizOption rightAnswer = new QuizOption();        /// 퀴즈 정답지
        QuizOption option1 = new QuizOption();            /// 퀴즈 선택옵션1             
        QuizOption option2;                               /// 퀴즈 선택옵션2 : 선택옵션1이 정답인경우, 선택옵션2를 오답으로

        if (option1.IsEqual(rightAnswer))                 ///1-1. 선택옵션1이 정답지와 일치한다면
        {
            while (1)                                     
            {
                option2 = new QuizOption();               /// (선택옵션2 처음은 무조건 생성, 무한루프마다 새로 생성)
                if (!option1.IsEqual(option2))            ///1-2. 선택옵션1이 선택옵션2와 동일하지 않으면
                    return;                               ///1-3. while을 그만두고 싶으면 break, play를 그만두고 싶으면 return
            }
        }
        else                                              ///2-1. (선택옵션1이 정답지와 일치하지 않으면) 선택옵션2를 정답으로
            option2 = rightAnswer;

        

        /// 선택옵션 창
        Console.WriteLine("선택하세요.");
        Console.WriteLine("1번:" + option1.color * option1.letter);
        Console.WriteLine("2번:" + option2.color * option2.letter);                                                           		


        QuizOption choiceQuiz = new QuizOption();         ///노인의 선택
        int color = input.nextInt();                      ///입력객체 -> C#에 맞게 수정해야함
        int letter = input.nextInt();                     ///입력객체 -> C#에 맞게 수정해야함              
        choiceQuiz.Init(color, letter);                   ///노인의 선택지 초기값 수정


        if (rightAnswer.IsEqual(choiceQuiz))
            Console.WriteLine("정답입니다."); 
        else
            Console.WriteLine("오답입니다.");
    }

}




class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();                     ///Class Quiz 객체 생성 후 Play함수 호출하면 퀴즈 시작
        quiz.Play();                                ///퀴즈 실행
    }
}
