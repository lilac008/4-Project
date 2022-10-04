using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/// Example 36: Find The Second Largest Number in Array Using C#


namespace Basic_CSharp_Examples
{
    internal class Class36__second_largest_number
    {
        static void Main1(string[] args)
        {
            int sizeofArr, i, j = 0, largest, secondLargest;
            int[] arr = new int[50];

            Console.Write("\n\nFind the second largest element in an array :\n");
            Console.Write("-----------------------------------------\n");

            Console.Write("Input the size of array : ");
            sizeofArr = Convert.ToInt32(Console.ReadLine());
            Console.Write("Input {0} elements in the array :\n", sizeofArr);  /// Stored values into the array
            for (i = 0; i < sizeofArr; i++)
            {
                Console.Write("element [{0}] : ", i);
                arr[i] = Convert.ToInt32(Console.ReadLine());
            }

            /// find location of the largest element in the array
            largest = 0;
            for (i = 0; i < sizeofArr; i++)
            {
                if (largest < arr[i])
                {
                    largest = arr[i];
                    j = i;
                }
            }

            /// ignore the largest element and find the 2nd largest element in the array
            secondLargest = 0;
            for (i = 0; i < sizeofArr; i++)
            {
                if (i == j)
                {
                    i++;  /* ignoring the largest element */
                    i--;
                }
                else
                {
                    if (secondLargest < arr[i])
                    {
                        secondLargest = arr[i];
                    }
                }
            }

            Console.Write("The Second largest element in the array is :  {0} \n\n", secondLargest);

            Console.ReadKey();
        }
    }
}
