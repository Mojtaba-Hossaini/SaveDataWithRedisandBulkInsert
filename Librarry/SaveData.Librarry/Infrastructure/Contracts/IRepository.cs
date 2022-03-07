using SaveData.Librarry.Models;

namespace SaveData.Librarry.Infrastructure;

public interface IRepository
{
    Task AddList(List<CustomerRate> customerRate);
}
