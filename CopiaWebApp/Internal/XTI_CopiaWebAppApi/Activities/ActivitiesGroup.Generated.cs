using XTI_CopiaWebAppApiActions.Activities;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Activities;
public sealed partial class ActivitiesGroup : AppApiGroupWrapper
{
    internal ActivitiesGroup(AppApiGroup source, ActivitiesGroupBuilder builder) : base(source)
    {
        CreateActivity = builder.CreateActivity.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<CreateActivityRequest, ActivityModel> CreateActivity { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}