using SaveData.Librarry.Infrastructure;
using SaveData.Librarry.Infrastructure.Contracts;
using SaveData.Librarry.Models;

namespace SaveData.Librarry.Application;

public class MSSqlRepository : IRepository
{
    private readonly CustomerMSSqlContext _context;

    public MSSqlRepository(CustomerMSSqlContext context)
    {
        _context = context;
    }
    public async Task AddList(List<CustomerRate> customerRate)
    {
        await _context.BulkInsertAsync(customerRate);
    }
}
