using XTI_CopiaWebAppApiActions.Activities;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class ActivitiesGroupExtensions
{
    internal static void AddActivitiesServices(this IServiceCollection services)
    {
        services.AddScoped<CreateActivityAction>();
        services.AddScoped<IndexAction>();
    }
}