namespace XTI_CopiaDB;

public sealed class PortfolioEntity
{
    public int ID { get; set; }
    public string PortfolioName { get; set; } = "";
    public DateTimeOffset TimeAdded { get; set; }
}