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
        await db.Counterparties.Create(counterparty);
        return new EfCounterparty(db, counterparty);
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
        return counterparties.Select(c => new EfCounterparty(db, c)).ToArray();
    }

    private IQueryable<CounterpartyEntity> SearchQuery(PortfolioEntity portfolio, string searchText)
    {
        searchText = searchText.ToLower().Trim();
        return db.Counterparties.Retrieve()
            .Where
            (
                c =>
                    c.PortfolioID == portfolio.ID &&
                    c.DisplayText != "" &&
                    c.DisplayText.ToLower().StartsWith(searchText)
            );
    }

    internal async Task<EfCounterparty> Counterparty(PortfolioEntity portfolio, int id)
    {
        var counterparty = await db.Counterparties.Retrieve()
            .Where(c => c.PortfolioID == portfolio.ID && c.ID == id)
            .FirstOrDefaultAsync();
        return new EfCounterparty(db, counterparty ?? throw new Exception($"Counterparty {id} not found for portfolio {portfolio.ID}"));
    }

    internal async Task<EfCounterparty> CounterpartyByDisplayText(PortfolioEntity portfolio, string displayText)
    {
        displayText = displayText.Trim().ToLower();
        var counterparty = await db.Counterparties.Retrieve()
            .Where(c => c.PortfolioID == portfolio.ID && c.DisplayText.ToLower() == displayText)
            .FirstOrDefaultAsync();
        return new EfCounterparty(db, counterparty ?? new CounterpartyEntity());
    }
}
