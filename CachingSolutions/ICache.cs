using System;
using System.Collections.Generic;
using System.Text;

namespace CachingSolutions
{
    public interface ICache
    {
        int? Get(int number);
        void Set(int number, int result);
        void Delete(int number);
    }
}
