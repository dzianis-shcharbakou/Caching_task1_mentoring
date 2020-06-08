using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSolutions
{
    public class Fibonachi
    {
        ICache Cache;
        public Fibonachi(ICache appCache)
        {
            this.Cache = appCache;
        }

        public int Fibonacci(int n)
        {
            var result = this.Cache.Get(n);

            if (result == null)
            {

                int a = 0;
                int b = 1;
                int tmp;

                for (int i = 0; i < n; i++)
                {
                    tmp = a;
                    a = b;
                    b += tmp;
                }

                this.Cache.Set(n, a);
                Console.WriteLine($"Result doesn't from cache: {a}");
                return a;
            }

            Console.WriteLine($"Result from cache: {result.Value}");
            return result.Value;
        }

        public void DeleteFromCache(int n)
        {
            this.Cache.Delete(n);
        }
    }
}
