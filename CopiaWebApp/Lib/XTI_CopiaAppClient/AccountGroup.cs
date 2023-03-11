// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class AccountGroup : AppClientGroup
{
    public AccountGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Account")
    {
        Actions = new AccountGroupActions(GetAccount: CreatePostAction<GetAccountRequest, AccountModel>("GetAccount"), Index: CreateGetAction<GetAccountRequest>("Index"));
    }

    public AccountGroupActions Actions { get; }

    public Task<AccountModel> GetAccount(string modifier, GetAccountRequest model, CancellationToken ct = default) => Actions.GetAccount.Post(modifier, model, ct);
    public sealed record AccountGroupActions(AppClientPostAction<GetAccountRequest, AccountModel> GetAccount, AppClientGetAction<GetAccountRequest> Index);
}