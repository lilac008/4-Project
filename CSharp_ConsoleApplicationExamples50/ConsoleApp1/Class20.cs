using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Ch07.Sub1; 


namespace Basic_CSharp_Examples 
{
    internal class Class20 
    {
        static void Main(string[] args)
        {



            //Dictionary, List 응용
            Dictionary<int, Apple> dic1 = new Dictionary<int, Apple>();
            Dictionary<int, Apple> dic2 = new Dictionary<int, Apple>();
            Dictionary<int, Apple> dic3 = new Dictionary<int, Apple>();

            ///   dic1          dic2          dic3
            ///  k   v       k   v          k    v
            ///  1  사과     4   사과
            ///  2  사과     5
            ///  3  사과     6


            dic1.Add(101, new Apple("한국", 3000));
            dic1.Add(102, new Apple("미국", 2000));
            dic1.Add(103, new Apple("이집트", 1000));

            dic2.Add(201, new Apple("중국", 3000));
            dic2.Add(202, new Apple("영국", 2000));
            dic2.Add(203, new Apple("인도", 1000));

            dic3.Add(301, new Apple("일본", 3000));
            dic3.Add(302, new Apple("프랑스", 2000));
            dic3.Add(303, new Apple("멕시코", 1000));

            ///List<> apples = new List<>();    
            /// + Dictionary<int, Apple>
            List<Dictionary<int, Apple>> apples = new List<Dictionary<int, Apple>>();
            apples.Add(dic1);
            apples.Add(dic2);
            apples.Add(dic3);


            // 한국 사과
            Dictionary<int, Apple> d = apples[0];
            Apple a = d[101];
            a.Show();
            Console.WriteLine();

            // 미국 사과
            ///Dictionary<int, Apple> d = apples[0];
            ///Apple a = d[102];
            ///a.Show();

            apples[0][102].Show();
            Console.WriteLine();

            // 영국 사과
            apples[1][202].Show();
            Console.WriteLine();

            // 멕시코 사과
            apples[2][303].Show();


        }

    }
    
}