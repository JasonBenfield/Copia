using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Account;

public sealed class AccountGroup : AppApiGroupWrapper
{
    public AccountGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        GetAccount = source.AddAction(nameof(GetAccount), () => sp.GetRequiredService<GetAccountAction>());
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
    }

    public AppApiAction<GetAccountRequest, AccountModel> GetAccount { get; }
    public AppApiAction<GetAccountRequest, WebViewResult> Index { get; }
}