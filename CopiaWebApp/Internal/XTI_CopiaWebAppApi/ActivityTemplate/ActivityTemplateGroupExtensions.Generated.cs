using XTI_CopiaWebAppApiActions.ActivityTemplate;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class ActivityTemplateGroupExtensions
{
    internal static void AddActivityTemplateServices(this IServiceCollection services)
    {
        services.AddScoped<GetActivityTemplateAction>();
    }
}