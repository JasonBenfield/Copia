namespace XTI_CopiaDB;

public sealed class CounterpartyEntity
{
    public int ID { get; set; }
    public int PortfolioID { get; set; }
    public string DisplayText { get; set; } = "";
    public string Url { get; set; } = "";
    public DateTimeOffset TimeDeleted { get; set; } = DateTimeOffset.MaxValue;
}
