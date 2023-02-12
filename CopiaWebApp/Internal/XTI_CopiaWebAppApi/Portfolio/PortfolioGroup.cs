namespace XTI_CopiaWebAppApi.Portfolio;

public sealed class PortfolioGroup : AppApiGroupWrapper
{
    public PortfolioGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        DoSomething = source.AddAction(nameof(DoSomething), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<EmptyRequest, EmptyActionResult> DoSomething { get; }
}