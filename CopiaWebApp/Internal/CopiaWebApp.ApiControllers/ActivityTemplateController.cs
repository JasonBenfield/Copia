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
    public Task<ResultContainer<ActivityTemplateModel>> GetActivityTemplate([FromBody] GetActivityTemplateRequest requestData, CancellationToken ct)
    {
        return api.ActivityTemplate.GetActivityTemplate.Execute(requestData, ct);
    }
}