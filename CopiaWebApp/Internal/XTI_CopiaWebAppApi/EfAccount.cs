using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi;

internal sealed class EfAccount
{
    private readonly AccountEntity entity;

    public EfAccount(AccountEntity entity)
    {
        this.entity = entity;
    }

    public AccountModel ToModel() =>
        new AccountModel(entity.ID, entity.AccountName, AccountType.Values.Value(entity.AccountType));
}
