using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class GetAccountsAction : AppAction<EmptyRequest, AccountModel[]>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetAccountsAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<AccountModel[]> Execute(EmptyRequest model, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efAccounts = await efPortfolio.Accounts();
        return efAccounts.Select(a => a.ToModel()).ToArray();
    }
}
