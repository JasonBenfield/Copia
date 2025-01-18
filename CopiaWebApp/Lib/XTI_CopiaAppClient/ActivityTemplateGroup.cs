// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class ActivityTemplateGroup : AppClientGroup
{
    public ActivityTemplateGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "ActivityTemplate")
    {
        Actions = new ActivityTemplateGroupActions(GetActivityTemplate: CreatePostAction<GetActivityTemplateRequest, ActivityTemplateModel>("GetActivityTemplate"));
        Configure();
    }

    partial void Configure();
    public ActivityTemplateGroupActions Actions { get; }

    public Task<ActivityTemplateModel> GetActivityTemplate(string modifier, GetActivityTemplateRequest requestData, CancellationToken ct = default) => Actions.GetActivityTemplate.Post(modifier, requestData, ct);
    public sealed record ActivityTemplateGroupActions(AppClientPostAction<GetActivityTemplateRequest, ActivityTemplateModel> GetActivityTemplate);
}