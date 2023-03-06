using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolios;

public sealed class PortfoliosGroup : AppApiGroupWrapper
{
    public PortfoliosGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        AddPortfolio = source.AddAction
        (
            nameof(AddPortfolio),
            () => sp.GetRequiredService<AddPortfolioAction>(),
            () => sp.GetRequiredService<AddPortfolioValidation>()
        );
        GetPortfolios = source.AddAction
        (
            nameof(GetPortfolios),
            () => sp.GetRequiredService<GetPortfoliosAction>()
        );
    }

    public AppApiAction<AddPortfolioRequest, PortfolioModel> AddPortfolio { get; }

    public AppApiAction<EmptyRequest, PortfolioModel[]> GetPortfolios { get; }
}