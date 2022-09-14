using System.Collections;
using System.Collections.Generic;
using UnityEngine;

class QuizOption()    ///��������
{
    int color;
    int letter;

    public QuizOption()                                   ///������ : ��ü������ �� �ѹ� ȣ��(���� �ʱ�ȭ)
    {
        Random random = new Random();                     ///�����Լ� ��ü����
        this.color = random.Range(1,7);                   ///��ü 1~7
        this.letter = random.Range(1,4);                  ///���ڿ� A,B,C,D
    }

    public bool IsEqual(QuizOption _quizOption)               ///���Լ�
    {
        if (this.color == _quizOption.color   &&   this.letter == _quizOption.letter)
            return true;
        else false;
    }

    public void Init(int _int1, int _int2)               ///�ʱ�ȭ�Լ�(�ʱⰪ ����)
    {
        this.color = _int1;
        this.letter = _int2;
    }

}


class Quiz  ///����Ǯ��
{
    public void Play()
    {
        QuizOption rightAnswer = new QuizOption();        /// ���� ������
        QuizOption option1 = new QuizOption();            /// ���� ���ÿɼ�1             
        QuizOption option2;                               /// ���� ���ÿɼ�2 : ���ÿɼ�1�� �����ΰ��, ���ÿɼ�2�� ��������

        if (option1.IsEqual(rightAnswer))                 ///1-1. ���ÿɼ�1�� �������� ��ġ�Ѵٸ�
        {
            while (1)                                     
            {
                option2 = new QuizOption();               /// (���ÿɼ�2 ó���� ������ ����, ���ѷ������� ���� ����)
                if (!option1.IsEqual(option2))            ///1-2. ���ÿɼ�1�� ���ÿɼ�2�� �������� ������
                    return;                               ///1-3. 
            }
        }
        else                                              ///2-1. (���ÿɼ�1�� �������� ��ġ���� ������) ���ÿɼ�2�� ��������
            option2 = rightAnswer;


        /// ���ÿɼ� â
        Console.WriteLine("�����ϼ���.");
        Console.WriteLine("1��:" + option1.color * option1.letter);
        Console.WriteLine("2��:" + option2.color * option2.letter);                                                           		


        QuizOption choiceQuiz = new QuizOption();         ///������ ����
        int color = input.nextInt();                      ///�Է°�ü -> C#�� �°� �����ؾ���
        int letter = input.nextInt();                     ///�Է°�ü -> C#�� �°� �����ؾ���              
        choiceQuiz.Init(color, letter);                   ///������ ������ �ʱⰪ ����


        if (rightAnswer.IsEqual(choiceQuiz))
            Console.WriteLine("�����Դϴ�."); 
        else
            Console.WriteLine("�����Դϴ�.");
    }

}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();                     ///Class Quiz ��ü ���� �� Play�Լ� ȣ���ϸ� ���� ����
        quiz.Play();                                ///���� ����
    }
}
