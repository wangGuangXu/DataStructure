using System;
using System.CodeDom;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 布隆过滤器01
{
    /// <summary>
    /// 布隆过滤器
    /// 参考资料：https://www.cnblogs.com/wgx0428/
    /// https://blog.csdn.net/WuLex/article/details/51897150?locationNum=11
    /// </summary>
    public class BloomFilter<T>
    {
        /// <summary>
        /// 一个很长的二进制向量 （位数组）
        /// </summary>
        public BitArray _bloomArray;
        /// <summary>
        /// 布隆过滤器的大小
        /// </summary>
        public Int64 BloomArrayLength { get; }
        /// <summary>
        /// 数据集合的大小
        /// </summary>
        public Int64 DataArrayLength { get; }
        /// <summary>
        /// hash函数个数（散列表或者哈希表）
        /// </summary>
        public Int64 HashFunctionCount { get; }

        /// <summary>
        /// 布隆过滤器（Bloom Filter）
        /// </summary>
        /// <param name="bloomArrayLength">布隆数组长度</param>
        /// <param name="dataArrayLength">数据数组长度</param>
        /// <param name="bitIndexCount">hash函数个数（散列表或者哈希表）</param>
        public BloomFilter(int bloomArrayLength, Int64 dataArrayLength,Int64 hashFunctionCount)
        {
            //1.初始化长度为bloomArrayLength的位数组
            _bloomArray = new BitArray(bloomArrayLength);

            this.BloomArrayLength = bloomArrayLength;
            this.DataArrayLength = dataArrayLength;
            this.HashFunctionCount = hashFunctionCount;
        }

        /// <summary>
        /// 自动计算需要多少哈希函数(散列表)的布隆过滤器（推荐）
        /// </summary>
        /// <param name="bloomArrayLength"></param>
        /// <param name="dataArrayLength"></param>
        public BloomFilter(int bloomArrayLength, int dataArrayLength)
        {
            //1.初始化长度为bloomArrayLength的位数组
            _bloomArray = new BitArray(bloomArrayLength);

            this.BloomArrayLength = bloomArrayLength;
            this.DataArrayLength = dataArrayLength;
            this.HashFunctionCount = OptimalNumberOfHashes(bloomArrayLength, dataArrayLength);
        }

        /// <summary>
        /// 获取哈希码
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        private int GetHashCode(T item)
        {
            return item.GetHashCode();
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="item">可以是字符串或者对象</param>
        public void Add(T item)
        {
            //计算字符串的哈希值
            int hashValue = GetHashCode(item);

            //将哈希值种子放进随机函数
            var random = new Random(hashValue);

            //2.将结果分别映射到位数组中，并设置对应位结果位1
            for (int i = 0; i < HashFunctionCount; i++)
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
        /// <param name="item">可以是字符串或者对象</param>
        /// <returns></returns>
        public bool Exists(T item)
        {
            int hashValue = GetHashCode(item);
            var random = new Random(hashValue);

            for (int i = 0; i < HashFunctionCount; i++)
            {
                if (_bloomArray[random.Next((int)BloomArrayLength - 1)] == false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 检查列表中的任何项是否可能是在集合
        /// 如果布隆过滤器包含列表中的任何一项，返回真
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool ExistsAny(List<T> items)
        {
            foreach (T item in items)
            {
                if (Exists(item))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 检查列表中的所有项目是否都在集合
        /// </summary>
        /// <param name="items"></param>
        /// <returns></returns>
        public bool ExistsAll(List<T> items)
        {
            foreach (T item in items)
            {
                if (Exists(item)==false)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 获取误报概率
        /// 说某个值不存在集合中一定不存在，说某个字符在集合中它可能存在。原因在于可能两个值或者多个值映射的是同一索引位导致这种现象。
        /// </summary>
        /// <returns></returns>
        public double GetFalsePositiveProbability()
        {
            /* m：布隆过滤器的大小个数
             * n：集合个数
             * k：哈希函数个数
             * 误报概率计算公式=(1 - e^(-k * n / m)) ^ k 
             * 
             * Math.Pow（x,y）计算x的y次方
             * Math.Pow(底数,几次方) 例子：Math.Pow(3,3)=27
             * Math.Exp() 计算指数值
             * 
             */
            return Math.Pow(1 - Math.Exp(-HashFunctionCount * (double)DataArrayLength / BloomArrayLength), HashFunctionCount);
        }

        /// <summary>
        /// 计算基于布隆过滤器散列的最佳数量
        /// </summary>
        /// <param name="bloomArraySize">布隆过滤器的大小(m)</param>
        /// <param name="dataArraySize">集合的大小 (n)</param>
        /// <returns></returns>
        public int OptimalNumberOfHashes(int bloomArraySize,int dataArraySize)
        {
            return (int)Math.Ceiling((bloomArraySize / dataArraySize) * Math.Log(2.0));
        }
    }
}