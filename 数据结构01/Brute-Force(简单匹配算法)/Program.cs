using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Brute_Force_简单匹配算法_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(index("cbbcbcbb","cbc"));
            Console.WriteLine(index("cbbcbcbb", "bcb"));
            Console.WriteLine(index("cbbcbcbb", "abc"));

            Console.ReadKey();
        }

        static int index(string s,string t)
        {
            int i = 0, j = 0, k;

            while (i<s.Length && j<t.Length)
            {
                //相等则匹配下一个字符
                if (s[i] == t[j])
                {
                    i++;
                    j++;
                }
                else
                {
                    //否则主、子串指针回溯重新开始下一次匹配
                    i = i - j + 1;
                    j = 0;
                }
            }

            //返回匹配的第一个字符的下标
            if (j>=t.Length)
            {
                k = i - t.Length;
            }
            else
            {
                k = -1;     //模式匹配不成功则返回-1
            }
            return k;
        }

    }
}
