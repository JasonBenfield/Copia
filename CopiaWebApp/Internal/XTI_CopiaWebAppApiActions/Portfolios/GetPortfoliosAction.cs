using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApiActions.Portfolios;

public sealed class GetPortfoliosAction : AppAction<EmptyRequest, PortfolioModel[]>
{
    private readonly EfCopiaDB db;
    private readonly PortfolioPermissions portfolioPermissions;

    public GetPortfoliosAction(EfCopiaDB db, PortfolioPermissions portfolioPermissions)
    {
        this.db = db;
        this.portfolioPermissions = portfolioPermissions;
    }

    public async Task<PortfolioModel[]> Execute(EmptyRequest model, CancellationToken stoppingToken)
    {
        var portfolios = await db.Portfolios.Portfolios();
        var portfolioModels = portfolios.Select(p => p.ToModel()).ToArray();
        var permissions = await portfolioPermissions.GetPermissions(portfolioModels);
        return permissions
            .Where(p => p.CanView)
            .Select(p => p.Portfolio)
            .ToArray();
    }
}
