using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Activities;

public sealed class ActivitiesGroup : AppApiGroupWrapper
{
    public ActivitiesGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        CreateActivity = source.AddAction(nameof(CreateActivity), () => sp.GetRequiredService<CreateActivityAction>());
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<CreateActivityRequest, ActivityDetailModel> CreateActivity { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}