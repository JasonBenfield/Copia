using XTI_CopiaWebAppApiActions.Portfolio;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Portfolio;
public sealed partial class PortfolioGroupBuilder
{
    private readonly AppApiGroup source;
    internal PortfolioGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        AddAccount = source.AddAction<AddAccountForm, AccountModel>("AddAccount").WithExecution<AddAccountAction>().WithValidation<AddAccountValidation>();
        GetAccounts = source.AddAction<EmptyRequest, AccountModel[]>("GetAccounts").WithExecution<GetAccountsAction>();
        GetPortfolio = source.AddAction<EmptyRequest, PortfolioModel>("GetPortfolio").WithExecution<GetPortfolioAction>();
        Index = source.AddAction<EmptyRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<AddAccountForm, AccountModel> AddAccount { get; }
    public AppApiActionBuilder<EmptyRequest, AccountModel[]> GetAccounts { get; }
    public AppApiActionBuilder<EmptyRequest, PortfolioModel> GetPortfolio { get; }
    public AppApiActionBuilder<EmptyRequest, WebViewResult> Index { get; }

    public PortfolioGroup Build() => new PortfolioGroup(source, this);
}