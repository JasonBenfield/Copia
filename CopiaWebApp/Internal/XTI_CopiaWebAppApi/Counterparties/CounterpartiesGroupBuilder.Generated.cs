using XTI_CopiaWebAppApiActions.Counterparties;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Counterparties;
public sealed partial class CounterpartiesGroupBuilder
{
    private readonly AppApiGroup source;
    internal CounterpartiesGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        AddCounterparty = source.AddAction<AddCounterpartyForm, CounterpartyModel>("AddCounterparty").WithExecution<AddCounterpartyAction>();
        CounterpartySearch = source.AddAction<string, CounterpartySearchResult>("CounterpartySearch").WithExecution<CounterpartySearchAction>();
        DeleteCounterparty = source.AddAction<int, EmptyActionResult>("DeleteCounterparty").WithExecution<DeleteCounterpartyAction>();
        EditCounterparty = source.AddAction<EditCounterpartyForm, CounterpartyModel>("EditCounterparty").WithExecution<EditCounterpartyAction>();
        Index = source.AddAction<EmptyRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<AddCounterpartyForm, CounterpartyModel> AddCounterparty { get; }
    public AppApiActionBuilder<string, CounterpartySearchResult> CounterpartySearch { get; }
    public AppApiActionBuilder<int, EmptyActionResult> DeleteCounterparty { get; }
    public AppApiActionBuilder<EditCounterpartyForm, CounterpartyModel> EditCounterparty { get; }
    public AppApiActionBuilder<EmptyRequest, WebViewResult> Index { get; }

    public CounterpartiesGroup Build() => new CounterpartiesGroup(source, this);
}