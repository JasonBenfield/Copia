using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolios;

public sealed class PortfoliosGroup : AppApiGroupWrapper
{
    public PortfoliosGroup(AppApiGroup source, IServiceProvider sp)
        : base(source)
    {
        AddPortfolio = source.AddAction(nameof(AddPortfolio), () => sp.GetRequiredService<AddPortfolioAction>());
    }

    public AppApiAction<AddPortfolioRequest, PortfolioModel> AddPortfolio { get; }
}