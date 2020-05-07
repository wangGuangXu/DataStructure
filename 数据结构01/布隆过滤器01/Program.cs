using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 布隆过滤器01
{
    /// <summary>
    /// 布隆过滤器示例
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            //五千万条数据
            var bloomFilter = new BloomFilter(200000000, 50000000, 3);

            //添加5千万个数做测试
            for (int i = 0; i < bloomFilter.DataArrayLength; i++)
            {
                bloomFilter.Add(i.ToString());
            }

            do
            {
                var str = Console.ReadLine();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var temp = bloomFilter.Exists(str);

                stopwatch.Stop();
                Console.WriteLine($"查找:{str}\n结果:{temp}\n总耗时:{stopwatch.ElapsedTicks}\n错误概率:{bloomFilter.GetFalsePositiveProbability()}\r\n");
            } while (true);

        }
    }
}