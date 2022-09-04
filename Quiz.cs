using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuizBall()
{
    int color;
    int letter;

    public QuizBall()                        //생성자 : 객체생성시 딱 한번 호출(변수 초기화를 위한 내용 작성)
    {
        Random random = new Random();        //랜덤함수 객체생성

        this.color = 1 + random.nextInt(7);  // 1+0~6 까지의 정수난수 랜덤 생성 (1~7)
        this.letter = 1 + random.nextInt(4); // 1+0~3 까지의 정수난수 랜덤 생성 (1~4)
    }

    public void Init(int color, int letter)   //값 변경을 위한 초기화
    {
        this.color = color;
        this.letter = letter;
    }

    public bool IsEqual(QuizBall _choice)    // 비교를 위한 함수
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

}


class Quiz
{
    public void Play()
    {
        QuizBall quiz = new QuizBall();          // 퀴즈볼(정답) 생성.


        /*2가지 선택지 생성*/
        Random random = new Random();
        QuizBall option1 = new QuizBall();
        QuizBall option2;

        if (option1.Equal(quiz))                // 선택지1이 정답으로 생성되는경우 선택지2를 오답으로 만들어줘야함.
        {
            while (1)                           //선택지2가 선택지1과 동일하게 생성되지 않게 무한루프돌림.
            {
                option2 = new QuizBall();       // 처음한번은 무조건 생성+무한루프 돌때마다 새롭게 생성.
                if (!option1.Equal(option2))
                    return;                     // 선택지1과 비교후 다르다면 무한루프 끝남.
            }
        }
        else                                // 선택지1이 정답으로 생성되지 않은 경우
            option2 = quiz;                 // 선택지2를 정답으로 만들어준다.



        /*선택창 출력*/
        System.println("선택하세요");
        System.println("1번:" + option1.color * option1.letter);
        System.println("2번:" + option2.color * option2.letter);
        //선택지를 출력하기 편하게 1~28까지의 숫자로 표현한것일뿐 실제 표현방식은 알아서			



        QuizeBall choiceBall = new QuizBall(); // 할머니 선택 퀴즈볼
        Scanner input = new Scanner();  //자바의 입력객체, 한줄 입력은 readLine() 한키 입력은 nextInt()로 입력받음.
        int color = input.nextInt();
        int letter = input.nextInt(); // 유니티의 입력함수에 따라 입력의 표현방식 달라짐.
        choiceBall.Init(color, letter); //할머니 퀴즈볼값 수정완료


        if (quiz.IsEqual(choiceBall))
            System.println("맞습니다.");
        else
            System.println("틀렸습니다.");

    }

}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();      //Class Quiz 객체 생성 후 Play함수 호출하면 퀴즈 시작.
        quiz.Play();                 //퀴즈 4번실행.
        quiz.Play();
        quiz.Play();
        quiz.Play();

    }
}
