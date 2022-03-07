namespace SaveData.Librarry.Infrastructure.Contracts;

public interface ICache
{
    Task SetOnRedis(List<string> customerRate);
}
