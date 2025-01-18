using XTI_CopiaWebAppApiActions.Account;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class AccountGroupExtensions
{
    internal static void AddAccountServices(this IServiceCollection services)
    {
        services.AddScoped<GetAccountAction>();
        services.AddScoped<IndexAction>();
    }
}