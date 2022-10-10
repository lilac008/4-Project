using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 26: C# program to find min and max in an array





namespace Basic_CSharp_Examples
{
    internal class Class26
    {
        static void Main1(string[] args)
        {
            int[] numArr = new int[10];
            Random random = new Random();
            int min, max;

            for (int i=0; i < numArr.Length; i++) 
            {
                numArr[i] = random.Next(1,100);       ///random.Next()범위 내의 수를 numArr[i]에 집어넣음
                Console.WriteLine(numArr[i]);
            }

            min = numArr[0];                          ///numArr[0]을 기준으로
            max = numArr[0];
            for (int i=1; i < numArr.Length; i++) 
            {
                if(min > numArr[i])                   ///numArr[0]과 numArr[1~numArr.Length]까지 순서대로 비교
                    min = numArr[i];                  ///numArr[0]보다 numArr[i]가 작으면 numArr[i]를 min에 저장
                if(max < numArr[i])
                    max = numArr[i];                  ///numArr[0]보다 numArr[i]가 크면 numArr[i]를 max에 저장
            }
            Console.WriteLine();
            Console.WriteLine("The highest number in the array: " + max);
            Console.WriteLine("The lowest number in the array: " + min);
            Console.ReadKey();


        }

    }
}
