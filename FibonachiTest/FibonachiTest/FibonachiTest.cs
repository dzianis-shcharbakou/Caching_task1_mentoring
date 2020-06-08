using CachingSolutions;
using NUnit.Framework;
using System.Runtime.Caching;

namespace FibonachiTest
{
    public class Tests
    {
        Fibonachi fibonachiMemoryCache;
        Fibonachi fibonachiRedisCache;

        [SetUp]
        public void Setup()
        {
            fibonachiMemoryCache = new Fibonachi(new FibonachiMemoryCache());
            fibonachiRedisCache = new Fibonachi(new FibonachiRedisCache("localhost", 6379));

            fibonachiRedisCache.DeleteFromCache(7);
        }

        [Test]
        public void MemoryCacheTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var res1 = fibonachiMemoryCache.Fibonacci(8);
            }

            Assert.Pass();
        }

        [Test]
        public void RedisCacheTest()
        {
            for (int i = 0; i < 10; i++)
            {
                var res1 = fibonachiRedisCache.Fibonacci(7);
            }

            Assert.Pass();
        }
    }
}