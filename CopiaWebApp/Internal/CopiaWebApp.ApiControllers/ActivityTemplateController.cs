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
    public Task<ResultContainer<ActivityTemplateModel>> GetActivityTemplate([FromBody] GetActivityTemplateRequest model, CancellationToken ct)
    {
        return api.Group("ActivityTemplate").Action<GetActivityTemplateRequest, ActivityTemplateModel>("GetActivityTemplate").Execute(model, ct);
    }
}