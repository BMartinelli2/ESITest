namespace EsiTest.RedisInMemory
{
    public interface IDataCacheProvider
    {
        void ConnectToCache(string connectionString);

        string GetValue(string key);

        void PutValue(string key, string value);
    }
}