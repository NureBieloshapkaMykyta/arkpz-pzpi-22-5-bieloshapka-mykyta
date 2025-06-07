using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class RegisterLayerExtension
{
    public static void AddDataAccess(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSqlServer<AppDbContext>(configuration.GetConnectionString("MasterDatabase"), options => options.EnableRetryOnFailure());
    }
}
