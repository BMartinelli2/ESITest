using System;
using System.Collections.Generic;

namespace EsiTest.RedisInMemory
{
    public class RedisCacheTester
    {
        private readonly IDataCacheProvider _provider;
        private List<(Guid, string)> _valuesToTest = new List<(Guid, string)>();

        public RedisCacheTester(IDataCacheProvider provider)
        {
            _provider = provider;
            
        }

        public void CreateAndCacheRandomValues()
        {
            int counter = 0;
            while (counter < 100)
            {
                Guid guidKey = Guid.NewGuid();
                _valuesToTest.Add((guidKey, guidKey.ToString("N")));
                _provider.PutValue(guidKey.ToString("B"), guidKey.ToString("N"));
                counter++;
            }
        }

        public void ValidateCache()
        {
            foreach (var testValue in _valuesToTest)
            {
                string cachedValue = _provider.GetValue(testValue.Item1.ToString("B"));

                if (cachedValue.CompareTo(testValue.Item2) != 0)
                {
                    Console.ForegroundColor = ConsoleColor.DarkRed;
                }

                Console.WriteLine($"Cached Value: {cachedValue} -- Cached Key: {testValue.Item1} -- Expected Item: {testValue.Item2}");
                Console.ResetColor();

            }
        }




    }
}