using XTI_CopiaWebAppApiActions;
using XTI_CopiaWebAppApiActions.Portfolios;

namespace XTI_CopiaWebAppApi;
partial class CopiaApiExtensions
{
    static partial void AddMoreServices(this IServiceCollection services)
    {
        services.AddScoped<PortfolioFromModifier>();
        services.AddScoped<PortfolioPermissions>();
    }
}