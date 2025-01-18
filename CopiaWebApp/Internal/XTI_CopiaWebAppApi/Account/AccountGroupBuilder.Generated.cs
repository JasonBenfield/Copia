using XTI_CopiaWebAppApiActions.Account;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Account;
public sealed partial class AccountGroupBuilder
{
    private readonly AppApiGroup source;
    internal AccountGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        GetAccount = source.AddAction<GetAccountRequest, AccountModel>("GetAccount").WithExecution<GetAccountAction>();
        Index = source.AddAction<GetAccountRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<GetAccountRequest, AccountModel> GetAccount { get; }
    public AppApiActionBuilder<GetAccountRequest, WebViewResult> Index { get; }

    public AccountGroup Build() => new AccountGroup(source, this);
}