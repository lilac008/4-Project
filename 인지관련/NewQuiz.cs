using System.Collections;
using System.Collections.Generic;
using UnityEngine;




class QuizUnit
{
    int color;
    int letter;


    /** �μ��� ���� �ʾ������� ������ **/
    public QuizUnit()
    {
        Random random = new Random();           /// �����Լ� ��ü����

        this.color = random.Range(7);           /// 0~6 ������ �������� ���� ����
        this.letter = random.Range(4);          /// 0~3 ������ �������� ���� ����
    }



    /** �μ��� �־������� ������ **/
    public QuizUnit(int _color, int _letter);
	{
		Random randdom = new Random();
		
		do
		{
			this.color = random.Range(7); 
			this.letter = random.Range(4);
		} while (this.color == _color && this.letter == _letter)  		/// �Ѵ� �����ϴٸ� ���Ӱ� ���� ����. �����ϳ��� �������� ���������� ��ӵ���	
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

        /**���� ����**/
        ans = new Quiz();


        /**option1�� option2�� �������� �ϳ��� ����, �ϳ��� �������� ����.**/
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



        /**���� ���� �����ֱ�**/
        ����Ƽȭ��ǥ��(ans.color);
        ����Ƽȭ��ǥ��(ans.letter);






        /**���� �����ְ� ���������� �� �Է¹���**/
        random = random.nextInt(2);

        Scanner input = new Scanner; ///�ڹ����� �Է°�ü.
        int choice;


        /// ó�� ������ ans�� color�� letter ���� �ϳ��� �������� �����ؾ� �Ѵ�.	
        switch (random)
        {
            case 0:
                {
                    /// ���� ����
                    ����Ƽȭ��ǥ��(ans.color);

                    /// �ɼ� ����
                    ����Ƽȭ��ǥ��(opt1.letter);
                    ����Ƽȭ��ǥ��(opt2.letter);

                    /// ���� ���ð� ��� ǥ��
                    System.println("�����ϼ���");
                    choice = input.nextInt();
                    if (choice == ans.letter)
                        System.println("�����Դϴ�");
                    else
                        System.println("�����Դϴ�.");
                }
            case 1:
                {
                    /// ���� ����
                    ����Ƽȭ��ǥ��(ans.letter);

                    /// �ɼ� ����
                    ����Ƽȭ��ǥ��(opt1.color);
                    ����Ƽȭ��ǥ��(opt2.color);

                    /// ���� ���ð� ��� ǥ��
                    System.println("�����ϼ���");
                    choice = input.nextInt();
                    if (choice == ans.color)
                        System.println("�����Դϴ�");
                    else
                        System.println("�����Դϴ�.");
                }
        }



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