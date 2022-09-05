using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class Quiz()    ///��������
{
    int color;
    int letter;

    public Quiz()                                       ///������ : ��ü������ �� �ѹ� ȣ��(���� �ʱ�ȭ)
    {
        Random random = new Random();                   ///�����Լ� ��ü����
        this.color = random.Range(1,7);                 ///��ü 1~7
        this.letter = random.Range(1,4);                ///���ڿ� A,B,C,D
    }

    public bool IsEqual(Quiz _choice)                   ///���Լ�
    {
        if (this.color == _choice.color && this.letter == _choice.letter)
            return true;
    }

    public void Init(int color, int letter)             ///�ʱ�ȭ�Լ�(�� ����)
    {
        this.color = color;
        this.letter = letter;
    }

}


class QuizOption  ///����Ǯ��
{
    public void Play()
    {
        Quiz quiz = new Quiz();                           /// ���� ���� ����
        Quiz choice1 = new Quiz();                        /// ����1�� ����, ����2�� ����
        Quiz choice2;

        if (choice1.IsEqual(quiz))                   
        {
            while (1)                                     /// ����2�� ����1�� �����ϰ� �������� �ʰ� ���ѷ���
            {
                choice2 = new Quiz();                     /// �ѹ��� ������ ���� + ���ѷ������� ���Ӱ� ����
                if (!choice1.IsEqual(choice2))
                    return;                               /// ����1�� ����2 ���� �ٸ��ٸ� ���ѷ��� ��
            }
        }
        else                                              ///����1�� �������� �������� ���� ���, ����2�� �������� ������ش�.
            choice2 = quiz;

        /// ����â ���
        Console.WriteLine("�� ���õ� ���� ������.");
        Console.WriteLine("1��:" + choice1.color * choice1.letter);
        Console.WriteLine("2��:" + choice2.color * choice2.letter);                                                           		


        Quiz quiz2 = new Quiz();                        /// ������ �������
        Scanner input = new Scanner();                  /// �ڹ��� �Է°�ü, ���� �Է��� readLine() ��Ű �Է��� nextInt()�� �Է¹���.
        int color = input.nextInt();
        int letter = input.nextInt();               
        quiz2.Init(color, letter);                      /// ��� �����Ϸ�


        if (quiz.IsEqual(quiz2))
            Console.WriteLine("�����Դϴ�."); 
        else
            Console.WriteLine("�����Դϴ�.");
    }

}


class Main
{
    public static void main()
    {
        QuizOption quizOption = new QuizOption();          ///Class Quiz ��ü ���� �� Play�Լ� ȣ���ϸ� ���� ����
        quizOption.Play();                                 ///���� ����
    }
}
