// Generated Code
namespace XTI_CopiaAppClient;
public sealed partial class PortfolioGroup : AppClientGroup
{
    public PortfolioGroup(IHttpClientFactory httpClientFactory, XtiTokenAccessor xtiTokenAccessor, AppClientUrl clientUrl, AppClientOptions options) : base(httpClientFactory, xtiTokenAccessor, clientUrl, options, "Portfolio")
    {
        Actions = new PortfolioGroupActions(Index: CreateGetAction<EmptyRequest>("Index"));
    }

    public PortfolioGroupActions Actions { get; }

    public sealed record PortfolioGroupActions(AppClientGetAction<EmptyRequest> Index);
}