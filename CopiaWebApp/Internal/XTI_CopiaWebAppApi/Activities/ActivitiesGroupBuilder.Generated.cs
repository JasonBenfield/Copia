using XTI_CopiaWebAppApiActions.Activities;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Activities;
public sealed partial class ActivitiesGroupBuilder
{
    private readonly AppApiGroup source;
    internal ActivitiesGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        CreateActivity = source.AddAction<CreateActivityRequest, ActivityModel>("CreateActivity").WithExecution<CreateActivityAction>();
        Index = source.AddAction<EmptyRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<CreateActivityRequest, ActivityModel> CreateActivity { get; }
    public AppApiActionBuilder<EmptyRequest, WebViewResult> Index { get; }

    public ActivitiesGroup Build() => new ActivitiesGroup(source, this);
}