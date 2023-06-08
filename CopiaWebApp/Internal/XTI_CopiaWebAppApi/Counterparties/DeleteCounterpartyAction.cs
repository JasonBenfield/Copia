using XTI_Core;

namespace XTI_CopiaWebAppApi.Counterparties;

internal sealed class DeleteCounterpartyAction : AppAction<int, EmptyActionResult>
{
    private readonly PortfolioFromModifier portfolioFromModifier;
    private readonly IClock clock;

    public DeleteCounterpartyAction(PortfolioFromModifier portfolioFromModifier, IClock clock)
    {
        this.portfolioFromModifier = portfolioFromModifier;
        this.clock = clock;
    }

    public async Task<EmptyActionResult> Execute(int counterpartyID, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var efCounterparty = await efPortfolio.Counterparty(counterpartyID);
        await efCounterparty.Delete(clock.Now());
        return new EmptyActionResult();
    }
}
