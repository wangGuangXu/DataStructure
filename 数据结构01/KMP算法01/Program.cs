using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMP算法01
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arrStr = new string[5];
            arrStr[0] = "acdefgh";
            arrStr[1] = "abcababcaacd";
            arrStr[2] = "ababac";
            arrStr[3] = "aaaaaaac";
            arrStr[4] = "a";

            foreach (string s in arrStr)
            {
                int[] pattern = new int[s.Length];
                GetNext(s, pattern);

                foreach (char c in s)
                {
                    Console.Write(string.Format("{0,3}",c));
                }
                Console.WriteLine();

                foreach (int i in pattern)
                {
                    Console.Write(string.Format("{0,3}", i));
                }
                Console.WriteLine(System.Environment.NewLine);
            }

            Console.ReadKey();
        }

        /// <summary>
        /// 计算模式串K值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="next"></param>
        static void GetNext(string t,int [] next)
        {
            int k = -1, j = 0;
            next[0] = -1;
            while (j<t.Length-1)
            {
                if (k==-1 || t[j]==t[k])
                {
                    j++;
                    k++;
                    next[j] = k;
                }
                else
                {
                    k = next[k];
                }
            }
        }
    }
}
