// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class ActivitiesController : Controller
{
    private readonly CopiaAppApi api;
    public ActivitiesController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<ActivityDetailModel>> CreateActivity([FromBody] CreateActivityRequest model, CancellationToken ct)
    {
        return api.Group("Activities").Action<CreateActivityRequest, ActivityDetailModel>("CreateActivity").Execute(model, ct);
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Group("Activities").Action<EmptyRequest, WebViewResult>("Index").Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }
}