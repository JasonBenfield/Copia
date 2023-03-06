namespace XTI_Copia.Abstractions;

public sealed record AccountModel(int ID, string AccountName, AccountType AccountType)
{
    public AccountModel()
        : this(0, "", AccountType.Values.GetDefault())
    {
    }
}
