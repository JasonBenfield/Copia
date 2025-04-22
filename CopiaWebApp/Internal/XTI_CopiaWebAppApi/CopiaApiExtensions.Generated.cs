// Generated Code
namespace XTI_CopiaWebAppApi;
public static partial class CopiaApiExtensions
{
    public static void AddCopiaAppApiServices(this IServiceCollection services)
    {
        services.AddAccountServices();
        services.AddActivitiesServices();
        services.AddCounterpartiesServices();
        services.AddHomeServices();
        services.AddPortfolioServices();
        services.AddPortfoliosServices();
        services.AddScoped<AppApiFactory, CopiaAppApiFactory>();
        services.AddMoreServices();
    }

    static partial void AddMoreServices(this IServiceCollection services);
}