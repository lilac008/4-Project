using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuizBall()
{
    int color;
    int letter;

    public QuizBall()                        //������ : ��ü������ �� �ѹ� ȣ��(���� �ʱ�ȭ�� ���� ���� �ۼ�)
    {
        Random random = new Random();        //�����Լ� ��ü����

        this.color = 1 + random.nextInt(7);  // 1+0~6 ������ �������� ���� ���� (1~7)
        this.letter = 1 + random.nextInt(4); // 1+0~3 ������ �������� ���� ���� (1~4)
    }

    public void Init(int color, int letter)   //�� ������ ���� �ʱ�ȭ
    {
        this.color = color;
        this.letter = letter;
    }

    public bool IsEqual(QuizBall _choice)    // �񱳸� ���� �Լ�
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

}


class Quiz
{
    public void Play()
    {
        QuizBall quiz = new QuizBall();          // ���(����) ����.


        /*2���� ������ ����*/
        Random random = new Random();
        QuizBall option1 = new QuizBall();
        QuizBall option2;

        if (option1.Equal(quiz))                // ������1�� �������� �����Ǵ°�� ������2�� �������� ����������.
        {
            while (1)                           //������2�� ������1�� �����ϰ� �������� �ʰ� ���ѷ�������.
            {
                option2 = new QuizBall();       // ó���ѹ��� ������ ����+���ѷ��� �������� ���Ӱ� ����.
                if (!option1.Equal(option2))
                    return;                     // ������1�� ���� �ٸ��ٸ� ���ѷ��� ����.
            }
        }
        else                                // ������1�� �������� �������� ���� ���
            option2 = quiz;                 // ������2�� �������� ������ش�.



        /*����â ���*/
        System.println("�����ϼ���");
        System.println("1��:" + option1.color * option1.letter);
        System.println("2��:" + option2.color * option2.letter);
        //�������� ����ϱ� ���ϰ� 1~28������ ���ڷ� ǥ���Ѱ��ϻ� ���� ǥ������� �˾Ƽ�			



        QuizeBall choiceBall = new QuizBall(); // �ҸӴ� ���� ���
        Scanner input = new Scanner();  //�ڹ��� �Է°�ü, ���� �Է��� readLine() ��Ű �Է��� nextInt()�� �Է¹���.
        int color = input.nextInt();
        int letter = input.nextInt(); // ����Ƽ�� �Է��Լ��� ���� �Է��� ǥ����� �޶���.
        choiceBall.Init(color, letter); //�ҸӴ� ����� �����Ϸ�


        if (quiz.IsEqual(choiceBall))
            System.println("�½��ϴ�.");
        else
            System.println("Ʋ�Ƚ��ϴ�.");

    }

}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();      //Class Quiz ��ü ���� �� Play�Լ� ȣ���ϸ� ���� ����.
        quiz.Play();                 //���� 4������.
        quiz.Play();
        quiz.Play();
        quiz.Play();

    }
}
