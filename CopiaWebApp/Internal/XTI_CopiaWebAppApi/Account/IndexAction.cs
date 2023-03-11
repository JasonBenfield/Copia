using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Account;

internal sealed class IndexAction : AppAction<GetAccountRequest, WebViewResult>
{
    private readonly WebViewResultFactory viewFactory;

    public IndexAction(WebViewResultFactory viewFactory)
    {
        this.viewFactory = viewFactory;
    }

    public Task<WebViewResult> Execute(GetAccountRequest model, CancellationToken ct) =>
        Task.FromResult(viewFactory.Default("account", "Account"));
}