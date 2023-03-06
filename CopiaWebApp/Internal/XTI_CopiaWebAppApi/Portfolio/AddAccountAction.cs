using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.Portfolio;

internal sealed class AddAccountAction : AppAction<AddAccountForm, AccountModel>
{
    private readonly CopiaDbContext db;

    public AddAccountAction(CopiaDbContext db)
    {
        this.db = db;
    }

    public async Task<AccountModel> Execute(AddAccountForm model, CancellationToken stoppingToken)
    {
        var account = new AccountEntity
        {
            AccountName = model.AccountName.Value() ?? "",
            AccountType = AccountType.Values.Value(model.AccountType.Value() ?? 0)
        };
        await db.Accounts.Create(account);
        return new AccountModel();
    }
}
