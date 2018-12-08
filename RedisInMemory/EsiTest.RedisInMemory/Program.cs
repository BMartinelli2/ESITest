using System;
using System.Linq.Expressions;
using StackExchange.Redis;

namespace EsiTest.RedisInMemory
{
    class Program
    {
        private const string ConnectionStringKey = "REDIS_CONNECTION_STRING";
        static void Main(string[] args)
        {
            string redisConnectionString = Environment.GetEnvironmentVariable(ConnectionStringKey);

            try
            {   
                IDataCacheProvider cacheProvider = new RedisCacheProvider();
                cacheProvider.ConnectToCache(redisConnectionString);

                RedisCacheTester tester = new RedisCacheTester(cacheProvider);

                Console.WriteLine("Press any key to attempt to cache / retrieve 100 items.");
                Console.ReadKey();
                tester.CreateAndCacheRandomValues();
                Console.WriteLine("Cache complete, press any key to continue to read and validate values in cache.");
                Console.ReadKey();
                tester.ValidateCache();
                Console.WriteLine("Readout completed, press any key to exit.");
                Console.ReadKey();
            }
            catch (RedisConnectionException)
            {
                Console.WriteLine("Unable to connect to redis cache, please ensure container is running.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Unknown exception occurred :");
                Console.Write(ex.Message);
            }

            
        }
    }
}
