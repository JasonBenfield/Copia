using XTI_CopiaWebAppApi.ActivityTemplate;

namespace XTI_CopiaWebAppApi;

internal static class ActivityTemplateGroupExtensions
{
    public static void AddActivityTemplateGroupServices(this IServiceCollection services)
    {
        services.AddScoped<EditTemplateStringAction>();
        services.AddScoped<GetActivityTemplateDetailAction>();
    }
}