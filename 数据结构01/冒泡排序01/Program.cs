using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 冒泡排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] array = new int[] { 30, 21, 60, 9, 58, 140, 1 };

            //升序
            array = AscendingOrder(array);

            //降序
            //array = DescendingOrder(array);

            foreach (var item in array)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 升序
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] AscendingOrder( int[] array)
        {
            int temp = 0;
            
            for (int i = 0; i < array.Length - 1; i++)//外层循环每次把参与排序的最大数排在最后
            {
                for (int j = 0; j < array.Length - 1 - i; j++)//内层循环负责对比相邻的两个数，并把大的排在后面
                {
                    //如果前一个数大于后一个数，则交换两个数
                    if (array[j] > array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        /// <summary>
        /// 降序
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] DescendingOrder(int[] array)
        {
            int temp = 0;
            for (int i = 0; i < array.Length - 1; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //降序和升序区别 大于或者小于
                    if (array[j] < array[j + 1])
                    {
                        temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }


    }
}