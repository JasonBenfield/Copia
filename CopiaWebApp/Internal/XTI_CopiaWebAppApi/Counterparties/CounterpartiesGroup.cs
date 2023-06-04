using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Counterparties;

public sealed class CounterpartiesGroup : AppApiGroupWrapper
{
    public CounterpartiesGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
        AddCounterparty = source.AddAction(nameof(AddCounterparty), () => sp.GetRequiredService<AddCounterpartyAction>());
        CounterpartySearch = source.AddAction(nameof(CounterpartySearch), () => sp.GetRequiredService<CounterpartySearchAction>());
    }

    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
    public AppApiAction<AddCounterpartyForm, CounterpartyModel> AddCounterparty { get; }
    public AppApiAction<string, CounterpartySearchResult> CounterpartySearch { get; }
}