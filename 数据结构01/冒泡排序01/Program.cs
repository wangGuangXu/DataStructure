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
            //array = AscendingOrder(array);
            //array = Ascending(array);

            //降序
            array = DescendingOrder(array);


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
            for (int i = 0; i < array.Length - 1; i++)//外层循环每次把参与排序的最大数排在最后
            {
                for (int j = 0; j < array.Length - 1 - i; j++)//内层循环负责对比相邻的两个数，并把大的排在后面
                {
                    //如果前一个数大于后一个数，则交换两个数
                    if (array[j] > array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }

        private static int[] Ascending(int[] arrays)
        {
            //外层循环控制循环多少趟  N个数字要排序完成，总共进行N-1趟排序，每i趟的排序次数为(N-i)次
            for (int i = 0; i < arrays.Length; i++)
            {
                //内层循环控制每一趟的循环次数
                for (int j = 0; j < arrays.Length - i - 1; j++)
                {
                    //交换位置
                    if (arrays[j] > arrays[j + 1])
                    {
                        int temp = arrays[j];
                        arrays[j] = arrays[j+1];
                        arrays[j+1] = temp;
                    }
                }
            }
            return arrays;
        }

        /// <summary>
        /// 降序
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        private static int[] DescendingOrder(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    //降序和升序区别 大于或者小于
                    if (array[j] < array[j + 1])
                    {
                        int temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
            return array;
        }


    }
}