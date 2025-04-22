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
    public Task<ResultContainer<ActivityModel>> CreateActivity([FromBody] CreateActivityRequest requestData, CancellationToken ct)
    {
        return api.Activities.CreateActivity.Execute(requestData, ct);
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Activities.Index.Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }
}