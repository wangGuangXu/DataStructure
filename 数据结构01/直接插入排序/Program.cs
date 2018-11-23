using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 直接插入排序
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = new List<int>() { 3, 1, 5, 90, 32, 78, 22 };

            //排序前
            Console.WriteLine("排序前："+string.Join(",",numbers));

            InsertSort(numbers);

            Console.WriteLine("排序后："+string.Join(",",numbers));

            Console.ReadKey();
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        static void InsertSort(List<int> numbers)
        {
            //无序序列
            for (int i = 1; i < numbers.Count; i++)
            {
                var temp = numbers[i];
                int j;

                //有序序列
                for (j = i-1; j>=0 && temp < numbers[j]; j--)
                {
                    numbers[j + 1] = numbers[j];
                }

                numbers[j + 1] = temp;
            }
        }

    }
}
