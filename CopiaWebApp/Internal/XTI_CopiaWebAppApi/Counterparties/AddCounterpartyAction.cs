using XTI_Copia.Abstractions;

namespace XTI_CopiaWebAppApi.Counterparties;

internal sealed class AddCounterpartyAction : AppAction<AddCounterpartyForm, CounterpartyModel>
{
    private readonly PortfolioFromModifier portfolioFromModifier;

    public AddCounterpartyAction(PortfolioFromModifier portfolioFromModifier)
    {
        this.portfolioFromModifier = portfolioFromModifier;
    }

    public async Task<CounterpartyModel> Execute(AddCounterpartyForm model, CancellationToken stoppingToken)
    {
        var efPortfolio = await portfolioFromModifier.Value();
        var displayText = model.DisplayText.Value()?.Trim() ?? "";
        var existingCounterparty = await efPortfolio.CounterpartyByDisplayText(displayText);
        if (existingCounterparty.IsFound())
        {
            throw new AppException(ValidationErrors.CounterpartyAlreadyExists);
        }
        var url = model.Url.Value()?.Trim() ?? "";
        var efCounterparty = await efPortfolio.AddCounterparty(displayText, url);
        return efCounterparty.ToModel();
    }
}
