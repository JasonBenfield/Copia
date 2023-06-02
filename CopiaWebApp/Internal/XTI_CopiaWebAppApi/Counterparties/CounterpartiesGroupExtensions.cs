using XTI_CopiaWebAppApi.Counterparties;

namespace XTI_CopiaWebAppApi;

internal static class CounterpartiesGroupExtensions
{
    public static void AddCounterpartiesGroupServices(this IServiceCollection services)
    {
        services.AddScoped<AddCounterpartyAction>();
        services.AddScoped<IndexAction>();
    }
}