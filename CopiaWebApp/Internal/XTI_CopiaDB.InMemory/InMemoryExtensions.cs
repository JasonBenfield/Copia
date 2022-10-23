using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace XTI_CopiaDB.Extensions;

public static class InMemoryExtensions
{
    public static void AddCopiaDbContextForInMemory(this IServiceCollection services)
    {
        services.AddDbContextFactory<CopiaDbContext>(options =>
        {
            options
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .EnableSensitiveDataLogging();
        });
    }
}