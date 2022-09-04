using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuizUnit()    ///문제단위
{
    int color;
    int letter;

    public QuizUnit()                                   ///생성자 : 객체생성시 딱 한번 호출(변수 초기화)
    {
        Random random = new Random();                   ///랜덤함수 객체생성

        this.color = random.Range(1,7);                 ///빛의 구체 1~7
        this.letter = random.Range(1,4);                ///문자열 1~4
    }

    public void Init(int color, int letter)             ///초기화함수(값 변경)
    {
        this.color = color;
        this.letter = letter;
    }

    public bool IsEqual(QuizUnit _choice)                ///비교함수
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

}


class Quiz  ///문제풀이
{
    public void Play()
    {
        QuizUnit quizUnit = new QuizUnit();          /// 퀴즈 문제 생성.


        /*2가지 선택지 생성*/
        QuizUnit choice1 = new QuizBall();
        QuizUnit choice2;

        if (choice1.Equal(quizUnit))                           /// 선택지1이 정답으로 생성되는경우 선택지2를 오답으로 만들어줘야함.
        {
            while (1)                                          /// 선택지2가 선택지1과 동일하게 생성되지 않게 무한루프돌림.
            {
                choice2 = new QuizBall();                    /// 처음한번은 무조건 생성+무한루프 돌때마다 새롭게 생성.
                if (!choice1.Equal(choice2))
                    return;                                    /// 선택지1과 비교후 다르다면 무한루프 끝남.
            }
        }
        else                                                   /// 선택지1이 정답으로 생성되지 않은 경우
            choice2 = quizUnit;                               /// 선택지2를 정답으로 만들어준다.



        /*선택창 출력*/     
        Console.WriteLine("과 관련된 것을 고르세요.");
        Console.WriteLine("1번:" + choice1.color * choice1.letter);
        Console.WriteLine("2번:" + choice2.color * choice2.letter);                                                           		


        QuizeBall quizBall_2 = new QuizBall();      /// 선택 퀴즈볼
        Scanner input = new Scanner();              /// 자바의 입력객체, 한줄 입력은 readLine() 한키 입력은 nextInt()로 입력받음.
        int color = input.nextInt();
        int letter = input.nextInt();               /// 유니티의 입력함수에 따라 입력의 표현방식 달라짐.
        quizBall_2.Init(color, letter);             /// 퀴즈볼값 수정완료


        if (quizUnit.IsEqual(quizBall_2))
            Console.WriteLine("정답입니다."); 
        else
            Console.WriteLine("오답입니다.");

    }

}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();      ///Class Quiz 객체 생성 후 Play함수 호출하면 퀴즈 시작
        quiz.Play();                 ///퀴즈 실행

    }
}
