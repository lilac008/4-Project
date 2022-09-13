using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


/// Example 24: Program Library Fine Calculation in C#
///
/// 
/// The fee structure is as follows:
/// 1. If the book is returned on before 5 days, no fine will be charged.
/// 2. If the book is returned after the expected return day (between 5 and 10 days) – fine: 0.5$ per day
/// 3. If the book is returned after the expected return day (between 10 and 30 days) fine: 1$ per day
/// 4. If the book is not returned after 30 days, cancel membership. fine: 1.5$ per day




namespace Basic_CSharp_Examples
{
    internal class Class24
    {
        static void Main1(string[] args)
        {
            int days;
            float fine = 0;

            Console.Write("Enter total days : ");
            days = Convert.ToInt32(Console.ReadLine);

            if (days <= 5)                           
            {
                fine = 0;
            }
            else if (days > 5 && days <= 10)         
            {
                fine = (days - 5) * 0.5F;
            }
            else if (days > 10 && days <= 30)      
            {
                fine = 5 * 0.5F + (days - 10) * 1;                  /// 5days (5 * 0.5F)  +  10~30days( (days-10)*1 )
            }
            else                                    
            {
                fine = 5 * 0.5F + 20 * 1 + (days - 30) * 1.5F;      /// 5days (5 * 0.5F)  +  10~30days( 20 * 1 ) +  30days~ ( (days-30) * 1.5F)  
                Console.WriteLine("Canceled your Membership");
            }
            Console.WriteLine("Your fine:" + fine);
            Console.ReadLine();
        }


    }
}
