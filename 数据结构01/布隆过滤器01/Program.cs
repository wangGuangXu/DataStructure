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
            //2亿个布隆过滤器大小 五千万条数据
            var bloomFilter = new BloomFilter<int>(200_000_000, 50_000_000);

            //添加5千万个数做测试
            for (int i = 0; i < bloomFilter.DataArrayLength; i++)
            {
                bloomFilter.Add(i);
            }

            do
            {
                var str = Console.ReadLine();

                var stopwatch = new Stopwatch();
                stopwatch.Start();

                var temp = bloomFilter.Exists(int.Parse(str));

                stopwatch.Stop();
                Console.WriteLine($"查找:{str}\n结果:{temp}\n总耗时:{stopwatch.ElapsedTicks}\n错误概率:{bloomFilter.GetFalsePositiveProbability()}\r\n");
            } while (true);

        }
    }
}