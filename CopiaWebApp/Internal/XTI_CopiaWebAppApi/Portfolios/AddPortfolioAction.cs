using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_Core;

namespace XTI_CopiaWebAppApi.Portfolios;

public sealed class AddPortfolioAction : AppAction<AddPortfolioRequest, PortfolioModel>
{
    private readonly CopiaDbContext db;
    private readonly IClock clock;

    public AddPortfolioAction(CopiaDbContext db, IClock clock)
    {
        this.db = db;
        this.clock = clock;
    }

    public async Task<PortfolioModel> Execute(AddPortfolioRequest model, CancellationToken ct)
    {
        var portfolio = new PortfolioEntity
        {
            PortfolioName = model.PortfolioName.Trim(),
            TimeAdded = clock.Now()
        };
        await db.Portfolios.Create(portfolio);
        return new PortfolioModel(portfolio.ID, portfolio.PortfolioName);
    }
}