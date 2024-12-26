// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class CounterpartiesController : Controller
{
    private readonly CopiaAppApi api;
    public CounterpartiesController(CopiaAppApi api)
    {
        this.api = api;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Counterparties.Index.Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }

    [HttpPost]
    public Task<ResultContainer<CounterpartyModel>> AddCounterparty([FromBody] AddCounterpartyForm requestData, CancellationToken ct)
    {
        return api.Counterparties.AddCounterparty.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<CounterpartySearchResult>> CounterpartySearch([FromBody] string requestData, CancellationToken ct)
    {
        return api.Counterparties.CounterpartySearch.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<EmptyActionResult>> DeleteCounterparty([FromBody] int requestData, CancellationToken ct)
    {
        return api.Counterparties.DeleteCounterparty.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<CounterpartyModel>> EditCounterparty([FromBody] EditCounterpartyForm requestData, CancellationToken ct)
    {
        return api.Counterparties.EditCounterparty.Execute(requestData, ct);
    }
}