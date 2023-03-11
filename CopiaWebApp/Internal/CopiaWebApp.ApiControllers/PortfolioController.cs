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
        var result = await api.Group("Portfolio").Action<EmptyRequest, WebViewResult>("Index").Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }

    [HttpPost]
    public Task<ResultContainer<AccountModel>> AddAccount([FromBody] AddAccountForm model, CancellationToken ct)
    {
        return api.Group("Portfolio").Action<AddAccountForm, AccountModel>("AddAccount").Execute(model, ct);
    }

    [HttpPost]
    public Task<ResultContainer<AccountModel[]>> GetAccounts(CancellationToken ct)
    {
        return api.Group("Portfolio").Action<EmptyRequest, AccountModel[]>("GetAccounts").Execute(new EmptyRequest(), ct);
    }

    [HttpPost]
    public Task<ResultContainer<PortfolioModel>> GetPortfolio(CancellationToken ct)
    {
        return api.Group("Portfolio").Action<EmptyRequest, PortfolioModel>("GetPortfolio").Execute(new EmptyRequest(), ct);
    }
}