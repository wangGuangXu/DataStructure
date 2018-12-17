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
            //temp 用于记录插入元素
            int j, temp;//j 是寻找插入位置的指针

            //待排序序列
            int[] R = { 3, 6, 5, 9, 7,1, 8, 2, 4 };

            //约定第一元素为有序
            for (int i = 2; i < R.Length; i++)
            {
                //将插入元素存储于变量temp中
                temp = R[i];

                j = i - 1;

                //从后向前查找插入位置，同时将已排序记录向后移动
                while (j >= 0 && temp<R[j])
                {
                    //移动记录
                    R[j + 1] = R[j];

                    j--;
                }

                //将插入元素插入到合适位置
                R[j + 1] = temp;

            }
            
            //遍历排序好的序列
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();

        }
    }
}
