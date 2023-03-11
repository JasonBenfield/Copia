// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class PortfolioGroup : AppClientGroup
{
    public PortfolioGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Portfolio")
    {
        Actions = new PortfolioGroupActions(Index: CreateGetAction<EmptyRequest>("Index"), AddAccount: CreatePostAction<AddAccountForm, AccountModel>("AddAccount"), GetAccounts: CreatePostAction<EmptyRequest, AccountModel[]>("GetAccounts"), GetPortfolio: CreatePostAction<EmptyRequest, PortfolioModel>("GetPortfolio"));
    }

    public PortfolioGroupActions Actions { get; }

    public Task<AccountModel> AddAccount(string modifier, AddAccountForm model, CancellationToken ct = default) => Actions.AddAccount.Post(modifier, model, ct);
    public Task<AccountModel[]> GetAccounts(string modifier, CancellationToken ct = default) => Actions.GetAccounts.Post(modifier, new EmptyRequest(), ct);
    public Task<PortfolioModel> GetPortfolio(string modifier, CancellationToken ct = default) => Actions.GetPortfolio.Post(modifier, new EmptyRequest(), ct);
    public sealed record PortfolioGroupActions(AppClientGetAction<EmptyRequest> Index, AppClientPostAction<AddAccountForm, AccountModel> AddAccount, AppClientPostAction<EmptyRequest, AccountModel[]> GetAccounts, AppClientPostAction<EmptyRequest, PortfolioModel> GetPortfolio);
}