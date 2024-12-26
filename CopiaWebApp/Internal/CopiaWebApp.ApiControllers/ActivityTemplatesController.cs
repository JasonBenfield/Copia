// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class ActivityTemplatesController : Controller
{
    private readonly CopiaAppApi api;
    public ActivityTemplatesController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<ActivityTemplateModel>> AddActivityTemplate([FromBody] AddActivityTemplateRequest requestData, CancellationToken ct)
    {
        return api.ActivityTemplates.AddActivityTemplate.Execute(requestData, ct);
    }

    [HttpPost]
    public Task<ResultContainer<ActivityTemplateModel[]>> GetActivityTemplates(CancellationToken ct)
    {
        return api.ActivityTemplates.GetActivityTemplates.Execute(new EmptyRequest(), ct);
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.ActivityTemplates.Index.Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }
}