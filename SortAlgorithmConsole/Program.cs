using System;
using System.Collections.Generic;

namespace SortAlgorithmConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> arr = new List<int>() { 12, 58, 1, 35, 112, 0, 62, 85, 16, 58, 85 };

            //  ShowArr(BubbleSort.Sort(arr));
            ShowArr(InsertionSort.Sort(arr));



            Console.WriteLine("Hello World!");
        }

        public static void ShowArr(List<int> arr)
        {
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
