// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class PortfoliosGroup : AppClientGroup
{
    public PortfoliosGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Portfolios")
    {
        Actions = new PortfoliosGroupActions(AddPortfolio: CreatePostAction<AddPortfolioRequest, PortfolioModel>("AddPortfolio"), GetPortfolios: CreatePostAction<EmptyRequest, PortfolioModel[]>("GetPortfolios"), Index: CreateGetAction<EmptyRequest>("Index"));
    }

    public PortfoliosGroupActions Actions { get; }

    public Task<PortfolioModel> AddPortfolio(AddPortfolioRequest model, CancellationToken ct = default) => Actions.AddPortfolio.Post("", model, ct);
    public Task<PortfolioModel[]> GetPortfolios(CancellationToken ct = default) => Actions.GetPortfolios.Post("", new EmptyRequest(), ct);
    public sealed record PortfoliosGroupActions(AppClientPostAction<AddPortfolioRequest, PortfolioModel> AddPortfolio, AppClientPostAction<EmptyRequest, PortfolioModel[]> GetPortfolios, AppClientGetAction<EmptyRequest> Index);
}