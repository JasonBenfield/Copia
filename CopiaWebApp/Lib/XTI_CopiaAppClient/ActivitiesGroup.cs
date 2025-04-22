// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class ActivitiesGroup : AppClientGroup
{
    public ActivitiesGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Activities")
    {
        Actions = new ActivitiesGroupActions(CreateActivity: CreatePostAction<CreateActivityRequest, ActivityModel>("CreateActivity"), Index: CreateGetAction<EmptyRequest>("Index"));
        Configure();
    }

    partial void Configure();
    public ActivitiesGroupActions Actions { get; }

    public Task<ActivityModel> CreateActivity(string modifier, CreateActivityRequest requestData, CancellationToken ct = default) => Actions.CreateActivity.Post(modifier, requestData, ct);
    public sealed record ActivitiesGroupActions(AppClientPostAction<CreateActivityRequest, ActivityModel> CreateActivity, AppClientGetAction<EmptyRequest> Index);
}