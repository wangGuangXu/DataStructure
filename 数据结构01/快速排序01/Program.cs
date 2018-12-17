using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 快速排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 40, 4, 99, 101, 24, 78, 77, 33, 5 };

            //快速排序
            QuickSort(array, 0, array.Length - 1);

            //打印排序后的数组
            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 对序列中索引号从低到高所表示的区间进行快速排序
        /// </summary>
        /// <param name="array">序列</param>
        /// <param name="low">低位索引</param>
        /// <param name="high">高位索引</param>
        static void QuickSort(int [] array,int low,int high)
        {
            //确保区间至少存在一个以上的元素
            if (low>=high)
            {
                return;
            }

            //temp表示基准值,此处取区间的第一个元素作为它的值
            int i = low, j = high, temp = array[i];

            //从区间两端交替像中间扫描,直到i=j为止
            while (i < j)
            {
                while (i < j && array[j] >= temp)
                {
                    j--;//从右向左扫描，直到找到比基准值小的元素
                }
                array[i] = array[j];//将比基准值小的元素移到左端

                while (i < j && array[i] <= temp)
                {
                    i++;//从左向右扫描直到找到比基准值大的元素。
                }
                array[j] = array[i];//将比基准值大的元素移到右端
            }

            array[i] = temp;//记录归位

            QuickSort(array, low, i - 1);//对左区间进行递归排序

            QuickSort(array, i + 1, high);//对右区间递归排序
        }

    }
}
