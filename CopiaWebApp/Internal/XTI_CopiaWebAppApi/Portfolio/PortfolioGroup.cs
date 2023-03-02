namespace XTI_CopiaWebAppApi.Portfolio;

public sealed class PortfolioGroup : AppApiGroupWrapper
{
    public PortfolioGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}