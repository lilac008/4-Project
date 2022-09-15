using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// 1. ������
/// 
/// Q : ���� ����� ���ڸ� �Բ� ����ϼ���.
/// ���� - ���� ��ü 7���� 
/// ���� - ���ڿ� N���� (��� �þ ����)


/// 2. ������
/// 
/// ���ÿɼ�1(������ ����)
/// ���ÿɼ�2(������ ����)  





class QuizUnit
{
    int color;
    int letter;


    /** �μ��� ���� �ʾ������� ������ **/
    public QuizUnit()
    {
        Random random = new Random();           /// �����Լ� ��ü����

        this.color = random.Range(7);           /// 0~6 ������ ������ ���� ����
        this.letter = random.Range(4);          /// 0~3 ������ ������ ���� ����
    }



    /** �μ��� �־������� ������ **/
    public QuizUnit(int _color, int _letter);
	{
		Random randdom = new Random();
		
		do
		{
			this.color = random.Range(7); 
			this.letter = random.Range(4);
		} while (this.color == _color && this.letter == _letter)  		/// �Ѵ� �����ϴٸ� ���ο� ���� ����. �� �� �ϳ��� �������� ���������� ��ӵ���	
	}
}




class Quiz
{
    QuizUnit answer;
    QuizUnit opt1;
    QuizUnit opt2;

    public void Play()
    {
        answer = new Quiz();                                        ///���� ����

        Random random = new Random();

        random = random.Range(2);                                   /// 1/2Ȯ���� ���� ���� ���� - �ϳ��� �����̸� �ٸ� �ϳ��� ����
        switch (random)
        {
            case 0:
                {
                    opt1 = answer;
                    opt2 = new QuizUnit(answer.color, answer.letter);   ///�ɼ�2�� ���ο� ������ ����/���� ����
                    break;
                }
            case 1:
                {
                    opt2 = answer;
                    opt1 = new QuizUnit(answer.color, answer.letter);
                    break;
                }
        }



        //1. ������ - ���� ó�� ������ ���� ������� ��
        ����Ƽȭ��ǥ�õ��Լ�(answer.color);
        ����Ƽȭ��ǥ�õ��Լ�(answer.letter);




        //2. ������
        random = random.Range(2);

        ConsoleKeyInfo KeyInfo;                         ///�Է°�ü -> ����Ƽ�� �°� ����
        KeyInfo = Console.ReadKey();                    ///�Է°�ü -> ����Ƽ�� �°� ����
        /// if(KeyInfo.Key == ConsoleKey.A)

        int choice;


        switch (random)   /// ó�� ������ ans�� color�� letter ���� �ϳ��� �������� �����ؾ� �Ѵ�.	
        {
            case 0:
                {
                    /// ���� ����
                    ����Ƽȭ��ǥ��(answer.color);

                    /// ������ ����
                    ����Ƽȭ��ǥ��(opt1.letter);
                    ����Ƽȭ��ǥ��(opt2.letter);

                    /// ���� ���� �� ��� ǥ��
                    System.Console.WriteLine("�����ϼ���"); 
                    choice = Convert.ToInt32(Console.ReadKey());       ///�Է°�ü -> ����Ƽ�� �°� ����
                    if (choice == answer.letter)
                        System.Console.WriteLine("�����Դϴ�");         
                    else
                        System.Console.WriteLine("�����Դϴ�."); 
                }
            case 1:
                {
                    /// ���� ����
                    ����Ƽȭ��ǥ��(answer.letter);

                    /// ������ ����
                    ����Ƽȭ��ǥ��(opt1.color);
                    ����Ƽȭ��ǥ��(opt2.color);

                    /// ���� ���� �� ��� ǥ��
                    System.Console.WriteLine("�����ϼ���");
                    choice = Convert.ToInt32(Console.ReadKey());       ///�Է°�ü -> ����Ƽ�� �°� ����
                    if (choice == answer.color)
                        System.Console.WriteLine("�����Դϴ�");
                    else
                        System.Console.WriteLine("�����Դϴ�.");
                }
        }



    }
}


class Main
{
    public static void main()
    {
        Quiz quiz = new Quiz();      ///Class Quiz ��ü ���� �� Play�Լ� ȣ���ϸ� ���� ����.
        quiz.Play();                 ///���� n������
        quiz.Play();
        quiz.Play();
        quiz.Play();

    }
}