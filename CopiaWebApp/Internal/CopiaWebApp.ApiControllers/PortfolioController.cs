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
        return View(result.Data.ViewName);
    }
}