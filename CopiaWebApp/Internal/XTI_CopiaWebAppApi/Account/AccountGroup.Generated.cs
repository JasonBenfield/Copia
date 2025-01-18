using XTI_CopiaWebAppApiActions.Account;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Account;
public sealed partial class AccountGroup : AppApiGroupWrapper
{
    internal AccountGroup(AppApiGroup source, AccountGroupBuilder builder) : base(source)
    {
        GetAccount = builder.GetAccount.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<GetAccountRequest, AccountModel> GetAccount { get; }
    public AppApiAction<GetAccountRequest, WebViewResult> Index { get; }
}