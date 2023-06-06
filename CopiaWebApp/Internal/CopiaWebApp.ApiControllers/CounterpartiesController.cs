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
        var result = await api.Group("Counterparties").Action<EmptyRequest, WebViewResult>("Index").Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }

    [HttpPost]
    public Task<ResultContainer<CounterpartyModel>> AddCounterparty([FromBody] AddCounterpartyForm model, CancellationToken ct)
    {
        return api.Group("Counterparties").Action<AddCounterpartyForm, CounterpartyModel>("AddCounterparty").Execute(model, ct);
    }

    [HttpPost]
    public Task<ResultContainer<CounterpartySearchResult>> CounterpartySearch([FromBody] string model, CancellationToken ct)
    {
        return api.Group("Counterparties").Action<string, CounterpartySearchResult>("CounterpartySearch").Execute(model, ct);
    }
}