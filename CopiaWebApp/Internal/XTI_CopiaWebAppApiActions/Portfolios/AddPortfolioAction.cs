using XTI_Copia.Abstractions;
using XTI_CopiaDB;
using XTI_Core;

namespace XTI_CopiaWebAppApiActions.Portfolios;

public sealed class AddPortfolioAction : AppAction<AddPortfolioRequest, PortfolioModel>
{
    private readonly EfCopiaDB db;
    private readonly IClock clock;
    private readonly IHubService hubService;
    private readonly ICurrentUserName currentUserName;

    public AddPortfolioAction(EfCopiaDB db, IClock clock, IHubService hubService, ICurrentUserName currentUserName)
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
        var efPortfolio = await db.Portfolios.AddPortfolio
        (
            addRequest.PortfolioName,
            clock.Now()
        );
        await efPortfolio.AddCounterparty("", "");
        var portfolioModel = efPortfolio.ToModel();
        await hubService.AddModifier
        (
            CopiaModCategories.Instance.Portfolio,
            portfolioModel.PublicKey,
            portfolioModel.ID.ToString(),
            portfolioModel.PortfolioName,
            ct
        );
        var userName = await currentUserName.Value();
        await hubService.AssignRoleToUser
        (
            userName,
            CopiaModCategories.Instance.Portfolio,
            portfolioModel.PublicKey,
            CopiaRoles.Instance.PortfolioOwner,
            ct
        );
        return portfolioModel;
    }
}