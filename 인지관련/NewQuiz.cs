using System.Collections;
using System.Collections.Generic;
using UnityEngine;




class QuizUnit
{
    int color;
    int letter;


    /** 인수를 주지 않았을때의 생성자 **/
    public QuizUnit()
    {
        Random random = new Random();           /// 랜덤함수 객체생성

        this.color = random.Range(7);           /// 0~6 까지의 정수난수 랜덤 생성
        this.letter = random.Range(4);          /// 0~3 까지의 정수난수 랜덤 생성
    }



    /** 인수를 주었을때의 생성자 **/
    public QuizUnit(int _color, int _letter);
	{
		Random randdom = new Random();
		
		do
		{
			this.color = random.Range(7); 
			this.letter = random.Range(4);
		} while (this.color == _color && this.letter == _letter)  		/// 둘다 동일하다면 새롭게 난수 생성. 둘중하나라도 동일하지 않을때까지 계속돌림	
	}
}




class Quiz
{
    QuizUnit ans;
    QuizUnit opt1;
    QuizUnit opt2;

    public void Play()
    {
        Random random = new Random();

        /**정답 생성**/
        ans = new Quiz();


        /**option1과 option2중 랜덤으로 하나를 정답, 하나를 오답으로 생성.**/
        random = random.Range(2);
        switch (random)
        {
            case 0:
                {
                    opt1 = ans;
                    opt2 = new QuizUnit(ans.color, ans.letter);
                    break;
                }
            case 1:
                {
                    opt2 = ans;
                    opt1 = new QuizUnit(ans.color, ans.letter);
                    break;
                }
        }



        /**정답 먼저 보여주기**/
        유니티화면표시(ans.color);
        유니티화면표시(ans.letter);






        /**문제 보여주고 선택지제시 및 입력받음**/
        random = random.nextInt(2);

        Scanner input = new Scanner; ///자바전용 입력객체.
        int choice;


        /// 처음 문제는 ans의 color와 letter 둘중 하나만 랜덤으로 제시해야 한다.	
        switch (random)
        {
            case 0:
                {
                    /// 문제 제시
                    유니티화면표시(ans.color);

                    /// 옵션 제시
                    유니티화면표시(opt1.letter);
                    유니티화면표시(opt2.letter);

                    /// 유저 선택과 결과 표시
                    System.println("선택하세요");
                    choice = input.nextInt();
                    if (choice == ans.letter)
                        System.println("정답입니다");
                    else
                        System.println("오답입니다.");
                }
            case 1:
                {
                    /// 문제 제시
                    유니티화면표시(ans.letter);

                    /// 옵션 제시
                    유니티화면표시(opt1.color);
                    유니티화면표시(opt2.color);

                    /// 유저 선택과 결과 표시
                    System.println("선택하세요");
                    choice = input.nextInt();
                    if (choice == ans.color)
                        System.println("정답입니다");
                    else
                        System.println("오답입니다.");
                }
        }



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