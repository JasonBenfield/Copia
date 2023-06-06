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
            () => AddPortfolio(addRequest, ct)
        );
        return addedPortfolio;
    }

    private async Task<PortfolioModel> AddPortfolio(AddPortfolioRequest addRequest, CancellationToken ct)
    {
        var efPortfolio = await new EfPortfolios(db).AddPortfolio
        (
            addRequest.PortfolioName,
            clock.Now()
        );
        await efPortfolio.AddCounterparty("", "");
        var portfolioModel = efPortfolio.ToModel();
        await hubService.AddModifier
        (
            CopiaInfo.ModCategories.Portfolio,
            portfolioModel.PublicKey,
            portfolioModel.ID.ToString(),
            portfolioModel.PortfolioName,
            ct
        );
        var userName = await currentUserName.Value();
        await hubService.AssignRoleToUser
        (
            userName,
            CopiaInfo.ModCategories.Portfolio,
            portfolioModel.PublicKey,
            CopiaInfo.Roles.PortfolioOwner,
            ct
        );
        return portfolioModel;
    }
}