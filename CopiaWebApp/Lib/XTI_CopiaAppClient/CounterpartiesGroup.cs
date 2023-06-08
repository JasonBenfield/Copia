// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class CounterpartiesGroup : AppClientGroup
{
    public CounterpartiesGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Counterparties")
    {
        Actions = new CounterpartiesGroupActions(Index: CreateGetAction<EmptyRequest>("Index"), AddCounterparty: CreatePostAction<AddCounterpartyForm, CounterpartyModel>("AddCounterparty"), CounterpartySearch: CreatePostAction<string, CounterpartySearchResult>("CounterpartySearch"), EditCounterparty: CreatePostAction<EditCounterpartyForm, CounterpartyModel>("EditCounterparty"));
    }

    public CounterpartiesGroupActions Actions { get; }

    public Task<CounterpartyModel> AddCounterparty(string modifier, AddCounterpartyForm model, CancellationToken ct = default) => Actions.AddCounterparty.Post(modifier, model, ct);
    public Task<CounterpartySearchResult> CounterpartySearch(string modifier, string model, CancellationToken ct = default) => Actions.CounterpartySearch.Post(modifier, model, ct);
    public Task<CounterpartyModel> EditCounterparty(string modifier, EditCounterpartyForm model, CancellationToken ct = default) => Actions.EditCounterparty.Post(modifier, model, ct);
    public sealed record CounterpartiesGroupActions(AppClientGetAction<EmptyRequest> Index, AppClientPostAction<AddCounterpartyForm, CounterpartyModel> AddCounterparty, AppClientPostAction<string, CounterpartySearchResult> CounterpartySearch, AppClientPostAction<EditCounterpartyForm, CounterpartyModel> EditCounterparty);
}