namespace XTI_CopiaDB.EF;

public sealed class EfCounterparties
{
    private readonly CopiaDbContext db;

    public EfCounterparties(CopiaDbContext db)
    {
        this.db = db;
    }

    public async Task<EfCounterparty> Add(string displayText, string url)
    {
        var counterparty = new CounterpartyEntity
        {
            DisplayText = displayText,
            Url = url
        };
        await db.CounterParties.Create(counterparty);
        return new EfCounterparty(counterparty);
    }
}
