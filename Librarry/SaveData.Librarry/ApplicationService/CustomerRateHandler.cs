using Microsoft.Extensions.Configuration;
using SaveData.Librarry.Helper;
using SaveData.Librarry.Infrastructure;
using SaveData.Librarry.Infrastructure.Contracts;
using SaveData.Librarry.Models;

namespace SaveData.Librarry.ApplicationService;

public class CustomerRateHandler : ICustomerRateHandler
{
    private readonly ICache _cache;
    private readonly IRepository _repo;
    private readonly IConfiguration configuration;

    public CustomerRateHandler(ICache cache, IRepository repo, IConfiguration configuration)
    {
        _cache = cache;
        _repo = repo;
        this.configuration = configuration;
    }
    public async Task Handle()
    {
        var customerList = ExcellOperation.Read(configuration.GetSection("CustomerFilePath").Value);
        var customerRates = new List<CustomerRate>();
        await _cache.SetOnRedis(customerList);

        foreach (var item in customerList)
        {
            var custmerRate = new CustomerRate { Rate = item };
            customerRates.Add(custmerRate);
        }
        await _repo.AddList(customerRates);
    }
}
