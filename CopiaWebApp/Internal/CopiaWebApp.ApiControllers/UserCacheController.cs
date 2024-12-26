// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class UserCacheController : Controller
{
    private readonly CopiaAppApi api;
    public UserCacheController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<EmptyActionResult>> ClearCache([FromBody] string requestData, CancellationToken ct)
    {
        return api.UserCache.ClearCache.Execute(requestData, ct);
    }
}