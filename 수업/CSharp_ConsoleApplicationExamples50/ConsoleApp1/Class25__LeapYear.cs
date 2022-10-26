using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 25: Program to Find Leap Year in C#

/// 태양력의 윤년(그레고리력) : 지구가 태양을 한 바퀴 도는 데에는 365일 5시간 48분 46초, 365일을 제외한 시간들을 모아 태양력에서 4년마다 한 번 2월 29일을 두어 하루를 늘리고, 태음력에서는 평년이 354일이므로 계절과 역월을 조절하기 위해 19년에 7번의 비율로 윤달을 끼워 1년을 13개월로 한다.
/// 서력 기원 연수가 4로 나누어 떨어지는 해는 윤년        (1988년, 1992년, 1996년, 2004년, 2008년, 2012년, 2016년, 2020년, 2024년, 2028년, 2032년, 2036년, 2040년, 2044년 ...)
/// 서력 기원 연수가 4, 100으로 나누어 떨어지는 해는 평년 (1700년, 1800년, 1900년, 2100년, 2200년, 2300년...)
/// 서력 기원 연수가 4, 100, 400으로 나누어 떨어지는 해는 윤년 (1600년, 2000년, 2400년...)


///  || (OR, 합집합) 
///  && (AND, 교집합)


namespace Basic_CSharp_Examples
{
    internal class Class25__LeapYear
    {
        static void Main1(string[] args)
        {
            int year;
            Console.Write("Enter the Year :");
            year = Convert.ToInt32(Console.ReadLine());
            
            if ( (year % 4==0 && year % 100 !=0) || year % 400 == 0 )
                Console.WriteLine("{0} is Leap Year", year);
            else
                Console.WriteLine("{0} is not a Leap Year", year);

            Console.ReadLine();
        }   

    }
}
