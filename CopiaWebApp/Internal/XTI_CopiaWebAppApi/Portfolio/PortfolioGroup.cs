using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolio;

public sealed class PortfolioGroup : AppApiGroupWrapper
{
    public PortfolioGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        Index = source.AddAction(nameof(Index), () => sp.GetRequiredService<IndexAction>());
        AddAccount = source.AddAction
        (
            nameof(AddAccount),
            () => sp.GetRequiredService<AddAccountAction>(),
            () => sp.GetRequiredService<AddAccountValidation>()
        );
        GetAccounts = source.AddAction(nameof(GetAccounts), () => sp.GetRequiredService<GetAccountsAction>());
        GetPortfolio = source.AddAction(nameof(GetPortfolio), () => sp.GetRequiredService<GetPortfolioAction>());
    }

    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
    public AppApiAction<AddAccountForm, AccountModel> AddAccount { get; }
    public AppApiAction<EmptyRequest, AccountModel[]> GetAccounts { get; }
    public AppApiAction<EmptyRequest, PortfolioModel> GetPortfolio { get; }
}