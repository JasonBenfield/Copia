using XTI_CopiaWebAppApiActions.Home;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class HomeGroupExtensions
{
    internal static void AddHomeServices(this IServiceCollection services)
    {
        services.AddScoped<IndexAction>();
    }
}