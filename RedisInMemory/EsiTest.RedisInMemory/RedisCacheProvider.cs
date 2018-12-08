using System;
using System.Collections.Generic;
using StackExchange.Redis;

namespace EsiTest.RedisInMemory
{
    public class RedisCacheProvider : IDataCacheProvider, IDisposable
    {
        private ConnectionMultiplexer _redisMultiplexer;
        private IDatabase _cacheDatabase;

        public void ConnectToCache(string connectionString)
        {
            _redisMultiplexer = ConnectionMultiplexer.Connect(connectionString);
            _cacheDatabase = _redisMultiplexer.GetDatabase();

        }

        public string GetValue(string key)
        {
            return _cacheDatabase.StringGet(key);
        }

        public void PutValue(string key, string value)
        {
            _cacheDatabase.StringSet(key, value);
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _cacheDatabase = null;
                _redisMultiplexer.Dispose();
            }
        }
    }
}