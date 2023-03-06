using XTI_CopiaWebAppApi.Portfolio;

namespace XTI_CopiaWebAppApi;

internal static class PortfolioGroupExtensions
{
    public static void AddPortfolioGroupServices(this IServiceCollection services)
    {
        services.AddScoped<IndexAction>();
        services.AddScoped<AddAccountAction>();
        services.AddScoped<AddAccountValidation>();
    }
}