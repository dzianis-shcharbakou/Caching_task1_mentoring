using StackExchange.Redis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;

namespace CachingSolutions
{
    public class FibonachiRedisCache : ICache
    {
        private ConnectionMultiplexer redisConnection;
        string prefix = "Cache_FibonachiRedis";
        DataContractSerializer serializer = new DataContractSerializer(
            typeof(int));

        public FibonachiRedisCache(string hostName, int port)
        {
            ConfigurationOptions options = new ConfigurationOptions()
            {
                EndPoints = { { hostName, port } },
                AllowAdmin = true,
                ConnectTimeout = 60 * 1000,
            };

            redisConnection = ConnectionMultiplexer.Connect(options);
        }

        public void Delete(int number)
        {
            var db = redisConnection.GetDatabase();
            db.KeyDelete(prefix + number.ToString());
        }

        public int? Get(int number)
        {
            var db = redisConnection.GetDatabase();
            int? s = (int?)db.StringGet(prefix + number.ToString());
            if (s.HasValue)
                return s.Value;

            return null;
        }

        public void Set(int number, int result)
        {
            var db = redisConnection.GetDatabase();

            db.StringSet(prefix + number.ToString(), result);

        }
    }
}
