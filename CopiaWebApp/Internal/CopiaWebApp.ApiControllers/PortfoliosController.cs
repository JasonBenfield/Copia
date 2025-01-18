// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class PortfoliosController : Controller
{
    private readonly CopiaAppApi api;
    public PortfoliosController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<PortfolioModel>> AddPortfolio([FromBody] AddPortfolioRequest requestData, CancellationToken ct)
    {
        return api.Portfolios.AddPortfolio.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<PortfolioModel[]>> GetPortfolios(CancellationToken ct)
    {
        return api.Portfolios.GetPortfolios.Execute(new EmptyRequest(), ct);
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Portfolios.Index.Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }
}