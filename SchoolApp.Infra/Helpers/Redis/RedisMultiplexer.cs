using System.Data.Common;
using StackExchange.Redis;

namespace SchoolApp.Infra.Helpers.Redis
{
    public class RedisMultiplexer 
    {
        public IDatabase GetDatabase(string connectionString)
        {
           var muxer = ConnectionMultiplexer.Connect(connectionString);
           return muxer.GetDatabase();
        }
    }
}