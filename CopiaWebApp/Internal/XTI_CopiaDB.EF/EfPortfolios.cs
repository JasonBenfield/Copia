using Microsoft.EntityFrameworkCore;

namespace XTI_CopiaDB.EF;

public sealed class EfPortfolios
{
    private readonly CopiaDbContext db;

    public EfPortfolios(CopiaDbContext db)
    {
        this.db = db;
    }

    public async Task<EfPortfolio> AddPortfolio(string portfolioName, DateTimeOffset timeAdded)
    {
        var portfolio = new PortfolioEntity
        {
            PortfolioName = portfolioName.Trim(),
            TimeAdded = timeAdded
        };
        await db.Portfolios.Create(portfolio);
        return new EfPortfolio(db, portfolio);
    }

    public Task<EfPortfolio[]> Portfolios() =>
        db.Portfolios.Retrieve()
            .Select(p => new EfPortfolio(db, p))
            .ToArrayAsync();

    public Task<EfPortfolio> Portfolio(ModifierKey publicKey)
    {
        if (!int.TryParse(publicKey.Value, out var portfolioID))
        {
            throw new ArgumentException($"Unable to convert '{publicKey.Value}' to portfolio ID");
        }
        return Portfolio(portfolioID);
    }

    public async Task<EfPortfolio> Portfolio(int portfolioID)
    {
        var entity = await db.Portfolios.Retrieve()
            .Where(p => p.ID == portfolioID)
            .FirstOrDefaultAsync();
        return new EfPortfolio(db, entity ?? throw new ArgumentException(string.Format(CopiaDBErrors.PortfolioIDNotFound, portfolioID)));
    }
}
