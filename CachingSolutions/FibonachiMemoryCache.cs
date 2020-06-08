using System;
using System.Collections.Generic;
using System.Runtime.Caching;
using System.Text;

namespace CachingSolutions
{
    public class FibonachiMemoryCache : ICache
    {
        MemoryCache Cache = MemoryCache.Default;

        public int? Get(int number)
        {
            if (Cache.Contains(number.ToString()))
            {
                return (int)Cache.Get(number.ToString());
            }

            return null;
        }

        public void Set(int number, int result)
        {
            Cache.Set(number.ToString(), result, DateTime.Now.AddMinutes(10));
        }

        public void Delete(int number)
        {
            if (Cache.Contains(number.ToString()))
            {
                Cache.Remove(number.ToString());
            }
        }
    }
}
