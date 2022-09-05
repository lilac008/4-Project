using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Quiz()    ///문제단위
{
    int color;
    int letter;

    public Quiz()                                       ///생성자 : 객체생성시 딱 한번 호출(변수 초기화)
    {
        Random random = new Random();                   ///랜덤함수 객체생성
        this.color = random.Range(1,7);                 ///구체 1~7
        this.letter = random.Range(1,4);                ///문자열 A,B,C,D
    }

    public bool IsEqual(Quiz _choice)                   ///비교함수
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

    public void Init(int color, int letter)             ///초기화함수(값 변경)
    {
        this.color = color;
        this.letter = letter;
    }

}


class QuizOption  ///문제풀이
{
    public void Play()
    {
        Quiz quiz = new Quiz();                           /// 퀴즈 문제 생성
        Quiz choice1 = new Quiz();                        /// 선택1을 정답, 선택2를 오답
        Quiz choice2;

        if (choice1.IsEqual(quiz))                   
        {
            while (1)                                     /// 선택2가 선택1과 동일하게 생성되지 않게 무한루프
            {
                choice2 = new Quiz();                     /// 한번은 무조건 생성 + 무한루프마다 새롭게 생성
                if (!choice1.IsEqual(choice2))
                    return;                               /// 선택1과 선택2 비교후 다르다면 무한루프 끝
            }
        }
        else                                              ///선택1이 정답으로 생성되지 않은 경우, 선택2를 정답으로 만들어준다.
            choice2 = quiz;

        /// 선택창 출력
        Console.WriteLine("과 관련된 것을 고르세요.");
        Console.WriteLine("1번:" + choice1.color * choice1.letter);
        Console.WriteLine("2번:" + choice2.color * choice2.letter);                                                           		


        Quiz quiz2 = new Quiz();                        /// 선택한 퀴즈단위
        Scanner input = new Scanner();                  /// 자바의 입력객체, 한줄 입력은 readLine() 한키 입력은 nextInt()로 입력받음.
        int color = input.nextInt();
        int letter = input.nextInt();               
        quiz2.Init(color, letter);                      /// 퀴즈값 수정완료


        if (quiz.IsEqual(quiz2))
            Console.WriteLine("정답입니다."); 
        else
            Console.WriteLine("오답입니다.");
    }

}


class Main
{
    public static void main()
    {
        QuizOption quizOption = new QuizOption();          ///Class Quiz 객체 생성 후 Play함수 호출하면 퀴즈 시작
        quizOption.Play();                                 ///퀴즈 실행
    }
}
