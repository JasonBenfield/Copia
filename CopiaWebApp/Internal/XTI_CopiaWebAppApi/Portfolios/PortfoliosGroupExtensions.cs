using XTI_CopiaWebAppApi.Portfolios;

namespace XTI_CopiaWebAppApi;

internal static class PortfoliosGroupExtensions
{
    public static void AddPortfoliosGroupServices(this IServiceCollection services)
    {
        services.AddScoped<PortfolioPermissions>();
        services.AddScoped<AddPortfolioAction>();
        services.AddScoped<AddPortfolioValidation>();
        services.AddScoped<GetPortfoliosAction>();
        services.AddScoped<IndexAction>();
    }
}