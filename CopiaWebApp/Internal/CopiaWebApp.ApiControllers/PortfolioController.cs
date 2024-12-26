// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class PortfolioController : Controller
{
    private readonly CopiaAppApi api;
    public PortfolioController(CopiaAppApi api)
    {
        this.api = api;
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Portfolio.Index.Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }

    [HttpPost]
    public Task<ResultContainer<AccountModel>> AddAccount([FromBody] AddAccountForm requestData, CancellationToken ct)
    {
        return api.Portfolio.AddAccount.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<AccountModel[]>> GetAccounts(CancellationToken ct)
    {
        return api.Portfolio.GetAccounts.Execute(new EmptyRequest(), ct);
    }

    [HttpPost]
    public Task<ResultContainer<PortfolioModel>> GetPortfolio(CancellationToken ct)
    {
        return api.Portfolio.GetPortfolio.Execute(new EmptyRequest(), ct);
    }
}