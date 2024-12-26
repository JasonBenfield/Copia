// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class ActivitiesGroup : AppClientGroup
{
    public ActivitiesGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Activities")
    {
        Actions = new ActivitiesGroupActions(CreateActivity: CreatePostAction<CreateActivityRequest, ActivityDetailModel>("CreateActivity"), Index: CreateGetAction<EmptyRequest>("Index"));
    }

    public ActivitiesGroupActions Actions { get; }

    public Task<ActivityDetailModel> CreateActivity(string modifier, CreateActivityRequest model, CancellationToken ct = default) => Actions.CreateActivity.Post(modifier, model, ct);
    public sealed record ActivitiesGroupActions(AppClientPostAction<CreateActivityRequest, ActivityDetailModel> CreateActivity, AppClientGetAction<EmptyRequest> Index);
}