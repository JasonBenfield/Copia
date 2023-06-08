namespace XTI_CopiaWebAppApi.Activities;

public sealed class ActivitiesGroup : AppApiGroupWrapper
{
    public ActivitiesGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        DoSomething = source.AddAction(nameof(DoSomething), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<EmptyRequest, EmptyActionResult> DoSomething { get; }
}