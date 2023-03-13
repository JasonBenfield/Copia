// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class ActivityTemplateGroup : AppClientGroup
{
    public ActivityTemplateGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "ActivityTemplate")
    {
        Actions = new ActivityTemplateGroupActions(EditTemplateString: CreatePostAction<EditTemplateStringRequest, TemplateStringModel>("EditTemplateString"), GetActivityTemplateDetail: CreatePostAction<GetActivityTemplateRequest, ActivityTemplateDetailModel>("GetActivityTemplateDetail"));
    }

    public ActivityTemplateGroupActions Actions { get; }

    public Task<TemplateStringModel> EditTemplateString(string modifier, EditTemplateStringRequest model, CancellationToken ct = default) => Actions.EditTemplateString.Post(modifier, model, ct);
    public Task<ActivityTemplateDetailModel> GetActivityTemplateDetail(string modifier, GetActivityTemplateRequest model, CancellationToken ct = default) => Actions.GetActivityTemplateDetail.Post(modifier, model, ct);
    public sealed record ActivityTemplateGroupActions(AppClientPostAction<EditTemplateStringRequest, TemplateStringModel> EditTemplateString, AppClientPostAction<GetActivityTemplateRequest, ActivityTemplateDetailModel> GetActivityTemplateDetail);
}