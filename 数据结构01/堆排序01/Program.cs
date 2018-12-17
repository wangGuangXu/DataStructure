using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 堆排序01
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] R = { 3, 6, 5, 9, 7, 1, 8, 2, 4 };

            //堆排序
            HeapSort(R);

            //打印排序后的元素
            foreach (int item in R)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 建堆过程
        /// </summary>
        static void Sift(int[] R,int low,int high)
        {
            //i为欲调整子树的根结点的索引号，j为这个结点的左孩子
            int i = low, j = 2 * i + 1;

            //记录双亲节点的值
            int temp = R[i];

            while (j<=high)
            {
                //如果左孩子小于右孩子，则将欲交换的孩子结点指向右孩子
                if (j<high && R[j]<R[j+1])
                {
                    j++;//j指向右孩子
                }

                //如果双亲结点小于它的孩子结点
                if (temp<R[j])
                {
                    R[i] = R[j];//交换双亲结点和它的孩子
                    i = j;//以后交换的孩子结点为根，继续调整它的子树
                    j = 2 * i + 1;// j 此时代表交换后的孩子结点的左孩子
                }
                else
                {
                    //调整完毕，退出
                    break;
                }
            }

            //使最初被调整的结点放入正确位置
            R[i] = temp;
        }

        /// <summary>
        /// 堆排序
        /// </summary>
        /// <param name="R"></param>
        static void HeapSort(int[] R)
        {
            int n = R.Length;//序列的长度

            //创建初始堆
            for (int i = n/2-1; i >=0; i--)
            {
                Sift(R, i, n - 1);
            }

            for (int i = n-1; i >=1; i--)
            {
                int temp = R[0];    //取堆顶元素
                R[0] = R[i];        //让堆中最后一个元素上移到堆顶位置
                R[i] = temp;        //此时R[i]已不在堆中，用于存放排序好的元素
                Sift(R, 0, i - 1);  //重新调整堆
            }
        }
    }
}
