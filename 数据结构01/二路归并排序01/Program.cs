using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 二路归并排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };

            //使用二路归并法进行排序
            MergeSort(R, 0, R.Length - 1);

            //打印排序后的元素
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 将两个有序的子集合R[low……mid]和R[mid+1……higth]合并成一个有序的集合R[low……higth]
        /// </summary>
        /// <param name="R"></param>
        /// <param name="low"></param>
        /// <param name="mid"></param>
        /// <param name="higth"></param>
        static void Merge(int[] R, int low, int mid,int higth)
        {
            //R1为临时空间，用于存放合并后的数据
            int[] R1 = new int[higth - low + 1];
            int i = low, j = mid + 1, k = 0;    //k代表R1的下标

            //合并两个子结合
            while (i<=mid && j<=higth)
            {
                R1[k++] = (R[i] < R[j]) ? R[i++] : R[j++];
            }

            //将左边子集合的剩余部分复制到R1中
            while (i <= mid)
            {
                R1[k++] = R[i++];
            }

            //将右边子集合的剩余部分复制到R1中
            while (j <= higth)
            {
                R1[k++] =  R[j++];
            }

            for (k = 0, i=low; i<= higth; k++,i++)
            {
                //将R1复制会R中
                R[i] = R1[k];
            }
        }

        /// <summary>
        /// 二路归并排序
        /// </summary>
        /// <param name="R"></param>
        /// <param name="low"></param>
        /// <param name="higth"></param>
        static void MergeSort(int[] R,int low,int higth)
        {
            if (low<higth)
            {
                int mid = (low + higth) / 2;
                MergeSort(R, low, mid);         //归并左边子集合（递归调用）
                MergeSort(R, mid+1, higth);     //归并右边子集合（递归调用）
                Merge(R, low, mid, higth);      //归并当前集合
            }
        }
    }
}
