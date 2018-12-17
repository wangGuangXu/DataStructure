using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KMP算法02
{
    class Program
    {
        static void Main(string[] args)
        {
            //把主串和子串压入二位数组
            string[,] arrStr =
            {
                {"abadababc","ababc" },
                {"abcaabbabcabaacbacba","abcabaa" },
                {"abcaabca","d" },
                {"abcdefg","abc" },
                {"aaaaaaaaaaaaaaaaab","aaaaaaaab" },
            };

            for (int i = 0; i < arrStr.GetLength(0); i++)
            {
                //使用KMP算法进行匹配
                Console.WriteLine(arrStr[i,0]+" 匹配 "+arrStr[i,1]+" 的结果为 "+KMPIndex(arrStr[i,0], arrStr[i, 1]));
            }
            Console.ReadKey();
        }

        /// <summary>
        /// 计算模式串K值
        /// </summary>
        /// <param name="t"></param>
        /// <param name="next"></param>
        static void GetNext(string t, int[] next)
        {
            int k = -1, j = 0;
            next[0] = -1;
            while (j < t.Length - 1)
            {
                if (k == -1 || t[j] == t[k])
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

        /// <summary>
        /// KMP算法
        /// </summary>
        /// <param name="s"></param>
        /// <param name="t"></param>
        /// <returns></returns>
        static int KMPIndex(string s, string t)
        {
            int[] pattern = new int[t.Length];
            int i = 0, j = 0, v=0;
            GetNext(t, pattern);

            while (i < s.Length && j<t.Length)
            {
                if (j == -1 || s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    j = pattern[j];
                }

                if (j >=t.Length)
                {
                    v = i - t.Length;   //匹配成功返回索引号
                }
                else
                {
                    v = -1;             //匹配失败返回-1
                }
            }
            return v;
        }
    }
}
