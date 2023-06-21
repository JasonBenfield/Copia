namespace XTI_CopiaDB;

public sealed class ActivityEntity
{
    public int ID { get; set; }
    public int PortfolioID { get; set; }
    public int ActivityTemplateID { get; set; }
    public string ActivityName { get; set; } = "";
    public DateTimeOffset TimeCreated { get; set; } = DateTimeOffset.MaxValue;
    public DateTimeOffset ActivityDate { get; set; } = DateTimeOffset.MaxValue;
    public decimal Amount { get; set; }
    public int CounterpartyID { get; set; }
}
