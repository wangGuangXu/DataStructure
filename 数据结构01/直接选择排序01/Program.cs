using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 直接选择排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };
            int k, temp;
            for (int i = 0; i < R.Length; i++)
            {
                //k用于记录一趟排序中最小元素的索引号
                k = i;
                for (int j = i+1; j < R.Length; j++)
                {
                    //只要发现比R[j]小的元素
                    if (R[j]<R[k])
                    {
                        //就把这个元素的索引号记录在变量k内
                        k = j;
                    }
                }

                if (i!=k)
                {
                    //交换R[i]和R[k]的值，把最小元素依次放在最左边
                    temp = R[i];
                    R[i] = R[k];
                    R[k] = temp;
                }
            }

            //打印排序后的元素
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
    }
}
