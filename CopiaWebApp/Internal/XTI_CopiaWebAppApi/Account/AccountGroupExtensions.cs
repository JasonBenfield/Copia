using XTI_CopiaWebAppApi.Account;

namespace XTI_CopiaWebAppApi;

internal static class AccountGroupExtensions
{
    public static void AddAccountGroupServices(this IServiceCollection services)
    {
        services.AddScoped<GetAccountAction>();
        services.AddScoped<IndexAction>();
    }
}