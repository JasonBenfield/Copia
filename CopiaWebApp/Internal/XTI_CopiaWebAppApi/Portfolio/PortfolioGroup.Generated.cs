using XTI_CopiaWebAppApiActions.Portfolio;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Portfolio;
public sealed partial class PortfolioGroup : AppApiGroupWrapper
{
    internal PortfolioGroup(AppApiGroup source, PortfolioGroupBuilder builder) : base(source)
    {
        AddAccount = builder.AddAccount.Build();
        GetAccounts = builder.GetAccounts.Build();
        GetPortfolio = builder.GetPortfolio.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<AddAccountForm, AccountModel> AddAccount { get; }
    public AppApiAction<EmptyRequest, AccountModel[]> GetAccounts { get; }
    public AppApiAction<EmptyRequest, PortfolioModel> GetPortfolio { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}