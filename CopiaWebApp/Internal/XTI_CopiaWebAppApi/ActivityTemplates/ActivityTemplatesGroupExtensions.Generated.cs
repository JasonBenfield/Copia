using XTI_CopiaWebAppApiActions.ActivityTemplates;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class ActivityTemplatesGroupExtensions
{
    internal static void AddActivityTemplatesServices(this IServiceCollection services)
    {
        services.AddScoped<AddActivityTemplateAction>();
        services.AddScoped<AddActivityTemplateValidation>();
        services.AddScoped<GetActivityTemplatesAction>();
        services.AddScoped<IndexAction>();
    }
}