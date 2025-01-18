using XTI_CopiaWebAppApiActions.Portfolios;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Portfolios;
public sealed partial class PortfoliosGroup : AppApiGroupWrapper
{
    internal PortfoliosGroup(AppApiGroup source, PortfoliosGroupBuilder builder) : base(source)
    {
        AddPortfolio = builder.AddPortfolio.Build();
        GetPortfolios = builder.GetPortfolios.Build();
        Index = builder.Index.Build();
        Configure();
    }

    partial void Configure();
    public AppApiAction<AddPortfolioRequest, PortfolioModel> AddPortfolio { get; }
    public AppApiAction<EmptyRequest, PortfolioModel[]> GetPortfolios { get; }
    public AppApiAction<EmptyRequest, WebViewResult> Index { get; }
}