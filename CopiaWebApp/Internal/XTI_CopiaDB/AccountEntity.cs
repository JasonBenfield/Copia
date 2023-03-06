namespace XTI_CopiaDB;

public sealed class AccountEntity
{
    public int ID { get; set; }
    public int PortfolioID { get; set; }
    public string AccountName { get; set; } = "";
    public int AccountType { get; set; }
}
