using XTI_CopiaWebAppApiActions.Counterparties;

// Generated Code
namespace XTI_CopiaWebAppApi;
internal static partial class CounterpartiesGroupExtensions
{
    internal static void AddCounterpartiesServices(this IServiceCollection services)
    {
        services.AddScoped<AddCounterpartyAction>();
        services.AddScoped<CounterpartySearchAction>();
        services.AddScoped<DeleteCounterpartyAction>();
        services.AddScoped<EditCounterpartyAction>();
        services.AddScoped<IndexAction>();
    }
}