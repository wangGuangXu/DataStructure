using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 直接插入排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            //直接插入排序适用于数据量较少的排序

            //待排序序列
            //int[] R = InsertSortV1();

            int[] R = InsertSortV2();

            //遍历排序好的序列
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 插入排序
        /// </summary>
        static int[] InsertSortV1()
        {
            //待排序序列
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };

            //j 是寻找插入位置的指针,temp 用于记录插入元素
            int j, temp;

            //约定第一个元素为有序, 此处i=2或者i=1都可以正常排序，换成别的数排序就有问题，不知道神马原因，不求甚解
            for (int i = 2; i < R.Length; i++)
            {
                //将插入元素存储于变量temp中
                temp = R[i];

                j = i - 1;

                //从后向前查找插入位置，同时将已排序记录向后移动
                while (j >= 0 && temp < R[j])
                {
                    //移动记录
                    R[j + 1] = R[j];

                    j--;
                }
                //将插入元素插入到合适位置
                R[j + 1] = temp;
            }

            return R;
        }

        /// <summary>
        /// 插入排序升级版
        /// </summary>
        static int[] InsertSortV2()
        {
            int j;

            //待排序序列
            int[] R = { 0, 3, 6, 5, 9, 7, 1, 8, 2, 4 };

            /*
             注意：使用监视哨的前提是R[0]元素不在待排序序列中，否则在排序前要在R[0]处插入一个额外元素，
             这样会使数组中的所有元素向右移动一位，导致改进后的性能提升被抵消
             */
            
            //目前没搞懂监视哨该怎么用

            for (int i = 2; i < R.Length; i++)
            {
                //将插入元素存于监视哨R[0]中
                R[0] = R[i];

                j = i - 1;

                while (R[0]<R[j])
                {
                    //移动记录
                    R[j + 1] = R[j];

                    j--;
                }

                //将插入元素插入到合适位置
                R[j + 1] = R[0];
            }

            return R;
        }

    }
}
