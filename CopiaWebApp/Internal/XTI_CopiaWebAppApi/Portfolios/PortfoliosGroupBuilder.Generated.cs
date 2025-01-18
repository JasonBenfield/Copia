using XTI_CopiaWebAppApiActions.Portfolios;

// Generated Code
#nullable enable
namespace XTI_CopiaWebAppApi.Portfolios;
public sealed partial class PortfoliosGroupBuilder
{
    private readonly AppApiGroup source;
    internal PortfoliosGroupBuilder(AppApiGroup source)
    {
        this.source = source;
        AddPortfolio = source.AddAction<AddPortfolioRequest, PortfolioModel>("AddPortfolio").WithExecution<AddPortfolioAction>().WithValidation<AddPortfolioValidation>();
        GetPortfolios = source.AddAction<EmptyRequest, PortfolioModel[]>("GetPortfolios").WithExecution<GetPortfoliosAction>();
        Index = source.AddAction<EmptyRequest, WebViewResult>("Index").WithExecution<IndexAction>();
        Configure();
    }

    partial void Configure();
    public AppApiActionBuilder<AddPortfolioRequest, PortfolioModel> AddPortfolio { get; }
    public AppApiActionBuilder<EmptyRequest, PortfolioModel[]> GetPortfolios { get; }
    public AppApiActionBuilder<EmptyRequest, WebViewResult> Index { get; }

    public PortfoliosGroup Build() => new PortfoliosGroup(source, this);
}