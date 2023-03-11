using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Account;

internal sealed class GetAccountAction : AppAction<GetAccountRequest, AccountModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public GetAccountAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<AccountModel> Execute(GetAccountRequest getRequest, CancellationToken stoppingToken)
    {
        var portfolio = await portfolioFromModifier.Value();
        var account = await portfolio.Account(getRequest.AccountID);
        return account.ToModel();
    }
}
