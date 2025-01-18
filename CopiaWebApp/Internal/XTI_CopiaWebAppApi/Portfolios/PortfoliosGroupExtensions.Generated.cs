using XTI_CopiaWebAppApiActions.Portfolios;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class PortfoliosGroupExtensions
{
    internal static void AddPortfoliosServices(this IServiceCollection services)
    {
        services.AddScoped<AddPortfolioAction>();
        services.AddScoped<AddPortfolioValidation>();
        services.AddScoped<GetPortfoliosAction>();
        services.AddScoped<IndexAction>();
    }
}