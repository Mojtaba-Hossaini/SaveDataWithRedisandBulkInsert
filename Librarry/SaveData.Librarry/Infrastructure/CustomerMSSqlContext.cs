using Microsoft.EntityFrameworkCore;
using SaveData.Librarry.Models;

namespace SaveData.Librarry.Infrastructure;

public class CustomerMSSqlContext : DbContext
{
    public CustomerMSSqlContext(DbContextOptions<CustomerMSSqlContext> options) : base(options)
    {
    }
    public DbSet<CustomerRate> CustomerRates { get; set; }
}
