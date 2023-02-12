using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_Core;

namespace XTI_CopiaWebAppApi.Portfolios;

internal sealed class AddPortfolioAction : AppAction<AddPortfolioRequest, PortfolioModel>
{
    private readonly CopiaDbContext db;
    private readonly IClock clock;
    private readonly IHubService hubService;
    private readonly ICurrentUserName currentUserName;

    public AddPortfolioAction(CopiaDbContext db, IClock clock, IHubService hubService, ICurrentUserName currentUserName)
    {
        this.db = db;
        this.clock = clock;
        this.hubService = hubService;
        this.currentUserName = currentUserName;
    }

    public async Task<PortfolioModel> Execute(AddPortfolioRequest addRequest, CancellationToken ct)
    {
        var addedPortfolio = await db.Transaction
        (
            () => AddPortfolio(addRequest)
        );
        return addedPortfolio;
    }

    private async Task<PortfolioModel> AddPortfolio(AddPortfolioRequest addRequest)
    {
        var portfolio = new PortfolioEntity
        {
            PortfolioName = addRequest.PortfolioName.Trim(),
            TimeAdded = clock.Now()
        };
        await db.Portfolios.Create(portfolio);
        var portfolioModel = portfolio.ToPortfolioModel();
        await hubService.AddPortfolioModifier(portfolioModel);
        var userName = await currentUserName.Value();
        await hubService.AssignPortfolioRoleToUser
        (
            userName, 
            portfolioModel, 
            CopiaInfo.Roles.PortfolioOwner
        );
        return portfolioModel;
    }
}