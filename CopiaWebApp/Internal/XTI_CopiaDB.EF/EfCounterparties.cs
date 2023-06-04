using Microsoft.EntityFrameworkCore;

namespace XTI_CopiaDB.EF;

public sealed class EfCounterparties
{
    private readonly CopiaDbContext db;

    public EfCounterparties(CopiaDbContext db)
    {
        this.db = db;
    }

    internal async Task<EfCounterparty> Add(PortfolioEntity portfolio, string displayText, string url)
    {
        var counterparty = new CounterpartyEntity
        {
            PortfolioID = portfolio.ID,
            DisplayText = displayText,
            Url = url
        };
        await db.CounterParties.Create(counterparty);
        return new EfCounterparty(counterparty);
    }

    internal Task<int> SearchTotal(PortfolioEntity portfolio, string searchText) =>
        SearchQuery(portfolio, searchText)
        .CountAsync();

    internal async Task<EfCounterparty[]> Search(PortfolioEntity portfolio, string searchText, int max)
    {
        var counterparties = await SearchQuery(portfolio, searchText)
            .OrderBy(c => c.DisplayText)
            .Take(max)
            .ToArrayAsync();
        return counterparties.Select(c => new EfCounterparty(c)).ToArray();
    }

    private IQueryable<CounterpartyEntity> SearchQuery(PortfolioEntity portfolio, string searchText)
    {
        searchText = searchText.ToLower().Trim();
        return db.CounterParties.Retrieve()
            .Where
            (
                c => 
                    c.PortfolioID == portfolio.ID && 
                    c.DisplayText != "" &&
                    c.DisplayText.ToLower().StartsWith(searchText)
            );
    }
}
