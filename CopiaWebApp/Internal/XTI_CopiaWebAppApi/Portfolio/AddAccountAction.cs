using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class AddAccountAction : AppAction<AddAccountForm, AccountModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public AddAccountAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<AccountModel> Execute(AddAccountForm addForm, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efAccount = await efPortfolio.AddAccount
        (
            addForm.AccountName.Value() ?? "",
            AccountType.Values.Value(addForm.AccountType.Value() ?? 0)
        );
        return efAccount.ToModel();
    }
}
