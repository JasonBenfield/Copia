using XTI_CopiaWebAppApiActions.Portfolio;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class PortfolioGroupExtensions
{
    internal static void AddPortfolioServices(this IServiceCollection services)
    {
        services.AddScoped<AddAccountAction>();
        services.AddScoped<AddAccountValidation>();
        services.AddScoped<GetAccountsAction>();
        services.AddScoped<GetPortfolioAction>();
        services.AddScoped<IndexAction>();
    }
}