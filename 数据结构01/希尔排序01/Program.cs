using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 希尔排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            //希尔排序适用于记录数目比较大的情况

            int j, temp;
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };

            for (int d= R.Length/2;  d>=1; d=d/2)
            {
                for (int i = d; i < R.Length; i++)
                {
                    temp = R[i];
                    j = i - d;
                    while (j >= 0 && temp<R[j])
                    {
                        R[j + d] = R[j];
                        j = j - d;
                    }
                    R[j + d] = temp;
                }
            }

            //遍历排序后数组
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }

            Console.ReadKey();
        }
    }
}
