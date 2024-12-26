namespace XTI_CopiaWebAppApi;

public static class CopiaAppApiExtensions
{
    public static void AddCopiaAppApiServices(this IServiceCollection services)
    {
        services.AddAccountGroupServices();
        services.AddActivitiesGroupServices();
        services.AddActivityTemplateGroupServices();
        services.AddActivityTemplatesGroupServices();
        services.AddCounterpartiesGroupServices();
        services.AddHomeGroupServices();
        services.AddPortfolioGroupServices();
        services.AddPortfoliosGroupServices();
    }
}