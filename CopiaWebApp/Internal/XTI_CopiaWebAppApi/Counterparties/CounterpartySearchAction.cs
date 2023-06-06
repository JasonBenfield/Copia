using XTI_Copia.Abstractions;
using XTI_CopiaDB;

namespace XTI_CopiaWebAppApi.Counterparties;

internal sealed class CounterpartySearchAction : AppAction<string, CounterpartySearchResult>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public CounterpartySearchAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<CounterpartySearchResult> Execute(string searchText, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efFoundCounterparties = await efPortfolio.CounterpartySearch(searchText, 50);
        var counterparties = efFoundCounterparties.Select(c => c.ToModel()).ToArray();
        var total = await efPortfolio.CounterpartySearchTotal(searchText);
        return new CounterpartySearchResult(counterparties, total);
    }
}
