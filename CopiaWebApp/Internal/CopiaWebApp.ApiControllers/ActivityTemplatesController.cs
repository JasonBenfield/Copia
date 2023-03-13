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
    public Task<ResultContainer<ActivityTemplateDetailModel>> AddActivityTemplate([FromBody] AddActivityTemplateRequest model, CancellationToken ct)
    {
        return api.Group("ActivityTemplates").Action<AddActivityTemplateRequest, ActivityTemplateDetailModel>("AddActivityTemplate").Execute(model, ct);
    }

    [HttpPost]
    public Task<ResultContainer<ActivityTemplateModel[]>> GetActivityTemplates(CancellationToken ct)
    {
        return api.Group("ActivityTemplates").Action<EmptyRequest, ActivityTemplateModel[]>("GetActivityTemplates").Execute(new EmptyRequest(), ct);
    }

    public async Task<IActionResult> Index(CancellationToken ct)
    {
        var result = await api.Group("ActivityTemplates").Action<EmptyRequest, WebViewResult>("Index").Execute(new EmptyRequest(), ct);
        return View(result.Data!.ViewName);
    }
}