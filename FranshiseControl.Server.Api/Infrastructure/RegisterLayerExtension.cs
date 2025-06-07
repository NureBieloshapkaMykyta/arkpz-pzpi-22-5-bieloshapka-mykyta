using Azure.Identity;
using Microsoft.Extensions.Azure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static class RegisterLayerExtension
{
    public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAzureClients(options =>
        {
            options.AddBlobServiceClient(configuration.GetConnectionString("Storage:Blob"));
            options.AddQueueServiceClient(configuration.GetConnectionString("Storage:Queue")).ConfigureOptions(options =>
            {
                options.MessageEncoding = Azure.Storage.Queues.QueueMessageEncoding.Base64;
            });
        });
    }
}
