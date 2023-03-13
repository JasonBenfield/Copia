// Generated Code
namespace CopiaWebApp.ApiControllers;
[Authorize]
public sealed partial class ActivityTemplateController : Controller
{
    private readonly CopiaAppApi api;
    public ActivityTemplateController(CopiaAppApi api)
    {
        this.api = api;
    }

    [HttpPost]
    public Task<ResultContainer<TemplateStringModel>> EditTemplateString([FromBody] EditTemplateStringRequest model, CancellationToken ct)
    {
        return api.Group("ActivityTemplate").Action<EditTemplateStringRequest, TemplateStringModel>("EditTemplateString").Execute(model, ct);
    }

    [HttpPost]
    public Task<ResultContainer<ActivityTemplateDetailModel>> GetActivityTemplateDetail([FromBody] GetActivityTemplateRequest model, CancellationToken ct)
    {
        return api.Group("ActivityTemplate").Action<GetActivityTemplateRequest, ActivityTemplateDetailModel>("GetActivityTemplateDetail").Execute(model, ct);
    }
}