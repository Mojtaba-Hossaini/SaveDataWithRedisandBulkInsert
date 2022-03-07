using SaveData.Librarry.Infrastructure.Contracts;
using StackExchange.Redis;

namespace SaveData.Librarry.Application;

public class RedisRepository : ICache
{
    private readonly IConnectionMultiplexer _redis;
    public RedisRepository(IConnectionMultiplexer redis)
    {
        _redis = redis;
    }
    public async Task SetOnRedis(List<string> customerRate)
    {
        var db = _redis.GetDatabase();
        for (int i = 0; i < customerRate.Count; i++)
        {
            await db.StringSetAsync($"Customer {i}", customerRate[i]);
        }
    }
}
