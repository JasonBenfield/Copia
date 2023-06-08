namespace XTI_CopiaWebAppApi.Activities;

internal sealed class IndexAction : AppAction<EmptyRequest, WebViewResult>
{
    private readonly WebViewResultFactory viewFactory;

    public IndexAction(WebViewResultFactory viewFactory)
    {
        this.viewFactory = viewFactory;
    }

    public Task<WebViewResult> Execute(EmptyRequest model, CancellationToken ct) =>
        Task.FromResult(viewFactory.Default("activities", "Activities"));
}