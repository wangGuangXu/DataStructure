using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 布隆过滤器01
{
    /// <summary>
    /// 布隆过滤器
    /// 参考资料：https://www.cnblogs.com/wgx0428/
    /// </summary>
    public class BloomFilter
    {
        public BitArray _bloomArray;
        /// <summary>
        /// 布隆数组长度
        /// </summary>
        public Int64 BloomArrayLength { get; }
        /// <summary>
        /// 数据数组长度
        /// </summary>
        public Int64 DataArrayLength { get; }
        /// <summary>
        /// hash函数个数（散列表或者哈希表）
        /// </summary>
        public Int64 BitIndexCount { get; }

        /// <summary>
        /// 布隆过滤器（Bloom Filter）
        /// </summary>
        /// <param name="bloomArrayLength">布隆数组长度</param>
        /// <param name="dataArrayLength">数据数组长度</param>
        /// <param name="bitIndexCount">hash函数个数（散列表或者哈希表）</param>
        public BloomFilter(int bloomArrayLength, Int64 dataArrayLength,Int64 bitIndexCount)
        {
            //1.初始化长度为bloomArrayLength的位数组
            _bloomArray = new BitArray(bloomArrayLength);

            this.BloomArrayLength = bloomArrayLength;
            this.DataArrayLength = dataArrayLength;
            this.BitIndexCount = bitIndexCount;
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="str">字符串</param>
        public void Add(string str)
        {
            //计算字符串的哈希值
            int hashValue = str.GetHashCode();

            //将哈希值种子放进随机函数
            var random = new Random(hashValue);

            //2.将结果分别映射到位数组中，并设置对应位结果位1
            for (int i = 0; i < BitIndexCount; i++)
            {
                //返回哈希值映射的位数组索引
                int randomIndex = random.Next((int)BloomArrayLength - 1);

                //将哈希值映射到随机生成的索引中 并将结果设置为1，0：表示不存在，1：表示存在
                _bloomArray[randomIndex] = true;
            }
        }

        /// <summary>
        /// 是否存在
        /// </summary>
        /// <param name="str">字符串</param>
        /// <returns></returns>
        public bool Exists(string str)
        {
            int hashValue = str.GetHashCode();
            var random = new Random(hashValue);

            for (int i = 0; i < BitIndexCount; i++)
            {
                if (_bloomArray[random.Next((int)BloomArrayLength - 1)] == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取错误概率
        /// </summary>
        /// <returns></returns>
        public double GetFalsePositiveProbability()
        {
            // (1 - e^(-k * n / m)) ^ k
            return Math.Pow((1 - Math.Exp(-BitIndexCount * (double)DataArrayLength / BloomArrayLength)), BitIndexCount);
        }
    }
}