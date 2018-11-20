using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 内置排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 30, 21, 60, 9, 58, 140, 1 };

            //采用系统内置的数组排序
            var sortArray = array.OrderBy(a => a).ToArray();
            for (int i = 0; i < sortArray.Length; i++)
            {
                Console.WriteLine(sortArray[i]);
            }

            Console.ReadKey();
        }
    }
}