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
    public Task<ResultContainer<PortfolioModel>> AddPortfolio([FromBody] AddPortfolioRequest model, CancellationToken ct)
    {
        return api.Group("Portfolios").Action<AddPortfolioRequest, PortfolioModel>("AddPortfolio").Execute(model, ct);
    }

    [HttpPost]
    public Task<ResultContainer<PortfolioModel[]>> GetPortfolios(CancellationToken ct)
    {
        return api.Group("Portfolios").Action<EmptyRequest, PortfolioModel[]>("GetPortfolios").Execute(new EmptyRequest(), ct);
    }
}