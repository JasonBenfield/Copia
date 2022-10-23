// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class PortfoliosGroup : AppClientGroup
{
    public PortfoliosGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Portfolios")
    {
        Actions = new PortfoliosGroupActions(AddPortfolio: CreatePostAction<AddPortfolioRequest, PortfolioModel>("AddPortfolio"));
    }

    public PortfoliosGroupActions Actions { get; }

    public Task<PortfolioModel> AddPortfolio(AddPortfolioRequest model, CancellationToken ct = default) => Actions.AddPortfolio.Post("", model, ct);
    public sealed record PortfoliosGroupActions(AppClientPostAction<AddPortfolioRequest, PortfolioModel> AddPortfolio);
}