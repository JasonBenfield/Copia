using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class GetPortfolioAction : AppAction<EmptyRequest, PortfolioModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetPortfolioAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<PortfolioModel> Execute(EmptyRequest model, CancellationToken stoppingToken)
    {
        var portfolio = await portfolioFromModifier.Value();
        return portfolio.ToModel();
    }
}
