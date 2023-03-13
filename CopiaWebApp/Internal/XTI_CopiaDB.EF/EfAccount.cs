using XTI_Copia.Abstractions;

namespace XTI_CopiaDB.EF;

public sealed class EfAccount
{
    private readonly AccountEntity entity;

    internal EfAccount(AccountEntity entity)
    {
        this.entity = entity;
    }

    public AccountModel ToModel() =>
        new AccountModel(entity.ID, entity.AccountName, AccountType.Values.Value(entity.AccountType));
}
