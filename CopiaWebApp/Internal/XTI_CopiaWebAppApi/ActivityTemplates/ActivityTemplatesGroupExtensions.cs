using XTI_CopiaWebAppApi.ActivityTemplates;

namespace XTI_CopiaWebAppApi;

internal static class ActivityTemplatesGroupExtensions
{
    public static void AddActivityTemplatesGroupServices(this IServiceCollection services)
    {
        services.AddScoped<IndexAction>();
        services.AddScoped<AddActivityTemplateValidation>();
        services.AddScoped<AddActivityTemplateAction>();
        services.AddScoped<GetActivityTemplatesAction>();
    }
}