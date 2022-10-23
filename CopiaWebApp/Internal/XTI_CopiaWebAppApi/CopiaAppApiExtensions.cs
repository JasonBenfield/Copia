namespace XTI_CopiaWebAppApi;

public static class CopiaAppApiExtensions
{
    public static void AddCopiaAppApiServices(this IServiceCollection services)
    {
        services.AddHomeGroupServices();
        services.AddPortfoliosGroupServices();
    }
}