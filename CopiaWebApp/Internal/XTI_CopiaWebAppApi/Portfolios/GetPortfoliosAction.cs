using Microsoft.EntityFrameworkCore;
using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.Portfolios;

internal sealed class GetPortfoliosAction : AppAction<EmptyRequest, PortfolioModel[]>
{
    private readonly CopiaDbContext db;
    private readonly PortfolioPermissions portfolioPermissions;

    public GetPortfoliosAction(CopiaDbContext db, PortfolioPermissions portfolioPermissions)
    {
        this.db = db;
        this.portfolioPermissions = portfolioPermissions;
    }

    public async Task<PortfolioModel[]> Execute(EmptyRequest model, CancellationToken stoppingToken)
    {
        var portfolios = await db.Portfolios.Retrieve()
            .Select(p => p.ToPortfolioModel())
            .ToArrayAsync();
        var permissions = await portfolioPermissions.GetPermissions(portfolios);
        return permissions
            .Where(p => p.CanView)
            .Select(p => p.Portfolio)
            .ToArray();
    }
}
