using XTI_CopiaWebAppApi.Portfolios;

namespace XTI_CopiaWebAppApi;

internal static class PortfoliosGroupExtensions
{
    public static void AddPortfoliosGroupServices(this IServiceCollection services)
    {
        services.AddScoped<AddPortfolioAction>();
    }
}