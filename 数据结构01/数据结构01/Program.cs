using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace 数据结构01
{
    class Program
    {
        static void Main(string[] args)
        {
            //计算：1+2+3+……100的和

            ////最普通的计算方法
            //int num = 0;
            //for (int i = 1; i <= 100; i++)
            //{
            //    num =num+i;
            //}
            //Console.WriteLine(num);

            /* 数学家高斯的解题思路：
             *  sum=1+2+3+4+5……+100 
             * sum2=100+99+98+97+96+……+1
             * sum3=101+101+101+……+101 正好为50个
             * sum4=101*50
             */
            int n = 100;
            int sum = (1 + n) * (n / 2);
            Console.WriteLine(sum);

            Console.Read();
        }
    }
}
