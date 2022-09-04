using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuizUnit()    ///��������
{
    int color;
    int letter;

    public QuizUnit()                                   ///������ : ��ü������ �� �ѹ� ȣ��(���� �ʱ�ȭ)
    {
        Random random = new Random();                   ///�����Լ� ��ü����

        this.color = random.Range(1,7);                 ///���� ��ü 1~7
        this.letter = random.Range(1,4);                ///���ڿ� 1~4
    }

    public void Init(int color, int letter)             ///�ʱ�ȭ�Լ�(�� ����)
    {
        this.color = color;
        this.letter = letter;
    }

    public bool IsEqual(QuizUnit _choice)                ///���Լ�
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

}


class Quiz  ///����Ǯ��
{
    public void Play()
    {
        QuizUnit quizUnit = new QuizUnit();          /// ���� ���� ����.


        /*2���� ������ ����*/
        QuizUnit choice1 = new QuizBall();
        QuizUnit choice2;

        if (choice1.Equal(quizUnit))                           /// ������1�� �������� �����Ǵ°�� ������2�� �������� ����������.
        {
            while (1)                                          /// ������2�� ������1�� �����ϰ� �������� �ʰ� ���ѷ�������.
            {
                choice2 = new QuizBall();                    /// ó���ѹ��� ������ ����+���ѷ��� �������� ���Ӱ� ����.
                if (!choice1.Equal(choice2))
                    return;                                    /// ������1�� ���� �ٸ��ٸ� ���ѷ��� ����.
            }
        }
        else                                                   /// ������1�� �������� �������� ���� ���
            choice2 = quizUnit;                               /// ������2�� �������� ������ش�.



        /*����â ���*/     
        Console.WriteLine("�� ���õ� ���� ������.");
        Console.WriteLine("1��:" + choice1.color * choice1.letter);
        Console.WriteLine("2��:" + choice2.color * choice2.letter);                                                           		


        QuizeBall quizBall_2 = new QuizBall();      /// ���� ���
        Scanner input = new Scanner();              /// �ڹ��� �Է°�ü, ���� �Է��� readLine() ��Ű �Է��� nextInt()�� �Է¹���.
        int color = input.nextInt();
        int letter = input.nextInt();               /// ����Ƽ�� �Է��Լ��� ���� �Է��� ǥ����� �޶���.
        quizBall_2.Init(color, letter);             /// ����� �����Ϸ�


        if (quizUnit.IsEqual(quizBall_2))
            Console.WriteLine("�����Դϴ�."); 
        else
            Console.WriteLine("�����Դϴ�.");

    }

}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();      ///Class Quiz ��ü ���� �� Play�Լ� ȣ���ϸ� ���� ����
        quiz.Play();                 ///���� ����

    }
}
