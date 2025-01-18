using XTI_CopiaWebAppApiActions.Counterparties;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Counterparties;
public sealed partial class CounterpartiesGroup : AppApiGroupWrapper
{
    internal CounterpartiesGroup(AppApiGroup source, CounterpartiesGroupBuilder builder) : base(source)
    {
        AddCounterparty = builder.AddCounterparty.Build();
        CounterpartySearch = builder.CounterpartySearch.Build();
        DeleteCounterparty = builder.DeleteCounterparty.Build();
        EditCounterparty = builder.EditCounterparty.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<AddCounterpartyForm, CounterpartyModel> AddCounterparty { get; }
    public AppApiAction<string, CounterpartySearchResult> CounterpartySearch { get; }
    public AppApiAction<int, EmptyActionResult> DeleteCounterparty { get; }
    public AppApiAction<EditCounterpartyForm, CounterpartyModel> EditCounterparty { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}