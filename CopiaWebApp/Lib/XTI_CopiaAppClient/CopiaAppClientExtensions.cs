// Generated Code
using Microsoft.Extensions.DependencyInjection;

namespace XTI_CopiaAppClient;
public static class CopiaAppClientExtensions
{
    public static void AddCopiaAppClient(this IServiceCollection services)
    {
        services.AddScoped<CopiaAppClientFactory>();
        services.AddScoped(sp => sp.GetRequiredService<CopiaAppClientFactory>().Create());
        services.AddScoped<CopiaAppClientVersion>();
    }
}