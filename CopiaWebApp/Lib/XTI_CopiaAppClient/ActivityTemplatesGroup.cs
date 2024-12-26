// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class ActivityTemplatesGroup : AppClientGroup
{
    public ActivityTemplatesGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "ActivityTemplates")
    {
        Actions = new ActivityTemplatesGroupActions(AddActivityTemplate: CreatePostAction<AddActivityTemplateRequest, ActivityTemplateModel>("AddActivityTemplate"), GetActivityTemplates: CreatePostAction<EmptyRequest, ActivityTemplateModel[]>("GetActivityTemplates"), Index: CreateGetAction<EmptyRequest>("Index"));
    }

    public ActivityTemplatesGroupActions Actions { get; }

    public Task<ActivityTemplateModel> AddActivityTemplate(string modifier, AddActivityTemplateRequest requestData, CancellationToken ct = default) => Actions.AddActivityTemplate.Post(modifier, requestData, ct);
    public Task<ActivityTemplateModel[]> GetActivityTemplates(string modifier, CancellationToken ct = default) => Actions.GetActivityTemplates.Post(modifier, new EmptyRequest(), ct);
    public sealed record ActivityTemplatesGroupActions(AppClientPostAction<AddActivityTemplateRequest, ActivityTemplateModel> AddActivityTemplate, AppClientPostAction<EmptyRequest, ActivityTemplateModel[]> GetActivityTemplates, AppClientGetAction<EmptyRequest> Index);
}