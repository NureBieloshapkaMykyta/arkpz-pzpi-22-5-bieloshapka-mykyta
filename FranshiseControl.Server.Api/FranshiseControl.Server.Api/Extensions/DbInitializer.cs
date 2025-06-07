using DataAccess;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FranshiseControl.Server.Api.Extensions;

public static class DbInitializer
{
    public static async Task InitDb(this WebApplication app)
    {
        var scope = app.Services.CreateScope();
        var dbContext = (AppDbContext)scope.ServiceProvider.GetRequiredService(typeof(AppDbContext));

        await dbContext.Database.MigrateAsync();
    }
}
