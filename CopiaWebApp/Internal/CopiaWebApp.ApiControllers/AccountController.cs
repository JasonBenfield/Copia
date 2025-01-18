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
    public Task<ResultContainer<AccountModel>> GetAccount([FromBody] GetAccountRequest requestData, CancellationToken ct)
    {
        return api.Account.GetAccount.Execute(requestData, ct);
    }

    public async Task<IActionResult> Index(GetAccountRequest requestData, CancellationToken ct)
    {
        var result = await api.Account.Index.Execute(requestData, ct);
        return View(result.Data!.ViewName);
    }
}