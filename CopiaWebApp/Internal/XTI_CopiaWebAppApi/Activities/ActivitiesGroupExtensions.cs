using XTI_CopiaWebAppApi.Activities;

namespace XTI_CopiaWebAppApi;

internal static class ActivitiesGroupExtensions
{
    public static void AddActivitiesGroupServices(this IServiceCollection services)
    {
        services.AddScoped<CreateActivityAction>();
        services.AddScoped<IndexAction>();
    }
}