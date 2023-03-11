// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class AccountController : Controller
{
    private readonly CopiaAppApi api;
    public AccountController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<AccountModel>> GetAccount([FromBody] GetAccountRequest model, CancellationToken ct)
    {
        return api.Group("Account").Action<GetAccountRequest, AccountModel>("GetAccount").Execute(model, ct);
    }

    public async Task<IActionResult> Index(GetAccountRequest model, CancellationToken ct)
    {
        var result = await api.Group("Account").Action<GetAccountRequest, WebViewResult>("Index").Execute(model, ct);
        return View(result.Data!.ViewName);
    }
}