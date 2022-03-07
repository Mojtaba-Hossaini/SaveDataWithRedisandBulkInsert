using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SaveData.Librarry.Application;
using SaveData.Librarry.Infrastructure;
using SaveData.Librarry.Infrastructure.Contracts;
using StackExchange.Redis;

namespace SaveData.Librarry.ApplicationService;

public class RegisterHandler
{
    //public RegisterHandler()
    //{
    //    var serviceCollection = new ServiceCollection();
    //    serviceCollection.AddScoped<ICache, RedisRepository>();
    //    serviceCollection.AddScoped<IRepository, MSSqlRepository>();
    //    serviceCollection.AddScoped<ICustomerRateHandler, CustomerRateHandler>();
    //    serviceCollection.AddSingleton<IConnectionMultiplexer>(option =>
    //        ConnectionMultiplexer.Connect(ConstValue.RedisConnectionConnectionStrings));
    //    serviceCollection.AddDbContext<CustomerMSSqlContext>(options => options.UseSqlServer(ConstValue.MSSqlServerConnectionStrings));
    //    ServiceProvider = serviceCollection.BuildServiceProvider();
    //}
    public static void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<ICache, RedisRepository>();
        services.AddScoped<IRepository, MSSqlRepository>();
        services.AddScoped<ICustomerRateHandler, CustomerRateHandler>();
        services.AddSingleton<IConnectionMultiplexer>(option =>
            ConnectionMultiplexer.Connect(configuration.GetConnectionString("RedisConnection")));
        services.AddDbContext<CustomerMSSqlContext>(options => options.UseSqlServer(configuration.GetConnectionString("MSSqlServer")));
    }
}
